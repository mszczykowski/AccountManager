using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.Stores
{
    internal class IdStore
    {
        private int _id;
        public int Id 
        { 
            get => _id; 
            set
            {
                _id = value;
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
