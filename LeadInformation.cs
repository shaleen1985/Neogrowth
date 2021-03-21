namespace NeoGrowth.Entity
{
    public class LeadInformation
    {
        public int Id { get; set; }
        public uint LoanAmountRequires { get; set; }

        public enum LeadSource
        {
            Emailer = 0,
            DirectSalesAgent = 1,
            NewsPaper = 2,
            Marketing = 3
        }
        public string CommunicationMode { get; set; }

        public enum CurrentStatus
        {
            InitialCommunication = 0,
            FollowUp = 1,
            NotInterested = 2,
            ConvertedToCustomer = 3
        }

        public ContactDetail ContactDetail { get; set; }
    }
}
