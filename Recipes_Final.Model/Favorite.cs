using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes_Final.Model
{
    public class Favorite
    {
        public int Id { get; set; }
        public User User { get; set; }
        //singular
        public Recipe Recipe { get; set; }

    }
}
