using System;

namespace PowersTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Powers Table!");
            MakeLineSpace(1);

            // Application Loop
            bool done = false;
            while (!done)
            {
                // Validation Loop, Valid values are positive integers.
                int baseValue = -1;
                bool inputValid = false;

                while (!inputValid)
                {
                    // Collect input from User
                    Console.Write("Please enter an integer: ");
                    string inputStr = Console.ReadLine();
                    int inputInt;

                    // Value is non-integer
                    if (int.TryParse(inputStr, out inputInt) == false)
                    {
                        Console.WriteLine("Error: Non-integer input. Please enter an integer!");
                    }
                    else
                    {
                        // Check to make sure the input is positive and non-zero
                        if (inputInt < 1)
                        {
                            Console.WriteLine("Error: Invalid. Please enter a non-zero POSITIVE number!");
                        }
                        else // Value is a valid positive integer
                        {
                            Console.WriteLine($"You entered {inputInt}. Preparing tables!");
                            baseValue = inputInt;
                            inputValid = true; // inputValid is updated, nested loop ends
                        }
                    }
                    MakeLineSpace(1);
                }

                // Build the Table
                Console.WriteLine($"Squares and Cubes to {baseValue} : ");
                MakeTable(baseValue);
                MakeLineSpace(2);;
                
                // Prompt user if they want to continue. If yes, then let the loop iterate. Otherwise, stop the loop by setting done to true.
                Console.Write($"Would you like to continue with another value? (y/n) ");

                if (!(Console.ReadLine().ToLower().Trim()).Equals("y"))
                {
                    Console.WriteLine($"Thank you for using Powers Table! Have a nice day!");
                    done = true;
                }
                else { Console.WriteLine("Reseting!"); }
                MakeLineSpace(1);
            }
        }

        // Take the user input and generate the squares and cubes of 1 to baseValue into the console
        public static void MakeTable(int x)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("| Base    | Squared    | Cubed         |");
            Console.WriteLine("|--------------------------------------|");
            for (int b = 1; b <= x; b++)
            {
                // Calculate Square and Cube of B (Base)
                int squareOfB = b * b;
                int cubeOfB = b * b * b;
                
                // Make them into strings for entries, run AddSpaces to add spaces if values are low enough
                string bStr = b + "";
                bStr = AddSpaces(bStr);
                string squStr = squareOfB + "";
                squStr = AddSpaces(squStr);
                string cubStr = cubeOfB + "";
                cubStr = AddSpaces(cubStr);
                string tableRow = "| {0} | {1}    | {2}       |";
                Console.WriteLine(tableRow, bStr, squStr, cubStr);
            }
            Console.WriteLine("========================================");
        }

        // Generates extra spaces for values under certain hard-coded thresholds.
        // Should be stable until around a base value of 215.
        public static string AddSpaces(string str)
        {
            int strInt = int.Parse(str);
            if (strInt < 10 )
            {
                str = str + " ";
            }
            if (strInt < 100)
            {
                str = str + " ";
            }
            if (strInt < 1000)
            {
                str = str + " ";
            }
            if (strInt < 10000)
            {
                str = str + " ";
            }
            if (strInt < 100000)
            {
                str = str + " ";
            }
            if (strInt < 1000000)
            {
                str = str + " ";
            }
            return str;
        }

        public static void MakeLineSpace(int x)
        {
            for (int i = 0; i < x; i++)
            {
                Console.WriteLine(" ");
            }
        }
    }
}
