namespace Gu.Wpf.GridExtensions
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Used by <see cref="Cell.IndexProperty"/>.
    /// </summary>
    [TypeConverter(typeof(GridCellConverter))]
    public struct GridCell : IEquatable<GridCell>
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

        /// <summary>Check if <paramref name="left"/> is equal to <paramref name="right"/>.</summary>
        /// <param name="left">The left <see cref="GridCell"/>.</param>
        /// <param name="right">The right <see cref="GridCell"/>.</param>
        /// <returns>True if <paramref name="left"/> is equal to <paramref name="right"/>.</returns>
        public static bool operator ==(GridCell left, GridCell right)
        {
            return left.Equals(right);
        }

        /// <summary>Check if <paramref name="left"/> is not equal to <paramref name="right"/>.</summary>
        /// <param name="left">The left <see cref="GridCell"/>.</param>
        /// <param name="right">The right <see cref="GridCell"/>.</param>
        /// <returns>True if <paramref name="left"/> is not equal to <paramref name="right"/>.</returns>
        public static bool operator !=(GridCell left, GridCell right)
        {
            return !left.Equals(right);
        }

        /// <inheritdoc/>
        public bool Equals(GridCell other)
        {
            return this.Row == other.Row && this.Column == other.Column;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is GridCell other && this.Equals(other);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Row * 397) ^ this.Column;
            }
        }
    }
}
