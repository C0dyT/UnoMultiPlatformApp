using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;
using Windows.Globalization.NumberFormatting;

namespace UnoMultiPlatformApp.Converters;

public class CelsiusToFahrenheitConverter : IValueConverter
{

    public object Convert( object value, Type targetType, object parameter, string language )
    {
        double celsius = double.Parse( value.ToString() );
        double fahrenheit = celsius * (9.0/5.0) + 32.0;
        return fahrenheit;
    }

    public object ConvertBack( object value, Type targetType, object parameter, string language )
    {
        double fahrenheit = double.Parse( value.ToString() );
        double celsius = (fahrenheit - 32.0) * (5.0/9.0);
        return celsius;
    }
}

public class KilogramToPoundConverter : IValueConverter
{

    public object Convert( object value, Type targetType, object parameter, string language )
    {
        double kg = double.Parse( value.ToString() );
        double lb = kg * 2.2;

        return lb;
    }

    public object ConvertBack( object value, Type targetType, object parameter, string language )
    {
        double lb = double.Parse( value.ToString() );
        double kg = lb / 2.2;
        return kg;
    }
}

public class DoubleFormatter : INumberFormatter2, INumberParser
{
    public virtual string Format { get; set; } = "{0:F2}"; // by default we use this but you can change it in the XAML declaration
    public virtual string FormatDouble(double value) => string.Format(Format, value);
    public virtual double? ParseDouble(string text) => double.TryParse(text, out var dbl) ? dbl : null;

    // we only support doubles
    public string FormatInt(long value) => throw new NotSupportedException();
    public string FormatUInt(ulong value) => throw new NotSupportedException();
    public long? ParseInt(string text) => throw new NotSupportedException();
    public ulong? ParseUInt(string text) => throw new NotSupportedException();
}

