using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager
{
    public class GoldMembership : Membership
    {
        // Business requirement: gold membership fees: $13.50 / month
        private const double SilverRate = 13.50;

        public GoldMembership(int membershipPeriod) : base(membershipPeriod)
        {
            MembershipPeriod = membershipPeriod;
        }

        public override double CalculateMembershipFees()
        {
            return MembershipPeriod * SilverRate;
        }

        public override string ToString() => "Gold";
    }
}
