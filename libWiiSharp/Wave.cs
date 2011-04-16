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
using System.IO;
using System.Collections.Generic;

namespace libWiiSharp
{
    /// <summary>
    /// A class for RIFF Wave files.
    /// </summary>
    public class Wave : IDisposable
    {
        private WaveHeader header = new WaveHeader();
        private WaveFmtChunk fmt = new WaveFmtChunk();
        private WaveDataChunk data = new WaveDataChunk();
        private WaveSmplChunk smpl = new WaveSmplChunk();

        private bool hasSmpl = false;

        /// <summary>
        /// The Samplerate of the Wave file
        /// </summary>
        public int SampleRate { get { return (int)fmt.SampleRate; } }
        /// <summary>
        /// The Bitdepth of the Wave file
        /// </summary>
        public int BitDepth { get { return (int)fmt.BitsPerSample; } }
        /// <summary>
        /// The number of channels of the Wave file
        /// </summary>
        public int NumChannels { get { return (int)fmt.NumChannels; } }
        /// <summary>
        /// The number of Loops in the Wave file
        /// </summary>
        public int NumLoops { get { if (!hasSmpl) return 0; return (int)smpl.NumLoops; } }
        /// <summary>
        /// The start sample of the first Loop (if exist)
        /// </summary>
        public int LoopStart { get { if (NumLoops == 0) return 0; return (int)smpl.Loops[0].LoopStart; } }
        /// <summary>
        /// The total number of Frames
        /// </summary>
        public int NumSamples { get { return (int)((data.DataSize / (fmt.BitsPerSample / 8)) /fmt.NumChannels); } }
        /// <summary>
        /// The format of the sample data.
        /// </summary>
        public int DataFormat { get { return (int)fmt.AudioFormat; } }
        /// <summary>
        /// The sampledata.
        /// </summary>
        public byte[] SampleData { get { return data.Data; } }
        /// <summary>
        /// The length of the wave file in seconds.
        /// </summary>
        public int PlayLength { get { return (int)(((data.DataSize / fmt.NumChannels) / (fmt.BitsPerSample / 8)) / fmt.SampleRate); } }

        public Wave(string pathToFile)
        {
            using (FileStream fs = new FileStream(pathToFile, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs))
                parseWave(reader);
        }

        public Wave(Stream wave)
        {
            BinaryReader reader = new BinaryReader(wave);
            parseWave(reader);
        }

        public Wave(byte[] waveFile)
        {
            using (MemoryStream ms = new MemoryStream(waveFile))
            using (BinaryReader reader = new BinaryReader(ms))
                parseWave(reader);
        }

        public Wave(int numChannels, int bitsPerSample, int sampleRate, byte[] samples)
        {
            fmt.SampleRate = (uint)sampleRate;
            fmt.NumChannels = (ushort)numChannels;
            fmt.BitsPerSample = (ushort)bitsPerSample;

            data.Data = samples;
        }

        #region IDisposable Members
        private bool isDisposed = false;

        ~Wave()
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
                header = null;
                fmt = null;
                data = null;
                smpl = null;
            }

            isDisposed = true;
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Writes the file to the given stream.
        /// </summary>
        /// <param name="writeStream"></param>
        public void Write(Stream writeStream)
        {
            BinaryWriter writer = new BinaryWriter(writeStream);
            writeToStream(writer);
        }

