﻿using ShopWPF.Commands.MisicCommands;
using ShopWPF.Models;
using ShopWPF.Services.Common;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;

namespace ShopWPF.ViewModels.ManageProductsViewModels
{
    internal class ProductFormViewModel : ViewModelBase
    {
        private string _productName;
        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        private CategoryModel _category;
        public CategoryModel Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        private double _price;
        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                ValidatePrice();
                OnPropertyChanged(nameof(Price));
            }
        }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                ValidateQuantity();
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public ICommand CancelCommand { get; }

        private readonly ErrorsViewModel _errorsViewModel;

        public ProductFormViewModel(NavigationService<ManageProductsViewModel> manageProductsViewModelNavigationService)
        {
            CancelCommand = new NavigateCommand<ManageProductsViewModel>(manageProductsViewModelNavigationService);

            _errorsViewModel = new ErrorsViewModel();

            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;
        }



        //validation
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public bool HasErrors => _errorsViewModel.HasErrors;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsViewModel.GetErrors(propertyName);
        }

        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
        }

        public void ValidateForm()
        {
            ValidateName();
            ValidatePrice();
            ValidateQuantity();
        }

        private void ValidateName()
        {
            _errorsViewModel.ClearErrors(nameof(ProductName));

            if (string.IsNullOrEmpty(ProductName)) _errorsViewModel.AddError(nameof(ProductName), "Name can't be empty");

            else if (ProductName.Length > 30) 
                _errorsViewModel.AddError(nameof(ProductName), "Name must be shorter than 30 characters");
        }

        private void ValidatePrice()
        {
            _errorsViewModel.ClearErrors(nameof(Price));

            if (Price <= 0 ) _errorsViewModel.AddError(nameof(Price), "Price must be greater than 0");

            else if(Math.Round(Price, 2) != Price ) _errorsViewModel.AddError(nameof(Price), "Invalid price");
        }

        private void ValidateQuantity()
        {
            _errorsViewModel.ClearErrors(nameof(Quantity));

            if (Quantity <= 0) _errorsViewModel.AddError(nameof(Quantity), "Quantity must be greater than 0");
        }
    }
}
