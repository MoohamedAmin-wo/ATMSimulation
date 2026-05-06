
using Microsoft.AspNetCore.Identity;

namespace ATMSimulation.Domain.Entities;
public  class ApplicationUser : IdentityUser
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateOnly DateOfBirth { get; set; }

    public string Fullname => string.Concat(Firstname, ' ', Lastname);
    public int Age => DateTime.Now.Year - DateOfBirth.Year;

    public Customer Customer { get; set; }
}