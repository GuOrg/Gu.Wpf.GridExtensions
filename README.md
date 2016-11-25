# Gu.Wpf.GridExtensions

Attached properties for WPF's `Grid`
Sample:

```xaml
<!-- xmlns:grid="https://github.com/JohanLarsson/Gu.Wpf.PropertyGrid" -->

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

Sample of usage in a style:

```xaml
<UserControl.Resources>
	<grid:ColumnDefinitions x:Key="Columns" x:Shared="False">
		<ColumnDefinition Width="Auto" />
		<ColumnDefinition Width="*" />
	</grid:ColumnDefinitions>

	<grid:RowDefinitions x:Key="Rows" x:Shared="False">
		<RowDefinition Height="Auto" />
		<RowDefinition Height="Auto" />
		<RowDefinition Height="*" />
	</grid:RowDefinitions>

	<Style x:Key="GridStyle" TargetType="{x:Type Grid}">
		<Setter Property="grid:Column.Definitions" Value="{StaticResource Columns}" />
		<Setter Property="grid:Row.Definitions" Value="{StaticResource Rows}" />
	</Style>
</UserControl.Resources>

<Grid Style="{StaticResource GridStyle}">
	<TextBlock grid:Cell.Index="0 0" Text="0 0" />
	<TextBlock grid:Cell.Index="0 1" Text="0 1" />
	<TextBlock grid:Cell.Index="2 1" Text="2 1" />
</Grid>
```
