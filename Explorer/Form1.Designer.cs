namespace Explorer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.addTagBtn = new System.Windows.Forms.Button();
            this.allTagsTextBox = new System.Windows.Forms.TextBox();
            this.tagToAdd = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "folder.png");
            this.imageList2.Images.SetKeyName(1, "image.png");
            this.imageList2.Images.SetKeyName(2, "video.ico");
            this.imageList2.Images.SetKeyName(3, "dvd.png");
            this.imageList2.Images.SetKeyName(4, "drive2.png");
            this.imageList2.Images.SetKeyName(5, "drive1.png");
            this.imageList2.Images.SetKeyName(6, "pdf.png");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "drive1.png");
            this.imageList1.Images.SetKeyName(2, "video.ico");
            this.imageList1.Images.SetKeyName(3, "image.png");
            this.imageList1.Images.SetKeyName(4, "dvd.png");
            this.imageList1.Images.SetKeyName(5, "drive1.png");
            this.imageList1.Images.SetKeyName(6, "drive2.png");
            this.imageList1.Images.SetKeyName(7, "pdf.png");
            // 
            // treeView1
            // 
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList2;
            this.treeView1.Location = new System.Drawing.Point(654, 47);
            this.treeView1.Name = "treeView1";
            this.treeView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeView1.RightToLeftLayout = true;
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(274, 281);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.dirsTreeView_BeforeExpand);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(245, 47);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(405, 474);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(0, 4);
            this.searchBox.Multiline = true;
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(244, 131);
            this.searchBox.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(245, 4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(683, 41);
            this.textBox2.TabIndex = 3;
            // 
            // addTagBtn
            // 
            this.addTagBtn.Enabled = false;
            this.addTagBtn.Location = new System.Drawing.Point(654, 398);
            this.addTagBtn.Name = "addTagBtn";
            this.addTagBtn.Size = new System.Drawing.Size(274, 53);
            this.addTagBtn.TabIndex = 4;
            this.addTagBtn.Text = "Add Tag";
            this.addTagBtn.UseVisualStyleBackColor = true;
            this.addTagBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // allTagsTextBox
            // 
            this.allTagsTextBox.Location = new System.Drawing.Point(654, 456);
            this.allTagsTextBox.Multiline = true;
            this.allTagsTextBox.Name = "allTagsTextBox";
            this.allTagsTextBox.Size = new System.Drawing.Size(274, 65);
            this.allTagsTextBox.TabIndex = 5;
            // 
            // tagToAdd
            // 
            this.tagToAdd.Location = new System.Drawing.Point(654, 330);
            this.tagToAdd.Multiline = true;
            this.tagToAdd.Name = "tagToAdd";
            this.tagToAdd.Size = new System.Drawing.Size(274, 63);
            this.tagToAdd.TabIndex = 5;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(0, 141);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(244, 52);
            this.searchBtn.TabIndex = 6;
            this.searchBtn.Text = "search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // previewPanel
            // 
            this.previewPanel.Location = new System.Drawing.Point(18, 199);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(209, 289);
            this.previewPanel.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.previewPanel);
            this.panel1.Controls.Add(this.searchBtn);
            this.panel1.Controls.Add(this.tagToAdd);
            this.panel1.Controls.Add(this.allTagsTextBox);
            this.panel1.Controls.Add(this.addTagBtn);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.searchBox);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(943, 547);
            this.panel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 545);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button addTagBtn;
        private System.Windows.Forms.TextBox allTagsTextBox;
        private System.Windows.Forms.TextBox tagToAdd;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.Panel panel1;
    }
}

