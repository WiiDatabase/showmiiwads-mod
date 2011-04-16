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

//BNS conversion is based on bns.py (by megazig) of the Wii.py framework with improvements by me (Leathl)
//Thanks to Xuzz, SquidMan, megazig, Matt_P, Omega and The Lemon Man, the authors of Wii.py!

using System;
using System.Collections.Generic;
using System.IO;

namespace libWiiSharp
{
    public class BNS : IDisposable
    {
        private BNS_Header bnsHeader = new BNS_Header();
        private BNS_Info bnsInfo = new BNS_Info();
        private BNS_Data bnsData = new BNS_Data();
        private int[,] lSamples = new int[2, 2];
        private int[,] rlSamples = new int[2, 2];
        private int[] tlSamples = new int[2];
        private int[] hbcDefTbl = new int[] { 674, 1040, 3598, -1738, 2270, -583, 3967, -1969, 1516, 381, 3453, -1468, 2606, -617, 3795, -1759 };
        private int[] defTbl = new int[] { 1820, -856, 3238, -1514, 2333, -550, 3336, -1376, 2444, -949, 3666, -1764, 2654, -701, 3420, -1398 };
        private int[] pHist1 = new int[2];
        private int[] pHist2 = new int[2];
        private int tempSampleCount;
        private byte[] waveFile;
        private bool loopFromWave = false;
        private bool converted = false;
        private bool toMono = false;

        /// <summary>
        /// 0x00 (0) = No Loop, 0x01 (1) = Loop
        /// </summary>
        public bool HasLoop { get { return (this.bnsInfo.HasLoop == 0x01) ? true : false; } set { this.bnsInfo.HasLoop = (value) ? (byte)0x01 : (byte)0x00; } }
        /// <summary>
        /// The start sample of the Loop
        /// </summary>
        public uint LoopStart { get { return this.bnsInfo.LoopStart; } set { this.bnsInfo.LoopStart = value; } }
        /// <summary>
        /// The total number of samples in this file
        /// </summary>
        public uint TotalSampleCount { get { return this.bnsInfo.LoopEnd; } set { this.bnsInfo.LoopEnd = value; } }
        /// <summary>
        /// If true and the input Wave file is stereo, the BNS will be converted to Mono.
        /// Be sure to set this before you call Convert()!
        /// </summary>
        public bool StereoToMono { get { return toMono; } set { toMono = value; } }

        protected BNS() { }

        public BNS(string waveFile)
        {
            this.waveFile = File.ReadAllBytes(waveFile);
        }

        public BNS(string waveFile, bool loopFromWave)
        {
            this.waveFile = File.ReadAllBytes(waveFile);
            this.loopFromWave = loopFromWave;
        }

        public BNS(byte[] waveFile)
        {
            this.waveFile = waveFile;
        }

        public BNS(byte[] waveFile, bool loopFromWave)
        {
            this.waveFile = waveFile;
            this.loopFromWave = loopFromWave;
        }

        #region IDisposable Members
        private bool isDisposed = false;

        ~BNS()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !isDisposed)
            {
                bnsHeader = null;
                bnsInfo = null;
                bnsData = null;
                lSamples = null;
                rlSamples = null;
                tlSamples = null;
                hbcDefTbl = null;
                pHist1 = null;
                pHist2 = null;
                waveFile = null;
            }
            
            isDisposed = true;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Returns the length of the BNS audio file in seconds
        /// </summary>
        /// <param name="bnsFile"></param>
        /// <returns></returns>
        public static int GetBnsLength(byte[] bnsFile)
        {
            uint sampleRate = Shared.Swap(BitConverter.ToUInt16(bnsFile, 44));
            uint sampleCount = Shared.Swap(BitConverter.ToUInt32(bnsFile, 52));

            return (int)(sampleCount / sampleRate);
        }

        /// <summary>
        /// Returns the progress of the conversion
        /// </summary>
        public event EventHandler<System.ComponentModel.ProgressChangedEventArgs> Progress;

        /// <summary>
        /// Converts the Wave file to BNS
        /// </summary>
        public void Convert()
        {
            convert(waveFile, loopFromWave);
        }

