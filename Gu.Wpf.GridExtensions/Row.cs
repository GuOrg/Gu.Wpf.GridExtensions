namespace Gu.Wpf.GridExtensions
{
    using System.Windows;

    public static class Row
    {
        public static readonly DependencyProperty DefinitionsProperty = DependencyProperty.RegisterAttached(
            "Definitions",
            typeof(RowDefinitions),
            typeof(Row),
            new FrameworkPropertyMetadata(
                default(RowDefinitions),
                FrameworkPropertyMetadataOptions.NotDataBindable,
                OnDefinitionsChanged));

        public static void SetDefinitions(System.Windows.Controls.Grid element, RowDefinitions value)
        {
            element.SetValue(DefinitionsProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(Cell))]
        public static RowDefinitions GetDefinitions(System.Windows.Controls.Grid element)
        {
            return (RowDefinitions)element.GetValue(DefinitionsProperty);
        }

        private static void OnDefinitionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = (System.Windows.Controls.Grid)d;
            grid.RowDefinitions.Clear();

            var rowDefinitions = (RowDefinitions)e.NewValue;
            if (rowDefinitions == null)
            {
                return;
            }

            foreach (var rowDefinition in rowDefinitions)
            {
                grid.RowDefinitions.Add(rowDefinition);
            }
        }
    }
}