namespace ATMSimulation.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set;  }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdtedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
