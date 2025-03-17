using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Manifest;
using Umbraco.Cms.Infrastructure.Manifest;

namespace Icoover.Package;

internal sealed class UmbracoPackage : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddSingleton<IPackageManifestReader, IcooverPackage>();
    }

    private class IcooverPackage : IPackageManifestReader
    {
        public Task<IEnumerable<PackageManifest>> ReadPackageManifestsAsync()
        {
            // get info from assembly
            Assembly assembly = typeof(UmbracoPackage).Assembly;
            var version = assembly.GetName().Version?.ToString() ?? "0.0.0";

            IEnumerable<PackageManifest> manifests = new List<PackageManifest> {
                new()
                {
                    Id = "Umbraco.Community.Icoover",
                    Name = "Icoover",
                    AllowTelemetry = true,
                    Version = version,
                    Extensions = [Manifest()],
                }
            };
            return Task.FromResult(manifests);
        }

        private static Dictionary<string, dynamic> Manifest() => new()
        {
            ["type"] = "icons",
            ["alias"] = "Umbraco.Community.Icoover.Icons",
            ["name"] = "Icoover",
            ["js"] = "/App_Plugins/Icoover/index.js"
        };
    }
}
