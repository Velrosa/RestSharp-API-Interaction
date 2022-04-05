using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp_API_Interaction.Models;

namespace RestSharp_API_Interaction
{
    internal class GetService
    {
        public void GetCategories()
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response = client.GetAsync<Categories>(request);

            List<Category> deserilizedList = response.Result.CategoriesList;

            TableVisuals.ShowTable(deserilizedList, "Categories");
        }

        internal void GetDrinksFromCategory(string category)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?c={category}");
            var response = client.GetAsync<Drinks>(request);

            List<Drink> deserilizedList = response.Result.DrinksList;

            TableVisuals.ShowTable(deserilizedList, $"{category} Drinks");
        }

        internal void GetDrinkDetails(string drinkID)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"lookup.php?i={drinkID}");
            var response = client.GetAsync<DrinkDetailsObj>(request);

            DrinkDetails details = response.Result.DrinkDetailsList[0];

            Console.WriteLine(details);

            List<object> refactoredList = new List<object>();

            string newName = "";

            foreach(PropertyInfo prop in details.GetType().GetProperties())
            {
                if (prop.Name.Contains("str"))
                {
                    newName = prop.Name.Substring(3);
                }

                if (prop.Name.Contains("date"))
                {
                    newName = "Date Last Modified";
                }

                if (!String.IsNullOrEmpty(prop.GetValue(details)?.ToString()))
                {
                    refactoredList.Add(new
                    {
                        Key = newName,
                        Value = prop.GetValue(details)
                    });                       
                }
            }        
            TableVisuals.ShowTable(refactoredList, "Drink Details");
        }
    }
}
