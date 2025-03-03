using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PC_Builder.Commands;

namespace PC_Builder.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
		private BaseViewModel selectedViewModel = new HomeViewModel();

		public BaseViewModel SelectedViewModel
		{
			get { return selectedViewModel; }
			set { 
                selectedViewModel = value; 
                OnPropertyChanged(nameof(SelectedViewModel));
            }
		}


		public ICommand UpdateViewCommand { get; set; }

        public MainWindowViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }
    }
}
