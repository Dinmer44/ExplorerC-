using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Factory
    {
      

        

        public static MyFile CreateMyFile(string extension, string path,ref int imageIndex)
        {
            MyFile mf = null;
            switch (extension)
            {
                case ".JPG":
                case ".jpeg":
                    imageIndex = 3;
                    mf = new MyImageFile(path);
                    break;
                case ".mp4":
                case ".mp3":
                    mf = new MyPlayFile(path);
                    imageIndex = 2;
                    break;
                default:
                    mf = new MyTextFile(path);
                    imageIndex = 7;
                    break;
            }
            return mf;
            

        }

    }
}
