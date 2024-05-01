using Recipes_Final.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes_Final.Service.Interface
{
    public interface ISearchService
    {
        List<Search> RetrieveRetrieveAllByCategory(int catid);
    }
}
//