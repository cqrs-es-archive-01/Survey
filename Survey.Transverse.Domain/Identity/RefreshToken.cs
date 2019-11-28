using Survey.Common.Types;
using Survey.Transverse.Domain.Users;
using System;
using System.Security.Cryptography;

namespace Survey.Transverse.Domain.Identity
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; set; }

        public string JwtId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public bool Used { get; set; }

        public bool Invalidated { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public RefreshToken() : base()
        {
            Token = GenerateRefreshToken();
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }


    }

}
