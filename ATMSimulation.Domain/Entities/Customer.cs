using ATMSimulation.Domain.Common;
using Microsoft.VisualBasic;
namespace ATMSimulation.Domain.Entities;
public sealed class Customer : BaseEntity
{
    // TO Do 
    // create address entity and link to customer

    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; }
    public string NationalId { get; set; }
    public ICollection<Account> Accounts { get; set; } = new List<Account>();
}