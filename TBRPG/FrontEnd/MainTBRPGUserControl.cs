namespace TBRPG.FrontEnd;

public partial class MainTBRPGUserControl : UserControl
{
    
    static List<string> previousValidInputs = [];
    static string txt = null!;
    static byte inputIndex = 0;
    public static MapTBRPGUserControl MapUserControl = new();
    public static MainTBRPGUserControl MainUserControl;
    
    static HashSet<string> allowed = new(StringComparer.OrdinalIgnoreCase) 
    {
        "attack", "atk", "defend", "def", "observe", "obs", "stats", "sts"
    };
    
    
    public MainTBRPGUserControl()
    {
        InitializeComponent();
    }
    
    private void MainTBRPGUserControl_Load(object sender, EventArgs e)
    {
        MainUserControl.Visible = true;
        MainUserControl.Show();
    }

    private void txtbxInputBox_TextChanged(object sender, EventArgs e)
    {
        Console.WriteLine("txtbxInputBox_TextChanged");
    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
        if (txtbxInputBox.Text is "" or null) return;
        txt = txtbxInputBox.Text;
        Console.WriteLine("txtbxInputBox_Enter");
        txtbxInputBox.Clear();
        Console.WriteLine(txt);
        previousValidInputs.Add(txt);
        previousValidInputs.ForEach(Console.WriteLine);
        inputIndex = 0;
        if (previousValidInputs.Count > 1)
        {
            previousValidInputs = previousValidInputs
                .Where(x=>!string.IsNullOrWhiteSpace(x))
                .Distinct()
                //.Where(x => allowed.Contains(x))
                .ToList();
        }
    }

    private void rchtxtbxMainOutPut_OnKeyPress(object? sender, KeyPressEventArgs e)
    {
        switch (e.KeyChar)
        {
            case 'M':
            case 'm':
            {
                MainUserControl.Hide();
                MapUserControl.Show();
                break;
            }
        }
    }

    private void txtbxInputBox_OnKeyUp(object? sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Enter:
            {
                if (txtbxInputBox.Text.Trim() is "" or null)
                {
                    txtbxInputBox.Clear();
                    return;
                }
                txt = txtbxInputBox.Text.Trim();
                Console.WriteLine("txtbxInputBox_Enter");
                txtbxInputBox.Clear();
                Console.WriteLine(txt);
                previousValidInputs.Insert(0, txt);
                previousValidInputs.ForEach(Console.WriteLine);
                inputIndex = 0;
                rchtxtbxMainOutPut.Text += txt + Environment.NewLine;
                rchtxtbxMainOutPut.SelectionStart = rchtxtbxMainOutPut.Text.Length;
                rchtxtbxMainOutPut.ScrollToCaret();
                
                if (previousValidInputs.Count > 1)
                    previousValidInputs = previousValidInputs
                            .Where(x=>!string.IsNullOrWhiteSpace(x))
                            .Distinct()
                            //.Where(x => allowed.Contains(x))
                            .ToList();
                break;
            }
            
            case Keys.Escape:
            {
                txtbxInputBox.Clear();
                rchtxtbxMainOutPut.Focus();
                
                break;
            }

            case Keys.Up:
            {
                if (previousValidInputs.Count != 0)
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