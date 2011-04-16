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
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.ComponentModel;
using System.IO;

namespace libWiiSharp
{
    public enum Protocol
    {
        /// <summary>
        /// Will preconfigure all settings for HBC to 1.0.5 (HAXX).
        /// </summary>
        HAXX = 0,
        /// <summary>
        /// Will preconfigure all settings for HBC from 1.0.5 (JODI).
        /// </summary>
        JODI = 1,
        /// <summary>
        /// Remember to define your custom settings.
        /// </summary>
        Custom = 2,
    }

    /// <summary>
    /// The HbcTransmitter can easily transmit files to the Homebrew Channel.
    /// In order to use compression, you need zlib1.dll in the application directory.
    /// </summary>
    public class HbcTransmitter : IDisposable
    {
        private int blocksize = 4 * 1024;
        private int wiiloadMayor = 0;
        private int wiiloadMinor = 5;
        private bool compress = false;
        private string ipAddress;
        private int port = 4299;

        private string lastErrorMessage = string.Empty;

        private Protocol protocol;
        private TcpClient tcpClient;
        private NetworkStream nwStream;

        private string lastError = string.Empty;
        private int transmittedLength = 0;
        private int compressionRatio = 0;

        /// <summary>
        /// The size of the buffer that is used to transmit the data.
        /// Default is 4 * 1024. If you're facing problems (freezes while transmitting), try a higher size.
        /// </summary>
        public int Blocksize { get { return blocksize; } set { blocksize = value; } }
        /// <summary>
        /// The mayor version of wiiload. You might need to change it for upcoming releases of the HBC.
        /// </summary>
        public int WiiloadVersionMayor { get { return wiiloadMayor; } set { wiiloadMayor = value; } }
        /// <summary>
        /// The minor version of wiiload. You might need to change it for upcoming releases of the HBC.
        /// </summary>
        public int WiiloadVersionMinor { get { return wiiloadMinor; } set { wiiloadMinor = value; } }
        /// <summary>
        /// If true, the data will be compressed before being transmitted. NOT available for Protocol.HAXX!
        /// Also, compression will only work if zlib1.dll is in the application folder.
        /// </summary>
        public bool Compress { get { return compress; } set { if (protocol != Protocol.HAXX) compress = value; } }
        /// <summary>
        /// The IP address of the Wii.
        /// </summary>
        public string IpAddress { get { return ipAddress; } set { ipAddress = value; } }
        /// <summary>
        /// The port used for the transmission.
        /// You don't need to touch this unless the port changes in future releases of the HBC.
        /// </summary>
        public int Port { get { return port; } set { port = value; } }
        /// <summary>
        /// After a successfully completed transmission, this value holds the number of transmitted bytes.
        /// </summary>
        public int TransmittedLength { get { return transmittedLength; } }
        /// <summary>
        /// After a successfully completed transmission, this value holds the compression ratio.
        /// Will be 0 if the data wasn't compressed.
        /// </summary>
        public int CompressionRatio { get { return compressionRatio; } }
        /// <summary>
        /// Holds the last occured error message.
        /// </summary>
        public string LastError { get { return lastError; } }

        public HbcTransmitter(Protocol protocol, string ipAddress)
        {
            this.protocol = protocol;
            this.ipAddress = ipAddress;

            wiiloadMinor = (protocol == Protocol.HAXX) ? 4 : 5;
            compress = (protocol == Protocol.JODI) ? true : false;
        }

        #region IDisposable Members
        private bool isDisposed = false;

        ~HbcTransmitter()
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
                ipAddress = null;
                lastErrorMessage = null;
                lastError = null;

                if (nwStream != null) { nwStream.Close(); nwStream = null; }
                if (tcpClient != null) { tcpClient.Close(); tcpClient = null; }
            }

