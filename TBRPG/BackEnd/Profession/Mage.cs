using TBRPG.BackEnd.CharacterFolder.PlayerFolder;
using TBRPG.BackEnd.Profession.Moves;

namespace TBRPG.BackEnd.Profession;

public class Mage {
    public void getProfession() {
        
    }

    public void setProfession() {
        
    }
    
    public void DirtyAllEnabledMoves()
    {
        ProfessionMoves.enableMoves(Player.player.Profession);
    }
}