using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            while (i < 13)
            {
                ArrayList drinks = new ArrayList{"berry", "berry", "berry", "berry",
                "citrus", "citrus", "citrus", "citrus", "water", "water", "water",
                "water", "coconut"};
                if (distribute(drinks, i))
                {
                    int answer = i + 1;
                    String numEnding = "";
                    if (answer == 1)
                    {
                        numEnding = "st";
                    }
                    else if (answer == 2)
                    {
                        numEnding = "nd";
                    }
                    else
                    {
                        numEnding = "th";
                    }

                    Console.WriteLine("Beginning at the " + answer + numEnding +
                        " drink will guarantee I get the coconut water.");
                }
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }

        public static bool distribute(ArrayList al, int position)
        {
            while (al.Count > 1)
            {
                if (al[position].Equals("coconut"))
                {
                    return false;
                }
                else
                {
                    al.RemoveAt(position);
                    position += 12;
                    while (position >= al.Count)
                    {
                        position -= al.Count;
                    }
                }
            }

            return true;
        }
    }
}
