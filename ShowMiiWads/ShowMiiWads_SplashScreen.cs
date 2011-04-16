/* This file is part of ShowMiiWads
 * Copyright (C) 2009 Leathl
 * 
 * ShowMiiWads is free software: you can redistribute it and/or
 * modify it under the terms of the GNU General Public License as published
 * by the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ShowMiiWads is distributed in the hope that it will be
 * useful, but WITHOUT ANY WARRANTY; without even the implied warranty
 * of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
 
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace ShowMiiWads
{
    public partial class ShowMiiWads_SplashScreen : Form
    {
        int foldercount = 0;
        string language = "English";
        string nandpath = "";
        bool portable = false;
        ShowMiiWads_Main smw = new ShowMiiWads_Main();
        Timer t1 = new Timer();
        Timer t2 = new Timer();

        public ShowMiiWads_SplashScreen()
        {
            InitializeComponent();
            this.Icon = global::ShowMiiWads.Properties.Resources.ShowMiiWads_Icon;
            this.CenterToScreen();
            Cursor.Current = Cursors.WaitCursor;
            t1.Tick += new EventHandler(t1_Tick);
            t1.Interval = 500;
            t1.Start();
            t2.Tick += new EventHandler(t2_Tick);
            t2.Interval = 750;
        }

        void t1_Tick(object sender, EventArgs e)
        {
            t1.Stop();
            string[] folders = LoadFoldersFromXml();

            if (foldercount == 0)
            {
                pbProgress.Value = 100;

                if (!string.IsNullOrEmpty(nandpath)) { AddNand(); SaveListNand(); }

                t2.Start();
            }
            else
            {
                for (int i = 0; i < folders.Length; i++)
                {
                    pbProgress.Value = (i + 1) * 100 / folders.Length;
                    AddWads(folders[i]);
                }
                pbProgress.Value = 100;
                if (!string.IsNullOrEmpty(nandpath)) { AddNand(); SaveListNand(); }

                SaveList();

                t2.Start();
            }
        }

        void t2_Tick(object sender, EventArgs e)
        {
            t2.Stop();
            this.Dispose(false);
            smw.Show();
        }

        private string[] LoadFoldersFromXml()
        {
            DataSet ds = new DataSet();
            ds.ReadXmlSchema(Application.StartupPath + "\\ShowMiiWads.cfg");
            ds.ReadXml(Application.StartupPath + "\\ShowMiiWads.cfg");

            try
            {
                try { portable = Convert.ToBoolean(ds.Tables["Settings"].Rows[0]["Portable"].ToString()); }
                catch { portable = false; }
                nandpath = ds.Tables["Settings"].Rows[0]["NandPath"].ToString();
                language = ds.Tables["Settings"].Rows[0]["Language"].ToString();
                foldercount = Convert.ToInt32(ds.Tables["Folders"].Rows[0]["Foldercount"]);

                if (portable)
                    nandpath = nandpath.Remove(0, 1).Insert(0, Application.StartupPath.Substring(0, 1));

                string[] folders = new string[foldercount];
                for (int i = 0; i < foldercount; i++)
                {
                    if (!portable)
                        folders[i] = ds.Tables["Folders"].Rows[0]["Folder" + i.ToString()].ToString();
                    else
                        folders[i] = ds.Tables["Folders"].Rows[0]["Folder" + i.ToString()].ToString().Remove(0, 1).Insert(0, Application.StartupPath.Substring(0, 1));
                }

                return folders;
            }
            catch { return new string[0]; }
        }

        /// <summary>
        /// Adds a folder to lvWads
        /// </summary>
        /// <param name="path">Path to Add to Listview</param>
        private void AddWads(string path)
        {
            bool thisexists = false;

            for (int f = 0; f < lvWads.Groups.Count; f++)
            {
                if (lvWads.Groups[f].Tag.ToString() == path)
                {
                    thisexists = true;
                }
            }

            if (Directory.Exists(path))
            {
                string[] wadfiles = Directory.GetFiles(path, "*.wad", SearchOption.TopDirectoryOnly);

                if (wadfiles.Length > 0 && thisexists == false)
                {
                    string[,] Infos = new string[wadfiles.Length, 11];
                    int i = 0;

                    lvWads.Groups.Add(new ListViewGroup(path, path));
                    lvWads.Groups[lvWads.Groups.Count - 1].Tag = path;

                    foreach (string thisFile in wadfiles)
                    {
                        try
                        {
                            byte[] wadfile = Wii.Tools.LoadFileToByteArray(thisFile);

                            Infos[i, 0] = thisFile.Remove(0, thisFile.LastIndexOf('\\') + 1);
                            Infos[i, 1] = Wii.WadInfo.GetTitleID(wadfile, 0);
                            Infos[i, 2] = Wii.WadInfo.GetNandBlocks(wadfile);
                            Infos[i, 3] = Wii.WadInfo.GetNandSize(wadfile, true);
                            Infos[i, 4] = Wii.WadInfo.GetIosFlag(wadfile);
                            Infos[i, 5] = Wii.WadInfo.GetRegionFlag(wadfile);
                            Infos[i, 6] = Wii.WadInfo.GetContentNum(wadfile).ToString();
                            Infos[i, 7] = Wii.WadInfo.GetNandPath(wadfile, 0);
                            Infos[i, 8] = Wii.WadInfo.GetChannelType(wadfile, 0);
                            Infos[i, 9] = Wii.WadInfo.GetTitleVersion(wadfile).ToString();

                            switch (language)
                            {
                                case "Dutch":
                                    Infos[i, 10] = Wii.WadInfo.GetChannelTitles(wadfile)[6];
                                    break;
                                case "Italian":
                                    Infos[i, 10] = Wii.WadInfo.GetChannelTitles(wadfile)[5];
                                    break;
                                case "Spanish":
                                    Infos[i, 10] = Wii.WadInfo.GetChannelTitles(wadfile)[4];
                                    break;
                                case "French":
                                    Infos[i, 10] = Wii.WadInfo.GetChannelTitles(wadfile)[3];
                                    break;
                                case "German":
                                    Infos[i, 10] = Wii.WadInfo.GetChannelTitles(wadfile)[2];
                                    break;
                                default:
                                    Infos[i, 10] = Wii.WadInfo.GetChannelTitles(wadfile)[1];
                                    break;
                                case "Japanese":
                                    Infos[i, 10] = Wii.WadInfo.GetChannelTitles(wadfile)[0];
                                    break;
                            }

                            i++;
                        }
                        catch { }
                    }


                    for (int j = 0; j < wadfiles.Length; j++)
                    {
                        lvWads.Items.Insert(lvWads.Items.Count, new ListViewItem(new String[] { Infos[j, 0], Infos[j, 1], Infos[j, 2], Infos[j, 3], Infos[j, 4], Infos[j, 5], Infos[j, 6], Infos[j, 7], Infos[j, 8], Infos[j, 9], Infos[j, 10] })).Group = lvWads.Groups[path];
                    }

                    for (int x = 0; x < lvWads.Items.Count; x++)
                    {
                        if (lvWads.Items[x].Group == null)
                        {
                            lvWads.Items.Remove(lvWads.Items[x]);
                        }

                        if (string.IsNullOrEmpty(lvWads.Items[x].Text))
                        {
                            lvWads.Items.Remove(lvWads.Items[x]);
                        }
                    }

                    lvWads.Groups[lvWads.Groups.Count - 1].Header = lvWads.Groups[lvWads.Groups.Count - 1].Header + " (" + lvWads.Groups[lvWads.Groups.Count - 1].Items.Count + ")";
                }
            }
        }

        /// <summary>
        /// Adds the titles from Nand Backup to lvNand
        /// </summary>
        private void AddNand()
        {
            pbProgress.Value = 100;
            lvNand.Items.Clear();

            if (Directory.Exists(nandpath) &&
                Directory.Exists(nandpath + "\\ticket") &&
                Directory.Exists(nandpath + "\\title"))
            {
                string[] tickets = Directory.GetFiles(nandpath + "\\ticket", "*.tik", SearchOption.AllDirectories);

                if (tickets.Length > 0)
                {
                    string[,] Infos = new string[tickets.Length, 11];
                    Cursor.Current = Cursors.WaitCursor;

                    for (int i = 0; i < tickets.Length; i++)
                    {
                        try
                        {
                            string path1 = tickets[i].Remove(tickets[i].LastIndexOf('\\'));
                            path1 = path1.Remove(0, path1.LastIndexOf('\\') + 1);
                            string path2 = tickets[i].Remove(0, tickets[i].LastIndexOf('\\') + 1);
                            path2 = path2.Remove(path2.LastIndexOf('.'));

                            byte[] tik = Wii.Tools.LoadFileToByteArray(tickets[i]);
                            if (File.Exists(nandpath + "\\title\\" + path1 + "\\" + path2 + "\\content\\title.tmd"))
                            {
                                byte[] tmd = Wii.Tools.LoadFileToByteArray(nandpath + "\\title\\" + path1 + "\\" + path2 + "\\content\\title.tmd");
                                string[,] continfo = Wii.WadInfo.GetContentInfo(tmd);
                                string cid = "00000000";

                                for (int j = 0; j < continfo.GetLength(0); j++)
                                {
                                    if (continfo[j, 1] == "00000000")
                                        cid = continfo[j, 0];
                                }

                                byte[] nullapp = Wii.Tools.LoadFileToByteArray(nandpath + "\\title\\" + path1 + "\\" + path2 + "\\content\\" + cid + ".app");

                                Infos[i, 0] = tickets[i].Remove(0, tickets[i].LastIndexOf('\\') + 1);
                                Infos[i, 1] = Wii.WadInfo.GetTitleID(tik, 0);
                                //Infos[i, 2] = Wii.WadInfo.GetNandBlocks(tmd);
                                //Infos[i, 3] = Wii.WadInfo.GetNandSize(tmd, true);
                                Infos[i, 4] = Wii.WadInfo.GetIosFlag(tmd);
                                Infos[i, 5] = Wii.WadInfo.GetRegionFlag(tmd);
                                //Infos[i, 6] = Wii.WadInfo.GetContentNum(tmd).ToString();
                                Infos[i, 7] = Wii.WadInfo.GetNandPath(tik, 0);
                                Infos[i, 8] = Wii.WadInfo.GetChannelType(tik, 0);
                                Infos[i, 9] = Wii.WadInfo.GetTitleVersion(tmd).ToString();

                                switch (language)
                                {
                                    case "Dutch":
                                        Infos[i, 10] = Wii.WadInfo.GetChannelTitlesFromApp(nullapp)[6];
                                        break;
                                    case "Italian":
                                        Infos[i, 10] = Wii.WadInfo.GetChannelTitlesFromApp(nullapp)[5];
                                        break;
                                    case "Spanish":
                                        Infos[i, 10] = Wii.WadInfo.GetChannelTitlesFromApp(nullapp)[4];
                                        break;
                                    case "French":
                                        Infos[i, 10] = Wii.WadInfo.GetChannelTitlesFromApp(nullapp)[3];
                                        break;
                                    case "German":
                                        Infos[i, 10] = Wii.WadInfo.GetChannelTitlesFromApp(nullapp)[2];
                                        break;
                                    default:
                                        Infos[i, 10] = Wii.WadInfo.GetChannelTitlesFromApp(nullapp)[1];
                                        break;
                                    case "Japanese":
                                        Infos[i, 10] = Wii.WadInfo.GetChannelTitlesFromApp(nullapp)[0];
                                        break;
                                }

                                string[] titlefiles = Directory.GetFiles(nandpath + "\\title\\" + path1 + "\\" + path2, "*", SearchOption.AllDirectories);
                                Infos[i, 6] = (titlefiles.Length - 1).ToString();
                                int nandsize = 0;

                                foreach (string titlefile in titlefiles)
                                {
                                    FileInfo fi = new FileInfo(titlefile);
                                    nandsize += (int)fi.Length;
                                }

                                FileInfo fitik = new FileInfo(tickets[i]);
                                nandsize += (int)fitik.Length;

                                double blocks = (double)((Convert.ToDouble(nandsize) / 1024) / 128);
                                Infos[i, 2] = Math.Ceiling(blocks).ToString();

                                string size = Convert.ToString(Math.Round(Convert.ToDouble(nandsize) * 0.0009765625 * 0.0009765625, 2));
                                if (size.Length > 4) { size = size.Remove(4); }
                                Infos[i, 3] = size.Replace(",", ".") + " MB";
                            }
                        }
                        catch //(Exception ex)
                        {
                            //MessageBox.Show(ex.Message, Messages[19], MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    for (int x = 0; x < Infos.GetLength(0); x++)
                    {
                        if (!string.IsNullOrEmpty(Infos[x, 0]))
                        {
                            lvNand.Items.Add(new ListViewItem(new string[] { Infos[x, 0], Infos[x, 1], Infos[x, 2], Infos[x, 3], Infos[x, 4], Infos[x, 5], Infos[x, 6], Infos[x, 7], Infos[x, 8], Infos[x, 9], Infos[x, 10] }));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Writes the entries of lvWads to an Xml-File
        /// </summary>
        private void SaveList()
        {
            DataSet ds = new DataSet("ShowMiiWads");

            for (int i = 0; i < lvWads.Groups.Count; i++)
            {
                DataTable dt = new DataTable((string)lvWads.Groups[i].Tag);

                for (int z = 0; z < lvWads.Columns.Count; z++)
                {
                    dt.Columns.Add(lvWads.Columns[z].Text);
                }

                for (int j = 0; j < lvWads.Groups[i].Items.Count; j++)
                {
                    dt.Rows.Add(new object[] { lvWads.Groups[i].Items[j].Text,
                        lvWads.Groups[i].Items[j].SubItems[1].Text,
                        lvWads.Groups[i].Items[j].SubItems[2].Text,
                        lvWads.Groups[i].Items[j].SubItems[3].Text,
                        lvWads.Groups[i].Items[j].SubItems[4].Text,
                        lvWads.Groups[i].Items[j].SubItems[5].Text,
                        lvWads.Groups[i].Items[j].SubItems[6].Text,
                        lvWads.Groups[i].Items[j].SubItems[7].Text,
                        lvWads.Groups[i].Items[j].SubItems[8].Text,
                        lvWads.Groups[i].Items[j].SubItems[9].Text,
                        lvWads.Groups[i].Items[j].SubItems[10].Text });
                }

                ds.Tables.Add(dt);
            }

            ds.WriteXml(smw.ListPath);
        }

        /// <summary>
        /// Writes the entries of lvNand to an Xml-File
        /// </summary>
        private void SaveListNand()
        {
            DataSet dsnand = new DataSet("ShowMiiNand");
            DataTable dtnand = new DataTable(nandpath);

            for (int z = 0; z < lvWads.Columns.Count; z++)
            {
                dtnand.Columns.Add(lvNand.Columns[z].Text);
            }

            for (int a = 0; a < lvNand.Items.Count; a++)
            {
                dtnand.Rows.Add(new object[] { lvNand.Items[a].Text,
                        lvNand.Items[a].SubItems[1].Text,
                        lvNand.Items[a].SubItems[2].Text,
                        lvNand.Items[a].SubItems[3].Text,
                        lvNand.Items[a].SubItems[4].Text,
                        lvNand.Items[a].SubItems[5].Text,
                        lvNand.Items[a].SubItems[6].Text,
                        lvNand.Items[a].SubItems[7].Text,
                        lvNand.Items[a].SubItems[8].Text,
                        lvNand.Items[a].SubItems[9].Text,
                        lvNand.Items[a].SubItems[10].Text });
            }

            dsnand.Tables.Add(dtnand);
            dsnand.WriteXml(smw.ListPathNand);
        }
    }
}
