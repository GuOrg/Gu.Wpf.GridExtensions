namespace Gu.Wpf.GridExtensions
{
    using System.Windows;

    public static class Grid
    {
        public static readonly DependencyProperty LayoutProperty = DependencyProperty.RegisterAttached(
            "Layout",
            typeof(RowAndColumnDefinitions),
            typeof(Grid),
            new FrameworkPropertyMetadata(
                default(RowAndColumnDefinitions),
                OnLayoutChanged));

        /// <summary>Helper for setting <see cref="LayoutProperty"/> on <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="System.Windows.Controls.Grid"/> to set <see cref="LayoutProperty"/> on.</param>
        /// <param name="value">Layout property value.</param>
        public static void SetLayout(System.Windows.Controls.Grid element, RowAndColumnDefinitions value)
        {
            element.SetValue(LayoutProperty, value);
        }

        /// <summary>Helper for getting <see cref="LayoutProperty"/> from <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="System.Windows.Controls.Grid"/> to read <see cref="LayoutProperty"/> from.</param>
        /// <returns>Layout property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Grid))]
        public static RowAndColumnDefinitions GetLayout(System.Windows.Controls.Grid element)
        {
            return (RowAndColumnDefinitions)element.GetValue(LayoutProperty);
        }

        private static void OnLayoutChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var layout = e.NewValue as RowAndColumnDefinitions;
            if (layout == null)
            {
                return;
            }

            var grid = (System.Windows.Controls.Grid)d;
            grid.SetCurrentValue(Row.DefinitionsProperty, layout.RowDefinitions);
            grid.SetCurrentValue(Column.DefinitionsProperty, layout.ColumnDefinitions);
        }
    }
}