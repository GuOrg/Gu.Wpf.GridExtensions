# Gu.Wpf.GridExtensions

Attached properties for WPF's `Grid`
Sample:

```xaml
<Grid grid:Column.Definitions="* *" grid:Row.Definitions="* *">
    <Rectangle grid:Cell.Index="1 1" Fill="Red" />
    <Rectangle grid:Cell.Index="1 0" Fill="Green" />
    <Rectangle Grid.Row="0"
               Grid.Column="0"
               Fill="Blue" />
    <Rectangle Grid.Row="0"
               Grid.Column="2"
               Fill="Yellow" />
</Grid>
```
