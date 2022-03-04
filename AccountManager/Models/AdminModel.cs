using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Models
{
    internal class AdminModel : UserModel
    {
        public AdminModel(string name, string password) : base(name, password)
        {

        }

        public override bool CanLogIn()
        {
            return true;
        }
    }
}
