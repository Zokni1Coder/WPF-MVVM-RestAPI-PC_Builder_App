using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Builder.ViewModels
{
    public class FailedTestWindowViewModel
    {
        public string errors = "";
        public FailedTestWindowViewModel(string errors)
        {
            this.errors = errors; 
        }
    }
}
