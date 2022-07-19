namespace Domain.Models
{
    public class PeriodViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
