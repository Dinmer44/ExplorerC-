using BL;
using System;
using System.Collections.Generic;
using System.Drawing;
//using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Explorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //global variables - pointer to the current folder and to the current file, Useful for adding a new tag
        static MyFolder currentFolder = new MyFolder(@"..\..");
        static MyFile currntFile = new MyFile(@"..\..\AllTags.xml");
        
        private void dirsTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {

            if (e.Node.Nodes.Count > 0)
            {

                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {

                    e.Node.Nodes.Clear();
                    currentFolder = e.Node.Tag as MyFolder;
                    //keep the directory's full path from the tag
                    var path = (e.Node.Tag as MyFolder).DI.FullName;
                    //get the list of sub direcotires
                    string[] dirs = Directory.GetDirectories(path);
                    
                    foreach (string dir in dirs)
                    {
                        MyFolder mf = new MyFolder(dir);
                        MyTreeNode node = new MyTreeNode(mf.DI.Name, 0, 1);
                        try
                        {
                            node.Tag = mf;
                            //if the directory has sub directories add the place holder
                            if (mf.DI.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0);
                         
                        }
                        catch (UnauthorizedAccessException)
                        {
                            //display a locked folder icon
                            node.ImageIndex = 1;
                            node.SelectedImageIndex = 2;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DirectoryLister",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            e.Node.Nodes.Add(node);
                            (node.Parent.Tag as MyFolder).MyFolderList.Add(node.Tag as MyFolder);

                        }
                    }
                    
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        { 
            MyBrowser.LoadBrowser();
            MyBrowser.DI.ForEach(d =>
            {
                int driveImage;
                switch (d.DriveType)    //set the drive's icon
                {
                    case DriveType.CDRom:
                        driveImage = 4;
                        break;
                    case DriveType.Network:
                        driveImage = 6;
                        break;
                    case DriveType.NoRootDirectory:
                        driveImage = 6;
                        break;
                    case DriveType.Unknown:
                        driveImage = 8;
                        break;
                    default:
                        driveImage = 5;
                        break;
                }
                MyTreeNode node = new MyTreeNode(d.Name.Substring(0, 1), driveImage, driveImage);
                ListViewItem item = new ListViewItem(d.Name.Substring(0, 2), driveImage);
                item.SubItems.Add("...");
                listView1.Items.Add(item);
                MyFolder mf = new MyFolder(d.Name);
                //keep the directory's full path at the tag property
                item.Tag = mf;
                node.Tag = mf;
                if (d.IsReady == true)
                {
                    //if the directory has sub directories add the place holder
                    node.Nodes.Add("...");
                }
                treeView1.Nodes.Add(node);

            });



        }
        //By clicking on the node we will see the contents of the folder in the listView
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {

                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    listView1.Clear();
                    //get the current path from the tag property
                    var path = (e.Node.Tag as MyFolder).DI.FullName;
                    string[] dirs = Directory.GetDirectories(path);
                    string[] fils = Directory.GetFiles(path);
                    foreach (string dir in dirs)
                    {
                        //create new folder and new listViewItem by the path
                        MyFolder mf = new MyFolder(dir);
                        ListViewItem item = new ListViewItem(mf.DI.Name, 0);
                    try
                        {
                            //save data on the item in the 'tag' property
                            item.Tag = mf;
                            //if the directory has sub directories add the place holder
                            if (mf.DI.GetDirectories().Count() > 0||mf.DI.GetFiles().Count()>0)
                                item.SubItems.Add("...");
                        }
                        catch (UnauthorizedAccessException)
                        {
                            //display a locked folder icon
                            item.ImageIndex = 1;
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DirectoryLister",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            listView1.Items.Add(item);
                        }
                    }
                    //go through the files' pathes array
                    foreach (string fil in fils)
                    {
                        MyFile mf = new MyFile(fil);
                        ListViewItem item = new ListViewItem(mf.FI.Name);
                        //create new file object by the fatcoty (factory design pattern)
                        mf = Factory.CreateMyFile(mf.FI.Extension, fil, ref imageIndex);
                        item.ImageIndex = imageIndex;
                        try
                        {
                            item.Tag = mf;
                        }
                        catch (UnauthorizedAccessException)
                        {
                            //display a locked folder icon
                            item.ImageIndex = 1;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DirectoryLister",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                           
                            listView1.Items.Add(item);
                        }

                    }
                    
                }
            }
        }
        //global variable 
        int imageIndex = 0;
        //show the inner content of a folder, if file was clicked nothing will happen
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            
            if (listView1.SelectedItems[0].SubItems.Count>1 && listView1.SelectedItems[0].SubItems[1].Text == "...")
            {
                //get the list of sub direcotires
                currentFolder = listView1.SelectedItems[0].Tag as MyFolder;
                var path = (listView1.SelectedItems[0].Tag as MyFolder).DI.FullName;
                string[] dirs = Directory.GetDirectories(path);
                string[] fils = Directory.GetFiles(path);
                listView1.Clear();
                foreach (string dir in dirs)
                {
                    MyFolder mf = new MyFolder(dir);
                    ListViewItem item = new ListViewItem(mf.DI.Name, 0);
                    try
                    {
                        item.Tag = mf;
                        //if the directory has sub directories add the place holder
                        if (mf.DI.GetDirectories().Count() > 0||mf.DI.GetFiles().Count()>0)
                            item.SubItems.Add("...");
                
                    }
                    catch (UnauthorizedAccessException)
                    {
                        //display a locked folder icon
                        item.ImageIndex = 1;
                        //item.SelectedImageIndex = 2;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "DirectoryLister",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {

                        listView1.Items.Add(item);
                        currentFolder.MyFolderList.Add(item.Tag as MyFolder);
                    }
                }
                foreach (string fil in fils)
                {
                    MyFile mf = new MyFile(fil);
                    ListViewItem item = new ListViewItem(mf.FI.Name);
                    mf = Factory.CreateMyFile(mf.FI.Extension, fil, ref imageIndex);
                    
                    item.ImageIndex = imageIndex;
                    try
                    {
                        //keep the directory's full path in the tag for use later
                        item.Tag = mf;


                    }
                    catch (UnauthorizedAccessException)
                    {
                        //display a locked folder icon
                        item.ImageIndex = 7;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "DirectoryLister",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }finally
                    {
                        listView1.Items.Add(item);
                      currentFolder.MyFileList.Add(item.Tag as MyFile);

                    }

                }
               
            }
            //In case of the current Item has no sub Items and was clicked, show all his tags in the textBox
            else
                if (listView1.SelectedItems[0].SubItems.Count == 1)
            {
                currntFile = listView1.SelectedItems[0].Tag as MyFile;
                Controls.Add(currntFile.showFile());
                foreach (MyTag t in (listView1.SelectedItems[0].Tag as MyFile).MyTagList)
                {
                    allTagsTextBox.Text += t.Name + ", ";

                };
            }
          
        }
        //button for adding new tag to a file
        private void button1_Click(object sender, EventArgs e)
        {
            MyBrowser.addTag(tagToAdd.Text);
            MyTag t = new MyTag(tagToAdd.Text);
            currentFolder.MyFileList.FirstOrDefault(f => f.FI.FullName.CompareTo(currntFile.FI.FullName) == 0).onAddTag(t);
            tagToAdd.Clear();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            //create tags list from the textBox
            List<MyTag> l = new List<MyTag>();
            var list = searchBox.Text.Split(' ').ToList();
            list.ForEach(x => l.Add(new MyTag(x)));
            listView1.Clear();
            MyBrowser.Search(l).ForEach(x =>
            {
                MyFile mf = new MyFile(x.FI.Name);
                ListViewItem item = new ListViewItem(mf.FI.Name);
                mf = Factory.CreateMyFile(mf.FI.Extension, x.FI.FullName, ref imageIndex);
                item.ImageIndex = imageIndex;
                try
                {
                    //keep the directory's full path in the tag for use later
                    item.Tag = mf;


                }
                catch (UnauthorizedAccessException)
                {
                    //display a locked folder icon
                    item.ImageIndex = 7;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "DirectoryLister",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    listView1.Items.Add(item);
                    currentFolder.MyFileList.Add(item.Tag as MyFile);

                }
            });

        }
    }
}
