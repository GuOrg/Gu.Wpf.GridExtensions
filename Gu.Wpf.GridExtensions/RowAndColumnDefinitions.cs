namespace Gu.Wpf.GridExtensions
{
    using System.ComponentModel;

    /// <summary>
    /// Row and column definitions used by <see cref="Grid.LayoutProperty"/>
    /// Reason for custom type is [TypeConverter].
    /// </summary>
    [TypeConverter(typeof(RowAndColumnDefinitionsConverter))]
#pragma warning disable INPC001 // The class has mutable properties and should implement INotifyPropertyChanged.
    public class RowAndColumnDefinitions
#pragma warning restore INPC001 // The class has mutable properties and should implement INotifyPropertyChanged.
    {
#pragma warning disable CA2227 // Collection properties should be read only

        /// <summary>
        /// Gets or sets the <see cref="RowDefinitions"/>.
        /// </summary>
        public RowDefinitions? RowDefinitions { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ColumnDefinitions"/>.
        /// </summary>
        public ColumnDefinitions? ColumnDefinitions { get; set; }

#pragma warning restore CA2227 // Collection properties should be read only
    }
}
