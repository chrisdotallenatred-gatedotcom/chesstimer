using System;
/*
				 \\|//
				 (o o)
--------------ooO-(_)-Ooo--------------
Copy rights 2004 By Gregory A. Prentice
					  Ooo.
--------------.ooO----(  )-------------
			  (  )    (_/
			   \_)
If you wish to use this code in any part
I request that you simply let me know where
and give the author credit for his work.
gregoryprentice@comcast.net
www.cafechess.org
*/

using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
//using ChessBoardCtrl;
//using ChessLibrary;
//using CustomControls;
//using DllSharp;
//using PCAD.CAT;



namespace Chess_Timer_v_4
{
	public class ChessMoveHandler
	{


		private string white_putative_move = "";

		private string black_putative_move = "";


		private frmGame game_time;



		public bool game_started = false;


		public bool white_takebackactive = false;

		public bool black_takebackactive = false;

		private StreamWriter logfile;

		//private ftp ftpClient;


		//private static FileStream iStream;


		const int VK_UP = 0x26; //up key
		const int VK_DOWN = 0x28;  //down key

		const int VK_CAPITAL = 0x14; //CAPS Lock (for white)


		const int VK_RETURN = 0x0D; //CAPS Lock (for black)


		const int VK_LEFT = 0x25;
		const int VK_RIGHT = 0x27;
		const uint KEYEVENTF_KEYUP = 0x0002;
		const uint KEYEVENTF_EXTENDEDKEY = 0x0001;



		#region fields

		//	private const string dllName = @"X:\DGT\Chess Timer v.3.3\bin\Debug\dgtebdll.dll"; // for 64-bit it becomes dgtebdll64.dll

		private const string dllName = @"dgtebdll64.dll"; // for 64-bit it becomes dgtebdll64.dll


		//  private const string dllName = @"X:\DGT\CTimerConsole\bin\Debug\dgtebdll.dll"; // for 64-bit it becomes dgtebdll64.dll




//		private const string dllName = @"X:\DGT\CTimerConsole\bin\Debug\dgtebdll64.dll"; // for 64-bit it becomes dgtebdll64.dll





		




	//	private const string dllName = @"dgtebdll64.dll"; // for 64-bit it becomes dgtebdll64.dll


	 //   const string dllName = @"X:\DGT\Chess Timer v.4\bin\Debug\dgtebdll64.dll";


		//   private static int moveCount = 0;

		//initialise to starting position


		// ProgramEngine prog = new ProgramEngine();

		//  private readonly CEngineProcess p = new CEngineProcess("TogaII131.exe");
		private FC bClockCallbackInstance; // The instance of the callback
		//EngineProcess p1 = new CEngineProcess("TogaII131.exe");


		//    private TextBox bbText;
		//   private Label blackstime; // The instance of the callback
		private /*static*/ FC bmCallbackInstance; // The instance of the callback



		private /*static*/ FC ngCallbackInstance; // The instance of the callback


		private /*static*/ FCintptr wtbCallbackInstance; // The instance of the callback


		private /*static*/ FCintptr btbCallbackInstance; // The instance of the callback

		//private Button button1;
		//private Button button2;
		//private ChessBoard chessBoard1;
		//private IContainer components;
		//private FormMain customfileopen = new FormMain();
		//private bool dllOk;
		//private ComboBox fenTXT;
		//private FlowLayoutPanel flowLayoutPanel1;
		//private FlowLayoutPanel flowLayoutPanel2;
		//private GameNavigation gameNavigation;
		//private int image_size = 100;
		//private Boolean is_firstScan = true;
		//private Label label1;
		//private Label label2;
		private string latestFEN = "";
		//    private Panel moveColor;
		//private string oldFEN = @"rnbkqbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";
		//private OpenFileDialog openFileDialog1;
		//private OpenFileDialog openFileDialog2;
		//private OpenFileDialog openFileDialog3;
		//private PictureBox pictureBox1;
		//private PictureBox pictureBox2;
		private FC scanCallbackInstance; // The instance of the callback


		//private FC scanCallbackInstance; 

		private FC wClockCallbackInstance; // The instance of the callback
		//      private bool white_winning = true;
		//     private Label whitestime;
		private /*static*/ FC wmCallbackInstance;

		//	private delegate int FC(string text);

		private delegate int FC(string text);

		private delegate int FCintptr(IntPtr text);


		//private FC scanCallbackInstance; // The instance of the callback

		//private FC wmCallbackInstance; // The instance of the callback

		//private FC bmCallbackInstance; // The instance of the callback

		#endregion fields

		#region DLLShit
		public void DisposeLogFile(bool disposable)
		{


			//Lastly write the result
			//logfile.WriteLine("1-0");
			//Any chess program that reads PGN files should now be able to import your chess game!



			//logfile.Close();

		}

		//public void ChessDisplayInit()
		//{


		  

		//}


		private /*static*/ int wClockCallbackHandler(string time)
		{
			// textBox.Text += "WHITE MOVE: " + move + Environment.NewLine;


			//whitestime.Text = time;


			//updateBoard(latestFEN);
			//moveColor.BackColor = Color.Black;


			return 0;
		}


		private /*static*/ int bClockCallbackHandler(string time)
		{
			// textBox.Text += "WHITE MOVE: " + move + Environment.NewLine;

			//updateBoard(latestFEN);
			//moveColor.BackColor = Color.Black;


			//blackstime.Text = time;


			return 0;
		}









		public void PrependString(string value, FileStream file)
		{
			var buffer = new byte[file.Length];

			while (file.Read(buffer, 0, buffer.Length) != 0)
			{
			}

			if (!file.CanWrite)
				throw new ArgumentException("The specified file cannot be written.", "file");

			file.Position = 0;
			var data = Encoding.Unicode.GetBytes(value);
			file.SetLength(buffer.Length + data.Length);
			file.Write(data, 0, data.Length);
			file.Write(buffer, 0, buffer.Length);
		}

		// public  void Prepend(this FileStream file, string value)
		// {
		//     PrependString(value, file);
		// }

	   
	 

	

//string filePath = path + "\\log.log";
//string tempFilePath = path + "\\temp.log";
//string backupFilePath = path + "\\backup.log";















		int movecount = 0;
		int plycount = 0;

		void logmoveB(string move)
		{

			plycount++;

			//movecount++;

			// PrependString(move + " ", (FileStream)logfile);



			logfile.WriteLine(move + " ");

			logfile.Flush();
			//Press the key
			//	keybd_event((byte)VK_RETURN, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);


			// game_time.KeyPressed(new KeyPressEventArgs(' '));


		//	ftpClient.upload();


		}


		private bool first_move = true;
		void logmoveW(string move)
		{





			plycount++; movecount++;



			//using (var file = File.Open("yourtext.txt", FileMode.Open, FileAccess.ReadWrite))
			//{
			//    file.Prepend("Text you want to write.");
			//}


			//using (var writer = new StreamWriter(tempFilePath, false))
			//{
			//    // Write whatever you want to prepend
			//    writer.WriteLine("Hi");
			//}

			//using (var oldFile = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
			//{
			//    using (var tempFile = new FileStream(tempFilePath, FileMode.Append, FileAccess.Write, FileShare.Read))
			//    {
			//        oldFile.CopyTo(tempFile);
			//    }
			//}

			//File.Replace(tempFilePath, filePath, backupFilePath);


			logfile.WriteLine(movecount + ". " + move + " "); logfile.Flush();


			//Press the key
			//keybd_event((byte)VK_RETURN, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);




			//ftpClient.upload();

			first_move = false;

		}


		private /*static*/ int wmCallbackHandler(string move)
		{
			// textBox.Text += "WHITE MOVE: " + move + Environment.NewLine;

			// if (game_started && !black_takebackactive)

			if (game_started)
			{




				//logmoveW(move);


				if (!white_takebackactive)
				{
					game_time.KeyPressed(new KeyPressEventArgs(' '));

					if (!first_move)
					{



						logmoveB(black_putative_move);



					}

				}

				white_putative_move = move;

				//white_putative_move = move;

			}

			//updateBoard(latestFEN);
			//     moveColor.BackColor = Color.Black;



			black_takebackactive = false;
			return 0;
		}

		private /*static*/ int bmCallbackHandler(string move)
		{
			//textBox.Text += "BLACK MOVE: " + move + Environment.NewLine;
			// if (game_started && !white_takebackactive)
			if (game_started)
			{




				if (!black_takebackactive)
				{


					game_time.KeyPressed(new KeyPressEventArgs(' '));


					logmoveW(white_putative_move);
				}

				black_putative_move = move;

				// logmoveB(move);
			}

			//	updateBoard(latestFEN);

			//moveColor.BackColor = Color.White;


			white_takebackactive = false;

			return 0;
		}




		private /*static*/ int ngCallbackHandler(string move)
		{


			// set a boolean?
			game_started = true;

			return 0;
		}









		private /*static*/ int wtbCallbackHandler(IntPtr cstr)




	 

		{






			//  IntPtr cstr = _DGTDLL_RegisterWhiteTakebackFunc(wtbCallbackInstance);
			String str = Marshal.PtrToStringAnsi(cstr);



			// set a boolean?
			// game_started = true;

			white_takebackactive = true;

		//	white_putative_move = move;



			return 0;
		}






		private /*static*/ int btbCallbackHandler(IntPtr cstr)
		{






			//  IntPtr cstr = _DGTDLL_RegisterWhiteTakebackFunc(wtbCallbackInstance);
			String str = Marshal.PtrToStringAnsi(cstr);


			// set a boolean?
			// game_started = true;

			black_takebackactive = true;


			//black_putative_move = move;

			return 0;
		}


















		private void updateBoard(string FEN)
		{
			//	chessBoard1.FENnotation = FEN;


			//                    //FEN has changed- get cp value; update pictures if necessary


			//#if !DEMO
			//                testCEngineProcess(board);


			//                // p.readEngineOutputLineAsynchronous();


			//                //wait for chess engine to process output
			//                //Thread.Sleep(10000);


			//                //+- three pawns is the limit
			//                if (cp_value >= 0)
			//                {

			//                    white_winning = true;
			//                    //black_winning = false;

			//                    if (cp_value > 300) cp_value = 300;

			//                }

			//                else
			//                {

			//                    white_winning = false;
			//                    //       black_winning = true;


			//                    if (cp_value < -300) cp_value = -300;


			//                }

			//                //we have recorded who's winning- now just get by how much
			//                cp_value = Math.Abs(cp_value);

			//                // scalefactor goes from 0 -> 100% of max image size = 0-> 250)
			//                // int scalefactor = (cp_value / 3) / 100 * image_size;


			//                int scalefactor = cp_value * 2;


			//                if (white_winning)
			//                {

			//                    this.pictureBox1.Size = new System.Drawing.Size(image_size + scalefactor, image_size + scalefactor);
			//                    this.pictureBox2.Size = new System.Drawing.Size(image_size - scalefactor, image_size - scalefactor);


			//                }
			//                else
			//                {

			//                    this.pictureBox1.Size = new System.Drawing.Size(image_size - scalefactor, image_size - scalefactor);
			//                    this.pictureBox2.Size = new System.Drawing.Size(image_size + scalefactor, image_size + scalefactor);


			//                }


			//                bbText.Invoke(new Action(() =>
			//                {
			//                    bbText.Text += Environment.NewLine;
			//                    // This code is executed on the UI thread.
			//                    bbText.Text += cp_value + Environment.NewLine;                  // (string)e.UserState;

			//                    bbText.Text += board + Environment.NewLine;
			//                }));


			//                // this.pictureBox1.Size = new System.Drawing.Size((100 - (cp_value * 10)) / 100 * 250, (100 - (cp_value * 10)) / 100 * 250);
			//                // this.pictureBox2.Size = new System.Drawing.Size((100 - (-cp_value * 10)) / 100 * 250, (100 - (-cp_value * 10)) / 100 * 250);

			//#endif
			//                    //bool isvalid = chessBoard1.Validate();
			//                    //if (!isvalid) bbText.Text = "Invalid state!!!";
			//                    finishedMove();

			//                    //  moveColor.BackColor = System.Drawing.Color.White/Black;


			//                }
			//            }

			//            //  if (!ignoreFirsttime) ignoreFirsttime = true;

			//            moveCount++;
		}


