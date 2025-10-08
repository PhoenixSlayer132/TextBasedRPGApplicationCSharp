using TBRPG.BackEnd.Stats;

namespace TBRPG.BackEnd.Player;

public class PlayerStats {
    public byte Hp { get; set; }
    public byte Con { get; set; }
    public byte Str { get; set; }
    public byte Dex { get; set; }
    public byte Intel { get; set; }
    public byte Wis { get; set; }
    public byte Spd { get; set; }
    
    
    
    public PlayerStats(byte health, byte constitution, byte strength, byte dexterity, byte intelligence, byte wisdom, byte speed) {
        Hp = health;
        Con = constitution;
        Str = strength;
        Dex = dexterity;
        Intel = intelligence;
        Wis = wisdom;
        Spd = speed;
    }
}