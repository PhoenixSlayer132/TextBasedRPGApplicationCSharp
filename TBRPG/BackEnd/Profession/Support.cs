namespace TBRPG.BackEnd.Profession;

public class Support {
    public void getProfession() {
        
    }

    public void setProfession() {
        
    }
    
    public void DirtyAllEnabledMoves()
    {
        ProfessionMoves.enableMoves(Player.Player.player.Profession);
    }
}