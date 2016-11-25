namespace Gu.Wpf.GridExtensions
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Controls;

    [TypeConverter(typeof(RowDefinitionsConverter))]
    public class RowDefinitions : Collection<RowDefinition>
    {
        public RowDefinitions()
        {
        }

        public RowDefinitions(IList<RowDefinition> definitions)
            : base(definitions)
        {
        }
    }
}