		//private void ChessDisplay_LoadXXX(object sender, EventArgs e)
		//{
		//}

		//private void ChessDisplay_FormClosed(object sender, FormClosedEventArgs e)
		//{
		//    if (dllOk)
		//    {
		//        _DGTDLL_Exit();
		//    }
		//}

		//private void setClockButton_Click(object sender, EventArgs e)
		//{
		//    if (dllOk)
		//    {
		//        _DGTDLL_DisplayClockMessage("Hello", 1000); // 1 second
		//    }
		//}

		//private void clearClockButton_Click(object sender, EventArgs e)
		//{
		//    if (dllOk)
		//    {
		//        _DGTDLL_EndDisplay(0);
		//    }
		//}


		private int scanCallbackHandler(string board)
		{
			// textBox.Text += "Scan: " + board + Environment.NewLine;


			//as soon as things are underway- hide distracting buttons
			//if (is_firstScan)
			//{
			//    button2.Visible = false;
			//    button1.Visible = false;
			//    is_firstScan = false;
			//}

			latestFEN = board;
			return 0;
		}

		#region DLL_Imports

		[DllImport("user32.dll")]
		public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);


		[DllImport(dllName)]
		private static extern int _DGTDLL_Init();

		[DllImport(dllName)]
		private static extern int _DGTDLL_AllowTakebacks(bool takeback);

		[DllImport(dllName)]
		private static extern int _DGTDLL_UseFEN(bool usefen);


		[DllImport(dllName)]
		private static extern int _DGTDLL_UseSAN(bool usesan);


		[DllImport(dllName)]
		private static extern int _DGTDLL_Exit();

		[DllImport(dllName)]
		private static extern int _DGTDLL_GetVersion();

		[DllImport(dllName)]
		private static extern int _DGTDLL_DisplayClockMessage(string message, int durationMs);

		[DllImport(dllName)]
		private static extern int _DGTDLL_EndDisplay(int dummy);

		[DllImport(dllName)]
		private static extern int _DGTDLL_RegisterScanFunc(FC scanFunc);


		[DllImport(dllName)]
		private static extern int _DGTDLL_RegisterWClockFunc(FC wClockFunc);

		[DllImport(dllName)]
		private static extern int _DGTDLL_RegisterBClockFunc(FC bClockFunc);


		[DllImport(dllName)]
		private static extern int _DGTDLL_RegisterWhiteMoveInputFunc(FC wmFunc);

		[DllImport(dllName)]
		private static extern int _DGTDLL_RegisterBlackMoveInputFunc(FC bmFunc);

		[DllImport(dllName)]
		private static extern int _DGTDLL_RegisterWhiteTakebackFunc(FCintptr wtbFunc);

		[DllImport(dllName)]
		private static extern int _DGTDLL_RegisterBlackTakebackFunc(FCintptr btbFunc);


		[DllImport(dllName)]
		private static extern int _DGTDLL_RegisterNewGameFunc(FC btbFunc);



		[DllImport(dllName)]
		private static extern int _DGTDLL_ShowDialog(int int1);



		[DllImport(dllName)]
		private static extern int _DGTDLL_HideDialog(int int1);








		#endregion DLL_Imports

		#endregion DLLShit

		public static int cp_value = 1;




		public ChessMoveHandler()
		{


			//this.game_time = game_time;

			//this.ftpClient = ftpClient;
			//this.logfile = logfile;


			//ChessDisplayInit();




			//		var openFileDialog1 = new OpenFileDialog();

			//  dgtInitialize();


			// DllSharp.DGT_Init.do_Init();


			//foreach (Control x in this.Controls)
			//{
			//    //if(x is Label)
			//    //    ((Label)x).MouseHover+=new EventHandler(AllLabels_HoverEvent);
			//    //else if(x is TextBox)
			//    //    ((TextBox)x).MouseHover+=new EventHandler(AllTextboxes_HoverEvent);

			//    if (x is CheckBox)
			//    {
			//        ((CheckBox)x).MouseClick += new System.Windows.Forms.MouseEventHandler(this.rotateEvent);


			//    }

			//}


			//    p.loadEngine();

			//    p.engineInput.AutoFlush = true;

			//      CEngineProcess.DataRead += CEngineProcess_DataRead_TESTX;


			//
			// Required for Windows Form Designer support
			//
			//InitializeComponent();


			//chessBoard1.addEvents(this);


			//gameNavigation.addEvents(this);


			//set up event listeners
			//CUCIPlug prog = new CUCIPlug();


			//this.pictureBox1.Size = new System.Drawing.Size(300, 300);


			//#if RELEASE


			//#endif 


			//   doChessStuff();

			//  Metronome m = new Metronome();

			//m.Start();


			//Input
			//uci
			//position fen 8/1K6/1Q6/8/5r2/4rk2/8/8 w - - 0 0 
			//go depth 5

			//output- cp_value


			// prog.Run();


			//get cp_value?


			//p.loadEngine();

			//   p.sendEngineCommandCRLF("uci");
			//     p.sendEngineCommandCRLF("ucinew");


			// p.sendEngineCommandCRLF("position fen 8/1K6/1Q6/8/5r2/4rk2/8/8 w - - 0 0");
			//p.sendEngineCommandCRLF("go depth 5");


			//  CEngineProcess.DataRead += new DataReadHandler(CEngineProcess_DataRead_TEST);


			//  p.readEngineOutputLineAsynchronous();


			//start test thread

			//    new Thread(testCEngineProcess).Start();

			#region DGT_INIT

			//dllOk = true;
			try
			{
				//string path = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine) + ";X:\\DGT\\Chess Timer v.3.3\\bin\\Debug\\";


				//Environment.SetEnvironmentVariable("Path", path, EnvironmentVariableTarget.User);


				_DGTDLL_Init();


				_DGTDLL_UseFEN(true);


				_DGTDLL_UseSAN(true);



				_DGTDLL_AllowTakebacks(true);


				scanCallbackInstance = scanCallbackHandler;


				wmCallbackInstance = wmCallbackHandler;

				bmCallbackInstance = bmCallbackHandler;

				ngCallbackInstance = ngCallbackHandler;

				wtbCallbackInstance = wtbCallbackHandler;

				btbCallbackInstance = btbCallbackHandler;


				wClockCallbackInstance = wClockCallbackHandler;

				bClockCallbackInstance = bClockCallbackHandler;


				/*
				 * 
				 * 
				 * 
				 * 
				 * 
				 * 
				 * 
				 * 
				 * 
				 * 
				 * 
				 * 	// Register the callbacks
		dll._DGTDLL_RegisterStatusFunc(demo.getStatus);
		dll._DGTDLL_RegisterScanFunc(demo.getScan);
		dll._DGTDLL_RegisterMagicPieceFunc(demo.getMagic);
		dll._DGTDLL_RegisterGameTypeChangedFunc(demo.getType);
	
				 * 
				 * 
				 */










				_DGTDLL_RegisterScanFunc(scanCallbackInstance);


				_DGTDLL_RegisterWClockFunc(wClockCallbackInstance);

				_DGTDLL_RegisterBClockFunc(bClockCallbackInstance);

				_DGTDLL_RegisterWhiteMoveInputFunc(wmCallbackInstance);
				_DGTDLL_RegisterBlackMoveInputFunc(bmCallbackInstance);


				_DGTDLL_RegisterNewGameFunc(ngCallbackInstance);

				_DGTDLL_RegisterWhiteTakebackFunc(wtbCallbackInstance);

				_DGTDLL_RegisterBlackTakebackFunc(btbCallbackInstance);


				_DGTDLL_ShowDialog(0);




				//textBox.Text += "Dll initialized." + Environment.NewLine;
			}
			catch (EntryPointNotFoundException)
			{
				//dllOk = false;
				//bbText.Text += "Dll function missing, please install the last version of RabbitPlugin!" +Environment.NewLine;
				return;
			}


			//	bbText.Text += "Connected!" + Environment.NewLine;

			Console.WriteLine("DLL Initialized");

			#endregion DGT_INIT
		}




