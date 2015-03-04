using System.Collections.Generic;

namespace Chess_Timer_v_4
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class PlayerSetup : UserControl
    {
        private bool _isStartingPlayer;
        private bool changing;
        private CheckBox chkCarryOver;
        private CheckBox chkCarrySpare;
        private IContainer components=null;
        private GroupBox gbTimeLimits;
        private Button GetProfile;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label2;
        private Label label21;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label labelx;
        private NumericUpDown numIncrement;
        private NumericUpDown numTimesOver;
        private NumericUpDown numTimesOverRow;
        private SetTime tmGame;
        private SetTime tmOverSingle;
        private SetTime tmOverTotal;
        private SetTime tmTurn;
        private TextBox txtName;

        public PlayerSetup()
        {
            this.InitializeComponent();
            txtName.Text = "Chris Allen";


            tmGame_Load(null, null);



        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public Player GetPlayer()
        {
            string str = this.txtName.Text.Trim();
            return new Player((this._isStartingPlayer && str.EndsWith("*")) ? str.Remove(str.Length - 1) : str, this.tmTurn.getTime(), this.tmGame.getTime(), new TimeSpan(0, 0, (int) this.numIncrement.Value), this.tmOverSingle.getTime(), this.tmOverTotal.getTime(), this.chkCarryOver.Checked, this.chkCarrySpare.Checked, (int) this.numTimesOver.Value, (int) this.numTimesOverRow.Value);
        }

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.gbTimeLimits = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numIncrement = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.labelx = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tmGame = new Chess_Timer_v_4.SetTime();
            this.tmTurn = new Chess_Timer_v_4.SetTime();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCarrySpare = new System.Windows.Forms.CheckBox();
            this.chkCarryOver = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tmOverTotal = new Chess_Timer_v_4.SetTime();
            this.tmOverSingle = new Chess_Timer_v_4.SetTime();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numTimesOverRow = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numTimesOver = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.GetProfile = new System.Windows.Forms.Button();
            this.gbTimeLimits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIncrement)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimesOverRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimesOver)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(3, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(169, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "Chris Allen";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // gbTimeLimits
            // 
            this.gbTimeLimits.Controls.Add(this.label2);
            this.gbTimeLimits.Controls.Add(this.numIncrement);
            this.gbTimeLimits.Controls.Add(this.label1);
            this.gbTimeLimits.Controls.Add(this.labelx);
            this.gbTimeLimits.Controls.Add(this.label21);
            this.gbTimeLimits.Controls.Add(this.tmGame);
            this.gbTimeLimits.Controls.Add(this.tmTurn);
            this.gbTimeLimits.Location = new System.Drawing.Point(3, 29);
            this.gbTimeLimits.Name = "gbTimeLimits";
            this.gbTimeLimits.Size = new System.Drawing.Size(194, 133);
            this.gbTimeLimits.TabIndex = 1;
            this.gbTimeLimits.TabStop = false;
            this.gbTimeLimits.Text = "Player Time Limits";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "seconds";
            // 
            // numIncrement
            // 
            this.numIncrement.Location = new System.Drawing.Point(83, 107);
            this.numIncrement.Name = "numIncrement";
            this.numIncrement.Size = new System.Drawing.Size(37, 20);
            this.numIncrement.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "with increment";
            // 
            // labelx
            // 
            this.labelx.AutoSize = true;
            this.labelx.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelx.Location = new System.Drawing.Point(8, 62);
            this.labelx.Name = "labelx";
            this.labelx.Size = new System.Drawing.Size(113, 11);
            this.labelx.TabIndex = 12;
            this.labelx.Text = "Player game time is...";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(8, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(107, 11);
            this.label21.TabIndex = 12;
            this.label21.Text = "Player turn time is...";
            // 
            // tmGame
            // 
            this.tmGame.Location = new System.Drawing.Point(8, 76);
            this.tmGame.Name = "tmGame";
            this.tmGame.Size = new System.Drawing.Size(172, 27);
            this.tmGame.TabIndex = 2;
            this.tmGame.Load += new System.EventHandler(this.tmGame_Load);
            // 
            // tmTurn
            // 
            this.tmTurn.Location = new System.Drawing.Point(8, 32);
            this.tmTurn.Name = "tmTurn";
            this.tmTurn.Size = new System.Drawing.Size(172, 27);
            this.tmTurn.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCarrySpare);
            this.groupBox1.Controls.Add(this.chkCarryOver);
            this.groupBox1.Location = new System.Drawing.Point(3, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 63);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player Carrying Options";
            // 
            // chkCarrySpare
            // 
            this.chkCarrySpare.AutoSize = true;
            this.chkCarrySpare.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
            this.chkCarrySpare.Location = new System.Drawing.Point(8, 39);
            this.chkCarrySpare.Name = "chkCarrySpare";
            this.chkCarrySpare.Size = new System.Drawing.Size(109, 15);
            this.chkCarrySpare.TabIndex = 5;
            this.chkCarrySpare.Text = "Carry spare time";
            this.chkCarrySpare.UseVisualStyleBackColor = true;
            // 
            // chkCarryOver
            // 
            this.chkCarryOver.AutoSize = true;
            this.chkCarryOver.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold);
            this.chkCarryOver.Location = new System.Drawing.Point(8, 18);
            this.chkCarryOver.Name = "chkCarryOver";
            this.chkCarryOver.Size = new System.Drawing.Size(104, 15);
            this.chkCarryOver.TabIndex = 4;
            this.chkCarryOver.Text = "Carry over time";
            this.chkCarryOver.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tmOverTotal);
            this.groupBox2.Controls.Add(this.tmOverSingle);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numTimesOverRow);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numTimesOver);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(3, 237);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 181);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player Loses If...";
            // 
            // tmOverTotal
            // 
            this.tmOverTotal.Location = new System.Drawing.Point(8, 142);
            this.tmOverTotal.Name = "tmOverTotal";
            this.tmOverTotal.Size = new System.Drawing.Size(172, 27);
            this.tmOverTotal.TabIndex = 9;
            // 
            // tmOverSingle
            // 
            this.tmOverSingle.Location = new System.Drawing.Point(8, 98);
            this.tmOverSingle.Name = "tmOverSingle";
            this.tmOverSingle.Size = new System.Drawing.Size(172, 27);
            this.tmOverSingle.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 11);
            this.label7.TabIndex = 11;
            this.label7.Text = "Total time over reaches...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 11);
            this.label6.TabIndex = 10;
            this.label6.Text = "Time over in a single turn reaches...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "times in-a-row";
            // 
            // numTimesOverRow
            // 
            this.numTimesOverRow.Location = new System.Drawing.Point(10, 59);
            this.numTimesOverRow.Name = "numTimesOverRow";
            this.numTimesOverRow.Size = new System.Drawing.Size(80, 20);
            this.numTimesOverRow.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "times";
            // 
            // numTimesOver
            // 
            this.numTimesOver.Location = new System.Drawing.Point(10, 32);
            this.numTimesOver.Name = "numTimesOver";
            this.numTimesOver.Size = new System.Drawing.Size(80, 20);
            this.numTimesOver.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 11);
            this.label3.TabIndex = 2;
            this.label3.Text = "They go over set turn time...\r\n";
            // 
            // GetProfile
            // 
            this.GetProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetProfile.Location = new System.Drawing.Point(175, 3);
            this.GetProfile.Margin = new System.Windows.Forms.Padding(0);
            this.GetProfile.Name = "GetProfile";
            this.GetProfile.Size = new System.Drawing.Size(22, 20);
            this.GetProfile.TabIndex = 13;
            this.GetProfile.TabStop = false;
            this.GetProfile.Text = "...";
            this.GetProfile.UseCompatibleTextRendering = true;
            this.GetProfile.UseMnemonic = false;
            this.GetProfile.UseVisualStyleBackColor = false;
            // 
            // PlayerSetup
            // 
            this.Controls.Add(this.GetProfile);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbTimeLimits);
            this.Controls.Add(this.txtName);
            this.Name = "PlayerSetup";
            this.Size = new System.Drawing.Size(200, 428);
            this.gbTimeLimits.ResumeLayout(false);
            this.gbTimeLimits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIncrement)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimesOverRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimesOver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void Mimic(PlayerSetup ps)
        {
            this.tmGame.setMinNSec(ps.tmGame.getMinNSecs());
            this.tmOverSingle.setMinNSec(ps.tmOverSingle.getMinNSecs());
            this.tmOverTotal.setMinNSec(ps.tmOverTotal.getMinNSecs());
            this.tmTurn.setMinNSec(ps.tmTurn.getMinNSecs());
            this.numIncrement.Value = ps.numIncrement.Value;
            this.chkCarryOver.Checked = ps.chkCarryOver.Checked;
            this.chkCarrySpare.Checked = ps.chkCarrySpare.Checked;
            this.numTimesOver.Value = ps.numTimesOver.Value;
            this.numTimesOverRow.Value = ps.numTimesOverRow.Value;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (!this.changing)
            {
                string text = this.txtName.Text;
                this.changing = true;
                if ((this.isStartingPlayer && !text.EndsWith("*")) && (text != ""))
                {
                    this.txtName.Text = this.txtName.Text + "*";
                    this.txtName.Select(this.txtName.Text.Length - 1, 0);
                }
                this.changing = false;
            }
        }

        public bool isStartingPlayer
        {
            get
            {
                return this._isStartingPlayer;
            }
            set
            {
                this._isStartingPlayer = value;
                if (!this._isStartingPlayer && this.txtName.Text.EndsWith("*"))
                {
                    this.txtName.Text = this.txtName.Text.Remove(this.txtName.Text.Length - 1);
                }
                if (this._isStartingPlayer)
                {
                    this.txtName.Text = this.txtName.Text + "*";
                }
            }
        }

        public string PlayerName
        {
            get
            {
                return this.txtName.Text;
            }
            set
            {
                this.txtName.Text = value;
            }
        }

        private void tmGame_Load(object sender, EventArgs e)
        {



            var setthetme = new TupleList<decimal, decimal>
            {
                { 25,0 }
 
            };



            tmGame.setMinNSec(setthetme[0]);
        }
    }







    public class TupleList<T1, T2> : List<Tuple<T1, T2>>
    {
        public void Add(T1 item, T2 item2)
        {
            Add(new Tuple<T1, T2>(item, item2));
        }
    }



}

