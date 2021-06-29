using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace BL
{
    public static class MyBrowser
    {
        private static List<DriveInfo> di;

        public static List<DriveInfo> DI
        {
            get { return di; }
            set { di = value; }
        }
        private static List<string> allTags;

        public static List<string> AllTags
        {
            get { return allTags; }
            set { allTags = value; }
        }
        //XML file of all tags in the system
        static string path = @"..\..\AllTags.xml";
        static XDocument doc = XDocument.Load(path);

        public static void LoadBrowser()
        {
            DI = new List<DriveInfo>();
            AllTags = new List<string>();
            string[] drives = Environment.GetLogicalDrives();

            foreach (string drive in drives)
            {
                DriveInfo driveI = new DriveInfo(drive);
                DI.Add(driveI);
            }

            XElement all = doc.Root;
            var tags = all.Elements("Tag");
            //initialize the allTags list by the XML file
            foreach (XElement g in tags)
            {
                AllTags.Add(g.Attribute("name").Value);
            }
            
        }
        //add new tag to the XML file and to the list of all tags
        public static void addTag(string newTag)
        {
            XElement tag = new XElement("Tag", new XAttribute("name", newTag));
            doc.Root.Add(tag);
            AllTags.Add(newTag);
            doc.Save(path);

        }
        
        public static List<MyFile> Search(List<MyTag> l)
        {
            List<MyFile> result = new List<MyFile>();

            //XML file of all folders that contain tagged files
             string path = @"..\..\AllFolders.xml";
             XDocument doc = XDocument.Load(path);
             XElement all = doc.Root;
            //all pathes of folders that contain tagged files
             var allPathes = all.Elements("Folder");
             foreach (XElement p in allPathes)
            {
                //upload the tags file  of the current folder
                //This file contains information about all the tagged files
                try
                {
                    File.SetAttributes($"{p.Attribute("Name").Value}\\tagsFile.xml", FileAttributes.Normal);
                    XDocument filesDoc = XDocument.Load($"{p.Attribute("Name").Value}\\tagsFile.xml");
                    File.SetAttributes($"{p.Attribute("Name").Value}\\tagsFile.xml", FileAttributes.Hidden);
                    XElement TagedFiles = filesDoc.Root;
                    var filesPathes = TagedFiles.Elements("File");
                    //Iterate through the list of tagged files
                    foreach (XElement f in filesPathes)
                    {
                        //Create a file based on the data and initialize the tags in it
                        MyFile mf = new MyFile(f.Attribute("Path").Value);
                        var tags = f.Elements("Tag");
                        foreach (XElement t in tags)
                        {
                            MyTag newTag = new MyTag(t.Value);
                            mf.MyTagList.Add(newTag);
                        }
                        //If the file contains one of the required tags, add the file to the result list
                        if (mf.Search(l))
                            result.Add(mf);

                    }

                }
                catch (DirectoryNotFoundException)
                {

                }

                catch (UnauthorizedAccessException)
                {

                }
            }
            return result;
            

        }
    }
}

