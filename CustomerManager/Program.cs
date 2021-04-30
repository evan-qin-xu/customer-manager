using System;
using System.Collections;
using System.Linq;

namespace CustomerManager
{
    class Program
    {   
        // Business requirement: Special offer is 90% of the total membership fees.
        private const double DiscountOffer = 0.9;
        
        public static void Main()
        {
            Console.WriteLine("Student Name: Qin Xu\nStudent ID: s4647307\n\n");

            var numberOfCustomers = GetNumberOfCustomers();
            var customers = GetCustomersInfo(numberOfCustomers);

            DisplaySummary("Summary of Membership Fees", new[] { "Name", "Months", "Special", "Offer", "Fees" }, customers);
            DisplayMembershipDetails(customers);

            // To keep the console window for user to read displayed information.
            Console.ReadKey();
        }

        private static int GetNumberOfCustomers()
        {
            Console.WriteLine("Hi, tell me how many customers do you need to enter?");
            int numberOfCustomers;

            while (true)
            {
                try
                {
                    numberOfCustomers = short.Parse(Console.ReadLine());
                    // Customers array cannot be empty array
                    if (numberOfCustomers == 0)
                    {
                        Console.WriteLine("The number of customers cannot be 0. Please try again.");
                        continue;
                    }

                    break;

                }
                catch (Exception)

                {
                    Console.WriteLine("Please enter integer value of customer numbers.");
                }
            }

            return numberOfCustomers;
        }

        // Function to get all the inputs from user
        private static Customer[] GetCustomersInfo(int numberOfCustomers)
        {
            Customer[] customers = new Customer[numberOfCustomers];
            var count = 0;

            while (true)
            {
                var customer = new Customer();
                Console.WriteLine("\nPlease enter information for customer {0}", count + 1);

                customer.Name = GetCustomerName();
                customer.MembershipPeriod = GetMembershipPeriod();
                customer.IsSpecial = GetSpecialOfferStatus();
                customer.MembershipType = GetMembershipType(customer.MembershipPeriod);
                customer.Fees = GetMembershipFees(customer);
                customers[count] = customer;
                count++;

                Console.WriteLine("The membership fee for {0} is {1:C}.", customer.Name, customer.Fees);

                if (count != numberOfCustomers) continue;

                return customers;
            }
        }

        private static void DisplayMembershipDetails(Customer[] customers)
        {
            var mostPayCustomer = customers.OrderBy(c => c.Fees).First();
            var leastPayCustomer = customers.OrderBy(c => c.Fees).Last();
            Console.WriteLine("The customer spending the most is {0} : {1:C}", mostPayCustomer.Name, mostPayCustomer.Fees);
            Console.WriteLine("The customer spending the least is {0} : {1:C}", leastPayCustomer.Name, leastPayCustomer.Fees);

            var totalSilverCustomers = customers.Count(c => c.MembershipPeriod < 12);
            var totalNonSilverCustomers = customers.Count(c => c.MembershipPeriod >= 12);
            Console.WriteLine("The number of members with less than 12 months memberships: {0}", totalSilverCustomers);
            Console.WriteLine("The number of members with more than 12 months(include 12 months) memberships: {0}", totalNonSilverCustomers);
        }

        private static void DisplaySummary(string title, string[] columns, IEnumerable items)
        {
            var printer = new SummaryPrinter(title, columns, items);
            printer.PrintSummaryTable();
        }

        // Function to get membership type based on the period: silver: less than 12; gold: between 12 and 24; platinum: longer than 12.
        private static Membership GetMembershipType(int membershipPeriod)
        {
            if (membershipPeriod <= 12)
                return new SilverMembership(membershipPeriod);
            if (membershipPeriod <= 24)
                return new GoldMembership(membershipPeriod);
            return new PlatinumMembership(membershipPeriod);
        }

        // Function to prompt user for entering customer name
        private static string GetCustomerName()
        {
            while (true)
            {
                Console.Write("Customer name: ");
                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name)) continue;
                return name;
            }
        }

        // Function to prompt user for entering customer membership period
        private static int GetMembershipPeriod()
        {

            while (true)
            {
                Console.Write("Number of month for membership: ");
                var membership = Console.ReadLine();
                if (string.IsNullOrEmpty(membership)) continue;

                try
                {
                    var membershipPeriod = Convert.ToInt32(membership); 
                    if (membershipPeriod >= 1 && membershipPeriod <= 120) // Implement business rules: membership period should be between 1 and 120 months.
                        return membershipPeriod;
                    Console.WriteLine("Membership period should be in the range of 1 to 120. Please re-enter.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter integer number of membership period");
                }
            }
        }

        // Function to prompt user for entering if is special offer or not 
        private static bool GetSpecialOfferStatus()
        {
            while (true)
            {
                Console.Write("Receive special offer? (Yes or No): \n");
                var isSpecial = Console.ReadLine();
                if (string.IsNullOrEmpty(isSpecial)) continue;
                switch (isSpecial.ToLower())
                {
                    case "yes":
                    case "y":
                        return true;
                    case "no":
                    case "n":
                        return false;
                    default:
                        Console.WriteLine("Please enter if the customer receives special offer or not.");
                        break;
                }
            }
        }

        // Function to calculate membership fees for each customer
        private static double GetMembershipFees(Customer customer)
        {
            var fees = customer.MembershipType.CalculateMembershipFees();
            if (customer.IsSpecial)
                fees *= DiscountOffer;

            return fees;

        }
    }
}
