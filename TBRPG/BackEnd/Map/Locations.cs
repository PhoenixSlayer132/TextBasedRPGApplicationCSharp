namespace TBRPG.BackEnd.Map;

public abstract class Locations
{
    public eLocations Location;
    public enum eLocations
    {
        TUTORIAL,
        BATTLE,
        EMPTY
    }
    public InstanceMap.eLanes LocationLane { get; set; }
    public string getLocation() { return Location.ToString(); }
    public void setLocation(eLocations location) { Location = location; }
    public abstract void MoveTo(eLocations location);
    
}