using System.Diagnostics;
using System.Windows;

namespace TestEmbedded
{
    /// <summary>
    /// MainWindowAppContainer.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindowAppContainer
    {
        static void Mainfx(string[] args)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe ";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = false;
            p.Start();
            p.StandardInput.WriteLine("start cmd.exe"); //先转到系统盘下
            p.StandardInput.WriteLine("exit");

            p.WaitForExit();
            p.Close();
            p.Dispose();

        }
        private bool _isLoadSuccess;
        public MainWindowAppContainer()
        {
            InitializeComponent();
        }

        private void MainWindowAppContainer_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!_isLoadSuccess)
            {
                _isLoadSuccess = ctnTest.StartAndEmbedProcess(@"C:\Windows\system32\mspaint.exe");
            }
        }
    }
}
