namespace TBRPG.BackEnd.Profession;

public class Support {
    public void getProfession() {
        
    }

    public void setProfession() {
        
    }
    
    public void DirtyAllEnabledMoves()
    {
        ProfessionMoves.AllEnabledMoves = ProfessionMoves.AllMoves.Where(a => a.Enabled.Equals(true)).ToList();
    }
}