        /// <summary>
        /// Returns the file as a memory stream.
        /// </summary>
        /// <returns></returns>
        public MemoryStream ToMemoryStream()
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms);
            writeToStream(writer);
            return ms;
        }

        /// <summary>
        /// Returns the file as a byte array.
        /// </summary>
        /// <returns></returns>
        public byte[] ToByteArray()
        {
            return ToMemoryStream().ToArray();
        }

        /// <summary>
        /// Saves the file to the given path.
        /// </summary>
        /// <param name="savePath"></param>
        public void Save(string savePath)
        {
            using (FileStream fs = new FileStream(savePath, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
                writeToStream(writer);
        }

        /// <summary>
        /// Adds a loop to the file, existing loops will be deleted.
        /// </summary>
        /// <param name="loopStartSample"></param>
        public void AddLoop(int loopStartSample)
        {
            smpl.AddLoop(loopStartSample, NumSamples);
            hasSmpl = true;
        }

        /// <summary>
        /// Removes the loop from the file.
        /// </summary>
        public void RemoveLoop()
        {
            hasSmpl = false;
        }

        /// <summary>
        /// Trims the start of the wave file to the given sample.
        /// </summary>
        /// <param name="newStartSample"></param>
        public void TrimStart(int newStartSample)
        {
            int offset = fmt.NumChannels * (fmt.BitsPerSample / 8) * newStartSample;

            MemoryStream ms = new MemoryStream();
            ms.Write(data.Data, offset, data.Data.Length - offset);

            data.Data = ms.ToArray();
            ms.Dispose();
        }
        #endregion

        #region Private Functions
        private void writeToStream(BinaryWriter writer)
        {
            header.FileSize = 4 + fmt.FmtSize + 8 + data.DataSize + 8 + (hasSmpl ? smpl.SmplSize + 8 : 0);

            header.Write(writer);
            fmt.Write(writer);
            data.Write(writer);
            if (hasSmpl) smpl.Write(writer);
        }

        private void parseWave(BinaryReader reader)
        {
            bool[] hasChunk = new bool[] { false, false, false };

            while (reader.BaseStream.Position < reader.BaseStream.Length - 4)
            {
                uint curChunk = Shared.Swap(reader.ReadUInt32());
                uint curChunkLength = reader.ReadUInt32();
                long nextChunkPos = reader.BaseStream.Position + curChunkLength;

                switch (curChunk)
                {
                    case 0x52494646: //RIFF
                        try
                        {
                            reader.BaseStream.Seek(-8, SeekOrigin.Current);
                            header.Read(reader);
                            hasChunk[0] = true;
                        }
                        catch { reader.BaseStream.Seek(nextChunkPos, SeekOrigin.Begin); }
                        break;
                    case 0x666d7420: //fmt
                        try
                        {
                            reader.BaseStream.Seek(-8, SeekOrigin.Current);
                            fmt.Read(reader);
                            hasChunk[1] = true;
                        }
                        catch { reader.BaseStream.Seek(nextChunkPos, SeekOrigin.Begin); }
                        break;
                    case 0x64617461: //data
                        try
                        {
                            reader.BaseStream.Seek(-8, SeekOrigin.Current);
                            data.Read(reader);
                            hasChunk[2] = true;
                        }
                        catch { reader.BaseStream.Seek(nextChunkPos, SeekOrigin.Begin); }
                        break;
                    case 0x736d706c: //smpl
                        try
                        {
                            reader.BaseStream.Seek(-8, SeekOrigin.Current);
                            smpl.Read(reader);
                            hasSmpl = true;
                        }
                        catch { reader.BaseStream.Seek(nextChunkPos, SeekOrigin.Begin); }
                        break;
                    default:
                        reader.BaseStream.Seek(curChunkLength, SeekOrigin.Current);
                        break;
                }

                if (hasChunk[0] && hasChunk[1] && hasChunk[2] && hasSmpl) break;
            }

            if (!(hasChunk[0] && hasChunk[1] && hasChunk[2]))
                throw new Exception("Couldn't parse Wave file...");
        }
        #endregion
    }

    internal class WaveHeader
    {
        private uint headerId = 0x52494646;
        private uint fileSize = 12;
        private uint format = 0x57415645;

        public uint FileSize { get { return fileSize; } set { fileSize = value; } }

        public void Write(BinaryWriter writer)
        {
            writer.Write(Shared.Swap(headerId));
            writer.Write(fileSize);
            writer.Write(Shared.Swap(format));
        }

        public void Read(BinaryReader reader)
        {
            if (Shared.Swap(reader.ReadUInt32()) != headerId)
                throw new Exception("Not a valid RIFF Wave file!");

            fileSize = reader.ReadUInt32();

            if (Shared.Swap(reader.ReadUInt32()) != format)
                throw new Exception("Not a valid RIFF Wave file!");
        }
    }

    internal class WaveFmtChunk
    {
        private uint fmtId = 0x666d7420;
        private uint fmtSize = 16;
        private ushort audioFormat = 1;
        private ushort numChannels = 2;
        private uint sampleRate = 44100;
        private uint byteRate;
        private ushort blockAlign;
        private ushort bitsPerSample = 16;

        public uint FmtSize { get { return fmtSize; } }
        public ushort NumChannels { get { return numChannels; } set { numChannels = value; } }
        public uint SampleRate { get { return sampleRate; } set { sampleRate = value; } }
        public ushort BitsPerSample { get { return bitsPerSample; } set { bitsPerSample = value; } }
        public uint AudioFormat { get { return audioFormat; } }

        public void Write(BinaryWriter writer)
        {
            byteRate = sampleRate * numChannels * bitsPerSample / 8;
            blockAlign = (ushort)(numChannels * bitsPerSample / 8);

            writer.Write(Shared.Swap(fmtId));
            writer.Write(fmtSize);
            writer.Write(audioFormat);
            writer.Write(numChannels);
            writer.Write(sampleRate);
            writer.Write(byteRate);
            writer.Write(blockAlign);
            writer.Write(bitsPerSample);
        }

        public void Read(BinaryReader reader)
        {
            if (Shared.Swap(reader.ReadUInt32()) != fmtId)
                throw new Exception("Wrong chunk ID!");

            fmtSize = reader.ReadUInt32();
            audioFormat = reader.ReadUInt16();
            numChannels = reader.ReadUInt16();
            sampleRate = reader.ReadUInt32();
            byteRate = reader.ReadUInt32();
            blockAlign = reader.ReadUInt16();
            bitsPerSample = reader.ReadUInt16();
        }
    }

    internal class WaveDataChunk
    {
        private uint dataId = 0x64617461;
        private uint dataSize = 8;
        private byte[] data;

        public uint DataSize { get { return dataSize; } }
        public byte[] Data { get { return data; } set { data = value; dataSize = (uint)data.Length; } }

        public void Write(BinaryWriter writer)
        {
            writer.Write(Shared.Swap(dataId));
            writer.Write(dataSize);
            writer.Write(data, 0, data.Length);
        }

        public void Read(BinaryReader reader)
        {
            if (Shared.Swap(reader.ReadUInt32()) != dataId)
                throw new Exception("Wrong chunk ID!");

            dataSize = reader.ReadUInt32();
            data = reader.ReadBytes((int)dataSize);
        }
    }

    internal class WaveSmplChunk
    {
        private uint smplId = 0x736d706c;
        private uint smplSize = 36;
        private uint manufacturer = 0;
        private uint product = 0;
        private uint samplePeriod = 0;
        private uint unityNote = 0x3c;
        private uint pitchFraction = 0;
        private uint smpteFormat = 0;
        private uint smpteOffset = 0;
        private uint numLoops = 0;
        private uint samplerData = 0;
        private List<WaveSmplLoop> smplLoops = new List<WaveSmplLoop>();

        public uint SmplSize { get { return smplSize; } }
        public uint NumLoops { get { return numLoops; } }
        public WaveSmplLoop[] Loops { get { return smplLoops.ToArray(); } }

        public void AddLoop(int loopStartSample, int loopEndSample)
        {
            RemoveAllLoops();
            numLoops++;

            WaveSmplLoop tmpLoop = new WaveSmplLoop();
            tmpLoop.LoopStart = (uint)loopStartSample;
            tmpLoop.LoopEnd = (uint)loopEndSample;

            smplLoops.Add(tmpLoop);
        }

        public void RemoveAllLoops()
        {
            smplLoops.Clear();
            numLoops = 0;
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(Shared.Swap(smplId));
            writer.Write(smplSize);
            writer.Write(manufacturer);
            writer.Write(product);
            writer.Write(samplePeriod);
            writer.Write(unityNote);
            writer.Write(pitchFraction);
            writer.Write(smpteFormat);
            writer.Write(smpteOffset);
            writer.Write(numLoops);
            writer.Write(samplerData);

            for (int i = 0; i < numLoops; i++)
                smplLoops[i].Write(writer);
        }

        public void Read(BinaryReader reader)
        {
            if (Shared.Swap(reader.ReadUInt32()) != smplId)
                throw new Exception("Wrong chunk ID!");

            smplSize = reader.ReadUInt32();
            manufacturer = reader.ReadUInt32();
            product = reader.ReadUInt32();
            samplePeriod = reader.ReadUInt32();
            unityNote = reader.ReadUInt32();
            pitchFraction = reader.ReadUInt32();
            smpteFormat = reader.ReadUInt32();
            smpteOffset = reader.ReadUInt32();
            numLoops = reader.ReadUInt32();
            samplerData = reader.ReadUInt32();

            for (int i = 0; i < numLoops; i++)
            {
                WaveSmplLoop tempLoop = new WaveSmplLoop();
                tempLoop.Read(reader);

                smplLoops.Add(tempLoop);
            }
        }
    }

    internal class WaveSmplLoop
    {
        private uint cuePointId = 0;
        private uint type = 0;
        private uint start = 0;
        private uint end = 0;
        private uint fraction = 0;
        private uint playCount = 0;

        public uint LoopStart { get { return start; } set { start = value; } }
        public uint LoopEnd { get { return end; } set { end = value; } }

        public void Write(BinaryWriter writer)
        {
            writer.Write(cuePointId);
            writer.Write(type);
            writer.Write(start);
            writer.Write(end);
            writer.Write(fraction);
            writer.Write(playCount);
        }

        public void Read(BinaryReader reader)
        {
            cuePointId = reader.ReadUInt32();
            type = reader.ReadUInt32();
            start = reader.ReadUInt32();
            end = reader.ReadUInt32();
            fraction = reader.ReadUInt32();
            playCount = reader.ReadUInt32();
        }
    }
}