		public ChessMoveHandler(StreamWriter logfile, ftp ftpClient, frmGame game_time)
		{


			this.game_time = game_time;

			//this.ftpClient = ftpClient;
			this.logfile = logfile;


		//	ChessDisplayInit();




			//		var openFileDialog1 = new OpenFileDialog();

			//  dgtInitialize();


			// DllSharp.DGT_Init.do_Init();


			//foreach (Control x in this.Controls)
			//{
			//    //if(x is Label)
			//    //    ((Label)x).MouseHover+=new EventHandler(AllLabels_HoverEvent);
			//    //else if(x is TextBox)
			//    //    ((TextBox)x).MouseHover+=new EventHandler(AllTextboxes_HoverEvent);

			//    if (x is CheckBox)
			//    {
			//        ((CheckBox)x).MouseClick += new System.Windows.Forms.MouseEventHandler(this.rotateEvent);


			//    }

			//}


			//    p.loadEngine();

			//    p.engineInput.AutoFlush = true;

			//      CEngineProcess.DataRead += CEngineProcess_DataRead_TESTX;


			//
			// Required for Windows Form Designer support
			//
			//InitializeComponent();


			//chessBoard1.addEvents(this);


			//gameNavigation.addEvents(this);


			//set up event listeners
			//CUCIPlug prog = new CUCIPlug();


			//this.pictureBox1.Size = new System.Drawing.Size(300, 300);


			//#if RELEASE


			//#endif 


			//   doChessStuff();

			//  Metronome m = new Metronome();

			//m.Start();


			//Input
			//uci
			//position fen 8/1K6/1Q6/8/5r2/4rk2/8/8 w - - 0 0 
			//go depth 5

			//output- cp_value


			// prog.Run();


			//get cp_value?


			//p.loadEngine();

			//   p.sendEngineCommandCRLF("uci");
			//     p.sendEngineCommandCRLF("ucinew");


			// p.sendEngineCommandCRLF("position fen 8/1K6/1Q6/8/5r2/4rk2/8/8 w - - 0 0");
			//p.sendEngineCommandCRLF("go depth 5");


			//  CEngineProcess.DataRead += new DataReadHandler(CEngineProcess_DataRead_TEST);


			//  p.readEngineOutputLineAsynchronous();


			//start test thread

			//    new Thread(testCEngineProcess).Start();

			#region DGT_INIT

			//dllOk = true;
			try
			{
				//string path = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine) + ";X:\\DGT\\Chess Timer v.3.3\\bin\\Debug\\";


				//Environment.SetEnvironmentVariable("Path", path, EnvironmentVariableTarget.User);


				_DGTDLL_Init();


				_DGTDLL_UseFEN(true);


				_DGTDLL_UseSAN(true);



				_DGTDLL_AllowTakebacks(true);


				scanCallbackInstance = scanCallbackHandler;


				wmCallbackInstance = wmCallbackHandler;

				bmCallbackInstance = bmCallbackHandler;

				ngCallbackInstance = ngCallbackHandler;

				wtbCallbackInstance = wtbCallbackHandler;

				btbCallbackInstance = btbCallbackHandler;


				wClockCallbackInstance = wClockCallbackHandler;

				bClockCallbackInstance = bClockCallbackHandler;


				_DGTDLL_RegisterScanFunc(scanCallbackInstance);


				_DGTDLL_RegisterWClockFunc(wClockCallbackInstance);

				_DGTDLL_RegisterBClockFunc(bClockCallbackInstance);

				_DGTDLL_RegisterWhiteMoveInputFunc(wmCallbackInstance);
				_DGTDLL_RegisterBlackMoveInputFunc(bmCallbackInstance);


				_DGTDLL_RegisterNewGameFunc(ngCallbackInstance);

				_DGTDLL_RegisterWhiteTakebackFunc(wtbCallbackInstance);

				_DGTDLL_RegisterBlackTakebackFunc(btbCallbackInstance);


			   




				//textBox.Text += "Dll initialized." + Environment.NewLine;
			}
			catch (EntryPointNotFoundException)
			{
				//dllOk = false;
				//bbText.Text += "Dll function missing, please install the last version of RabbitPlugin!" +Environment.NewLine;
				return;
			}


			//	bbText.Text += "Connected!" + Environment.NewLine;

			#endregion DGT_INIT
		}

		//private void InitializePictureBox()
		//{
		//    pictureBox1 = new PictureBox();
		//    pictureBox1.BorderStyle =
		//        BorderStyle.FixedSingle;
		//    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		//    pictureBox1.Location = new Point(72, 112);
		//    pictureBox1.Name = "pictureBox1";
		//    pictureBox1.Size = new Size(160, 136);
		//    pictureBox1.TabIndex = 6;
		//    pictureBox1.TabStop = false;
		//}

		//private void InitializeOpenFileDialog()
		//{
		//    openFileDialog1 = new OpenFileDialog();

		//    // Set the file dialog to filter for graphics files. 
		//    openFileDialog1.Filter =
		//        "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
		//        "All files (*.*)|*.*";

		//    // Allow the user to select multiple images. 
		//    openFileDialog1.Multiselect = true;
		//    openFileDialog1.Title = "My Image Browser";
		//}

		//private void fileButton_Click(Object sender, EventArgs e)
		//{
		//    openFileDialog1.ShowDialog();
		//}


		//// This method handles the FileOK event.  It opens each file  
		//// selected and loads the image from a stream into pictureBox1. 
		//private void openFileDialog1_FileOk(object sender,
		//    CancelEventArgs e)
		//{
		//    Activate();
		//    string[] files = openFileDialog1.FileNames;

		//    // Open each file and display the image in pictureBox1. 
		//    // Call Application.DoEvents to force a repaint after each 
		//    // file is read.         
		//    foreach (string file in files)
		//    {
		//        var fileInfo = new FileInfo(file);
		//        FileStream fileStream = fileInfo.OpenRead();
		//        pictureBox1.Image = Image.FromStream(fileStream);
		//        Application.DoEvents();
		//        fileStream.Close();

		//        // Call Sleep so the picture is briefly displayed,  
		//        //which will create a slide-show effect.
		//        Thread.Sleep(2000);
		//    }
		//    pictureBox1.Image = null;
		//}


		////void AllLabels_HoverEvent(object sender, EventArgs e)
		////{
		////      Label label = (Label)sender;
		////   // label.dowhateveryouwant...
		////}
		////void AllTextboxes_HoverEvent(object sender, EventArgs e)
		////{
		////    Textbox textbox = (Textbox)sender;
		////   // textbox.dowhateveryouwant...
		////}


		//private void rotateEvent(object sender, EventArgs e)
		//{
		//    chessBoard1.isFlipped = !chessBoard1.isFlipped;
		//}


		//    #region DGT
		//    void dgtInitialize()
		//    {


		//#if BLUETOOTH


		//        init_DGT_DLL();


		//        scanCallbackInstance = new FC(scanCallbackHandler);

		//        wmCallbackInstance = new FC(wmCallbackHandler);

		//        bmCallbackInstance = new FC(bmCallbackHandler);


		//        _DGTDLL_RegisterWhiteMoveInputFunc(wmCallbackInstance);
		//        _DGTDLL_RegisterBlackMoveInputFunc(bmCallbackInstance);


		//        //            _DGTDLL_RegisterScanFunc(scanCallbackInstance);


		//        //				_DGTDLL_RegisterWhiteTakebackFunc(DgtebdllLib.CallbackFunctionCharPtr fn);
		//        //				_DGTDLL_RegisterBlackTakebackFunc(DgtebdllLib.CallbackFunctionCharPtr fn);


		//        _DGTDLL_RegisterScanFunc(scanCallbackInstance);


		//        _DGTDLL_UseFEN(true);
		//#endif


		//    }
		//    #endregion DGT


		/// <summary>
		///     Clean up any resources being used.
		///// </summary>
		//protected override void Dispose(bool disposing)
		//{
		//    if (disposing)
		//    {
		//        if (components != null)
		//        {
		//            components.Dispose();
		//        }
		//    }
		//    base.Dispose(disposing);

		//     DisposeLogFile( disposing);
		//}

		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		//[STAThread]
		//private static void Main()
		//{
		//    Application.Run(new ChessDisplay());
		//}


		//private void Autofenk(object sender, System.EventArgs e)
		//{
		//    //Add the new FEN to the listbox only if it's not already there
		//    if (!fenTXT.Items.Contains(fenTXT.Text))
		//        fenTXT.Items.Insert(0, fenTXT.Text);
		//    statusLBL.Text = "";
		//    chessBoard1.FENnotation = fenTXT.Text;
		//    finishedMove();
		//}


		//private void dragCHK_CheckedChanged(object sender, System.EventArgs e)
		//{
		//  this.chessBoard1.isHoldingPiece = dragCHK.Checked;
		//}

		//private void switchBTN_Click(object sender, EventArgs e)
		//{
		//    chessBoard1.isFlipped = !chessBoard1.isFlipped;
		//}

		//private void fenBTN_Click(object sender, System.EventArgs e)
		//{
		//    //Add the new FEN to the listbox only if it's not already there
		//    if (!fenTXT.Items.Contains(fenTXT.Text))
		//        fenTXT.Items.Insert(0, fenTXT.Text);
		//    statusLBL.Text = "";
		//    chessBoard1.FENnotation = fenTXT.Text;
		//    finishedMove();
		//}

		//private void pgnBtn_Click(object sender, EventArgs e)
		//{
		//    var events = new ChessEventHandler();
		//    var gameEvents = new GameInMemory();

		//    var oFileDialog = new OpenFileDialog();

		//    if (DialogResult.OK == oFileDialog.ShowDialog())
		//    {
		//        try
		//        {
		//            string strXMLFile = Path.GetDirectoryName(oFileDialog.FileName) + "\\" +
		//                                Path.GetFileNameWithoutExtension(oFileDialog.FileName) + ".xml";
		//            //events.open(strXMLFile);
		//            gameEvents.open(strXMLFile);
		//            var pgn = new PgnData();
		//            pgn.Filename = oFileDialog.FileName;
		//            //pgn.addEvents(events);
		//            pgn.addEvents(gameEvents);
		//            pgn.parse();
		//        }
		//        catch
		//        {
		//        }
		//        finally
		//        {
		//            //events.close();
		//            gameEvents.close();
		//        }
		//    }
		//}

		//private void printBTN_Click(object sender, EventArgs e)
		//{
		//    bbText.Text = chessBoard1.printBitboards();
		//}

		////private void btnNew_Click(object sender, System.EventArgs e)
		////{
		////  statusLBL.Text = "";
		////  moveColor.BackColor = System.Drawing.Color.White;
		////  chessBoard1.FENnotation = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq";


		////"rnbqkbnr/pppp1ppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq";
		////"rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq";

		////}

		//private void getFenBtn_Click(object sender, EventArgs e)
		//{
		//    fenTXT.Text = chessBoard1.getFEN();
		//}

		////private void validChk_CheckedChanged(object sender, System.EventArgs e)
		////{
		////  chessBoard1.isValidating = validChk.Checked;    
		////}

		//private void gameNavigation_Load(object sender, EventArgs e)
		//{
		//    //gameNavigation.SetDataBinding( , );
		//}

		//   #region DLLSharp
		//   public void init_DGT_DLL()
		//       {
		//           dllOk = true;
		//           try
		//           {
		//               _DGTDLL_Init();
		////               scanCallbackInstance = new FC(scanCallbackHandler);
		//            //   _DGTDLL_RegisterScanFunc(scanCallbackInstance);

		//               //textBox.Text += "Dll initialized." + Environment.NewLine;
		//              // _DGTDLL_UseFEN(true);
		//           }
		//           catch (EntryPointNotFoundException)
		//           {
		//               dllOk = false;
		//               //textBox.Text += "Dll function missing, please install the last version of RabbitPlugin!" + Environment.NewLine;
		//               return;
		//           }
		//       }

		// private void MyForm_FormClosed(object sender, FormClosedEventArgs e)
		// {
		//     if (dllOk)
		//     {
		//         _DGTDLL_Exit();
		//     }


		// //    p.sendEngineCommandCRLF("quit");
		//     // p1.sendEngineCommandCRLF("stop");
		//     //  p1.sendEngineCommandCRLF("quit");

		////     p.waitForExit();
		//     //p1.waitForExit();
		// }

		//public void setClockButton_Click(object sender, EventArgs e)
		//{
		//    if (dllOk)
		//    {
		//        _DGTDLL_DisplayClockMessage("Hello", 1000); // 1 second
		//    }
		//}

		//void clearClockButton_Click(object sender, EventArgs e)
		//{
		//    if (dllOk)
		//    {
		//        _DGTDLL_EndDisplay(0);
		//    }
		//}


