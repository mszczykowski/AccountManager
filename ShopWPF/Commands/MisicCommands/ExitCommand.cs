using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopWPF.Commands.MisicCommands
{
    internal class ExitCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if(MessageBox.Show("Close Application?", "Exit", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }
    }
}
