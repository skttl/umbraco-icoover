# Icoover 

[![Downloads](https://img.shields.io/nuget/dt/Umbraco.Community.Icoover?color=cc9900)](https://www.nuget.org/packages/Umbraco.Community.Icoover/)
[![NuGet](https://img.shields.io/nuget/vpre/Umbraco.Community.Icoover?color=0273B3)](https://www.nuget.org/packages/Umbraco.Community.Icoover)
[![GitHub license](https://img.shields.io/github/license/skttl/umbraco-icoover?color=8AB803)](https://github.com/skttl/umbraco-icoover/blob/main/LICENSE)

Icoover automatically imports svg icons found in `App_Plugins/Icoover/icons` into Umbraco, to be used for Document Types and other places in the UI.

To add your own SVG icons, simply add them in the above mentioned path, and restart Umbraco. Your icons will be available with the alias `icoover-[icon filename]`, eg. `/App_Plugins/Icoover/icons/brand.svg` is imported into Umbraco as `icoover-brand`.