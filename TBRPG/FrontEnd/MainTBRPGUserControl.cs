using System.Diagnostics;
using TBRPG.BackEnd.Gameplay;
using TBRPG.BackEnd.TextBox;
using TBRPG.BackEnd.TextFormats;
using TBRPG.BackEnd.Leveling;

namespace TBRPG.FrontEnd;

public partial class MainTBRPGUserControl : UserControl
{
    public static HashSet<string> allowed = new(StringComparer.OrdinalIgnoreCase) 
    {
        "attack", "a", "defend", "d", "observe", "o", "/stats", "/s", "/map", "/m", "/g", "/glance", "glance", "g"
    };
    
    private readonly MainTextBox mainTextBox;
    static List<string> previousValidInputs = [];
    static byte inputIndex = 0;
    public static MapTBRPGUserControl MapUserControl = new();
    public static MainTBRPGUserControl MainUserControl;
    
    
    
    public MainTBRPGUserControl()
    {
        InitializeComponent();
        mainTextBox = new MainTextBox(rchtxtbxMainOutPut);
        
        // TBD Battle Scene
    }
    
    private async void MainTBRPGUserControl_Load(object sender, EventArgs e)
    {
        MainUserControl.Visible = true;
        MainUserControl.Show();

        await Adventure.StartAdventure();
    }

    private void txtbxInputBox_TextChanged(object sender, EventArgs e)
    {
        Console.WriteLine("txtbxInputBox_TextChanged");
    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
        if (txtbxInputBox.Text is "" or null) return;
        MainTextBox.txt = txtbxInputBox.Text.ToLower();
        Console.WriteLine("txtbxInputBox_Enter");
        txtbxInputBox.Clear();
        Console.WriteLine(MainTextBox.txt);
        previousValidInputs.Add(MainTextBox.txt);
        previousValidInputs.ForEach(Console.WriteLine);
        inputIndex = 0;
        if (previousValidInputs.Count > 1)
        {
            previousValidInputs = previousValidInputs
                .Where(x=>!string.IsNullOrWhiteSpace(x))
                .Distinct()
                .Where(x => allowed.Contains(x))
                .ToList();
        }
    }

    private void rchtxtbxMainOutPut_OnKeyPress(object? sender, KeyPressEventArgs e)
    {
        // empty
    }

    public static void txtbxInputBox_OnKeyUp(object? sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Escape:
            {
                txtbxInputBox.Clear();
                rchtxtbxMainOutPut.Focus();
                break;
            }
            
            case Keys.Up:
            {
                if (previousValidInputs.Count != 0 && previousValidInputs.Count > inputIndex)
                {
                    try
                    {
                        txtbxInputBox.Text = previousValidInputs[inputIndex];
                        inputIndex++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("[Exception Caught!]: " + ex);
                        inputIndex--;
                    }
                }
                break;
            }
            
            case Keys.Down:
            {
                if (inputIndex != 0)
                {
                    if (previousValidInputs.Count != 0)
                    {
                        try
                        {
                            if (previousValidInputs.Count == inputIndex)
                                inputIndex--;
                            inputIndex--;
                            txtbxInputBox.Text = previousValidInputs[inputIndex];
                        
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("[Exception Caught!]: " + ex);
                            inputIndex = 0;
                        }
                    }
                }
                else
                    txtbxInputBox.Clear();
                break;
            }
        }
    }
}