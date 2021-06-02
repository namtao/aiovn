using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilsLib.Control
{
    class ToggleSwitch : CheckBox
    {
        //Fields
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.DarkSlateGray;
        private bool solidStyle = true;

        //Constructor
        public ToggleSwitch()
        {
            this.MinimumSize = new Size(50, 20);
        }

        //Properties
        public Color OnBackColor
        {
            get { return onBackColor; }
            set
            {
                onBackColor = value;
                this.Invalidate();
            }
        }

        public Color OnToggleColor
        {
            get { return onToggleColor; }
            set
            {
                onToggleColor = value;
                this.Invalidate();
            }
        }

        public Color OffBackColor
        {
            get { return offBackColor; }
            set
            {
                offBackColor = value;
                this.Invalidate();
            }
        }

        public Color OffToggleColor
        {
            get { return offToggleColor; }
            set
            {
                offToggleColor = value;
                this.Invalidate();
            }
        }

        [Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { }
        }

        [Category("RJ Code Advance")]
        [DefaultValue(true)]
        public bool SolidStyle
        {
            get { return solidStyle; }
            set
            {
                solidStyle = value;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.OnPaintBackground(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = new GraphicsPath())
            {
                var d = Padding.All;
                var r = this.Height - 2 * d;
                path.AddArc(d, d, r, r, 90, 180);
                path.AddArc(this.Width - r - d, d, r, r, -90, 180);
                path.CloseFigure();
                e.Graphics.FillPath(Checked ? Brushes.DarkGray : Brushes.LightGray, path);
                r = Height - 1;
                var rect = Checked ? new Rectangle(Width - r - 1, 0, r, r)
                                   : new Rectangle(0, 0, r, r);
                e.Graphics.FillEllipse(Checked ? Brushes.Green : Brushes.DarkGray, rect);
            }
        }
    }
}