		//     bool    white_winning=true;
		// bool    black_winning=false;

		//      
		//  static bool ignoreFirsttime = false;

		//  static bool okToProceed = false;
		// static string eventTime;


		/********************************************************************************
reset the board and set its position to the one specified by FEN
********************************************************************************/

		private int setFEN(string aFEN)
		{
			int i, j

				//,state
				;


			//ESquare sq;
			char letter;
			int aRank, aFile;
			//vector strList;

			//string[] strList = new string[4];

			////String.split( strList , aFEN, " " );

			//strList[0] = aFEN;

			string[] strList = aFEN.Split(' ');

			// Empty the board quares
			//for (sq=A1;sq<=H8;sq++) bb.squares[sq] = EMPTY;


			// read the board - translate each loop idx into a square
			j = 1;
			i = 0;
			while ((j <= 64) && (i <= strList[0].Length))
			{
				letter = strList[0].ToCharArray()[i];
				i++;
				aFile = 1 + ((j - 1) % 8);
				aRank = 8 - ((j - 1) / 8);
				//sq = (ESquare) (((aRank-1)*8) + (aFile - 1));
				switch (letter)
				{
					//case 'p' : bb.squares[sq] = B_PAWN; break;
					//case 'r' : bb.squares[sq] = B_ROOK; break;
					//case 'n' : bb.squares[sq] = B_KNIGHT; break;
					//case 'b' : bb.squares[sq] = B_BISHOP; break;
					//case 'q' : bb.squares[sq] = B_QUEEN; break;
					//case 'k' : bb.squares[sq] = B_KING; break;
					//case 'P' : bb.squares[sq] = W_PAWN; break;
					//case 'R' : bb.squares[sq] = W_ROOK; break;
					//case 'N' : bb.squares[sq] = W_KNIGHT; break;
					//case 'B' : bb.squares[sq] = W_BISHOP; break;
					//case 'Q' : bb.squares[sq] = W_QUEEN; break;
					//case 'K' : bb.squares[sq] = W_KING; break;


					case 'p':
						break;
					case 'r':
						break;
					case 'n':
						break;
					case 'b':
						break;
					case 'q':
						break;
					case 'k':
						break;
					case 'P':
						break;
					case 'R':
						break;
					case 'N':
						break;
					case 'B':
						break;
					case 'Q':
						break;
					case 'K':
						break;


					case '/':
						j--;
						break;
					case '1':
						break;
					case '2':
						j++;
						break;
					case '3':
						j += 2;
						break;
					case '4':
						j += 3;
						break;
					case '5':
						j += 4;
						break;
					case '6':
						j += 5;
						break;
					case '7':
						j += 6;
						break;
					case '8':
						j += 7;
						break;
					default:
						return -1;
				}
				j++;
			}
			//So here the variable i marks the current position in the FEN string. The variable j walks through the board in the direction the FEN squares occur (A8 .. H1). Next we set the turn which is stored in the 2nd substring
			// set the turn; default = White
			//sideToMove = WHITE;

			//if (strList.size()>=2)
			//{
			//if (strList[1] == "w") sideToMove = WHITE; else
			//if (strList[1] == "b") sideToMove = BLACK; else return -1;
			//}


			//Next the casteling rights. For efficience we store all casteling rights into a single integer where different bits indicate a certain right is there (bit is 1) or right is missing (bit is 0). For bit manipulating we rely on small inline functions that do just set the correct bit to 1.
			// set boardstate to initial 0
			//state = 0;
			// Initialize all castle possibilities
			//if (strList.size()>=3)
			//{
			//if (strList[2].find('K') != string::npos) state =
			//TBoardState_SET_CASTLE_WHITE_KS(state,WHITE_CASTLE_KINGSIDE);
			//if (strList[2].find('Q') != string::npos) state =
			//TBoardState_SET_CASTLE_WHITE_QS(state,WHITE_CASTLE_QUEENSIDE);
			//if (strList[2].find('k') != string::npos) state =
			//TBoardState_SET_CASTLE_BLACK_KS(state,BLACK_CASTLE_KINGSIDE);
			//if (strList[2].find('q') != string::npos) state =
			//TBoardState_SET_CASTLE_BLACK_QS(state,BLACK_CASTLE_QUEENSIDE);
			//}
			//The next sub string stands for a possible en passent square. The square is initialized to the square "ER", which just means no valid square (we could initialize also to square 0, which is A1. Because A1 is also not a valid en passent square it is possible to recognize this situation as "No en passent" possibility but keep your code clean and readable. And it is advisable to call an invalid square "Invalid square" and not use a valid square for that, which is just invalid in this situation.
			// read en passent and save it into "sq" Default := None (ER)
			//sq = ER;
			if ((strList[0].Length >= 4) && (strList[3].Length >= 2))
			{
				if (
					(strList[3].ToCharArray()[0] >= 'a') && (strList[3].ToCharArray()[0] >= 'h')
					&&
					(
						(strList[3].ToCharArray()[1] == '3') || (strList[3].ToCharArray()[1] == '6')
						)
					)
				{
					aFile = strList[3].ToCharArray()[0] - 96; // ASCII 'a' = 97
					aRank = strList[3].ToCharArray()[1] - 48; // ASCII '1' = 49
					//sq = (ESquare)((aRank-1)*8 + aFile-1);
				}
				else return -1;
			}


			//Finally we retrieve the turn number
			// we start at turn 1 per default
			//int currentPly = 1;
			//if (strList.size()>=6)
			//{
			//currentPly = 2 * (StrToInt(strList[5])-1) +1;
			//if (currentPly<0) currentPly = 0; // avoid possible underflow
			//if (sideToMove==BLACK) currentPly++;
			//}


			//We now create our initial board state record with the en passent square we read and the castle rights we initialized
			// initialize the board state history stack
			//boardHistory->initialize(state,sq);
			// setup the piece related bit boards with this board content
			//initializeBitBoards();
			return 0;
		}


		/*************************************************
initialize the bitboards with the contents of
bb.squares
**************************************************/
		//void initializeBitBoards()
		//{
		//ESquare sq;
		//memset(&bb.pcs,0,sizeof(bb.pcs));
		//// initialize the piece bit boards
		//for (sq=A1;sq<=H8;sq++)
		//bb.pcs[bb.squares[sq]] |= BB_SQUARES[sq];
		//// calculate the utility bitboards
		//bb.pcsOfColor[WHITE] = bb.pcs[W_PAWN] | bb.pcs[W_KNIGHT] | bb.pcs[W_BISHOP] |
		//bb.pcs[W_ROOK] | bb.pcs[W_QUEEN] | bb.pcs[W_KING];
		//bb.pcsOfColor[BLACK] = bb.pcs[B_PAWN] | bb.pcs[B_KNIGHT] | bb.pcs[B_BISHOP] |
		//bb.pcs[B_ROOK] | bb.pcs[B_QUEEN] | bb.pcs[B_KING];
		//bb.occupiedSquares = bb.pcsOfColor[WHITE] | bb.pcsOfColor[BLACK];
		//bb.emptySquares = ~bb.occupiedSquares;
		//}


		//        public void testCEngineProcess(string fen)
		//        {
		////                while (p.isEngineLoaded())
		//            //              {


		//            //this.chessBoard1.Color.ToString().Substring(0, 1)

		//            //string tomove = "w";

		//            ////OMFG!
		//            //if (!this.chessBoard1.Color) tomove = "b";

		//            // string s = "";
		//            fen += @" "
		//                   + (chessBoard1.coBitBoard.Move.whiteToMove ? "w" : "b")
		//                   + " " + "KQkq - 0 0"; //allow all castling, ignore number of moves and en passant
		//            //setFEN(fen);
		//            //sample 		fen	"rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNB1KBNR w KQkq"	string

		//         //   p.sendEngineCommandCRLF("position fen " + fen); // "8/1K6/1Q6/8/5r2/4rk2/8/8 w - - 0 0");
		//       //     p.sendEngineCommandCRLF("go depth 5");


		//            //p.sendEngineCommandCRLF("position fen 8/1K6/1Q6/8/5r2/4rk2/8/8 w - - 0 0");
		//            //p.sendEngineCommandCRLF("go depth 5");

		//            //p.sendEngineCommandCRLF("quit");


		//            //if (cmd.Equals("quit"))
		//            //{
		//            //    // get ready to quit
		//            //    p.waitForExit();
		//            //    p = false;

		//            //}


		//            //            }


		//            //#region NOT_NEEDED
		//            ////System.Timers.Timer t = new System.Timers.Timer(10 * 1000);

		//            //System.Timers.Timer t = new System.Timers.Timer(10);
		//            //t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
		//            //p.sendEngineCommandCRLF("Interval: " + t.Interval);

		//            //p.sendEngineCommandCRLF(String.Format("Starttime: {0}:{1}:{2}:{3}",
		//            //    DateTime.Now.Hour,
		//            //    DateTime.Now.Minute,
		//            //    DateTime.Now.Second,
		//            //    DateTime.Now.Millisecond));

		//            //t.Start();

		//            //while (okToProceed != true)
		//            //{
		//            //    ;
		//            //}
		//            //p.sendEngineCommandCRLF(eventTime);
		//            //p.sendEngineCommandCRLF(String.Format("StopTime: {0}:{1}:{2}:{3}",
		//            //    DateTime.Now.Hour,
		//            //    DateTime.Now.Minute,
		//            //    DateTime.Now.Second,
		//            //    DateTime.Now.Millisecond));

		//            //t.Stop();
		//            //#endregion
		//        }

		//static void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		//{
		//    eventTime = String.Format("EventTime: {0}:{1}:{2}:{3}",
		//        e.SignalTime.Hour,
		//        e.SignalTime.Minute,
		//        e.SignalTime.Second,
		//        e.SignalTime.Millisecond);
		//    okToProceed = true;
		//}


		/// <summary>
		///     Callback for engineprocess data_read.
		///     **** INTERNAL. NOT for public use *****
		/// </summary>
		/// <param name="id">The id.</param>
		/// <param name="data">The data.</param>
		/*static*/
		private void CEngineProcess_DataRead_TESTX(int id, string data)
		{
			// Console.WriteLine("PGM::{0}::{1}", id, data);
			/*
				bbText.Invoke(new Action(() =>
				{
					// This code is executed on the UI thread.
					bbText.Text += "PGM:: " + id + "" + data + Environment.NewLine;                  // (string)e.UserState;
				}));
				*/
			//scan line for update to centi-pawn value (cp SPACE ANY_POS_NEG _OR ZERO_DIGIT)
			// Here we call Regex.Match.
			Match match = Regex.Match(data, @"cp (\-?\d+)" /*, RegexOptions.IgnoreCase*/);

			// Here we check the Match instance.
			if (match.Success)
			{
				// Finally, we get the Group value and display it.
				//string key = match.Groups[1].Value;
				//Console.WriteLine(key);


				string cp_string = match.Groups[1].Value;
				int new_cp_value = 0;
				// cp_string = cp_string.Substring(2);

				if (Int32.TryParse(cp_string, out new_cp_value))
				{
					//if cp_changed raise cp changed event and do stuff
					if (new_cp_value != cp_value)
					{
						cp_value = new_cp_value;

						//   data += @"*******************************************CP CHANGED***********************************";

						//raise event
						// Tick(this, e);
						//update graphic

						//string imagePath = @"ChrisAllen.bmp";

						//ImgHandler.ProcessRequest(imagePath, cp_value, cp_value);
					}
				}
				else
				{
					//fucked up somewhere
					throw new Exception();
				}
			}


			// Console.WriteLine(data);
			// Trace.WriteLine("RSP: " + data);
		}


