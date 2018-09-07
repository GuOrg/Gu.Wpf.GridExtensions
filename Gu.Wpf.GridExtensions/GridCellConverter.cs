namespace Gu.Wpf.GridExtensions
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Security;

    /// <inheritdoc />
    public class GridCellConverter : TypeConverter
    {
        private static readonly char[] SeparatorChars = { ',', ' ' };

        /// <inheritdoc />
        public override bool CanConvertFrom(ITypeDescriptorContext typeDescriptorContext, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        /// <inheritdoc />
        public override bool CanConvertTo(ITypeDescriptorContext typeDescriptorContext, Type destinationType)
        {
            return false;
        }

        /// <inheritdoc />
        public override object ConvertFrom(ITypeDescriptorContext typeDescriptorContext, CultureInfo cultureInfo, object source)
        {
            if (source is string text)
            {
                try
                {
                    var strings = text.Split(SeparatorChars, StringSplitOptions.RemoveEmptyEntries);
                    if (strings.Length != 2)
                    {
                        var message = $"Could not parse {text} to a grid cell. Expected two ints";
                        throw new FormatException(message);
                    }

                    return new GridCell(int.Parse(strings[0]), int.Parse(strings[1]));
                }
                catch (Exception e)
                {
                    var message = $"Could not parse row and column from {text}.\r\n" +
                                  $"Expected a string like '1 2'. (Two integers)\r\n" +
                                  $"Valid separators are {{{string.Join(", ", SeparatorChars.Select(x => $"'x'"))}}}";
                    throw new FormatException(message, e);
                }
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