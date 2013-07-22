using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;

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
            dialog.Text = rootMSG;
            if (handler != IntPtr.Zero)
                dialog.OwnerWindowHandle = handler;
            dialog.Icon = TaskDialogStandardIcon.Error;
            dialog.StandardButtons = TaskDialogStandardButtons.Ok;
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
            dialog.DetailsExpanded = true;
            dialog.InstructionText = helpTopic;
            if (moreDetails != null)
                dialog.DetailsExpandedText = "\n\n"+moreDetails;
            dialog.HyperlinksEnabled = true;
            dialog.Text = rootMSG;
            if (handler != IntPtr.Zero)
                dialog.OwnerWindowHandle = handler;
            dialog.Icon = TaskDialogStandardIcon.Information;
            dialog.StandardButtons = TaskDialogStandardButtons.Ok;
            dialog.StartupLocation = TaskDialogStartupLocation.CenterScreen;
            dialog.Show();
        }
    }
}
