using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes_Final.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public string? Title { get; set; }    //preguntar a Yuri que me explique lo de las `?`
        public User? Author { get; set; }
        public Category? Category { get; set; }  
        public int PreparationTime { get; set; }    
        public string? PreparationMethod { get; set; }
        public Difficulty? Difficulty { get; set; }
        public List<IngredientLine>? ingredientLines { get; set; }
        public bool IsApproved { get; set; }

    }
}
