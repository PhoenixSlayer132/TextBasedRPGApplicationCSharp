namespace TBRPG.BackEnd.Profession;

public class Berserker {
    public void getProfession() {
        
    }

    public void setProfession() {
        
    }
    
    public void DirtyAllEnabledMoves()
    {
        ProfessionMoves.enableMoves(Player.Player.player.Profession);
    }
}
