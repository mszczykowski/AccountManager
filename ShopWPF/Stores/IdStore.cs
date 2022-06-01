using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.Stores
{
    internal class IdStore
    {
        public int Id 
        { 
            get => Id; 
            set
            {
                Id = value;
                OnIdChanged();
            }
        }

        public event EventHandler? IdChanged;

        private void OnIdChanged()
        {
            IdChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
