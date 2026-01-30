using TBRPG.BackEnd.CharacterFolder;

namespace TBRPG.BackEnd.Stats;

public class PlayerStats : CharacterStats {
    
    public PlayerStats(byte health, byte constitution, byte strength, byte dexterity, byte intelligence, byte wisdom, byte speed) {
        Hp = health;
        CurrentHp = Hp;
        Con = constitution;
        Str = strength;
        Dex = dexterity;
        Intel = intelligence;
        Wis = wisdom;
        Spd = speed;
    }
}