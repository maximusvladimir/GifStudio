using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;
using Gifbrary.Utilities;
using System.Net;
using System.IO;
using System.Data;
using System.Data.SQLite;

namespace Gifbrary
{
    public class App
    {
        public static string SERFJ = "AI39si7bXTu92wh6hy6fYPSMp18MAbZ03yh2T6L29JrwjiLpJUKJKjYiJSHivj3H2Yx1aAOy4-b1h1TFYiFunyz3-igHrfI2ag";
        public static List<object> CleanupQueue = new List<object>();

        public static void HandleError(IntPtr handler, string rootMSG, Exception ex, int opCode)
        {
            TaskDialog dialog = new TaskDialog();
            dialog.Caption = "Error #" + opCode;
            dialog.DetailsExpanded = false;
            dialog.InstructionText = "Something went wrong! (Error #"+ opCode + ")";
            if (ex != null)
                dialog.DetailsExpandedText = ex.Message + "\n\n" + ex.StackTrace;
            else
                dialog.DetailsExpandedText = "Root message unspecified.";
            dialog.HyperlinksEnabled = true;
            dialog.Text = Unlk(rootMSG);
            if (handler != IntPtr.Zero)
                dialog.OwnerWindowHandle = handler;
            TaskDialogCommandLink copy = new TaskDialogCommandLink("Copy", "Copy the contents of this message to the clipboard.");
            copy.Click += delegate(object sender, EventArgs args)
            {
                try
                {
                    System.Windows.Forms.Clipboard.SetText(dialog.Caption + ": " + rootMSG + "\n\n" + dialog.DetailsExpandedText);
                }
                catch (Exception)
                {
                    try
                    {
                        System.Windows.Forms.Clipboard.SetText(dialog.Caption + ": " + rootMSG + "\n\n" + dialog.DetailsExpandedText);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            System.Windows.Forms.Clipboard.SetText(dialog.Caption + ": " + rootMSG + "\n\n" + dialog.DetailsExpandedText);
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                dialog.Close();
            };
            TaskDialogCommandLink closeok = new TaskDialogCommandLink("Ok", "Ok");
            closeok.Click += delegate(object sender, EventArgs args)
            {
                dialog.Close();
            };
            dialog.Controls.Add(closeok);
            dialog.Controls.Add(copy);
            dialog.Icon = TaskDialogStandardIcon.Error;
            dialog.StandardButtons = TaskDialogStandardButtons.None;
            dialog.StartupLocation = TaskDialogStartupLocation.CenterScreen;
            dialog.HyperlinkClick += new EventHandler<TaskDialogHyperlinkClickedEventArgs>(dialog_HyperlinkClick);
            if (opCode % 2 != 0 && ex != null)
            {
                dialog.FooterCheckBoxText = "Send error report so I can improve the program?";
                dialog.FooterCheckBoxChecked = true;
            }
            //dialog.FooterLabel = "If you continue to recieve this message, please contact me at http://maximusvladimir.wordpress.com/ .";
            dialog.Show();
            if (opCode % 2 != 0 && ex != null && dialog.FooterCheckBoxChecked != null && ((bool)dialog.FooterCheckBoxChecked))
            {
                SendErrorReport(ex.Message, ex.StackTrace, rootMSG);
            }
        }

        private static string Unlk(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            if (str.IndexOf("\\n") > -1)
                str = str.Replace("\\n", "\n");

            return str;
        }

        private static void SendErrorReport(string message, string stack, string rootMessage)
        {
            try
            {

            }
            catch (Exception)
            {
            }
        }

        private static void dialog_HyperlinkClick(object sender, TaskDialogHyperlinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        public static void SetProgress(int value)
        {
            var prog = Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.Instance;
            if (value >= 100)
                prog.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.NoProgress);
            else
            {
                prog.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.Normal);
                if (value > 100)
                    value = 100;
                if (value < 0)
                    value = 0;
                prog.SetProgressValue(value, 100);
            }
        }

        /*public static bool IsValidPath(string file)
        {
            bool valid = true;
            bool delete = true;
            try
            {
                if (!File.Exists(file))
                    File.Create(file);
                else
                {
                    delete = false;
                    using (FileStream reader = new FileStream(file, FileMode.Open, FileAccess.ReadWrite, FileShare.Delete))
                    {
                        
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                valid = false;
            }
            try
            {
                if (delete)
                    File.Delete(file);
            }
            catch (Exception)
            { }
            return valid;
        }*/

        public static void HandleHelp(IntPtr handler, string rootMSG, string moreDetails, string helpTopic)
        {
            TaskDialog dialog = new TaskDialog();
            dialog.Caption = "Help";
            if (moreDetails != null)
                dialog.DetailsExpanded = false;
            dialog.InstructionText = helpTopic;
            if (moreDetails != null)
                dialog.DetailsExpandedText = "\n\n" + Unlk(moreDetails);
            dialog.HyperlinksEnabled = true;
            dialog.Text = Unlk(rootMSG);
            if (handler != IntPtr.Zero)
                dialog.OwnerWindowHandle = handler;
            TaskDialogCommandLink copy = new TaskDialogCommandLink("Copy", "Copy the contents of this message to the clipboard.");
            copy.Click += delegate(object sender, EventArgs args)
            {
                try
                {
                    System.Windows.Forms.Clipboard.SetText(helpTopic+":\n"+rootMSG + "\n\n" + moreDetails);
                }
                catch (Exception)
                {
                    try
                    {
                        System.Windows.Forms.Clipboard.SetText(helpTopic + ":\n" + rootMSG + "\n\n" + moreDetails);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            System.Windows.Forms.Clipboard.SetText(helpTopic + ":\n" + rootMSG + "\n\n" + moreDetails);
                        }
                        catch (Exception)
                        { }
                    }
                }
                dialog.Close();
            };
            TaskDialogCommandLink closeok = new TaskDialogCommandLink("Ok", "Ok");
            closeok.Click += delegate(object sender, EventArgs args)
            {
                dialog.Close();
            };
            dialog.Controls.Add(closeok);
            dialog.Controls.Add(copy);
            dialog.Icon = TaskDialogStandardIcon.Shield;
            dialog.StandardButtons = TaskDialogStandardButtons.None;
            dialog.StartupLocation = TaskDialogStartupLocation.CenterScreen;
            dialog.Show();
        }

