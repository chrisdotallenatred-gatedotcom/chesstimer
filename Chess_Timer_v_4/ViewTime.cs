namespace Chess_Timer_v_4
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class ViewTime : UserControl
    {
        public TimeSpan _displaying = new TimeSpan(0L);
        private Color _fontF = Color.FromArgb(0x41, 0x41, 0xb9);
        private Color bg = Color.FromArgb(0x19, 0x19, 0x19);
        private Rectangle[] colons = new Rectangle[] { new Rectangle(0x84, 0x13, 8, 8), new Rectangle(0x10b, 0x13, 8, 8), new Rectangle(130, 0x26, 8, 8), new Rectangle(0x109, 0x26, 8, 8) };
        private IContainer components=null;
        private Font dFont;
        public Color fontB = Color.FromArgb(30, 30, 60);
        private KeyPressedPointer kpp;
        private Label lblBH;
        private Label lblBM;
        private Label lblBS;
        private Label lblFH;
        private Label lblFM;
        private Label lblFS;
        private bool small;

        public ViewTime(FontFamily fnt, bool isSmall, KeyPressedPointer kp)
        {
            this.InitializeComponent();
            base.AutoScaleMode = AutoScaleMode.Font;


            this.small = isSmall;
            this.dFont = new Font(fnt, !this.small ? 45f : 25f);
            if (this.small)
            {
                base.Size = new Size(0xe7, 0x26);
                this.colons = new Rectangle[] { new Rectangle(0x4f, 12, 5, 5), new Rectangle(0x9c, 12, 5, 5), new Rectangle(0x4d, 0x17, 5, 5), new Rectangle(0x9a, 0x17, 5, 5) };
                this.lblBH.Location = this.lblFH.Location = new Point(0, 0);
                this.lblBM.Location = this.lblFM.Location = new Point(0x4d, 0);
                this.lblBS.Location = this.lblFS.Location = new Point(0x9a, 0);
            }
            this.kpp = kp;
        }

        private void Clear(Color FontFore)
        {
            Bitmap image = new Bitmap(base.Width, base.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.FillRectangles(new SolidBrush(FontFore), this.colons);
            graphics.Flush();
            this.BackgroundImage = image;
        }

        public void Display()
        {
            if (this._displaying.Ticks < 0L)
            {
                this.Clear(Color.Red);
                this.lblFH.ForeColor = this.lblFM.ForeColor = this.lblFS.ForeColor = Color.Red;
            }
            else
            {
                this.Clear(this._fontF);
                this.lblFH.ForeColor = this.lblFM.ForeColor = this.lblFS.ForeColor = this._fontF;
            }
            this.lblFH.Text = frmGame.getDigiString(((this._displaying.Hours < 0) ? -this._displaying.Hours : this._displaying.Hours).ToString("00"));
            this.lblFM.Text = frmGame.getDigiString(((this._displaying.Minutes < 0) ? -this._displaying.Minutes : this._displaying.Minutes).ToString("00"));
            this.lblFS.Text = frmGame.getDigiString(((this._displaying.Seconds < 0) ? -this._displaying.Seconds : this._displaying.Seconds).ToString("00"));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblBH = new System.Windows.Forms.Label();
            this.lblBM = new System.Windows.Forms.Label();
            this.lblBS = new System.Windows.Forms.Label();
            this.lblFS = new System.Windows.Forms.Label();
            this.lblFM = new System.Windows.Forms.Label();
            this.lblFH = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBH
            // 
            this.lblBH.AutoSize = true;
            this.lblBH.BackColor = System.Drawing.Color.Transparent;
            this.lblBH.Location = new System.Drawing.Point(-3, 0);
            this.lblBH.Name = "lblBH";
            this.lblBH.Size = new System.Drawing.Size(35, 13);
            this.lblBH.TabIndex = 0;
            this.lblBH.Text = "label1";
            // 
            // lblBM
            // 
            this.lblBM.AutoSize = true;
            this.lblBM.BackColor = System.Drawing.Color.Transparent;
            this.lblBM.Location = new System.Drawing.Point(132, 0);
            this.lblBM.Name = "lblBM";
            this.lblBM.Size = new System.Drawing.Size(35, 13);
            this.lblBM.TabIndex = 1;
            this.lblBM.Text = "label1";
            // 
            // lblBS
            // 
            this.lblBS.AutoSize = true;
            this.lblBS.BackColor = System.Drawing.Color.Transparent;
            this.lblBS.Location = new System.Drawing.Point(267, 0);
            this.lblBS.Name = "lblBS";
            this.lblBS.Size = new System.Drawing.Size(35, 13);
            this.lblBS.TabIndex = 2;
            this.lblBS.Text = "label1";
            // 
            // lblFS
            // 
            this.lblFS.AutoSize = true;
            this.lblFS.BackColor = System.Drawing.Color.Transparent;
            this.lblFS.Location = new System.Drawing.Point(267, 0);
            this.lblFS.Name = "lblFS";
            this.lblFS.Size = new System.Drawing.Size(0, 13);
            this.lblFS.TabIndex = 5;
            // 
            // lblFM
            // 
            this.lblFM.AutoSize = true;
            this.lblFM.BackColor = System.Drawing.Color.Transparent;
            this.lblFM.Location = new System.Drawing.Point(132, 0);
            this.lblFM.Name = "lblFM";
            this.lblFM.Size = new System.Drawing.Size(0, 13);
            this.lblFM.TabIndex = 4;
            // 
            // lblFH
            // 
            this.lblFH.AutoSize = true;
            this.lblFH.BackColor = System.Drawing.Color.Transparent;
            this.lblFH.Location = new System.Drawing.Point(-3, 0);
            this.lblFH.Name = "lblFH";
            this.lblFH.Size = new System.Drawing.Size(0, 13);
            this.lblFH.TabIndex = 3;
            // 
            // ViewTime
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblFS);
            this.Controls.Add(this.lblFM);
            this.Controls.Add(this.lblFH);
            this.Controls.Add(this.lblBS);
            this.Controls.Add(this.lblBM);
            this.Controls.Add(this.lblBH);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ViewTime";
            this.Size = new System.Drawing.Size(464, 70);
            this.Load += new System.EventHandler(this.ViewTime_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ViewTime_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ViewTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.kpp(e);
        }

        private void ViewTime_Load(object sender, EventArgs e)
        {
            this.lblBH.ForeColor = this.lblBM.ForeColor = this.lblBS.ForeColor = this.fontB;
            this.lblFH.ForeColor = this.lblFM.ForeColor = this.lblFS.ForeColor = this._fontF;
            this.lblFH.Font = this.lblFM.Font = this.lblFS.Font = this.lblBH.Font = this.lblBM.Font = this.lblBS.Font = this.dFont;
            this.Clear(this._fontF);
            this.Display();
        }

        public TimeSpan displaying
        {
            get
            {
                return this._displaying;
            }
            set
            {
                this._displaying = value;
                this.Display();
            }
        }

        public Color fontF
        {
            get
            {
                return this._fontF;
            }
            set
            {
                this._fontF = value;
                this.Clear(this._fontF);
                this.lblFH.ForeColor = this.lblFM.ForeColor = this.lblFS.ForeColor = this._fontF;
            }
        }

        public delegate void KeyPressedPointer(KeyPressEventArgs e);
    }
}

