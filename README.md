# Gu.Wpf.GridExtensions
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md)
[![NuGet](https://img.shields.io/nuget/v/Gu.Wpf.GridExtensions.svg)](https://www.nuget.org/packages/Gu.Wpf.GridExtensions/)
[![Build status](https://ci.appveyor.com/api/projects/status/8kvvd5ggbkn2wevm/branch/master?svg=true)](https://ci.appveyor.com/project/JohanLarsson/gu-wpf-gridextensions/branch/master)
[![Build Status](https://dev.azure.com/guorg/Gu.Wpf.GridExtensions/_apis/build/status/GuOrg.Gu.Wpf.GridExtensions?branchName=master)](https://dev.azure.com/guorg/Gu.Wpf.GridExtensions/_build/latest?definitionId=25&branchName=master)
Attached properties for WPF's `Grid`

## Sample.

```xaml
<!-- xmlns:gu="https://github.com/JohanLarsson/Gu.Wpf" -->

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
