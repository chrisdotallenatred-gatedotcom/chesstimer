namespace Chess_Timer_v_4
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class GetKey : Form
    {
        private Button button1;
        private IContainer components=null;
        private Label label1;
        public char newKey;
        public bool set;

        public GetKey()
        {
            this.InitializeComponent();

            base.AutoScaleMode = AutoScaleMode.Font;
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.set = true;
            this.newKey = e.KeyChar;
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
            this.label1 = new Label();
            this.button1 = new Button();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xad, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Press a new key or cancel";
            this.button1.Location = new Point(0x75, 40);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button1.KeyPress += new KeyPressEventHandler(this.button1_KeyPress);
            base.AutoScaleDimensions = new SizeF(6f, 13f);

            base.ClientSize = new Size(0xcc, 0x4b);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.label1);
          
            base.Name = "GetKey";
            this.Text = "GetKey";
            base.ResumeLayout(false);
            base.PerformLayout();












        }
    }
}

