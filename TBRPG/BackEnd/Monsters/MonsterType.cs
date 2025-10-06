using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace TBRPG.BackEnd.Monsters;

public class MonsterType {
    
    public static MonsterType randomizedTypes() {
        Random random = new Random();
        var types = Enum.GetNames(typeof(eMonsterType));
        int randomTypeIndex = random.Next(0, types.Length);
        eMonsterType randomType = (eMonsterType)randomTypeIndex;
        string[] elements = ["Fire",  "Water", "Earth", "Wind", "Null"];

        eElement randomElement;
        
        switch (randomType)
        {
            case 0: {//Humanoid
                int randomElementIndex = random.Next(0, elements.Length);
                randomElement = (eElement)randomElementIndex;
                break;
            }
            case (eMonsterType)1: {//Feral
                int randomElementIndex = random.Next(0, elements.Length);
                while (randomElementIndex == 0) 
                    randomElementIndex = random.Next(0, elements.Length);
                randomElement = (eElement)randomElementIndex;
                break;
            }
            case (eMonsterType)2: {//Elemental
                int randomElementIndex = random.Next(0, elements.Length);
                while (randomElementIndex == 4)
                    randomElementIndex = random.Next(0, elements.Length);
                randomElement = (eElement)randomElementIndex;
                break;
            }
            case (eMonsterType)3: {//Flora
                int randomElementIndex = random.Next(0, elements.Length);
                while (randomElementIndex == 0 || randomElementIndex == 3 || randomElementIndex == 4)
                    randomElementIndex = random.Next(0, elements.Length);
                randomElement = (eElement)randomElementIndex;
                break;
            }
            case (eMonsterType)4: {//Undead
                int randomElementIndex = random.Next(0, elements.Length);
                while (randomElementIndex == 1)
                    randomElementIndex = random.Next(0, elements.Length);
                randomElement = (eElement)randomElementIndex;
                break;
            }
            case (eMonsterType)5: {//Draconic
                int randomElementIndex = random.Next(0, elements.Length);
                while (randomElementIndex == 4)
                    randomElementIndex = random.Next(0, elements.Length);
                randomElement = (eElement)randomElementIndex;
                break;
            }
            default:
                randomElement = (eElement)4;
                break;
        }

        MonsterType randMonster = new MonsterType((eMonsterType)randomTypeIndex, randomElement);
        return randMonster;
    }
    
    public enum eMonsterType {
        Humanoid,
        Feral,
        Elemental,
        Flora,
        Undead,
        Draconic,
        Abomination
    }
    public MonsterType(eMonsterType type, eElement element) {
        
    }
    public enum eElement {
        Fire,
        Water,
        Earth,
        Wind,
        Null
    }

    

    
} 