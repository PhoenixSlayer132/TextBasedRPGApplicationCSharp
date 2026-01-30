namespace TBRPG.BackEnd.Map;

public class PlayerPosition
{
    
    private int Step { get; set;}
    public InstanceMap.eLanes Lane { get; private set;}
    private PlayerPosition playerPosition = null!;
    
    public PlayerPosition(InstanceMap.eLanes lane, int step)
    {
        Lane = lane;
        Step = step;
    }
    

    public InstanceMap.eLanes lane { get; set; }
    public int step { get; set; }

}