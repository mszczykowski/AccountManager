using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.Models.UserModels
{
    internal class AdminModel : UserModel
    {
        public AdminModel( string name, string password) : base(name, password)
        {

        }
        public AdminModel(int id, string name, string password) : base(id, name, password)
        {

        }

        public override bool HasAdminPermissions()
        {
            return true;
        }
    }
}
