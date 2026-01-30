namespace TBRPG.BackEnd.Map;

public class InstanceMap : Locations
{
    private const byte INITIAL_LENGTH = 10;

    private static Random rand = new Random();
    private static byte rLocation;
    private static byte globalX = 20;
    private static List<List<MapNode>> map = new List<List<MapNode>>();

    public class MapNode(int x, int y, eLanes lane, eLocations location, bool enabled)
    {
        public static int nodeCount = 0;
        private int x = x;
        private int y = y;
        private eLanes lane = lane;
        private eLocations location = location;
        private bool enabled = enabled;
    }
    
    public enum eLanesY
    {
        Top = 40,
        Middle = 60,
        Bottom = 80
    }
    
    public enum eLanes
    {
        Top = 0,
        Middle = 1,
        Bottom = 2
    }
    
    public static void generateInitialMap()
    {
        throw new NotImplementedException();

        map.Add(
            new List<MapNode>
            {
                new (globalX, (byte)eLanesY.Top, eLanes.Top, eLocations.EMPTY, false), 
                new (globalX,(byte)eLanesY.Middle, eLanes.Middle, eLocations.TUTORIAL, true), 
                new (globalX, (byte)eLanesY.Bottom, eLanes.Bottom, eLocations.EMPTY, false)
            });
        
        for (int laneLength = 1; laneLength < INITIAL_LENGTH; laneLength++)
        {
            rLocation = (byte) rand.Next(0, Enum.GetNames(typeof(eLocations)).Length);
            
            
            
        }
        
    }

    public static void generateSpaces(byte amt)
    {
        while (amt > 0)
        {
            throw new NotImplementedException();
            generateNode();
            amt--;
        }

    }

    public static MapNode generateNode()
    {
        throw new NotImplementedException();

        byte lX = 1;
        byte lY;
        eLanes lLane;
        eLocations lLocation;
        
        
        lY = (byte)rand.Next(0, 20);
        lLane = (eLanes) rand.Next(0, Enum.GetNames(typeof(eLanes)).Length);
        lLocation = (eLocations) rand.Next(0, Enum.GetNames(typeof(eLocations)).Length);
        
        return new MapNode((lX * MapNode.nodeCount) + globalX, lY, lLane, lLocation, lLocation == eLocations.EMPTY);
    }

    public override void MoveTo(eLocations location)
    {
        throw new NotImplementedException();

    }
}