namespace roadcast.Shared.Helpers;

public static class SpeedToRadiusHelper
{
    private const int Below30KmH = 30;
    private const int Below60KmH = 60;

    private const int Radius150Meters = 150;
    private const int Radius500Meters = 500;
    private const int Radius1000Meters = 1000;

    public static double GetRadiusBySpeed(double speed)
    {
        if (speed <= Below30KmH)
        {
            return Radius150Meters;
        }

        if (speed <= Below60KmH)
        {
            return Radius500Meters;
        }
        
        return Radius1000Meters;
    }
}
