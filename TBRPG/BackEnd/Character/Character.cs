using System.Text;
using TBRPG.BackEnd.CharacterFolder.Monsters;
using TBRPG.BackEnd.CharacterFolder.PlayerFolder;
using TBRPG.BackEnd.TextBox;
using TBRPG.BackEnd.TextFormats;

namespace TBRPG.BackEnd.CharacterFolder;

public abstract class Character : CharacterStats
{
    public abstract string? Name { get; set; }
    public abstract bool Defending { get; set; }
    
    private const byte BASE_CON = 5;
    private const byte BASE_STR = 5;
    private const byte BASE_DEX = 5;
    private const byte BASE_INTEL = 5;
    private const byte BASE_WIS = 5;
    private const byte BASE_SPD = 3;

    private const byte MAJOR_TRAIT_ADDITION = 2;
    private const byte MINOR_TRAIT_ADDITION = 1;
    private const byte DEBUFFED_TRAIT_SUBTRACTION = 1;
    
    // public static List<MovePool> CharacterMovePool;
    
    // alter damage conditions to allow for class damage type
    //
    //    ---- Player -----
    // Class        - Major Trait,    Minor Trait
    // Mage         - Intelligence,   Wisdom
    // Berserker    - Strength,       Constitution
    // Archer       - Dexterity,      Speed
    // Support      - Constitution,   Intelligence
    //
    //    ---- Monster ----
    // Type         - Major Trait,    Minor Trait   : Debuffed Trait
    // Humanoid     - Intelligence,   Dexterity     : Constitution
    // Feral        - Strength,       Dexterity     : Intelligence
    // Elemental    - Intelligence,   Wisdom        : Constitution
    // Flora        - Wisdom,         Dexterity     : Speed
    // Undead       - Constitution,   Strength      : Wisdom
    // Draconic     - Constitution,   Wisdom        : Speed
    // Abomination  - Strength,       Constitution  : Intelligence
    // 
    
    public virtual async Task Attack(Character target)
    {
        Character user = this;

        if (!target.Defending)
        {
            if (user.Str > target.Con)
            {
                Console.WriteLine($"{user.Name} str = {user.Str}\n{target.Name} con = {target.Con}");
                target.CurrentHp -= user.Str;
                await TextFormat.DamageIndicator(
                    target.Name, user.Str, 
                    null, null, 
                    await IsThereDeath(user, target));
            }
            else if (user.Str < target.Con)
            {
                Console.WriteLine($"{user.Name} str = {user.Str}\n{target.Name} con = {target.Con}");
                byte damageGuess = (byte)(user.Str  - (target.Con  / 2));
                damageGuess = (byte)((damageGuess >= 1) ? damageGuess : 1);
                target.CurrentHp -= damageGuess;
            
                await TextFormat.DamageIndicator(
                    target.Name, damageGuess, 
                    null, null, 
                    await IsThereDeath(user, target));
            }
            else
            {
                Console.WriteLine($"{user.Name} str = {user.Str}\n{target.Name} con = {target.Con}");
                byte damageGuessTarget = (byte)(user.Str  / 1.5);
                damageGuessTarget = (byte)((damageGuessTarget >= 1) ? damageGuessTarget : 1);
                target.CurrentHp -= damageGuessTarget;
            
                byte damageGuessUser = (byte)(target.Str / 2);
                damageGuessUser = (byte)((damageGuessUser >= 1) ? damageGuessUser : 1);
                user.CurrentHp -= damageGuessUser;
            
                await TextFormat.DamageIndicator(
                    target.Name, damageGuessTarget, 
                    user.Name, damageGuessUser, 
                    await IsThereDeath(user, target));
            }
        }
        else
        { 
            if (user.Str > target.Con)
            {
                Console.WriteLine($"{user.Name} str = {user.Str}\n{target.Name} con = {target.Con}");
                target.CurrentHp -= (byte)(user.Str / 1.5);
                await TextFormat.DamageIndicator(
                    target.Name, user.Str, 
                    null, null, 
                    await IsThereDeath(user, target));
            }
            else if (user.Str < target.Con)
            {
                Console.WriteLine($"{user.Name} str = {user.Str}\n{target.Name} con = {target.Con}");
                byte damageGuess = 1;
                target.CurrentHp -= damageGuess;
            
                await TextFormat.DamageIndicator(
                    target.Name, damageGuess, 
                    null, null, 
                    await IsThereDeath(user, target));
            }
            else
            {
                Console.WriteLine($"{user.Name} str = {user.Str}\n{target.Name} con = {target.Con}");
                byte damageGuessTarget = (byte)(user.Str  - (target.Con  / 2));
                damageGuessTarget = (byte)((damageGuessTarget >= 1) ? damageGuessTarget : 1);
                target.CurrentHp -= damageGuessTarget;
            
                byte damageGuessUser = (byte)(target.Str  - (user.Con  / 1.5));
                damageGuessUser = (byte)((damageGuessUser >= 1) ? damageGuessUser : 1);
                user.CurrentHp -= damageGuessUser;
            
                await TextFormat.DamageIndicator(
                    target.Name, damageGuessTarget, 
                    user.Name, damageGuessUser, 
                    await IsThereDeath(user, target));
            }
        }
        
        
    }
    
    public virtual async Task Defend()
    {
        Character user = this;
        user.Defending = true;
        
        await MainTextBox.AppendText($"{user.Name} is defending!");
    }
    

    private async Task<(Character?[], bool)> IsThereDeath(Character user, Character target)
    {
        Character?[] DeadCharacters = new Character?[2];
        bool Dead = false;
        
        await Task.Run(() =>
        {
        
            Console.WriteLine($"{user.Name} currentHp = {user.CurrentHp}\n{target.Name} currentHp = {target.CurrentHp}");
            switch (user.CurrentHp)
            {
                case <= 0 when target.CurrentHp <= 0:
                    Dead = true;
                    DeadCharacters.SetValue(user, 0);
                    DeadCharacters.SetValue(target, 1);
                    break;
                case <= 0:
                    Dead = true;
                    DeadCharacters.SetValue(user, 0);
                    break;
                default:
                {
                    if (target.CurrentHp <= 0)
                    {
                        Dead = true;
                        DeadCharacters.SetValue(target, 0);
                    }

                    break;
                }
            }
        });
        return (DeadCharacters, Dead);
    }

    public abstract Task Death();

    public static bool IsPlayer(Character character)
    {
        try
        {
            Player charc = (Player) character;
            return charc is not null;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    public virtual async Task Observe(Character target)
    {
        await MainTextBox.AppendText(target.ToString());
    }

    public virtual async Task Glance(Character target)
    {
        await MainTextBox.AppendText(target.BasicInfo());
    }

    public abstract string BasicInfo();
}