        /// <summary>
        /// Returns the BNS file as a Byte Array. If not already converted, it will be done first.
        /// </summary>
        /// <returns></returns>
        public byte[] ToByteArray()
        {
            return ToMemoryStream().ToArray();
        }

        /// <summary>
        /// Returns the BNS file as a Memory Stream. If not already converted, it will be done first.
        /// </summary>
        /// <returns></returns>
        public MemoryStream ToMemoryStream()
        {
            if (!converted)
                convert(waveFile, loopFromWave);

            MemoryStream ms = new MemoryStream();

            try
            {
                this.bnsHeader.Write(ms);
                this.bnsInfo.Write(ms);
                this.bnsData.Write(ms);
            }
            catch { ms.Dispose(); throw; }

            return ms;
        }

        /// <summary>
        /// Saves the BNS file to the given path. If not already converted, it will be done first.
        /// </summary>
        /// <param name="destionationFile"></param>
        public void Save(string destionationFile)
        {
            if (File.Exists(destionationFile)) File.Delete(destionationFile);

            using (FileStream fs = new FileStream(destionationFile, FileMode.Create))
            {
                byte[] bnsFile = ToMemoryStream().ToArray();
                fs.Write(bnsFile, 0, bnsFile.Length);
            }
        }

        /// <summary>
        /// Sets the Loop to the given Start Sample. Be sure that you call Convert() first!
        /// </summary>
        /// <param name="loopStartSample"></param>
        public void SetLoop(int loopStartSample)
        {
            this.bnsInfo.HasLoop = 0x01;
            this.bnsInfo.LoopStart = (uint)loopStartSample;
        }
        #endregion

        #region Private Functions
        private void convert(byte[] waveFile, bool loopFromWave)
        {
            Wave wave = new Wave(waveFile);
            int waveLoopCount = wave.NumLoops;
            int waveLoopStart = wave.LoopStart;

            this.bnsInfo.ChannelCount = (byte)wave.NumChannels;
            this.bnsInfo.SampleRate = (ushort)wave.SampleRate;

            if (this.bnsInfo.ChannelCount > 2 || this.bnsInfo.ChannelCount < 1)
                throw new Exception("Unsupported Amount of Channels!");
            if (wave.BitDepth != 16)
                throw new Exception("Only 16bit Wave files are supported!");
            if (wave.DataFormat != 1)
                throw new Exception("The format of this Wave file is not supported!");

            this.bnsData.Data = Encode(wave.SampleData);

            if (this.bnsInfo.ChannelCount == 1)
            {
                this.bnsHeader.InfoLength = 0x60;
                this.bnsHeader.DataOffset = 0x80;

                this.bnsInfo.Size = 0x60;
                this.bnsInfo.Channel1StartOffset = 0x0000001C;
                this.bnsInfo.Channel2StartOffset = 0x00000000;
                this.bnsInfo.Channel1Start = 0x00000028;
                this.bnsInfo.Coefficients1Offset = 0x00000000;
            }

            this.bnsData.Size = (uint)bnsData.Data.Length + 8;

            this.bnsHeader.DataLength = this.bnsData.Size;
            this.bnsHeader.FileSize = this.bnsHeader.Size + this.bnsInfo.Size + this.bnsData.Size;

            if (loopFromWave)
                if (waveLoopCount == 1)
                    if (waveLoopStart != -1)
                    { this.bnsInfo.LoopStart = (uint)waveLoopStart; this.bnsInfo.HasLoop = 0x01; }

            this.bnsInfo.LoopEnd = (uint)tempSampleCount;                   

            for (int i = 0; i < 16; i++)
            {
                this.bnsInfo.Coefficients1[i] = this.defTbl[i];

                if (this.bnsInfo.ChannelCount == 2)
                    this.bnsInfo.Coefficients2[i] = this.defTbl[i];
            }

            this.converted = true;
        }

