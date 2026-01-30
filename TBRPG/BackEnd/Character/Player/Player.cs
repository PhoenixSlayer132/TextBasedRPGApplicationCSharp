using TBRPG.BackEnd.Gameplay;
using TBRPG.BackEnd.Leveling;
using TBRPG.BackEnd.Map;
using TBRPG.BackEnd.Stats;
using TBRPG.BackEnd.TextBox;

namespace TBRPG.BackEnd.CharacterFolder.PlayerFolder;

public class Player : Character{
    public enum eProfession {
        Archer,
        Mage,
        Berserker,
        Support
    }
    
    public PlayerLevel Level { get; set; }
    public PlayerStats Stats { get; set; }
    public eProfession Profession { get; set; }
    public override string? Name { get; set; }
    public override bool Defending { get; set; }
    
    public static PlayerPosition Position { get; set; }
    public bool inBattle { get; set; }
    
    // Default Player
    public static Player player = new (
        "Player", 
        eProfession.Archer, 
        new PlayerLevel(
            0, 0.0f, PlayerLevel.eLifeRank.Tutorial), 
        new PlayerStats(
            5, 1, 1, 1, 1, 1, 1));
    
    public static void createPlayer(string playerName, eProfession profession) {

        player = new Player(
            playerName, 
            profession, 
            new PlayerLevel(0, 0.0f, PlayerLevel.eLifeRank.Tutorial), 
            new PlayerStats(20, 5, 5, 5, 5, 5, 3));
        player.inBattle = false;
        // Position.step = 0;
        // Position.lane = InstanceMap.eLanes.Middle;
    }
    
    public Player(string name, eProfession profession, PlayerLevel level, PlayerStats stats) {
        Name = name;
        Profession = profession;
        Level = level;
        
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

    public override async Task Death()
    {
        inBattle = false;
        Battle.turnCounter = 1;
        await MainTextBox.AppendText($"Looks like {Name} has perished!\nWould you like to try again? (Yes/No)");
        string? ans = await MainTextBox.WaitForUserInputAsync();
        if (ans != null)
        {
            ans = ans.Trim().ToLower();
            switch (ans)
            {
                case "yes" or "y":
                    await Adventure.StartAdventure(); break;
                case "no" or "n":
                    Application.Exit(); break;
            }
        }

    }

    public override string BasicInfo()
    {
        return player.Hp.ToString();
    }

    public string GlanceSelf()
    {
        return "\n[------------SELF------------]\n" +
               $"[ Player: {Name}]\n" +
               $"[ Level: {Level.Level}]\n"+
               $"[ Profession: {Profession}]\n" +
               "[----------------------------]\n" +
               $"[ HP: {CurrentHp}/{Hp}]\n" +
               "[----------------------------]";
    }

    public override string ToString()
    {
        return "\n[------------INFO------------]\n" +
               $"[ Player: {Name}]\n" +
               $"[ Level: {Level.Level}]\n"+
               $"[ Profession: {Profession}]\n" +
               "[----------------------------]\n" +
               $"[ HP: {CurrentHp}/{Hp}]\n" +
               $"[ Constitution: {Con}]\n" +
               $"[ Strength: {Str}]\n" +
               $"[ Dexterity: {Dex}]\n" +
               $"[ Intelligence: {Intel}]\n" +
               $"[ Wisdom: {Wis}]\n" +
               $"[ Speed: {Spd}]\n" +
               "[----------------------------]";
    }
}