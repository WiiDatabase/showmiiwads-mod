/* This file is part of libWiiSharp
 * Copyright (C) 2009 Leathl
 * 
 * libWiiSharp is free software: you can redistribute it and/or
 * modify it under the terms of the GNU General Public License as published
 * by the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * libWiiSharp is distributed in the hope that it will be
 * useful, but WITHOUT ANY WARRANTY; without even the implied warranty
 * of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace libWiiSharp
{
    /// <summary>
    /// A static class that provides functions to dump a byte array to view it like in a hex-editor.
    /// In combination with a DataGridView, it's even able to act like a hex-editor.
    /// Big files (25kB ++) will take quite a long time, so don't use this for big files.
    /// </summary>
    public static class HexView
    {
        private static string savedValue;

        #region Public Functions
        /// <summary>
        /// Displays the byte array like a hex editor in a ListView.
        /// Columns will be created, estimated width is ~685 px.
        /// Big files (25kB ++) will take quite a long time, so don't use this for big files.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="listView"></param>
        public static void DumpToListView(byte[] data, ListView listView)
        {
            dumpToListView(data, listView);
        }

        /// <summary>
        /// Displays the byte array like a hex editor in a DataGridView.
        /// Columns will be created, estimated width is ~685 px.
        /// Big files (25kB ++) will take quite a long time, so don't use this for big files.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataGridView"></param>
        public static void DumpToDataGridView(byte[] data, DataGridView dataGridView)
        {
            dumpToDataGridView(data, dataGridView);
        }

        /// <summary>
        /// Dumps a DataGridView back to a byte array.
        /// The DataGridView must have the right format.
        /// Big files (25kB ++) will take quite a long time, so don't use this for big files.
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        public static byte[] DumpFromDataGridView(DataGridView dataGridView)
        {
            return dumpFromDataGridView(dataGridView);
        }

        /// <summary>
        /// Displays the byte array like a hex editor in a RichTextBox.
        /// Big files (25kB ++) will take quite a long time, so don't use this for big files.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="richTextBox"></param>
        public static void DumpToRichTextBox(byte[] data, RichTextBox richTextBox)
        {
            richTextBox.Clear();
            richTextBox.Font = new System.Drawing.Font("Courier New", 9);
            richTextBox.ReadOnly = true;

            richTextBox.Text = DumpAsString(data);
        }

        /// <summary>
        /// Displays the byte array like a hex editor in a TextBox.
        /// Big files (25kB ++) will take quite a long time, so don't use this for big files.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="textBox"></param>
        public static void DumpToTextBox(byte[] data, TextBox textBox)
        {
            textBox.Multiline = true;
            textBox.Font = new System.Drawing.Font("Courier New", 9);
            textBox.ReadOnly = true;

            textBox.Text = DumpAsString(data).Replace("\n", "\r\n");
        }

        /// <summary>
        /// Displays the byte array like a hex editor as a string array.
        /// Be sure to use "Courier New" as a font, so every char has the same width.
        /// Big files (25kB ++) will take quite a long time, so don't use this for big files.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string[] DumpAsStringArray(byte[] data)
        {
            return dumpAsStringArray(data);
        }

        /// <summary>
        /// Displays the byte array like a hex editor as a string.
        /// Be sure to use "Courier New" as a font, so every char has the same width.
        /// Big files (25kB ++) will take quite a long time, so don't use this for big files.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DumpAsString(byte[] data)
        {
            return string.Join("\n", dumpAsStringArray(data));
        }

        /// <summary>
        /// Link your DataGridView's CellEndEdit event with this function.
        /// The dump and byte values will be synchronized.
        /// Don't forget to also link the CellBeginEdit event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dataGridView = sender as DataGridView;

                if (dataGridView.Columns[e.ColumnIndex].HeaderText.ToLower() == "dump")
                {
                    string curDump = (string)dataGridView.Rows[e.RowIndex].Cells[17].Value;

                    if (curDump != savedValue)
                    {
                        if (curDump.Length != 16) throw new Exception();

                        for (int i = 0; i < 16; i++)
                            if (toAscii(byte.Parse((string)dataGridView.Rows[e.RowIndex].Cells[i + 1].Value, System.Globalization.NumberStyles.HexNumber)) != curDump[i])
                                dataGridView.Rows[e.RowIndex].Cells[i + 1].Value = fromAscii(curDump[i]).ToString("x2");
                    }
                }
                else
                {
                    if (((string)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).Length == 1)
                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0" + dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    int index = int.Parse(dataGridView.Columns[e.ColumnIndex].HeaderText, System.Globalization.NumberStyles.HexNumber);
                    string curDump = (string)dataGridView.Rows[e.RowIndex].Cells[17].Value;

                    curDump = curDump.Remove(index, 1);
                    curDump = curDump.Insert(index, toAscii(byte.Parse((string)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value, System.Globalization.NumberStyles.HexNumber)).ToString());

                    dataGridView.Rows[e.RowIndex].Cells[17].Value = curDump;

                    if (((string)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).Length > 2)
                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ((string)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).Remove(0, ((string)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).Length - 2);
                }
            }
            catch { ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value = savedValue; }
        }

        /// <summary>
        /// Link your DataGridView's CellBeginEdit event with this function.
        /// The dump and byte values will be synchronized.
        /// Don't forget to also link the CellEndEdit event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            savedValue = (string)((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }
        #endregion

        #region Private Functions
        private static string[] dumpAsStringArray(byte[] data)
        {
            List<string> result = new List<string>();
            string curLine = string.Empty;

            //Dump
            int offset = 0;

            while ((data.Length - offset) / 16.0 >= 1.0)
            {
                curLine = string.Empty;
                curLine += offset.ToString("x8") + "   ";
                string asciiString = string.Empty;

                for (int i = 0; i < 16; i++)
                {
                    curLine += data[offset + i].ToString("x2") + " ";
                    asciiString += toAscii(data[offset + i]);
                }

                curLine += "  " + asciiString;
                result.Add(curLine);
                offset += 16;
            }

            //Dump Rest
            if (data.Length > offset)
            {
                curLine = string.Empty;
                curLine += offset.ToString("x8") + "   ";
                string asciiString = string.Empty;

                for (int i = 0; i < 16; i++)
                {
                    if (i < (data.Length - offset))
                    {
                        curLine += data[offset + i].ToString("x2") + " ";
                        asciiString += toAscii(data[offset + i]);
                    }
                    else curLine += "   ";
                }

                curLine += "  " + asciiString;
                result.Add(curLine);
            }

            return result.ToArray();
        }

        private static byte[] dumpFromDataGridView(DataGridView dataGridView)
        {
            try
            {
                List<byte> result = new List<byte>();
                int currentRow = 0;

                //Dump rows
                while (!string.IsNullOrEmpty((string)dataGridView.Rows[currentRow].Cells[1].Value))
                {
                    for (int j = 0; j < 16; j++)
                        if (!string.IsNullOrEmpty((string)dataGridView.Rows[currentRow].Cells[j + 1].Value))
                            result.Add(byte.Parse((string)dataGridView.Rows[currentRow].Cells[j + 1].Value, System.Globalization.NumberStyles.HexNumber));

                    if (currentRow == dataGridView.Rows.Count - 1) break;
                    currentRow++;
                }

                return result.ToArray();
            }
            catch { throw new Exception("An error occured. The DataGridView might have the wrong format!"); }
        }

        private static void dumpToDataGridView(byte[] data, DataGridView dataGridView)
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            dataGridView.Font = new System.Drawing.Font("Courier New", 9);

            //Create Columns
            DataGridViewColumn tempColumn = new DataGridViewColumn();
            tempColumn.HeaderText = "Offset";
            tempColumn.Width = 80;
            tempColumn.CellTemplate = new DataGridViewTextBoxCell();
            

            dataGridView.Columns.Add(tempColumn);

            for (int i = 0; i < 16; i++)
            {
                tempColumn = new DataGridViewColumn();
                tempColumn.HeaderText = i.ToString("x1");
                tempColumn.Width = 30;
                tempColumn.CellTemplate = new DataGridViewTextBoxCell();

                dataGridView.Columns.Add(tempColumn);
            }

            tempColumn = new DataGridViewColumn();
            tempColumn.HeaderText = "Dump";
            tempColumn.Width = 125;
            tempColumn.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView.Columns.Add(tempColumn);

            //Dump
            int offset = 0;

            while ((data.Length - offset) / 16.0 >= 1.0)
            {
                DataGridViewRow dgvRow = new DataGridViewRow();
                int index = dgvRow.Cells.Add(new DataGridViewTextBoxCell());
                dgvRow.Cells[index].Value = offset.ToString("x8");
                dgvRow.Cells[index].ReadOnly = true;

                string asciiString = string.Empty;

                for (int i = 0; i < 16; i++)
                {
                    index = dgvRow.Cells.Add(new DataGridViewTextBoxCell());
                    dgvRow.Cells[index].Value = data[offset + i].ToString("x2");
                    asciiString += toAscii(data[offset + i]);
                }

                index = dgvRow.Cells.Add(new DataGridViewTextBoxCell());
                dgvRow.Cells[index].Value = asciiString;
                dataGridView.Rows.Add(dgvRow);
                offset += 16;
            }

            //Dump Rest
            if (data.Length > offset)
            {
                DataGridViewRow dgvRow = new DataGridViewRow();
                int index = dgvRow.Cells.Add(new DataGridViewTextBoxCell());
                dgvRow.Cells[index].Value = offset.ToString("x8");
                dgvRow.Cells[index].ReadOnly = true;

                string asciiString = string.Empty;

                for (int i = 0; i < 16; i++)
                {
                    if (i < (data.Length - offset))
                    {
                        index = dgvRow.Cells.Add(new DataGridViewTextBoxCell());
                        dgvRow.Cells[index].Value = data[offset + i].ToString("x2");
                        asciiString += toAscii(data[offset + i]);
                    }
                    else
                    {
                        dgvRow.Cells.Add(new DataGridViewTextBoxCell());
                    }
                }

                index = dgvRow.Cells.Add(new DataGridViewTextBoxCell());
                dgvRow.Cells[index].Value = asciiString;
                dataGridView.Rows.Add(dgvRow);
            }
        }

        private static void dumpToListView(byte[] data, ListView listView)
        {
            listView.Columns.Clear();
            listView.Items.Clear();
            listView.View = View.Details;
            listView.Font = new System.Drawing.Font("Courier New", 9);

            //Create Columns
            listView.Columns.Add("Offset", "Offset", 80, HorizontalAlignment.Left, string.Empty);

            for (int i = 0; i < 16; i++)
                listView.Columns.Add(i.ToString("x1"), i.ToString("x1"), 30, HorizontalAlignment.Left, string.Empty);

            listView.Columns.Add("Dump", "Dump", 125, HorizontalAlignment.Left, string.Empty);

            //Dump
            int offset = 0;

            while ((data.Length - offset) / 16.0 >= 1.0)
            {
                ListViewItem lvI = new ListViewItem(offset.ToString("x8"));
                string asciiString = string.Empty;

                for (int i = 0; i < 16; i++)
                {
                    lvI.SubItems.Add(data[offset + i].ToString("x2"));
                    asciiString += toAscii(data[offset + i]);
                }

                lvI.SubItems.Add(asciiString);
                listView.Items.Add(lvI);
                offset += 16;
            }

            //Dump Rest
            if (data.Length > offset)
            {
                ListViewItem lvI = new ListViewItem(offset.ToString("x8"));
                string asciiString = string.Empty;

                for (int i = 0; i < 16; i++)
                {
                    if (i < (data.Length - offset))
                    {
                        lvI.SubItems.Add(data[offset + i].ToString("x2"));
                        asciiString += toAscii(data[offset + i]);
                    }
                    else lvI.SubItems.Add(string.Empty);
                }

                lvI.SubItems.Add(asciiString);
                listView.Items.Add(lvI);
            }
        }

        private static char toAscii(byte value)
        {
            if (value < 0x20 || value > 0x7E) return '.';
            return (char)value;
        }

        private static byte fromAscii(char value)
        {
            return (byte)value;
        }
        #endregion
    }
}
