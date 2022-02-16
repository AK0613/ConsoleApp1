using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// Main function
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int choice;
            string tryAgain;

            do
            {
                Console.Clear();
                choice = mainMenu();

                switch (choice)
                {
                    case 1:
                        CaseOne();
                        break;
                    case 2:
                        CaseTwo();
                        break;
                    case 3:
                        CaseThree();
                        break;
                    case 4:
                        CaseFour();
                        break;
                    case 5:
                        CaseFive();
                        break;
                    case 6:
                        CaseSix();
                        break;
                    case 7:
                        CaseSeven();
                        break;
                    case 8:
                        CaseEight();
                        break;
                    case 9:
                        CaseNine();
                        break;
                    case 10:
                        CaseTen();
                        break;
                }

                Console.WriteLine("\nWould you like to start over? \nEnter Y or y to start again or any key to continue: ");
                tryAgain=Console.ReadLine();

            } while (tryAgain.Equals("y") || tryAgain.Equals("Y"));
            
        }

        #region Input Handlers
        private static int mainMenu()
        {
            int choice;
            string input;
            bool valid;

            Console.WriteLine("Main Menu:\n" +
                "Problem 1: Enter two numbers to be multiplied\n" +
                "Problem 2: Compute sum of two integers. If two values are the same, return triple their sum\n" +
                "Problem 3: Get the difference between x and n. If x>n return triple the absolute difference\n" +
                "Problem 4: Provide two integers and n, then return true if one of them is n or if their sum is n\n" +
                "Problem 5: Provide a string and then an integer. The letter that corresponds to that integer will be removed\n" +
                "Problem 6: Provide a string and two integers. The corresponding letters will be swapped\n" +
                "Problem 7: Provide a string, and two integers. A new string will be created with X number of copies of the first Y characters in the original string\n" +
                "Problem 8: Provide three integers (n, x, y), then check if the first number is a multiple of x or y\n" +
                "Problem 9: Check whether the three given integer values (comma separated) are in the range of 100-200\n" +
                "Problem 10: Enter a string and check if it contains the letters \"yt\". If it appears, return a string without it\n");

            do
            {
                Console.WriteLine("Please enter a number between 1-10: ");
                input = Console.ReadLine();

                valid = int.TryParse(input, out choice);
                if (!valid || (choice > 10 || choice < 0))
                {
                    Console.WriteLine("Invalid input. You entered {0}", input);
                }
                    
                
            } while (!valid || (choice > 10 || choice < 0));

            return choice;
        }



        private static int GetInput(string variable)
        {
            string input;
            int value;
            do
            {
                Console.Write("Please enter a positive integer for {0}: ", variable);
                input = Console.ReadLine();
            } while (!int.TryParse(input, out value) || value < 0);

            return value;
        }

        /// <summary>
        /// Overloaded function that requests user input but limits the range of values the user can enter (not more than the max number of letters available)
        /// </summary>
        /// <param name="max">Upper limit for values that this function can pass</param>
        /// <returns></returns>
        private static int GetInput(int max)
        {
            int value;
            string msg = "the number of characters to be copied";
            do
            {
                value = GetInput(msg);
                if (value > max)
                    Console.WriteLine("Invalid value. The value for characters to be copied exceeds the length of the word. Please enter a number between 1 and " + max);
                else if (value < 0)
                    Console.WriteLine("Invalid value. Please enter a number between 1 and " + max);

            } while (value > max || value < 1);

            return value;       
        }

        /// <summary>
        /// Prompt the user to enter a string
        /// </summary>
        /// <returns>String input which holds the user's input</returns>
        private static string GetString()
        {
            string input;
            Console.Write("Please enter a string: ");
            input = Console.ReadLine();
            return input;
        }

        /// <summary>
        /// Used to receive comma delimited input from the user and then extract integer values from it. 
        /// </summary>
        /// <returns>A list of integer values provided by the user</returns>
        private static List<int> GetMultArgString()
        {
            string input;
            int temp;
            List<int> list = new List<int>();

            Console.Write("Please enter three numbers separated by a comma (1, 2, 3): ");
            input = Console.ReadLine();

            string[] delim = input.Split(',');
            foreach(var sub in delim)
            {
                int.TryParse(sub, out temp);
                //Console.WriteLine("temp is " + temp);
                list.Add(temp);
            }
            return list;
        }

        #endregion

        #region Cases
        /// <summary>
        /// Problem 1: Enter two numbers to be multiplied
        /// </summary>
        public static void CaseOne()
        {
            int x, y;
            string xString = "x", yString = "y";

            Console.Clear();
            Console.WriteLine("Problem 1: Enter two numbers to be multiplied");
            x = GetInput(xString);
            y = GetInput(yString);
            Console.WriteLine("Multiplying {0}x{1}= " + x * y, x, y);
        }

        /// <summary>
        /// Problem 2: Compute sum of two integers. If two values are the same, return triple their sum
        /// </summary>
        public static void CaseTwo()
        {
            int x, y;
            string xString = "x", yString = "y";

            Console.Clear();
            Console.WriteLine("Problem 2: Compute sum of two integers. If two values are the same, return triple their sum");
            x = GetInput(xString);
            y = GetInput(yString);

            if (x == y)
            {
                Console.WriteLine("Both numbers are identical! ({0}+{1})*3 = " + (x + y)*3, x, y);
            }

            else
                Console.WriteLine("{0}+{1}= " + (x + y), x, y);
        }

        /// <summary>
        /// Problem 3: Get the difference between x and n. If x>n return triple the absolute difference
        /// </summary>
        public static void CaseThree()
        {
            int x, n;
            string xString = "x", nString = "n";

            Console.Clear();
            Console.WriteLine("Problem 3: Get the difference between x and n. If x>n return triple the absolute difference");
            x = GetInput(xString);
            n = GetInput(nString);

            if (x > n)
            {
                Console.WriteLine("x is larger than n\n" +
                    "|(x-n)*3|= " + (Math.Abs(x - n)) * 3);
            }
            else
                Console.WriteLine("x-n =" + (x-n));
        }

        /// <summary>
        /// Problem 4: Provide two integers and n, then return true if one of them is n or if their sum is n
        /// </summary>
        public static void CaseFour()
        {
            int x, y, n;
            string xString = "x", yString = "y", nString = "n";

            Console.Clear();
            Console.WriteLine("Problem 4: Provide two integers and n, then return true if one of them is n or if their sum is n");

            x = GetInput(xString);
            y = GetInput(yString);
            n = GetInput(nString);

            if (x == n || y == n || (x + y) == n)
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
        }

        /// <summary>
        /// Problem 5: Provide a string and then an integer. The letter that corresponds to that integer will be removed
        /// </summary>
        public static void CaseFive()
        {
            int index;
            string input, letter= "the number of the letter to be removed";

            Console.Clear();
            Console.WriteLine("Problem 5: Provide a string and then an integer. The letter that corresponds to that integer will be removed");

            input = GetString();
            index = GetInput(letter);

            Console.WriteLine(input.Remove(index-1, 1));
            
            
        }

        /// <summary>
        /// Problem 6: Provide a string and two integers. The corresponding letters will be swapped
        /// </summary>
        public static void CaseSix()
        {
            int x, y;
            string input, xString = "x", yString = "y";
            char placeholder;

            Console.Clear();
            Console.WriteLine("Problem 6: Provide a string and two integers. The corresponding letters will be swapped");

            input = GetString();
            x = GetInput(xString)-1;
            y = GetInput(yString)-1;

            placeholder = input[x];
            StringBuilder strBuilder = new StringBuilder(input);
            strBuilder[x] = input[y];
            strBuilder[y] = placeholder;

            string finalString = strBuilder.ToString();
            Console.WriteLine("Output: {0}", finalString);
        }

        /// <summary>
        /// Problem 7: Provide a string, and two integers. A new string will be created with X number of copies of the first Y characters in the original string
        /// </summary>
        public static void CaseSeven()
        {
            string input, numCopies = "the number of copies to be made";
            int copies, chars;

            Console.Clear();
            Console.WriteLine("Problem 7: Provide a string, and two integers. A new string will be created with X number of copies of the first Y characters in the original string");
            input = GetString();
            copies = GetInput(numCopies);
            chars = GetInput(input.Length);

            string temp = input.Substring(0, chars);
            StringBuilder stringBuilder = new StringBuilder(input);

            for(int i=0; i<copies;i++)
            {
                stringBuilder.Insert(0, temp);
            }

            string output = stringBuilder.ToString();
            Console.WriteLine("Result: {0}", output);

        }

        /// <summary>
        /// Problem 8: Provide three integers (n, x, y), then check if the first number is a multiple of x or y\n
        /// </summary>
        public static void CaseEight()
        {
            int x, y, n;
            string xString = "x", yString = "y", nString = "n";

            Console.Clear();
            Console.WriteLine("Problem 8: Provide three integers (n, x, y), then check if the first number is a multiple of x or y");
            n = GetInput(nString);
            x = GetInput(xString);
            y = GetInput(yString);

            if (n % x == 0)
                Console.WriteLine("{0} is a multiple of {1}", n, x);
            else if (n % y == 0)
                Console.WriteLine("{0} is a multiple of {1}", n, y);
            else
                Console.WriteLine("{0} is not a multiple of {1} or {2}", n, x, y);
        }

        /// <summary>
        /// Problem 9: Check whether the three given integer values (comma separated) are in the range of 100-200
        /// </summary>
        public static void CaseNine()
        {
            List<int> list = new List<int>();
            list = GetMultArgString();

            Console.Clear();
            Console.WriteLine("Problem 9: Check whether the three given integer values (comma separated) are in the range of 100-200");

            foreach (int val in list)
            {
                if (val >= 100 && val <= 200)
                    Console.WriteLine("{0} is between 100 and 200", val);
                else 
                    Console.WriteLine("{0} is not between 100 and 200", val);
            }
        }

        /// <summary>
        /// Problem 10: Enter a string and then a sub-string. Check if the sub-string is part of the string and if it appears, return a string without it
        /// </summary>
        public static void CaseTen()
        {
            string input, temp, pattern;

            Console.Clear();
            Console.WriteLine("Problem 10: Enter a string and then a sub-string. Check if the sub-string is part of the string and if it appears, return a string without it");

            input = GetString();
            pattern = GetString();

            foreach(Match match in Regex.Matches(input, pattern))
            {
                Console.WriteLine("Word contains {0}: {1}", pattern, input);
                temp = input.Remove(match.Index, pattern.Length);
                Console.WriteLine("Removing {0} from the word {1}: {2}", pattern, input, temp);
            }
        }
        #endregion

    }
}
