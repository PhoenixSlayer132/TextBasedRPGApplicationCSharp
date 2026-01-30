using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using TBRPG.BackEnd.CharacterFolder.Monsters;
using TBRPG.BackEnd.CharacterFolder.PlayerFolder;
using TBRPG.FrontEnd;

namespace TBRPG.BackEnd.TextBox;

public class MainTextBox
{
    public static readonly HashSet<string> commandsAllowed = new(StringComparer.OrdinalIgnoreCase) 
    {
        "attack", "a", "defend", "d", "observe", "o", "glace", "g", "/stats", "/s", "/glance", "/g", "/map", "/m"
    };

    public static readonly HashSet<string> anyTimeCommandsAllowed = new(StringComparer.OrdinalIgnoreCase)
    {
        "glance", "g", "/stats", "/s", "/map", "/m", "/glance", "/g"
    };
        
    static List<string> previousValidInputs = [];
    public static string txt = null!;
    static byte inputIndex = 0;
    
    private Control TextBoxOutput = MainTBRPGUserControl.rchtxtbxMainOutPut;
    public static float TypingSpeed { get; set; } = 25f;    private string Text;
    public static bool IsTyping => TypingSemaphore.CurrentCount == 0;
    
    private static Control Control;
    private static readonly StringBuilder displayBuffer = new();
    private static readonly SemaphoreSlim TypingSemaphore = new(1,1);
    
    private static volatile bool FastForwardRequested;
    
    private string CurrentText = $"{MainTBRPGUserControl.txtbxInputBox.Text}\n";
    private string AddingText;
    private static byte fastForwardCounter = 0;
    
    
    public MainTextBox(Control targetControl)
    {
        Control = targetControl ?? throw new ArgumentNullException(nameof(targetControl));
        displayBuffer.Append(Control.Text);
    }

    public static async Task<String?> WaitForUserInputAsync(CancellationToken cancellationToken = default)
    {
        var tcs = new TaskCompletionSource<string?>();

        KeyEventHandler? handler = null;

        handler = async (s, e) =>
        {
            if (e.KeyCode != Keys.Enter) return;
            Console.WriteLine("Test- ----------------------------------------------");
            
            Console.WriteLine(Player.player.inBattle);
            
            switch (fastForwardCounter)
            {
                case > 1:
                    return;
                case 1:
                    FastForward();
                    fastForwardCounter++;
                    break;
            }

            
            fastForwardCounter++;
            
            e.Handled = true;
            e.SuppressKeyPress = true;
            
            Console.WriteLine("txtbxInputBox_Enter");
            Console.WriteLine(txt);
            
            txt = MainTBRPGUserControl.txtbxInputBox.Text;
            MainTBRPGUserControl.txtbxInputBox.Clear();
            MainTBRPGUserControl.txtbxInputBox.KeyDown -= handler!;
            
            await AppendText(txt);
            
            previousValidInputs.Insert(0, txt);
            previousValidInputs.ForEach(Console.WriteLine);
            inputIndex = 0;

            if (previousValidInputs.Count > 1)
                previousValidInputs = previousValidInputs
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Distinct()
                    .Where(x => commandsAllowed.Contains(x))
                    .ToList();
            
            if (Player.player.inBattle)
            {
                switch (txt.ToLower())
                {
                    case "attack":
                    case "a":
                    {
                        Console.WriteLine("Command 'attack' used.");
                        fastForwardCounter = 0;
                        await Player.player.Attack(Monster.monster);
                        break;
                    }
                    case "defend":
                    case "d":
                    {
                        Console.WriteLine("Command 'defend' used.");
                        fastForwardCounter = 0;
                        await Player.player.Defend();
                        break;
                    }
                    case "observe":
                    case "o":
                    {
                        // Do opponent stats method
                        Console.WriteLine("Command 'observe' used.");
                        fastForwardCounter = 0;
                        await Player.player.Observe(Monster.monster);
                        break;
                    }
                    case "glance":
                    case "g":
                    {
                        // Do opponent glance method
                        Console.WriteLine("Command 'Glance' used.");
                        fastForwardCounter = 0;
                        await Player.player.Glance(Monster.monster);
                        break;
                    }
                    case "/stats":
                    case "/s":
                    {
                        // Do player stats method
                        Console.WriteLine("Command '/Stats' used.");
                        fastForwardCounter = 0;
                        await AppendText(Player.player.ToString());
                        break;
                    }
                    case "/glance":
                    case "/g":
                    {
                        // Do opponent glance method
                        Console.WriteLine("Command '/Glance' used.");
                        fastForwardCounter = 0;
                        await AppendText(Player.player.GlanceSelf());
                        break;
                    }
                    default:
                    {
                        Console.WriteLine($"\"{txt}\" is not a Valid Input.");
                        fastForwardCounter = 0;
                        break;
                    }
                }
            }
            
            tcs.TrySetResult(txt);
            fastForwardCounter = 0;
        };

        MainTBRPGUserControl.txtbxInputBox.KeyDown += handler;

        if (cancellationToken.CanBeCanceled)
        {
            cancellationToken.Register(() =>
            {
                MainTBRPGUserControl.txtbxInputBox.KeyDown -= handler!;
                tcs.TrySetCanceled(cancellationToken);
            });
        }

        
        
        
        
        
        return await tcs.Task;
    }



