﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Builder.ViewModels
{
    public class ErrorWindowViewModel
    {
        public string Description { get; set; }
        public ErrorWindowViewModel(string description)
        {
            this.Description = description;
        }
    }
}
