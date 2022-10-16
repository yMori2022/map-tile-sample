namespace MapTileSample.Utilities;

public class Coordinate
{
    public static int Long2TileX(double lon, int z)
    {
        return (int)(Math.Floor((lon + 180.0) / 360.0 * (1 << z)));
    }

    public static int Lat2TileY(double lat, int z)
    {
        return (int)Math.Floor((1 - Math.Log(Math.Tan(ToRadians(lat)) + 1 / Math.Cos(ToRadians(lat))) / Math.PI) / 2 *
                               (1 << z));
    }

    public static int Long2PixelX(double lon, int z)
    {
        return (int)(Math.Pow(2, z + 7) * (lon / 180 + 1));
    }

    public static int Lat2PixelY(double lat, int z)
    {
        return (int)((Math.Pow(2, z + 7) / Math.PI) * ((-1 * Math.Atanh(Math.Sin((Math.PI / 180) * lat))) +
                                                       Math.Atanh(Math.Sin((Math.PI / 180) * 85.05112878))));
    }


    public static double TileX2Long(int x, int z)
    {
        return x / (double)(1 << z) * 360.0 - 180;
    }

    public static double TileY2Lat(int y, int z)
    {
        double n = Math.PI - 2.0 * Math.PI * y / (double)(1 << z);
        return 180.0 / Math.PI * Math.Atan(0.5 * (Math.Exp(n) - Math.Exp(-n)));
    }
    
    

    public static double ToRadians(double degrees)
    {
        double radians = (Math.PI / 180) * degrees;
        return (radians);
    }
}