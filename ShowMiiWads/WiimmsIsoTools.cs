using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Wii
{
    public enum GameType
    {
        iso, wdf, wia, ciso, wbi, wbfs, fst, unknown
    }

    public class WiiGame
    {
        public string id { get; set; }
        public string title { get; set; }
        public string customTitle { get; set; }
        public int iosRequired { get; set; }
        public string region { get; set; }
        public int size { get; set; }
        public GameType gameType { get; set; }
        public string gamePath { get; set; }
    }

    public class WiimmsIsoTools
    {
        private string witPath;
        private string gamesPathDirectory;
        private volatile bool isStopRequired;
        private List<WiiGame> gamesListToConvert;

        /// <summary>
        /// Fires the Progress of various operations
        /// </summary>
        public event EventHandler<ProgressChangedEventArgs> Progress;
        /// <summary>
        /// Fires estimated ETA of process.
        /// </summary>
        public event EventHandler<MessageEventArgs> ETA;
        /// <summary>
        /// Fires info when thread is finish.
        /// </summary>
        public event EventHandler<ThreadFinishEventArgs> ThreadFinish;

        #region Constructors

        public WiimmsIsoTools()
        {
            this.witPath = Application.StartupPath + Path.DirectorySeparatorChar + "External" + Path.DirectorySeparatorChar + "wit" + Path.DirectorySeparatorChar + "wit.exe";
            this.gamesPathDirectory = null;
            this.gamesListToConvert = new List<WiiGame>();
            this.isStopRequired = false;
        }

        public WiimmsIsoTools(string gamesPathDirectory)
        {
            this.witPath = Application.StartupPath + Path.DirectorySeparatorChar + "External" + Path.DirectorySeparatorChar + "wit" + Path.DirectorySeparatorChar + "wit.exe";
            this.gamesPathDirectory = gamesPathDirectory;
            this.gamesListToConvert = new List<WiiGame>();
            this.isStopRequired = false;
        }

        public WiimmsIsoTools(string gamesPathDirectory, List<WiiGame> gamesListToConvert)
        {
            this.witPath = Application.StartupPath + Path.DirectorySeparatorChar + "External" + Path.DirectorySeparatorChar + "wit" + Path.DirectorySeparatorChar + "wit.exe";
            this.gamesPathDirectory = gamesPathDirectory;
            this.gamesListToConvert = gamesListToConvert;
            this.isStopRequired = false;
        }

        #endregion

        #region fire methods

        private void FormatProgressExtractInfo(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                Regex myRegex = new Regex(@"([\d]+)% copied in ([\d]+:[\d]{2}\.[\d]{3}) \(([\d]+\.[\d]{1} [\w]{3}\/sec)\)");
                Regex myRegexEta = new Regex(@"-> ETA ([\d]+\:[\d]{2})");

                Match m = myRegex.Match(outLine.Data);

                if (m.Success)
                {
                    fireProgress(int.Parse(m.Groups[1].Value));
                }

                m = myRegexEta.Match(outLine.Data);

                if (m.Success)
                {
                    fireETA(m.Groups[1].Value);
                }
            }
        }

        private void fireProgress(int progressPercentage)
        {
            EventHandler<ProgressChangedEventArgs> progress = Progress;
            if (progress != null)
                progress(new object(), new ProgressChangedEventArgs(progressPercentage));
        }

        private void fireETA(string Eta, params object[] args)
        {
            EventHandler<MessageEventArgs> eta = ETA;
            if (eta != null)
                eta(new object(), new MessageEventArgs(string.Format(Eta, args)));
        }

        private void fireThreadFinish(bool isInterrupted)
        {
            EventHandler<ThreadFinishEventArgs> isThreadInterrupted = ThreadFinish;
            if (isThreadInterrupted != null)
                isThreadInterrupted(new object(), new ThreadFinishEventArgs(isInterrupted));
        }

        #endregion
        
        #region public methods

        public int GetRequiredIOS(string gamePath)
        {
            int ios = -1;
            ProcessStartInfo processInfo;

            if (!isStopRequired && !String.IsNullOrEmpty(gamePath))
            {
                processInfo = new ProcessStartInfo(witPath);
                processInfo.Arguments = @"dump --show P-INFO " + gamePath;

                processInfo.UseShellExecute = false;
                processInfo.CreateNoWindow = true;
                processInfo.RedirectStandardOutput = true;

                Process witProcess = new Process();
                witProcess.StartInfo = processInfo;

                witProcess.Start();

                string output = witProcess.StandardOutput.ReadToEnd();

                witProcess.WaitForExit();
                witProcess.Close();

                Regex myRegex = new Regex(@"System version:   [\d]{8}-[\d]{8} = IOS 0x[\d]{2} = IOS ([\d]{2})");

                Match m = myRegex.Match(output);

                if (m.Success)
                {
                    try
                    {
                        ios = int.Parse(m.Groups[1].Value);
                    }
                    catch
                    {
                        ios = -1;
                    }
                }
            }

            fireThreadFinish(isStopRequired);

            return ios;
        }

        public void ExtractGames()
        {
            int exitCode = -1;

            ProcessStartInfo processInfo;

            if (String.IsNullOrEmpty(this.gamesPathDirectory))
            {
                return;
            }

            foreach (WiiGame game in gamesListToConvert)
            {

                if (!isStopRequired)
                {
                    processInfo = new ProcessStartInfo(witPath);
                    processInfo.Arguments = @"extract --sneek -v -v -v " + game.gamePath + " " + this.gamesPathDirectory + Path.DirectorySeparatorChar + "\'[%I]\'";

                    processInfo.UseShellExecute = false;
                    processInfo.CreateNoWindow = true;
                    processInfo.RedirectStandardOutput = true;

                    Process witProcess = new Process();
                    witProcess.StartInfo = processInfo;

                    witProcess.OutputDataReceived += new DataReceivedEventHandler(FormatProgressExtractInfo);

                    witProcess.Start();

                    witProcess.BeginOutputReadLine();

                    witProcess.WaitForExit();

                    exitCode = witProcess.ExitCode;

                    witProcess.Close();
                }
            }

            fireThreadFinish(isStopRequired);
        }

        public List<WiiGame> ListGames(string gamePath, string langCode)
        {
            List<WiiGame> result = new List<WiiGame>();
            char[] separateur;
            ProcessStartInfo processInfo;

            if (!isStopRequired && !String.IsNullOrEmpty(gamePath))
            {
                processInfo = new ProcessStartInfo(witPath);
                processInfo.Arguments = @"list --real-path --sections --title titles-" + langCode + ".txt " + gamePath;

                processInfo.UseShellExecute = false;
                processInfo.CreateNoWindow = true;
                processInfo.RedirectStandardOutput = true;

                Process witProcess = new Process();
                witProcess.StartInfo = processInfo;

                witProcess.Start();

                string output = witProcess.StandardOutput.ReadToEnd();

                witProcess.WaitForExit();
                witProcess.Close();

                separateur = "\0".ToCharArray();

                string[] outputs = output.Replace("\r\n\r\n", "\0").Split(separateur, StringSplitOptions.RemoveEmptyEntries);

                foreach (string info in outputs)
                {
                    if (!String.IsNullOrEmpty(info) && !isStopRequired)
                    {

                        separateur = "\r\n".ToCharArray();

                        string[] infos = info.Split(separateur, StringSplitOptions.RemoveEmptyEntries);

                        if (infos.Length == 18)
                        {
                            WiiGame game = new WiiGame();

                            game.id = infos[1].Replace("id=", "");
                            game.title = infos[2].Replace("name=", "");
                            game.customTitle = infos[3].Replace("title=", "");
                            game.region = infos[4].Replace("region=", "");

                            try
                            {
                                game.size = int.Parse(infos[5].Replace("size=", ""));
                            }
                            catch
                            {
                                game.size = -1;
                            }

                            try
                            {
                                game.gameType = (GameType)Enum.Parse(typeof(GameType), infos[11].Replace("container=", ""), true);
                            }
                            catch
                            {
                                game.gameType = GameType.unknown;
                            }

                            game.gamePath = infos[16].Replace("filename=", "");

                            game.iosRequired = this.GetRequiredIOS(game.gamePath);

                            result.Add(game);
                        }
                    }
                }
            }

            fireThreadFinish(isStopRequired);

            return result;
        }

        public void IsStopRequired()
        {
            isStopRequired = false;
        }
        #endregion
    }
}
