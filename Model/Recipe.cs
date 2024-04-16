using ST10265272_POE_Part1.PrintUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10265272_POE_Part1.Model
{
    public class Recipe // Declares a public class named Recipe
    {
        // Properties to store recipe ingredients and steps
        public List<Ingredient> Ingredients { get; set; }
        private List<Ingredient> originalIngredients;
        public List<string> Steps { get; set; }

        // Private fields to store recipe name, number of ingredients, and number of steps
        private string recipeName;
        private int numIngredient;
        private int numSteps;

        // Constructor to initialize Ingredients and Steps lists
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        // Method to create a recipe
        public void CreateRecipe()
        {
            bool isValidInput = false;

            // Prompt user to enter recipe name
            Console.WriteLine(PrinUtil.ENTER_RECIPE_NAME);
            recipeName = PrinUtil.ReadLine();
            Console.WriteLine();

            // Loop until valid input is provided for the number of ingredients
            while (!isValidInput)
            {
                try
                {
                    // Prompt user to enter the number of ingredients
                    Console.WriteLine(PrinUtil.ENTER_INGREDIENT_NUMBER);
                    numIngredient = int.Parse(PrinUtil.ReadLine());
                    isValidInput = true; // Set isValidInput to true if parsing is successful
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter the number of ingredients you want.");
                }
                Console.WriteLine();
            }

            // Loop to input each ingredient
            for (int i = 0; i < numIngredient; i++)
            {
                Ingredient ingredient = new Ingredient();

                // Prompt user to enter ingredient name
                Console.WriteLine((i + 1) + "." + " " + PrinUtil.DISPLAY_INGREDIENT_NAME);
                ingredient.Name = PrinUtil.ReadLine();
                Console.WriteLine();

                // Prompt user to enter ingredient quantity
                try
                {
                    Console.WriteLine((i + 1) + "." + " " + PrinUtil.DISPLAY_INGREDIENT_QUANTITY);
                    ingredient.Quantity = int.Parse(PrinUtil.ReadLine());
                    isValidInput = false; // Reset isValidInput for next input
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter the Ingredient Quantity.");
                }

                Console.WriteLine();

                // Prompt user to enter ingredient unit
                Console.WriteLine((i + 1) + "." + " " + PrinUtil.DISPLAY_INGREDIENT_UNIT);
                ingredient.Unit = PrinUtil.ReadLine();
                Console.WriteLine();

                Ingredients.Add(ingredient); // Add the ingredient to the list
            }

            // Loop until valid input is provided for the number of steps
            while (!isValidInput)
            {
                try
                {
                    // Prompt user to enter the number of steps
                    Console.WriteLine(PrinUtil.DISPLAY_NUMSTEPS);
                    numSteps = int.Parse(PrinUtil.ReadLine());
                    isValidInput = true; // Set isValidInput to true if parsing is successful
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter number of steps.");
                    Console.WriteLine();
                }
            }

            // Loop to input each step
            for (int j = 0; j < numSteps; j++)
            {
                Console.WriteLine(PrinUtil.DISPLAY_STEP_DESCRIPTION + (j + 1));
                Steps.Add(PrinUtil.ReadLine());
                Console.WriteLine();
            }
        }

        // Method to scale the recipe
        public void Scale()
        {
            // If originalIngredients is null, make a copy of the current ingredients
            if (originalIngredients == null)
            {
                originalIngredients = new List<Ingredient>(Ingredients);
            }

            // Display scale options to the user
            Console.WriteLine("Choose a scale from:" +
            "\n 1. 0.5" +
            "\n 2. 2" +
            "\n 3. 3" +
            "\n 4. Reset to original");

            // Read user's scale choice
            string scaleChoice = PrinUtil.ReadLine();

            // Switch statement to execute different actions based on the scale choice
            switch (scaleChoice)
            {
                case "1":
                    ScaleRecipe(0.5);
                    break;

                case "2":
                    ScaleRecipe(2);
                    break;

                case "3":
                    ScaleRecipe(3);
                    break;

                case "4":
                case "reset":
                    displayOriginalRecipe();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        // Method to scale the recipe by a given factor
        public void ScaleRecipe(double scaleFactor)
        {
            Console.WriteLine();
            Console.WriteLine("Scaled Recipe: ");

            // Scale each ingredient's quantity
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= scaleFactor;

                // Handle unit conversions for tablespoons to cups
                if (ingredient.Unit.ToLower() == "tablespoon" || ingredient.Unit.ToLower() == "tablespoons")
                {
                    // Convert 16 tablespoons to 1 cup
                    if (ingredient.Quantity == 16 && scaleFactor > 1)
                    {
                        ingredient.Quantity = scaleFactor;
                        ingredient.Unit = "cup";
                    }
                }
                Console.ForegroundColor = ConsoleColor.Blue; // Set text color to blue
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name}"); // Display scaled ingredient
            }
            Console.WriteLine();
            Console.ResetColor(); // Reset text color to default
        }

        // Method to display the original recipe
        public void displayOriginalRecipe()
        {
            Console.WriteLine();
            Console.WriteLine("Original Recipe:");

            // Display the original ingredients with original units
            foreach (var ingredient in originalIngredients)
            {
                if (ingredient.Unit.ToLower() == "cup" || ingredient.Unit.ToLower() == "cups" && ingredient.Quantity == 1)
                {
                    ingredient.Quantity = 16;
                    ingredient.Unit = "tablespoons";
                }

                Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name}"); // Display original ingredient
            }

            foreach (var step in Steps)
            {
                Console.WriteLine("Recipe Steps: " + step); // Display recipe steps
            }
            Console.ResetColor(); // Reset text color to default
        }

        // Method to display the current recipe
        public void displayRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
            Console.WriteLine("Recipe for " + recipeName);

            // Display each ingredient with its original unit using a for loop
            for (int i = 0; i < Ingredients.Count; i++)
            {
                var ingredient = Ingredients[i];

                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name}"); // Display ingredient
                Console.ResetColor(); // Reset text color to default
            }

            // Display the recipe steps
            foreach (var step in Steps)
            {
                Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
                Console.WriteLine("Recipe Steps: " + step); // Display recipe step
            }
            Console.WriteLine();
            Console.ResetColor(); // Reset text color to default
        }

        // Method to clear the recipe
        public void ClearRecipe()
        {
            string confirm;
            do
            {
                Console.WriteLine("Do you want to clear your recipe? (Yes/No)");
                confirm = Console.ReadLine().ToLower();

                if (confirm == "yes")
                {
                    // Clear the recipe
                    Ingredients.Clear();
                    recipeName = "";
                    numIngredient = 0;
                    numSteps = 0;
                    Steps.Clear();
                    Console.WriteLine("Recipe details cleared.");
                }
                else if (confirm != "no")
                {
                    Console.WriteLine("Invalid input. Please enter Yes or No.");
                }
            } while (confirm != "yes" && confirm != "no");
        }
    }

}