        public static List<string> HistoryUrls = new List<string>();
        public static bool HistoryReady = false;
        public static void Init()
        {
            Gifbrary.Common.FFmpeg.Init();
            System.Threading.Thread worker = new System.Threading.Thread(new System.Threading.ThreadStart(WorkHistory));
            worker.Start();
            //VideoCodecLib.Converter.Init();
        }

        private static void WorkHistory()
        {
            try
            {
                GoogleChrome chromium = new GoogleChrome();
                List<URL> urls = chromium.GetHistory();
                for (int c = 0; c < urls.Count; c++)
                {
                    string uri = urls[c].url;
                    if (uri.IndexOf("http://") > -1)
                        uri = uri.Replace("http://", "");
                    if (uri.IndexOf("https://") > -1)
                        uri = uri.Replace("https://", "");
                    HistoryUrls.Add(uri);
                }
                HistoryReady = true;
            }
            catch (Exception)
            {
               
            }
        }

        public static void Shutdown()
        {
            List<object> post = new List<object>();
            for (int c = 0; c < CleanupQueue.Count; c++)
            {
                if (CleanupQueue[c] is Process)
                {
                    try
                    {
                        ((Process)CleanupQueue[c]).Kill();
                    }
                    catch (Exception)
                    { }
                }
                /*else if (CleanupQueue[c] is ConsoleApp)
                {
                    try
                    {
                        ((ConsoleApp)CleanupQueue[c]).Stop();
                    }
                    catch (Exception)
                    { }
                }*/
                else
                    post.Add(CleanupQueue[c]);
            }

            for (int c = 0; c < post.Count; c++)
            {
                if (post[c] is string)
                {
                    try
                    {
                        File.Delete((string)post[c]);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            Directory.Delete((string)post[c], true);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                else if (post[c] is IDisposable)
                {
                    try
                    {
                        ((IDisposable)post[c]).Dispose();
                    }
                    catch (Exception)
                    { }
                }
            }

            if (VideoDownloader.AppTemp != null)
            {
                try
                {
                    System.IO.Directory.Delete(VideoDownloader.AppTemp);
                }
                catch (Exception)
                {
                }
            }

            SharpApng.Apng.Shutdown();

            try
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            catch (Exception)
            {
            }
            //VideoCodecLib.Converter.Shutdown();
        }
        public static string AppDataPath
        {
            get
            {
                if (dir == null)
                {
                    dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"GifStudio\\");
                    if (!Directory.Exists(dir))
                        try
                        {
                            Directory.CreateDirectory(dir);
                        }
                        catch (Exception)
                        { }
                }
                return dir;
            }
        }
        private static string dir = null;
        private static WebClient _webclie;
        public static WebClient DefaultWebClient
        {
            get
            {
                if (_webclie == null)
                {
                    _webclie = new WebClient();
                    _webclie.Headers.Add("user-agent", UserAgent);
                }

                return _webclie;
            }
        }

        public static string UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0";
    }

