using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prosto_Pets  // had to land this thing right into the main dir, sorry: otherwise we had misunderstandings with VS Designer. Probably just me.
{
    public partial class PBwithText_v2 : UserControl
    {
        public PBwithText_v2()
        {
            InitializeComponent();
        }

        // ContentAlignment is an enumeration defined in the System.Drawing
        // namespace that specifies the alignment of content on filename drawing 
        // surface.
        private ContentAlignment alignmentValue = ContentAlignment.MiddleLeft;

        [
        Category("Misc"),
        Description("Specifies the alignment of text.")
        ]
        public ContentAlignment TextAlignment
        {

            get
            {
                return alignmentValue;
            }
            set
            {
                alignmentValue = value;

                // The Invalidate method invokes the OnPaint method described 
                // in step 3.
                Invalidate();
            }
        }

        // Bar Color
        private Color barColor = Color.LightGreen;

        [
        Category("Misc"),
        Description("Specifies the progress bar color.")
        ]
        public Color BarColor
        {

            get
            {
                return barColor;
            }
            set
            {
                barColor = value;

                // The Invalidate method invokes the OnPaint method described 
                // in step 3.
                Invalidate();
            }
        }

        // Percent to display
        private int percent = 70;

        [
        Category("Misc"),
        Description("Specifies the value to display: 0-100.")
        ]
        public int Percent
        {

            get
            {
                return percent;
            }
            set
            {
                percent = value;

                // The Invalidate method invokes the OnPaint method described 
                // in step 3.
                Invalidate();
            }
        }

        // Is Favourite (pet)
        private bool favourite = true;

        [
        Category("Misc"),
        Description("Specifies if the pet is a Favourite (Purple border).")
        ]
        public bool Favourite
        {

            get
            {
                return favourite;
            }
            set
            {
                favourite = value;

                // The Invalidate method invokes the OnPaint method described 
                // in step 3.
                Invalidate();
            }
        }


        // Text to Display
        private string text = "Progress Bar";

        [
        Category("Misc"),
        Description("Specifies the Text to display: 0-100.")
        ]
        public override string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;

                // The Invalidate method invokes the OnPaint method described 
                // in step 3.
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rectangle = this.ClientRectangle;
            //Rectangle r = new Rectangle( 2, 2, (int)(rectangle.Width * ((double)percent / 100)) - 4, rectangle.Height-4 );
            Rectangle r = new Rectangle(0, 0, (int)(rectangle.Width * ((double)percent / 100)), rectangle.Height);
            e.Graphics.FillRectangle(new SolidBrush(BarColor), r);
            //r = new Rectangle(2, 2, rectangle.Width - 4, rectangle.Height - 4);
            r = new Rectangle(0, 0, rectangle.Width, rectangle.Height);
            if (Favourite)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Purple,2.0f), r);
            }
            else
            {
                // e.Graphics.DrawRectangle(new Pen(Color.Gray, 2.0f), r);  
            }

            StringFormat style = new StringFormat();
            style.Alignment = StringAlignment.Near;
            switch (alignmentValue)
            {
                case ContentAlignment.MiddleLeft:
                    style.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    style.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.MiddleCenter:
                    style.Alignment = StringAlignment.Center;
                    break;
            }

            // Call the DrawString method of the System.Drawing class to write   
            // text. Text and ClientRectangle are properties inherited from
            // Control.
            //r = new Rectangle(2, 2, rectangle.Width - 4, rectangle.Height - 4);
            r = new Rectangle(0, 0, rectangle.Width, rectangle.Height);
            style.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(
                Text,
                Font,
                new SolidBrush(ForeColor),
                r, style);
        }
    }

}
