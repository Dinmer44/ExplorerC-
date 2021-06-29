using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL
{
    public class MyImageFile : MyFile
    {
        public MyImageFile(string fileName) : base(fileName)
        {
        }

        public override Control showFile()
        {
            PictureBox pb_preview = new PictureBox();
            pb_preview.Image = Image.FromFile(FI.FullName);
            pb_preview.Size = new Size(200, 320);
            pb_preview.SizeMode = PictureBoxSizeMode.Zoom;
            pb_preview.Location = new Point(20, 25);
            return pb_preview;
        }

    }
}
