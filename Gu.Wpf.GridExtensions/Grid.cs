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

        public static void SetLayout(DependencyObject element, RowAndColumnDefinitions value)
        {
            element.SetValue(LayoutProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(Grid))]
        public static RowAndColumnDefinitions GetLayout(DependencyObject element)
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