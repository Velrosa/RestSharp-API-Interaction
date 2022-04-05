using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharp_API_Interaction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInput userInput = new UserInput();
            userInput.GetCategoriesInput();
            Console.ReadKey();
        }
    }
}
