namespace TBRPG.BackEnd.CharacterFolder.Monsters;

public class MonsterType {
    public eMonsterType Type { get; set; }
    public eElement Element { get; set; }
    
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

    public static List<string> HumanoidNames = new List<string>
    {
        "Carl",
        "Orc",
        "Goblin"
    };
    public static List<string> FeralNames = new List<string>
    {
        "Wolf",
        "Chicken",
        "Vulture"
    };
    public static List<string> ElementalNames = new List<string>
    {
        $"Elemental"
    };
    public static List<string> FloraNames = new List<string>
    {
        "Rose",
        "Thorn",
        "Blossom",
        "Blade"
    };
    public static List<string> UndeadNames = new List<string>
    {
        "Skeleton",
        "Lich",
        "Zombie"
    };
    public static List<string> DraconicNames = new List<string>
    {
        "Dragon",
        "Wyvern",
        "Drake"
    };
    public static List<string> AbominationNames = new List<string>
    {
        "Griffin",
        "Homunculus",
        "Experiment"
    };
    
    public MonsterType(eMonsterType type, eElement element)
    {
        Type = type;
        Element = element;
    }
    public enum eElement {
        Fire,
        Water,
        Earth,
        Wind,
        Null
    }

    

    
} 