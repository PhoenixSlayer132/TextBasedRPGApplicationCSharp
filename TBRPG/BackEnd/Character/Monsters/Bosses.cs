using TBRPG.BackEnd.Stats;

namespace TBRPG.BackEnd.CharacterFolder.Monsters;

public class Bosses(string name, byte level, MonsterStats stats, MonsterType type)
    : Monster(name, level, type, stats);