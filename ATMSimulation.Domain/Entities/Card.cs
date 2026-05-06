using ATMSimulation.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace ATMSimulation.Domain.Entities
{
    public sealed class Card
    {
        public Guid Id { get; set; }
        public string CardHolder { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int FaildAttemp { get; set; }

        public CardType CardType { get; set; }
        public bool IsActive { get; set; }
        public bool IsFirstUseForCard { get; set; } = true;

        // Default daily limit, can be adjusted as needed
        public bool ReachLimitPerDay { get; set; }
        public decimal CurrentLimitPerDay { get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        
        public string CardPassword { get;private set; }
        
        public string CardNumber { get; private set; }
        
        public void SetCardPassword(string password , IPasswordHasher<Card> hasher)
        {
            CardPassword = hasher.HashPassword(this , password);
        }
        public bool VerfiyCardPassword(string password , IPasswordHasher<Card > hasher)
        {
            var verficationResult = hasher.VerifyHashedPassword(this , CardPassword , password);
            return verficationResult == PasswordVerificationResult.Success;
        }
    }
}