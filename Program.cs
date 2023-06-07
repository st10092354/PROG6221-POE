using System;
using System.Collections;
using System.Collections.Generic;

namespace Recipe
{
    class Program
    {
        //arraylists for storing information
        public static ArrayList name = new ArrayList();
        public static ArrayList quantity = new ArrayList();
        public static ArrayList unitOfM = new ArrayList();
        public static ArrayList steps = new ArrayList();
        static void main(string[] args)
        {
            /*loop that makes user enter unlimited recipes
             stackoverflow. 2015*/
            //adding recipe names
            List<string> recipes = new List<string>();

            while (true)
            {
                Console.WriteLine("Enter a recipe (or 'exit' to quit):");
                string recipe = Console.ReadLine();

                if (recipe.ToLower() == "exit")
                    break;

                recipes.Add(recipe);
            }


            Console.WriteLine("Recipe Book:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"Recipe {i + 1}: {recipes[i]}");
            }


            Console.WriteLine("How many ingredients do you want to store?");
            //turn ingredients into an integer and read user input as integer
            int Ing = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Storing " + Ing + " ingredients");

            //for loop to add ingredients according to how the user wants to add
            for (int i = 0; i < Ing; i++)
            {
                //add specefic information to the arraylist

                /*this is commented out because i used the method required in the next submission to add a recipe
                Console.WriteLine("Enter the name of the Ingredient");
                string names = Console.ReadLine();
                name.Add(names);*/

                Console.WriteLine("Enter the quantity of the Ingredient");
                /*How to read an integer from user input
                 stackoverflow. 2014
                 */
                int numIng = Convert.ToInt32(Console.ReadLine());
                quantity.Add(numIng);

                Console.WriteLine("Enter the unit of measurement of the Ingredient");
                string measurement = Console.ReadLine();
                unitOfM.Add(measurement);

                Console.WriteLine("How many steps are there?");
                int numStep = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the steps: ");
                //for loop inside a for loop
                //this for loop is for adding the number of steps to each ingredient stored
                for (int j = 0; j < numStep; j++)
                {
                    string step = Console.ReadLine();
                    steps.Add(step);
                }
            }

            //sort recipes in alphabetical order
            recipes.Sort();

            Console.WriteLine("Recipe Book (Alphabetical order)");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"Recipe {i + 1}: {recipes[i]}");
                Console.WriteLine(name[i]);
                Console.WriteLine(quantity[i]);
                Console.WriteLine(unitOfM[i]);
                Console.WriteLine(steps[i]);
            }

            Console.WriteLine("Enter the number of the recipe to display or 'exit to quit the app':");
            //while loop for user to choose which recipe they want to display
            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                if (int.TryParse(input, out int recipeNumber) && recipeNumber >= 1 && recipeNumber <= recipes.Count)
                {
                    Console.WriteLine($"\nRecipe {recipeNumber}: {recipes[recipeNumber - 1]}");
                }
                
            }
        }
        //add name for your recipe
        class RecipeApp
        {
            //using getters and setters
            public string Name { get; set; }
            public List<Ingredient> Ingredients { get; set; }

            public RecipeApp(string name)
            {
                Name = name;
                Ingredients = new List<Ingredient>();
            }
            //method to calculate the calories in your recipe
            public int CalculateTotalCalories()
            {
                int totalCalories = 0;
                //loop to calculate the calories
                foreach (Ingredient ingredient in Ingredients)
                {
                    totalCalories += ingredient.Calories;
                }

                return totalCalories;
            }
        }

        class Ingredient
        {
            //getters and setters
            public string Name { get; set; }
            public int Calories { get; set; }
            public string FoodGroup { get; set; }
            
            public Ingredient(string name, int calories, string foodGroup)
            {
                //creating variables for the information that will be entered
                Name = name;
                Calories = calories;
                FoodGroup = foodGroup;
            }
        }

        class Programs
        {
            static void Main(string[] args)
            {
                List<RecipeApp> recipes = new List<RecipeApp>();

                while (true)
                {
                    Console.WriteLine("Enter a recipe (or 'exit' to quit):");
                    string recipeName = Console.ReadLine();

                    if (recipeName.ToLower() == "exit")
                        break;

                    RecipeApp recipe = new RecipeApp(recipeName);
                    //while loop to add a new recipe and its contents
                    while (true)
                    {
                        Console.WriteLine("\nEnter an ingredient (or 'done' to finish adding ingredients):");
                        string ingredientName = Console.ReadLine();

                        if (ingredientName.ToLower() == "done")
                            break;

                        Console.WriteLine("Enter the number of calories:");
                        int calories = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the food group:");
                        string foodGroup = Console.ReadLine();

                        Ingredient ingredient = new Ingredient(ingredientName, calories, foodGroup);
                        recipe.Ingredients.Add(ingredient);
                    }

                    recipes.Add(recipe);
                }

                recipes.Sort((r1, r2) => string.Compare(r1.Name, r2.Name, StringComparison.OrdinalIgnoreCase));

                Console.WriteLine("\nRecipe Book (Alphabetical Order):");
                for (int i = 0; i < recipes.Count; i++)
                {
                    RecipeApp recipe = recipes[i];
                    Console.WriteLine($"Recipe {i + 1}: {recipe.Name}");

                    Console.WriteLine("Ingredients:");
                    for (int j = 0; j < recipe.Ingredients.Count; j++)
                    {
                        Ingredient ingredient = recipe.Ingredients[j];
                        Console.WriteLine($"- {ingredient.Name} ({ingredient.Calories} calories) - {ingredient.FoodGroup}");
                    }
                    //calculating the calorie count
                    int totalCalories = recipe.CalculateTotalCalories();
                    Console.WriteLine($"Total Calories: {totalCalories}");
                    //warning message for recipe exceeding 300 calories
                    if (totalCalories > 300)
                    {
                        Console.WriteLine("WARNING\n This recipe exceeds 300 calories.");
                    }

                }
            }

            //unit testing
            //C# corner. 2019.
            public class RecipeTests
            {
                //test
                public void CalculateTotalCalories_ReturnsCorrectTotalCalories()
                {
                    // Arrange
                    RecipeApp recipe = new RecipeApp("Test Recipe");
                    recipe.Ingredients.Add(new Ingredient("Ingredient 1", 300, "Group A"));
                    recipe.Ingredients.Add(new Ingredient("Ingredient 2", 150, "Group B"));
                    recipe.Ingredients.Add(new Ingredient("Ingredient 3", 100, "Group A"));

                    // Act
                    int totalCalories = recipe.CalculateTotalCalories();

                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                }

            }

        }
    }
}
