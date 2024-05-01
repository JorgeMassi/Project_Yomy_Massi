using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes_Final.Model
{
    public class IngredientLine
    {
        public int Id { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }

        public double Quantity { get; set; }    

        public Measure Measure { get; set; }


    }
}
