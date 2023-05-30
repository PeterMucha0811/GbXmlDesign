namespace GbXmlDesign.Core.Events
{
    public class BuildingUpdatedEvent
    {
        public int BuildingId { get; set; }

        public BuildingUpdatedEvent(int buildingId)
        {
            BuildingId = buildingId;
        }
    }
}