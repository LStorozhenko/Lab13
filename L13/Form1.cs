using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L13
{
    public partial class Form1 : Form
    {
        private DirectoryInfo directoryInfo;
        public Form1()
        {
            InitializeComponent();
            this.fileSystemTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.fileSystemTreeView_BeforeExpand);
            this.fileSystemTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.fileSystemTreeView_AfterSelect);
            this.filterTextBox.TextChanged += new System.EventHandler(this.filterTextBox_TextChanged);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDrives();
        }
        private void LoadDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                TreeNode driveNode = new TreeNode(drive.Name);
                driveNode.Tag = drive;

                if (drive.IsReady == true)
                {
                    try
                    {
                        foreach (DirectoryInfo dir in drive.RootDirectory.GetDirectories())
                        {
                            TreeNode dirNode = new TreeNode(dir.Name);
                            dirNode.Tag = dir;
                            dirNode.Nodes.Add("");

                            driveNode.Nodes.Add(dirNode);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                }

                fileSystemTreeView.Nodes.Add(driveNode);
            }
        }
        private void fileSystemTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode currentNode = e.Node;

            if (currentNode.Nodes.Count == 1 && currentNode.Nodes[0].Text == "")
            {
                currentNode.Nodes.Clear();
                directoryInfo = (DirectoryInfo)currentNode.Tag;
                try
                {
                    foreach (DirectoryInfo subDir in directoryInfo.GetDirectories())
                    {
                        TreeNode node = new TreeNode(subDir.Name);
                        node.Tag = subDir;
                        node.Nodes.Add("");
                        currentNode.Nodes.Add(node);
                    }
                    foreach (FileInfo file in directoryInfo.GetFiles())
                    {
                        TreeNode node = new TreeNode(file.Name);
                        node.Tag = file;
                        currentNode.Nodes.Add(node);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show($"Access denied: {ex.Message}");
                }
            }
        }
        private void fileSystemTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is FileInfo)
            {
                FileInfo file = (FileInfo)e.Node.Tag;

                if (IsTextFile(file))
                {
                    try
                    {
                        string fileContent;
                        using (StreamReader reader = new StreamReader(file.FullName, Encoding.UTF8))
                        {
                            fileContent = reader.ReadToEnd();
                        }
                        textBox1.Text = fileContent;
                        filePropertiesLabel.Text = $"Name: {file.Name}\nSize: {file.Length} bytes\nCreation time: {file.CreationTime}\nAttributes: {file.Attributes.ToString()}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (IsImageFile(file))
                {
                    try
                    {
                        Image image = Image.FromFile(file.FullName);
                        Image thumbnail = image.GetThumbnailImage(pictureBox1.Width, pictureBox1.Height, null, IntPtr.Zero);
                        pictureBox1.Image = thumbnail;

                        filePropertiesLabel.Text = $"Name: {file.Name}\nSize: {file.Length} bytes\nCreation time: {file.CreationTime}\nAttributes: {file.Attributes.ToString()}\n\nImage dimensions: {thumbnail.Width} x {thumbnail.Height}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    filePropertiesLabel.Text = $"Name: {file.Name}\nSize: {file.Length} bytes\nCreation time: {file.CreationTime}\nAttributes: {file.Attributes.ToString()}\n\nCannot display content for this file type.";
                }
            }
            else if (e.Node.Tag is DirectoryInfo)
            {
                DirectoryInfo dir = (DirectoryInfo)e.Node.Tag;
                filePropertiesLabel.Text = $"Name: {dir.Name}\nCreation time: {dir.CreationTime}\nAttributes: {dir.Attributes.ToString()}";
            }
            else if (e.Node.Tag is DriveInfo)
            {
                DriveInfo drive = (DriveInfo)e.Node.Tag;
                filePropertiesLabel.Text = $"Drive letter: {drive.Name}\nDrive type: {drive.DriveType}\nAvailable space: {drive.AvailableFreeSpace} bytes";
            }
        }

        private bool IsTextFile(FileInfo file)
        {
            string extension = file.Extension.ToLower();
            return extension == ".txt" || extension == ".csv" || extension == ".log" || extension == ".doc" || extension == ".docx" || extension == ".zip" || extension == ".pdf";
        }

        private bool IsImageFile(FileInfo file)
        {
            string extension = file.Extension.ToLower();
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif";
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            string filterText = filterTextBox.Text.ToLower();
            ApplyFilter(filterText);
        }
        private void clearFilterButton_Click(object sender, EventArgs e)
        {
            filterTextBox.Text = "";
            ResetTreeView();
        }

        private void filterFilesButton_Click(object sender, EventArgs e)
        {
            ApplyFilter("*.txt");
        }

        private void filterDirectoriesButton_Click(object sender, EventArgs e)
        {
            ApplyFilter("DIR");
        }

        private void ApplyFilter(string filterText)
        {
            fileSystemTreeView.BeginUpdate();
            fileSystemTreeView.Nodes.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                TreeNode driveNode = new TreeNode(drive.Name);
                driveNode.Tag = drive;
                if (drive.IsReady == true)
                {
                    try
                    {
                        foreach (DirectoryInfo dir in drive.RootDirectory.EnumerateDirectories("*", SearchOption.TopDirectoryOnly)
                                                                         .Where(d => d.Name.ToLowerInvariant().Contains(filterText)))
                        {
                            TreeNode dirNode = new TreeNode(dir.Name);
                            dirNode.Tag = dir;
                            dirNode.Nodes.Add("");

                            driveNode.Nodes.Add(dirNode);
                        }
                        foreach (FileInfo file in drive.RootDirectory.EnumerateFiles("*", SearchOption.TopDirectoryOnly)
                                                                     .Where(f => f.Name.ToLowerInvariant().Contains(filterText)))
                        {
                            TreeNode fileNode = new TreeNode(file.Name);
                            fileNode.Tag = file;

                            driveNode.Nodes.Add(fileNode);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                }
                fileSystemTreeView.Nodes.Add(driveNode);
            }
            fileSystemTreeView.EndUpdate();
        }
        private void ResetTreeView()
        {
            fileSystemTreeView.BeginUpdate();
            fileSystemTreeView.Nodes.Clear();
            LoadDrives();
            fileSystemTreeView.EndUpdate();
        }
    }
}