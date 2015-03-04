using Properties;

namespace Chess_Timer_v_4
{
    
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class ViewPlayer : UserControl
    {
        private bool _isExanded;
        public Color bgClr;
        private IContainer components=null;
        private Font digiFont;
        private FontFamily ff;
        private Label label1;
        private Label label10;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label lblAvg;
        private Label lblGameTimeOverAllowed;
        private Label lblMaxTimesOver;
        private Label lblMaxTimesOverRow;
        private Label lblName;
        private Label lblTimeOver;
        private Label lblTimeToCarry;
        private Label lblTurnTimeOverAllowed;
        private int maxOver;
        private int maxOverRow;
   //     private Panel panel1;
    //    private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private PrivateFontCollection pfc;
        private PictureBox picCarryOver;
        private PictureBox picCarrySpare;
        private PictureBox pictureBox1;
        private Label[] titles;
        public Color titlesClr;
        public Color valuesClr;
        //private ViewTime vtGameTime;
        private ViewTime vtGameTimeLeft;
        //private ViewTime vtTurnTime;
        //private ViewTime vtTurnTimeLeft;

        public unsafe ViewPlayer()
        {

            byte[] numRef3 = null;
            byte[] numRef2 = null;

            byte[] numRef = null;



            byte[] buffer2;
            byte[] buffer3;
            this.pfc = new PrivateFontCollection();
            this.valuesClr = Color.FromArgb(230, 230, 230);
            this.titlesClr = Color.FromArgb(0x41, 0x41, 0xb9);
            this.bgClr = Color.FromArgb(0x19, 0x19, 0x19);
            this._isExanded = true;
            this.InitializeComponent();

            // fixed ( numRef = Resources.pcf1)
            numRef = Resources.pcf1;

            IntPtr unmanagedPointer;  ///  http://stackoverflow.com/questions/537573/how-to-get-intptr-from-byte-in-c-sharp
            {

                unmanagedPointer = Marshal.AllocHGlobal(numRef.Length);
                Marshal.Copy(numRef, 0, unmanagedPointer, numRef.Length);


                this.pfc.AddMemoryFont(unmanagedPointer, Resources.pcf1.Length);
                uint num = 0;
                AddFontMemResourceEx(unmanagedPointer, (uint)Resources.pcf1.Length, IntPtr.Zero, ref num);


                // Call unmanaged code
                Marshal.FreeHGlobal(unmanagedPointer);

            }
            if (((buffer2 = Resources.QuartzMS) == null) || (buffer2.Length == 0))
            {
                // numRef2 = null;
                goto Label_00D2;
            }
            //  fixed (byte* numRef2 = buffer2)

            numRef2 = buffer2;


        Label_00D2:

            unmanagedPointer = Marshal.AllocHGlobal(numRef2.Length);
            Marshal.Copy(numRef2, 0, unmanagedPointer, numRef2.Length);



            this.pfc.AddMemoryFont(unmanagedPointer, Resources.QuartzMS.Length);
            uint num2 = 0;
            AddFontMemResourceEx(unmanagedPointer, (uint)Resources.QuartzMS.Length, IntPtr.Zero, ref num2);

            // Call unmanaged code
            Marshal.FreeHGlobal(unmanagedPointer);


            if (((buffer3 = Resources.MotorwerkOblique) == null) || (buffer3.Length == 0))
            {
                numRef3 = null;
            }
            else
            {
                numRef3 = buffer3;
            }



            unmanagedPointer = Marshal.AllocHGlobal(numRef3.Length);
            Marshal.Copy(numRef3, 0, unmanagedPointer, numRef3.Length);


            this.pfc.AddMemoryFont(unmanagedPointer, Resources.MotorwerkOblique.Length);
            uint pcFonts = 0;
            AddFontMemResourceEx(unmanagedPointer, (uint)Resources.MotorwerkOblique.Length, IntPtr.Zero, ref pcFonts);
            // fixed (numRef3 = null)

            // Call unmanaged code
            Marshal.FreeHGlobal(unmanagedPointer);


            numRef3 = null;
            {
                this.ff = this.pfc.Families[0];
                this.digiFont = new Font(this.ff, 50f);
            }



















        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void DrawArrow(bool up)
        {
            Bitmap image = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            Graphics graphics = Graphics.FromImage(image);
            Point[] points = new Point[] { new Point(0, 0), new Point(this.pictureBox1.Width, 0), new Point(this.pictureBox1.Width / 2, this.pictureBox1.Height) };
            if (up)
            {
                points = new Point[] { new Point(0, this.pictureBox1.Height), new Point(this.pictureBox1.Width, this.pictureBox1.Height), new Point(this.pictureBox1.Width / 2, 0) };
            }
            graphics.FillPolygon(new SolidBrush(this.titlesClr), points);
            this.pictureBox1.Image = image;
        }

        public void EndGo(TimeSpan toCarry, int moves, double average, int TimesGoneOverInARow)
        {
            this.lblTimeToCarry.Text = toCarry.ToString("hh':'mm':'ss");
            this.lblAvg.Text = string.Format("{0} moves, {1:0.000} sec/per move", moves, average);
            this.UpdateColours(Color.FromArgb(130, 130, 150), Color.FromArgb(130, 130, 130), this.bgClr);
            this.lblMaxTimesOverRow.Text = string.Format("{0}/{1}", TimesGoneOverInARow, this.maxOverRow);
        }

        public void GameTimeUpdate(TimeSpan timeTakenThisGame, TimeSpan timeLeftThisGame)
        {
           // this.vtGameTime.displaying = timeTakenThisGame;
            this.vtGameTimeLeft.displaying = timeLeftThisGame;
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTimeToCarry = new System.Windows.Forms.Label();
            this.lblTimeOver = new System.Windows.Forms.Label();
            this.lblGameTimeOverAllowed = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTurnTimeOverAllowed = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAvg = new System.Windows.Forms.Label();
            this.lblMaxTimesOver = new System.Windows.Forms.Label();
            this.lblMaxTimesOverRow = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picCarrySpare = new System.Windows.Forms.PictureBox();
            this.picCarryOver = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarrySpare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarryOver)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "TIME TAKEN THIS TURN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(3, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "TIME LEFT FOR TURN:";
            this.label2.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(177, 280);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(231, 38);
            this.panel3.TabIndex = 5;
            this.panel3.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(3, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "TIME LEFT FOR GAME:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(3, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "TIME TAKEN THIS GAME:";
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(3, 207);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(405, 67);
            this.panel4.TabIndex = 3;
            this.panel4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(208, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "TIME TO CARRY:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(4, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "TOTAL TIME GONE OVER:";
            // 
            // lblTimeToCarry
            // 
            this.lblTimeToCarry.AutoSize = true;
            this.lblTimeToCarry.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeToCarry.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTimeToCarry.Location = new System.Drawing.Point(218, 353);
            this.lblTimeToCarry.Name = "lblTimeToCarry";
            this.lblTimeToCarry.Size = new System.Drawing.Size(90, 25);
            this.lblTimeToCarry.TabIndex = 7;
            this.lblTimeToCarry.Text = "00:00:00";
            // 
            // lblTimeOver
            // 
            this.lblTimeOver.AutoSize = true;
            this.lblTimeOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeOver.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTimeOver.Location = new System.Drawing.Point(14, 353);
            this.lblTimeOver.Name = "lblTimeOver";
            this.lblTimeOver.Size = new System.Drawing.Size(90, 25);
            this.lblTimeOver.TabIndex = 9;
            this.lblTimeOver.Text = "00:00:00";
            // 
            // lblGameTimeOverAllowed
            // 
            this.lblGameTimeOverAllowed.AutoSize = true;
            this.lblGameTimeOverAllowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameTimeOverAllowed.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblGameTimeOverAllowed.Location = new System.Drawing.Point(14, 399);
            this.lblGameTimeOverAllowed.Name = "lblGameTimeOverAllowed";
            this.lblGameTimeOverAllowed.Size = new System.Drawing.Size(90, 25);
            this.lblGameTimeOverAllowed.TabIndex = 11;
            this.lblGameTimeOverAllowed.Text = "00:00:00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(4, 387);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(238, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "TOTAL TIME OVER ALLOWED:";
            // 
            // lblTurnTimeOverAllowed
            // 
            this.lblTurnTimeOverAllowed.AutoSize = true;
            this.lblTurnTimeOverAllowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnTimeOverAllowed.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTurnTimeOverAllowed.Location = new System.Drawing.Point(14, 445);
            this.lblTurnTimeOverAllowed.Name = "lblTurnTimeOverAllowed";
            this.lblTurnTimeOverAllowed.Size = new System.Drawing.Size(90, 25);
            this.lblTurnTimeOverAllowed.TabIndex = 13;
            this.lblTurnTimeOverAllowed.Text = "00:00:00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label12.Location = new System.Drawing.Point(4, 433);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(232, 20);
            this.label12.TabIndex = 12;
            this.label12.Text = "TURN TIME OVER ALLOWED:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(208, 387);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(162, 20);
            this.label13.TabIndex = 14;
            this.label13.Text = "CARRY OVER TIME:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label14.Location = new System.Drawing.Point(208, 410);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(171, 20);
            this.label14.TabIndex = 14;
            this.label14.Text = "CARRY SPARE TIME:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(208, 433);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(151, 20);
            this.label15.TabIndex = 15;
            this.label15.Text = "MAX TIMES OVER:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label16.Location = new System.Drawing.Point(208, 456);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(179, 20);
            this.label16.TabIndex = 16;
            this.label16.Text = "MAX OVER-IN-A-ROW:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(259, 31);
            this.lblName.TabIndex = 17;
            this.lblName.Text = "[Insert Player Name]";
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // lblAvg
            // 
            this.lblAvg.AutoSize = true;
            this.lblAvg.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAvg.Location = new System.Drawing.Point(26, 31);
            this.lblAvg.Name = "lblAvg";
            this.lblAvg.Size = new System.Drawing.Size(128, 13);
            this.lblAvg.TabIndex = 18;
            this.lblAvg.Text = "0 moves, 0 sec/per move";
            // 
            // lblMaxTimesOver
            // 
            this.lblMaxTimesOver.AutoSize = true;
            this.lblMaxTimesOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxTimesOver.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMaxTimesOver.Location = new System.Drawing.Point(365, 430);
            this.lblMaxTimesOver.Name = "lblMaxTimesOver";
            this.lblMaxTimesOver.Size = new System.Drawing.Size(42, 25);
            this.lblMaxTimesOver.TabIndex = 21;
            this.lblMaxTimesOver.Text = "0/0";
            // 
            // lblMaxTimesOverRow
            // 
            this.lblMaxTimesOverRow.AutoSize = true;
            this.lblMaxTimesOverRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxTimesOverRow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMaxTimesOverRow.Location = new System.Drawing.Point(365, 453);
            this.lblMaxTimesOverRow.Name = "lblMaxTimesOverRow";
            this.lblMaxTimesOverRow.Size = new System.Drawing.Size(42, 25);
            this.lblMaxTimesOverRow.TabIndex = 22;
            this.lblMaxTimesOverRow.Text = "0/0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(388, 341);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(13, 14);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // picCarrySpare
            // 
            this.picCarrySpare.BackColor = System.Drawing.Color.Transparent;
            this.picCarrySpare.Location = new System.Drawing.Point(372, 403);
            this.picCarrySpare.Name = "picCarrySpare";
            this.picCarrySpare.Size = new System.Drawing.Size(26, 26);
            this.picCarrySpare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCarrySpare.TabIndex = 19;
            this.picCarrySpare.TabStop = false;
            // 
            // picCarryOver
            // 
            this.picCarryOver.BackColor = System.Drawing.Color.Transparent;
            this.picCarryOver.InitialImage = null;
            this.picCarryOver.Location = new System.Drawing.Point(372, 377);
            this.picCarryOver.Name = "picCarryOver";
            this.picCarryOver.Size = new System.Drawing.Size(26, 26);
            this.picCarryOver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCarryOver.TabIndex = 20;
            this.picCarryOver.TabStop = false;
            // 
            // ViewPlayer
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picCarrySpare);
            this.Controls.Add(this.picCarryOver);
            this.Controls.Add(this.lblMaxTimesOverRow);
            this.Controls.Add(this.lblMaxTimesOver);
            this.Controls.Add(this.lblAvg);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblTurnTimeOverAllowed);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblGameTimeOverAllowed);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTimeOver);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTimeToCarry);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Name = "ViewPlayer";
            this.Size = new System.Drawing.Size(637, 583);
            this.Load += new System.EventHandler(this.ViewPlayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarrySpare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarryOver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void NewGo(TimeSpan turnTime, TimeSpan singleCutoff)
        {
          //  this.vtTurnTime.displaying = new TimeSpan(0L);
         //   this.vtTurnTimeLeft.displaying = turnTime;
            this.lblTimeToCarry.Text = "00:00:00";
            this.lblTurnTimeOverAllowed.Text = singleCutoff.ToString("hh':'mm':'ss");
            this.UpdateColours();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.isExanded = !this.isExanded;
            this.DrawArrow(!this.isExanded);
        }

        public void SetUp(string playername, bool carryOver, bool carrySpare, TimeSpan turnTimeOverAllowed, TimeSpan gameTimeOverAllowed, int timesOverAllowed, int timesOverInARowAllowed, TimeSpan gameTime, TimeSpan turnTime, ViewTime.KeyPressedPointer kpp, bool expanded)
        {
            this.lblName.Text = playername;
            this.picCarryOver.Image = carryOver ? Resources.CT_tick : Resources.CT_cross;
            this.picCarrySpare.Image = carrySpare ? Resources.CT_tick : Resources.CT_cross;
            this.lblTurnTimeOverAllowed.Text = turnTimeOverAllowed.ToString("hh':'mm':'ss");
            this.lblGameTimeOverAllowed.Text = gameTimeOverAllowed.ToString("hh':'mm':'ss");
            this.lblMaxTimesOver.Text = "0/" + timesOverAllowed;
            this.lblMaxTimesOverRow.Text = "0/" + timesOverInARowAllowed;
            this.maxOver = timesOverAllowed;
            this.maxOverRow = timesOverInARowAllowed;
            this.isExanded = expanded;
            this.DrawArrow(!this.isExanded);
//            this.vtTurnTime = new ViewTime(this.ff, true, kpp);
  //          this.vtTurnTime.Location = new Point(3, 0x49);
    //        this.vtGameTime = new ViewTime(this.ff, true, kpp);
     //       this.vtGameTime.Location = new Point(3, 0xcf);
      //      this.vtTurnTimeLeft = new ViewTime(this.ff, true, kpp);
       //     this.vtTurnTimeLeft.Location = new Point(0xb1, 0x92);
        //    this.vtTurnTimeLeft.displaying = turnTime;
            this.vtGameTimeLeft = new ViewTime(this.ff, false, kpp);
            this.vtGameTimeLeft.Location = new Point(0xb1, 280);
            this.vtGameTimeLeft.displaying = gameTime;
          //  this.vtTurnTime.fontF = this.vtGameTime.fontF = this.vtTurnTimeLeft.fontF = 
            
            this.vtGameTimeLeft.fontF = this.valuesClr;
            //base.Controls.Add(this.vtTurnTime);
            //base.Controls.Add(this.vtGameTime);
            //base.Controls.Add(this.vtTurnTimeLeft);
            base.Controls.Add(this.vtGameTimeLeft);
            this.EndGo(TimeSpan.Zero, 0, 0.0, 0);
        }

        public void StartedGoingOver(int movesGoneOver, int movesGoneOverRow)
        {
            this.lblMaxTimesOver.Text = string.Format("{0}/{1}", movesGoneOver, this.maxOver);
            this.lblMaxTimesOverRow.Text = string.Format("{0}/{1}", movesGoneOverRow, this.maxOverRow);
        }

        public void TimeGoingOverUpdate(TimeSpan totalTimeOver, TimeSpan timeOverAllowedThisTurn, TimeSpan timeOverAllowedThisGame)
        {
            this.lblGameTimeOverAllowed.Text = timeOverAllowedThisGame.ToString("hh':'mm':'ss");
            this.lblTimeOver.Text = totalTimeOver.ToString("hh':'mm':'ss");
            this.lblTurnTimeOverAllowed.Text = timeOverAllowedThisTurn.ToString("hh':'mm':'ss");
        }

        public void TurnTimeUpdate(TimeSpan timeTakenThisTurn, TimeSpan timeLeftThisTurn)
        {
         //   this.vtTurnTime.displaying = timeTakenThisTurn;
          //  this.vtTurnTimeLeft.displaying = timeLeftThisTurn;
        }

        public void UpdateColours()
        {
            this.UpdateColours(this.titlesClr, this.valuesClr, this.bgClr);
        }

        public void UpdateColours(Color ctitles, Color cvalues, Color bg)
        {
            this.BackColor = this.bgClr;
            foreach (Label label in this.titles)
            {
                label.ForeColor = ctitles;
            }
            this.lblAvg.ForeColor = this.lblGameTimeOverAllowed.ForeColor 
                = this.lblMaxTimesOver.ForeColor = this.lblMaxTimesOverRow.ForeColor = this.lblTimeOver.ForeColor
                = this.lblTimeToCarry.ForeColor 
                = this.lblTurnTimeOverAllowed.ForeColor
               // = this.vtGameTime.fontF 
                = this.vtGameTimeLeft.fontF 

                /*
                = this.vtTurnTime.fontF 
                = this.vtTurnTimeLeft.fontF
                 */ 
                = cvalues;
            this.DrawArrow(!this.isExanded);
        }

        private void ViewPlayer_Load(object sender, EventArgs e)
        {
            this.titles = new Label[] { this.label1, this.label2, this.label3, this.label4, this.label13, this.label14, this.label10, this.label12, this.label15, this.label16, this.label5, this.label6, this.lblName };
            FontFamily family = this.pfc.Families[1];
            Font font = new Font(family, 14f);
            for (int i = 0; i < 4; i++)
            {
                this.titles[i].Font = font;
            }
            font = new Font(family, 12f);
            for (int j = 4; j < (this.titles.Length - 1); j++)
            {
                this.titles[j].Font = font;
            }
            this.lblMaxTimesOver.Font = font;
            this.lblMaxTimesOverRow.Font = font;
            FontFamily family2 = this.pfc.Families[2];
            Font font2 = new Font(family2, 15f);
            this.lblGameTimeOverAllowed.Font = this.lblTimeOver.Font = this.lblTimeToCarry.Font = this.lblTurnTimeOverAllowed.Font = font2;
        }

        public bool isExanded
        {
            get
            {
                return this._isExanded;
            }
            set
            {
                this._isExanded = value;
                if (!this._isExanded)
                {
                    this.label6.Visible = this.label5.Visible = this.label10.Visible = this.label12.Visible = this.label13.Visible = this.label14.Visible = this.label15.Visible = this.label16.Visible = this.lblTimeOver.Visible = this.lblGameTimeOverAllowed.Visible = this.lblTurnTimeOverAllowed.Visible = this.lblTimeToCarry.Visible = this.lblMaxTimesOver.Visible = this.lblMaxTimesOverRow.Visible = this.picCarryOver.Visible = this.picCarrySpare.Visible = false;
                }
                else
                {
                    this.label6.Visible = this.label5.Visible = this.label10.Visible = this.label12.Visible = this.label13.Visible = this.label14.Visible = this.label15.Visible = this.label16.Visible = this.lblTimeOver.Visible = this.lblGameTimeOverAllowed.Visible = this.lblTurnTimeOverAllowed.Visible = this.lblTimeToCarry.Visible = this.lblMaxTimesOver.Visible = this.lblMaxTimesOverRow.Visible = this.picCarryOver.Visible = this.picCarrySpare.Visible = true;
                }
            }
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        //private void panel1_Paint(object sender, PaintEventArgs e)
        //{
        //    panel1.Visible = false;
        //}
    }
}

