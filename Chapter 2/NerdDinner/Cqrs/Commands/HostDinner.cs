namespace NerdDinner.Cqrs.Commands
{
    public class HostDinner
    {
        public string HostedBy { get; set; }

        public HostDinner(string hostedBy)
        {
            HostedBy = hostedBy;
        }
    }
}