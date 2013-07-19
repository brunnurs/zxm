using System;
using Cirrious.CrossCore.Converters;

namespace Zxm.Android.Converter
{
    public class MessageDateFormatConverter : MvxValueConverter<DateTime, string>
    {
        protected override string Convert(DateTime value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString("(dd.mm.yyyy)");
        }
    }
}