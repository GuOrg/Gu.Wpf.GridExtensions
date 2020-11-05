namespace Gu.Wpf.GridExtensions
{
    using System.Windows;

    /// <summary> Defines an attached property for setting Grid.Layout instead of Grid.RowDefinitions and Grid.ColumnDefinitions. </summary>
    public static class Grid
    {
        /// <summary>
        /// A string like "Auto Auto *, Auto *.
        /// </summary>
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
        public static void SetLayout(System.Windows.Controls.Grid element, RowAndColumnDefinitions? value)
        {
            if (element is null)
            {
                throw new System.ArgumentNullException(nameof(element));
            }

            element.SetValue(LayoutProperty, value);
        }

        /// <summary>Helper for getting <see cref="LayoutProperty"/> from <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="System.Windows.Controls.Grid"/> to read <see cref="LayoutProperty"/> from.</param>
        /// <returns>Layout property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Grid))]
        public static RowAndColumnDefinitions? GetLayout(System.Windows.Controls.Grid element)
        {
            if (element is null)
            {
                throw new System.ArgumentNullException(nameof(element));
            }

            return (RowAndColumnDefinitions?)element.GetValue(LayoutProperty);
        }

        private static void OnLayoutChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is RowAndColumnDefinitions layout)
            {
                var grid = (System.Windows.Controls.Grid)d;
                grid.SetCurrentValue(Row.DefinitionsProperty, layout.RowDefinitions);
                grid.SetCurrentValue(Column.DefinitionsProperty, layout.ColumnDefinitions);
            }
        }
    }
}
