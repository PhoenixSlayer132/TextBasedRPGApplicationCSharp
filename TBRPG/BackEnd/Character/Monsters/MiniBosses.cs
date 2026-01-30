using TBRPG.BackEnd.Stats;

namespace TBRPG.BackEnd.CharacterFolder.Monsters;

public class MiniBosses(string name, byte level, MonsterStats stats, MonsterType type)
    : Monster(name, level, type, stats);