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
    public class Brlan
    {
        #region Public Functions
        /// <summary>
        /// Gets all TPLs that are required by the brlan (Frame Animation).
        /// </summary>
        /// <param name="pathTobrlan"></param>
        /// <returns></returns>
        public static string[] GetBrlanTpls(string pathTobrlan)
        {
            return getBrlanTpls(File.ReadAllBytes(pathTobrlan));
        }

        /// <summary>
        /// Gets all TPLs that are required by the brlan (Frame Animation).
        /// </summary>
        /// <param name="brlanFile"></param>
        /// <returns></returns>
        public static string[] GetBrlanTpls(byte[] brlanFile)
        {
            return getBrlanTpls(brlanFile);
        }

        /// <summary>
        /// Gets all TPLs that are required by the brlan (Frame Animation).
        /// </summary>
        /// <param name="wad"></param>
        /// <param name="banner"></param>
        /// <returns></returns>
        public static string[] GetBrlanTpls(WAD wad, bool banner)
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
                        if (bannerFile.StringTable[y].ToLower() == bannerName + "_start.brlan" ||
                            bannerFile.StringTable[y].ToLower() == bannerName + "_loop.brlan" ||
                            bannerFile.StringTable[y].ToLower() == bannerName + ".brlan")
                        {
                            tpls = Shared.MergeStringArrays(tpls, getBrlanTpls(bannerFile.Data[y]));
                        }
                    }

                    return tpls;
                }
            }

                    return new string[0];
        }
        #endregion

        #region Private Functions
        private static string[] getBrlanTpls(byte[] brlanFile)
        {
            List<string> tpls = new List<string>();
            int tplCount = getNumOfTpls(brlanFile);
            int tplNamePos = 36 + (tplCount * 4);

            for (int i = 0; i < tplCount; i++)
            {
                string thisTpl = string.Empty;

                while (brlanFile[tplNamePos] != 0x00)
                    thisTpl += Convert.ToChar(brlanFile[tplNamePos++]);

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

        private static int getNumOfTpls(byte[] brlanFile)
        {
            return (int)Shared.Swap(BitConverter.ToUInt16(brlanFile, 28));
        }
        #endregion
    }
}
