using System.IO;
using Properties;


namespace Chess_Timer_v_4
{

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Media;
    using System.Security.Permissions;
    using System.Windows.Forms;

    [IsolatedStorageFilePermission(SecurityAction.Demand)]
    public class frmSetup : Form
    {


        private Player[] plyrs;

        /* Create Object Instance */
        // ftp ftpClient = new ftp(@"ftp://supporttest.testnet.red-gate.com/", "chessgate", "chessgate", @"games.pgn");

      //  private ftp ftpClient;



        //   ftp ftpClient = new ftp(@"ftp://waws-prod-db3-013.ftp.azurewebsites.windows.net/site/wwwroot/", @"chessgate\$chessgate", "mtmldfaMlFAJwfiG5jHaoqsHv67HacYubjFxWmdxsaCwpnySN3rouaGbMipq", @"games.pgn");





          //        StreamWriter logfile = new StreamWriter("games.pgn");


          static string games_file = "games.pgn";


          private static FileStream oStream;


      

        private static StreamWriter logfile;

   


          //  static FileStream iStream = new FileStream(games_file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);


       
      //  static StreamReader stream_reader = new System.IO.StreamReader(iStream); 




        private Button btnExit;
        private Button btnPauseKey;
        private Button btnStart;
        private Button btnSwitchStarting;
        private Button btnThemeBg;
        private Button btnThemeTitle;
        private Button btnThemeValue;
        private Button btnWinKey;
        private Button button1;
        private Button button2;
        private Button button3;
        private CheckBox checkBox1;
        private CheckBox chkPauseKey;
        private CheckBox chkWinKey;
        private ComboBox cmbSelectedTheme;
        private IContainer components=null;
        private FlowLayoutPanel flwSetupCon;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label31;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private NumericUpDown numUpdateInterval;
        private OpenFileDialog opensound;
        private Button othersound;
        private Button P1isP2;
        private Button P2isP1;
        private ColorDialog pickClr;
        private PlayerSetup playerSetup1;
        private PlayerSetup playerSetup2;
        private bool playSound;
        private ComboBox sound;
        private Button SwitchPlayerPos;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;




        private ChessMoveHandler cmh;





