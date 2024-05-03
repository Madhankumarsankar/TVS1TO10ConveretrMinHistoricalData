using System;
using System.Xml;
using System.Globalization;
using System.Configuration;

namespace AccessRRD
{
    /// <summary>
    /// Summary description for ReadConfigFile.
    /// </summary>
    public class ReadConfigFile
    {
        #region - XPath Definition

        #region - FileInfo Related

        private const string _INPUT_FOLDER_PATH = "Config/ReceivedFile/InputDir";
        private const string _VALIDATE_SUCCESS_PATH = "Config/ReceivedFile/GoodFileDir";
        private const string _VALIDATE_FAILED_PATH = "Config/ReceivedFile/BadFileDir";

        #endregion - FileInfo Related

        #region - LogFile related

        private const string _LOGLEVEL = "Config/Log/LogLevel";
        private const string _LOG_FILE_PATH = "Config/Log/LogParams/FilePath";
        private const string _LOG_FILE_SIZE_LIMIT = "Config/Log/LogParams/FileSizeLimit";
        private const string _ARCHIVE_FOLDER_PATH = "Config/Log/LogParams/ArchivesPath";
        private const string _LOG_FILE_NAME = "Config/Log/LogParams/FileName";

        #endregion - LogFile related

        #region - Service related

        private const string _SERVICE_TIME_INTERVAL = "Config/WindowsService/TimeInterval";

        #endregion - Service related

        #region - Database related

        //public const string CONNECTION_STRING = @"server=CAMDE; User ID=pioneer; Password=pioneer; database=PIONEER;";
        private const string _DATABASE_SERVER = "Config/DataBaseParams/Server";
        private const string _DATABASE_USERID = "Config/DataBaseParams/UserID";
        private const string _DATABASE_PASSWORD = "Config/DataBaseParams/PassWord";
        private const string _DATABASE_NAME = "Config/DataBaseParams/Database";

        #endregion - Database related

        #region - ASN Related

        private const string _ASN_OUTPUTDIR = "Config/ASN/OutPut_Dir";

        #endregion - ASN Related

        #endregion - XPath Definition 

        #region - Private Variables

        XmlDocument myXmlDoc = new XmlDocument();

        #region - FileInfo Related

        private static string _szInputFPath = "";
        private static string _szGoodFpath = "";
        private static string _szBadFPath = "";

        #endregion - FileInfo Related

        #region - LogFile Related

        private static int _nLogLevel = (ConfigurationManager.AppSettings["LogLevel"] != "" ? (Convert.ToInt32(ConfigurationManager.AppSettings["LogLevel"])) : 3);
        private static string _szLogFilePath = ConfigurationManager.AppSettings["LogFileLocation"].ToString();
        private static string _szLogArchPath = ConfigurationManager.AppSettings["LogArchivesPath"].ToString();
        private static int _nLogFSizeLt = (ConfigurationManager.AppSettings["LogFileSizeLimit"] != "" ? (Convert.ToInt32(ConfigurationManager.AppSettings["LogFileSizeLimit"]) * 1048576) : 1048576);
        private static string _szLogFileName = ConfigurationManager.AppSettings["LogFileName"].ToString();

        //private static string _szFMPUserDataPath = ConfigurationSettings.AppSettings["FMPUserDataPath"].ToString();				
        //private static string _szFMPTransData_OrderPDFPath = ConfigurationSettings.AppSettings["FMPTransData_OrderPDFPath"].ToString();				
        //private static string _szFMPTransData_OrderDataPath = ConfigurationSettings.AppSettings["FMPTransData_OrderDataPath"].ToString();			

        #endregion - LogFile Related

        #region - Service Related

        private static int _nSerTimeIntveral = 0;

        #endregion - Service Related

        #region - DataBase Related

        private static string _szConnectionString = "";

        #endregion - DataBase Related

        #region - ASN related

        private static string _szAsnOutputDir = string.Empty;
        private static string _szOrderCxmlUrl = string.Empty;
        private static string _szOutBoundDir = string.Empty;
        private static string _szOrderResponseFileDir = string.Empty;

        #endregion - ASN related

        #region -  PBSystemShippingInstruction.xml related

        private static string _szDeploymentMode = "";
        private static string _szPioneerDUNS = "";
        private static string _szTestRLZDUNS = "";
        private static string _szProdRLZDUNS = "";
        private static string _szTestSharedCredential = "";
        private static string _szProdSharedCredential = "";
        private static string _szPBSystemsDUNS = "";
        private static string _szCLIENTID = "";

        #endregion -  PBSystemShippingInstruction.xml related

        #endregion - Private Variables   

        #region - Public Properties

        #region - PBSystemShippingInstruction.xml related

