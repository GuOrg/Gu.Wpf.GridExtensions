# Gu.Wpf.GridExtensions

Attached properties for WPF's `Grid`

## Sample.

```xaml
<!-- xmlns:gu="https://github.com/JohanLarsson/Gu.Wpf.GridExtensions" -->

<Grid gu:Column.Definitions="* *" gu:Row.Definitions="* *">
    <Rectangle gu:Cell.Index="1 1" Fill="Red" />
    <Rectangle gu:Cell.Index="1 0" Fill="Green" />
    <Rectangle Grid.Row="0"
               Grid.Column="0"
               Fill="Blue" />
    <Rectangle Grid.Row="0"
               Grid.Column="2"
               Fill="Yellow" />
</Grid>
```

## Sample using the layout attached property.

```xaml
<Grid gu:Grid.Layout="* *, * *">
	<Rectangle gu:Cell.Index="1 1" Fill="Red" />
	<Rectangle gu:Cell.Index="1 0" Fill="Green" />
	<Rectangle Grid.Row="0"
			   Grid.Column="0"
			   Fill="Blue" />
	<Rectangle Grid.Row="0"
			   Grid.Column="2"
			   Fill="Yellow" />
</Grid>
```

## Sample of usage in a style.

```xaml
<UserControl.Resources>
	<gu:ColumnDefinitions x:Key="Columns" x:Shared="False">
		<ColumnDefinition Width="Auto" />
		<ColumnDefinition Width="*" />
	</gu:ColumnDefinitions>

	<gu:RowDefinitions x:Key="Rows" x:Shared="False">
		<RowDefinition Height="Auto" />
		<RowDefinition Height="Auto" />
		<RowDefinition Height="*" />
	</gu:RowDefinitions>

	<Style x:Key="GridStyle" TargetType="{x:Type Grid}">
		<Setter Property="gu:Column.Definitions" Value="{StaticResource Columns}" />
		<Setter Property="gu:Row.Definitions" Value="{StaticResource Rows}" />
	</Style>
</UserControl.Resources>

<Grid Style="{StaticResource GridStyle}">
	<TextBlock gu:Cell.Index="0 0" Text="0 0" />
	<TextBlock gu:Cell.Index="0 1" Text="0 1" />
	<TextBlock gu:Cell.Index="2 1" Text="2 1" />
</Grid>
```
