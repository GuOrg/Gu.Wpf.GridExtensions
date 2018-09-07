namespace Gu.Wpf.GridExtensions
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Security;

    public class RowAndColumnDefinitionsConverter : TypeConverter
    {
        private static readonly RowDefinitionsConverter RowsConverter = new RowDefinitionsConverter();
        private static readonly ColumnDefinitionsConverter ColumnsConverter = new ColumnDefinitionsConverter();
        private static readonly char[] SeparatorChars = { ',', ';' };

        /// <inheritdoc />
        public override bool CanConvertFrom(ITypeDescriptorContext typeDescriptorContext, Type sourceType) => sourceType == typeof(string);

        /// <inheritdoc />
        public override bool CanConvertTo(ITypeDescriptorContext typeDescriptorContext, Type destinationType) => false;

        /// <inheritdoc />
        public override object ConvertFrom(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, object source)
        {
            if (source is string text)
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
                    RowDefinitions = (RowDefinitions)RowsConverter.ConvertFrom(typeDescriptorContext, cultureInfo, parts[0]),
                    ColumnDefinitions = (ColumnDefinitions)ColumnsConverter.ConvertFrom(typeDescriptorContext, cultureInfo, parts[1]),
                };
            }

            return base.ConvertFrom(typeDescriptorContext, cultureInfo, source);
        }

        /// <inheritdoc />
        [SecurityCritical]
        public override object ConvertTo(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, object value, Type destinationType)
        {
            throw new NotSupportedException();
        }
    }
}