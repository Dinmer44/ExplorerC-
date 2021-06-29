using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Windows.Forms;

namespace BL
{
    public class MyFolder
    {
        private DirectoryInfo di;

        public DirectoryInfo DI
        {
            get { return di; }
            set { di = value; }
        }
    

        private List<MyFolder> myFolderList;

        public List<MyFolder> MyFolderList
        {
            set { myFolderList = value; }
            get { return myFolderList; }
            
        }
        private List<MyFile> myFileList;

        public List<MyFile> MyFileList
        {
            set { myFileList = value; }
            get { return myFileList; }
          
        }
        //constructor for initialize empty folder
        public MyFolder(string dir, bool rootFolder)
        {
            this.di = new DirectoryInfo(dir);

        }
        public MyFolder(string dir)
        {
            di = new DirectoryInfo(dir);
            MyFolderList = new List<MyFolder>();
            MyFileList = new List<MyFile>();
            if (di.Exists)
            {


                try
                {
                    //initialize the folders list

                    string[] dirs = Directory.GetDirectories(di.FullName);
                    if (dirs != null)
                        foreach (string d in dirs)
                        {
                            DirectoryInfo dinfo = new DirectoryInfo(d);
                            MyFolder mf = new MyFolder(d, true);
                            myFolderList.Add(mf);

                        }
                }
                catch (UnauthorizedAccessException)
                {

                }
            }
            if(di.Exists)
            try
            {
                string[] fDirs = Directory.GetFiles(di.FullName);
                if (fDirs != null)
                    //initialize thd fils list
                    foreach (string d in fDirs)
                    {
                        MyFile mf = new MyFile(d);
                        myFileList.Add(mf);
                        mf.Tlc += new EventHandler<tagListChangedEvntArgs>(TagListChanged);
                        
                    }
            }
            catch (UnauthorizedAccessException)
            {

            }

        }
        public List<MyFile> search(List<MyTag> l)
        {
            
            return MyFileList.FindAll(f => f.Search(l)).ToList();
            
        }
        private void TagListChanged(object sender, tagListChangedEvntArgs e)
        {
            string path = $"{di.FullName}\\tagsFile.xml";
            string[] fNames = Directory.GetFiles(di.FullName);
            //If there is still no tags file in the folder
            try
            {
                if (!fNames.Any(f => f.CompareTo(path) == 0))
                {

                    //Create a file and add it to the list of files
                    XDocument d = new XDocument(new XElement("fileTag"));
                    d.Save(path);
                    MyFile mf = new MyFile("tagsFile");
                    myFileList.Add(mf);
                }
                File.SetAttributes(path, FileAttributes.Normal);
                XDocument doc = XDocument.Load(path);
                    XElement root = doc.Root;
                
                //In case of adding new tag to the tags list
                if (e.OldTag.Name.CompareTo(e.NewTag.Name) == 0)
                {
                    var allF = root.Elements("File");
                    //If the current file is not yet tagged
                    if (!allF.Any(f => f.Attribute("Path").Value.CompareTo(e.FilePath) == 0))
                    {
                        XElement el = new XElement("File", new XAttribute("Path", e.FilePath), new XElement("Tag", e.NewTag.Name));
                        doc.Root.Add(el);

                    }
                    //If the file has already been tagged, add the tags to the list of tags of the file
                    else
                    {
                        var file = doc.Descendants("File").First(g => g.Attribute("Path").Value.CompareTo(e.FilePath) == 0);
                        file.Add(new XElement(new XElement("Tag", e.NewTag.Name)));

                    }
                }
                //In case of tag update - update in the XML file
                else
                {
                    var f = root.Elements("File");
                    var fi = f.FirstOrDefault(t => t.Value.CompareTo(e.OldTag.Name) == 0);
                    fi.Value = e.NewTag.Name;

                }
                doc.Save(path);

                File.SetAttributes(path, FileAttributes.Hidden);
                string pathTagedFolders = @"..\..\AllFolders.xml";
                XDocument allFoldersDoc = XDocument.Load(pathTagedFolders);
                //Add the folder to the list of folders only if it did not already exist
                if (!allFoldersDoc.Descendants("Folder").Any(f => f.Attribute("Name").Value.CompareTo(di.FullName) == 0))
                {
                    XElement fTag = new XElement("Folder", new XAttribute("Name", di.FullName));
                    allFoldersDoc.Root.Add(fTag);
                    allFoldersDoc.Save(pathTagedFolders);

                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Unauthorized Access");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DirectoryLister",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
           
            
            





        }


    }
}
