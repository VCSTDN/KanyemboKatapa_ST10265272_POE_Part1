using ST10265272_POE_Part1.PrintUtil;
using ST10265272_POE_Part1.Model;
using System.Linq.Expressions;

namespace ST10265272_POE_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exitMenu = false; // Declares a boolean variable to control the menu loop
            bool isValidInput = false; // Declares a boolean variable to track if the input is valid

            Recipe rp = new Recipe(); // Instantiates a Recipe object

            // Displays a welcome message
            Console.WriteLine("**************************************");
            Console.WriteLine("Welcome to Recipe Creation Application");
            Console.WriteLine("**************************************");
            Console.WriteLine();

            // Menu loop
            while (!exitMenu) // Loops until exitMenu is true
            {
                try
                {
                    // Displays the menu options
                    Console.WriteLine(PrinUtil.MENU_OPTION);

                    // Reads the user's menu choice
                    int MenuNum = int.Parse(PrinUtil.ReadLine());
                    Console.WriteLine();

                    // Switch statement to execute different actions based on the menu choice
                    switch (MenuNum)
                    {
                        case 1:
                            rp.CreateRecipe(); // Calls the CreateRecipe method of the Recipe object
                            break;
                        case 2:
                            rp.displayRecipe(); // Calls the displayRecipe method of the Recipe object
                            break;
                        case 3:
                            rp.ClearRecipe(); // Calls the ClearRecipe method of the Recipe object
                            break;
                        case 4:
                            rp.Scale(); // Calls the Scale method of the Recipe object
                            break;
                        case 5:
                            Console.WriteLine("Exiting the application..."); // Displays exit message
                            Environment.Exit(0); // Exits the application
                            break;
                        default:
                            Console.WriteLine("Please Choose a Number."); // Displays message for invalid menu choice
                            break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Choose a number."); // Displays message for exception
                    Console.WriteLine();
                }

            }
        }
    }
}


