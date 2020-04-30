namespace Doublelives.Shared.ConfigModels
{
    public class JwtOptions
    {
        public string Key { get; set; }

        /// <summary>
        /// 签发者
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 接收者
        /// </summary>
        public string Audience { get; set; }

        public int ExpireMinutes { get; set; }
    }
}