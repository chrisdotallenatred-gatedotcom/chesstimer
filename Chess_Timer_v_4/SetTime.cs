namespace Chess_Timer_v_4
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class SetTime : UserControl
    {
        private IContainer components=null;
        private Label label1;
        private Label label2;
        private NumericUpDown numMin;
        private NumericUpDown numSec;

        public SetTime()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public Tuple<decimal, decimal> getMinNSecs()
        {
            return new Tuple<decimal, decimal>(this.numMin.Value, this.numSec.Value);
        }

        public TimeSpan getTime()
        {
            return new TimeSpan(0, 0, (int) this.numMin.Value, (int) this.numSec.Value);
        }

        private void InitializeComponent()
        {
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numSec = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSec)).BeginInit();
            this.SuspendLayout();
            // 
            // numMin
            // 
            this.numMin.Location = new System.Drawing.Point(3, 3);
            this.numMin.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numMin.Name = "numMin";
            this.numMin.Size = new System.Drawing.Size(37, 20);
            this.numMin.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "seconds";
            // 
            // numSec
            // 
            this.numSec.Location = new System.Drawing.Point(75, 3);
            this.numSec.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numSec.Name = "numSec";
            this.numSec.Size = new System.Drawing.Size(37, 20);
            this.numSec.TabIndex = 2;
            this.numSec.ValueChanged += new System.EventHandler(this.numSec_ValueChanged);
            // 
            // SetTime
            // 
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numSec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numMin);
            this.Name = "SetTime";
            this.Size = new System.Drawing.Size(172, 27);
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void numSec_ValueChanged(object sender, EventArgs e)
        {
            if ((this.numSec.Value == 60M) && (this.numMin.Value < this.numMin.Maximum))
            {
                this.numSec.Value = 0M;
                this.numMin.Value++;
            }
        }

        public void setMinNSec(Tuple<decimal, decimal> setTo)
        {
            this.numMin.Value = setTo.Item1;
            this.numSec.Value = setTo.Item2;
        }
    }
}

