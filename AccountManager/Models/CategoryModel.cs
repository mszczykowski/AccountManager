using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Models
{
    internal class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CategoryModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