    public static void FastForward()
    {
        FastForwardRequested = true;
    }

    private static async Task TypeTextAsync(string text, CancellationToken cancellationToken = default)
    {
        if (text is null) text = string.Empty;

        await TypingSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (displayBuffer.Length > 0)
            {
                displayBuffer.AppendLine(); 
                SetControlTextSafe(displayBuffer.ToString()); 
                MoveCaret();
            }

            var delay = TimeSpan.FromSeconds(1f / Math.Max(1f, TypingSpeed));

            
            string[] entireText = text.Split('\n');

            foreach (var line in entireText)
            {
                foreach (var ch in line)
                {
                    
                    cancellationToken.ThrowIfCancellationRequested();
                    displayBuffer.Append(ch);
                    Console.WriteLine($"Appending {ch}");
                    SetControlTextSafe(displayBuffer.ToString());
                    
                    if (ch.Equals('\n'))
                        MoveCaret();
                    
                    if (FastForwardRequested)
                        continue; 
                    
                    await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
                }
                NewLine();
            }
            
            await Task.Delay(1000, CancellationToken.None);
            MoveCaret();
            SetControlTextSafe(displayBuffer.ToString()); // just incase fastforward fucked up
        }
        finally
        {
            MoveCaret();
            FastForwardRequested = false;
            TypingSemaphore.Release();
        }
    }
    public static async Task TypeTextAsync_SameLine(string text, CancellationToken cancellationToken = default)
    {
        if (text is null) text = string.Empty;

        await TypingSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            var delay = TimeSpan.FromSeconds(1f / Math.Max(1f, TypingSpeed));
            
            foreach (var ch in text)
            {
            
                cancellationToken.ThrowIfCancellationRequested();
                displayBuffer.Append(ch);
                Console.WriteLine($"Appending {ch}");
                SetControlTextSafe(displayBuffer.ToString());
            
            
                if (FastForwardRequested)
                    continue;

            
                await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
            }

            SetControlTextSafe(displayBuffer.ToString()); // just incase fastforward fucked up
        }
        finally
        {
            FastForwardRequested = false;
            TypingSemaphore.Release();
        }
    }

    private static void SetControlTextSafe(string text)
    {
        if (Control.IsDisposed) return;

        if (Control.InvokeRequired)
        {
            Control.BeginInvoke(() => Control.Text = text);
        }
        else
        {
            Control.Text = text;
        }
    }

    public static async Task AppendText(string text)
    {
        MoveCaret();
        await TypeTextAsync(text);
    }
    
    public static void AppendText_FAST(string text)
    {
        displayBuffer.Append(text + Environment.NewLine);
        SetControlTextSafe(displayBuffer.ToString());
        MoveCaret();
    }

    public static async Task TextAnim(string[] text, int waitTime)
    {
        foreach (var section in text)
        {
            await TypeTextAsync_SameLine(section);
            await Task.Delay(waitTime);
        }
        MoveCaret();
    }
    
    public static void NewLine()
    {
        MainTBRPGUserControl.rchtxtbxMainOutPut.Text += Environment.NewLine;
        displayBuffer.Append(Environment.NewLine);
        MoveCaret();
    }

    public static void MoveCaret()
    {
        MainTBRPGUserControl.rchtxtbxMainOutPut.SelectionStart = MainTBRPGUserControl.rchtxtbxMainOutPut.Text.Length;
        MainTBRPGUserControl.rchtxtbxMainOutPut.ScrollToCaret();
    }
}