namespace TBRPG.FrontEnd;

public partial class MapTBRPGUserControl : UserControl
{
    private MapTBRPGUserControl MapUserControl = MainTBRPGUserControl.MapUserControl;
    public MapTBRPGUserControl()
    {
        InitializeComponent();
    }
    
    private void MapUserControl_Load(object sender, EventArgs e)
    {
        MapUserControl.Visible = true;
        MapUserControl.Show();
        Controls.Add(MainTBRPGUserControl.MapUserControl);
    }
    private void MapUserControl_Paint(object sender, PaintEventArgs pe)
    {
        
    }
    
    
}