		//       private bool dllOk;
		//       private delegate int FC(string text); // The callback delegate
		//   //    private FC scanCallbackInstance = new FC(scanCallbackHandler);
		//       //	_DGTDLL_RegisterScanFunc(scanCallbackInstance);
		//// The instance of the callback

		//       const string dllName = "dgtebdll.dll"; // for 64-bit it becomes dgtebdll64.dll

		//       [DllImport(dllName)]
		//       private extern static int _DGTDLL_Init();

		//       [DllImport(dllName)]
		//       private extern static int _DGTDLL_Exit();

		//       [DllImport(dllName)]
		//       private extern static int _DGTDLL_GetVersion();

		//       [DllImport(dllName)]
		//       private extern static int _DGTDLL_DisplayClockMessage(string message, int durationMs);

		//       [DllImport(dllName)]
		//       private extern static int _DGTDLL_EndDisplay(int dummy);

		//        [DllImport(dllName)]
		//       private extern static int _DGTDLL_UseFEN(bool usefen);


		//       [DllImport(dllName)]
		//       private extern static int _DGTDLL_RegisterScanFunc(FC scanFunc);


		//       [DllImport(dllName)]
		//       private extern static int _DGTDLL_RegisterWhiteMoveInputFunc(FC wmFunc);
		//       [DllImport(dllName)]
		//       private extern static int _DGTDLL_RegisterBlackMoveInputFunc(FC bmFunc);
		//       [DllImport(dllName)]
		//       private extern static int _DGTDLL_RegisterWhiteTakebackFunc(FC wtbFunc);

		//       [DllImport(dllName)]
		//       private extern static int _DGTDLL_RegisterBlackTakebackFunc(FC btbFunc);


		//  #endregion DLLSharp


		//private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
		//{
		//    Activate();
		//    string[] files = openFileDialog1.FileNames;

		//    // Open each file and display the image in pictureBox1. 
		//    // Call Application.DoEvents to force a repaint after each 
		//    // file is read.         
		//    foreach (string file in files)
		//    {
		//        var fileInfo = new FileInfo(file);
		//        FileStream fileStream = fileInfo.OpenRead();
		//        pictureBox1.Image = Image.FromStream(fileStream);
		//        Application.DoEvents();
		//        fileStream.Close();

		//        // Call Sleep so the picture is briefly displayed,  
		//        //which will create a slide-show effect.
		//        Thread.Sleep(2000);
		//    }
		//    pictureBox1.Image = null;
		//}

		//private void button1_Click(object sender, EventArgs e)
		//{
		//    //  openFileDialog1.ShowDialog();

		//    openFileDialog1.Title = "Select Image";

		//    DialogResult dr = openFileDialog1.ShowDialog();
		//    if (dr == DialogResult.OK)
		//    {
		//        String file = openFileDialog1.FileName;

		//        try
		//        {
		//            //PictureBox imageControl = new PictureBox();
		//            //imageControl.Height = 100;
		//            //imageControl.Width = 100;

		//            //Image.GetThumbnailImageAbort myCallback =    new Image.GetThumbnailImageAbort(ThumbnailCallback);
		//            var myBitmap = new Bitmap(file);
		//            Image myThumbnail = myBitmap.GetThumbnailImage(250, 250, null, IntPtr.Zero);
		//            // imageControl.Image = myThumbnail;

		//            pictureBox1.Image = myThumbnail;

		//            // PhotoGallary.Controls.Add(imageControl);
		//        }
		//        catch (Exception ex)
		//        {
		//            MessageBox.Show("Error: " + ex.Message);
		//        }


		//        //foreach (String file in openFileDialog1.FileNames)
		//        //{
		//        //    try
		//        //    {
		//        //        PictureBox imageControl = new PictureBox();
		//        //        imageControl.Height = 100;
		//        //        imageControl.Width = 100;

		//        //        //Image.GetThumbnailImageAbort myCallback =    new Image.GetThumbnailImageAbort(ThumbnailCallback);
		//        //        Bitmap myBitmap = new Bitmap(file);
		//        //        Image myThumbnail = myBitmap.GetThumbnailImage(96, 96, null, IntPtr.Zero);
		//        //        // imageControl.Image = myThumbnail;

		//        //        pictureBox1.Image = myThumbnail;

		//        //        // PhotoGallary.Controls.Add(imageControl);
		//        //    }
		//        //    catch (Exception ex)
		//        //    {
		//        //        MessageBox.Show("Error: " + ex.Message);
		//        //    }
		//        //}


		//        button1.Visible = false;
		//    }
		//}

		//private void button2_Click(object sender, EventArgs e)
		//{
		//    //  openFileDialog2.ShowDialog();


		//    openFileDialog2.Title = "Select Image";

		//    DialogResult dr = openFileDialog2.ShowDialog();
		//    if (dr == DialogResult.OK)
		//    {
		//        String file = openFileDialog2.FileName;

		//        try
		//        {
		//            //PictureBox imageControl = new PictureBox();
		//            //imageControl.Height = 100;
		//            //imageControl.Width = 100;

		//            //Image.GetThumbnailImageAbort myCallback =    new Image.GetThumbnailImageAbort(ThumbnailCallback);
		//            var myBitmap = new Bitmap(file);
		//            Image myThumbnail = myBitmap.GetThumbnailImage(250, 250, null, IntPtr.Zero);
		//            // imageControl.Image = myThumbnail;

		//            pictureBox2.Image = myThumbnail;

		//            // PhotoGallary.Controls.Add(imageControl);
		//        }
		//        catch (Exception ex)
		//        {
		//            MessageBox.Show("Error: " + ex.Message);
		//        }


		//        //foreach (String file in openFileDialog2.FileNames)
		//        //{
		//        //    try
		//        //    {
		//        //        PictureBox imageControl = new PictureBox();
		//        //        imageControl.Height = 100;
		//        //        imageControl.Width = 100;

		//        //        //Image.GetThumbnailImageAbort myCallback =    new Image.GetThumbnailImageAbort(ThumbnailCallback);
		//        //        Bitmap myBitmap = new Bitmap(file);
		//        //        Image myThumbnail = myBitmap.GetThumbnailImage(96, 96, null, IntPtr.Zero);
		//        //        // imageControl.Image = myThumbnail;

		//        //        pictureBox2.Image = myThumbnail;

		//        //        // PhotoGallary.Controls.Add(imageControl);
		//        //    }
		//        //    catch (Exception ex)
		//        //    {
		//        //        MessageBox.Show("Error: " + ex.Message);
		//        //    }
		//        //}


		//        button2.Visible = false;
		//    }
		//}

		//private void pictureBox1_Click(object sender, EventArgs e)
		//{
		//}

		//private void gameNavigation_Load_1(object sender, EventArgs e)
		//{
		//    // chessBoard1.isFlipped = ! chessBoard1.isFlipped;

		//    //  gameNavigation.checkBox1


		//    foreach (Control x in gameNavigation.Controls)
		//    {
		//        //if(x is Label)
		//        //    ((Label)x).MouseHover+=new EventHandler(AllLabels_HoverEvent);
		//        //else if(x is TextBox)
		//        //    ((TextBox)x).MouseHover+=new EventHandler(AllTextboxes_HoverEvent);

		//        if (x is CheckBox)
		//        {
		//            x.MouseClick += rotateEvent;
		//        }
		//    }
		//}

		//private void bbText_TextChanged(object sender, EventArgs e)
		//{
		//}

		//private void moveColor_Paint(object sender, PaintEventArgs e)
		//{
		//}

		//private void blackstime_Click(object sender, EventArgs e)
		//{
		//}

		#region chess_handlers

		//        bool isAMove(string oldFEN, string newFEN)
		//        {


		//            //newFEN must represent a clear move so:
		//            // must NOT be *just* the removal of one piece


		//            List<string> diff;
		//            IEnumerable<string> set1 = oldFEN.Split('/').Distinct();
		//            IEnumerable<string> set2 = newFEN.Split('/').Distinct();

		//            if (set2.Count() > set1.Count())
		//            {
		//                diff = set2.Except(set1).ToList();
		//            }
		//            else
		//            {
		//                diff = set1.Except(set2).ToList();
		//            }


		//            return false;
		//        }

		//        int scanCallbackHandler(string board)
		//        {
		//         //   label2.Text += "Scan: " + board + Environment.NewLine;


		//            //CEngineProcess.DataRead += new DataReadHandler(CEngineProcess_DataRead_TEST);
		//            if (moveCount == 0)
		//            {

		//                bbText.Invoke(new Action(() =>
		//                {
		//                    bbText.Text = @"Connected to DGT Bluetooth Chess board." + Environment.NewLine;  
		//                }));


		//            }


		//            latestFEN = board;


		//            return 0;

		//        }


		//        private void upDateBoard(string board)
		//        {


		//            {

		//                //check if this represents a move (not just a FEN change)

		//                //    if (isAMove(oldFEN, board))
		//                {

		//                    chessBoard1.FENnotation = board;


		//                    //FEN has changed- get cp value; update pictures if necessary


		//#if !DEMO
		//                testCEngineProcess(board);


		//                // p.readEngineOutputLineAsynchronous();


		//                //wait for chess engine to process output
		//                //Thread.Sleep(10000);


		//                //+- three pawns is the limit
		//                if (cp_value >= 0)
		//                {

		//                    white_winning = true;
		//                    //black_winning = false;

		//                    if (cp_value > 300) cp_value = 300;

		//                }

		//                else
		//                {

		//                    white_winning = false;
		//                    //       black_winning = true;


		//                    if (cp_value < -300) cp_value = -300;


		//                }

		//                //we have recorded who's winning- now just get by how much
		//                cp_value = Math.Abs(cp_value);

		//                // scalefactor goes from 0 -> 100% of max image size = 0-> 250)
		//                // int scalefactor = (cp_value / 3) / 100 * image_size;


		//                int scalefactor = cp_value * 2;


		//                if (white_winning)
		//                {

		//                    this.pictureBox1.Size = new System.Drawing.Size(image_size + scalefactor, image_size + scalefactor);
		//                    this.pictureBox2.Size = new System.Drawing.Size(image_size - scalefactor, image_size - scalefactor);


		//                }
		//                else
		//                {

