namespace CustomerManager
{
    
    public class SilverMembership : Membership
    {
        // Business requirement: silver membership fees: $15.00 / month
        private const double SilverRate = 15.0;

        public SilverMembership(int membershipPeriod) : base(membershipPeriod)
        {
            MembershipPeriod = membershipPeriod;
        }

        public override double CalculateMembershipFees()
        {
            return MembershipPeriod * SilverRate;
        }

        public override string ToString() => "Silver";
    }
    
}