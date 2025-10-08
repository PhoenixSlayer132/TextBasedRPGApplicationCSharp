using TBRPG.BackEnd.Stats;
namespace TBRPG.BackEnd.Profession;

public class ProfessionMoves
{
    private Player.Player.eProfession Profession { get; set; }
    private String Name;
    private byte Power;
    private byte Count;
    private String Description;
    private IStatModifier StatModifier1;
    private IStatModifier StatModifier2;
    public bool Enabled;
    public static List<ProfessionMoves> AllEnabledMoves = new();
    public static List<ProfessionMoves> AllMoves = new();

    
    
    public ProfessionMoves(Player.Player.eProfession Profession, String Name, byte Power, String Description, bool Enabled)
    {
        this.Profession = Profession;
        this.Name = Name;
        this.Power = Power;
        this.Description = Description;
        this.Enabled = Enabled;
    }

    public ProfessionMoves(Player.Player.eProfession Profession, String Name, byte Power, byte Count, String Description, bool Enabled)
    {
        this.Profession = Profession;
        this.Name = Name;
        this.Power = Power;
        this.Count = Count;
        this.Description = Description;
        this.Enabled = Enabled;
    }
    public ProfessionMoves(Player.Player.eProfession Profession, String Name, byte Power, String Description,  IStatModifier StatModifier1, IStatModifier StatModifier2, bool Enabled)
    {
        this.Profession = Profession;
        this.Name = Name;
        this.Power = Power;
        this.Description = Description;
        this.StatModifier1 = StatModifier1;
        this.StatModifier2 = StatModifier2;
        this.Enabled = Enabled;
    }
    public ProfessionMoves(Player.Player.eProfession Profession, String Name, byte Power, String Description, IStatModifier StatModifier1, bool Enabled)
    {
        this.Profession = Profession;
        this.Name = Name;
        this.Power = Power;
        this.Description = Description;
        this.StatModifier1 = StatModifier1;
        this.Enabled = Enabled;
    }
    public ProfessionMoves(Player.Player.eProfession Profession, String Name, String Description, IStatModifier StatModifier1, IStatModifier StatModifier2, bool Enabled)
    {
        this.Profession = Profession;
        this.Name = Name;
        this.Description = Description;
        this.StatModifier1 = StatModifier1;
        this.StatModifier2 = StatModifier2;
        this.Enabled = Enabled;
    }
    public ProfessionMoves(Player.Player.eProfession Profession, String Name, String Description,  IStatModifier StatModifier1, bool Enabled)
    {
        this.Profession = Profession;
        this.Name = Name;
        this.Description = Description;
        this.StatModifier1 = StatModifier1;
        this.Enabled = Enabled;
    }

    public void createMoves()
    {
        switch (Profession)
        {
            case Player.Player.eProfession.Archer:
            {
                ProfessionMoves TestMove = new ProfessionMoves(Player.Player.eProfession.Archer,"Test Move", Player.Player.player.Stats.Wis, "Test", true);
                
                ProfessionMoves BurstFire = new ProfessionMoves(Player.Player.eProfession.Archer,"Burst Fire", Player.Player.player.Stats.Str, 3,
                    "The User Burst Fires their bow shooting 3 times in one turn.", false);
                break;
            }
            case Player.Player.eProfession.Berserker:
            {
                ProfessionMoves TestMove = new ProfessionMoves(Player.Player.eProfession.Berserker,"Test Move", Player.Player.player.Stats.Wis, "Test", true);
                
                break;
            }
            case Player.Player.eProfession.Mage:
            {
                ProfessionMoves TestMove = new ProfessionMoves(Player.Player.eProfession.Mage,"Test Move", Player.Player.player.Stats.Wis, "Test", true);
                
                break;
            }
            case Player.Player.eProfession.Support:
            {
                ProfessionMoves TestMove = new ProfessionMoves(Player.Player.eProfession.Support,"Test Move", Player.Player.player.Stats.Wis, "Test", true);
                
                break;
            }
            
                
        }
    }
    
}