		//                    this.pictureBox1.Size = new System.Drawing.Size(image_size - scalefactor, image_size - scalefactor);
		//                    this.pictureBox2.Size = new System.Drawing.Size(image_size + scalefactor, image_size + scalefactor);


		//                }


		//                bbText.Invoke(new Action(() =>
		//                {
		//                    bbText.Text += Environment.NewLine;
		//                    // This code is executed on the UI thread.
		//                    bbText.Text += cp_value + Environment.NewLine;                  // (string)e.UserState;

		//                    bbText.Text += board + Environment.NewLine;
		//                }));


		//                // this.pictureBox1.Size = new System.Drawing.Size((100 - (cp_value * 10)) / 100 * 250, (100 - (cp_value * 10)) / 100 * 250);
		//                // this.pictureBox2.Size = new System.Drawing.Size((100 - (-cp_value * 10)) / 100 * 250, (100 - (-cp_value * 10)) / 100 * 250);

		//#endif
		//                    //bool isvalid = chessBoard1.Validate();
		//                    //if (!isvalid) bbText.Text = "Invalid state!!!";
		//                    finishedMove();

		//                    //  moveColor.BackColor = System.Drawing.Color.White/Black;


		//                }
		//            }

		//            //  if (!ignoreFirsttime) ignoreFirsttime = true;

		//            moveCount++;


		//        }


		//        private int wmCallbackHandler(string board)
		//        {
		//           // textBox.Text += "WHITE MOVE: " + board + Environment.NewLine;


		//            upDateBoard(latestFEN);
		//            return 0;
		//        }

		//        private int bmCallbackHandler(string board)
		//        {
		//            //textBox.Text += "BLACK MOVE: " + board + Environment.NewLine;

		//            upDateBoard(latestFEN);
		//            return 0;
		//        }

		#endregion chess_handlers

		#region INavigationEvents Members

		public void cancel()
		{
		}

		public void add()
		{
		}

		public void OK()
		{
		}

		public void movePrev()
		{
		}

		public void delete()
		{
		}

		public void moveLast()
		{
		}

		public void moveFirst()
		{
		}

		public void moveNext()
		{
		}

		public void rotate()
		{
		}

		#endregion

		//#region IValidationEvents Members

		////public void KingIsStaleMated()
		////{
		////  statusLBL.Text = "STALE MATE!";    
		////}

		////public void KingIsInCheck()
		////{
		////  statusLBL.Text = "CHECK!";
		////}

		//public void KingIsMated()
		//{
		//    //   statusLBL.Text = "MATE!";


		//    //MessageBox.Show("Mate! Mate. Lolz","FUKD",MessageBoxIcon.Exclamation);

		//    MessageBox.Show("Mate! Mate. Lolz.");
		//}

		////    public void KingIsFree()
		////    {
		////        statusLBL.Text = "";    
		////    }
		//public void finishedMove()
		//{
		//    //what the HELL is this?!
		//    //moveColor.BackColor = this.chessBoard1.Color ? System.Drawing.Color.White : System.Drawing.Color.Black;

		//    //

		//    chessBoard1.coBitBoard.Move.whiteToMove = !chessBoard1.coBitBoard.Move.whiteToMove;
		//    if (chessBoard1.coBitBoard.Move.whiteToMove)
		//    {
		//        flowLayoutPanel1.BackColor = SystemColors.ActiveCaptionText;
		//        flowLayoutPanel2.BackColor = SystemColors.ButtonFace;
		//        pictureBox2.BorderStyle = BorderStyle.None;
		//        pictureBox1.BorderStyle = BorderStyle.Fixed3D;
		//        moveColor.BackColor = Color.White;
		//    }
		//    else
		//    {
		//        flowLayoutPanel2.BackColor = SystemColors.ActiveCaptionText;
		//        flowLayoutPanel1.BackColor = SystemColors.ButtonFace;


		//        pictureBox1.BorderStyle = BorderStyle.None;
		//        pictureBox2.BorderStyle = BorderStyle.Fixed3D;


		//        moveColor.BackColor = Color.Black;
		//    }
		//}

		//public void updateBoard(Chess.Operation op, string FromSquare, string ToSquare)
		//{
		//    // TODO:  Add ChessDisplay.updatePiece implementation
		//}

		//public void Promotion(bool color, string square, ref Chess.Pieces piece)
		//{
		//    // TODO:  Add ChessDisplay.Promotion implementation
		//}

		//#endregion

		//#region Windows Form Designer generated code

		///// <summary>
		/////     Required method for Designer support - do not modify
		/////     the contents of this method with the code editor.
		///// </summary>
		//private void InitializeComponent()
		//{
		//    this.components = new System.ComponentModel.Container();
		//    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessDisplay));
		//    this.bbText = new System.Windows.Forms.TextBox();
		//    this.fenTXT = new System.Windows.Forms.ComboBox();
		//    this.label1 = new System.Windows.Forms.Label();
		//    this.moveColor = new System.Windows.Forms.Panel();
		//    this.label2 = new System.Windows.Forms.Label();
		//    this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
		//    this.pictureBox1 = new System.Windows.Forms.PictureBox();
		//    this.pictureBox2 = new System.Windows.Forms.PictureBox();
		//    this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
		//    this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
		//    this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
		//    this.button1 = new System.Windows.Forms.Button();
		//    this.button2 = new System.Windows.Forms.Button();
		//    this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
		//    this.chessBoard1 = new ChessBoardCtrl.ChessBoard();
		//    this.gameNavigation = new ChessBoardCtrl.GameNavigation();
		//    this.whitestime = new System.Windows.Forms.Label();
		//    this.blackstime = new System.Windows.Forms.Label();
		//    this.flowLayoutPanel1.SuspendLayout();
		//    ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
		//    ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
		//    this.flowLayoutPanel2.SuspendLayout();
		//    this.SuspendLayout();
		//    // 
		//    // bbText
		//    // 
		//    this.bbText.Location = new System.Drawing.Point(480, 459);
		//    this.bbText.Multiline = true;
		//    this.bbText.Name = "bbText";
		//    this.bbText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		//    this.bbText.Size = new System.Drawing.Size(545, 21);
		//    this.bbText.TabIndex = 6;
		//    this.bbText.Text = "Waiting for connection to DGT Bluetooth Chess board ...";
		//    this.bbText.TextChanged += new System.EventHandler(this.bbText_TextChanged);
		//    // 
		//    // fenTXT
		//    // 
		//    this.fenTXT.Items.AddRange(new object[] {
		//    "3qkb2/pppppppp/8/8/8/8/8/RNBQKBNR w KQkq"});
		//    this.fenTXT.Location = new System.Drawing.Point(40, 496);
		//    this.fenTXT.Name = "fenTXT";
		//    this.fenTXT.Size = new System.Drawing.Size(416, 21);
		//    this.fenTXT.TabIndex = 0;
		//    this.fenTXT.Text = "3qkb2/pppppppp/8/8/8/8/8/RNBQKBNR w KQkq";
		//    this.fenTXT.Visible = false;
		//    // 
		//    // label1
		//    // 
		//    this.label1.Location = new System.Drawing.Point(0, 496);
		//    this.label1.Name = "label1";
		//    this.label1.Size = new System.Drawing.Size(32, 16);
		//    this.label1.TabIndex = 11;
		//    this.label1.Text = "FEN:";
		//    this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		//    this.label1.Visible = false;
		//    // 
		//    // moveColor
		//    // 
		//    this.moveColor.BackColor = System.Drawing.Color.White;
		//    this.moveColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		//    this.moveColor.Location = new System.Drawing.Point(480, 43);
		//    this.moveColor.Name = "moveColor";
		//    this.moveColor.Size = new System.Drawing.Size(545, 18);
		//    this.moveColor.TabIndex = 12;
		//    this.moveColor.Paint += new System.Windows.Forms.PaintEventHandler(this.moveColor_Paint);
		//    // 
		//    // label2
		//    // 
		//    this.label2.Location = new System.Drawing.Point(472, 24);
		//    this.label2.Name = "label2";
		//    this.label2.Size = new System.Drawing.Size(80, 16);
		//    this.label2.TabIndex = 13;
		//    this.label2.Text = "Side To Move:";
		//    this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		//    // 
		//    // flowLayoutPanel1
		//    // 
		//    this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		//    this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
		//    this.flowLayoutPanel1.Location = new System.Drawing.Point(483, 67);
		//    this.flowLayoutPanel1.Name = "flowLayoutPanel1";
		//    this.flowLayoutPanel1.Size = new System.Drawing.Size(261, 265);
		//    this.flowLayoutPanel1.TabIndex = 15;
		//    // 
		//    // pictureBox1
		//    // 
		//    this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		//    this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		//    this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
		//    this.pictureBox1.Location = new System.Drawing.Point(3, 3);
		//    this.pictureBox1.Name = "pictureBox1";
		//    this.pictureBox1.Size = new System.Drawing.Size(254, 254);
		//    this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		//    this.pictureBox1.TabIndex = 0;
		//    this.pictureBox1.TabStop = false;
		//    this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
		//    // 
		//    // pictureBox2
		//    // 
		//    this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		//    this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
		//    this.pictureBox2.Location = new System.Drawing.Point(3, 3);
		//    this.pictureBox2.Name = "pictureBox2";
		//    this.pictureBox2.Size = new System.Drawing.Size(254, 254);
		//    this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		//    this.pictureBox2.TabIndex = 1;
		//    this.pictureBox2.TabStop = false;
		//    // 
		//    // openFileDialog1
		//    // 
		//    this.openFileDialog1.FileName = "openFileDialog1";
		//    this.openFileDialog1.InitialDirectory = ".";
		//    this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk_1);
		//    // 
		//    // openFileDialog2
		//    // 
		//    this.openFileDialog2.FileName = "openFileDialog2";
		//    this.openFileDialog2.InitialDirectory = ".";
		//    // 
		//    // openFileDialog3
		//    // 
		//    this.openFileDialog3.FileName = "openFileDialog3";
		//    this.openFileDialog3.Tag = "Open first image (white)";
		//    this.openFileDialog3.Title = "Open first image (white)";
		//    // 
		//    // button1
		//    // 
		//    this.button1.Location = new System.Drawing.Point(483, 349);
		//    this.button1.Name = "button1";
		//    this.button1.Size = new System.Drawing.Size(261, 23);
		//    this.button1.TabIndex = 16;
		//    this.button1.Text = "White Player Image";
		//    this.button1.UseVisualStyleBackColor = true;
		//    this.button1.Click += new System.EventHandler(this.button1_Click);
		//    // 
		//    // button2
		//    // 
		//    this.button2.Location = new System.Drawing.Point(761, 349);
		//    this.button2.Name = "button2";
		//    this.button2.Size = new System.Drawing.Size(264, 23);
		//    this.button2.TabIndex = 17;
		//    this.button2.Text = "Black Player Image";
		//    this.button2.UseVisualStyleBackColor = true;
		//    this.button2.Click += new System.EventHandler(this.button2_Click);
		//    // 
		//    // flowLayoutPanel2
		//    // 
		//    this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.ButtonFace;
		//    this.flowLayoutPanel2.Controls.Add(this.pictureBox2);
		//    this.flowLayoutPanel2.Location = new System.Drawing.Point(761, 68);
		//    this.flowLayoutPanel2.Name = "flowLayoutPanel2";
		//    this.flowLayoutPanel2.Size = new System.Drawing.Size(264, 264);
		//    this.flowLayoutPanel2.TabIndex = 18;
		//    // 
		//    // chessBoard1
		//    // 
		//    this.chessBoard1.isFlipped = false;
		//    this.chessBoard1.isHoldingPiece = true;
		//    this.chessBoard1.isValidating = true;
		//    this.chessBoard1.Location = new System.Drawing.Point(0, 0);
		//    this.chessBoard1.Name = "chessBoard1";
		//    this.chessBoard1.Size = new System.Drawing.Size(467, 454);
		//    this.chessBoard1.TabIndex = 0;
		//    // 
		//    // gameNavigation
		//    // 
		//    this.gameNavigation.Location = new System.Drawing.Point(0, 459);
		//    this.gameNavigation.Name = "gameNavigation";
		//    this.gameNavigation.Size = new System.Drawing.Size(456, 21);
		//    this.gameNavigation.TabIndex = 1;
		//    this.gameNavigation.Load += new System.EventHandler(this.gameNavigation_Load_1);
		//    // 
		//    // whitestime
		//    // 
		//    this.whitestime.AutoSize = true;
		//    this.whitestime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		//    this.whitestime.Location = new System.Drawing.Point(493, 399);
		//    this.whitestime.Name = "whitestime";
		//    this.whitestime.Size = new System.Drawing.Size(39, 20);
		//    this.whitestime.TabIndex = 19;
		//    this.whitestime.Text = "--|--";
		//    // 
		//    // blackstime
		//    // 
		//    this.blackstime.AutoSize = true;
		//    this.blackstime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		//    this.blackstime.Location = new System.Drawing.Point(764, 398);
		//    this.blackstime.Name = "blackstime";
		//    this.blackstime.Size = new System.Drawing.Size(39, 20);
		//    this.blackstime.TabIndex = 20;
		//    this.blackstime.Text = "--|--";
		//    this.blackstime.Click += new System.EventHandler(this.blackstime_Click);
		//    // 
		//    // ChessDisplay
		//    // 
		//    this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		//    this.ClientSize = new System.Drawing.Size(1213, 612);
		//    this.Controls.Add(this.blackstime);
		//    this.Controls.Add(this.whitestime);
		//    this.Controls.Add(this.flowLayoutPanel2);
		//    this.Controls.Add(this.button2);
		//    this.Controls.Add(this.button1);
		//    this.Controls.Add(this.flowLayoutPanel1);
		//    this.Controls.Add(this.chessBoard1);
		//    this.Controls.Add(this.gameNavigation);
		//    this.Controls.Add(this.label2);
		//    this.Controls.Add(this.moveColor);
		//    this.Controls.Add(this.label1);
		//    this.Controls.Add(this.fenTXT);
		//    this.Controls.Add(this.bbText);
		//    this.Name = "ChessDisplay";
		//    this.Text = "ChessDisplay";
		//    this.flowLayoutPanel1.ResumeLayout(false);
		//    this.flowLayoutPanel1.PerformLayout();
		//    ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
		//    ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
		//    this.flowLayoutPanel2.ResumeLayout(false);
		//    this.flowLayoutPanel2.PerformLayout();
		//    this.ResumeLayout(false);
		//    this.PerformLayout();

