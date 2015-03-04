namespace Chess_Timer_v_4
{
    using Chess_Timer_v_4.Properties;
    using System;
    using System.Drawing;
    using System.Media;
    using System.Windows.Forms;

    public class Player
    {
        private bool _carryOver;
        private bool _carrySpare;
        private bool _gameLimit;
        private TimeSpan _gameTime;
        private TimeSpan _increment;
        private bool _isRunning;
        private bool _moveLimit;
        private int _movesOverAllowed;
        private int _movesOverAllowedRow;
        private bool _overTimeGameLimit;
        private bool _overTimeTurnLimit;
        private string _playerName;
        private TimeSpan _singleCutOff;
        private TimeSpan _totalCutOff;
        private TimeSpan _turnTime;
        private TimeSpan carriedTime = new TimeSpan();
        public ViewTime.KeyPressedPointer kpp;
        private int lastSecond;
        private int lastSecondGame;
        private int lastSecondOver;
        private int movesOver;
        private int movesOverRow;
        private int movesThisGame;
        private double msToNextBeep;
        private TimeSpan nothing = new TimeSpan(0, 0, 0);
        private TimeSpan thisGame = new TimeSpan();
        private TimeSpan thisTurn = new TimeSpan();
        private TimeSpan timeOver = new TimeSpan();
        private bool updatedMovesOverThisTurn;
        private ViewPlayer vp;

        public Player(string name, TimeSpan turnTime, TimeSpan gameTime, TimeSpan increment, TimeSpan singleCutOff, TimeSpan totalCutOff, bool carryOver, bool carrySpare, int movesOverAllowed, int movesOverAllowedRows)
        {
            this._playerName = name;
            this._turnTime = turnTime;
            this._gameTime = gameTime;
            this._increment = increment;
            this._singleCutOff = singleCutOff;
            this._totalCutOff = totalCutOff;
            this._carryOver = carryOver;
            this._carrySpare = carrySpare;
            this._movesOverAllowed = movesOverAllowed;
            this._movesOverAllowedRow = movesOverAllowedRows;
            this._moveLimit = this._turnTime != this.nothing;
            this._gameLimit = this._gameTime != this.nothing;
            this._overTimeTurnLimit = this._singleCutOff != this.nothing;
            this._overTimeGameLimit = this._totalCutOff != this.nothing;
        }

        public void Beep()
        {
            this.msToNextBeep = 1000.0;
            if (Settings.Default.WarningSound != -1)
            {
                if (Settings.Default.WarningSound == 3)
                {
                    try
                    {
                        Settings.Default.CustomWarningSound.Play();
                    }
                    catch
                    {
                        Settings.Default.WarningSound = 1;
                    }
                }
                if (Settings.Default.WarningSound == 0)
                {
                    SystemSounds.Exclamation.Play();
                }
                else if (Settings.Default.WarningSound == 1)
                {
                    SystemSounds.Asterisk.Play();
                }
                else if (Settings.Default.WarningSound == 2)
                {
                    SystemSounds.Beep.Play();
                }
            }
        }

        public void BeginTurn()
        {
            this._isRunning = true;
            this.thisTurn = this.nothing;
            this.thisTurn = -this.carriedTime;
            this.carriedTime = this.nothing;
            this._gameTime = this._gameTime.Add(this._increment);
            this.updatedMovesOverThisTurn = false;
            this.msToNextBeep = 0.0;
            this.lastSecond = 0;
            this.lastSecondOver = 0;
            this.lastSecondGame = 0;
            this.movesThisGame++;
            this.vp.NewGo(this._turnTime, this._singleCutOff);
        }

        public void EndTurn()
        {
            this.carriedTime = this._turnTime - this.thisTurn;
            if ((this.carriedTime > this.nothing) && !this._carrySpare)
            {
                this.carriedTime = this.nothing;
            }
            if ((this.carriedTime < this.nothing) && !this._carryOver)
            {
                this.carriedTime = this.nothing;
            }
            if (!this.updatedMovesOverThisTurn)
            {
                this.movesOverRow = 0;
            }
            this._isRunning = false;
            this.vp.EndGo(this.carriedTime, this.movesThisGame, this.thisGame.TotalSeconds / ((double) this.movesThisGame), this.movesOverRow);
        }

        public void IncreaseGameTime(TimeSpan byAmmount)
        {
            this._gameTime = this._gameTime.Add(byAmmount);
        }

        public void IncreaseTotalTurnOverTime(TimeSpan byAmmount)
        {
            this._totalCutOff = this._totalCutOff.Add(byAmmount);
        }

        private void SetupViewer()
        {
            this.vp.SetUp(this.playerName, this._carryOver, this._carrySpare, this._singleCutOff, this._totalCutOff, this._movesOverAllowed, this._movesOverAllowedRow, this._gameTime, this._turnTime, this.kpp, this._moveLimit);
            if (Settings.Default.selectedTheme == 1)
            {
                this.vp.valuesClr = SystemColors.ControlText;
                this.vp.titlesClr = SystemColors.ControlText;
                this.vp.bgClr = SystemColors.Control;
                this.vp.BorderStyle = BorderStyle.Fixed3D;
                this.vp.EndGo(TimeSpan.Zero, 0, 0.0, 0);
            }
            else if (Settings.Default.selectedTheme == 2)
            {
                this.vp.valuesClr = Settings.Default.customThemeValueColour;
                this.vp.titlesClr = Settings.Default.customThemeTitleColour;
                this.vp.bgClr = Settings.Default.customThemeBgColour;
                this.vp.EndGo(TimeSpan.Zero, 0, 0.0, 0);
            }
        }

        public Status Step(TimeSpan stepSize)
        {
            this.thisTurn += stepSize;
            this.thisGame += stepSize;
            if (this._moveLimit)
            {
                if (!this.updatedMovesOverThisTurn)
                {
                    if (this.thisTurn > this._turnTime)
                    {
                        this.updatedMovesOverThisTurn = true;
                        this.movesOver++;
                        this.movesOverRow++;
                        this.vp.StartedGoingOver(this.movesOver, this.movesOverRow);
                        if ((this._movesOverAllowed != 0) && (this.movesOver >= this._movesOverAllowed))
                        {
                            return Status.MovesOverInGame;
                        }
                        if ((this._movesOverAllowedRow != 0) && (this._movesOverAllowedRow <= this.movesOverRow))
                        {
                            return Status.MovesOverInRow;
                        }
                        this.Beep();
                    }
                }
                else
                {
                    this.timeOver += stepSize;
                    if (this.lastSecondOver < this.timeOver.TotalSeconds)
                    {
                        this.lastSecondOver = (int) (this.timeOver.TotalSeconds + 1.0);
                        TimeSpan ts = -(this._turnTime - this.thisTurn);
                        this.vp.TimeGoingOverUpdate(this.timeOver, this._overTimeTurnLimit ? this._singleCutOff.Subtract(ts) : TimeSpan.Zero, this._overTimeGameLimit ? this._totalCutOff.Subtract(this.timeOver) : TimeSpan.Zero);
                        if (this._overTimeTurnLimit && (ts >= this._singleCutOff))
                        {
                            return Status.TurnOverTimeUsed;
                        }
                        if (this._overTimeGameLimit && (this.timeOver >= this._totalCutOff))
                        {
                            return Status.GameOverTimeUsed;
                        }
                    }
                    this.msToNextBeep -= stepSize.TotalMilliseconds;
                    if (this.msToNextBeep <= 0.0)
                    {
                        this.Beep();
                    }
                }
            }
            if (this.lastSecondGame < this.thisGame.TotalSeconds)
            {
                this.lastSecondGame = ((int) this.thisGame.TotalSeconds) + 1;
                this.vp.GameTimeUpdate(this.thisGame, this._gameLimit ? this._gameTime.Subtract(this.thisGame) : this.nothing);
                if (this._gameLimit && (this.thisGame > this._gameTime))
                {
                    return Status.GameTimeUsed;
                }
            }
            if (this.lastSecond < this.thisTurn.TotalSeconds)
            {
                this.lastSecond = ((int) this.thisTurn.TotalSeconds) + 1;
                this.vp.TurnTimeUpdate(this.thisTurn, this._moveLimit ? this._turnTime.Subtract(this.thisTurn) : this.nothing);
            }
            if (!this.updatedMovesOverThisTurn)
            {
                return Status.Normal;
            }
            return Status.GoingOver;
        }

        public bool isRunning
        {
            get
            {
                return this._isRunning;
            }
        }

        public string playerName
        {
            get
            {
                return this._playerName;
            }
        }

        public ViewPlayer viewer
        {
            get
            {
                return this.vp;
            }
            set
            {
                this.vp = value;
                if (this.kpp == null)
                {
                    throw new NullReferenceException("Player.kpp must be set before calling Player.SetupViewer");
                }
                this.SetupViewer();
            }
        }

        public enum Status
        {
            Normal,
            GoingOver,
            MovesOverInGame,
            MovesOverInRow,
            GameTimeUsed,
            GameOverTimeUsed,
            TurnOverTimeUsed
        }
    }
}

