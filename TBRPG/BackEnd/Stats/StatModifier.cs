namespace TBRPG.BackEnd.Stats;

public interface IStatModifier {
    int conBoost();

    int strBoost();

    int dexBoost();

    int intelBoost();

    int wisBoost();
    
    int conNerf();

    int strNerf();

    int dexNerf();

    int intelNerf();

    int wisNerf();
}