        public frmSetup()
        {


#if DEBUG
                    File.Delete(games_file);

                    oStream = new FileStream(games_file, FileMode.CreateNew, FileAccess.Write, FileShare.Read);


              /* Create Object Instance */
           // ftpClient = new ftp(@"ftp://ps-chrisal3.red-gate.com/", "chessgate", "chessgate", @"games.pgn");

#else

            oStream = new FileStream(games_file, FileMode.Append, FileAccess.Write, FileShare.Read);

            /* Create Object Instance */
        //    ftpClient = new ftp(@"ftp://supporttest.testnet.red-gate.com/", "chessgate", "chessgate", @"games.pgn");

#endif




           
            
            logfile = new System.IO.StreamWriter(oStream);







          


            //   ftp ftpClient = new ftp(@"ftp://waws-prod-db3-013.ftp.azurewebsites.windows.net/site/wwwroot/", @"chessgate\$chessgate", "mtmldfaMlFAJwfiG5jHaoqsHv67HacYubjFxWmdxsaCwpnySN3rouaGbMipq", @"games.pgn");













           

            this.InitializeComponent();

            this.btnExit.DialogResult = DialogResult.Cancel;

            this.playerSetup1.RightToLeft = RightToLeft.No;
            this.playerSetup2.RightToLeft = RightToLeft.No;
            base.AutoScaleMode = AutoScaleMode.Font;
            base.FormBorderStyle = FormBorderStyle.FixedSingle;


            this.playerSetup1.isStartingPlayer = false;
            this.playerSetup1.Location = new Point(3, 3);
            this.playerSetup1.Name = "playerSetup1";
            this.playerSetup1.PlayerName = "Chris Allen";


            this.playerSetup1.Size = new Size(200, 0x1ac);
            this.playerSetup1.TabIndex = 0;
            this.playerSetup2.isStartingPlayer = false;
            this.playerSetup2.Location = new Point(0xd1, 3);
            this.playerSetup2.Name = "playerSetup2";
            this.playerSetup2.PlayerName = "Clive n James";

            this.playerSetup2.Size = new Size(200, 0x1ac);
            this.playerSetup2.TabIndex = 1;



        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnPauseKey_Click(object sender, EventArgs e)
        {
            GetKey key = new GetKey();
            key.Show();
            if (key.set)
            {
                Settings.Default.PauseKey = key.newKey;
                this.btnPauseKey.Text = "'" + key.newKey + "'";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            plyrs = new Player[] { ((PlayerSetup)this.flwSetupCon.Controls[0]).GetPlayer(), ((PlayerSetup)this.flwSetupCon.Controls[1]).GetPlayer() };
            string playerName = "";
            foreach (Player player in plyrs)
            {
                if (player.playerName == "")
                {
                    MessageBox.Show("A player name field is blank, please input names for both players.", "Name fields are blank", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (playerName == player.playerName)
                {
                    MessageBox.Show("You can't play against yourself, please change the name of one player.", "Name fields are identical", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                playerName = player.playerName;
            }
            frmGame game = new frmGame(plyrs, this.playerSetup1.isStartingPlayer ? 0 : 1);
           


            //write PGN file using players names

            var now = DateTime.Now.ToString("yyyyMMdd");

          

            //First write the info about the pgn file (game)
            //Make sure the info section start with a "[" sign and ends with a "]" sign.
            logfile.WriteLine(@"[Event ""The Main Event""]");
            logfile.WriteLine(@"[Site ""Newnham House""]");
            logfile.WriteLine(@"[Date " + now + "]");

            logfile.WriteLine(@"[Round ""1""]");




            logfile.WriteLine(@"[White " + plyrs[0].playerName + "]");
            logfile.WriteLine(@"[Black " + plyrs[1].playerName + "]");





















            //logfile.WriteLine(@"[Result ""1-0""]");
            //logfile.WriteLine(@"[ECO ""A50""]");
            //logfile.WriteLine(@"[PlyCount ""25""]");

            //  logfile.Close();


            logfile.Flush();


            try
            {



                //  ftpSetup();

                /* Upload a File */
               // ftpClient.upload();



            }
            catch
            {


                MessageBox.Show("Problem with FTP setup");



            }


            try
            {

                cmh = new ChessMoveHandler(logfile, /*ftpClient*/null,game);

             


            }
            catch
            {


                MessageBox.Show("Problem with DGT Chess Board");



            }


           





            base.Hide();
            game.ShowDialog();
            base.Show();
            game.Dispose();







        }



        private void ftpSetup()
        {




            /* Upload a File */
           // ftpClient.upload(@"games.pgn", iStream);

            ///* Download a File */
            //ftpClient.download("etc/test.txt", @"C:\Users\metastruct\Desktop\test.txt");

            ///* Delete a File */
            //ftpClient.delete("etc/test.txt");

            ///* Rename a File */
            //ftpClient.rename("etc/test.txt", "test2.txt");

            ///* Create a New Directory */
            //ftpClient.createDirectory("etc/test");

            ///* Get the Date/Time a File was Created */
            //string fileDateTime = ftpClient.getFileCreatedDateTime("etc/test.txt");
            //Console.WriteLine(fileDateTime);

            ///* Get the Size of a File */
            //string fileSize = ftpClient.getFileSize("etc/test.txt");
            //Console.WriteLine(fileSize);

            ///* Get Contents of a Directory (Names Only) */
            //string[] simpleDirectoryListing = ftpClient.directoryListDetailed("/etc");
            //for (int i = 0; i < simpleDirectoryListing.Count(); i++) { Console.WriteLine(simpleDirectoryListing[i]); }

            ///* Get Contents of a Directory with Detailed File/Directory Info */
            //string[] detailDirectoryListing = ftpClient.directoryListDetailed("/etc");
            //for (int i = 0; i < detailDirectoryListing.Count(); i++) { Console.WriteLine(detailDirectoryListing[i]); }
            ///* Release Resources */
            //ftpClient = null;










        }


        private void btnSwitchStarting_Click(object sender, EventArgs e)
        {
            foreach (PlayerSetup setup in this.flwSetupCon.Controls)
            {
                setup.isStartingPlayer = !setup.isStartingPlayer;
            }
        }

        private void btnWinKey_Click(object sender, EventArgs e)
        {
            GetKey key = new GetKey();
            key.Show();
            if (key.set)
            {
                Settings.Default.WinKey = key.newKey;
                this.btnWinKey.Text = "'" + key.newKey + "'";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            this.pickClr.Color = button.BackColor;
            if (this.pickClr.ShowDialog() == DialogResult.OK)
            {
                button.BackColor = this.pickClr.Color;
                string text = button.Text;
                if (text != null)
                {
                    if (!(text == "Title"))
                    {
                        if (!(text == "Value"))
                        {
                            if (text == "Background")
                            {
                                Settings.Default.customThemeBgColour = this.pickClr.Color;
                            }
                            return;
                        }
                    }
                    else
                    {
                        Settings.Default.customThemeTitleColour = this.pickClr.Color;
                        return;
                    }
                    Settings.Default.customThemeValueColour = this.pickClr.Color;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save your changes, you will not be able to cancel these changes.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Settings.Default.Save();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            this.ShowSettings();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cacel your changes, you will not be able to restore these changes.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Settings.Default.Reload();
            }
            this.ShowSettings();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.showSplashOnExit = this.checkBox1.Checked;
        }

        private void chkPauseKey_CheckedChanged(object sender, EventArgs e)
        {
            this.chkPauseKey.Checked = Settings.Default.EnablePauseKey;
        }

        private void chkWinKey_CheckedChanged(object sender, EventArgs e)
        {
            this.chkWinKey.Checked = Settings.Default.EnableWinKey;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbSelectedTheme.Text == "Space Race")
            {
                Settings.Default.selectedTheme = 0;
            }
            else if (this.cmbSelectedTheme.Text == "Nostalgia")
            {
                Settings.Default.selectedTheme = 1;
            }
            else if (this.cmbSelectedTheme.Text == "Custom")
            {
                Settings.Default.selectedTheme = 2;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);

         //   logfile.Close();

        }

        private void frmSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.P1isP2 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.P2isP1 = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.SwitchPlayerPos = new System.Windows.Forms.Button();
            this.flwSetupCon = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSwitchStarting = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkPauseKey = new System.Windows.Forms.CheckBox();
            this.btnPauseKey = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.chkWinKey = new System.Windows.Forms.CheckBox();
            this.numUpdateInterval = new System.Windows.Forms.NumericUpDown();
            this.btnWinKey = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThemeTitle = new System.Windows.Forms.Button();
            this.btnThemeValue = new System.Windows.Forms.Button();
            this.btnThemeBg = new System.Windows.Forms.Button();
            this.cmbSelectedTheme = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sound = new System.Windows.Forms.ComboBox();
            this.othersound = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.opensound = new System.Windows.Forms.OpenFileDialog();
            this.pickClr = new System.Windows.Forms.ColorDialog();
            this.playerSetup1 = new Chess_Timer_v_4.PlayerSetup();
            this.playerSetup2 = new Chess_Timer_v_4.PlayerSetup();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flwSetupCon.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateInterval)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(430, 524);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.P1isP2);
            this.tabPage1.Controls.Add(this.btnExit);
            this.tabPage1.Controls.Add(this.P2isP1);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Controls.Add(this.SwitchPlayerPos);
            this.tabPage1.Controls.Add(this.flwSetupCon);
            this.tabPage1.Controls.Add(this.btnSwitchStarting);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(422, 498);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Setup";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // P1isP2
            // 
            this.P1isP2.Location = new System.Drawing.Point(138, 467);
            this.P1isP2.Name = "P1isP2";
            this.P1isP2.Size = new System.Drawing.Size(64, 23);
            this.P1isP2.TabIndex = 14;
            this.P1isP2.Text = "P1 <— P2";
            this.P1isP2.UseVisualStyleBackColor = true;
            this.P1isP2.Click += new System.EventHandler(this.P1isP2_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(269, 438);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(143, 23);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Quit Chess Timer v.4";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // P2isP1
            // 
            this.P2isP1.Location = new System.Drawing.Point(138, 438);
            this.P2isP1.Name = "P2isP1";
            this.P2isP1.Size = new System.Drawing.Size(64, 23);
            this.P2isP1.TabIndex = 15;
            this.P2isP1.Text = "P1 —> P2";
            this.P2isP1.UseVisualStyleBackColor = true;
            this.P2isP1.Click += new System.EventHandler(this.P2isP1_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Lime;
            this.btnStart.Location = new System.Drawing.Point(269, 467);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(143, 23);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Accept These Settings";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // SwitchPlayerPos
            // 
            this.SwitchPlayerPos.Location = new System.Drawing.Point(8, 467);
            this.SwitchPlayerPos.Name = "SwitchPlayerPos";
            this.SwitchPlayerPos.Size = new System.Drawing.Size(124, 23);
            this.SwitchPlayerPos.TabIndex = 12;
            this.SwitchPlayerPos.Text = "Switch Player Positions";
            this.SwitchPlayerPos.UseVisualStyleBackColor = true;
            this.SwitchPlayerPos.Click += new System.EventHandler(this.SwitchPlayerPos_Click);
            // 
            // flwSetupCon
            // 
            this.flwSetupCon.Controls.Add(this.playerSetup1);
            this.flwSetupCon.Controls.Add(this.playerSetup2);
            this.flwSetupCon.Dock = System.Windows.Forms.DockStyle.Top;
            this.flwSetupCon.Location = new System.Drawing.Point(3, 3);
            this.flwSetupCon.Name = "flwSetupCon";
            this.flwSetupCon.Size = new System.Drawing.Size(416, 433);
            this.flwSetupCon.TabIndex = 0;
            // 
            // btnSwitchStarting
            // 
            this.btnSwitchStarting.Location = new System.Drawing.Point(8, 438);
            this.btnSwitchStarting.Name = "btnSwitchStarting";
            this.btnSwitchStarting.Size = new System.Drawing.Size(124, 23);
            this.btnSwitchStarting.TabIndex = 13;
            this.btnSwitchStarting.Text = "Switch Starting Player";
            this.btnSwitchStarting.UseVisualStyleBackColor = true;
            this.btnSwitchStarting.Click += new System.EventHandler(this.btnSwitchStarting_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(422, 498);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Preferences";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(212, 467);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Cancel Changes";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 467);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Restore Defaults";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 467);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Save Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(8, 358);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(406, 67);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Misc.";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(245, 27);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(155, 17);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "Show splash screen on exit";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Show Splash:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkPauseKey);
            this.groupBox2.Controls.Add(this.btnPauseKey);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.chkWinKey);
            this.groupBox2.Controls.Add(this.numUpdateInterval);
            this.groupBox2.Controls.Add(this.btnWinKey);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(8, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 184);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gameplay";
            // 
            // chkPauseKey
            // 
            this.chkPauseKey.AutoSize = true;
            this.chkPauseKey.Location = new System.Drawing.Point(329, 151);
            this.chkPauseKey.Name = "chkPauseKey";
            this.chkPauseKey.Size = new System.Drawing.Size(71, 17);
            this.chkPauseKey.TabIndex = 17;
            this.chkPauseKey.Text = "Allow use";
            this.chkPauseKey.UseVisualStyleBackColor = true;
            this.chkPauseKey.CheckedChanged += new System.EventHandler(this.chkPauseKey_CheckedChanged);
            // 
            // btnPauseKey
            // 
            this.btnPauseKey.Location = new System.Drawing.Point(325, 122);
            this.btnPauseKey.Name = "btnPauseKey";
            this.btnPauseKey.Size = new System.Drawing.Size(75, 23);
            this.btnPauseKey.TabIndex = 16;
            this.btnPauseKey.Text = "\'\'";
            this.btnPauseKey.UseVisualStyleBackColor = true;
            this.btnPauseKey.Click += new System.EventHandler(this.btnPauseKey_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Pause Key:";
            // 
            // chkWinKey
            // 
            this.chkWinKey.AutoSize = true;
            this.chkWinKey.Location = new System.Drawing.Point(329, 89);
            this.chkWinKey.Name = "chkWinKey";
            this.chkWinKey.Size = new System.Drawing.Size(71, 17);
            this.chkWinKey.TabIndex = 14;
            this.chkWinKey.Text = "Allow use";
            this.chkWinKey.UseVisualStyleBackColor = true;
            this.chkWinKey.CheckedChanged += new System.EventHandler(this.chkWinKey_CheckedChanged);
            // 
            // numUpdateInterval
            // 
            this.numUpdateInterval.Location = new System.Drawing.Point(280, 26);
            this.numUpdateInterval.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numUpdateInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpdateInterval.Name = "numUpdateInterval";
            this.numUpdateInterval.Size = new System.Drawing.Size(120, 20);
            this.numUpdateInterval.TabIndex = 13;
            this.numUpdateInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUpdateInterval.ValueChanged += new System.EventHandler(this.numUpdateInterval_ValueChanged);
            // 
            // btnWinKey
            // 
            this.btnWinKey.Location = new System.Drawing.Point(325, 60);
            this.btnWinKey.Name = "btnWinKey";
            this.btnWinKey.Size = new System.Drawing.Size(75, 23);
            this.btnWinKey.TabIndex = 13;
            this.btnWinKey.Text = "\'\'";
            this.btnWinKey.UseVisualStyleBackColor = true;
            this.btnWinKey.Click += new System.EventHandler(this.btnWinKey_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Update interval:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Win Key:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnThemeTitle);
            this.groupBox1.Controls.Add(this.btnThemeValue);
            this.groupBox1.Controls.Add(this.btnThemeBg);
            this.groupBox1.Controls.Add(this.cmbSelectedTheme);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.sound);
            this.groupBox1.Controls.Add(this.othersound);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 156);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stylistic";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Custom Sound:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Custom Theme:";
            // 
            // btnThemeTitle
            // 
            this.btnThemeTitle.Location = new System.Drawing.Point(163, 114);
            this.btnThemeTitle.Name = "btnThemeTitle";
            this.btnThemeTitle.Size = new System.Drawing.Size(75, 23);
            this.btnThemeTitle.TabIndex = 8;
            this.btnThemeTitle.Text = "Title";
            this.btnThemeTitle.UseVisualStyleBackColor = true;
            this.btnThemeTitle.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnThemeValue
            // 
            this.btnThemeValue.Location = new System.Drawing.Point(244, 114);
            this.btnThemeValue.Name = "btnThemeValue";
            this.btnThemeValue.Size = new System.Drawing.Size(75, 23);
            this.btnThemeValue.TabIndex = 8;
            this.btnThemeValue.Text = "Value";
            this.btnThemeValue.UseVisualStyleBackColor = true;
            this.btnThemeValue.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnThemeBg
            // 
            this.btnThemeBg.Location = new System.Drawing.Point(325, 114);
            this.btnThemeBg.Name = "btnThemeBg";
            this.btnThemeBg.Size = new System.Drawing.Size(75, 23);
            this.btnThemeBg.TabIndex = 8;
            this.btnThemeBg.Text = "Background";
            this.btnThemeBg.UseVisualStyleBackColor = true;
            this.btnThemeBg.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbSelectedTheme
            // 
            this.cmbSelectedTheme.FormattingEnabled = true;
            this.cmbSelectedTheme.Items.AddRange(new object[] {
            "Space Race",
            "Nostalgia",
            "Custom"});
            this.cmbSelectedTheme.Location = new System.Drawing.Point(261, 87);
            this.cmbSelectedTheme.Name = "cmbSelectedTheme";
            this.cmbSelectedTheme.Size = new System.Drawing.Size(139, 21);
            this.cmbSelectedTheme.TabIndex = 7;
            this.cmbSelectedTheme.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Theme:";
            // 
            // sound
            // 
            this.sound.FormattingEnabled = true;
            this.sound.Items.AddRange(new object[] {
            "Exclamation",
            "Asterisk",
            "Beep",
            "None"});
            this.sound.Location = new System.Drawing.Point(261, 21);
            this.sound.Name = "sound";
            this.sound.Size = new System.Drawing.Size(139, 21);
            this.sound.TabIndex = 4;
            this.sound.SelectedIndexChanged += new System.EventHandler(this.sound_SelectedIndexChanged);
            // 
            // othersound
            // 
            this.othersound.Location = new System.Drawing.Point(325, 48);
            this.othersound.Name = "othersound";
            this.othersound.Size = new System.Drawing.Size(75, 23);
            this.othersound.TabIndex = 5;
            this.othersound.Text = "Other...";
            this.othersound.UseVisualStyleBackColor = true;
            this.othersound.Click += new System.EventHandler(this.othersound_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(6, 22);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(85, 15);
            this.label31.TabIndex = 3;
            this.label31.Text = "Alert Sound:";
            // 
            // opensound
            // 
            this.opensound.FileName = "Alert sound";
            this.opensound.Filter = "Sound files|*.wav";
            // 
            // playerSetup1
            // 
            this.playerSetup1.isStartingPlayer = false;
            this.playerSetup1.Location = new System.Drawing.Point(3, 3);
            this.playerSetup1.Name = "playerSetup1";
            this.playerSetup1.PlayerName = "Chris Allen";
            this.playerSetup1.Size = new System.Drawing.Size(200, 428);
            this.playerSetup1.TabIndex = 0;
            this.playerSetup1.Load += new System.EventHandler(this.playerSetup1_Load);
            // 
            // playerSetup2
            // 
            this.playerSetup2.isStartingPlayer = false;
            this.playerSetup2.Location = new System.Drawing.Point(209, 3);
            this.playerSetup2.Name = "playerSetup2";
            this.playerSetup2.PlayerName = "Chris Allen";
            this.playerSetup2.Size = new System.Drawing.Size(200, 428);
            this.playerSetup2.TabIndex = 1;
            // 
            // frmSetup
            // 
            this.AcceptButton = this.btnStart;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(430, 524);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "frmSetup";
            this.ShowIcon = false;
            this.Text = "Setup";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSetup_FormClosed);
            this.Load += new System.EventHandler(this.Setup_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.flwSetupCon.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateInterval)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void numUpdateInterval_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.updateInterval = (int) this.numUpdateInterval.Value;
        }

        private void othersound_Click(object sender, EventArgs e)
        {
            if (this.opensound.ShowDialog() == DialogResult.OK)
            {
                SoundPlayer player = new SoundPlayer(this.opensound.FileName);
                try
                {
                    player.Play();
                    this.sound.Text = "Other";
                   // Settings.Default.WarningSound = 3;
                  //  Settings.Default.CustomWarningSound = player;
                }
                catch
                {
                    MessageBox.Show("Error with sound file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.sound.Text = "Exclamation";
                }
            }
        }

        private void P1isP2_Click(object sender, EventArgs e)
        {
            ((PlayerSetup) this.flwSetupCon.Controls[0]).Mimic((PlayerSetup) this.flwSetupCon.Controls[1]);
        }

        private void P2isP1_Click(object sender, EventArgs e)
        {
            ((PlayerSetup) this.flwSetupCon.Controls[1]).Mimic((PlayerSetup) this.flwSetupCon.Controls[0]);
        }

        private void Setup_Load(object sender, EventArgs e)
        {
            this.playerSetup1.isStartingPlayer = true;
            this.ShowSettings();
        }

        private void ShowSettings()
        {
            this.playSound = false;
            string[] strArray = new string[] { "None", "Exclamation", "Asterisk", "Beep", "Other" };
            //if (((Settings.Default.WarningSound + 1) > strArray.Length) || (Settings.Default.WarningSound < -1))
            //{
            //    Settings.Default.WarningSound = 1;
            //}
            //this.sound.Text = strArray[Settings.Default.WarningSound + 1];
            this.sound.Text = strArray[1];
            string[] strArray2 = new string[] { "Space Race", "Nostalgia", "Custom" };
            if (((Settings.Default.selectedTheme + 1) > strArray2.Length) || (Settings.Default.selectedTheme < 0))
            {
                Settings.Default.selectedTheme = 0;
            }
            this.cmbSelectedTheme.Text = strArray2[Settings.Default.selectedTheme];
            this.btnThemeBg.BackColor = Settings.Default.customThemeBgColour;
            this.btnThemeTitle.BackColor = Settings.Default.customThemeTitleColour;
            this.btnThemeValue.BackColor = Settings.Default.customThemeValueColour;
            if (Settings.Default.updateInterval < this.numUpdateInterval.Minimum)
            {
                Settings.Default.updateInterval = (int) this.numUpdateInterval.Minimum;
            }
            else if (Settings.Default.updateInterval > this.numUpdateInterval.Maximum)
            {
                Settings.Default.updateInterval = (int) this.numUpdateInterval.Maximum;
            }
            this.numUpdateInterval.Value = Settings.Default.updateInterval;
            this.btnWinKey.Text = "'" + Settings.Default.WinKey + "'";
            this.btnPauseKey.Text = "'" + Settings.Default.PauseKey + "'";
            this.chkWinKey.Checked = Settings.Default.EnableWinKey;
            this.chkPauseKey.Checked = Settings.Default.EnablePauseKey;
            this.checkBox1.Checked = Settings.Default.showSplashOnExit;
            this.playSound = true;
        }

        private void sound_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.sound.Text == "Beep")
            {
                Settings.Default.WarningSound = 2;
                if (this.playSound)
                {
                    SystemSounds.Beep.Play();
                }
            }
            else if (this.sound.Text == "Asterisk")
            {
                Settings.Default.WarningSound = 1;
                if (this.playSound)
                {
                    SystemSounds.Asterisk.Play();
                }
            }
            else if (this.sound.Text == "Exclamation")
            {
                Settings.Default.WarningSound = 0;
                if (this.playSound)
                {
                    SystemSounds.Exclamation.Play();
                }
            }
            else if (this.sound.Text == "Other")
            {
                Settings.Default.WarningSound = 3;
            }
            else if (this.sound.Text == "None")
            {
                Settings.Default.WarningSound = -1;
            }
        }

        private void SwitchPlayerPos_Click(object sender, EventArgs e)
        {
            PlayerSetup setup = (PlayerSetup) this.flwSetupCon.Controls[0];
            this.flwSetupCon.Controls.RemoveAt(0);
            this.flwSetupCon.Controls.Add(setup);
        }

        private void playerSetup1_Load(object sender, EventArgs e)
        {

        }
    }
}

