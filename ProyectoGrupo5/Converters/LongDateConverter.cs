﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace ProyectoGrupo5.Converters
{
    /// <summary>
    /// Binding value converter that returns a long-form string of a date.
    /// <seealso href="https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/data-binding/converters"/>
    /// </summary>
    public class LongDateConverter : IValueConverter
    {
        /// <param name="value">Date (DateTime)</param>
        /// <param name="targetType">Unused</param>
        /// <param name="parameter">Unused</param>
        /// <param name="culture">Unused</param>
        /// <returns>A long-form string of the date.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateTime)value).ToLongDateString();
        }

        /// <summary>
        /// It is unnecessary to implement.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
