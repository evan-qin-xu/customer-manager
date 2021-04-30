using System;
using System.Collections;

namespace CustomerManager
{
    class SummaryPrinter
    {
        private static int tableWidth = 80;
        public string Title { get; set; }
        public string[] Columns { get; set; }
        public IEnumerable Items { get; set; }

        public SummaryPrinter(string title, string[] columns, IEnumerable items)
        {
            Title = title;
            Columns = columns;
            Items = items;
        }

        private void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));

        }

        // Print table based on the title, columns, and each tuple data sets.
        public void PrintSummaryTable()
        {
            Console.WriteLine();
            PrintLine();
            Console.WriteLine("{0, 55}", Title);

            foreach (var column in Columns)
                Console.Write("{0, 15}", column);

            Console.WriteLine("");

            foreach (var item in Items)
                Console.WriteLine(item);    
            PrintLine();
        }
    }
}
