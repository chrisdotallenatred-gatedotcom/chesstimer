namespace Chess_Timer_v_4
{
    using System;
    using System.Media;
    using System.Timers;

    public class Game
    {
        private AlertSound alert;
        private Timer beepTimer = new Timer();
        private int makingMove = -1;
        private Player[] players = new Player[2];
        public string soundFileLoc;

        public Game(Player p1, Player p2, AlertSound a, string soundFile)
        {
            this.players[0] = p1;
            this.players[1] = p2;
            this.alert = a;
            this.soundFileLoc = soundFile;
            this.beepTimer.Interval = 1000.0;
            this.beepTimer.Elapsed += new ElapsedEventHandler(this.PlayAlertSound);
        }

        public void PlayAlertSound(object sender, ElapsedEventArgs e)
        {
            switch (this.alert)
            {
                case AlertSound.Asterisk:
                    SystemSounds.Asterisk.Play();
                    return;

                case AlertSound.Beep:
                    SystemSounds.Beep.Play();
                    return;

                case AlertSound.Exclamation:
                    SystemSounds.Exclamation.Play();
                    return;

                case AlertSound.None:
                    break;

                case AlertSound.Other:
                    new SoundPlayer(this.soundFileLoc).Play();
                    break;

                default:
                    return;
            }
        }

        public void Step(TimeSpan stepSize)
        {
            if ((this.players[this.makingMove].Step(stepSize) == Player.Status.GoingOver) && !this.beepTimer.Enabled)
            {
                this.beepTimer.Enabled = true;
            }
        }

        public void SwitchTurns()
        {
            this.beepTimer.Enabled = false;
            if (this.makingMove != -1)
            {
                this.players[this.makingMove].EndTurn();
                this.makingMove = (this.makingMove == 1) ? 0 : 1;
            }
            else
            {
                this.makingMove++;
            }
            this.players[this.makingMove].BeginTurn();
        }

        public enum AlertSound
        {
            Asterisk,
            Beep,
            Exclamation,
            None,
            Other
        }
    }
}

