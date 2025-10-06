using System.ComponentModel;

namespace TBRPG.FrontEnd;

partial class MapTBRPGUserControl
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
        // 
        // MapTBRPGUserControl
        // 
        components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        

        BackColor = System.Drawing.Color.Black;
        ClientSize = new System.Drawing.Size(1074, 712);
        Font = new System.Drawing.Font("Monocraft", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        Location = new System.Drawing.Point(22, 22);
        Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
        Text = "MapTBRPGWindow";
        Dock = DockStyle.Fill;
        Load += MapUserControl_Load;
        Paint += MapUserControl_Paint;
        ResumeLayout(false);
        PerformLayout();
    }
    
}