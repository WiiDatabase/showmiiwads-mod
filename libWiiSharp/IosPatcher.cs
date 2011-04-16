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

//Patches based on Dop-Mii - Thanks to Arikado and Lunatik
 
using System;
using System.ComponentModel;
using System.Text;

namespace libWiiSharp
{
    /// <summary>
    /// An IOS patcher which can patch fakesigning, es_identify and nand permissions.
    /// </summary>
    public class IosPatcher
    {
        private WAD wadFile;
        private int esIndex = -1;

        #region Public Functions
        /// <summary>
        /// Loads an IOS wad to patch the es module.
        /// </summary>
        /// <param name="iosWad"></param>
        public void LoadIOS(ref WAD iosWad)
        {
            if ((iosWad.TitleID >> 32) != 1 ||
                (iosWad.TitleID & 0xFFFFFFFF) < 3 ||
                (iosWad.TitleID & 0xFFFFFFFF) > 255)
                throw new Exception("Only IOS WADs can be patched!");

            wadFile = iosWad;
            getEsIndex();
        }

        /// <summary>
        /// Patches fakesigning.
        /// Returns the number of applied patches.
        /// </summary>
        /// <returns></returns>
        public int PatchFakeSigning()
        {
            if (esIndex < 0) return -1;
            return patchFakeSigning(ref wadFile.Contents[esIndex]);
        }

        /// <summary>
        /// Patches es_identify.
        /// Returns the number of applied patches.
        /// </summary>
        /// <returns></returns>
        public int PatchEsIdentify()
        {
            if (esIndex < 0) return -1;
            return patchEsIdentify(ref wadFile.Contents[esIndex]);
        }

        /// <summary>
        /// Patches nand permissions.
        /// Returns the number of applied patches.
        /// </summary>
        /// <returns></returns>
        public int PatchNandPermissions()
        {
            if (esIndex < 0) return -1;
            return patchNandPermissions(ref wadFile.Contents[esIndex]);
        }

        /// <summary>
        /// Patches fakesigning, es_identify and nand permissions.
        /// Returns the number of applied patches.
        /// </summary>
        /// <returns></returns>
        public int PatchAll()
        {
            if (esIndex < 0) return -1;
            return patchAll(ref wadFile.Contents[esIndex]);
        }

        /// <summary>
        /// Patches fakesigning.
        /// Returns the number of applied patches.
        /// </summary>
        /// <returns></returns>
        public int PatchFakeSigning(ref byte[] esModule)
        {
            return patchFakeSigning(ref esModule);
        }

        /// <summary>
        /// Patches es_identify.
        /// Returns the number of applied patches.
        /// </summary>
        /// <returns></returns>
        public int PatchEsIdentify(ref byte[] esModule)
        {
            return patchEsIdentify(ref esModule);
        }

        /// <summary>
        /// Patches nand permissions.
        /// Returns the number of applied patches.
        /// </summary>
        /// <returns></returns>
        public int PatchNandPermissions(ref byte[] esModule)
        {
            return patchNandPermissions(ref esModule);
        }

        /// <summary>
        /// Patches fakesigning, es_identify and nand permissions.
        /// Returns the number of applied patches.
        /// </summary>
        /// <returns></returns>
        public int PatchAll(ref byte[] esModule)
        {
            return patchAll(ref esModule);
        }
        #endregion

        #region Private Functions
        private int patchFakeSigning(ref byte[] esModule)
        {
            fireDebug("Patching Fakesigning...");
            int patchCount = 0;

            byte[] oldHashCheck = { 0x20, 0x07, 0x23, 0xA2 };
            byte[] newHashCheck = { 0x20, 0x07, 0x4B, 0x0B };

            for (int i = 0; i < esModule.Length - 4; i++)
            {
                fireProgress((i + 1) * 100 / esModule.Length);

                if (Shared.CompareByteArrays(esModule, i, oldHashCheck, 0, 4) ||
                    Shared.CompareByteArrays(esModule, i, newHashCheck, 0, 4))
                {
                    fireDebug("   Patching at Offset: 0x{0}", i.ToString("x8").ToUpper());
                    esModule[i + 1] = 0x00;
                    i += 4;
                    patchCount++;
                }
            }

            fireDebug("Patching Fakesigning Finished... (Patches applied: {0})", patchCount);
            return patchCount;
        }

        private int patchEsIdentify(ref byte[] esModule)
        {
            fireDebug("Patching ES_Identify...");
            int patchCount = 0;

            byte[] identifyCheck = { 0x28, 0x03, 0xD1, 0x23 };

            for (int i = 0; i < esModule.Length - 4; i++)
            {
                fireProgress((i + 1) * 100 / esModule.Length);

                if (Shared.CompareByteArrays(esModule, i, identifyCheck, 0, 4))
                {
                    fireDebug("   Patching at Offset: 0x{0}", i.ToString("x8").ToUpper());
                    esModule[i + 2] = 0x00;
                    esModule[i + 3] = 0x00;
                    i += 4;
                    patchCount++;
                }
            }

            fireDebug("Patching ES_Identify Finished... (Patches applied: {0})", patchCount);
            return patchCount;
        }

