namespace Chess_Timer_v_4
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Media;
    using System.Windows.Forms;

    public class frmGameEnd : Form
    {
        private Timer BeepTimer;
        private Button btnCont;
        private Button btnEnd;
        private Button btnStats;
        private CheckBox chkIgnore;
        private IContainer components;
        public bool continueGame;
        private GroupBox groupBox1;
        public TimeSpan increaseBy;
        private Label lblIncrease;
        private Label lblIntro;
        private Label lblNote;
        private Label lblReason;
        private Label lblRemedyIntro;
        private SetTime remIncrease;
        private int timesBeeped;

        public frmGameEnd(string Playername, string reason, Remedy rem)
        {
            this.InitializeComponent();

            base.AutoScaleMode = AutoScaleMode.Font;
            base.FormBorderStyle = FormBorderStyle.FixedDialog;

            this.lblIntro.Text = Playername + " has lost for the following reason:";
            this.lblReason.Text = reason;
            this.lblRemedyIntro.Text = "The remedy for this is called \r\n" + rem.ToString() + ".\r\nYou can see the options for this below:";
            switch (rem)
            {
                case Remedy.Ignore:
                    this.chkIgnore.Visible = true;
                    return;

                case Remedy.MoveThenIgnore:
                    this.chkIgnore.Visible = true;
                    this.lblNote.Visible = true;
                    this.lblNote.Text = Playername + "\r\nshould finish their move before you continue.";
                    return;

                case Remedy.IncreaseGameTime:
                    this.remIncrease.Visible = true;
                    this.lblIncrease.Visible = true;
                    this.lblIncrease.Text = "Increase game time limit by...";
                    return;

                case Remedy.IncreaseTotalTurnOverTime:
                    this.remIncrease.Visible = true;
                    this.lblIncrease.Visible = true;
                    this.lblIncrease.Text = "Increase total time over turn limit permitted by...";
                    return;
            }
        }

        private void BeepTimer_Tick(object sender, EventArgs e)
        {
            if (this.timesBeeped < 6)
            {
                SystemSounds.Asterisk.Play();
                this.timesBeeped++;
            }
            else
            {
                this.BeepTimer.Enabled = false;
            }
        }

        private void btnCont_Click(object sender, EventArgs e)
        {
            if (!this.chkIgnore.Checked && (this.remIncrease.getTime().TotalSeconds == 0.0))
            {
                MessageBox.Show("You need to choose some options for how to continue before you click \"Continue game\"", "Options not accepted", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.increaseBy = this.remIncrease.getTime();
                this.continueGame = true;
                base.Close();
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            base.Close();
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
            this.components = new System.ComponentModel.Container();
            this.lblIntro = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.btnCont = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnStats = new System.Windows.Forms.Button();
            this.chkIgnore = new System.Windows.Forms.CheckBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblRemedyIntro = new System.Windows.Forms.Label();
            this.remIncrease = new Chess_Timer_v_4.SetTime();
            this.lblIncrease = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BeepTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIntro
            // 
            this.lblIntro.AutoSize = true;
            this.lblIntro.Location = new System.Drawing.Point(12, 13);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(64, 13);
            this.lblIntro.TabIndex = 0;
            this.lblIntro.Text = "END GAME";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(12, 31);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(52, 13);
            this.lblReason.TabIndex = 1;
            this.lblReason.Text = "REASON";
            // 
            // btnCont
            // 
            this.btnCont.BackColor = System.Drawing.Color.Lime;
            this.btnCont.Location = new System.Drawing.Point(171, 191);
            this.btnCont.Name = "btnCont";
            this.btnCont.Size = new System.Drawing.Size(87, 23);
            this.btnCont.TabIndex = 2;
            this.btnCont.Text = "Continue game";
            this.btnCont.UseVisualStyleBackColor = false;
            this.btnCont.Click += new System.EventHandler(this.btnCont_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.Red;
            this.btnEnd.Location = new System.Drawing.Point(171, 220);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(87, 23);
            this.btnEnd.TabIndex = 2;
            this.btnEnd.Text = "End game";
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnStats
            // 
            this.btnStats.BackColor = System.Drawing.Color.White;
            this.btnStats.Location = new System.Drawing.Point(78, 220);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(87, 23);
            this.btnStats.TabIndex = 2;
            this.btnStats.Text = "View stats";
            this.btnStats.UseVisualStyleBackColor = false;
            // 
            // chkIgnore
            // 
            this.chkIgnore.AutoSize = true;
            this.chkIgnore.Location = new System.Drawing.Point(9, 68);
            this.chkIgnore.Name = "chkIgnore";
            this.chkIgnore.Size = new System.Drawing.Size(83, 17);
            this.chkIgnore.TabIndex = 3;
            this.chkIgnore.Text = "Ignore once";
            this.chkIgnore.UseVisualStyleBackColor = true;
            this.chkIgnore.Visible = false;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(10, 88);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(37, 13);
            this.lblNote.TabIndex = 4;
            this.lblNote.Text = "NOTE";
            this.lblNote.Visible = false;
            // 
            // lblRemedyIntro
            // 
            this.lblRemedyIntro.AutoSize = true;
            this.lblRemedyIntro.Location = new System.Drawing.Point(6, 16);
            this.lblRemedyIntro.Name = "lblRemedyIntro";
            this.lblRemedyIntro.Size = new System.Drawing.Size(53, 13);
            this.lblRemedyIntro.TabIndex = 1;
            this.lblRemedyIntro.Text = "REMEDY";
            // 
            // remIncrease
            // 
            this.remIncrease.Location = new System.Drawing.Point(65, 92);
            this.remIncrease.Name = "remIncrease";
            this.remIncrease.Size = new System.Drawing.Size(172, 27);
            this.remIncrease.TabIndex = 5;
            this.remIncrease.Visible = false;
            // 
            // lblIncrease
            // 
            this.lblIncrease.AutoSize = true;
            this.lblIncrease.Location = new System.Drawing.Point(9, 72);
            this.lblIncrease.Name = "lblIncrease";
            this.lblIncrease.Size = new System.Drawing.Size(61, 13);
            this.lblIncrease.TabIndex = 6;
            this.lblIncrease.Text = "INCREASE";
            this.lblIncrease.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRemedyIntro);
            this.groupBox1.Controls.Add(this.lblIncrease);
            this.groupBox1.Controls.Add(this.chkIgnore);
            this.groupBox1.Controls.Add(this.remIncrease);
            this.groupBox1.Controls.Add(this.lblNote);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 125);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "REMEDY";
            // 
            // BeepTimer
            // 
            this.BeepTimer.Enabled = true;
            this.BeepTimer.Tick += new System.EventHandler(this.BeepTimer_Tick);
            // 
            // frmGameEnd
            // 
            this.ClientSize = new System.Drawing.Size(296, 296);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnStats);
            this.Controls.Add(this.btnCont);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.lblIntro);
            this.Name = "frmGameEnd";
            this.Text = "End Game";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public enum Remedy
        {
            None,
            Ignore,
            MoveThenIgnore,
            IncreaseGameTime,
            IncreaseTotalTurnOverTime
        }
    }
}

