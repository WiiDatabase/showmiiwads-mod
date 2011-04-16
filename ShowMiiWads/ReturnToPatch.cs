//This is just a C# version of giantpune's return to any channel patch, thanks pune!

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace ShowMiiWads
{
    enum PatternType
    {
        None,
        NewPattern,
        OldPattern,
        SafePlaceIdentifier,
    }

    class ReturnToPatcher
    {
        #region Public Functions
        public static bool PatchFile(Stream file, uint newId)
        { return patchFile(file, newId); }
        #endregion

        #region Private Functions
        private static bool patchFile(Stream file, uint newId)
        {
            bool foundFirst = false;
            uint safePlacePos = 0, newFound = 0, oldFound = 0;
            uint[] newPositions = new uint[3], oldPositions = new uint[3], positions = new uint[3];
            byte[] temp = new byte[12];

            file.Seek(0, SeekOrigin.Begin);

            while (file.Position < file.Length - 12)
            {
                file.Read(temp, 0, temp.Length);
                file.Seek(-12, SeekOrigin.Current);

                PatternType regionType = checkRegion(temp, (foundFirst ? 8 : 12));

                if (regionType == PatternType.SafePlaceIdentifier)
                {
                    if (safePlacePos == 0)
                        safePlacePos = (uint)file.Position + 0x30;
                }
                else if (regionType == PatternType.NewPattern)
                {
                    if (newFound < 3)
                        newPositions[newFound++] = (uint)file.Position;

                    foundFirst = true;
                }
                else if (regionType == PatternType.OldPattern)
                {
                    if (oldFound < 3)
                        oldPositions[oldFound++] = (uint)file.Position;

                    foundFirst = true;
                }

                if (newFound == 3 && safePlacePos != 0) break; //Everything found...

                file.Seek(4, SeekOrigin.Current);
            }

            if (newFound == 3) { positions = newPositions; }
            else if (oldFound == 3) { positions = oldPositions; }
            else return false;

            if (safePlacePos == 0) return false; //No safe place found
            if (positions[2] - safePlacePos >= 0x1000001) return false; //Too far away

            byte[] jumpPattern = new byte[] { 0x3C, 0x60, 0x00, 0x01, 0x60, 0x63, 0x00, 0x01,
                                              0x3C, 0x80, 0x4A, 0x4F, 0x60, 0x84, 0x44, 0x49,
                                              0x4E, 0x80, 0x00, 0x20 };

            if (newFound < 3)
            {
                jumpPattern[1] = 0xA0;
                jumpPattern[5] = 0xA5;
                jumpPattern[9] = 0xC0;
                jumpPattern[13] = 0xC6;
            }

            jumpPattern[10] = (byte)(newId >> 24);
            jumpPattern[11] = (byte)(newId >> 16);
            jumpPattern[14] = (byte)(newId >> 8);
            jumpPattern[15] = (byte)newId;

            file.Seek(safePlacePos, SeekOrigin.Begin);
            file.Write(jumpPattern, 0, jumpPattern.Length);

            uint newValue;
            byte[] nop = BitConverter.GetBytes(0x60000000);

            newValue = ((safePlacePos - positions[0]) & 0x03FFFFFC) | 0x48000001;
            temp = BitConverter.GetBytes(newValue);

            file.Seek(positions[0], SeekOrigin.Begin);
            file.Write(temp, 0, temp.Length);
            file.Write(nop, 0, nop.Length);

            newValue = ((safePlacePos - positions[1]) & 0x03FFFFFC) | 0x48000001;
            temp = BitConverter.GetBytes(newValue);

            file.Seek(positions[1], SeekOrigin.Begin);
            file.Write(temp, 0, temp.Length);
            file.Write(nop, 0, nop.Length);

            newValue = ((safePlacePos - positions[2]) & 0x03FFFFFC) | 0x48000001;
            temp = BitConverter.GetBytes(newValue);

            file.Seek(positions[2], SeekOrigin.Begin);
            file.Write(temp, 0, temp.Length);
            file.Write(nop, 0, nop.Length);

            return true;
        }

        private static PatternType checkRegion(byte[] region, int length)
        {
            //new __OSLoadMenu() (SM2.0 and higher)
            byte[] newPattern = new byte[] { 0x38, 0x80, 0x00, 0x02, 0x38, 0x60, 0x00, 0x01, 0x38, 0xa0, 0x00, 0x00 };
            //old _OSLoadMenu() (used in launch games) //Maybe also in early VC / WW titles?
            byte[] oldPattern = new byte[] { 0x38, 0xC0, 0x00, 0x02, 0x38, 0xA0, 0x00, 0x01, 0x38, 0xe0, 0x00, 0x00 };
            //identifier for the safe place //Location to store the new title ID
            byte[] safePlaceIdentifier = new byte[] { 0x4D, 0x65, 0x74, 0x72, 0x6F, 0x77, 0x65, 0x72, 0x6B, 0x73, 0x20, 0x54 };

            PatternType result = PatternType.None;
            bool[] isPattern = new bool[] {true, true, true};

            for (int i = 0; i < 12; i++)
            {
                if (i < length) if (region[i] != newPattern[i]) isPattern[0] = false;
                if (i < length) if (region[i] != oldPattern[i]) isPattern[1] = false;
                if (region[i] != safePlaceIdentifier[i]) isPattern[2] = false; //Always 12
            }

            if (isPattern[0]) result = PatternType.NewPattern;
            else if (isPattern[1]) result = PatternType.OldPattern;
            else if (isPattern[2]) result = PatternType.SafePlaceIdentifier;

            return result;
        }
        #endregion
    }
}
