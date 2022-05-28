using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.Models
{
    internal class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public CategoryModel(int id, string name)
        {
            CategoryId = id;
            Name = name;
        }
    }
}
