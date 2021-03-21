using System;

namespace NeoGrowth.Entity
{
    public class ContactDetail
    {
        public int Id { get; set; }

        public int ContactType { get; set; }

        public string ContactName { get; set; }

        public DateTime DateofBirth { get; set; }

        public enum Gender
        {
            Male = 0,
            Female = 1
        }

        public string EmailAddress { get; set; }

        public string ContactNumbers { get; set; }


    }
}
