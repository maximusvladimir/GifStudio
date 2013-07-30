using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;
using Gifbrary.Utilities;
using System.Net;
using System.IO;

namespace Gifbrary
{
    public class App
    {
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

        public static void Init()
        {
            //VideoCodecLib.Converter.Init();
        }

        public static void Shutdown()
        {
            if (VideoDownloader.AppTemp != null)
            {
                try
                {
                   // System.IO.Directory.Delete(VideoDownloader.AppTemp);
                }
                catch (Exception)
                {
                }
            }
            SharpApng.Apng.Shutdown();

            try
            {
                System.Diagnostics.Process.GetCurrentProcess().Close();
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
}
