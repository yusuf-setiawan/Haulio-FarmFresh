using Haulio.FarmFresh.DTO.Model;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Haulio.FarmFresh.Utility
{
    public static class TokenUtility
    {
        private static string _secret = "MIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQCP2svRLjkzM28A9iDzxip0g5ag2lLiYZdvQOPpzTJo8RjubcnYYjCEsiDEmwKqZqPEorGH3NNRGcJ8NVPg2fOWaLv5VXl/xySkOk2fpATZxCxHRdnc8X2v3ve+/cpbYmkr+awTLPfV6gBdXb7OnyL1Wem7iANtnG4O8fHaTFwMs9jiV4Y2w+qTNT5gKuyFtseKl2i0gtqFx6S+g19wpuyTNYBaa1q31C18u8gEWNSjq9wRtvQD2L02HJzC2umE22kJdWP7L0B3wAjqc/X758MRK4oeHDhGVakfM9kSGuKujsOzi2VnMq3QbVhzKgJwn22pOGi8XaRFCrtpxSTv3ZRTAgMBAAECggEAUt/+I9i5Y2HyRV+GxGoZ814L3UdqELmggJulsgBhVkvvzQy7CEopIYltj1auRnUzTAletaLmqwZoIR6n4BYwWyqjgJVZld+ooGRma94WXU7DI5x+UuddPYD6wbF8bwFXDdqc4784WKii5Sco0eikPy05lqxZLUC9tyZz6wuqzDXDUW9eUjg2tN3olyooNA0s37mgUqtM/mfI2r5n8F7s0cQ2y0AzEHb3FC7O1se7aC9jhu0Poo0p5fFBDld470gi5E6RJNS68VuzAWKYfJwbFbvTpqU/NRy3MNDDkOYceZFDPWVwNsiumAhsXSu/58mOTwkUKSm+3vLWriDPgdGPAQKBgQDBrqWLPENof2lX2RB3Hj4BZKRb2YTQ3Scea4pTtYGqroTFn+XDUf8oSuPKKVDS7wY88YwXP6Y+isHRg0AtCApJu56amEJDgpCBESNA8U7UeQJVFvBUvFpcVEKU0Pbat4HZhbPYMaO3oR/CBkjToS70J9hlfRTx0NFyePha1WdTIQKBgQC+I+tfBN9Rk6SlUgIGwrL/ZUnPxpl5MquYZaMwIuuP1fvFVjTH3AOQXGlljriUfOSuWi0mfD0Kwg+lojb2DEFdDocKISuj7kdlJzKJDkE5HKE80n7QWRvzxQDN/k1M/dGtB3XgR+nkCR9ln3XiAVwzXXhmfytZ86f74cA/jIAs8wKBgQC1zUbtDHNFyptKb6FJ/uQ7EIpLAUHvgDexEUb1zmFZoplUnAPjNLuqyalKYT/Rz7XuTNmwFPnqqPrHvEjoPCzUCz4UZSmGDy+vRzPtSNUzEieDUZXkJC05j4o0AHZG1YwYb61iGS5RNvgFezqvFBRr8F7q3N9lIRsJNc4CDWEAoQKBgQCbu/PWmbkHqfQa7DZ4rxPJF38DTVj66cOeSPEGRjPGVa+ni9ojMFNC9E3nPqR0Cm+LVpTQhsXAf/4s3dZCZPtMas+0PkLuPAYCFb7Qfvpw+sAdfxMbN0ErwlnMXtOVkfcgz5F+p6gsfERZCeiVuiN4dsBcwyAQxv750YeTBVMefQKBgHfeMNWb+faprOfUBgD/2EtFLmv27Ybzbl7V+b7zL7bYwrlEHz0c82jNTlwvp8aChHkzcu8thW2+5SgMNtBUBEJKqcSrDmOEJ1ngxQ3R5o+ERghlcgLTZ3tvcKDbsR6zkmu5UKxTUrIll49wOytwC+5mpskKKwvdvGAQjb3gQWij";

         public static AuthenticateResultModel CreateAccessToken(long UserId, string Username, int ExpiredInSecond, string Secret)
        {
            using RSA rsa = RSA.Create();
             
            var param = ReadAsymmetricKeyParameter(Secret == null ? _secret : Secret);
            rsa.ImportParameters(param);

            var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
            {
                CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
            };

            var Jti = Guid.NewGuid().ToString();
            var SessionId = Guid.NewGuid().ToString();
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: "Haulio",
                claims: new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Iss, "Haulio"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, UserId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString(), ClaimValueTypes.Integer64)
               },
                notBefore: now,
                expires: now.AddSeconds(ExpiredInSecond),
                signingCredentials: signingCredentials
            );

            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new AuthenticateResultModel
            {
                access_token = token,
                ExpireInSeconds = Convert.ToInt32(ExpiredInSecond),
            };
        }

        private static RSAParameters ReadAsymmetricKeyParameter(string pkey)
        {
            RsaPrivateCrtKeyParameters rsaPrivateCrtKeyParameters1;
            var keyBytes = Convert.FromBase64String(pkey);
            var asymmetricKeyParameter = PrivateKeyFactory.CreateKey(keyBytes);

            rsaPrivateCrtKeyParameters1 = (RsaPrivateCrtKeyParameters)asymmetricKeyParameter;

            RSAParameters r = DotNetUtilities.ToRSAParameters(rsaPrivateCrtKeyParameters1);

            return r;
        }

        public static bool ValidateToken(string token, string Secret)
        {
            using RSA rsa = RSA.Create();
            var param = ReadAsymmetricKeyParameter(Secret);
            rsa.ImportParameters(param);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "Haulio",
                //ValidAudience = _settings.Audience,
                IssuerSigningKey = new RsaSecurityKey(rsa),
                CryptoProviderFactory = new CryptoProviderFactory()
                {
                    CacheSignatureProviders = false
                }
            };

            try
            {
                var handler = new JwtSecurityTokenHandler();
                handler.ValidateToken(token, validationParameters, out var validatedSecurityToken);
            }
            catch (Exception ex)
            {
                var exc = ex.Message;
                var asdsa = ex.StackTrace;
                return false;
            }

            return true;
        }

        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
    }
}
