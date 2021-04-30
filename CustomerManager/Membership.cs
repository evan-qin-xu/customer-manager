namespace CustomerManager
{
    public abstract class Membership
    {
        public int MembershipPeriod { get; set; }

        protected Membership(int membershipPeriod)
        {
            MembershipPeriod = membershipPeriod;
        }

        // default membership fees is 0, derived classes should implement specific fees accordingly
        public virtual double CalculateMembershipFees()
        {
            return 0 * MembershipPeriod;
        }
    }
}