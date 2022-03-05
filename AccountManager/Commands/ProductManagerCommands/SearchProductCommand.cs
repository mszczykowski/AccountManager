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
    internal class SearchProductCommand : CommandBase
    {
        private readonly ManageProductsViewModel _manageProductsViewModel;
        private readonly IProductManagerService _productManagerService;

        public SearchProductCommand(ManageProductsViewModel manageProductsViewModel, IProductManagerService productManagerService)
        {
            _manageProductsViewModel = manageProductsViewModel;
            _productManagerService = productManagerService;


            _manageProductsViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ManageProductsViewModel.Search))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_manageProductsViewModel.Search) && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            _manageProductsViewModel.UpdateProductsCollection(_productManagerService.SearchProductByName(_manageProductsViewModel.Search));
        }
    }
}
