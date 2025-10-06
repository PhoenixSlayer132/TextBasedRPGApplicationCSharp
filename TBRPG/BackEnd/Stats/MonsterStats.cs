namespace TBRPG.BackEnd.Stats;
using TBRPG.BackEnd.Leveling;
using TBRPG.BackEnd.Player;

public class MonsterStats : IStatModifier
{
    private static int randomHealth,
        randomConsti,
        randomStreng,
        randomDext,
        randomIntelli,
        randomWisdom,
        randomSpeed;

    private static eLifeRank randomSkillLevel;
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
    
    public static MonsterStats randomizedStats() {
        Random random = new Random();
        string[] lifeRankList = Enum.GetNames(typeof(eLifeRank));
        byte randomLifeRankIndex = (byte)random.Next(0, lifeRankList.Length);
        PlayerLevel.eLifeRank lifeRank = Player.player.Level.LifeRank;
        switch (lifeRank) {
            case PlayerLevel.eLifeRank.Tutorial:
            {
                randomSkillLevel = eLifeRank.Tutorial;
                randomHealth = random.Next(10, 20);
                randomConsti = random.Next(3, 7);
                randomStreng = random.Next(3, 7);
                randomDext = random.Next(3, 7);
                randomIntelli = random.Next(3, 7);
                randomWisdom = random.Next(3, 7);
                randomSpeed = random.Next(2, 5);
                break;
            }
            case PlayerLevel.eLifeRank.NewBlood: {
                while (randomLifeRankIndex != 0 || randomLifeRankIndex != 1)
                    randomLifeRankIndex = (byte)random.Next(0, lifeRankList.Length);
                
                randomSkillLevel = (eLifeRank)randomLifeRankIndex;
                randomHealth = random.Next(10, 20);
                randomConsti = random.Next(3, 7);
                randomStreng = random.Next(3, 7);
                randomDext = random.Next(3, 7);
                randomIntelli = random.Next(3, 7);
                randomWisdom = random.Next(3, 7);
                randomSpeed = random.Next(2, 5);
                break;
            }
            case PlayerLevel.eLifeRank.Beginner: {
                while (randomLifeRankIndex != 0 || 
                       randomLifeRankIndex != 1 ||
                       randomLifeRankIndex != 2)
                    randomLifeRankIndex = (byte)random.Next(0, lifeRankList.Length);
                
                randomSkillLevel = (eLifeRank)randomLifeRankIndex;
                randomHealth = random.Next(15, 20) * randomLifeRankIndex;
                randomConsti = random.Next(5, 10) * randomLifeRankIndex;
                randomStreng = random.Next(5, 10) * randomLifeRankIndex;
                randomDext = random.Next(5, 10) * randomLifeRankIndex;
                randomIntelli = random.Next(5, 10) * randomLifeRankIndex;
                randomWisdom = random.Next(5, 10) * randomLifeRankIndex;
                randomSpeed = random.Next(3, 7) * randomLifeRankIndex;
                break;
            }
            case PlayerLevel.eLifeRank.Advanced: {
                
                break;
            }
            case PlayerLevel.eLifeRank.Elite: {
                
                break;
            }
            case PlayerLevel.eLifeRank.SpecialElite: {
                
                break;
            }
            case PlayerLevel.eLifeRank.StandardChieftain: {
                
                break;
            }
            case PlayerLevel.eLifeRank.HighChieftain: {
                
                break;
            }
            case PlayerLevel.eLifeRank.Lord: {
                
                break;
            }
            case PlayerLevel.eLifeRank.HighLord: {
                
                break;
            }
        }
        
        
        MonsterStats randMonster = new MonsterStats(
            randomSkillLevel, 
            randomHealth, 
            randomConsti, 
            randomStreng, 
            randomDext, 
            randomIntelli, 
            randomWisdom, 
            randomSpeed);
        
        return randMonster;
    }
    
    #region enum
    private eLifeRank LifeRank { get; set; }
    private int Hp { get; set; }
    private int Con { get; set; }
    private int Str { get; set; }
    private int Dex { get; set; }
    private int Intel { get; set; }
    private int Wis { get; set; }
    private int Spd { get; set; }
    #endregion
    
    public MonsterStats(eLifeRank lifeRank, int health, int constitution, int strength, int dexterity, int intelligence, int wisdom, int speed) {
        LifeRank = lifeRank;
        Hp = health;
        Con = constitution;
        Str = strength;
        Dex = dexterity;
        Intel = intelligence;
        Wis = wisdom;
        Spd = speed;
    }
    
    public int conMod() { return (int) (Con * 0.5); }

    public int strMod() { return (int) (Str * 0.5); }

    public int dexMod() { return (int) (Dex * 0.5); }

    public int intelMod() { return (int) (Intel * 0.5); }

    public int wisMod() { return (int) (Wis * 0.5); }
    
}