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
        Pen pen = new Pen(Color.White, 3);
        var graphics = CreateGraphics();
        
        graphics.DrawLine(pen, 50, 70, 160, 220);
        
    }
    
    
}