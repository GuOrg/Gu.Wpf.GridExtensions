namespace Gu.Wpf.GridExtensions
{
    using System.ComponentModel;

    [TypeConverter(typeof(RowAndColumnDefinitionsConverter))]
    public class RowAndColumnDefinitions
    {
        public RowDefinitions RowDefinitions { get; set; }

        public ColumnDefinitions ColumnDefinitions { get; set; }
    }
}