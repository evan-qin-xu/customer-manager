namespace CustomerManager
{
    class PlatinumMembership : Membership
    {
        // Business requirement: platinum membership fees: $12.00 / month
        private const double SilverRate = 12.0;

        public PlatinumMembership(int membershipPeriod) : base(membershipPeriod)
        {
            MembershipPeriod = membershipPeriod;
        }

        public override double CalculateMembershipFees()
        {
            return MembershipPeriod * SilverRate;
        }

        public override string ToString() => "Platinum";
    }
}
