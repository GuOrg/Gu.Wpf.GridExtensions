namespace Gu.Wpf.GridExtensions
{
    using System.ComponentModel;

    [TypeConverter(typeof(GridCellConverter))]
    public struct GridCell
    {
        public GridCell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public int Row { get; }

        public int Column { get; }
    }
}