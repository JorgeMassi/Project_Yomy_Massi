using Recipes_Final.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes_Final.Repository.Interface
{
    public interface ISearchRepository
    {
        List<Search> RetrieveAllByCategory(int catid);
    }
}
//