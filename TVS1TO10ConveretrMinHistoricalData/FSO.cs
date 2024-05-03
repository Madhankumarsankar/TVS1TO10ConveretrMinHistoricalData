using System;
using System.IO;
using System.Data;
using System.Configuration;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace AccessRRD
{
    public class FSO
    {
        #region - Private Variables

        private static string _szSystemDir = "";

        #endregion - Private Variables 

        #region - Public Properties

        /// <summary>
        /// Read-only property for system directory.
        /// </summary>
        public static string SystemDir
        {
            get { return _szSystemDir; }
        }

        #endregion - Public Properties 

        #region - Public Methods

        /// <summary>
        /// Default constructor
        /// </summary>
        public FSO()
        {

        }


        /// <summary>
        /// Get the System directory on the server the appliation is running.
        /// This is necessary to generate the default folders locations.
        /// </summary>
        public static void GetSystemDirectory()
        {
            int nIndex = System.Environment.SystemDirectory.IndexOf(@"\");
            _szSystemDir = System.Environment.SystemDirectory.Substring(0, nIndex);
        }


        /// <summary>
        /// Creates set of folders that were required for integration.
        /// </summary>
        public void CreateFolders()
        {
            if (ReadConfigFile.OutBoundFileDir != null && ReadConfigFile.OutBoundFileDir != "")
            {
                if (!Directory.Exists(ReadConfigFile.OutBoundFileDir))
                {
                    Directory.CreateDirectory(ReadConfigFile.OutBoundFileDir);
                }//Checking whether outbound file directory exists or not. If doesnt exist creating it.
            }//Null and empty string checking.

            if (ReadConfigFile.OrderResponseFileDir != null && ReadConfigFile.OrderResponseFileDir != "")
            {
                if (!Directory.Exists(ReadConfigFile.OrderResponseFileDir))
                {
                    Directory.CreateDirectory(ReadConfigFile.OrderResponseFileDir);
                }//Checking whether outbound response files directory exists or not. If doesnt exist creating it.
            }//Null and empty string checking.


            if (ReadConfigFile.InputFilePath != null && ReadConfigFile.InputFilePath != "")
            {
                if (!Directory.Exists(ReadConfigFile.InputFilePath))
                {
                    Directory.CreateDirectory(ReadConfigFile.InputFilePath);
                }//Checking whether input file directory exists or not. If doesnt exist creating it.
            }//Null and empty string checking.

            if (ReadConfigFile.ValidatedFilePath != null && ReadConfigFile.ValidatedFilePath != "")
            {
                if (!Directory.Exists(ReadConfigFile.ValidatedFilePath))
                {
                    Directory.CreateDirectory(ReadConfigFile.ValidatedFilePath);
                }//Checking whether validated files directory exists or not. If doesn't exist creating it.
            }//Null and empty string checking.


            if (ReadConfigFile.InValidatedFilePath != null && ReadConfigFile.InValidatedFilePath != "")
            {
                if (!Directory.Exists(ReadConfigFile.InValidatedFilePath))
                {
                    Directory.CreateDirectory(ReadConfigFile.InValidatedFilePath);
                }//Checking whether invalidated files directory exists or not. If doesn't exist creating it.
            }//Null and empty string checking.


            if (ReadConfigFile.LogFilePath != null && ReadConfigFile.LogFilePath != "")
            {
                if (!Directory.Exists(ReadConfigFile.LogFilePath))
                {
                    Directory.CreateDirectory(ReadConfigFile.LogFilePath);
                }//Checking whether Log files directory exists or not. If doesn't exist creating it.
            }//Null and empty string checking.


            if (ReadConfigFile.ArchiveFolderPath != null && ReadConfigFile.ArchiveFolderPath != "")
            {
                if (!Directory.Exists(ReadConfigFile.ArchiveFolderPath))
                {
                    Directory.CreateDirectory(ReadConfigFile.ArchiveFolderPath);
                }//Checking whether Log files directory exists or not. If doesn't exist creating it.
            }

            /*if( ReadConfigFile.FMPUserDataPath != null && ReadConfigFile.FMPUserDataPath != "" )
            {
                if( !Directory.Exists( ReadConfigFile.FMPUserDataPath ) )
                {
                    Directory.CreateDirectory( ReadConfigFile.FMPUserDataPath );
                }//Checking whether Log files directory exists or not. If doesn't exist creating it.
            }

            if( ReadConfigFile.FMPTransData_OrderPDFPath != null && ReadConfigFile.FMPTransData_OrderPDFPath != "" )
            {
                if( !Directory.Exists( ReadConfigFile.FMPTransData_OrderPDFPath ) )
                {
                    Directory.CreateDirectory( ReadConfigFile.FMPTransData_OrderPDFPath );
                }//Checking whether FMPTransData_OrderPDFPath directory exists or not. If doesn't exist creating it.
            }

            if( ReadConfigFile.FMPTransData_OrderDataPath != null && ReadConfigFile.FMPTransData_OrderDataPath != "" )
            {
                if( !Directory.Exists( ReadConfigFile.FMPTransData_OrderDataPath ) )
                {
                    Directory.CreateDirectory( ReadConfigFile.FMPTransData_OrderDataPath );
                }//Checking whether FMPTransData_OrderDataPath directory exists or not. If doesn't exist creating it.
            }*/
        }


        /// <summary>
        /// Checking the size of the log file. Moving the file if it exceeds the limit.
        /// </summary>
        /// <param name="szFullFileName">Path of the log file path which is to be checked.</param>
        /// <param name="szCurrTimeStamp">Current time stamp. Which will be used in building the moved log file name</param>
        /// <returns></returns>
        public static string CheckLogSize(string szFullFileName, string szCurrTimeStamp)
        {
            Log myLog = new Log();
            FileInfo checkFile;
            string szNewFileName = "";

            try
            {
                //Check size of log. If greater than LogFileSizeLimit archive and start a new one.
                if (File.Exists(szFullFileName))
                {
                    checkFile = new FileInfo(szFullFileName);

                    if (checkFile.Length >= (ReadConfigFile.LogFileSizeLimit))
                    {
                        szNewFileName = ReadConfigFile.ArchiveFolderPath + @"\WebLog_" + szCurrTimeStamp + ".txt";
                        if (File.Exists(szNewFileName))
                        {
                            File.Delete(szNewFileName);
                        }
                        File.Copy(szFullFileName, szNewFileName);
                        File.Delete(szFullFileName);
                    }
                }
            }
            catch (Exception ex)
            {
                myLog.WriteToLog(ex, "FSO.CheckLogSize");
            }
            return szFullFileName;
        }

        #endregion - Public Methods 
    }
}
