namespace Chess_Timer_v_4
{
    using Chess_Timer_v_4.Properties;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmGame : Form
    {
        private IContainer components;
        private Timer gameTimer;
        private Label lblPaused;
        private Player[] players;
        private int playerToMove;
        private int startingInterval;
        private ViewPlayer viewPlayer1;
        private ViewPlayer viewPlayer2;

        public frmGame(Player[] plyrs, int startingPlayer)
        {
            this.InitializeComponent();

            base.AutoScaleMode = AutoScaleMode.Font;
            base.FormBorderStyle = FormBorderStyle.FixedDialog;

            this.players = plyrs;
            this.playerToMove = (startingPlayer == 0) ? 1 : 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.viewPlayer1.Dispose();
            this.viewPlayer2.Dispose();
        }

        private void frmGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.KeyPressed(e);
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            this.players[0].kpp = new ViewTime.KeyPressedPointer(this.KeyPressed);
            this.players[1].kpp = new ViewTime.KeyPressedPointer(this.KeyPressed);
            this.players[0].viewer = this.viewPlayer1;
            this.players[1].viewer = this.viewPlayer2;
            this.gameTimer.Interval = Settings.Default.updateInterval;
            this.startingInterval = this.gameTimer.Interval;
        }

        public static string getDigiString(string s)
        {
            string str = "";
            foreach (char ch in s)
            {
                str = str + ((char) (ch + 0xdfff));
            }
            return str;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.lblPaused = new System.Windows.Forms.Label();
            this.viewPlayer2 = new Chess_Timer_v_4.ViewPlayer();
            this.viewPlayer1 = new Chess_Timer_v_4.ViewPlayer();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblPaused
            // 
            this.lblPaused.AutoSize = true;
            this.lblPaused.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaused.ForeColor = System.Drawing.Color.Red;
            this.lblPaused.Location = new System.Drawing.Point(496, 510);
            this.lblPaused.Name = "lblPaused";
            this.lblPaused.Size = new System.Drawing.Size(264, 39);
            this.lblPaused.TabIndex = 4;
            this.lblPaused.Text = "TIMER PAUSED";
            this.lblPaused.Visible = false;
            // 
            // viewPlayer2
            // 
            this.viewPlayer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.viewPlayer2.isExanded = true;
            this.viewPlayer2.Location = new System.Drawing.Point(708, 6);
            this.viewPlayer2.Name = "viewPlayer2";
            this.viewPlayer2.Size = new System.Drawing.Size(665, 501);
            this.viewPlayer2.TabIndex = 1;
            this.viewPlayer2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.viewPlayer2_KeyPress);
            // 
            // viewPlayer1
            // 
            this.viewPlayer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.viewPlayer1.isExanded = true;
            this.viewPlayer1.Location = new System.Drawing.Point(6, 6);
            this.viewPlayer1.Name = "viewPlayer1";
            this.viewPlayer1.Size = new System.Drawing.Size(667, 495);
            this.viewPlayer1.TabIndex = 0;
            this.viewPlayer1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.viewPlayer1_KeyPress);
            // 
            // frmGame
            // 
            this.ClientSize = new System.Drawing.Size(1385, 573);
            this.Controls.Add(this.lblPaused);
            this.Controls.Add(this.viewPlayer2);
            this.Controls.Add(this.viewPlayer1);
            this.MaximizeBox = false;
            this.Name = "frmGame";
            this.Text = "Chess Timer v.4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGame_FormClosing);
            this.Load += new System.EventHandler(this.frmGame_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmGame_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void KeyPressed(KeyPressEventArgs e)
        {
            if (Settings.Default.EnableWinKey && (e.KeyChar == Settings.Default.WinKey))
            {
                this.gameTimer.Enabled = false;
                frmGameEnd end = new frmGameEnd(this.players[this.playerToMove].playerName, "Was checkmated by the other player", frmGameEnd.Remedy.Ignore);
                end.ShowDialog();
                if (!end.continueGame)
                {
                    base.Close();
                }
                else
                {
                    this.gameTimer.Enabled = true;
                }
            }
            else if (Settings.Default.EnablePauseKey && (e.KeyChar == Settings.Default.PauseKey))
            {
                if (this.lblPaused.Visible)
                {
                    this.gameTimer.Enabled = true;
                    base.Height -= 0x27;
                }
                else
                {
                    this.gameTimer.Enabled = false;
                    base.Height += 0x27;
                }
                this.lblPaused.Visible = !this.lblPaused.Visible;
            }
            else if (!this.lblPaused.Visible)
            {
                this.SwitchPlayerMoving();
            }
        }

        private void SwitchPlayerMoving()
        {
            this.gameTimer.Enabled = false;
            if (this.players[this.playerToMove].isRunning)
            {
                this.players[this.playerToMove].EndTurn();
            }
            this.playerToMove = (this.playerToMove == 0) ? 1 : 0;
            this.players[this.playerToMove].BeginTurn();
            this.gameTimer.Interval = this.startingInterval;
            this.gameTimer.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Player.Status status = this.players[this.playerToMove].Step(TimeSpan.FromMilliseconds((double) this.gameTimer.Interval));
            if (status > Player.Status.GoingOver)
            {
                this.gameTimer.Enabled = false;
                string reason = "";
                frmGameEnd.Remedy none = frmGameEnd.Remedy.None;
                switch (status)
                {
                    case Player.Status.MovesOverInGame:
                        reason = "Total moves over in game exceeded limit.";
                        none = frmGameEnd.Remedy.Ignore;
                        break;

                    case Player.Status.MovesOverInRow:
                        reason = "Moves over in-a-row exceeded limit.";
                        none = frmGameEnd.Remedy.Ignore;
                        break;

                    case Player.Status.GameTimeUsed:
                        reason = "Game time has exceeded limit.";
                        none = frmGameEnd.Remedy.IncreaseGameTime;
                        break;

                    case Player.Status.GameOverTimeUsed:
                        reason = "Total turn over time has exceeded limit.";
                        none = frmGameEnd.Remedy.IncreaseTotalTurnOverTime;
                        break;

                    case Player.Status.TurnOverTimeUsed:
                        reason = "Time gone over this turn exceeded limit.";
                        none = frmGameEnd.Remedy.MoveThenIgnore;
                        break;
                }
                frmGameEnd end = new frmGameEnd(this.players[this.playerToMove].playerName, reason, none);
                end.ShowDialog();
                if (!end.continueGame)
                {
                    base.Close();
                }
                else
                {
                    switch (none)
                    {
                        case frmGameEnd.Remedy.Ignore:
                            this.gameTimer.Enabled = true;
                            break;

                        case frmGameEnd.Remedy.MoveThenIgnore:
                            this.SwitchPlayerMoving();
                            break;

                        case frmGameEnd.Remedy.IncreaseTotalTurnOverTime:
                            this.players[this.playerToMove].IncreaseTotalTurnOverTime(end.increaseBy);
                            this.gameTimer.Enabled = true;
                            break;

                        case frmGameEnd.Remedy.IncreaseGameTime:
                            this.players[this.playerToMove].IncreaseGameTime(end.increaseBy);
                            this.gameTimer.Enabled = true;
                            break;
                    }
                }
            }
            stopwatch.Stop();
        }

        private void viewPlayer1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.KeyPressed(e);
        }

        private void viewPlayer2_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.KeyPressed(e);
        }
    }
}

