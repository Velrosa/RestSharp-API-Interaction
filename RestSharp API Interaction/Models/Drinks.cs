using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestSharp_API_Interaction.Models
{
    public class Drinks
    {
        [JsonPropertyName("drinks")]
        public List<Drink> DrinksList { get; set; }
    }

    public class Drink
    {
        public string idDrink { get; set; }

        public string strDrink { get; set; }
    }
}
