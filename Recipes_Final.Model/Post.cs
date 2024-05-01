using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Recipes_Final.Model
{
    public  class Post
    {
        public int Id { get; set; } 
        public User User { get; set; }
        public Recipe Recipes { get; set; }
        public int Rattings { get; set; }   
        public string Comment { get; set; } 
    }
}
