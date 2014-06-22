using System;
using System.IO;

namespace PostalService.Engine
{
    public struct Location
    {
        public Location(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Location a, Location b)
        {
            return Math.Abs(a.X - b.X) < 0.01 && Math.Abs(a.Y - b.Y) < 0.01;
        }

        public static bool operator !=(Location a, Location b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            return this == (Location)obj;
        }

        public override int GetHashCode()
        {
            return (X + Y).GetHashCode();
        }

        public double DistanceTo(Location location)
        {
            var distanceX = location.X - X;
            var distanceY = location.Y - Y;
            return Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
        }

        public Location ApproachTo(Location location, double distance)
        {
            var totalDistance = DistanceTo(location);
            if (distance >= totalDistance)
                return location;

            var sin = totalDistance / (location.Y - Y);
            var cos = totalDistance / (location.X - X);

            var distanceY = distance / sin;
            var distanceX = distance / cos;

            return new Location(X + distanceX, Y + distanceY);
        }

        public readonly double X;

        public readonly double Y;
    }
}
