# Icoover 

[![Downloads](https://img.shields.io/nuget/dt/Umbraco.Community.Icoover?color=cc9900)](https://www.nuget.org/packages/Umbraco.Community.Icoover/)
[![NuGet](https://img.shields.io/nuget/vpre/Umbraco.Community.Icoover?color=0273B3)](https://www.nuget.org/packages/Umbraco.Community.Icoover)
[![GitHub license](https://img.shields.io/github/license/skttl/umbraco-icoover?color=8AB803)](../LICENSE)

Icoover automatically imports svg icons found in `App_Plugins/Icoover/icons` into Umbraco, to be used for Document Types and other places in the UI.

To add your own SVG icons, simply add them in the above mentioned path, and restart Umbraco. Your icons will be available with the alias `icoover-[icon filename]`, eg. `/App_Plugins/Icoover/icons/brand.svg` is imported into Umbraco as `icoover-brand`.

## Tips for SVG icons in Umbraco

### Use `viewBox` instead of `width` and `height`

Icons in Umbraco are inlined as SVG elements inside the [uui-icon](https://uui.umbraco.com/?path=/docs/uui-icon--docs) component. Because of this, sizing is handled by the component, and you should avoid having `width` and `height` attributes in your root SVG element.

|Do|Don't|
|-|-|
|`<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">`|`<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24">`|

### Use `currentColor` for colors

Make sure to use `currentColor` as the color of any strokes or fills in your icon, that should be colored according to the settings in Umbraco.

|Do|Don't|
|-|-|
|`<path d="M12 12L12 12" stroke="currentColor" stroke-width="2"/>`|`<path d="M12 12L12 12" stroke="#283a97" stroke-width="2"/>`|


## Installation

Add the package to an existing Umbraco website (v15+) from nuget:

`dotnet add package Umbraco.Community.Icoover`

After installing, the package will automatically pick up SVG files in `App_Plugins/Icoover/icons` and import them into Umbraco.

## Contributing

Contributions to this package are most welcome! Please read the [Contributing Guidelines](CONTRIBUTING.md).

## Acknowledgments

- Lotte Pitcher for her amazing [Opinionated Starter Kit](https://github.com/LottePitcher/opinionated-package-starter)