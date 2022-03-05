namespace Gu.Wpf.GridExtensions
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Security;

    /// <inheritdoc />
    public class RowAndColumnDefinitionsConverter : TypeConverter
    {
        private static readonly RowDefinitionsConverter RowsConverter = new();
        private static readonly ColumnDefinitionsConverter ColumnsConverter = new();
        private static readonly char[] SeparatorChars = { ',', ';' };

        /// <inheritdoc />
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) => sourceType == typeof(string);

        /// <inheritdoc />
        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType) => false;

        /// <inheritdoc />
        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is string text)
            {
                var parts = text.Split(SeparatorChars, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2)
                {
                    var message = $"Could not parse layout from {text}.\r\n" +
                                  $"Expected a string like '* 20 Auto, Auto *'\r\n" +
                                  $"Valid separators are {{{string.Join(", ", SeparatorChars.Select(x => $"'x'"))}}}";
                    throw new FormatException(message);
                }

                return new RowAndColumnDefinitions
                {
                    RowDefinitions = (RowDefinitions?)RowsConverter.ConvertFrom(context, culture, parts[0]),
                    ColumnDefinitions = (ColumnDefinitions?)ColumnsConverter.ConvertFrom(context, culture, parts[1]),
                };
            }

            return base.ConvertFrom(context, culture, value);
        }

        /// <inheritdoc />
        [SecurityCritical]
        public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object value, Type destinationType)
        {
            throw new NotSupportedException();
        }
    }
}
