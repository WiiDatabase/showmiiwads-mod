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

namespace ChannelNameBox
{
    public partial class ChannelNameDialog : Form
    {
        string[] titles = new string[8];
        string formcaption = string.Empty;
        string btncancel = "Cancel";
        bool cbchecked = true;

        public string[] Titles
        {
            get { return titles; }
            set { titles = value; }
        }
        public string FormCaption
        {
            get { return formcaption; }
            set { formcaption = value; }
        }
        public string btnCancelText
        {
            get { return btncancel; }
            set { btncancel = value; }
        }
        public bool cbChecked
        {
            get { return cbchecked; }
            set { cbchecked = value; }
        }

        public ChannelNameDialog()
        {
            InitializeComponent();
            this.Icon = global::ShowMiiWads.Properties.Resources.ShowMiiWads_Icon;
        }

        private void txtChanged(object sender, EventArgs e)
        {
            TextBox thistxt = sender as TextBox;

            if (cbChecked == true)
            {
                txtDe.Text = thistxt.Text;
                txtEng.Text = thistxt.Text;
                txtEs.Text = thistxt.Text;
                txtFr.Text = thistxt.Text;
                txtIt.Text = thistxt.Text;
                txtJap.Text = thistxt.Text;
                txtNe.Text = thistxt.Text;
                txtKor.Text = thistxt.Text;
            }
        }

        private void cbLink_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLink.Checked == true)
            {
                cbChecked = true;
            }
            else
            {
                cbChecked = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            titles[1] = txtEng.Text;
            titles[0] = txtJap.Text;
            titles[2] = txtDe.Text;
            titles[3] = txtFr.Text;
            titles[4] = txtEs.Text;
            titles[5] = txtIt.Text;
            titles[6] = txtNe.Text;
            titles[7] = txtKor.Text;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChannelNameDialog_Load(object sender, EventArgs e)
        {
            this.CenterToParent();

            this.Text = formcaption;
            btnCancel.Text = btncancel;

            if (titles[0] == titles[1] &&
                titles[0] == titles[2] &&
                titles[0] == titles[3] &&
                titles[0] == titles[4] &&
                titles[0] == titles[5] &&
                titles[0] == titles[6] &&
                titles[0] == titles[7]) { cbChecked = true; }
            else { cbChecked = false; }
            cbLink.Checked = cbChecked;

            txtEng.Text = titles[1];
            txtJap.Text = titles[0];
            txtDe.Text = titles[2];
            txtFr.Text = titles[3];
            txtEs.Text = titles[4];
            txtIt.Text = titles[5];
            txtNe.Text = titles[6];
            txtKor.Text = titles[7];

            txtEng.Focus();
        }
    }
}
