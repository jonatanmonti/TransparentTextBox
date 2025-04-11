using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba
{
    public class ButtonPerso : TextBox
    {

        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
        public ButtonPerso()
        {
            this.InitializeComponent();
            this.BackColor = this.myBackColor;
            base.SetStyle(ControlStyles.UserPaint, false);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            this.myPictureBox = new ButtonPerso.uPictureBox();
            base.Controls.Add(this.myPictureBox);
            this.myPictureBox.Dock = DockStyle.Fill;
        }

        // Token: 0x06000002 RID: 2 RVA: 0x000020FC File Offset: 0x000010FC
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.myBitmap = new Bitmap(base.ClientRectangle.Width, base.ClientRectangle.Height);
            this.myAlphaBitmap = new Bitmap(base.ClientRectangle.Width, base.ClientRectangle.Height);
            this.myUpToDate = false;
            base.Invalidate();
        }

        // Token: 0x06000003 RID: 3 RVA: 0x0000216C File Offset: 0x0000116C
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            this.myUpToDate = false;
            base.Invalidate();
        }

        // Token: 0x06000004 RID: 4 RVA: 0x00002190 File Offset: 0x00001190
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            this.myUpToDate = false;
            base.Invalidate();
        }

        // Token: 0x06000005 RID: 5 RVA: 0x000021B4 File Offset: 0x000011B4
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            this.myUpToDate = false;
            base.Invalidate();
        }

        // Token: 0x06000006 RID: 6 RVA: 0x000021D8 File Offset: 0x000011D8
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            base.Invalidate();
        }

        // Token: 0x06000007 RID: 7 RVA: 0x000021F4 File Offset: 0x000011F4
        protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
        {
            base.OnGiveFeedback(gfbevent);
            this.myUpToDate = false;
            base.Invalidate();
        }

        // Token: 0x06000008 RID: 8 RVA: 0x00002218 File Offset: 0x00001218
        protected override void OnMouseLeave(EventArgs e)
        {
            Point point = Cursor.Position;
            Form form = base.FindForm();
            point = form.PointToClient(point);
            if (!base.Bounds.Contains(point))
            {
                base.OnMouseLeave(e);
            }
        }

        // Token: 0x06000009 RID: 9 RVA: 0x00002254 File Offset: 0x00001254
        protected override void OnChangeUICues(UICuesEventArgs e)
        {
            base.OnChangeUICues(e);
            this.myUpToDate = false;
            base.Invalidate();
        }

        // Token: 0x0600000A RID: 10 RVA: 0x00002278 File Offset: 0x00001278
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.myCaretUpToDate = false;
            this.myUpToDate = false;
            base.Invalidate();
            this.myTimer1 = new System.Windows.Forms.Timer(this.components);
            this.myTimer1.Interval = (int)win32.GetCaretBlinkTime();
            this.myTimer1.Tick += this.myTimer1_Tick;
            this.myTimer1.Enabled = true;
        }

        // Token: 0x0600000B RID: 11 RVA: 0x000022E4 File Offset: 0x000012E4
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.myCaretUpToDate = false;
            this.myUpToDate = false;
            base.Invalidate();
            this.myTimer1.Dispose();
        }

        // Token: 0x0600000C RID: 12 RVA: 0x00002318 File Offset: 0x00001318
        protected override void OnFontChanged(EventArgs e)
        {
            if (this.myPaintedFirstTime)
            {
                base.SetStyle(ControlStyles.UserPaint, false);
            }
            base.OnFontChanged(e);
            if (this.myPaintedFirstTime)
            {
                base.SetStyle(ControlStyles.UserPaint, true);
            }
            this.myFontHeight = this.GetFontHeight();
            this.myUpToDate = false;
            base.Invalidate();
        }

        // Token: 0x0600000D RID: 13 RVA: 0x00002368 File Offset: 0x00001368
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.myUpToDate = false;
            base.Invalidate();
        }

        // Token: 0x0600000E RID: 14 RVA: 0x0000238C File Offset: 0x0000138C
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 15)
            {
                this.myPaintedFirstTime = true;
                if (!this.myUpToDate || !this.myCaretUpToDate)
                {
                    this.GetBitmaps();
                }
                this.myUpToDate = true;
                this.myCaretUpToDate = true;
                if (this.myPictureBox.Image != null)
                {
                    this.myPictureBox.Image.Dispose();
                }
                this.myPictureBox.Image = (Image)this.myAlphaBitmap.Clone();
                return;
            }
            if (m.Msg == 276 || m.Msg == 277)
            {
                this.myUpToDate = false;
                base.Invalidate();
                return;
            }
            if (m.Msg == 513 || m.Msg == 516 || m.Msg == 515)
            {
                this.myUpToDate = false;
                base.Invalidate();
                return;
            }
            if (m.Msg == 512 && m.WParam.ToInt32() != 0)
            {
                this.myUpToDate = false;
                base.Invalidate();
            }
        }

        // Token: 0x0600000F RID: 15 RVA: 0x00002498 File Offset: 0x00001498
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Token: 0x17000001 RID: 1
        // (get) Token: 0x06000010 RID: 16 RVA: 0x000024C4 File Offset: 0x000014C4
        // (set) Token: 0x06000011 RID: 17 RVA: 0x000024D8 File Offset: 0x000014D8
        public new BorderStyle BorderStyle
        {
            get
            {
                return base.BorderStyle;
            }
            set
            {
                if (this.myPaintedFirstTime)
                {
                    base.SetStyle(ControlStyles.UserPaint, false);
                }
                base.BorderStyle = value;
                if (this.myPaintedFirstTime)
                {
                    base.SetStyle(ControlStyles.UserPaint, true);
                }
                this.myBitmap = null;
                this.myAlphaBitmap = null;
                this.myUpToDate = false;
                base.Invalidate();
            }
        }

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x06000012 RID: 18 RVA: 0x00002528 File Offset: 0x00001528
        // (set) Token: 0x06000013 RID: 19 RVA: 0x00002564 File Offset: 0x00001564
        public new Color BackColor
        {
            get
            {
                return Color.FromArgb((int)base.BackColor.R, (int)base.BackColor.G, (int)base.BackColor.B);
            }
            set
            {
                this.myBackColor = value;
                base.BackColor = value;
                this.myUpToDate = false;
            }
        }

        // Token: 0x17000003 RID: 3
        // (get) Token: 0x06000014 RID: 20 RVA: 0x00002588 File Offset: 0x00001588
        // (set) Token: 0x06000015 RID: 21 RVA: 0x0000259C File Offset: 0x0000159C
        public override bool Multiline
        {
            get
            {
                return base.Multiline;
            }
            set
            {
                if (this.myPaintedFirstTime)
                {
                    base.SetStyle(ControlStyles.UserPaint, false);
                }
                base.Multiline = value;
                if (this.myPaintedFirstTime)
                {
                    base.SetStyle(ControlStyles.UserPaint, true);
                }
                this.myBitmap = null;
                this.myAlphaBitmap = null;
                this.myUpToDate = false;
                base.Invalidate();
            }
        }

        // Token: 0x06000016 RID: 22 RVA: 0x000025EC File Offset: 0x000015EC
        private int GetFontHeight()
        {
            Graphics graphics = base.CreateGraphics();
            SizeF sizeF = graphics.MeasureString("X", this.Font);
            graphics.Dispose();
            return (int)sizeF.Height;
        }

        // Token: 0x06000017 RID: 23 RVA: 0x00002620 File Offset: 0x00001620
        private void GetBitmaps()
        {
            if (this.myBitmap == null || this.myAlphaBitmap == null || this.myBitmap.Width != base.Width || this.myBitmap.Height != base.Height || this.myAlphaBitmap.Width != base.Width || this.myAlphaBitmap.Height != base.Height)
            {
                this.myBitmap = null;
                this.myAlphaBitmap = null;
            }
            if (this.myBitmap == null)
            {
                this.myBitmap = new Bitmap(base.ClientRectangle.Width, base.ClientRectangle.Height);
                this.myUpToDate = false;
            }
            if (!this.myUpToDate)
            {
                base.SetStyle(ControlStyles.UserPaint, false);
                win32.CaptureWindow(this, ref this.myBitmap);
                base.SetStyle(ControlStyles.UserPaint, true);
                base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                this.BackColor = Color.FromArgb(this.myBackAlpha, this.myBackColor);
            }
            Rectangle destRect = new Rectangle(0, 0, base.ClientRectangle.Width, base.ClientRectangle.Height);
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap[] array = new ColorMap[]
            {
                new ColorMap()
            };
            array[0].OldColor = Color.FromArgb(255, this.myBackColor);
            array[0].NewColor = Color.FromArgb(this.myBackAlpha, this.myBackColor);
            imageAttributes.SetRemapTable(array);
            if (this.myAlphaBitmap != null)
            {
                this.myAlphaBitmap.Dispose();
            }
            this.myAlphaBitmap = new Bitmap(base.ClientRectangle.Width, base.ClientRectangle.Height);
            Graphics graphics = Graphics.FromImage(this.myAlphaBitmap);
            graphics.DrawImage(this.myBitmap, destRect, 0, 0, base.ClientRectangle.Width, base.ClientRectangle.Height, GraphicsUnit.Pixel, imageAttributes);
            graphics.Dispose();
            if (this.Focused && this.SelectionLength == 0)
            {
                Graphics graphics2 = Graphics.FromImage(this.myAlphaBitmap);
                if (this.myCaretState)
                {
                    Point point = this.findCaret();
                    Pen pen = new Pen(this.ForeColor, 3f);
                    graphics2.DrawLine(pen, point.X, point.Y, point.X, point.Y + this.myFontHeight);
                    graphics2.Dispose();
                }
            }
        }

        // Token: 0x06000018 RID: 24 RVA: 0x0000287C File Offset: 0x0000187C
        private Point findCaret()
        {
            Point result = new Point(0);
            int selectionStart = base.SelectionStart;
            IntPtr wParam = new IntPtr(selectionStart);
            int dw = win32.SendMessage(base.Handle, 214, wParam, IntPtr.Zero);
            result = new Point(dw);
            if (selectionStart == 0)
            {
                result = new Point(0);
            }
            else if (selectionStart >= this.Text.Length)
            {
                wParam = new IntPtr(selectionStart - 1);
                dw = win32.SendMessage(base.Handle, 214, wParam, IntPtr.Zero);
                result = new Point(dw);
                Graphics graphics = base.CreateGraphics();
                string text = this.Text.Substring(this.Text.Length - 1, 1) + "X";
                SizeF sizeF = graphics.MeasureString(text, this.Font);
                SizeF sizeF2 = graphics.MeasureString("X", this.Font);
                graphics.Dispose();
                int num = (int)(sizeF.Width - sizeF2.Width);
                result.X += num;
                if (selectionStart == this.Text.Length)
                {
                    string a = this.Text.Substring(this.Text.Length - 1, 1);
                    if (a == "\n")
                    {
                        result.X = 1;
                        result.Y += this.myFontHeight;
                    }
                }
            }
            return result;
        }

        // Token: 0x06000019 RID: 25 RVA: 0x000029DC File Offset: 0x000019DC
        private void myTimer1_Tick(object sender, EventArgs e)
        {
            this.myCaretState = !this.myCaretState;
            this.myCaretUpToDate = false;
            base.Invalidate();
        }

        // Token: 0x0600001A RID: 26 RVA: 0x00002A08 File Offset: 0x00001A08
        private void InitializeComponent()
        {
            this.components = new Container();
        }

        // Token: 0x17000004 RID: 4
        // (get) Token: 0x0600001B RID: 27 RVA: 0x00002A20 File Offset: 0x00001A20
        // (set) Token: 0x0600001C RID: 28 RVA: 0x00002A34 File Offset: 0x00001A34
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        [Description("The alpha value used to blend the control's background. Valid values are 0 through 255.")]
        public int BackAlpha
        {
            get
            {
                return this.myBackAlpha;
            }
            set
            {
                int num = value;
                if (num > 255)
                {
                    num = 255;
                }
                this.myBackAlpha = num;
                this.myUpToDate = false;
                base.Invalidate();
            }
        }

        // Token: 0x04000001 RID: 1
        private ButtonPerso.uPictureBox myPictureBox;

        // Token: 0x04000002 RID: 2
        private bool myUpToDate = false;

        // Token: 0x04000003 RID: 3
        private bool myCaretUpToDate = false;

        // Token: 0x04000004 RID: 4
        private Bitmap myBitmap;

        // Token: 0x04000005 RID: 5
        private Bitmap myAlphaBitmap;

        // Token: 0x04000006 RID: 6
        private int myFontHeight = 10;

        // Token: 0x04000007 RID: 7
        private System.Windows.Forms.Timer myTimer1;

        // Token: 0x04000008 RID: 8
        private bool myCaretState = true;

        // Token: 0x04000009 RID: 9
        private bool myPaintedFirstTime = false;

        // Token: 0x0400000A RID: 10
        private Color myBackColor = Color.White;

        // Token: 0x0400000B RID: 11
        private int myBackAlpha = 10;

        // Token: 0x0400000C RID: 12
        private Container components = null;

        // Token: 0x02000003 RID: 3
        private class uPictureBox : PictureBox
        {
            // Token: 0x0600001D RID: 29 RVA: 0x00002A68 File Offset: 0x00001A68
            public uPictureBox()
            {
                base.SetStyle(ControlStyles.Selectable, false);
                base.SetStyle(ControlStyles.UserPaint, true);
                base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                base.SetStyle(ControlStyles.DoubleBuffer, true);
                this.Cursor = null;
                base.Enabled = true;
                base.SizeMode = PictureBoxSizeMode.Normal;
            }

            // Token: 0x0600001E RID: 30 RVA: 0x00002ABC File Offset: 0x00001ABC
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 513 || m.Msg == 516 || m.Msg == 515 || m.Msg == 675 || m.Msg == 512)
                {
                    win32.PostMessage(base.Parent.Handle, (uint)m.Msg, m.WParam, m.LParam);
                }
                else if (m.Msg == 514)
                {
                    base.Parent.Invalidate();
                }
                base.WndProc(ref m);
            }
        }

    }
}
