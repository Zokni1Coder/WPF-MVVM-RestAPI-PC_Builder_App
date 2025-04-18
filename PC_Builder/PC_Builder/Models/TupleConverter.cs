﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using PC_Builder.Interfaces;

namespace PC_Builder.Models
{
    public class TupleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2 && values[0] is IComputerPart computerPart && values[1] is string type1)
            {
                if (!string.IsNullOrEmpty(type1) && computerPart != null)
                {
                    return new Tuple<IComputerPart, int>(computerPart, 5);
                }
                return null;
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
