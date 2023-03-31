using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApplicationDAL.Entities;

namespace TestingApplicationDAL.Context
{
    public class ApplicationSeed
    {
        public static void Initialize(ApplicationContext context)
        {
           
            context.Database.EnsureCreated();
            //Tutaj dodać rzeczy do bazy
            var result = IfNull(RecipesJson.Recipes);
                foreach (var recipe in result)
                {
                    context.recipes.Add(recipe);
                }
                context.SaveChanges();
            
        }
        public static List<Recipe> IfNull(List<Recipe> Recipes)
        {
            foreach(var recipe in Recipes)
            {
                if (recipe != null)
                {
                    if(recipe.Label == null)
                    {
                        recipe.Label = "Null";
                    }
                    if (recipe.ShareAs == null)
                    {
                        recipe.ShareAs = "Null";
                    }
                    if(recipe.DietLabels== null)
                    {
                        recipe.DietLabels = new List<string>() { "Null" };
                    }
                    if (recipe.HealthLabels == null)
                    {
                        recipe.HealthLabels = new List<string>() { "Null" };
                    }
                    if(recipe.Cautions== null)
                    {
                        recipe.Cautions = new List<string>() { "Null" };
                    }
                    if (recipe.IngredientLines == null)
                    {
                        recipe.IngredientLines = new List<string>() { "Null" };
                    }
                    if (recipe.RecipeSteps == null)
                    {
                        recipe.RecipeSteps = new List<string>() { "Null" };
                    }
                    if (recipe.Calories == null)
                    {
                        recipe.Calories = 0;
                    }
                    if (recipe.CuisineType == null)
                    {
                        recipe.CuisineType = new List<string>() { "Null" };
                    }
                    if (recipe.MealType == null)
                    {
                        recipe.MealType = new List<string>() { "Null" };
                    }
                    if (recipe.Image == null)
                        recipe.Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fpl.wiktionary.org%2Fwiki%2Fznak_zapytania&psig=AOvVaw09BWt8xJYMe8EuaBhriBGQ&ust=1680375999879000&source=images&cd=vfe&ved=0CBAQjRxqFwoTCMCngdLuhv4CFQAAAAAdAAAAABAD";
                    
                }
                else
                {
                    break;
                }
                
            }
            return Recipes;
        }
    }
}
