using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP_MappingRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            String input1 = "2017-01-01; Coffee Shop; L2, L5, L5, R5, L2";
            String input2 = "2017-01-02; Advertising Agency; R3, R3, R3, L2";

            Console.WriteLine(directRoute(input1));
            Console.WriteLine(directRoute(input2));

            Console.WriteLine("\nPress any key to close...");
            Console.ReadKey();
        }

        public static String directRoute(String robotRoute)
        {
            String[] fullInput = robotRoute.Split(';');
            String[] steps = fullInput[2].Split(',');

            String result = "";
            result += fullInput[0] + ";" + fullInput[1] + "; ";

            int x = 0;
            int y = 0;
            int currentDirection = 0;

            for (int i = 0; i < steps.Length; i++)
            {
                String step = steps[i].Trim();

                if(step.Substring(0, 1).Equals("R"))
                {
                    currentDirection++;
                }
                else
                {
                    currentDirection--;
                }

                if(currentDirection == -1)
                {
                    currentDirection = 3;
                }
                else if(currentDirection == 4)
                {
                    currentDirection = 0;
                }
                
                int run = int.Parse(step.Substring(1));

                if (currentDirection == 0)
                {
                    x -= run;
                }
                else if (currentDirection == 1)
                {
                    y += run;
                }
                else if(currentDirection == 2)
                {
                    x += run;
                }
                else
                {
                    y -= run;
                }
            }

            if(y == 0 && x < 0)
            {
                result += "F" + Math.Abs(x);
            }
            else if (y >= 0)
            {
                result += "R" + y;

                if(x > 0)
                {
                    result += ", R" + x;
                }
                else if(x < 0)
                {
                    result += ", L" + Math.Abs(x);
                }
            }
            else
            {
                result += "L" + Math.Abs(y);
                if(x > 0)
                {
                    result += ", L" + x;
                }
                else if(x < 0)
                {
                    result += ", R" + Math.Abs(x);
                }
            }

            return result;
        }
    }
}
