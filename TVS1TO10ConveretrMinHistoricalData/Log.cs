using System;
using System.IO;
using System.Text;
using System.Globalization;

//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace AccessRRD
{
    public class Log
    {
        private static int _nLogLevel = 0;

        /// <value>Available message severities</value>
        public enum MessageType
        {
            /// <value>Fatal system error message</value>
            //			Error = 1,
            //			/// <value>Application error message</value>
            //			Failure = 2,
            //			/// <value>Information message from system</value>
            //			Information = 3,
            //			/// <value>Debug message from developer</value>
            //			Debug = 4,

            Alert = 1,
            Summary = 2,
            Detail = 3,
        }

        public Log()
        {
            _nLogLevel = ReadConfigFile.LoggingLevel;
        }

        /// <summary>
        /// Record a log, which is an exception.
        /// </summary>
        /// <param name="Message">Exception to log. </param>
        /// <param name="Severity">Error severity level. </param>
        public void WriteToLog(Exception Message, string szSource, Log.MessageType Severity)
        {
            this.WriteToLog(Message.Message, szSource, Severity);
        }

        /// <summary>
        /// Record a log, which is a string.
        /// </summary>
        /// <param name="Message">Message to log. </param>	
        /// <param name="Severity">Error severity level. </param>	
        public void WriteToLog(string szLogMessage, string szSource, Log.MessageType Severity)
        {
            if (szLogMessage.ToLower().Trim().IndexOf("thread was being aborted") == -1)
            {
                FSO myFso = new FSO();
                myFso.CreateFolders();
                if (doLog(Severity))
                {
                    TextWriter logWriter = null;
                    string szFullFileName = "";
                    StringBuilder sbLogMessage = new StringBuilder();

                    szFullFileName = ReadConfigFile.LogFilePath + @"\" + ReadConfigFile.LogFileName;

                    try
                    {
                        // Variables declared to get the required date format.	
                        DateTimeFormatInfo dfi = new DateTimeFormatInfo();
                        DateTime dt = DateTime.Now;
                        dfi.LongDatePattern = "dd-MMM-yyyy";
                        dfi.ShortTimePattern = "HH-mm-ss";

                        //Check to see if current log file size exceeds the maxSize
                        if (ReadConfigFile.LogFileSizeLimit > 0)
                        {
                            AccessRRD.FSO.CheckLogSize(szFullFileName, dt.ToString("D", dfi) + "_" + dt.ToString("t", dfi));
                        }

                        //open the logfile for writing - create it if it does not exist
                        logWriter = File.AppendText(szFullFileName);

                        //Begin modified since to display user id also in log file
                        //string szLogString = string.Format( "{0}:{1}:<{2}>\t{3}", dt.ToString( "D", dfi ), dt.ToString( "t", dfi ), szSource, szLogMessage );
                        //Example --- 24-Nov-2005:10-32-05:<OrderVerificationWorkarea.BuildPOD_HighResFiles><User Id:7><Severity:Alert>	File does not exist at
                        //string szLogString = string.Format( "{0}:{1}:<{2}><{3}><{4}>\t{5}", dt.ToString( "D", dfi ), dt.ToString( "t", dfi ),szSource,"User Id:"+strUserId,"Severity:" + Severity,szLogMessage );
                        string szLogString = string.Format("{0}:{1}:<{2}><{3}>\t{4}", dt.ToString("D", dfi), dt.ToString("t", dfi), szSource, "Severity:" + Severity, szLogMessage);
                        //End modified since to display user id also in log file

                        //write out the datetime and message
                        logWriter.WriteLine(szLogString);

                        //close the writer and underlying file
                        logWriter.Close();
                    }
                    catch (Exception ex)
                    {
                        string sz = ex.Message;
                    }
                }
            }
        }

        #region Not using

        public void WriteToLog(Exception Message, string szSource)
        {
            this.WriteToLog(Message.Message, szSource);
        }

        /// <summary>
        /// Record a log, which is a string.
        /// </summary>
        /// <param name="Message">Message to log. </param>		
        public void WriteToLog(string szLogMessage, string szSource)
        {
            if (szLogMessage.ToLower().Trim().IndexOf("thread was being aborted") == -1)
            {
                TextWriter logWriter = null;
                string szFullFileName = "";
                StringBuilder sbLogMessage = new StringBuilder();

                szFullFileName = ReadConfigFile.LogFilePath + @"\" + ReadConfigFile.LogFileName;

                try
                {
                    // Variables declared to get the required date format.	
                    DateTimeFormatInfo dfi = new DateTimeFormatInfo();
                    DateTime dt = DateTime.Now;
                    dfi.LongDatePattern = "dd-MMM-yyyy";
                    dfi.ShortTimePattern = "HH-mm-ss";

                    //Check to see if current log file size exceeds the maxSize
                    if (ReadConfigFile.LogFileSizeLimit > 0)
                    {
                        AccessRRD.FSO.CheckLogSize(szFullFileName, dt.ToString("D", dfi) + "_" + dt.ToString("t", dfi));
                    }

                    //open the logfile for writing - create it if it does not exist
                    logWriter = File.AppendText(szFullFileName);

                    string szLogString = string.Format("{0}:{1}:<{2}>\t{3}", dt.ToString("D", dfi), dt.ToString("t", dfi), szSource, szLogMessage);

                    //write out the datetime and message
                    logWriter.WriteLine(szLogString);

                    //close the writer and underlying file
                    logWriter.Close();
                }
                catch (Exception ex)
                {
                    string sz = ex.Message;
                }
            }
        }

        #endregion


        /// <summary>
        /// This method returns whether the Logger component needs to log the message or not.
        /// </summary>
        /// <param name="logLevel">Configurred log level</param>
        /// <returns>True or false</returns>
        private bool doLog(Log.MessageType Severity)
        {
            bool doLog = false;

            switch (ReadConfigFile.LoggingLevel)
            {
                case 0:
                    doLog = false;
                    break;
                case 1:
                    if (Severity == AccessRRD.Log.MessageType.Alert)
                        doLog = true;
                    break;
                case 2:
                    if (Severity == AccessRRD.Log.MessageType.Alert || Severity == AccessRRD.Log.MessageType.Summary)
                        doLog = true;
                    break;
                case 3:
                    if (Severity == AccessRRD.Log.MessageType.Alert || Severity == AccessRRD.Log.MessageType.Summary || Severity == AccessRRD.Log.MessageType.Detail)
                        doLog = true;
                    break;
            }
            return doLog;            
        }
    }
}
