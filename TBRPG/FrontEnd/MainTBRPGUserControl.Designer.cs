using System.ComponentModel;

namespace TBRPG.FrontEnd;

partial class MainTBRPGUserControl
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }


    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTBRPGUserControl));
        btnEnter = new System.Windows.Forms.Button();
        txtbxInputBox = new System.Windows.Forms.TextBox();
        lblPlayerName = new System.Windows.Forms.Label();
        pnlPlayerStats = new System.Windows.Forms.Panel();
        btnMap = new System.Windows.Forms.Button();
        rchtxtbxMainOutPut = new System.Windows.Forms.RichTextBox();
        pnlPlayerStats.SuspendLayout();
        SuspendLayout();
        // 
        // btnEnter
        // 
        btnEnter.BackColor = System.Drawing.SystemColors.WindowFrame;
        btnEnter.Location = new System.Drawing.Point(888, 627);
        btnEnter.Margin = new System.Windows.Forms.Padding(34, 12, 34, 12);
        btnEnter.Name = "btnEnter";
        btnEnter.Size = new System.Drawing.Size(128, 64);
        btnEnter.TabIndex = 0;
        btnEnter.Text = "Enter";
        btnEnter.UseVisualStyleBackColor = false;
        btnEnter.Click += btnEnter_Click;
        // 
        // txtbxInputBox
        // 
        txtbxInputBox.AcceptsReturn = true;
        txtbxInputBox.BackColor = System.Drawing.SystemColors.WindowFrame;
        txtbxInputBox.Location = new System.Drawing.Point(64, 627);
        txtbxInputBox.MinimumSize = new System.Drawing.Size(768, 64);
        txtbxInputBox.Name = "txtbxInputBox";
        txtbxInputBox.Size = new System.Drawing.Size(768, 64);
        txtbxInputBox.TabIndex = 1;
        txtbxInputBox.TextChanged += txtbxInputBox_TextChanged;
        txtbxInputBox.KeyUp += txtbxInputBox_OnKeyUp;
        // 
        // lblPlayerName
        // 
        lblPlayerName.BackColor = System.Drawing.Color.DarkGray;
        lblPlayerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lblPlayerName.Location = new System.Drawing.Point(24, 12);
        lblPlayerName.Name = "lblPlayerName";
        lblPlayerName.Size = new System.Drawing.Size(192, 32);
        lblPlayerName.TabIndex = 3;
        lblPlayerName.Text = "Player";
        lblPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pnlPlayerStats
        // 
        pnlPlayerStats.BackColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
        pnlPlayerStats.Controls.Add(btnMap);
        pnlPlayerStats.Controls.Add(lblPlayerName);
        pnlPlayerStats.Location = new System.Drawing.Point(48, 512);
        pnlPlayerStats.Name = "pnlPlayerStats";
        pnlPlayerStats.Size = new System.Drawing.Size(982, 84);
        pnlPlayerStats.TabIndex = 4;
        // 
        // btnMap
        // 
        btnMap.BackColor = System.Drawing.Color.Transparent;
        btnMap.BackgroundImage = ((System.Drawing.Image)resources.GetObject("btnMap.BackgroundImage"));
        btnMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        btnMap.Font = new System.Drawing.Font("Monocraft", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        btnMap.ForeColor = System.Drawing.Color.Transparent;
        btnMap.Location = new System.Drawing.Point(909, 9);
        btnMap.Name = "btnMap";
        btnMap.Size = new System.Drawing.Size(64, 64);
        btnMap.TabIndex = 4;
        btnMap.Text = "Map";
        btnMap.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        btnMap.UseVisualStyleBackColor = false;
        // 
        // rchtxtbxMainOutPut
        // 
        rchtxtbxMainOutPut.BackColor = System.Drawing.Color.Gray;
        rchtxtbxMainOutPut.Cursor = System.Windows.Forms.Cursors.Default;
        rchtxtbxMainOutPut.DetectUrls = false;
        rchtxtbxMainOutPut.Location = new System.Drawing.Point(32, 32);
        rchtxtbxMainOutPut.Name = "rchtxtbxMainOutPut";
        rchtxtbxMainOutPut.ReadOnly = true;
        rchtxtbxMainOutPut.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
        rchtxtbxMainOutPut.ShortcutsEnabled = false;
        rchtxtbxMainOutPut.Size = new System.Drawing.Size(1008, 448);
        rchtxtbxMainOutPut.TabIndex = 5;
        rchtxtbxMainOutPut.TabStop = false;
        rchtxtbxMainOutPut.Text = "";
        // 
        // MainTBRPGUserControl
        // 
        // AutoScaleDimensions = new System.Drawing.SizeF(16.5F, 34.5F);
        // AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.Black;
        Controls.Add(rchtxtbxMainOutPut);
        Controls.Add(pnlPlayerStats);
        Controls.Add(txtbxInputBox);
        Controls.Add(btnEnter);
        Font = new System.Drawing.Font("Monocraft", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        Location = new System.Drawing.Point(22, 22);
        Margin = new System.Windows.Forms.Padding(0, 0, 2, 2);
        Size = new System.Drawing.Size(1074, 712);
        Load += MainTBRPGUserControl_Load;
        KeyPress += rchtxtbxMainOutPut_OnKeyPress;
        pnlPlayerStats.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button btnMap;

    private System.Windows.Forms.RichTextBox rchtxtbxMainOutPut;

    private System.Windows.Forms.Panel pnlPlayerStats;

    private System.Windows.Forms.Label lblPlayerName;

    private System.Windows.Forms.TextBox txtbxInputBox;

    private System.Windows.Forms.Button btnEnter;

    public static List<string> outputText;
    
    
}