            isDisposed = true;
        }
        #endregion

        #region Public Functions
        public bool TransmitFile(string pathToFile)
        {
            return transmit(Path.GetFileName(pathToFile), File.ReadAllBytes(pathToFile));
        }

        public bool TransmitFile(string fileName, byte[] fileData)
        {
            return transmit(fileName, fileData);
        }
        #endregion

        #region Private Functions
        private bool transmit(string fileName, byte[] fileData)
        {
            fireDebug("Transmitting {0} to {1}:{2}...", fileName, ipAddress, port);

            if (!Environment.OSVersion.ToString().ToLower().Contains("windows")) compress = false;
            if (fileName.ToLower().EndsWith(".zip")) compress = false; //There won't be much to compress in Zips

            tcpClient = new TcpClient();
            
            byte[] compFileData;
            byte[] buffer = new byte[4];

            fireDebug("   Connecting...");
            try { tcpClient.Connect(ipAddress, 4299); }
            catch (Exception ex) { fireDebug("    -> Connection Failed:\n" + ex.Message); lastError = "Connection Failed:\n" + ex.Message; tcpClient.Close(); return false; }
            nwStream = tcpClient.GetStream();

            fireDebug("   Sending Magic...");
            buffer[0] = (byte)'H';
            buffer[1] = (byte)'A';
            buffer[2] = (byte)'X';
            buffer[3] = (byte)'X';
            try { nwStream.Write(buffer, 0, 4); }
            catch (Exception ex) { fireDebug("    -> Error sending Magic:\n" + ex.Message); lastError = "Error sending Magic:\n" + ex.Message; nwStream.Close(); tcpClient.Close(); return false; }

            fireDebug("   Sending Version Info...");
            buffer[0] = (byte)wiiloadMayor;
            buffer[1] = (byte)wiiloadMinor;
            buffer[2] = (byte)(((fileName.Length + 2) >> 8) & 0xff);
            buffer[3] = (byte)((fileName.Length + 2) & 0xff);

            try { nwStream.Write(buffer, 0, 4); }
            catch (Exception ex) { fireDebug("    -> Error sending Version Info:\n" + ex.Message); lastError = "Error sending Version Info:\n" + ex.Message; nwStream.Close(); tcpClient.Close(); return false; }

            if (compress)
            {
                fireDebug("   Compressing File...");
                try { compFileData = zlibWrapper.Compress(fileData); }
                catch
                {
                    //Compression failed, let's continue without compression
                    fireDebug("    -> Compression failed, continuing without compression...");
                    compress = false;
                    compFileData = fileData;
                    fileData = new byte[0];
                }
            }
            else
            {
                compFileData = fileData;
                fileData = new byte[0];
            }

            //First compressed filesize, then uncompressed filesize
            fireDebug("   Sending Filesize...");
            buffer[0] = (byte)((compFileData.Length >> 24) & 0xff);
            buffer[1] = (byte)((compFileData.Length >> 16) & 0xff);
            buffer[2] = (byte)((compFileData.Length >> 8) & 0xff);
            buffer[3] = (byte)(compFileData.Length & 0xff);
            try { nwStream.Write(buffer, 0, 4); }
            catch (Exception ex) { fireDebug("    -> Error sending Filesize:\n" + ex.Message); lastError = "Error sending Filesize:\n" + ex.Message; nwStream.Close(); tcpClient.Close(); return false; }

            if (protocol != Protocol.HAXX)
            {
                buffer[0] = (byte)((fileData.Length >> 24) & 0xff);
                buffer[1] = (byte)((fileData.Length >> 16) & 0xff);
                buffer[2] = (byte)((fileData.Length >> 8) & 0xff);
                buffer[3] = (byte)(fileData.Length & 0xff);
                try { nwStream.Write(buffer, 0, 4); }
                catch (Exception ex) { fireDebug("    -> Error sending Filesize:\n" + ex.Message); lastError = "Error sending Filesize:\n" + ex.Message; nwStream.Close(); tcpClient.Close(); return false; }
            }

            fireDebug("   Sending File...");
            int off = 0;
            int cur = 0;
            int count = compFileData.Length / Blocksize;
            int left = compFileData.Length % Blocksize;

            try
            {
                do
                {
                    fireProgress((++cur) * 100 / count);
                    nwStream.Write(compFileData, off, Blocksize);
                    off += Blocksize;
                } while (cur < count);

                if (left > 0)
                {
                    nwStream.Write(compFileData, off, compFileData.Length - off);
                }
            }
            catch (Exception ex) { fireDebug("    -> Error sending File:\n" + ex.Message); lastError = "Error sending File:\n" + ex.Message; nwStream.Close(); tcpClient.Close(); return false; }

            fireDebug("   Sending Arguments...");
            byte[] args = new byte[fileName.Length + 2];
            for (int i = 0; i < fileName.Length; i++) { args[i] = (byte)fileName.ToCharArray()[i]; }
            try { nwStream.Write(args, 0, args.Length); }
            catch (Exception ex) { fireDebug("    -> Error sending Arguments:\n" + ex.Message); lastError = "Error sending Arguments:\n" + ex.Message; nwStream.Close(); tcpClient.Close(); return false; }

            nwStream.Close();
            tcpClient.Close();

            this.transmittedLength = compFileData.Length;
            if (compress && fileData.Length != 0)
                this.compressionRatio = (compFileData.Length * 100) / fileData.Length;
            else
                this.compressionRatio = 0;

            fireDebug("Transmitting {0} to {1}:{2} Finished...", fileName, ipAddress, port);
            return true;
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

    internal class zlibWrapper
    {
        public enum ZLibError : int
        {
            Z_OK = 0,
            Z_STREAM_END = 1,
            Z_NEED_DICT = 2,
            Z_ERRNO = (-1),
            Z_STREAM_ERROR = (-2),
            Z_DATA_ERROR = (-3),
            Z_MEM_ERROR = (-4),
            Z_BUF_ERROR = (-5),
            Z_VERSION_ERROR = (-6)
        }

        [DllImport("zlib1.dll")]
        private static extern ZLibError compress2(byte[] dest, ref int destLength, byte[] source, int sourceLength, int level);

        public static byte[] Compress(byte[] inFile)
        {
            byte[] outFile = new byte[inFile.Length + 64];
            int outLength = -1;

            ZLibError err = compress2(outFile, ref outLength, inFile, inFile.Length, 6);

            if (err == ZLibError.Z_OK && (outLength > -1 && outLength < inFile.Length))
            {
                Array.Resize(ref outFile, outLength);
                return outFile;
            }
            else
                throw new Exception("An error occured while compressing! Code: " + err.ToString());
        }
    }
}
