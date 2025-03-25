using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PC_Builder.Commands;

namespace PC_Builder.ViewModels
{
    public class TestResultPopupWindowViewModel
    {
        public ICommand TestCommand { get; set; }
        public object ControlContent { get; set; }
        public TestResultPopupWindowViewModel()
        {
            TestCommand = new TestCommand();
        }

        public string errors { get; set; }
    }
}
