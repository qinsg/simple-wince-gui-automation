﻿using System;
using System.Runtime.InteropServices;
using System.Text;
using SimpleWinceGuiAutomation.Core;

namespace SimpleWinceGuiAutomation
{
    public class WinceListBox
    {
        private readonly IntPtr ptr;

        public WinceListBox(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public String Text
        {
            get { return WindowHelper.GetText(ptr); }
        }

        int LB_GETTEXT = 0x0189;
        private int LB_GETTEXTLEN = 0x018A;
        private int LB_GETCOUNT = 0x018B;
        int LB_SETCURSEL = 0x0186;

        private string GetListItem(int index)
        {
            var size = PInvoke.SendMessage(ptr, LB_GETTEXTLEN, new IntPtr(index), new IntPtr(0)).ToInt32();
            StringBuilder ssb = new StringBuilder(size);
            var getSize = SendMessageS(ptr, LB_GETTEXT, index, ssb);
            return ssb.ToString();
        }


        public void Select(string value)
        {
            StringBuilder ssb = new StringBuilder(5);
            var getSize = SendMessageS(ptr, LB_GETTEXT, 0, ssb);
            
            //IntPtr ptr = PInvoke.SendMessage(this.ptr, LB_GETCOUNT, (IntPtr)0, (IntPtr)0);
            //for (var i = 0; i < ptr.ToInt32(); i++)
            //{
            //    var item = GetListItem(i);
            //    if (item == value)
            //    {
            //        PInvoke.SendMessage(this.ptr, LB_SETCURSEL, (IntPtr)i, (IntPtr)0);
            //    }
            //}
        }

        [DllImport("coredll", EntryPoint = "SendMessage")]
        private static extern int SendMessageS(IntPtr hwnd, int msg, int wParamas, StringBuilder lParam);
    }
}