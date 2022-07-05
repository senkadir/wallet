namespace Domain.Commands
{
    public class CreatePeriodCommand
    {
        public string Name { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
