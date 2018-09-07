namespace Gu.Wpf.GridExtensions
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Controls;

    /// <summary>
    /// A collection of <see cref="ColumnDefinition"/>.
    /// </summary>
    [TypeConverter(typeof(ColumnDefinitionsConverter))]
    public class ColumnDefinitions : Collection<System.Windows.Controls.ColumnDefinition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnDefinitions"/> class.
        /// </summary>
        public ColumnDefinitions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnDefinitions"/> class.
        /// </summary>
        /// <param name="collection">The <see cref="IList{ColumnDefinition}"/>.</param>
        public ColumnDefinitions(IList<ColumnDefinition> collection)
            : base(collection)
        {
        }
    }
}