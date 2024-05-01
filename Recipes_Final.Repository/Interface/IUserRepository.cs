using Recipes_Final.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes_Final.Repository.Interface
{
    public interface IUserRepository
    {
        User Create(User user);
        User Retrieve(int id);
        List<User> RetrieveAll();
        User Update(User user);
        void Delete(int id);
        User Login(string username, string password);//

    }
}
