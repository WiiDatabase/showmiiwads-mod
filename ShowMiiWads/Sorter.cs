/* I'm afraid I don't know who originally created this (Sorry!). It's used as a part of ShowMiiWads
 * Copyright (C) Unknown
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

using System.Collections;
using System.Windows.Forms;

public class Sorter : System.Collections.IComparer
{
    public int Column = 0;
    public System.Windows.Forms.SortOrder Order = SortOrder.Ascending;
    public int ColumnToSort;

    public int SortColumn
    {
        set
        {
            ColumnToSort = value;
        }
        get
        {
            return ColumnToSort;
        }
    }

    public int Compare(object x, object y) // IComparer Member
    {
        if (!(x is ListViewItem))
            return (0);
        if (!(y is ListViewItem))
            return (0);

        ListViewItem l1 = (ListViewItem)x;
        ListViewItem l2 = (ListViewItem)y;

        if (l1.ListView.Columns[Column].Tag == null)
        {
            l1.ListView.Columns[Column].Tag = "Text";
        }

        if (l1.ListView.Columns[Column].Tag.ToString() == "Numeric")
        {
            float fl1;
            float fl2;

            if (l1.SubItems[Column].Text.Contains("-")) { fl1 = float.Parse(l1.SubItems[Column].Text.Remove(l1.SubItems[Column].Text.IndexOf(' '))); }
            else { fl1 = float.Parse(l1.SubItems[Column].Text); }
            if (l2.SubItems[Column].Text.Contains("-")) { fl2 = float.Parse(l2.SubItems[Column].Text.Remove(l1.SubItems[Column].Text.IndexOf(' '))); }
            else { fl2 = float.Parse(l2.SubItems[Column].Text); }
            
            

            if (Order == SortOrder.Ascending)
            {
                return fl1.CompareTo(fl2);
            }
            else
            {
                return fl2.CompareTo(fl1);
            }
        }
        else
        {
            string str1 = l1.SubItems[Column].Text;
            string str2 = l2.SubItems[Column].Text;

            if (Order == SortOrder.Ascending)
            {
                return str1.CompareTo(str2);
            }
            else
            {
                return str2.CompareTo(str1);
            }
        }
    }
}

