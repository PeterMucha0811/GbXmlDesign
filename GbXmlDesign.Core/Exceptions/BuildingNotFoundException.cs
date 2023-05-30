using System;

namespace GbXmlDesign.Core.Exceptions
{
    public class BuildingNotFoundException : Exception
    {
        public BuildingNotFoundException(int buildingId)
            : base($"Building with ID {buildingId} was not found.")
        {
        }
    }
}