        private byte[] Encode(byte[] inputFrames)
        {
            int offset = 0;
            int[] sampleBuffer = new int[14];

            this.tempSampleCount = inputFrames.Length / (bnsInfo.ChannelCount == 2 ? 4 : 2);
            int modLength = (inputFrames.Length / (bnsInfo.ChannelCount == 2 ? 4 : 2)) % 14;

            Array.Resize(ref inputFrames, inputFrames.Length + ((14 - modLength) * (bnsInfo.ChannelCount == 2 ? 4 : 2)));

            int sampleCount = inputFrames.Length / (bnsInfo.ChannelCount == 2 ? 4 : 2);

            int blocks = (sampleCount + 13) / 14;

            List<int> soundDataLeft = new List<int>();
            List<int> soundDataRight = new List<int>();

            int co = offset;

            if (this.toMono && this.bnsInfo.ChannelCount == 2) this.bnsInfo.ChannelCount = 1;
            else if (this.toMono) this.toMono = false;

            for (int j = 0; j < sampleCount; j++)
            {
                soundDataLeft.Add(BitConverter.ToInt16(inputFrames, co));
                co += 2;

                if (this.bnsInfo.ChannelCount == 2 || toMono)
                {
                    soundDataRight.Add(BitConverter.ToInt16(inputFrames, co));
                    co += 2;
                }
            }

            byte[] data = new byte[(this.bnsInfo.ChannelCount == 2 ? (blocks * 16) : (blocks * 8))];

            int data1Offset = 0;
            int data2Offset = blocks * 8;

            this.bnsInfo.Channel2Start = (this.bnsInfo.ChannelCount == 2 ? (uint)data2Offset : 0);

            int[] leftSoundData = soundDataLeft.ToArray();
            int[] rightSoundData = soundDataRight.ToArray();

            for (int y = 0; y < blocks; y++)
            {
                try
                {
                    if (y % (int)(blocks / 100) == 0 || (y + 1) == blocks)
                        ChangeProgress((y + 1) * 100 / blocks);
                }
                catch { }

                for (int a = 0; a < 14; a++)
                    sampleBuffer[a] = leftSoundData[y * 14 + a];

                byte[] outBuffer = RepackAdpcm(0, this.defTbl, sampleBuffer);

                for (int a = 0; a < 8; a++)
                    data[data1Offset + a] = outBuffer[a];

                data1Offset += 8;

                if (this.bnsInfo.ChannelCount == 2)
                {
                    for (int a = 0; a < 14; a++)
                        sampleBuffer[a] = rightSoundData[y * 14 + a];

                    outBuffer = RepackAdpcm(1, this.defTbl, sampleBuffer);

                    for (int a = 0; a < 8; a++)
                        data[data2Offset + a] = outBuffer[a];
                    
                    data2Offset += 8;
                }
            }

            this.bnsInfo.LoopEnd = (uint)(blocks * 7);

            return data;
        }

        private byte[] RepackAdpcm(int index, int[] table, int[] inputBuffer)
        {
            byte[] data = new byte[8];
            int[] blSamples = new int[2];
            int bestIndex = -1;
            double bestError = 999999999.0;
            double error;

            for (int tableIndex = 0; tableIndex < 8; tableIndex++)
            {
                byte[] testData = CompressAdpcm(index, table, tableIndex, inputBuffer, out error);

                if (error < bestError)
                {
                    bestError = error;

                    for (int i = 0; i < 8; i++)
                        data[i] = testData[i];
                    for (int i = 0; i < 2; i++)
                        blSamples[i] = this.tlSamples[i];

                    bestIndex = tableIndex;
                }
            }

            for (int i = 0; i < 2; i++)
                this.rlSamples[index, i] = blSamples[i];

            return data;
        }

