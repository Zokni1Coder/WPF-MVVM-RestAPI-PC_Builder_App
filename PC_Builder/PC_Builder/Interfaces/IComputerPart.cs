﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Builder.Interfaces
{
    public interface IComputerPart
    {
        void Accept(IComputerPartVisitor visitor);
        string Name();
    }
}
