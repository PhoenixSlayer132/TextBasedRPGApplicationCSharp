using TBRPG.BackEnd.CharacterFolder.PlayerFolder;
using TBRPG.BackEnd.Stats;

namespace TBRPG.BackEnd.Profession.Moves;

public class ProfessionMoves
{
    private Player.eProfession Profession { get; set; }
    private String Name;
    private byte Power;
    private byte Count;
    private String Description;
    private IStatModifier StatModifier1;
    private IStatModifier StatModifier2;
    public bool Enabled;
    public static List<ProfessionMoves> AllEnabledMoves = new();
    public static List<ProfessionMoves> AllMoves = new();

    
    
    public ProfessionMoves(Player.eProfession Profession, String Name, byte Power, String Description, bool Enabled)
    {
        this.Profession = Profession;
        this.Name = Name;
        this.Power = Power;
        this.Description = Description;
        this.Enabled = Enabled;
        
        AllMoves.Add(this);
    }

    public ProfessionMoves(Player.eProfession Profession, String Name, byte Power, byte Count, String Description, bool Enabled)
    {
        this.Profession = Profession;
        this.Name = Name;
        this.Power = Power;
        this.Count = Count;
        this.Description = Description;
        this.Enabled = Enabled;
        
        AllMoves.Add(this);

    }
    public ProfessionMoves(Player.eProfession Profession, String Name, byte Power, String Description,  IStatModifier StatModifier1, IStatModifier StatModifier2, bool Enabled)
    {
        this.Profession = Profession;
        this.Name = Name;
        this.Power = Power;
        this.Description = Description;
        this.StatModifier1 = StatModifier1;
        this.StatModifier2 = StatModifier2;
        this.Enabled = Enabled;
        
        AllMoves.Add(this);

    }
    public ProfessionMoves(Player.eProfession Profession, String Name, byte Power, String Description, IStatModifier StatModifier1, bool Enabled)
    {
        this.Profession = Profession;
        this.Name = Name;
        this.Power = Power;
        this.Description = Description;
        this.StatModifier1 = StatModifier1;
        this.Enabled = Enabled;
        
        AllMoves.Add(this);

    }
    public ProfessionMoves(Player.eProfession Profession, String Name, String Description, IStatModifier StatModifier1, IStatModifier StatModifier2, bool Enabled)
    {
        this.Profession = Profession;
        this.Name = Name;
        this.Description = Description;
        this.StatModifier1 = StatModifier1;
        this.StatModifier2 = StatModifier2;
        this.Enabled = Enabled;
        
        AllMoves.Add(this);

        
    }
    public ProfessionMoves(Player.eProfession Profession, String Name, String Description,  IStatModifier StatModifier1, bool Enabled)
    {
        this.Profession = Profession;
        this.Name = Name;
        this.Description = Description;
        this.StatModifier1 = StatModifier1;
        this.Enabled = Enabled;
        
        AllMoves.Add(this);

    }

    public void enableMove(ProfessionMoves professionMoves)
    {
        professionMoves.Enabled = true;
        AllEnabledMoves.Add(professionMoves);
    }

    public static void enableMoves(Player.eProfession profession)
    {
        AllMoves.ForEach(Move =>
        {
            if (Move.Profession.Equals(profession))
            {
                Move.Enabled = true;
                AllEnabledMoves.Add(Move);
            }
            else
            {
                Move.Enabled = false;
                AllEnabledMoves.Remove(Move);
            }
        } );
    }

    public void disableMove(ProfessionMoves professionMoves)
    {
        professionMoves.Enabled = false;
        AllEnabledMoves.Remove(professionMoves);
    }

    public static void disableMoves(Player.eProfession profession)
    {
        AllEnabledMoves.ForEach(Move =>
        {
            if (!Move.Profession.Equals(profession))
            {
                Move.Enabled = false;
                AllEnabledMoves.Remove(Move);
            }
        } );
    }
    public void createMoves()
    {
        switch (Profession)
        {
            case Player.eProfession.Archer:
            {
                ProfessionMoves TestMove = new ProfessionMoves(Player.eProfession.Archer,"Test Move", Player.player.Wis, "Test", true);
                
                ProfessionMoves BurstFire = new ProfessionMoves(Player.eProfession.Archer,"Burst Fire", Player.player.Str, 3,
                    "The User Burst Fires their bow shooting 3 times in one turn.", false);
                break;
            }
            case Player.eProfession.Berserker:
            {
                ProfessionMoves TestMove = new ProfessionMoves(Player.eProfession.Berserker,"Test Move", Player.player.Wis, "Test", true);
                
                break;
            }
            case Player.eProfession.Mage:
            {
                ProfessionMoves TestMove = new ProfessionMoves(Player.eProfession.Mage,"Test Move", Player.player.Wis, "Test", true);
                
                break;
            }
            case Player.eProfession.Support:
            {
                ProfessionMoves TestMove = new ProfessionMoves(Player.eProfession.Support,"Test Move", Player.player.Wis, "Test", true);
                
                break;
            }
            
                
        }
    }
    
}