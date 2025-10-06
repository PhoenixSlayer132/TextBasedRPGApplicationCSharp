using TBRPG.BackEnd.Stats;

namespace TBRPG.BackEnd.Player;

public class PlayerStats : IStatModifier {
    public int Hp { get; set; }
    public int Con { get; set; }
    public int Str { get; set; }
    public int Dex { get; set; }
    public int Intel { get; set; }
    public int Wis { get; set; }
    public int Spd { get; set; }
    
    
    
    public PlayerStats(int health, int constitution, int strength, int dexterity, int intelligence, int wisdom, int speed) {
        Hp = health;
        Con = constitution;
        Str = strength;
        Dex = dexterity;
        Intel = intelligence;
        Wis = wisdom;
        Spd = speed;
    }

    public int conMod() { return (int) (Con * 0.2); }

    public int strMod() { return (int) (Str * 0.2); }

    public int dexMod() { return (int) (Dex * 0.2); }

    public int intelMod() { return (int) (Intel * 0.2); }

    public int wisMod() { return (int) (Wis * 0.2); }
}