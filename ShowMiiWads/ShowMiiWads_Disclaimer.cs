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

namespace ShowMiiWads
{
    public partial class ShowMiiWads_Disclaimer : Form
    {
        public bool firststart = false;
        
        public ShowMiiWads_Disclaimer()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbAccept.Checked == true)
            {
                //Enable editing Features
                ShowMiiWads_Main.accepted = "true";
                this.Close(); 
            }
            else if (rbNoUse.Checked == true)
            {
                ShowMiiWads_Main.accepted = "nouse";
                this.Close(); 
            }
        }

        private void Disclaimer_Load(object sender, EventArgs e)
        {
            if (firststart == false)
            {
                this.CenterToParent();
            }
            else
            {
                this.CenterToScreen();
                firststart = false;
            }
        }
    }
}
