namespace Gu.Wpf.GridExtensions
{
    using System.Windows;

    public static class Column
    {
        public static readonly DependencyProperty DefinitionsProperty = DependencyProperty.RegisterAttached(
            "Definitions",
            typeof(ColumnDefinitions),
            typeof(Column),
            new FrameworkPropertyMetadata(
                default(ColumnDefinitions),
                FrameworkPropertyMetadataOptions.NotDataBindable,
                OnDefinitionsChanged));

        /// <summary>Helper for setting <see cref="DefinitionsProperty"/> on <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="System.Windows.Controls.Grid"/> to set <see cref="DefinitionsProperty"/> on.</param>
        /// <param name="value">Definitions property value.</param>
        public static void SetDefinitions(System.Windows.Controls.Grid element, ColumnDefinitions value)
        {
            element.SetValue(DefinitionsProperty, value);
        }

        /// <summary>Helper for getting <see cref="DefinitionsProperty"/> from <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="System.Windows.Controls.Grid"/> to read <see cref="DefinitionsProperty"/> from.</param>
        /// <returns>Definitions property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Grid))]
        public static ColumnDefinitions GetDefinitions(System.Windows.Controls.Grid element)
        {
            return (ColumnDefinitions)element.GetValue(DefinitionsProperty);
        }

        private static void OnDefinitionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = (System.Windows.Controls.Grid)d;
            grid.ColumnDefinitions.Clear();

            var columnDefinitions = (ColumnDefinitions)e.NewValue;
            if (columnDefinitions == null)
            {
                return;
            }

            foreach (var columnDefinition in columnDefinitions)
            {
                grid.ColumnDefinitions.Add(columnDefinition);
            }
        }
    }
}