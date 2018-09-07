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

        public static void SetDefinitions(System.Windows.Controls.Grid element, ColumnDefinitions value)
        {
            element.SetValue(DefinitionsProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(Grid))]
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