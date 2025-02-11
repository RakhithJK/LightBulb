﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace LightBulb.Converters;

[ValueConversion(typeof(double), typeof(string))]
public class FractionToPercentageStringConverter : IValueConverter
{
    public static FractionToPercentageStringConverter Instance { get; } = new();

    public object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    ) => value is double doubleValue ? doubleValue.ToString("P0", culture) : default;

    public object ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    ) =>
        value is string stringValue
        && double.TryParse(
            stringValue.Trim('%', ' '),
            NumberStyles.Float | NumberStyles.AllowThousands,
            culture,
            out var result
        )
            ? result / 100.0
            : default;
}
