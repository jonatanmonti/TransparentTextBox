using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace prueba
{
    public class win32
    {

        // Token: 0x0600001F RID: 31
        [DllImport("USER32.DLL")]
        public static extern bool PostMessage(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);

        // Token: 0x06000020 RID: 32
        [DllImport("USER32.DLL")]
        public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);

        // Token: 0x06000021 RID: 33
        [DllImport("USER32.DLL")]
        public static extern uint GetCaretBlinkTime();

        // Token: 0x06000022 RID: 34 RVA: 0x00002B50 File Offset: 0x00001B50
        public static bool CaptureWindow(Control control, ref Bitmap bitmap)
        {
            Graphics graphics = Graphics.FromImage(bitmap);
            int value = 12;
            IntPtr lParam = new IntPtr(value);
            IntPtr hdc = graphics.GetHdc();
            win32.SendMessage(control.Handle, 791, hdc, lParam);
            graphics.ReleaseHdc(hdc);
            graphics.Dispose();
            return true;
        }

        // Token: 0x0400000D RID: 13
        public const int WM_MOUSEMOVE = 512;

        // Token: 0x0400000E RID: 14
        public const int WM_LBUTTONDOWN = 513;

        // Token: 0x0400000F RID: 15
        public const int WM_LBUTTONUP = 514;

        // Token: 0x04000010 RID: 16
        public const int WM_RBUTTONDOWN = 516;

        // Token: 0x04000011 RID: 17
        public const int WM_LBUTTONDBLCLK = 515;

        // Token: 0x04000012 RID: 18
        public const int WM_MOUSELEAVE = 675;

        // Token: 0x04000013 RID: 19
        public const int WM_PAINT = 15;

        // Token: 0x04000014 RID: 20
        public const int WM_ERASEBKGND = 20;

        // Token: 0x04000015 RID: 21
        public const int WM_PRINT = 791;

        // Token: 0x04000016 RID: 22
        public const int WM_HSCROLL = 276;

        // Token: 0x04000017 RID: 23
        public const int WM_VSCROLL = 277;

        // Token: 0x04000018 RID: 24
        public const int EM_GETSEL = 176;

        // Token: 0x04000019 RID: 25
        public const int EM_LINEINDEX = 187;

        // Token: 0x0400001A RID: 26
        public const int EM_LINEFROMCHAR = 201;

        // Token: 0x0400001B RID: 27
        public const int EM_POSFROMCHAR = 214;

        // Token: 0x0400001C RID: 28
        private const int WM_PRINTCLIENT = 792;

        // Token: 0x0400001D RID: 29
        private const long PRF_CHECKVISIBLE = 1L;

        // Token: 0x0400001E RID: 30
        private const long PRF_NONCLIENT = 2L;

        // Token: 0x0400001F RID: 31
        private const long PRF_CLIENT = 4L;

        // Token: 0x04000020 RID: 32
        private const long PRF_ERASEBKGND = 8L;

        // Token: 0x04000021 RID: 33
        private const long PRF_CHILDREN = 16L;

        // Token: 0x04000022 RID: 34
        private const long PRF_OWNED = 32L;

        // Token: 0x02000005 RID: 5
        private enum CaptureOptions : long
        {
            // Token: 0x04000024 RID: 36
            PRF_CHECKVISIBLE = 1L,
            // Token: 0x04000025 RID: 37
            PRF_NONCLIENT,
            // Token: 0x04000026 RID: 38
            PRF_CLIENT = 4L,
            // Token: 0x04000027 RID: 39
            PRF_ERASEBKGND = 8L,
            // Token: 0x04000028 RID: 40
            PRF_CHILDREN = 16L,
            // Token: 0x04000029 RID: 41
            PRF_OWNED = 32L
        }
    }
}
