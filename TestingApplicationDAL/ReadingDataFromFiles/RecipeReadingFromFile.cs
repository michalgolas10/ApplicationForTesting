using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestingApplicationDAL.Entities;

namespace TestingApplicationDAL.ReadingDataFromFiles
{
    public class RecipeReadingFromFile
    {
            public static void ReadingDataFromFile()
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                string JsonFilePath = "../TestingApplicationDAL/JsonFiles/recipies.json";
            string JsonDeserialized = File.ReadAllText(JsonFilePath);

                var recipeList = JsonSerializer.Deserialize<List<RootForRecipe>>(JsonDeserialized, options);
                if (recipeList != null)
                {

                    RecipesJson.Recipes = recipeList.Select(x => x.Recipe).ToList();
                }
                else
                {
                    throw new ArgumentException("Error while deserializing file.");
                }
            }
        
    }
}
