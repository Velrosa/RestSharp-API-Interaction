using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharp_API_Interaction
{
    internal class UserInput
    {
        GetService service = new GetService();
        internal void GetCategoriesInput()
        {
            service.GetCategories();

            Console.Write("Choose category: ");

            string category = Console.ReadLine();

            while (!Validator.IsTextValid(category))
            {
                Console.WriteLine("\nInvalid category");
                category = Console.ReadLine();
            }

            GetDrinksInput(category);
        }

        private void GetDrinksInput(string category)
        {
            service.GetDrinksFromCategory(category);

            Console.Write("Type the ID of a drink to view its details: ");
            string drinkID = Console.ReadLine();
            if (drinkID == "MENU") GetCategoriesInput();

            while (!Validator.IsIdValid(drinkID))
            {
                Console.WriteLine("\nInvalid drink");
                drinkID = Console.ReadLine();
            }

            service.GetDrinkDetails(drinkID);
        }
    }
}
