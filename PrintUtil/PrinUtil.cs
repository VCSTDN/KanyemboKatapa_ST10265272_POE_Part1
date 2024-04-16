using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10265272_POE_Part1.PrintUtil
{
    internal class PrinUtil 
    {
        // Constants representing messages displayed to the user
        public const string ENTER_RECIPE_NAME = "Please enter the recipe name:"; // Message prompt for entering recipe name
        public const string ENTER_INGREDIENT_NUMBER = "Please enter number of ingredients:"; // Message prompt for entering number of ingredients
        public const string DISPLAY_INGREDIENT_NAME = "Ingredient Name: "; // Message prompt for displaying ingredient name
        public const string DISPLAY_INGREDIENT_QUANTITY = "Ingredient Quantity: "; // Message prompt for displaying ingredient quantity
        public const string DISPLAY_INGREDIENT_UNIT = "Unit of Measurement (teaspoon(s), tablespoon(s), cup(s))"; // Message prompt for displaying unit of measurement
        public const string DISPLAY_NUMSTEPS = "Number of steps: "; // Message prompt for displaying number of steps
        public const string DISPLAY_STEP_DESCRIPTION = "Step No. "; // Message prompt for displaying step description
        public const string MENU_OPTION = " - O P T I O N  M E N U - " + // Menu options displayed to the user
                                           "\n 1. Create Recipe" +
                                           "\n 2. Display/Scale Recipe" +
                                           "\n 3. Reset Recipe" +
                                           "\n 4. Scale Recipe " +
                                           "\n 5. Exit Application" +
                                           "\n" +
                                           "\nPlease Choose a Number: "; // Message prompt for choosing a menu option

        // Static method to read a line of input from the console
        public static string ReadLine()
        {
            return Console.ReadLine(); // Returns the input read from the console
        }
    }



}
