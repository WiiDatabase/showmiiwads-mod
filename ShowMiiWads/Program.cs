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
using System.Data;

namespace ShowMiiWads
{
    static class Program
    {
        private static string nandpath = "";
        private static int foldercount = 0;
        private static string splash = "true";

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (System.IO.File.Exists(Application.StartupPath + "\\ShowMiiWads.cfg"))
            {
                LoadSettings();

                if (foldercount == 0 && string.IsNullOrEmpty(nandpath)) { Application.Run(new ShowMiiWads_Main()); }
                else if (splash != "false") { Application.Run(new ShowMiiWads_SplashScreen()); }
                else { Application.Run(new ShowMiiWads_Main()); }
            }
            else { Application.Run(new ShowMiiWads_Main()); }
        }

        private static void LoadSettings()
        {
            DataSet ds = new DataSet();
            ds.ReadXmlSchema(Application.StartupPath + "\\ShowMiiWads.cfg");
            ds.ReadXml(Application.StartupPath + "\\ShowMiiWads.cfg");

            try
            {
                nandpath = ds.Tables["Settings"].Rows[0]["NandPath"].ToString();
                foldercount = Convert.ToInt32(ds.Tables["Folders"].Rows[0]["Foldercount"]);
                splash = ds.Tables["Settings"].Rows[0]["SplashScreen"].ToString();
            }
            catch { }
        }
    }
}
