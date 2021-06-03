using Haulio.FarmFresh.Utility;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;

namespace Haulio.FarmFresh.Web.Helper
{
    public class FarmFreshAuthorization : Attribute, IAuthorizationFilter
    {

        /// <summary>  
        /// This will Authorize User  
        /// </summary>  
        /// <returns></returns>  
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (filterContext != null)
            {
                Microsoft.Extensions.Primitives.StringValues accessToken;
                filterContext.HttpContext.Request.Headers.TryGetValue("Authorization", out accessToken);

                var _token = accessToken.FirstOrDefault();

                if (_token != null)
                {
                    string authToken = _token.Replace("Bearer ", "");
                    if (authToken != null)
                    {
                        var ErrorList = IsValidToken(authToken);
                        if (ErrorList.Count() == 0)
                        {
                            filterContext.HttpContext.Response.Headers.Add("authToken", authToken);
                            filterContext.HttpContext.Response.Headers.Add("AuthStatus", "Authorized");

                            filterContext.HttpContext.Response.Headers.Add("storeAccessiblity", "Authorized");

                            return;
                        }
                        else
                        {
                            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "log");
                            var _logger = new LoggerConfiguration()
                             .WriteTo.File($"{fullPath}\\log {DateTime.Now.ToString("yyyy-MM-dd")}.txt", LogEventLevel.Error)
                             .CreateLogger();


                            _logger.Error("Error OnAuthorization ", ErrorList);

                            filterContext.HttpContext.Response.Headers.Add("authToken", authToken);
                            filterContext.HttpContext.Response.Headers.Add("AuthStatus", "NotAuthorized");

                            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            filterContext.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Not Authorized";
                            filterContext.Result = new JsonResult("NotAuthorized")
                            {
                                Value = new
                                {
                                    code = 401,
                                    msg = "Invalid Token"
                                },
                            };
                        }
                    }
                }
                else
                {
                    filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    filterContext.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Not Authorized";
                    filterContext.Result = new JsonResult("NotAuthorized")
                    {
                        Value = new
                        {
                            code = 401,
                            msg = "UnAuthorized"
                        },
                    };
                }
            }
        }

        public List<string> IsValidToken(string authToken)
        {
            ConfigurationLoader config = new ConfigurationLoader();
            config.Load();

            var Secret = config.GetProperty("AppSettings.Secret")?.ToString();
            string ExpiredInSecondStr = config.GetProperty("AppSettings.ExpiredInSecond")?.ToString();
            int ExpiredInSecond = ExpiredInSecondStr.ParseInt(600);

            List<string> Message = new List<string>();
            try
            {
                //validate Token here  
                var isValidate = TokenUtility.ValidateToken(authToken, Secret);
                if (isValidate)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwtToken = handler.ReadToken(authToken) as JwtSecurityToken;

                    var issuer = jwtToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Iss).Value;
                    if (issuer != "Haulio")
                        Message.Add("Invalid Issuer");

                    var posixTime = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);
                    var expt = jwtToken.Claims.First(claim => claim.Type == "iat").Value;
                    DateTime iat = new DateTime(1970, 1, 1) + TimeSpan.FromMilliseconds(double.Parse(expt));
                    var timeexp = iat.AddSeconds(ExpiredInSecond);
                    if (timeexp < DateTime.UtcNow)
                        Message.Add("Expired Token");

                }
                else
                    Message.Add("Invalid Token");

                return Message;
            }
            catch (Exception ex)
            {
                Message.Add(ex.Message);
                return Message;
            }
        }
    }

}