        private int patchNandPermissions(ref byte[] esModule)
        {
            fireDebug("Patching NAND Permissions...");
            int patchCount = 0;

            byte[] permissionTable = { 0x42, 0x8B, 0xD0, 0x01, 0x25, 0x66 };

            for (int i = 0; i < esModule.Length - 6; i++)
            {
                fireProgress((i + 1) * 100 / esModule.Length);

                if (Shared.CompareByteArrays(esModule, i, permissionTable, 0, 6))
                {
                    fireDebug("   Patching at Offset: 0x{0}", i.ToString("x8").ToUpper());
                    esModule[i + 2] = 0xE0;
                    i += 6;
                    patchCount++;
                }
            }

            fireDebug("Patching NAND Permissions Finished... (Patches applied: {0})", patchCount);
            return patchCount;
        }

        private int patchAll(ref byte[] esModule)
        {
            fireDebug("Patching Fakesigning, ES_Identify and NAND Permissions...");
            int patchCount = 0;

            byte[] oldHashCheck = { 0x20, 0x07, 0x23, 0xA2 };
            byte[] newHashCheck = { 0x20, 0x07, 0x4B, 0x0B };
            byte[] identifyCheck = { 0x28, 0x03, 0xD1, 0x23 };
            byte[] permissionTable = { 0x42, 0x8B, 0xD0, 0x01, 0x25, 0x66 };

            for (int i = 0; i < esModule.Length - 6; i++)
            {
                fireProgress((i + 1) * 100 / esModule.Length);

                if (Shared.CompareByteArrays(esModule, i, oldHashCheck, 0, 4) ||
                    Shared.CompareByteArrays(esModule, i, newHashCheck, 0, 4))
                {
                    fireDebug("   Patching Fakesigning at Offset: 0x{0}", i.ToString("x8").ToUpper());
                    esModule[i + 1] = 0x00;
                    i += 4;
                    patchCount++;
                }
                else if (Shared.CompareByteArrays(esModule, i, identifyCheck, 0, 4))
                {
                    fireDebug("   Patching ES_Identify at Offset: 0x{0}", i.ToString("x8").ToUpper());
                    esModule[i + 2] = 0x00;
                    esModule[i + 3] = 0x00;
                    i += 4;
                    patchCount++;
                }
                else if (Shared.CompareByteArrays(esModule, i, permissionTable, 0, 6))
                {
                    fireDebug("   Patching NAND Permissions at Offset: 0x{0}", i.ToString("x8").ToUpper());
                    esModule[i + 2] = 0xE0;
                    i += 6;
                    patchCount++;
                }
            }

            fireDebug("Patching Fakesigning, ES_Identify and NAND Permissions Finished... (Patches applied: {0})", patchCount);
            return patchCount;
        }

        private void getEsIndex()
        {
            fireDebug("Scanning for ES Module...");
            string iosTag = "$IOSVersion:";

            for (int i = wadFile.NumOfContents - 1; i >= 0; i--)
            {
                fireDebug("   Scanning Content #{0} of {1}...", i + 1, wadFile.NumOfContents);
                fireProgress((i + 1) * 100 / wadFile.NumOfContents);

                for (int j = 0; j < wadFile.Contents[i].Length - 64; j++)
                {
                    if (ASCIIEncoding.ASCII.GetString(wadFile.Contents[i], j, 12) == iosTag)
                    {
                        int curIndex = j + 12;
                        while (wadFile.Contents[i][curIndex] == ' ') { curIndex++; }

                        if (ASCIIEncoding.ASCII.GetString(wadFile.Contents[i], curIndex, 3) == "ES:")
                        {
                            fireDebug("    -> ES Module found!");
                            fireDebug("Scanning for ES Module Finished...");
                            esIndex = i;
                            fireProgress(100);
                            return;
                        }
                    }
                }
            }

            fireDebug(@"/!\/!\/!\ ES Module wasn't found! /!\/!\/!\");
            throw new Exception("ES module wasn't found!");
        }
        #endregion

        #region Events
        /// <summary>
        /// Fires the Progress of various operations
        /// </summary>
        public event EventHandler<ProgressChangedEventArgs> Progress;
        /// <summary>
        /// Fires debugging messages. You may write them into a log file or log textbox.
        /// </summary>
        public event EventHandler<MessageEventArgs> Debug;

        private void fireDebug(string debugMessage, params object[] args)
        {
            EventHandler<MessageEventArgs> debug = Debug;
            if (debug != null)
                debug(new object(), new MessageEventArgs(string.Format(debugMessage, args)));
        }

        private void fireProgress(int progressPercentage)
        {
            EventHandler<ProgressChangedEventArgs> progress = Progress;
            if (progress != null)
                progress(new object(), new ProgressChangedEventArgs(progressPercentage, string.Empty));
        }
        #endregion
    }
}