        public static string DeploymentMode
        {
            get
            {
                return _szDeploymentMode;
            }
            set
            {
                _szDeploymentMode = value;
            }
        }

        public static string PioneerDUNS
        {
            get
            {
                return _szPioneerDUNS;
            }
            set
            {
                _szPioneerDUNS = value;
            }
        }

        public static string TestRLZDUNS
        {
            get
            {
                return _szTestRLZDUNS;
            }
            set
            {
                _szTestRLZDUNS = value;
            }
        }

        public static string ProdRLZDUNS
        {
            get
            {
                return _szProdRLZDUNS;
            }
            set
            {
                _szProdRLZDUNS = value;
            }
        }

        public static string TestSharedCredential
        {
            get
            {
                return _szTestSharedCredential;
            }
            set
            {
                _szTestSharedCredential = value;
            }
        }

        public static string ProdSharedCredential
        {
            get
            {
                return _szProdSharedCredential;
            }
            set
            {
                _szProdSharedCredential = value;
            }
        }

        public static string PBSystemsDUNS
        {
            get
            {
                return _szPBSystemsDUNS;
            }
            set
            {
                _szPBSystemsDUNS = value;
            }
        }

        public static string CLIENTID
        {
            get
            {
                return _szCLIENTID;
            }
            set
            {
                _szCLIENTID = value;
            }
        }

        #endregion - PBSystemShippingInstruction.xml related

        #region - ASN related

        /// <summary>
        /// Read-only property for ASNOutputDir
        /// </summary>
        public static string ASNOutputDir
        {
            get
            {
                return _szAsnOutputDir;
            }
        }

        /// <summary>
        /// Read-only property for OrderCxmlURL
        /// </summary>
        public static string OrderCxmlURL
        {
            get
            {
                return _szOrderCxmlUrl;
            }
            set
            {
                _szOrderCxmlUrl = value;
            }
        }

        /// <summary>
        /// Read-only property for OutBoundFileDir
        /// </summary>
        public static string OutBoundFileDir
        {
            get
            {
                return _szOutBoundDir;
            }
            set
            {
                _szOutBoundDir = value;
            }
        }


        /// <summary>
        /// Read-only property for OutBoundFileDir
        /// </summary>
        public static string OrderResponseFileDir
        {
            get
            {
                return _szOrderResponseFileDir;
            }
            set
            {
                _szOrderResponseFileDir = value;
            }
        }




        #endregion - ASN related

        #region - DataBase related

