/* This file is part of ShowMiiWads mod (Original code by Leathl)
 * This is the port of an original code in C : wstc.c
 * (Code could be found a the end of this page)
 * I didn't find who wrote it, but all credit goes to him (even if his code was silly buggy :p)
 * Copyright (C) 2011 orwel
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
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;


namespace ShowMiiWads
{
    public static class SettingTxt
    {
        public static uint LolCrypt(byte[] stuff)
        {
            uint key = 0x73b5dbfa;
            for (int i = 0; i < stuff.Length; i++)
            {
                if (stuff[i] != '\0')
                {
                    stuff[i] ^= (byte)(key & 0xff);
                    key = ((key << 1) | (key >> 31));
                }
            }

            return key;
        }

        public static bool isValidSerialNumber(string serial)
        {
            Regex myRegex = new Regex(@"(^[a-zA-Z]{2,3})(\d+$)");

            if (!String.IsNullOrEmpty(serial))
                return myRegex.IsMatch(serial);

            return false;
        }

        public static void GenerateFile(string serialNumber, string region, string path)
        {

            byte[] settingTxt = new byte[0x100];
            string code, serno;
            string settingTemplateEur = "AREA=EUR\r\nMODEL=RVL-001(EUR)\r\nDVD=0\r\nMPCH=0x7FFE\r\nCODE={0}\r\nSERNO={1}\r\nVIDEO=PAL\r\nGAME=EU\r\n";
            string settingTemplateUsa = "AREA=USA\r\nMODEL=RVL-001(USA)\r\nDVD=0\r\nMPCH=0x7FFE\r\nCODE={0}\r\nSERNO={1}\r\nVIDEO=NTSC\r\nGAME=US\r\n";
            string settingTemplateJap = "AREA=JPN\r\nMODEL=RVL-001(JPN)\r\nDVD=0\r\nMPCH=0x7FFE\r\nCODE={0}\r\nSERNO={1}\r\nVIDEO=NTSC\r\nGAME=JP\r\n";
            string settingTemplateKor = "AREA=KOR\r\nMODEL=RVL-001(KOR)\r\nDVD=0\r\nMPCH=0x7FFE\r\nCODE={0}\r\nSERNO={1}\r\nVIDEO=NTSC\r\nGAME=KR\r\n";

            // Init array (i'm not sure it's usefull...)
            Array.Clear(settingTxt, 0, settingTxt.Length);


            // Parse serial number
            if (String.IsNullOrEmpty(serialNumber))
            {
                // Use default serial number : LU520123456
                code = "LU";
                serno = "520123456";

            }
            else
            {
                Regex myRegex = new Regex(@"(^[a-zA-Z]{2,3})(\d+$)");

                Match m = myRegex.Match(serialNumber);

                if (!m.Success)
                {
                    throw new Exception(serialNumber + " is not a valid Wii serial !");
                }
                else
                {
                    code = m.Groups[1].Value;
                    serno = m.Groups[2].Value;
                }
            }

            // Build decrypted content of setting.txt for a region, with the serial numer 
            string tmpSettingTxt;

            switch (region)
            {
                case "E":
                    tmpSettingTxt = String.Format(settingTemplateEur, code, serno);
                    break;
                case "J":
                    tmpSettingTxt = String.Format(settingTemplateJap, code, serno);
                    break;
                case "K":
                    tmpSettingTxt = String.Format(settingTemplateKor, code, serno);
                    break;
                case "U":
                    tmpSettingTxt = String.Format(settingTemplateUsa, code, serno);
                    break;
                default:
                    throw new Exception("Invalid region code : " + region);
            }

            // Parse string into byte[]
            Array.Copy(Wii.Tools.CharArrayToByteArray(tmpSettingTxt.ToCharArray()), settingTxt, tmpSettingTxt.Length);

            // Encrypt
            LolCrypt(settingTxt);

            // Write file
            FileStream fs = new FileStream(path + Path.DirectorySeparatorChar + "setting.txt", FileMode.Create, FileAccess.Write, FileShare.Read);

            fs.Write(settingTxt, 0, settingTxt.Length);

            if (fs != null)
                fs.Close();
        }
    }

/* Original code
*
*#include <stdio.h>
*#include <stdlib.h>
*#include <string.h>
*
*typedef unsigned char u8;
*typedef unsigned short u16;
*typedef unsigned int u32;
*typedef unsigned long long u64;
*
*u32 lolcrypt(u8 *stuff)
*{
*    u32 key = 0x73b5dbfa;
*    while(*stuff)
*    {
*        *stuff ^= (key & 0xff);
*        stuff++;
*        key = ((key<<1) | (key>>31));
*    }
*    return key;
*}
*
*int main(int argc, char **argv)
*{
*    printf("Wii setting.txt creator\n\n");
*
*    char settingTxt[0x100] __attribute__((aligned(32)));
*    memset(settingTxt, 0, 0x100);
*
*    char code[4];
*    u32 serno;
*
*    if(argc < 2)
*    {
*        printf("I need a serial number");
*        return 1;
*    }
*    else
*    {
*        if(strlen(argv[1]) == 9)
*        {
*            serno = atoi(argv[1]);
*        }
*        else if(strlen(argv[1]) == 11)
*        {
*            char number[9];
*            strncpy(code, &argv[1][0], 2);
*            code[2] = '\0';
*            strncpy(number, &argv[1][2],9);
*            serno = atoi(number);
*        }
*        else if(strlen(argv[1]) == 12)
*        {
*            char number[9];
*            strncpy(code, &argv[1][0], 3);
*            code[3] = '\0';
*            strncpy(number, &argv[1][3], 9);
*            serno = atoi(number);
*        }
*        else
*        {
*            printf("%s is not a valid wii serial", argv[1]);
*            return 1;
*        }
*    }
*
*    sprintf(settingTxt, "AREA=USA\r\nMODEL=RVL-001(USA)\r\nDVD=0\r\nMPCH=0x7FFE\r\nCODE=LU\r\nSERNO=%d\r\nVIDEO=NTSC\r\nGAME=US\r\n", serno);
*    printf("%s \n", settingTxt);
*    lolcrypt((u8 *)settingTxt);
*    printf("%s\n\n", settingTxt);
*    FILE * pFile;
*    pFile = fopen ( "USAsetting.txt" , "wb" );
*    fwrite (settingTxt , 1 , sizeof(settingTxt) , pFile );
*    fclose (pFile);
*
*    if(code[1] == 'E')
*    {
*        sprintf(settingTxt, "AREA=EUR\r\nMODEL=RVL-001(EUR)\r\nDVD=0\r\nMPCH=0x7FFE\r\nCODE=%s\r\nSERNO=%d\r\nVIDEO=PAL\r\nGAME=EU\r\n", code, serno);
*    }
*   else sprintf(settingTxt, "AREA=EUR\r\nMODEL=RVL-001(EUR)\r\nDVD=0\r\nMPCH=0x7FFE\r\nCODE=LEH\r\nSERNO=%d\r\nVIDEO=PAL\r\nGAME=EU\r\n", serno);
*    printf("%s \n", settingTxt);
*    lolcrypt((u8 *)settingTxt);
*    printf("%s\n\n", settingTxt);
*    pFile = fopen ( "EURsetting.txt" , "wb" );
*    fwrite (settingTxt , 1 , sizeof(settingTxt) , pFile );
*    fclose (pFile);
*
*    if(code[1] == 'J')
*    {
*        sprintf(settingTxt, "AREA=JPN\r\nMODEL=RVL-001(JPN)\r\nDVD=0\r\nMPCH=0x7FFE\r\nCODE=%s\r\nSERNO=%d\r\nVIDEO=NTSC\r\nGAME=JP\r\n", code, serno);
*    }
*    else sprintf(settingTxt, "AREA=JPN\r\nMODEL=RVL-001(JPN)\r\nDVD=0\r\nMPCH=0x7FFE\r\nCODE=LJF\r\nSERNO=%d\r\nVIDEO=NTSC\r\nGAME=JP\r\n", serno);
*    printf("%s \n", settingTxt);
*    lolcrypt((u8 *)settingTxt);
*    printf("%s\n\n", settingTxt);
*    pFile = fopen ( "JPNsetting.txt" , "wb" );
*    fwrite (settingTxt , 1 , sizeof(settingTxt) , pFile );
*    fclose (pFile);
*
*    if(code[1] == 'K')
*    {
*        sprintf(settingTxt, "AREA=KOR\r\nMODEL=RVL-001(KOR)\r\nDVD=0\r\nMPCH=0x7FFE\r\nCODE=%s\r\nSERNO=%d\r\nVIDEO=NTSC\r\nGAME=KR\r\n", code, serno);
*    }
*    else sprintf(settingTxt, "AREA=KOR\r\nMODEL=RVL-001(KOR)\r\nDVD=0\r\nMPCH=0x7FFE\r\nCODE=LKM\r\nSERNO=%d\r\nVIDEO=NTSC\r\nGAME=KR\r\n", serno);
*    printf("%s \n", settingTxt);
*    lolcrypt((u8 *)settingTxt);
*    printf("%s\n\n", settingTxt);
*    pFile = fopen ( "KORsetting.txt" , "wb" );
*    fwrite (settingTxt , 1 , sizeof(settingTxt) , pFile );
*    fclose (pFile);
*
*    return 0;
}*/
}
