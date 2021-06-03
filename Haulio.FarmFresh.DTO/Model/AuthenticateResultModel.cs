namespace Haulio.FarmFresh.DTO.Model
{
    public class AuthenticateResultModel
    {
        public string access_token { get; set; }
        public int ExpireInSeconds { get; set; }
    }
}
