using System.Diagnostics.CodeAnalysis;
using TBRPG.BackEnd.Leveling;
using TBRPG.BackEnd.Profession;

namespace TBRPG.BackEnd.Player;

public class Player {
    public enum eProfession {
        Archer,
        Mage,
        Berserker,
        Support
    }
    public PlayerLevel Level { get; set; }
    public PlayerStats Stats { get; set; }
    public string Name { get; set; }
    public static Player player = null!;
    
    public static void createPlayer() {
        Console.WriteLine("Please Enter Your Character's Name: ");
        string playerName = Console.ReadLine() ?? "Player";
        Console.WriteLine("player name is:_" + playerName + "_okay?");//////////////////////////////////////////////////////////////////
        
        Boolean boolProf = true;
        eProfession profession = eProfession.Archer;

        do {
            Console.WriteLine("Please Enter What Profession You Would Prefer? (Mage, Berserker, Archer, Support)");
            string professionChoice = Console.ReadLine()!;
            switch (professionChoice.ToLower()) {
                case "archer": {
                    profession = eProfession.Archer;
                    boolProf = false;
                    break;
                }
                case "mage": {
                    profession = eProfession.Mage;
                    boolProf = false;
                    break;
                }
                case "berserker": {
                    profession = eProfession.Berserker;
                    boolProf = false;
                    break;
                }
                case "support": {
                    profession = eProfession.Support;
                    boolProf = false;
                    break;
                }
                default: {
                    Console.WriteLine("You wrote:_"+professionChoice+"_okay?");///////////////////////////////////////////////////////////////////////////////////////
                    Console.WriteLine("Invalid Input.\nPlease Try Again.");
                    break;
                }
            } 
        } while (boolProf);

        player = new Player(
            playerName, 
            profession, 
            new PlayerLevel(0, 0.0f, PlayerLevel.eLifeRank.Tutorial), 
            new PlayerStats(20, 5, 5, 5, 5, 5, 3));

    }
    
    public Player(string name, eProfession profession, PlayerLevel level, PlayerStats stats) {
        Name = name;
        Level = level;
        Stats = stats;
    }
    
    
    
    
    
}