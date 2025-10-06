using TBRPG.BackEnd.Stats;

namespace TBRPG.BackEnd.Monsters;

public class Monsters {
    private string Name { get; set; }
    private byte Level { get; set; }
    private MonsterType Type { get; set; }
    private MonsterStats Stats { get; set; }
    
    public Monsters(string name, byte level, MonsterType type, MonsterStats stats) {
        Name = name;
        Level = level;
        Type = type;
        Stats = stats;
    }

    public override string ToString()
    {
        return "Monsters: " + Name + ", Level: " + Level + ", Type: " + Type;
    }
}