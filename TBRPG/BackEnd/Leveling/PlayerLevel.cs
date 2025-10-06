namespace TBRPG.BackEnd.Leveling;

public class PlayerLevel
{
    public byte Level { get; set;}
    public float Experience { get; set;}
    public eLifeRank LifeRank { get; set;}
    public enum eLifeRank {
        Tutorial,
        NewBlood,
        Beginner,
        Advanced,
        Elite,
        SpecialElite,
        StandardChieftain,
        HighChieftain,
        Lord,
        HighLord
    }
    public PlayerLevel(byte level, float experience, eLifeRank lifeRank) {
        Level = level;
        Experience = experience;
        LifeRank = lifeRank;
    }
}