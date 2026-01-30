using TBRPG.BackEnd.CharacterFolder.Monsters;
using TBRPG.BackEnd.CharacterFolder.PlayerFolder;
using TBRPG.BackEnd.TextBox;
using TBRPG.BackEnd.TextFormats;
using TBRPG.BackEnd.Leveling;

namespace TBRPG.BackEnd.Gameplay;

public class Adventure
{
    private static Random rand = new Random();
    
    public static async Task StartAdventure()
    {
        await MainTextBox.AppendText("Please Enter Your Character's Name: ");
        string playerName = await MainTextBox.WaitForUserInputAsync() ?? "Player";
        await MainTextBox.AppendText($"Welcome {{{playerName}}}!");
        Console.WriteLine("player name is:_" + playerName + "_okay?");//////////////////////////////////////////////////////////////////
        
        Boolean boolProf = true;
        Player.eProfession profession = Player.eProfession.Archer;

        do
        {
            await Task.Delay(2000);
            await MainTextBox.AppendText("Please Enter What Profession You Would Prefer?\n(Mage, Berserker, Archer, Support): ");
            string professionChoice = await MainTextBox.WaitForUserInputAsync() ?? "Null";
            Console.WriteLine(professionChoice);
            
            switch (professionChoice.ToLower().Trim()) {
                
                case "archer" or "arch" or "a": {
                    await MainTextBox.AppendText("{Archer} Chosen!");
                    profession = Player.eProfession.Archer;
                    boolProf = false;
                    break;
                }
                case "mage" or "m": {
                    await MainTextBox.AppendText("{Mage} Chosen!");
                    profession = Player.eProfession.Mage;
                    boolProf = false;
                    break;
                }
                case "berserker" or "bers" or "b": {
                    await MainTextBox.AppendText("{Berserker} Chosen!");
                    profession = Player.eProfession.Berserker;
                    boolProf = false;
                    break;
                }
                case "support" or "sup" or "s": {
                    await MainTextBox.AppendText("{Support} Chosen!");
                    profession = Player.eProfession.Support;
                    boolProf = false;
                    break;
                }
                default: {
                    Console.WriteLine("You wrote:_"+professionChoice+"_okay?");///////////////////////////////////////////////////////////////////////////////////////
                    await MainTextBox.AppendText("Invalid Input.\nPlease Try Again.");
                    break;
                }
            } 
            
            await Task.Delay(2000);
        } while (boolProf);
        
        Player.createPlayer(playerName, profession);
        await MainTextBox.AppendText(Player.player.ToString());
        await MainTextBox.AppendText("\nYou can recheck your player stats by doing `/Stats` in combat!");
        
        
        await Battle.NewEncounter();
        
        
        
    }

    public static async Task StartEncounterFind() /////////////////////// Rework System
    {
        Monster.monster = Monster.createMonster();

        await MainTextBox.AppendText("Lets walk around the forest!\nMhhh.. What will we find today?");

        byte num;
        do
        {
            num = (byte)rand.Next(1, 11);
            await MainTextBox.TextAnim(new []{"Sear", "ching", ".", ".", ".\n"}, 500);
            if (num <= 3) await MainTextBox.AppendText("Found Nothing..\nLets try again!");
        } while (num <= 3);

        await MainTextBox.AppendText("A monster has appeared!\n" + Monster.monster);
    }
}