		//}

		//#endregion

		//        private void button1_Click(object sender, EventArgs e)
		//        {

		//            if (sender.Equals(button1))
		//            {
		////                using (CustomControls.MyOpenFileDialogControl openDialog = new CustomControls.MyOpenFileDialogControl())


		//                CustomControls.MyOpenFileDialogControl openDialog = new CustomControls.MyOpenFileDialogControl();
		//                {


		//                    if (openDialog.ShowDialog(this) == DialogResult.OK)
		//                    {
		//                        lblFilePath.Text = openDialog.MSDialog.FileName;
		//                    }
		//                }

		//            }
		//            else if (sender.Equals(_btnSave))
		//            {
		//                using (MySaveDialogControl saveDialog = new MySaveDialogControl(lblFilePath.Text, this))
		//                {
		//                    if (saveDialog.ShowDialog(this) == DialogResult.OK)
		//                    {
		//                        lblFilePath.Text = saveDialog.MSDialog.FileName;
		//                    }
		//                }
		//            }
		//            else if (sender.Equals(this._btnExtension))
		//            {
		//                using (MyOpenFileDialogControl openDialogCtrl = new MyOpenFileDialogControl())
		//                {
		//                    openDialogCtrl.FileDlgInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
		//                    OpenFileDialog openDialog = new OpenFileDialog();
		//                    openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
		//                    openDialog.AddExtension = true;
		//                    openDialog.Filter = "Image Files(*.bmp)|*.bmp |Image Files(*.JPG)|*.JPG|Image Files(*.jpeg)|*.jpeg|Image Files(*.GIF)|*.GIF|Image Files(*.emf)|*emf.|Image Files(*.ico)|*.ico|Image Files(*.png)|*.png|Image Files(*.tif)|*.tif|Image Files(*.wmf)|*.wmf|Image Files(*.exif)|*.exif";
		//                    openDialog.FilterIndex = 2;
		//                    openDialog.CheckFileExists = true;
		//                    openDialog.DefaultExt = "jpg";
		//                    openDialog.FileName = "Select Picture";
		//                    openDialog.DereferenceLinks = true;
		//                    //openDialog.ShowHelp = true;
		//                    if (Environment.OSVersion.Version.Major < 6)
		//                        openDialog.SetPlaces(new object[] { @"c:\", (int)Places.MyComputer, (int)Places.Favorites, (int)Places.Printers, (int)Places.Fonts });
		//                    if (openDialog.ShowDialog(openDialogCtrl, this) == DialogResult.OK)
		//                    {
		//                        lblFilePath.Text = openDialog.FileName;
		//                    }
		//                }
		//            }
		//            else if (sender.Equals(_btnSaveExt))
		//            {
		//                using (SaveFileDialog saveDialog = new SaveFileDialog())
		//                {
		//                    MySaveDialogControl saveDialogCtrl = new MySaveDialogControl(lblFilePath.Text, this);
		//                    saveDialogCtrl.FileDlgInitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
		//                    saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
		//                    saveDialog.AddExtension = true;
		//                    saveDialog.Filter = "Image Files(*.bmp)|*.bmp |Image Files(*.JPG)|*.JPG|Image Files(*.jpeg)|*.jpeg|Image Files(*.GIF)|*.GIF|Image Files(*.emf)|*emf.|Image Files(*.ico)|*.ico|Image Files(*.png)|*.png|Image Files(*.tif)|*.tif|Image Files(*.wmf)|*.wmf|Image Files(*.exif)|*.exif";
		//                    saveDialog.FilterIndex = 2;
		//                    saveDialog.CheckFileExists = true;
		//                    saveDialog.DefaultExt = "jpg";
		//                    saveDialog.FileName = "Change Picture";
		//                    saveDialog.DereferenceLinks = true;
		//                    //saveDialog.ShowHelp = true;
		//                    if (Environment.OSVersion.Version.Major < 6)
		//                        saveDialog.SetPlaces(new object[] { (int)Places.Desktop, (int)Places.Printers, (int)Places.Favorites, (int)Places.Programs, (int)Places.Fonts, });
		//                    if (saveDialog.ShowDialog(saveDialogCtrl, this) == DialogResult.OK)
		//                    {
		//                        lblFilePath.Text = saveDialog.FileName;
		//                    }
		//                }
		//            }
		//            else if (sender.Equals(_btnExit))
		//                this.Close();

