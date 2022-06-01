using ShopWPF.Commands.MisicCommands;
using ShopWPF.Services.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopWPF.ViewModels.ManageCategoriesViewModels
{
    internal abstract class CategoryFormViewModel : ViewModelBase
    {
        private string _categoryName;
        public string CategoryName
        {
            get => _categoryName;
            set
            {
                _categoryName = value;
                ValidateName();
                OnPropertyChanged(nameof(CategoryName));
            }
        }

        public ICommand CancelCommand { get; }

        private readonly ErrorsViewModel _errorsViewModel;

        public CategoryFormViewModel(NavigationService<ManageCategoriesViewModel> listCategoriesViewNavigationService)
        {
            CancelCommand = new NavigateCommand<ManageCategoriesViewModel>(listCategoriesViewNavigationService);

            _errorsViewModel = new ErrorsViewModel();

            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;
        }


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
        }

        private void ValidateName()
        {
            _errorsViewModel.ClearErrors(nameof(CategoryName));

            if (string.IsNullOrEmpty(CategoryName)) _errorsViewModel.AddError(nameof(CategoryName), "Name can't be empty");

            else if (CategoryName.Length > 30)
                _errorsViewModel.AddError(nameof(CategoryName), "Name must be shorter than 30 characters");
        }
    }
}
