using TBRPG.FrontEnd;
using TBRPG.BackEnd;
using TBRPG.BackEnd.Leveling;
using TBRPG.BackEnd.Player;

namespace TBRPG;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {

        
        
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        Application.Run(new MainTBRPGWindow());
        //Player.createPlayer();
    }
}