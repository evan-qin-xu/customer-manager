

namespace CustomerManager
{
    class Customer
    {
        public string Name { get; set; }
        public int MembershipPeriod { get; set; }
        public bool IsSpecial { get; set; }
        public Membership MembershipType{ get; set; }
        public double Fees { get; set; }

        public override string ToString()
        {
            return
                $"{Name,15}{MembershipPeriod,15}{ToYesOrNoString(IsSpecial),15}{MembershipType,15}{Fees,15:C}";
        }

        // make boolean value "Yes" or "No" when printed on the console
        private static string ToYesOrNoString(bool value)
        {
            return value ? "Yes" : "No";
        }
    }
}
