using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Models
{
    internal class StandarUser : UserModel
    {
        public StandarUser(string name, string password) : base(name, password)
        {
        }

        public override bool CanLogIn()
        {
            return false;
        }
    }
}
