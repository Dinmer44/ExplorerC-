using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL
{
    public class MyTextFile : MyFile
    {
        public MyTextFile(string fileName) : base(fileName)

        { }
        public override Control showFile()
        {
            TextBox tb_preview = new TextBox();
            tb_preview.ScrollBars = ScrollBars.Both;
            tb_preview.Multiline = true;
            tb_preview.Size = new Size(180, 450);
            tb_preview.Location = new Point(20, 25);

            try
            {
                using (StreamReader sr = new StreamReader(this.FI.FullName))
                {
                    tb_preview.Text = sr.ReadToEnd();
                }
            }
            catch (Exception e) { };

            return tb_preview;



        }
    }
}
