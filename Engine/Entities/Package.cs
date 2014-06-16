﻿namespace PostalService.Engine.Entities
{
    public sealed class Package
    {
        public Package(Location location)
        {
            Location = location;
        }

        public Location Location { get; private set; }
    }
}