        private byte[] CompressAdpcm(int index, int[] table, int tableIndex, int[] inputBuffer, out double outError)
        {
            byte[] data = new byte[8];
            int error = 0;
            int factor1 = table[2 * tableIndex + 0];
            int factor2 = table[2 * tableIndex + 1];

            int exponent = DetermineStdExponent(index, table, tableIndex, inputBuffer);

            while (exponent <= 15)
            {
                bool breakIt = false;
                error = 0;
                data[0] = (byte)(exponent | (tableIndex << 4));

                for (int i = 0; i < 2; i++)
                    this.tlSamples[i] = this.rlSamples[index, i];

                int j = 0;

                for (int i = 0; i < 14; i++)
                {
                    int predictor = (int)((this.tlSamples[1] * factor1 + this.tlSamples[0] * factor2) >> 11);
                    int residual = (inputBuffer[i] - predictor) >> exponent;

                    if (residual > 7 || residual < -8)
                    {
                        exponent++;
                        breakIt = true;
                        break;
                    }

                    int nibble = Clamp(residual, -8, 7);

                    if ((i & 1) != 0)
                        data[i / 2 + 1] = (byte)(data[i / 2 + 1] | (nibble & 0xf));
                    else
                        data[i / 2 + 1] = (byte)(nibble << 4);

                    predictor += nibble << exponent;

                    this.tlSamples[0] = this.tlSamples[1];
                    this.tlSamples[1] = Clamp(predictor, -32768, 32767);

                    error += (int)(Math.Pow((double)(this.tlSamples[1] - inputBuffer[i]), 2));
                }

                if (!breakIt) j = 14;

                if (j == 14) break;
            }

            outError = error;
            return data;
        }

        private int DetermineStdExponent(int index, int[] table, int tableIndex, int[] inputBuffer)
        {
            int[] elSamples = new int[2];
            int maxResidual = 0;
            int factor1 = table[2 * tableIndex + 0];
            int factor2 = table[2 * tableIndex + 1];

            for (int i = 0; i < 2; i++)
                elSamples[i] = this.rlSamples[index, i];

            for (int i = 0; i < 14; i++)
            {
                int predictor = (elSamples[1] * factor1 + elSamples[0] * factor2) >> 11;
                int residual = inputBuffer[i] - predictor;

                if (residual > maxResidual)
                    maxResidual = residual;

                elSamples[0] = elSamples[1];
                elSamples[1] = inputBuffer[i];
            }

            return FindExponent(maxResidual);
        }

        private int FindExponent(double residual)
        {
            int exponent = 0;

            while (residual > 7.5 || residual < -8.5)
            {
                exponent++;
                residual /= 2.0;
            }

            return exponent;
        }

        private int Clamp(int input, int min, int max)
        {
            if (input < min) return min;
            if (input > max) return max;
            return input;
        }

        private void ChangeProgress(int progressPercentage)
        {
            EventHandler<System.ComponentModel.ProgressChangedEventArgs> progress = Progress;
            if (progress != null)
            {
                progress(new object(), new System.ComponentModel.ProgressChangedEventArgs(progressPercentage, new object()));
            }
        }
        #endregion

        #region BNS to Wave
        #region Public Functions
        /// <summary>
        /// Converts a BNS audio file to Wave format.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        /// <returns></returns>
        public static Wave BnsToWave(Stream inputFile)
        {
            BNS b = new BNS();
            byte[] samples = b.Read(inputFile);

            Wave wave = new Wave(b.bnsInfo.ChannelCount, 16, b.bnsInfo.SampleRate, samples);
            if (b.bnsInfo.HasLoop == 1) wave.AddLoop((int)b.bnsInfo.LoopStart);
            return wave;
        }

        public static Wave BnsToWave(string pathToFile)
        {
            BNS b = new BNS();
            byte[] samples;

            using (FileStream fs = new FileStream(pathToFile, FileMode.Open))
                samples = b.Read(fs);

            Wave wave = new Wave(b.bnsInfo.ChannelCount, 16, b.bnsInfo.SampleRate, samples);
            if (b.bnsInfo.HasLoop == 1) wave.AddLoop((int)b.bnsInfo.LoopStart);
            return wave;
        }

        public static Wave BnsToWave(byte[] bnsFile)
        {
            BNS b = new BNS();
            byte[] samples;

            using (MemoryStream ms = new MemoryStream(bnsFile))
                samples = b.Read(ms);

            Wave wave = new Wave(b.bnsInfo.ChannelCount, 16, b.bnsInfo.SampleRate, samples);
            if (b.bnsInfo.HasLoop == 1) wave.AddLoop((int)b.bnsInfo.LoopStart);
            return wave;
        }
        #endregion

