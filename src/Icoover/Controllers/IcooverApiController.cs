using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Extensions;

namespace Icoover.Controllers;

[Route("/App_Plugins/Icoover/")]
public class ServerVariablesController : ControllerBase
{
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly string _path;

    public ServerVariablesController(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
        _path = _hostingEnvironment.MapPathWebRoot(Path.Combine("App_Plugins", "Icoover", "icons"));
    }

    [HttpGet("index.js")]
    public IActionResult Index()
    {
        Response.Headers.ContentType = "text/javascript";

        var files = Directory.GetFiles(_path, "*.svg");
        var icons = new Dictionary<string, string>();

        foreach (var file in files)
        {
            icons.TryAdd(Path.GetFileNameWithoutExtension(file), System.IO.File.ReadAllText(file));
        }


        return Content($@"
export default [
            {string.Join(
                    ",\n",
                    files.Select(x => $@"
{{
    name: '{Path.GetFileNameWithoutExtension(x).EnsureStartsWith("icoover-")}',
    path: () => import (`./icons/{Path.GetFileNameWithoutExtension(x)}.js`)
}}
                    ")
                )}
]  
        ");
    }


    [HttpGet("icons/{name}.js")]
    public IActionResult Icon(string name)
    {
        var filePath = Path.Combine(_path, $"{name}.svg");
        if (System.IO.File.Exists(filePath) == false)
        {
            return NotFound();
        }
        Response.Headers.ContentType = "text/javascript";

        return Content($"export default `{System.IO.File.ReadAllText(filePath)}`");
    }
}