		//            System.GC.Collect();
		//            GC.WaitForPendingFinalizers();
		//        }
	}


	//internal class ChessEventHandler : IGameParserEvents
	//{
	//    #region IGameParserEvents Members

	//    private XmlTextWriter coXml;
	//    private int count;
	//    private int number;

	//    public void newGame(IGameParser iParser)
	//    {
	//        count++;
	//        if (count > 1)
	//            coXml.WriteEndElement();
	//        coXml.WriteStartElement("GAME");
	//    }

	//    public void enterVariation(IGameParser iParser)
	//    {
	//        coXml.WriteStartElement("VARIATION");
	//    }

	//    public void exitVariation(IGameParser iParser)
	//    {
	//        coXml.WriteEndElement();
	//    }

	//    public void finished(IGameParser iParser)
	//    {
	//        coXml.WriteEndElement();
	//        MessageBox.Show("Finished!!", "Parsing Complete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	//    }

	//    public void tagParsed(IGameParser iParser)
	//    {
	//        coXml.WriteStartElement("TAG");
	//        coXml.WriteAttributeString("name", iParser.Tag);
	//        coXml.WriteString(iParser.Value);
	//        coXml.WriteEndElement();
	//    }

	//    public void nagParsed(IGameParser iParser)
	//    {
	//        coXml.WriteStartElement("NAG");
	//        coXml.WriteString(iParser.Value);
	//        coXml.WriteEndElement();
	//    }

	//    public void moveParsed(IGameParser iParser)
	//    {
	//        try
	//        {
	//            if (iParser.State == GameParserState.State.NUMBER)
	//                number = int.Parse(iParser.Value);
	//            else
	//            {
	//                coXml.WriteStartElement("MOVE");
	//                coXml.WriteAttributeString("number", number.ToString());
	//                coXml.WriteAttributeString("color", iParser.State.ToString());
	//                coXml.WriteString(iParser.Value);
	//                coXml.WriteEndElement();
	//            }
	//        }
	//        catch
	//        {
	//        }
	//    }

	//    public void commentParsed(IGameParser iParser)
	//    {
	//        coXml.WriteStartElement("COMMENT");
	//        coXml.WriteString(iParser.Value);
	//        coXml.WriteEndElement();
	//    }

	//    public void open(string Filename)
	//    {
	//        try
	//        {
	//            if (File.Exists(Filename))
	//                File.Delete(Filename);
	//            coXml = new XmlTextWriter(Filename, null);
	//            coXml.WriteStartDocument();
	//            coXml.WriteStartElement("GAMES");
	//        }
	//        catch (Exception e)
	//        {
	//            e.Message.Trim();
	//        }
	//    }

	//    public void close()
	//    {
	//        coXml.WriteEndElement();
	//        coXml.Close();
	//    }

	//    #endregion
	//}

	//internal class GameInMemory : IGameParserEvents
	//{
	//    #region IGameParserEvents Members    

	//    public XmlDocument GameDOM;
	//    private XmlNode coCurrent;
	//    private string coFilename;
	//    private XmlElement coMove;
	//    private int count;

	//    public GameInMemory()
	//    {
	//        GameDOM = new XmlDocument();
	//        count = 0;
	//        coMove = null;
	//    }

	//    public void newGame(IGameParser iParser)
	//    {
	//        count++;
	//        XmlElement newElement = GameDOM.CreateElement("GAME");
	//        coCurrent = coCurrent.AppendChild(newElement);
	//    }

	//    public void enterVariation(IGameParser iParser)
	//    {
	//        if (coMove != null)
	//        {
	//            coCurrent.AppendChild(coMove);
	//            coMove = null;
	//        }
	//        XmlElement newElement = GameDOM.CreateElement("VARIATION");
	//        coCurrent = coCurrent.AppendChild(newElement);
	//    }

	//    public void exitVariation(IGameParser iParser)
	//    {
	//        coCurrent = coCurrent.ParentNode;
	//    }

	//    public void finished(IGameParser iParser)
	//    {
	//        coCurrent = GameDOM.DocumentElement;
	//    }

	//    public void tagParsed(IGameParser iParser)
	//    {
	//        try
	//        {
	//            XmlElement newElement = GameDOM.CreateElement("TAG");
	//            newElement.SetAttribute("name", iParser.Tag);
	//            newElement.AppendChild(GameDOM.CreateTextNode(iParser.Value));
	//            coCurrent.AppendChild(newElement);
	//        }
	//        catch (Exception err)
	//        {
	//            err.Message.ToUpper();
	//        }
	//    }

	//    public void commentParsed(IGameParser iParser)
	//    {
	//        if (coMove != null)
	//        {
	//            coCurrent.AppendChild(coMove);
	//            coMove = null;
	//        }
	//        XmlElement newElement = GameDOM.CreateElement("COMMENT");
	//        newElement.AppendChild(GameDOM.CreateTextNode(iParser.Value));
	//        coCurrent.AppendChild(newElement);
	//    }

	//    public void nagParsed(IGameParser iParser)
	//    {
	//        if (coMove != null)
	//        {
	//            coCurrent.AppendChild(coMove);
	//            coMove = null;
	//        }
	//        XmlElement newElement = GameDOM.CreateElement("NAG");
	//        newElement.AppendChild(GameDOM.CreateTextNode(iParser.Value));
	//        coCurrent.AppendChild(newElement);
	//    }

	//    public void moveParsed(IGameParser iParser)
	//    {
	//        try
	//        {
	//            if (iParser.State == GameParserState.State.NUMBER)
	//            {
	//                // Checks for cases where someone has entered a move as: 1. e4 1...e5
	//                //  as we only save out our element when we have complete move list or
	//                //  we are entering a variation.
	//                if (coMove == null)
	//                {
	//                    coMove = GameDOM.CreateElement("MOVE");
	//                    coMove.SetAttribute("number", iParser.Value);
	//                }
	//            }
	//            else if (iParser.State == GameParserState.State.WHITE)
	//            {
	//                if (coMove != null)
	//                    coMove.SetAttribute("white", iParser.Value);
	//            }
	//            else
	//            {
	//                if (coMove != null)
	//                {
	//                    coMove.SetAttribute("black", iParser.Value);
	//                    coCurrent.AppendChild(coMove);
	//                    coMove = null;
	//                }
	//            }
	//        }
	//        catch
	//        {
	//        }
	//    }

	//    public void open(string Filename)
	//    {
	//        coFilename = Filename;
	//        GameDOM.LoadXml("<GAMES>" +
	//                        "</GAMES>");
	//        coCurrent = GameDOM.DocumentElement;
	//    }

	//    public void close()
	//    {
	//        GameDOM.Save(coFilename);
	//    }

	//    #endregion
	//}










}

/*

DEAD CODE
 * 
 * 
 * 
 * 
 * 


 * 
 * 
 * 

		#region CHESSENGINE interface
		class ProgramEngine
		{


			static bool okToProceed = false;
			static string eventTime;



			public static int cp_value = 1;


			static void MainTest(string[] args)
			{


				//set up event listeners
				// CUCIPlug prog = new CUCIPlug();


				ProgramEngine prog = new ProgramEngine();

				prog.testCEngineProcess();



				//  Metronome m = new Metronome();

				//m.Start();

			}





			public void testCEngineProcess()
			{
				CEngineProcess p = new CEngineProcess("TogaII131.exe");
				CEngineProcess p1 = new CEngineProcess("TogaII131.exe");

				CEngineProcess.DataRead += new DataReadHandler(CEngineProcess_DataRead_TEST);


				p.loadEngine();
				p1.loadEngine();
				p.sendEngineCommandCRLF("uci");
				p1.sendEngineCommandCRLF("uci");

				p.readEngineOutputLineAsynchronous();
				p1.readEngineOutputLineAsynchronous();

				p1.sendEngineCommandCRLF("ucinew");
				p1.sendEngineCommandCRLF("position startpos");
				p1.sendEngineCommandCRLF("go infinite");


				p.sendEngineCommandCRLF("ucinew");
				p.sendEngineCommandCRLF("position fen 8/1K6/1Q6/8/5r2/4rk2/8/8 w - - 0 0");
				p.sendEngineCommandCRLF("go depth 5");





				// Start the process.
				//
				//
				// Read in all the text from the process with the StreamReader.
				//    //

				//string result = p1.engineOutput.ReadToEnd();
				//        Console.Write(result);



				#region NOT_NEEDED
				//System.Timers.Timer t = new System.Timers.Timer(10 * 1000);

				System.Timers.Timer t = new System.Timers.Timer(10);
				t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
				p.sendEngineCommandCRLF("Interval: " + t.Interval);

				p.sendEngineCommandCRLF(String.Format("Starttime: {0}:{1}:{2}:{3}",
					DateTime.Now.Hour,
					DateTime.Now.Minute,
					DateTime.Now.Second,
					DateTime.Now.Millisecond));

				t.Start();

				while (okToProceed != true)
				{
					;
				}
				p.sendEngineCommandCRLF(eventTime);
				p.sendEngineCommandCRLF(String.Format("StopTime: {0}:{1}:{2}:{3}",
					DateTime.Now.Hour,
					DateTime.Now.Minute,
					DateTime.Now.Second,
					DateTime.Now.Millisecond));

				t.Stop();
				#endregion

				p.sendEngineCommandCRLF("quit");
				p1.sendEngineCommandCRLF("stop");
				p1.sendEngineCommandCRLF("quit");

				p.waitForExit();
				p1.waitForExit();

			}
			static void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
			{
				eventTime = String.Format("EventTime: {0}:{1}:{2}:{3}",
					e.SignalTime.Hour,
					e.SignalTime.Minute,
					e.SignalTime.Second,
					e.SignalTime.Millisecond);
				okToProceed = true;
			}



			/// <summary>
			/// Callback for engineprocess data_read.
			/// **** INTERNAL. NOT for public use *****
			/// </summary>
			/// <param name="id">The id.</param>
			/// <param name="data">The data.</param>
			static void CEngineProcess_DataRead_TEST(int id, string data)
			{
				// Console.WriteLine("PGM::{0}::{1}", id, data);



				//scan line for update to centi-pawn value (cp SPACE ANY_POS_NEG _OR ZERO_DIGIT)
				// Here we call Regex.Match.
				Match match = Regex.Match(data, @"cp (\-?\d+)", RegexOptions.IgnoreCase);

				// Here we check the Match instance.
				if (match.Success)
				{
					// Finally, we get the Group value and display it.
					//string key = match.Groups[1].Value;
					//Console.WriteLine(key);


					string cp_string = match.Groups[1].Value;
					int new_cp_value = 0;
					// cp_string = cp_string.Substring(2);

					if (Int32.TryParse(cp_string, out new_cp_value))
					{

						//if cp_changed raise cp changed event and do stuff
						if (new_cp_value != cp_value)
						{

							cp_value = new_cp_value;

							//   data += @"*******************************************CP CHANGED***********************************";

							//raise event
							// Tick(this, e);
							//update graphic

							//string imagePath = @"ChrisAllen.bmp";

							//ImgHandler.ProcessRequest(imagePath, cp_value, cp_value);


						}

					}
					else
					{

						//fucked up somewhere
						throw new Exception();

					}



				}



				// Console.WriteLine(data);
				// Trace.WriteLine("RSP: " + data);











			}



		}
		#endregion CHESSENGINE interface
		public class ImgHandler
		{

			static int count = 0;

			public ImgHandler()
			{
				//
				// TODO: Add constructor logic here
				//
			}

			public static void ProcessRequest(string imagePath, int width, int height)
			{


				// split the string on periods and read the last element, this is to ensure we have
				// the right ContentType if the file is named something like "image1.jpg.png"
				string[] imageArray = imagePath.Split('.');

				if (imageArray.Length <= 1)
				{
					throw new Exception("Invalid photo name.");
				}
				else
				{
					if (File.Exists(imagePath))
					{
						//--------------- Dynamically changing image size --------------------------  
						// context.Response.Clear();
						//context.Response.ContentType = getContentType(imagePath);
						// Set image height and width to be loaded on web page

						getContentType(imagePath);

						byte[] buffer = getResizedImage(imagePath, width, height);
						// context.Response.OutputStream.Write(buffer, 0, buffer.Length);
						//context.Response.End();
						count++;

						string extension = Path.GetExtension(imagePath);

						string newpath = imagePath + count + extension;


						//Form1.pictureBox1.

						File.WriteAllBytes(newpath, buffer);

					}
				}
			}

			public bool IsReusable
			{
				get { return true; }
			}

			static byte[] getResizedImage(String path, int width, int height)
			{
				Bitmap imgIn = new Bitmap(path);
				double y = imgIn.Height;
				double x = imgIn.Width;

				double factor = 1;
				if (width > 0)
				{
					factor = width / x;
				}
				else if (height > 0)
				{
					factor = height / y;
				}
				System.IO.MemoryStream outStream = new System.IO.MemoryStream();
				Bitmap imgOut = new Bitmap((int)(x * factor), (int)(y * factor));

				// Set DPI of image (xDpi, yDpi)
				imgOut.SetResolution(72, 72);

				Graphics g = Graphics.FromImage(imgOut);
				g.Clear(Color.White);
				g.DrawImage(imgIn, new Rectangle(0, 0, (int)(factor * x), (int)(factor * y)),
				  new Rectangle(0, 0, (int)x, (int)y), GraphicsUnit.Pixel);

				imgOut.Save(outStream, getImageFormat(path));
				return outStream.ToArray();
			}

			static string getContentType(String path)
			{
				switch (Path.GetExtension(path))
				{
					case ".bmp": return "Image/bmp";
					case ".gif": return "Image/gif";
					case ".jpg": return "Image/jpeg";
					case ".png": return "Image/png";
					default: break;
				}
				return "";
			}

			static ImageFormat getImageFormat(String path)
			{
				switch (Path.GetExtension(path))
				{
					case ".bmp": return ImageFormat.Bmp;
					case ".gif": return ImageFormat.Gif;
					case ".jpg": return ImageFormat.Jpeg;
					case ".png": return ImageFormat.Png;
					default: break;
				}
				return ImageFormat.Jpeg;
			}
		}























*/