        #region Private Functions
        private byte[] Read(Stream input)
        {
            input.Seek(0, SeekOrigin.Begin);

            this.bnsHeader.Read(input);
            this.bnsInfo.Read(input);
            this.bnsData.Read(input);

            return Decode();
        }

        private byte[] Decode()
        {
            List<byte> decBuffer = new List<byte>();
            int blocks = (int)this.bnsData.Data.Length / (this.bnsInfo.ChannelCount == 2 ? 16 : 8);

            int data1Off = 0;
            int data2Off = blocks * 8;

            byte[] leftBuffer = new byte[0], rightBuffer = new byte[0];

            for (int i = 0; i < blocks; i++)
            {
                if (data1Off == 302752) { }

                leftBuffer = DecodeAdpcm(0, data1Off);
                if (this.bnsInfo.ChannelCount == 2) rightBuffer = DecodeAdpcm(1, data2Off);

                for (int j = 0; j < 14; j++)
                {
                    decBuffer.Add(leftBuffer[j * 2]);
                    decBuffer.Add(leftBuffer[j * 2 + 1]);
                    if (this.bnsInfo.ChannelCount == 2)
                    {
                        decBuffer.Add(rightBuffer[j * 2]);
                        decBuffer.Add(rightBuffer[j * 2 + 1]);
                    }
                }

                data1Off += 8;
                if (this.bnsInfo.ChannelCount == 2) data2Off += 8;
            }

            return decBuffer.ToArray();
        }