        /// <summary>
        /// Read-only property for database Connection string
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return _szConnectionString;
            }
            set
            {
                _szConnectionString = value;
            }
        }

        #endregion - DataBase related

        #region - LogFile Related

        /// <summary>
        /// Read-Write property for loglevel
        /// </summary>
        public static int LoggingLevel
        {
            get
            {
                return _nLogLevel;
            }
            set
            {
                _nLogLevel = value;
            }
        }

        /// <summary>
        /// Read-write property for log file path
        /// </summary>
        public static string LogFilePath
        {
            get
            {
                return _szLogFilePath;
            }
            set
            {
                _szLogFilePath = value;
            }
        }

        /// <summary>
        /// Read-write property for log file size limit.
        /// If the size of the file exceeds this value then it will be moved to arcives folder.
        /// </summary>
        public static int LogFileSizeLimit
        {
            get
            {
                return _nLogFSizeLt;
            }
            set
            {
                _nLogFSizeLt = value;
            }
        }

        /// <summary>
        ///Read-write property for archive folder path.
        /// </summary>
        public static string ArchiveFolderPath
        {
            get
            {
                return _szLogArchPath;
            }
            set
            {
                _szLogArchPath = value;
            }
        }


        /// <summary>
        ///Read-write property for log file name.
        /// </summary>
        public static string LogFileName
        {
            get
            {
                return _szLogFileName;
            }
            set
            {
                _szLogFileName = value;
            }
        }

        #endregion - LogFile Related

        #region - FileInfo Related

        /// <summary>
        /// Read-only property for Input directory from where files are to be read
        /// </summary>
        public static string InputFilePath
        {
            get
            {
                return _szInputFPath;
            }
            set
            {
                _szInputFPath = value;
            }
        }

        /// <summary>
        /// Read-only property for loglevel
        /// </summary>
        public static string ValidatedFilePath
        {
            get
            {
                return _szGoodFpath;
            }
            set
            {
                _szGoodFpath = value;
            }
        }

        /// <summary>
        /// Read-only property for loglevel
        /// </summary>
        public static string InValidatedFilePath
        {
            get
            {
                return _szBadFPath;
            }
            set
            {
                _szBadFPath = value;
            }
        }

        /// <summary>
        /// Read-only property for loglevel
        /// </summary>
        /*public static string FMPUserDataPath
        {
            get
            { 
                return _szFMPUserDataPath; 
            }
            set
            {
                _szFMPUserDataPath = value;
            }
        }*/

        /// <summary>
        /// Read-only property for loglevel
        /// </summary>
        /*public static string FMPTransData_OrderPDFPath
        {
            get
            { 
                return _szFMPTransData_OrderPDFPath; 
            }
            set
            {
                _szFMPTransData_OrderPDFPath = value;
            }
        }*/

        /// <summary>
        /// Read-only property for loglevel
        /// </summary>
        /*public static string FMPTransData_OrderDataPath
        {
            get
            { 
                return _szFMPTransData_OrderDataPath; 
            }
            set
            {
                _szFMPTransData_OrderDataPath = value;
            }
        }*/

        #endregion - FileInfo Related

        #region - Service Related

        /// <summary>
        ///Read-only property for archive folder path.
        /// </summary>
        public static int ServiceTimeInterval
        {
            get
            {
                return _nSerTimeIntveral;
            }
            set
            {
                _nSerTimeIntveral = value;
            }
        }

        #endregion - Service Related

        #endregion - Public Proeprties 

        #region - Enums

        /// <value>Available message severities</value>
        public enum LogLevel
        {
            /// <value>No logging</value>
            NONE = 0,
            /// <value>Information message from system</value>
            HIGH = 1,
            /// <value>Application error message</value>
            MEDIUM = 2,
            /// <value>Fatal system error messag</value>
            LOW = 3,
            /// <value>Above 1 + 2 + 3 + everything</value>
            EVERYTHING = 4
        }

        #endregion - Enums 

        #region - Public Methods

        /// <summary>
        /// Default Constructor. Reads the config file into the XmlDOM object
        /// </summary>
        public ReadConfigFile()
        {
            try
            {
                //To get the System directory on the running server.
                AccessRRD.FSO.GetSystemDirectory();

                this.ReadConfigSettings();
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading Config file. " + ex.Message);
            }
        }

        private void ReadConfigSettings()
        {
            #region - Reading config values for LogLevel

            if (ConfigurationManager.AppSettings["LogLevel"] != "")
            {
                try
                {
                    AccessRRD.ReadConfigFile.LoggingLevel = Convert.ToInt32(ConfigurationManager.AppSettings["LogLevel"]);
                }
                catch (Exception ex)
                {
                    if (ex != null)
                    {

                    }//Need to be reviewed.
                }
            }//If LogLevel value is not empty
            else
            {
                //RWInteg.ReadConfigFile.LoggingLevel = 4;
                AccessRRD.ReadConfigFile.LoggingLevel = 3;
            }//Setting default value in case of empty string.

            #endregion - Reading config values for LogLevel

            #region - Reading config values for LogFileName

            if (ConfigurationManager.AppSettings["LogFileName"] != "")
            {
                AccessRRD.ReadConfigFile.LogFileName = ConfigurationManager.AppSettings["LogFileName"];
            }//If LogLevel value is not empty
            else
            {
                AccessRRD.ReadConfigFile.LogFileName = "RWIntegLog.log";
            }//Setting default value in case of empty string.

            #endregion - Reading config values for LogFileName

            #region - Reading config values for LogFilePath

            if (ConfigurationManager.AppSettings["LogFileLocation"] != "")
            {
                AccessRRD.ReadConfigFile.LogFilePath = ConfigurationManager.AppSettings["LogFileLocation"];
            }//If LogLevel value is not empty
            else
            {
                AccessRRD.ReadConfigFile.LogFilePath = AccessRRD.FSO.SystemDir + @"\RWInteg\LogFolder";
            }//Setting default value in case of empty string.

            #endregion - Reading config values for LogFilePath

            #region - Reading config values for LogFileSizeLimit

            if (ConfigurationManager.AppSettings["LogFileSizeLimit"] != "")
            {
                try
                {
                    AccessRRD.ReadConfigFile.LogFileSizeLimit = Convert.ToInt32(ConfigurationManager.AppSettings["LogFileSizeLimit"]) * 1000000;
                }
                catch (Exception ex)
                {
                    if (ex != null)
                    {

                    }//Need to be reviewed.
                }
            }//If LogLevel value is not empty
            else
            {
                AccessRRD.ReadConfigFile.LogFileSizeLimit = 1000000;
            }//Setting default value in case of empty string.

            #endregion - Reading config values for LogFileSizeLimit

            #region - Reading config values for LogArchivesPath

            if (ConfigurationManager.AppSettings["LogArchivesPath"] != "")
            {
                AccessRRD.ReadConfigFile.ArchiveFolderPath = ConfigurationManager.AppSettings["LogArchivesPath"];
            }//If LogLevel value is not empty
            else
            {
                AccessRRD.ReadConfigFile.ArchiveFolderPath = AccessRRD.FSO.SystemDir + @"\RWInteg\Archives";
            }//Setting default value in case of empty string.

            #endregion - Reading config values for LogArchivesPath

            #region - Reading config values for OrderCxml Files folder location

            if (ConfigurationManager.AppSettings["OutBoundDir"] != "")
            {
                AccessRRD.ReadConfigFile.OutBoundFileDir = ConfigurationManager.AppSettings["OutBoundDir"];
            }//If out bound files directory value is not empty.
            else
            {
                AccessRRD.ReadConfigFile.OutBoundFileDir = AccessRRD.FSO.SystemDir + @"\RWInteg\OutBoundFiles";
            }//Setting default value in case of empty string.

            if (ConfigurationManager.AppSettings["ResponseFilesDir"] != "")
            {
                AccessRRD.ReadConfigFile.OrderResponseFileDir = ConfigurationManager.AppSettings["ResponseFilesDir"];
            }//If Order response files directory value is not empty.
            else
            {
                AccessRRD.ReadConfigFile.OrderResponseFileDir = AccessRRD.FSO.SystemDir + @"\RWInteg\OrderResponseFiles";
            }//Setting default value in case of empty string.

            #endregion - Reading config values for Input Files folder location

            #region - Reading Database Connection String
            if (ConfigurationManager.AppSettings["connectionString"] != "")
            {
                AccessRRD.ReadConfigFile.ConnectionString = ConfigurationManager.AppSettings["connectionString"];
            }//If LogLevel value is not empty
            else
            {
                throw new Exception("Connection string not set");
            }


            #endregion - Reading Database Connection String

            #region  - Reading config values for PBSystemShippingInstruction.xml

            //Fetching Deployment mode from config file. This can be Test for testing environment and Production for production environment
            if (ConfigurationManager.AppSettings["DeploymentMode"] != "")
            {
                AccessRRD.ReadConfigFile.DeploymentMode = ConfigurationManager.AppSettings["DeploymentMode"];
            }//Check for empty string.

            //Fetching PioneerDUNS from config file.
            if (ConfigurationManager.AppSettings["PioneerDUNS"] != "")
            {
                AccessRRD.ReadConfigFile.PioneerDUNS = ConfigurationManager.AppSettings["PioneerDUNS"];
            }//Check for empty string.

            //Fetching DUNS number for Testing environment from config file.
            if (ConfigurationManager.AppSettings["TestRLZDUNS"] != "")
            {
                AccessRRD.ReadConfigFile.TestRLZDUNS = ConfigurationManager.AppSettings["TestRLZDUNS"];
            }//Check for empty string.

            //Fetching DUNS number for Production environment from config file.
            if (ConfigurationManager.AppSettings["ProdRLZDUNS"] != "")
            {
                AccessRRD.ReadConfigFile.ProdRLZDUNS = ConfigurationManager.AppSettings["ProdRLZDUNS"];
            }//Check for empty string.

            //Fetching Shared credentials for Testing environment from config file.
            if (ConfigurationManager.AppSettings["TestSharedCredential"] != "")
            {
                AccessRRD.ReadConfigFile.TestSharedCredential = ConfigurationManager.AppSettings["TestSharedCredential"];
            }//Check for empty string.

            //Fetching Shared credentials for production environment from config file.
            if (ConfigurationManager.AppSettings["ProdSharedCredential"] != "")
            {
                AccessRRD.ReadConfigFile.ProdSharedCredential = ConfigurationManager.AppSettings["ProdSharedCredential"];
            }//Check for empty string.

            //Fetching URL to which order cXML message is to be posted from config file.
            if (ConfigurationManager.AppSettings["OrderCxmlUrl"] != "")
            {
                AccessRRD.ReadConfigFile.OrderCxmlURL = ConfigurationManager.AppSettings["OrderCxmlUrl"];
            }//Check for empty string.

            //Fetching PBSystemsDuns from Config file.
            if (ConfigurationManager.AppSettings["PBSystemsDUNS"] != "")
            {
                AccessRRD.ReadConfigFile.PBSystemsDUNS = ConfigurationManager.AppSettings["PBSystemsDUNS"];
            }//check for empty string.

            //Fetching CLIENTID from config file.
            if (ConfigurationManager.AppSettings["CLIENTID"] != "")
            {
                AccessRRD.ReadConfigFile.CLIENTID = ConfigurationManager.AppSettings["CLIENTID"];
            }//check for the empty string.

            #endregion  - Reading config values for PBSystemShippingInstruction.xml

        }

        #endregion - Public Methods 
    }
}
