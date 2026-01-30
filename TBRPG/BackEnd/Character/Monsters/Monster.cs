using System.Runtime.CompilerServices;
using TBRPG.BackEnd.CharacterFolder.PlayerFolder;
using TBRPG.BackEnd.Gameplay;
using TBRPG.BackEnd.Stats;
using TBRPG.BackEnd.TextBox;

namespace TBRPG.BackEnd.CharacterFolder.Monsters;

public class Monster : Character {
    static Random rand = new Random();
    public override string? Name { get; set; }
    public override bool Defending { get; set; }
    private bool Glanced = false;
    private bool Observed = false;

    public byte Level { get; set; }
    public MonsterType Type { get; set; }
    public MonsterStats Stats { get; set; }

    public static Monster monster;
    public static List<Monster> monsters = new List<Monster>();
    public static List<Monster> deadMonsters = new List<Monster>();
    
    
    private const byte DEBUFFED_TRAIT_SUBTRACTION = 1;
    
    public Monster(string name, byte level, MonsterType type, MonsterStats stats) {
        Name = name;
        Level = level;
        Type = type;
        
        Hp = stats.Hp;
        CurrentHp = stats.CurrentHp;
        Str = stats.Str;
        Con = stats.Con;
        Dex = stats.Dex;
        Intel = stats.Intel;
        Wis = stats.Wis;
        Spd = stats.Spd;
        
        Stats = stats;
    }
    

    public static Monster createMonster()
    {
        string randName = "\"N U L L\"";
        MonsterType randType = MonsterType.randomizedTypes();

        switch (randType.Type)
        {
            case MonsterType.eMonsterType.Humanoid:
            {
                randName = MonsterType.HumanoidNames[rand.Next(0, MonsterType.HumanoidNames.Count)];
                break;
            }
            case MonsterType.eMonsterType.Feral:
            {
                randName = MonsterType.FeralNames[rand.Next(0, MonsterType.FeralNames.Count)];
                break;
            }
            case MonsterType.eMonsterType.Elemental:
            {
                randName = MonsterType.ElementalNames[rand.Next(0, MonsterType.ElementalNames.Count)];
                break;
            }
            case MonsterType.eMonsterType.Flora:
            {
                randName = MonsterType.FloraNames[rand.Next(0, MonsterType.FloraNames.Count)];
                break;
            }
            case MonsterType.eMonsterType.Undead:
            {
                randName = MonsterType.UndeadNames[rand.Next(0, MonsterType.UndeadNames.Count)];
                break;
            }
            case MonsterType.eMonsterType.Draconic:
            {
                randName = MonsterType.DraconicNames[rand.Next(0, MonsterType.DraconicNames.Count)];
                break;
            }
            case MonsterType.eMonsterType.Abomination:
            {
                randName = MonsterType.AbominationNames[rand.Next(0, MonsterType.AbominationNames.Count)];
                break;
            }
        }

        byte randLevel = (byte)rand.Next(1, 4);
        monster = new Monster(randName, randLevel, randType, MonsterStats.randomizedStats()); 
        return monster;
    }

    public async Task Turn()
    {
        bool monstTurn = true;
        while (monstTurn)
        {
            byte choice;

            if (Glanced) choice = (byte)rand.Next(1, 4);
            else if (Observed) choice = (byte)rand.Next(1, 3);
            else choice = (byte)rand.Next(1, 5);
            

            switch (choice)
            {
                case 1: // Attack
                {
                    if ((!Glanced && !Observed) ||
                        (Glanced && Player.player.CurrentHp >= (Player.player.Hp / 3) && (byte)rand.Next(1, 5) % 2 == 0) ||
                        (Observed && Player.player.CurrentHp >= (Player.player.Hp / 3) && (byte)rand.Next(1, 11) >= 3))
                    {
                        await MainTextBox.AppendText($"{this.Name} chose to attack!");
                        await Attack(Player.player);
                        Glanced = false;
                        Observed = false;
                    }
                    else
                    {
                        await Defend();
                        Glanced = false;
                        Observed = false;
                    }

                    monstTurn = false;
                    break;
                }
                case 2: // Defend
                {
                    if ((!Glanced && !Observed) ||
                        (Glanced && Player.player.CurrentHp >= (Player.player.Hp / 3) && (byte)rand.Next(1, 5) % 2 == 0) ||
                        (Observed && Player.player.CurrentHp >= (Player.player.Hp / 3) && (byte)rand.Next(1, 11) <= 3))
                    {
                        await Defend();
                        Glanced = false;
                        Observed = false;
                    }
                    else
                    {
                        await MainTextBox.AppendText($"{this.Name} chose to attack!");
                        await Attack(Player.player);
                        Glanced = false;
                        Observed = false;
                    }

                    monstTurn = false;
                    break;
                }
                case 3: // Observe
                {
                    await MainTextBox.AppendText($"{this.Name} is Observing {Player.player.Name}...");
                    await Observe(Player.player);
                    monstTurn = false;
                    break;
                }
                case 4: // Glance
                {
                    await MainTextBox.AppendText($"{this.Name} took a glance at {Player.player.Name}'s condition...");
                    await Glance(Player.player);
                    break;
                }
            }
        }
    }

    public override Task Observe(Character target)
    {
        Observed = true;
        return Task.CompletedTask;
    }

    public override Task Glance(Character target)
    {
        Glanced = true;
        return Task.CompletedTask;
    }
    
    public override async Task Death()
    {
        Player.player.inBattle = false;
        Battle.turnCounter = 1;
        
        await MainTextBox.AppendText($"Great! You killed {Name}!\nWant to continue exploring? (Yes/No)");
        string? ans = await MainTextBox.WaitForUserInputAsync();
        if (ans != null)
        {
            ans = ans.Trim().ToLower();
            switch (ans)
            {
                case "yes" or "y":
                    await Battle.NewEncounter(); break;
                case "no" or "n":
                    Application.Exit(); break;
            }
        }

    }

    public static List<Monster> createMonsters(byte amt)
    {
        
        for (int i = 0; i < amt; i++)
            monsters.Add(createMonster());
        
        return monsters;
    }
    
    
    public override string BasicInfo()
    {
        return "[-----------Glance-----------]\n" +
               $"[ Type: {Type.Type.ToString()}]\n" +
               $"[ Element: {Type.Element.ToString()}]\n" +
               "[----------------------------]\n" +
               $"[ HP: {CurrentHp}/{Hp}]\n" +
               "[----------------------------]\n";
    }
    
    public override string ToString()
    {
        return "\n[------------INFO------------]\n" +
               $"[ Name: {Name}]\n" +
               $"[ Level: {Level}]\n" +
               $"[ Type: {Type.Type.ToString()}]\n" +
               $"[ Element: {Type.Element.ToString()}]\n" +
               "[----------------------------]\n" +
               $"[ HP: {CurrentHp}/{Hp}]\n" +
               $"[ Constitution: {Con}]\n" +
               $"[ Strength: {Str}]\n" +
               $"[ Dexterity: {Dex}]\n" +
               $"[ Intelligence: {Intel}]\n" +
               $"[ Wisdom: {Wis}]\n" +
               $"[ Speed: {Spd}]\n" +
               "[----------------------------]\n";
    }
}