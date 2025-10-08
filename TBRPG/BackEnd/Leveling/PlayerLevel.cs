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

    public void LevelUp()
    {
        if (Experience >= 1.0f)
        {
            Experience -= 1.0f;
            Level += 1;
        }

        switch (Level)
        {
            case 1:
                LifeRank = eLifeRank.NewBlood; break;
            case 3:
                LifeRank = eLifeRank.Beginner; break;
            case 5:
                LifeRank = eLifeRank.Advanced; break;
            case 7:
                LifeRank = eLifeRank.Elite; break;
            case 9:
                LifeRank = eLifeRank.SpecialElite; break;
            case 11:
                LifeRank = eLifeRank.StandardChieftain; break;
            case 12:
                LifeRank = eLifeRank.HighChieftain; break;
            case 13:
                LifeRank = eLifeRank.Lord; break;
            case 14:
                LifeRank = eLifeRank.HighLord; break;
        }
        
    }
    
    
    
}