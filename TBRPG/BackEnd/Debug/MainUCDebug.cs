using TBRPG.BackEnd.CharacterFolder.Monsters;
using TBRPG.BackEnd.Gameplay;
using TBRPG.BackEnd.TextBox;

namespace TBRPG.BackEnd.Debug;

public class MainUCDebug
{

    public static bool IsNull(Object obj)
    {
        bool boolean;

        try
        {
            boolean = obj.Equals(null);
        }
        catch (NullReferenceException nre)
        {
            boolean = true;
        }
        
        return boolean;
    }
    public static async void CheckMonsterGeneration()
    {
        Monster.monster = Monster.createMonster();

        await Adventure.StartEncounterFind();
        var resp = await MainTextBox.WaitForUserInputAsync();
        do
        {
            if (resp.Equals("a") || resp.Equals("again"))
            {
                await Adventure.StartEncounterFind();
                
                resp = await MainTextBox.WaitForUserInputAsync();
            }
        } while (!resp.Equals("end") || !resp.Equals("e"));
    }
}