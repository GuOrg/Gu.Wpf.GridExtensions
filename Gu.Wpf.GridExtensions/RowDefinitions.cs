namespace Gu.Wpf.GridExtensions
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Controls;

    /// <summary>
    /// A collection of <see cref="System.Windows.Controls.ColumnDefinition"/>.
    /// </summary>
    [TypeConverter(typeof(RowDefinitionsConverter))]
    public class RowDefinitions : Collection<RowDefinition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RowDefinitions"/> class.
        /// </summary>
        public RowDefinitions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RowDefinitions"/> class.
        /// </summary>
        /// <param name="collection">The <see cref="IList{RowDefinition}"/>.</param>
        public RowDefinitions(IList<RowDefinition> collection)
            : base(collection)
        {
        }
    }
}
