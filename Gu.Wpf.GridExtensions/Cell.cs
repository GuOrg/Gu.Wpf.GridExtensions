namespace Gu.Wpf.GridExtensions
{
    using System.Windows;

    public static class Cell
    {
        public static readonly DependencyProperty IndexProperty = DependencyProperty.RegisterAttached(
            "Index",
            typeof(GridCell),
            typeof(Cell),
            new PropertyMetadata(
                default(GridCell),
                OnIndexChanged));

        /// <summary>Helper for setting <see cref="IndexProperty"/> on <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="UIElement"/> to set <see cref="IndexProperty"/> on.</param>
        /// <param name="value">Index property value.</param>
        public static void SetIndex(UIElement element, GridCell value)
        {
            element.SetValue(IndexProperty, value);
        }

        /// <summary>Helper for getting <see cref="IndexProperty"/> from <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="UIElement"/> to read <see cref="IndexProperty"/> from.</param>
        /// <returns>Index property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static GridCell GetIndex(UIElement element)
        {
            return (GridCell)element.GetValue(IndexProperty);
        }

        private static void OnIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var cell = (GridCell)e.NewValue;
            d.SetCurrentValue(System.Windows.Controls.Grid.RowProperty, cell.Row);
            d.SetCurrentValue(System.Windows.Controls.Grid.ColumnProperty, cell.Column);
        }
    }
}
