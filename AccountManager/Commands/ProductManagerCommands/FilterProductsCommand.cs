using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManager.Services;
using AccountManager.ViewModels;


namespace AccountManager.Commands.ProductManagerCommands
{
    internal class FilterProductsCommand : CommandBase
    {
        private readonly ManageProductsViewModel _manageProductsViewModel;

        public FilterProductsCommand(ManageProductsViewModel manageProductsViewModel)
        {
            _manageProductsViewModel = manageProductsViewModel;


            //_manageProductsViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        
        /*private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ManageProductsViewModel.Search))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_manageProductsViewModel.Search) && base.CanExecute(parameter);
        }*/
        public override void Execute(object? parameter)
        {
            _manageProductsViewModel.UpdateProductsCollection();
        }
    }
}
