using System.Collections;
using System.Linq;
using Microsoft.VisualBasic.Devices;

namespace TBRPG.FrontEnd;

public partial class MainTBRPGWindow : Form
{
    
    public MainTBRPGWindow()
    {
        InitializeComponent();
    }

    private void MainTBRPGWindow_Load(object sender, EventArgs e)
    {
        MainTBRPGUserControl.MainUserControl = new MainTBRPGUserControl();
        Controls.Add(MainTBRPGUserControl.MainUserControl);
    }
    
}