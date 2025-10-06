using TBRPG.BackEnd.Stats;

namespace TBRPG.BackEnd.Monsters;

public class Bosses(string name, byte level, MonsterStats stats, MonsterType type)
    : Monsters(name, level, type, stats);