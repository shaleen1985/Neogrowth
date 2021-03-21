using System;

namespace NeoGrowth.Entity
{
    public class CommunicationLog
    {
        public int Id { get; set; }

        public int LeadId { get; set; }
        public DateTime CommunicationDate { get; set; }

        public string CommunicationMode { get; set; }

        public string Status { get; set; }

    }
}
