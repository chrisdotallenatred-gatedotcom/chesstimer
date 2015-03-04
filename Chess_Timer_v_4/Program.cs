namespace Chess_Timer_v_4
{
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        [MTAThread]
        private static void Main()
        {
          //  Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new frmSetup());
        }
    }
}

