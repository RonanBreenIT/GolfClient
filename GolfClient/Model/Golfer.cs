using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GolfClub.Models
{
    public enum MemberType { Youth, FullTime, PartTime, Patron, Student };

    public class Golfer
    {
        public int GUI { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public MemberType Membership { get; set; }

        public int Handicap { get; set; }

        public DateTime DateJoined { get; set; }

        public int YearlyFees { get; set; }

        public override string ToString()
        {
            return "\nFirst Name: " + this.FirstName + "\nSurname: " + this.Surname + "\nGUI: " + this.GUI + "\nMembership Type: " + this.Membership + "\nHandicap: " + this.Handicap + "\nYearly Fees: " + this.YearlyFees + "\nDate Joined: " + this.DateJoined;

        }
    }
}