        private byte[] DecodeAdpcm(int channel, int dataOffset)
        {
            byte[] decBuffer = new byte[14 * 2];

            int coefficientIndex = ((this.bnsData.Data[dataOffset] >> 4) & 0xf);
            int scale = 1 << (this.bnsData.Data[dataOffset] & 0xf);

            int hist1 = this.pHist1[channel];
            int hist2 = this.pHist2[channel];

            int coefficient1 = (channel == 0) ? this.bnsInfo.Coefficients1[coefficientIndex * 2] : this.bnsInfo.Coefficients2[coefficientIndex * 2];
            int coefficient2 = (channel == 0) ? this.bnsInfo.Coefficients1[coefficientIndex * 2 + 1] : this.bnsInfo.Coefficients2[coefficientIndex * 2 + 1];
            int nibble;

            for (int i = 0; i < 14; i++)
            {
                short sampleByte = this.bnsData.Data[dataOffset + (i / 2 + 1)];

                if ((i & 1) == 0) nibble = sampleByte >> 4;
                else nibble = sampleByte & 0xf;

                if (nibble >= 8) nibble -= 16;

                int sample11 = ((scale * nibble) << 11) + (coefficient1 * hist1 + coefficient2 * hist2);
                int sampleRaw = Clamp((sample11 + 1024) >> 11, -32768, 32767);

                decBuffer[i * 2] = (byte)(((short)sampleRaw) & 0xff);
                decBuffer[i * 2 + 1] = (byte)(((short)sampleRaw) >> 8);

                hist2 = hist1;
                hist1 = sampleRaw;
            }

            this.pHist1[channel] = hist1;
            this.pHist2[channel] = hist2;

            return decBuffer;
        }
        #endregion
        #endregion
    }

    internal class BNS_Data
    {
        //Private Varialbes
        private byte[] magic = new byte[] { (byte)'D', (byte)'A', (byte)'T', (byte)'A' };
        private uint size = 0x0004d000;
        private byte[] data;

        //Public Variables
        public uint Size { get { return size; } set { size = value; } }
        public byte[] Data { get { return data; } set { data = value; } }

        public BNS_Data() { }

        public void Write(Stream outStream)
        {
            byte[] temp = BitConverter.GetBytes(Shared.Swap(size));

            outStream.Write(magic, 0, magic.Length);
            outStream.Write(temp, 0, temp.Length);
            outStream.Write(data, 0, data.Length);
        }

        public void Read(Stream input)
        {
            BinaryReader reader = new BinaryReader(input);

            if (!Shared.CompareByteArrays(magic, reader.ReadBytes(4)))
                throw new Exception("This is not a valid BNS audfo file!");

            size = Shared.Swap(reader.ReadUInt32());
            data = reader.ReadBytes((int)size - 8);
        }
    }

    internal class BNS_Info
    {
        //Private Variables
        private byte[] magic = new byte[] { (byte)'I', (byte)'N', (byte)'F', (byte)'O' };
        private uint size = 0x000000a0;
        private byte codec = 0x00;
        private byte hasLoop = 0x00;
        private byte channelCount = 0x02;
        private byte zero = 0x00;
        private ushort sampleRate = 0xac44;
        private ushort pad0 = 0x0000;
        private uint loopStart = 0x00000000;
        private uint loopEnd = 0x00000000; //Or total sample count
        private uint offsetToChannelStart = 0x00000018;
        private uint pad1 = 0x00000000;
        private uint channel1StartOffset = 0x00000020;
        private uint channel2StartOffset = 0x0000002C;
        private uint channel1Start = 0x00000000;
        private uint coefficients1Offset = 0x0000038;
        private uint pad2 = 0x00000000;
        private uint channel2Start = 0x00000000;
        private uint coefficients2Offset = 0x00000068;
        private uint pad3 = 0x00000000;
        private int[] coefficients1 = new int[16];
        private ushort channel1Gain = 0x0000;
        private ushort channel1PredictiveScale = 0x0000;
        private ushort channel1PreviousValue = 0x0000;
        private ushort channel1NextPreviousValue = 0x0000;
        private ushort channel1LoopPredictiveScale = 0x0000;
        private ushort channel1LoopPreviousValue = 0x0000;
        private ushort channel1LoopNextPreviousValue = 0x0000;
        private ushort channel1LoopPadding = 0x0000;
        private int[] coefficients2 = new int[16];
        private ushort channel2Gain = 0x0000;
        private ushort channel2PredictiveScale = 0x0000;
        private ushort channel2PreviousValue = 0x0000;
        private ushort channel2NextPreviousValue = 0x0000;
        private ushort channel2LoopPredictiveScale = 0x0000;
        private ushort channel2LoopPreviousValue = 0x0000;
        private ushort channel2LoopNextPreviousValue = 0x0000;
        private ushort channel2LoopPadding = 0x0000;

        //Public Variables
        public byte HasLoop { get { return hasLoop; } set { hasLoop = value; } }
        public uint Coefficients1Offset { get { return coefficients1Offset; } set { coefficients1Offset = value; } }
        public uint Channel1StartOffset { get { return channel1StartOffset; } set { channel1StartOffset = value; } }
        public uint Channel2StartOffset { get { return channel2StartOffset; } set { channel2StartOffset = value; } }
        public uint Size { get { return size; } set { size = value; } }
        public ushort SampleRate { get { return sampleRate; } set { sampleRate = value; } }
        public byte ChannelCount { get { return channelCount; } set { channelCount = value; } }
        public uint Channel1Start { get { return channel1Start; } set { channel1Start = value; } }
        public uint Channel2Start { get { return channel2Start; } set { channel2Start = value; } }
        public uint LoopStart { get { return loopStart; } set { loopStart = value; } }
        public uint LoopEnd { get { return loopEnd; } set { loopEnd = value; } }
        public int[] Coefficients1 { get { return coefficients1; } set { coefficients1 = value; } }
        public int[] Coefficients2 { get { return coefficients2; } set { coefficients2 = value; } }

        public BNS_Info() { }

        public void Write(Stream outStream)
        {
            outStream.Write(magic, 0, magic.Length);

            byte[] temp = BitConverter.GetBytes(size); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            outStream.WriteByte(codec);
            outStream.WriteByte(hasLoop);
            outStream.WriteByte(channelCount);
            outStream.WriteByte(zero);

            temp = BitConverter.GetBytes(sampleRate); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            temp = BitConverter.GetBytes(pad0); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            temp = BitConverter.GetBytes(loopStart); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            temp = BitConverter.GetBytes(loopEnd); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            temp = BitConverter.GetBytes(offsetToChannelStart); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            temp = BitConverter.GetBytes(pad1); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            temp = BitConverter.GetBytes(channel1StartOffset); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            temp = BitConverter.GetBytes(channel2StartOffset); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            temp = BitConverter.GetBytes(channel1Start); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            temp = BitConverter.GetBytes(coefficients1Offset); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            if (this.channelCount == 2)
            {
                temp = BitConverter.GetBytes(pad2); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel2Start); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(coefficients2Offset); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(pad3); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                foreach (int thisInt in coefficients1)
                {
                    temp = BitConverter.GetBytes(thisInt); Array.Reverse(temp);
                    outStream.Write(temp, 2, temp.Length - 2);
                }

                temp = BitConverter.GetBytes(channel1Gain); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel1PredictiveScale); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel1PreviousValue); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel1NextPreviousValue); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel1LoopPredictiveScale); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel1LoopPreviousValue); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel1LoopNextPreviousValue); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel1LoopPadding); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                foreach (int thisInt in coefficients2)
                {
                    temp = BitConverter.GetBytes(thisInt); Array.Reverse(temp);
                    outStream.Write(temp, 2, temp.Length - 2);
                }

                temp = BitConverter.GetBytes(channel2Gain); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel2PredictiveScale); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel2PreviousValue); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel2NextPreviousValue); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel2LoopPredictiveScale); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel2LoopPreviousValue); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel2LoopNextPreviousValue); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel2LoopPadding); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);
            }
            else if (this.channelCount == 1)
            {
                foreach (int thisInt in coefficients1)
                {
                    temp = BitConverter.GetBytes(thisInt); Array.Reverse(temp);
                    outStream.Write(temp, 2, temp.Length - 2);
                }

                temp = BitConverter.GetBytes(channel1Gain); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel1PredictiveScale); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel1PreviousValue); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel1NextPreviousValue); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel1LoopPredictiveScale); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel1LoopPreviousValue); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel1LoopNextPreviousValue); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);

                temp = BitConverter.GetBytes(channel1LoopPadding); Array.Reverse(temp);
                outStream.Write(temp, 0, temp.Length);
            }
        }

        public void Read(Stream input)
        {
            BinaryReader reader = new BinaryReader(input);

            if (!Shared.CompareByteArrays(magic, reader.ReadBytes(4)))
                throw new Exception("This is not a valid BNS audfo file!");

            size = Shared.Swap(reader.ReadUInt32());
            codec = reader.ReadByte();
            hasLoop = reader.ReadByte();
            channelCount = reader.ReadByte();
            zero = reader.ReadByte();
            sampleRate = Shared.Swap(reader.ReadUInt16());
            pad0 = Shared.Swap(reader.ReadUInt16());
            loopStart = Shared.Swap(reader.ReadUInt32());
            loopEnd = Shared.Swap(reader.ReadUInt32());
            offsetToChannelStart = Shared.Swap(reader.ReadUInt32());
            pad1 = Shared.Swap(reader.ReadUInt32());
            channel1StartOffset = Shared.Swap(reader.ReadUInt32());
            channel2StartOffset = Shared.Swap(reader.ReadUInt32());
            channel1Start = Shared.Swap(reader.ReadUInt32());
            coefficients1Offset = Shared.Swap(reader.ReadUInt32());

            if (channelCount == 2)
            {
                pad2 = Shared.Swap(reader.ReadUInt32());
                channel2Start = Shared.Swap(reader.ReadUInt32());
                coefficients2Offset = Shared.Swap(reader.ReadUInt32());
                pad3 = Shared.Swap(reader.ReadUInt32());

                for (int i = 0; i < 16; i++)
                    coefficients1[i] = (short)Shared.Swap(reader.ReadUInt16());

                channel1Gain = Shared.Swap(reader.ReadUInt16());
                channel1PredictiveScale = Shared.Swap(reader.ReadUInt16());
                channel1PreviousValue = Shared.Swap(reader.ReadUInt16());
                channel1NextPreviousValue = Shared.Swap(reader.ReadUInt16());
                channel1LoopPredictiveScale = Shared.Swap(reader.ReadUInt16());
                channel1LoopPreviousValue = Shared.Swap(reader.ReadUInt16());
                channel1LoopNextPreviousValue = Shared.Swap(reader.ReadUInt16());
                channel1LoopPadding = Shared.Swap(reader.ReadUInt16());

                for (int i=0;i<16;i++)
                    coefficients2[i] = (short)Shared.Swap(reader.ReadUInt16());

                channel2Gain = Shared.Swap(reader.ReadUInt16());
                channel2PredictiveScale = Shared.Swap(reader.ReadUInt16());
                channel2PreviousValue = Shared.Swap(reader.ReadUInt16());
                channel2NextPreviousValue = Shared.Swap(reader.ReadUInt16());
                channel2LoopPredictiveScale = Shared.Swap(reader.ReadUInt16());
                channel2LoopPreviousValue = Shared.Swap(reader.ReadUInt16());
                channel2LoopNextPreviousValue = Shared.Swap(reader.ReadUInt16());
                channel2LoopPadding = Shared.Swap(reader.ReadUInt16());
            }
            else if (channelCount == 1)
            {
                for (int i = 0; i < 16; i++)
                    coefficients1[i] = (short)Shared.Swap(reader.ReadUInt16());

                channel1Gain = Shared.Swap(reader.ReadUInt16());
                channel1PredictiveScale = Shared.Swap(reader.ReadUInt16());
                channel1PreviousValue = Shared.Swap(reader.ReadUInt16());
                channel1NextPreviousValue = Shared.Swap(reader.ReadUInt16());
                channel1LoopPredictiveScale = Shared.Swap(reader.ReadUInt16());
                channel1LoopPreviousValue = Shared.Swap(reader.ReadUInt16());
                channel1LoopNextPreviousValue = Shared.Swap(reader.ReadUInt16());
                channel1LoopPadding = Shared.Swap(reader.ReadUInt16());
            }
        }
    }

    internal class BNS_Header
    {
        //Private Variables
        private byte[] magic = new byte[] { (byte)'B', (byte)'N', (byte)'S', (byte)' ' };
        private uint flags = 0xfeff0100;
        private uint fileSize = 0x0004d0c0;
        private ushort size = 0x0020;
        private ushort chunkCount = 0x0002;
        private uint infoOffset = 0x00000020;
        private uint infoLength = 0x000000a0;
        private uint dataOffset = 0x000000c0;
        private uint dataLength = 0x0004d000;

        //Public Varialbes
        public uint DataOffset { get { return dataOffset; } set { dataOffset = value; } }
        public uint InfoLength { get { return infoLength; } set { infoLength = value; } }
        public ushort Size { get { return size; } set { size = value; } }
        public uint DataLength { get { return dataLength; } set { dataLength = value; } }
        public uint FileSize { get { return fileSize; } set { fileSize = value; } }

        public BNS_Header() { }

        public void Write(Stream outStream)
        {
            outStream.Write(magic, 0, magic.Length);

            byte[] temp = BitConverter.GetBytes(flags); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            temp = BitConverter.GetBytes(fileSize); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            temp = BitConverter.GetBytes(size); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            temp = BitConverter.GetBytes(chunkCount); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            temp = BitConverter.GetBytes(infoOffset); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            temp = BitConverter.GetBytes(infoLength); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            temp = BitConverter.GetBytes(dataOffset); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);

            temp = BitConverter.GetBytes(dataLength); Array.Reverse(temp);
            outStream.Write(temp, 0, temp.Length);
        }

        public void Read(Stream input)
        {
            BinaryReader reader = new BinaryReader(input);

            if (!Shared.CompareByteArrays(magic, reader.ReadBytes(4)))
            {
                reader.BaseStream.Seek(28, SeekOrigin.Current);
                if (!Shared.CompareByteArrays(magic, reader.ReadBytes(4)))
                    throw new Exception("This is not a valid BNS audfo file!");
            }

            flags = Shared.Swap(reader.ReadUInt32());
            fileSize = Shared.Swap(reader.ReadUInt32());
            size = Shared.Swap(reader.ReadUInt16());
            chunkCount = Shared.Swap(reader.ReadUInt16());
            infoOffset = Shared.Swap(reader.ReadUInt32());
            infoLength = Shared.Swap(reader.ReadUInt32());
            dataOffset = Shared.Swap(reader.ReadUInt32());
            dataLength = Shared.Swap(reader.ReadUInt32());
        }
    }
}
