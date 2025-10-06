using TBRPG.BackEnd.Monsters;
using TBRPG.BackEnd.Player;

namespace TBRPG.BackEnd.Stats;

public interface IStatModifier {
    int conMod();

    int strMod();

    int dexMod();

    int intelMod();

    int wisMod();
}