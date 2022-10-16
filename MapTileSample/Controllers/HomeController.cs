using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MapTileSample.Models;

namespace MapTileSample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
       // 17/116423/51613.png
     //  var lat = Utilities.Coordinate.TileY2Lat(51613, 17);
     //  var lng = Utilities.Coordinate.TileX2Long(116423, 17);
       
       var lat = 35.68026187847616;
       var lng = 139.76875062591986;

       var tileX = Utilities.Coordinate.Long2TileX(lng, 17);
       var tileY = Utilities.Coordinate.Lat2TileY(lat, 17);

       var pixelX = Utilities.Coordinate.Long2PixelX(lng, 17);
       var pixelY = Utilities.Coordinate.Lat2PixelY(lat, 17);

       var x = pixelX - (116423 * 256);
       var y = pixelY - (51613 * 256);
       
       /*
           <svg width="100" height="100"  viewBox="-100 -100 200 200" xmlns="http://www.w3.org/2000/svg">
           <circle cx="0" cy="0" r="80"  stroke="black" fill="none" >
           </svg>
       */
       
       
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}