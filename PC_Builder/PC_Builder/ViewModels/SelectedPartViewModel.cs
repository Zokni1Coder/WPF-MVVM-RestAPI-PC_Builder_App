using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PC_Builder.Commands;
using PC_Builder.Views;

namespace PC_Builder.ViewModels
{
    public class SelectedPartViewModel : BaseSelectedViewModel
    {
        private BaseSelectedViewModel selectedViewModel;

        public BaseSelectedViewModel SelectedViewModel
        {
            get
            {
                return selectedViewModel;
            }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand SelectViewCommand { get; set; }

        public SelectedPartViewModel()
        {
            SelectViewCommand = new SelectViewCommand(this);
        }
    }
}
