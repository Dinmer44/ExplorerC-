using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace BL
{
     public class tagListChangedEvntArgs : EventArgs
    {
        
        private MyTag oldTag;

        public MyTag OldTag
        {
            get { return oldTag; }
            set { oldTag = value; }
        }
        private MyTag newTag;
        

        public MyTag NewTag
        {
            get { return newTag; }
            set { newTag = value; }
        }
        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }


      

        public tagListChangedEvntArgs(MyTag oldTag, MyTag newTag, string fullName)
        {
            this.oldTag = oldTag;
            this.newTag = newTag;
            this.filePath = fullName;
        }

        public tagListChangedEvntArgs(MyTag newTag)
        {
            this.newTag = newTag;
        }
    }


    public class MyFile
    {
        
        public event EventHandler<tagListChangedEvntArgs> Tlc;
        private FileInfo fi;

        public FileInfo FI
        {
            get { return fi; }
            set { fi = value; }
        }

        private string fileName;

        public virtual string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        private List<MyTag> myTagList;

        public List<MyTag> MyTagList
        {
            get { return myTagList; }
            set {myTagList = value; }
        }
        public MyFile(string fileName)
        {
            fi = new FileInfo(fileName);
            myTagList = new List<MyTag>();

        }
        //search method- returns true if one of the tags is the same
        public bool Search(List<MyTag> l)
        {
            bool b = false;
            this.myTagList.ForEach(x =>
            
            { if (l.Any(y => x.Name.CompareTo(y.Name) == 0))
                    b= true; });
            return b;
            
        }
    
       
        public void onChangeTag(MyTag newT, MyTag oldT)
        {
            //Search for the tag in the list and update it
            var tag = myTagList.FirstOrDefault(t => t.Name.CompareTo(oldT.Name) == 0);
            tag = newT;
            Tlc?.Invoke(this, new tagListChangedEvntArgs(oldT ,newT, fi.FullName));
        }
        public void onAddTag(MyTag newTag)
        {
            myTagList.Add(newTag);
            
            if(Tlc!=null)
                Tlc(this, new tagListChangedEvntArgs(newTag, newTag, fi.FullName));

        }
        //preview of the file
        public virtual Control showFile()
        {
            Label lbl_perview = new Label();
            lbl_perview.AutoSize = true;
            lbl_perview.Location = new System.Drawing.Point(50, 249);
            lbl_perview.Name = "lbl_perview";
            lbl_perview.Size = new System.Drawing.Size(144, 17);
            lbl_perview.TabIndex = 2;
            lbl_perview.Text = "אין תצוגה מקדימה זמינה";
            return lbl_perview;
        }



    }
}
