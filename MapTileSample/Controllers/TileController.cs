using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace MapTileSample.Controllers;

public class TileController : Controller
{
    [Route("tile/{z}/{x}/{y}/tile.svg")]
    public IActionResult Index(int x, int y, int z)
    {
        // 35.68026187847616, 139.76875062591986
        var lat = 35.68026187847616;
        var lng = 139.76875062591986;

        lat = 35.650400;
        lng = 139.768345;
        
        var tileX = Utilities.Coordinate.Long2TileX(lng, z);
        var tileY = Utilities.Coordinate.Lat2TileY(lat, z);


        var pixelX = Utilities.Coordinate.Long2PixelX(lng, z);
        var pixelY = Utilities.Coordinate.Lat2PixelY(lat, z);

        var x2 = pixelX - (x * 256);
        var y2 = pixelY - (y * 256);


        var svg = "<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\" \"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">"
                  + "<svg width=\"256\" height=\"256\" viewBox=\"0 0 256 256\" xmlns=\"http://www.w3.org/2000/svg\">"
                  + "<circle cx=\"" + x2 + "\" cy=\"" + y2 + "\" r=\"10\"  stroke=\"black\" fill=\"#FF0000\" />"
                  + "</svg>";

        var data = Encoding.UTF8.GetBytes(svg);
        return File(data, "image/svg+xml");
    }
}