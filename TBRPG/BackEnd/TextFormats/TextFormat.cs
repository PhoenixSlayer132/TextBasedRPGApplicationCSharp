using System.Text;
using TBRPG.BackEnd.CharacterFolder.PlayerFolder;
using TBRPG.BackEnd.CharacterFolder.Monsters;
using TBRPG.BackEnd.TextBox;

namespace TBRPG.BackEnd.TextFormats;

public class TextFormat
{
    public string LevelUp =
        "[----------Level-Up----------]\n" +
        $"[ Player: {Player.player.Name}]\n" +
        $"[ Level: {Player.player.Level.Level}]\n"+
        $"[ Profession: {Player.player.Profession}]\n" +
        "[----------------------------]\n" +
        $"[ HP: {Player.player.Hp}/{Player.player.Hp}]\n" +
        $"[ Constitution: {Player.player.Con}]\n" +
        $"[ Strength: {Player.player.Str}]\n" +
        $"[ Dexterity: {Player.player.Dex}]\n" +
        $"[ Intelligence: {Player.player.Intel}]\n" +
        $"[ Wisdom: {Player.player.Wis}]\n" +
        $"[ Speed: {Player.player.Spd}]\n" +
        "[----------------------------]";

    public string PlayerDeath = $"{Player.player.Name} died!";

    public static async Task DamageIndicator
        (string character1, byte? damage1, 
        string? character2, byte? damage2, 
        (CharacterFolder.Character?[], bool) deathList)
    {
        StringBuilder builder = new StringBuilder();
        var charList = deathList.Item1;
        var death = deathList.Item2;
        var checkPlayerDeath = (bool, CharacterFolder.Character?) () =>
        {
            if (!death || (charList.Equals(null)))
            {
                Console.WriteLine("Returning Null for charlist in check player death! 000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
                return (false, null);
            }
            foreach (var character in charList)
            {
                if (CharacterFolder.Character.IsPlayer(character))
                {
                    return (true, character);
                }
            }
            return (false, null);
        };
        var checkMonsterDeath = async Task () =>
        {
            if (!death || (charList.Equals(null))) return;
            foreach (var character in charList)
            {
                if (CharacterFolder.Character.IsPlayer(character)) continue;
                builder.AppendLine($"\n{character.Name} took fatal Damage!");
                await MainTextBox.AppendText(builder.ToString());
                await character.Death();
            }
        };
        
        if (damage1.HasValue && damage2.HasValue)
        {
            builder.AppendLine($"{character1} took {damage1.Value} damage!\n{character2} took {damage2.Value} damage!");

            var player = checkPlayerDeath.Invoke();
            if (player.Item1)
            {
                builder.AppendLine($"\nOh no! {player.Item2.Name} took fatal Damage!");
                await MainTextBox.AppendText(builder.ToString());
                await player.Item2.Death();

            }
            else
                await checkMonsterDeath.Invoke();
        }
        else if (damage1.HasValue)
        {
            builder.AppendLine($"{character1} took {damage1.Value} damage!");
            
            var player = checkPlayerDeath.Invoke();
            if (player.Item1)
            {
                builder.AppendLine($"\nOh no! {player.Item2.Name} took fatal Damage!");
                await MainTextBox.AppendText(builder.ToString());
                await player.Item2.Death();

            }
            else
                await checkMonsterDeath.Invoke();
        }
        else if (damage2.HasValue)
        {
            builder.AppendLine($"{character2} took {damage2.Value} damage!");
            
            var player = checkPlayerDeath.Invoke();
            if (player.Item1)
            {
                builder.AppendLine($"\nOh no! {player.Item2.Name} took fatal Damage!");
                await MainTextBox.AppendText(builder.ToString());
                await player.Item2.Death();
            }
            else
                await checkMonsterDeath.Invoke();
        }
        await MainTextBox.AppendText(builder.ToString());
    }

    


}