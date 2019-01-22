namespace SIS.MVC.Framework.Services
{
    using Contracts;
    using Loggers.Contracts;
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class HashService : IHashService
    {
        private readonly ILogger logger;

        public HashService(ILogger logger)
        {
            this.logger = logger;
        }

        public string Hash(string str)
        {
            using (var hash = SHA256.Create())
            {
                return String.Concat(hash
                    .ComputeHash(Encoding.UTF8.GetBytes(str + "hufNAWoi*&&*nbwaKni90i09u3095i"))
                    .Select(item => item.ToString("x2")));
            }
        }
    }
}