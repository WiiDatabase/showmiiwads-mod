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
using System.IO;

namespace libWiiSharp
{
    public class Brlyt
    {
        #region Public Functions
        /// <summary>
        /// Gets all TPLs that are required by the brlyt.
        /// </summary>
        /// <param name="pathToBrlyt"></param>
        /// <returns></returns>
        public static string[] GetBrlytTpls(string pathToBrlyt)
        {
            return getBrlytTpls(File.ReadAllBytes(pathToBrlyt));
        }

        /// <summary>
        /// Gets all TPLs that are required by the brlyt.
        /// </summary>
        /// <param name="brlytFile"></param>
        /// <returns></returns>
        public static string[] GetBrlytTpls(byte[] brlytFile)
        {
            return getBrlytTpls(brlytFile);
        }

        /// <summary>
        /// Gets all TPLs that are required by the brlyt.
        /// </summary>
        /// <param name="wad"></param>
        /// <param name="banner"></param>
        /// <returns></returns>
        public static string[] GetBrlytTpls(WAD wad, bool banner)
        {
            if (!wad.HasBanner) return new string[0];

            string bannerName = "banner";
            if (!banner) bannerName = "icon";

            for (int i = 0; i < wad.BannerApp.Nodes.Count; i++)
            {
                if (wad.BannerApp.StringTable[i].ToLower() == bannerName + ".bin")
                {
                    U8 bannerFile = U8.Load(wad.BannerApp.Data[i]);
                    string[] tpls = new string[0];

                    for (int y = 0; y < bannerFile.Nodes.Count; y++)
                    {
                        if (bannerFile.StringTable[y].ToLower() == bannerName + ".brlyt")
                        {
                            tpls = Shared.MergeStringArrays(tpls, getBrlytTpls(bannerFile.Data[y]));
                        }
                    }

                    return tpls;
                }
            }

            return new string[0];
        }
        #endregion

        #region Private Functions
        private static string[] getBrlytTpls(byte[] brlytFile)
        {
            List<string> tpls = new List<string>();
            int tplCount = getNumOfTpls(brlytFile);
            int tplNamePos = 48 + (tplCount * 8);

            for (int i = 0; i < tplCount; i++)
            {
                string thisTpl = string.Empty;

                while (brlytFile[tplNamePos] != 0x00)
                    thisTpl += Convert.ToChar(brlytFile[tplNamePos++]);

                tpls.Add(thisTpl);
                tplNamePos++;
            }

            for (int i = tpls.Count - 1; i >= 0; i--)
            {
                if (!tpls[i].ToLower().EndsWith(".tpl"))
                    tpls.RemoveAt(i);
            }

            return tpls.ToArray();
        }

        private static int getNumOfTpls(byte[] brlytFile)
        {
            return (int)Shared.Swap(BitConverter.ToUInt16(brlytFile, 44));
        }
        #endregion
    }
}
