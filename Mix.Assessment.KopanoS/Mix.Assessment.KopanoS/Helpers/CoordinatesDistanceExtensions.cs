namespace Mix.Assessment.KopanoS.Helpers;

internal static class CoordinatesDistanceExtensions
{
    internal static double DistanceTo(this Mix.Assessment.Service.Model.CoOrdernate baseCoordinates,double Latitude,double Longitude)
    {
        return DistanceTo(baseCoordinates,Latitude,Longitude,UnitOfLength.Kilometers);
    }

    internal static double DistanceTo(this Service.Model.CoOrdernate baseCoordinates,double Latitude,double Longitude,UnitOfLength unitOfLength)
    {
        var baseRad = Math.PI * baseCoordinates.Latitude / 180;
        var targetRad = Math.PI * Latitude / 180;
        var theta = baseCoordinates.Longitude - Longitude;
        var thetaRad = Math.PI * theta / 180;

        double dist =
            Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
            Math.Cos(targetRad) * Math.Cos(thetaRad);
        dist = Math.Acos(dist);

        dist = dist * 180 / Math.PI;
        dist = dist * 60 * 1.1515;

        return unitOfLength.ConvertFromMiles(dist);
    }
}

internal class UnitOfLength
{
    internal static UnitOfLength Kilometers = new UnitOfLength(1.609344);
    internal static UnitOfLength NauticalMiles = new UnitOfLength(0.8684);
    internal static UnitOfLength Miles = new UnitOfLength(1);

    private readonly double _fromMilesFactor;

    private UnitOfLength(double fromMilesFactor)
    {
        _fromMilesFactor = fromMilesFactor;
    }

    internal double ConvertFromMiles(double input)
    {
        return input * _fromMilesFactor;
    }
}
