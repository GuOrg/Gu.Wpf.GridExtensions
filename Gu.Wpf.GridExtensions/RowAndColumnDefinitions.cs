namespace Gu.Wpf.GridExtensions
{
    using System.ComponentModel;

    /// <summary>
    /// Row and column definitions used by <see cref="Grid.LayoutProperty"/>
    /// Reason for custom type is [TypeConverter].
    /// </summary>
    [TypeConverter(typeof(RowAndColumnDefinitionsConverter))]
    public class RowAndColumnDefinitions
    {
        /// <summary>
        /// Gets or sets the <see cref="RowDefinitions"/>.
        /// </summary>
        public RowDefinitions RowDefinitions { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ColumnDefinitions"/>.
        /// </summary>
        public ColumnDefinitions ColumnDefinitions { get; set; }
    }
}