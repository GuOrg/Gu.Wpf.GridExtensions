namespace Gu.Wpf.GridExtensions
{
    using System.ComponentModel;

    /// <summary>
    /// Used by <see cref="Cell.IndexProperty"/>.
    /// </summary>
    [TypeConverter(typeof(GridCellConverter))]
    public struct GridCell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GridCell"/> struct.
        /// </summary>
        /// <param name="row">The row index.</param>
        /// <param name="column">The column index.</param>
        public GridCell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        /// <summary>
        /// Gets the row index.
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Gets the column index.
        /// </summary>
        public int Column { get; }
    }
}