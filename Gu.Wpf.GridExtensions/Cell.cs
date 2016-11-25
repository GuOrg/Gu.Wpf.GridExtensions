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


        public static void SetIndex(UIElement element, GridCell value)
        {
            element.SetValue(IndexProperty, value);
        }

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