    public class URL
    {
        public string url;
        public string title;
        public string browser;
        public URL(string url, string title, string browser)
        {
            this.url = url;
            this.title = title;
            this.browser = browser;
        }

        public string getData()
        {
            return browser + " - " + title + " - " + url;
        }
    }

    class GoogleChrome
    {
        public List<URL> URLs = new List<URL>();
        public List<URL> GetHistory()
        {
            // Get Current Users App Data
            string documentsFolder = Environment.GetFolderPath
            (Environment.SpecialFolder.ApplicationData);
            string[] tempstr = documentsFolder.Split('\\');
            string tempstr1 = "";
            documentsFolder += "\\Google\\Chrome\\User Data\\Default\\History";
            if (tempstr[tempstr.Length - 1] != "Local")
            {
                for (int i = 0; i < tempstr.Length - 1; i++)
                {
                    tempstr1 += tempstr[i] + "\\";
                }
                documentsFolder = tempstr1 + "Local\\Google\\Chrome\\User Data\\Default\\History";
            }

            bool chromeRunning = false;
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.IndexOf("chrome") > -1)
                {
                    chromeRunning = true;
                    Console.WriteLine("Chrome is running. Attempting to copy database for use.");
                    break;
                }
            }

            if (chromeRunning)
            {
                string tmp = Path.Combine(App.AppDataPath, "ChromiumHistory.txt");
                try
                {
                    if (File.Exists(tmp))
                        File.Delete(tmp);
                }
                catch (Exception)
                { }
                using (var inputFile = new FileStream(documentsFolder, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var outputFile = new FileStream(tmp, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        var buffer = new byte[0x10000];
                        int bytes;
                        while ((bytes = inputFile.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            outputFile.Write(buffer, 0, bytes);
                        }
                    }
                }

                documentsFolder = tmp;
            }

            // Check if directory exists
            if (File.Exists(documentsFolder))
            {
                return ExtractUserHistory(documentsFolder);
            }
            return null;
        }


        private List<URL> ExtractUserHistory(string folder)
        {
            // Get User history info
            DataTable historyDT = ExtractFromTable("urls", folder);

            // Get visit Time/Data info
            DataTable visitsDT = ExtractFromTable("visits",
            folder);

            // Loop each history entry
            foreach (DataRow row in historyDT.Rows)
            {

                // Obtain URL and Title strings
                string url = row["url"].ToString();
                string title = row["title"].ToString();

                // Create new Entry
                URL u = new URL(url.Replace('\'', ' '),
                title.Replace('\'', ' '),
                "Google Chrome");

                // Add entry to list
                URLs.Add(u);
            }
            // Clear URL History
            DeleteFromTable("urls", folder);
            DeleteFromTable("visits", folder);

            return URLs;
        }
        private void DeleteFromTable(string table, string folder)
        {
            SQLiteConnection sql_con;
            SQLiteCommand sql_cmd;

            // FireFox database file
            string dbPath = folder;

            // If file exists
            if (File.Exists(dbPath))
            {
                // Data connection
                sql_con = new SQLiteConnection("Data Source=" + dbPath +
                ";Version=3;New=False;Compress=True;");

                // Open the Conn
                sql_con.Open();

                // Delete Query
                string CommandText = "delete from " + table;

                // Create command
                sql_cmd = new SQLiteCommand(CommandText, sql_con);

                sql_cmd.ExecuteNonQuery();

                // Clean up
                sql_con.Close();
            }
        }
        private DataTable ExtractFromTable(string table, string folder)
        {
            SQLiteConnection sql_con;
            SQLiteCommand sql_cmd;
            SQLiteDataAdapter DB;
            DataTable DT = new DataTable();

            // FireFox database file
            string dbPath = folder;

            // If file exists
            if (File.Exists(dbPath))
            {
                // Data connection
                sql_con = new SQLiteConnection("Data Source=" + dbPath +
                ";Version=3;New=False;Compress=True;");

                // Open the Connection
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();

                // Select Query
                string CommandText = "select * from " + table;

                // Populate Data Table
                DB = new SQLiteDataAdapter(CommandText, sql_con);
                DB.Fill(DT);

                // Clean up
                sql_con.Close();
            }
            return DT;
        }
    }

}
