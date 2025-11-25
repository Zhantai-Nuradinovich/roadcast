using System.Text;

namespace roadcast.Shared.Helpers;

public static class GeoHashHelper
{
    public static string Encode(double latitude, double longitude, int precision = 9)
    {
        var latRange = new[] { -90.0, 90.0 };
        var lonRange = new[] { -180.0, 180.0 };

        var geohash = new StringBuilder();
        var bit = 0;
        var ch = 0;
        var evenBit = true;

        while (geohash.Length < precision)
        {
            double mid;
            if (evenBit)
            {
                mid = (lonRange[0] + lonRange[1]) / 2;
                if (longitude >= mid)
                {
                    ch |= Bits[bit];
                    lonRange[0] = mid;
                }
                else
                {
                    lonRange[1] = mid;
                }
            }
            else
            {
                mid = (latRange[0] + latRange[1]) / 2;
                if (latitude >= mid)
                {
                    ch |= Bits[bit];
                    latRange[0] = mid;
                }
                else
                {
                    latRange[1] = mid;
                }
            }

            evenBit = !evenBit;

            if (bit < 4)
            {
                bit++;
            }
            else
            {
                geohash.Append(Base32[ch]);
                bit = 0;
                ch = 0;
            }
        }

        return geohash.ToString();
    }

    private static readonly int[] Bits = { 16, 8, 4, 2, 1 };

    private static readonly char[] Base32 = {
        '0','1','2','3','4','5','6','7','8','9',
        'b','c','d','e','f','g','h','j','k','m',
        'n','p','q','r','s','t','u','v','w','x',
        'y','z'
    };
}
