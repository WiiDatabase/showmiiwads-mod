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
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace ShowMiiWads
{
    public partial class ShowMiiWads_Preview : Form
    {
        public string wadfile = "";
        public bool fromwad = false;
        public bool edited = false;
        public string backup = "false";
        private bool replaced = false;

        public ShowMiiWads_Preview()
        {
            InitializeComponent();
            this.Icon = global::ShowMiiWads.Properties.Resources.ShowMiiWads_Icon;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Preview_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Directory.Exists(ShowMiiWads_Main.TempPath)) Directory.Delete(ShowMiiWads_Main.TempPath, true);
            cbBanner.Items.Clear();
            cbIcon.Items.Clear();
        }

        private void Preview_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            if (fromwad == true)
            {
                cbLz77.Visible = true;
                sepReplace.Visible = true;
                tsReplace.Visible = true;
            }

            string[] bannerpics = Directory.GetFiles(ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\banner_bin_OUT\\arc\\timg", "*.png");
            string[] iconpics = Directory.GetFiles(ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\icon_bin_OUT\\arc\\timg", "*.png");

            foreach (string thispic in bannerpics)
            {
                string picname = thispic.Remove(0, thispic.LastIndexOf('\\') + 1);
                picname = picname.Remove(picname.LastIndexOf('.'));
                cbBanner.Items.Add((object)picname);
            }

            foreach (string thispic in iconpics)
            {
                string picname = thispic.Remove(0, thispic.LastIndexOf('\\') + 1);
                picname = picname.Remove(picname.LastIndexOf('.'));
                cbIcon.Items.Add((object)picname);
            }

            try { cbBanner.SelectedIndex = 0; } catch { try { cbIcon.SelectedIndex = 0; } catch { } }
        }

        private void cbBanner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBanner.SelectedIndex != -1)
            {
                pbPic.ImageLocation = ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\banner_bin_OUT\\arc\\timg\\" + cbBanner.SelectedItem.ToString() + ".png";
                
                byte[] tpl = Wii.Tools.LoadFileToByteArray(ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\banner_bin_OUT\\arc\\timg\\" + cbBanner.SelectedItem.ToString() + ".tpl");
                lbSize.Text = Wii.TPL.GetTextureWidth(tpl).ToString() + " x " + Wii.TPL.GetTextureHeight(tpl).ToString();
                lbFormat.Text = Wii.TPL.GetTextureFormatName(tpl);

                cbIcon.SelectedIndex = -1;
            }
        }

        private void cbIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIcon.SelectedIndex != -1)
            {
                pbPic.ImageLocation = ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\icon_bin_OUT\\arc\\timg\\" + cbIcon.SelectedItem.ToString() + ".png";

                byte[] tpl = Wii.Tools.LoadFileToByteArray(ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\icon_bin_OUT\\arc\\timg\\" + cbIcon.SelectedItem.ToString() + ".tpl");
                lbSize.Text = Wii.TPL.GetTextureWidth(tpl).ToString() + " x " + Wii.TPL.GetTextureHeight(tpl).ToString();
                lbFormat.Text = Wii.TPL.GetTextureFormatName(tpl);

                cbBanner.SelectedIndex = -1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (fromwad == true)
            {
                if (replaced == true)
                {
                    try
                    {
                        string[] pngs = Directory.GetFiles(ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta", "*.png", SearchOption.AllDirectories);

                        foreach (string png in pngs)
                            File.Delete(png);

                        File.Delete(ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\banner.bin");
                        File.Delete(ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\icon.bin");

                        byte[] bannerbin = Wii.U8.PackU8(ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\banner_bin_OUT");
                        if (cbLz77.Checked == true) bannerbin = Wii.Lz77.Compress(bannerbin);
                        bannerbin = Wii.U8.AddHeaderIMD5(bannerbin);
                        Wii.Tools.SaveFileFromByteArray(bannerbin, ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\banner.bin");

                        byte[] iconbin = Wii.U8.PackU8(ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\icon_bin_OUT");
                        if (cbLz77.Checked == true) iconbin = Wii.Lz77.Compress(iconbin);
                        iconbin = Wii.U8.AddHeaderIMD5(iconbin);
                        Wii.Tools.SaveFileFromByteArray(iconbin, ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\icon.bin");

                        Directory.Delete(ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\banner_bin_OUT", true);
                        Directory.Delete(ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\icon_bin_OUT", true);

                        string[] channeltitles = Wii.WadInfo.GetChannelTitlesFromApp(ShowMiiWads_Main.TempPath + "\\00000000.app");
                        int[] sizes = new int[3];

                        File.Delete(ShowMiiWads_Main.TempPath + "\\00000000.app");
                        byte[] nullapp = Wii.U8.PackU8(ShowMiiWads_Main.TempPath + "\\00000000_app_OUT", out sizes[0], out sizes[1], out sizes[2]);
                        nullapp = Wii.U8.AddHeaderIMET(nullapp, channeltitles, sizes);
                        Wii.Tools.SaveFileFromByteArray(nullapp, ShowMiiWads_Main.TempPath + "\\00000000.app");
                        Directory.Delete(ShowMiiWads_Main.TempPath + "\\00000000_app_OUT", true);

                        string[] tmd = Directory.GetFiles(ShowMiiWads_Main.TempPath, "*.tmd");
                        Wii.WadEdit.UpdateTmdContents(tmd[0]);
                        Wii.WadEdit.TruchaSign(tmd[0], 1);

                        string[] trailer = Directory.GetFiles(ShowMiiWads_Main.TempPath, "*.trailer");
                        if (trailer.Length > 0)
                        {
                            File.Delete(trailer[0]);
                            File.Copy(ShowMiiWads_Main.TempPath + "\\00000000.app", trailer[0]);
                        }

                        CreateBackup(wadfile);
                        File.Delete(wadfile);
                        Wii.WadPack.PackWad(ShowMiiWads_Main.TempPath, wadfile);

                        this.edited = true;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                cmPic.Show(MousePosition);
            }
        }

        private void CreateBackup(string FileToBackup)
        {
            if (backup == "true")
            {
                if (!File.Exists(FileToBackup + ".backup"))
                    File.Copy(FileToBackup, FileToBackup + ".backup");
            }
        }

        private void cmSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = pbPic.ImageLocation.Remove(0, pbPic.ImageLocation.LastIndexOf('\\') + 1);
            sfd.Filter = "PNG|*.png";
            if (sfd.ShowDialog() == DialogResult.OK)
                File.Copy(pbPic.ImageLocation, sfd.FileName);
        }

        private void btnBannerImages_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < cbBanner.Items.Count; i++)
                {
                    string filename = cbBanner.Items[i].ToString();
                    File.Copy(ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\banner_bin_OUT\\arc\\timg\\" + filename + ".png", fbd.SelectedPath + "\\" + filename + ".png");
                }
            }
        }

        private void btnIconImages_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < cbIcon.Items.Count; i++)
                {
                    string filename = cbIcon.Items[i].ToString();
                    File.Copy(ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\icon_bin_OUT\\arc\\timg\\" + filename + ".png", fbd.SelectedPath + "\\" + filename + ".png");
                }
            }
        }

        private void btnBothImages_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < cbBanner.Items.Count; i++)
                {
                    string filename = cbBanner.Items[i].ToString();
                    File.Copy(ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\banner_bin_OUT\\arc\\timg\\" + filename + ".png", fbd.SelectedPath + "\\Banner_" + filename + ".png");
                }
                for (int i = 0; i < cbIcon.Items.Count; i++)
                {
                    string filename = cbIcon.Items[i].ToString();
                    File.Copy(ShowMiiWads_Main.TempPath + "\\00000000_app_OUT\\meta\\icon_bin_OUT\\arc\\timg\\" + filename + ".png", fbd.SelectedPath + "\\Icon_" + filename + ".png");
                }
            }
        }

        private Image ResizeImage(Image img, int x, int y)
        {
            Image newimage = new Bitmap(x, y);
            using (Graphics gfx = Graphics.FromImage(newimage))
            {
                gfx.DrawImage(img, 0, 0, x, y);
            }
            return newimage;
        }

        private void ReplaceTPL(string imagefile, int format)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG|*.png|JPG|*.jpg|GIF|*.gif|BMP|*.bmp|All|*.png; *.jpg; *.gif; *.bmp";
            ofd.FilterIndex = 5;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image img = Image.FromFile(ofd.FileName);

                    if (img != null)
                    {
                        int currentx = Convert.ToInt32(lbSize.Text.Remove(lbSize.Text.IndexOf(' ')));
                        int currenty = Convert.ToInt32(lbSize.Text.Remove(0, lbSize.Text.LastIndexOf(' ')));

                        if (img.Width != currentx || img.Height != currenty) { img = ResizeImage(img, currentx, currenty); }

                        File.Delete(imagefile.Remove(imagefile.LastIndexOf('.')) + ".tpl");
                        Wii.TPL.ConvertToTPL(img, imagefile.Remove(imagefile.LastIndexOf('.')) + ".tpl", format);

                        pbPic.ImageLocation = "";
                        File.Delete(imagefile);
                        Bitmap bmp = Wii.TPL.ConvertFromTPL(imagefile.Remove(imagefile.LastIndexOf('.')) + ".tpl");
                        bmp.Save(imagefile);
                        pbPic.ImageLocation = imagefile;

                        byte[] tpl = Wii.Tools.LoadFileToByteArray(imagefile.Remove(imagefile.LastIndexOf('.')) + ".tpl");
                        lbSize.Text = Wii.TPL.GetTextureWidth(tpl).ToString() + " x " + Wii.TPL.GetTextureHeight(tpl).ToString();
                        lbFormat.Text = Wii.TPL.GetTextureFormatName(tpl);

                        replaced = true;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnRGBA8_Click(object sender, EventArgs e)
        {
            ReplaceTPL(pbPic.ImageLocation, 6);
        }

        private void btnRGB565_Click(object sender, EventArgs e)
        {
            ReplaceTPL(pbPic.ImageLocation, 4);
        }

        private void btnRGB5A3_Click(object sender, EventArgs e)
        {
            ReplaceTPL(pbPic.ImageLocation, 5);
        }
    }
}
