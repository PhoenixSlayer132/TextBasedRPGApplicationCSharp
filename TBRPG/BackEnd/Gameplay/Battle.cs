using TBRPG.BackEnd.CharacterFolder.Monsters;
using TBRPG.BackEnd.CharacterFolder.PlayerFolder;
using TBRPG.BackEnd.Debug;
using TBRPG.BackEnd.TextBox;

namespace TBRPG.BackEnd.Gameplay;

public class Battle
{
    public static int turnCounter = 1;
    static Random rand =  new Random();
    public static async Task NewEncounter()
    {

        await Adventure.StartEncounterFind();

        var initiativeOrder = checkInitiative();
        string? resp;
        
        // triple loop X
        // Look into Data Structure
        
        // While the characters in the initiative order are alive 
        //   loop through the order and allow the character to do their action
        //     if the character is a player ask for user input for a valid command
        //     else make the monster character do a randomized action
        //     when any character dies; break out of loop and use character death method
        
        /*
         * 
         */
        
        while (Player.player.inBattle) // to allow the initiative order to restart
        {
            if (turnCounter != 1)
                await MainTextBox.AppendText($"Turn {turnCounter}:");
            foreach (var character in initiativeOrder)
            {
                if (CharacterFolder.Character.IsPlayer(character))
                {
                    while (true) // incase the user gives an invalid input or utilizes anytime Commands
                    {
                        Console.WriteLine(Player.player.inBattle);

                        await MainTextBox.AppendText("What would you like to do?\n" +
                                         "Attack\tDefend\n" +
                                         "Observe\tGlance");
                        
                        resp = await MainTextBox.WaitForUserInputAsync();
                        if (MainTextBox.anyTimeCommandsAllowed.Contains(resp))
                            continue;
                        break;
                    }
                }
                else
                {
                    await Monster.monster.Turn();
                }
            }
            turnCounter++;
        }
    }


    static CharacterFolder.Character[] checkInitiative()
    {
        Player.player.inBattle = true;
        CharacterFolder.Character?[] order = new CharacterFolder.Character?[2];
        if (Monster.monster.Spd > Player.player.Spd)
        {
            order.SetValue(Monster.monster, 0);
            order.SetValue(Player.player, 1);
        }
        else if (Monster.monster.Spd < Player.player.Spd)
        {
            order.SetValue(Player.player, 0);
            order.SetValue(Monster.monster, 1);
        }
        else if (Monster.monster.Dex > Player.player.Dex)
        {
            order.SetValue(Monster.monster, 0);
            order.SetValue(Player.player, 1);
        }
        else if (Monster.monster.Dex < Player.player.Dex)
        {
            order.SetValue(Player.player, 0);
            order.SetValue(Monster.monster, 1);
        }
        else
        {
            byte val = (byte)rand.Next(0, 2);
            order.SetValue(Player.player, val);
            order.SetValue(Monster.monster, val == 0 ? 1 : 0);
        }
        return order!;
    }
}