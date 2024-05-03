using AccessRRD;
using BLL;
using Microsoft.ApplicationBlocks.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TVS1TO10ConveretrMinHistoricalData
{
    public partial class TVS1TO10ConveretrMinHistoricalData : ServiceBase
    {
        string FolderPath = ConfigurationManager.AppSettings["Path"].ToString();
        int intCommandTimeOut = int.Parse(ConfigurationManager.AppSettings["CommandTimeOut"].ToString());
        Log loginfo = new Log();
        string StartProcessYN = "N"; // service is not in process	  
        string strTimeInterval = ConfigurationManager.AppSettings["ServiceTimeInterval"].ToString();
        static Dictionary<string, DateTime> fileUploadTimes = new Dictionary<string, DateTime>();
        FileSystemWatcher watcher = new FileSystemWatcher();
        
        private DateTime lastExecutionDate = DateTime.MinValue;
        private object lockObject = new object();
        //string connection;

        string connection;
        DataSet GateWayDetailsFull;
        string SNID;

        public TVS1TO10ConveretrMinHistoricalData()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                loginfo.WriteToLog("OnStart event started", "OnStart", Log.MessageType.Detail);

                StartProcessYN = "Y";

                //Assigning the Initial ServiceInterval.
                servicetimer.Enabled = true;
                servicetimer.Interval = Convert.ToDouble(strTimeInterval) * 2000.00;

                loginfo.WriteToLog("OnStart event ended", "OnStart", Log.MessageType.Detail);
            }
            catch (Exception ex)
            {
                loginfo.WriteToLog("Exception Occured : " + ex, "OnStart", Log.MessageType.Detail);

            }
        }

        protected override void OnStop()
        {
            try
            {
                loginfo.WriteToLog("OnStop event started", "OnStop", Log.MessageType.Detail);
                this.servicetimer.Enabled = false;
                loginfo.WriteToLog("OnStop event ended", "OnStop", Log.MessageType.Detail);
                //  loginfo.WriteToLog("Exception Occured : " + ex, "ServiceTimer_Elapsed event", Log.MessageType.Detail);
                ServiceController service = new ServiceController("TVS1TO10ConveretrMinHistoricalData");
                try
                {
                    int millisec1 = Environment.TickCount;
                    TimeSpan timeout = TimeSpan.FromMilliseconds(1000);


                    if ((service.Status.Equals(ServiceControllerStatus.Stopped)) ||
                         (service.Status.Equals(ServiceControllerStatus.StopPending)))
                    {
                        // count the rest of the timeout
                        int millisec2 = Environment.TickCount;
                        timeout = TimeSpan.FromMilliseconds(1000 - (millisec2 - millisec1));

                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                        loginfo.WriteToLog("service started in after comport Access Denied", "", Log.MessageType.Detail);
                    }

                }
                catch
                {
                    loginfo.WriteToLog("unable to start the service ON STOP", "", Log.MessageType.Detail);
                    int millisec1 = Environment.TickCount;
                    TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
                    loginfo.WriteToLog("unable to start the service", "", Log.MessageType.Detail);
                    if ((service.Status.Equals(ServiceControllerStatus.Stopped)) ||
                        (service.Status.Equals(ServiceControllerStatus.StopPending)))
                    {
                        // count the rest of the timeout
                        int millisec2 = Environment.TickCount;
                        timeout = TimeSpan.FromMilliseconds(1000 - (millisec2 - millisec1));

                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                        loginfo.WriteToLog("service started in after comport close", "", Log.MessageType.Detail);
                    }
                }
            }
            catch (Exception ex)
            {
                loginfo.WriteToLog("Exception Occured : " + ex, "OnStop", Log.MessageType.Detail);
            }
        }

        private void servicetimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            loginfo.WriteToLog("servicetimer_Elapsed event started", "", Log.MessageType.Detail);
            try
            {
                int g = 0;

                while (g == 0)
                {
                    loginfo.WriteToLog("=================================================================  ", "", Log.MessageType.Detail);
                    deletejsonfile();
                    GetGateWayDetials();
                    Thread.Sleep(10000);
                    loginfo.WriteToLog("=================================================================  ", "", Log.MessageType.Detail);
                }
            }
            catch (Exception ex)
            {
                loginfo.WriteToLog("Exception occured at servicetimer_Elapsed  " + ex, "", Log.MessageType.Detail);
            }
        }

        public void GetGateWayDetials()
        {
            try
            {
                BLL_Login bLL_ = new BLL_Login("", 0);

                GateWayDetailsFull = bLL_.GetgatewayDetails();
                int ServiceNo = 1;
                DataSet GateWayDetails = bLL_.GetjsonStorageGateways(ServiceNo);

                DataTable dtGateWayFullDetails = GateWayDetailsFull.Tables[0];
                DataTable dtGateWaypolling = GateWayDetails.Tables[0];
                loginfo.WriteToLog("dtGateWaypolling count " + dtGateWaypolling.Rows.Count, "GetGateWayDetials", Log.MessageType.Detail);

                for (int i = 0; i < dtGateWaypolling.Rows.Count; i++)
                {
                    //Get a SN number
                    SNID = dtGateWaypolling.Rows[i]["SN"].ToString();
                    loginfo.WriteToLog("SNID= " + SNID, "GetGateWayDetials", Log.MessageType.Detail);

                    //Connection string
                    //connection= dataTable.Rows[i]["dbname"].ToString();


                    // Specify the directory path to monitor
                    string directoryPath = FolderPath + SNID;


                    // Process existing files in the directory
                    ProcessExistingFiles(directoryPath, SNID);

                    // Create a FileSystemWatcher to monitor the directory for changes

                    //watcher.Path = directoryPath;
                    //watcher.Filter = "*.json";
                    //watcher.EnableRaisingEvents = true;

                    //// Subscribe to the Created event
                    //watcher.Created += OnFileCreated;

                    //// Set up a timer to check for fully uploaded files at intervals
                    //timer = new System.Windows.Forms.Timer();
                    //timer.Interval = 5000; // Check every 5 seconds
                    //timer.Tick += CheckFileUploadStatus;
                    //timer.Start();



                }
            }
            catch (Exception ex)
            {
                loginfo.WriteToLog("Not able to Get GateWay Details Method Name GetGateWayDetials" + ex.Message, "", Log.MessageType.Detail);
            }
        }

        private void ProcessExistingFiles(string directoryPath, string SNID)
        {
            try
            {
                // Check if the directory exists
                if (!Directory.Exists(directoryPath))
                {
                    loginfo.WriteToLog("Directory not found: " + directoryPath, "ProcessExistingFiles", Log.MessageType.Detail);
                    return;
                }

                // Get all existing JSON files in the directory
                string[] existingFiles = Directory.GetFiles(directoryPath, "*.json");
                loginfo.WriteToLog("ProcessExistingFiles started. Existing files count: " + existingFiles.Length, "ProcessExistingFiles", Log.MessageType.Detail);

                if (existingFiles.Length > 0)
                {
                    // Process each existing file
                    foreach (string filePath in existingFiles)
                    {
                        ProcessJsonFile(filePath, connection, SNID);
                    }
                }
                else
                {
                    loginfo.WriteToLog("No files found for processing in directory: " + directoryPath, "ProcessExistingFiles", Log.MessageType.Detail);
                }

                loginfo.WriteToLog("ProcessExistingFiles Ended ", "ProcessExistingFiles", Log.MessageType.Detail);
            }
            catch (Exception ex)
            {
                loginfo.WriteToLog("Error processing: " + ex.Message, "ProcessExistingFiles", Log.MessageType.Detail);
            }
        }



        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            try
            {
                lock (fileUploadTimes)
                {
                    // Store the upload time of the file
                    fileUploadTimes[e.FullPath] = DateTime.Now;
                }
            }
            catch (Exception ex)
            {

                loginfo.WriteToLog("Error processing ex= " + ex, "OnFileCreated", Log.MessageType.Detail);
            }

        }

        private void CheckFileUploadStatus(object sender, EventArgs e)
        {
            loginfo.WriteToLog("entred in to CheckFileUploadStatus ", "CheckFileUploadStatus", Log.MessageType.Detail);
            lock (fileUploadTimes)
            {
                // Iterate through the dictionary to check for fully uploaded files
                foreach (var kvp in fileUploadTimes.ToArray())
                {
                    string filePath = kvp.Key;
                    DateTime uploadTime = kvp.Value;

                    // If the file was last written more than 5 seconds ago, consider it fully uploaded
                    if (DateTime.Now - uploadTime > TimeSpan.FromSeconds(5))
                    {
                        // File is fully uploaded, process it
                        ProcessJsonFile(filePath, "", "");

                        // Remove the file entry from the dictionary
                        fileUploadTimes.Remove(filePath);
                    }
                }
            }

            loginfo.WriteToLog("End in to CheckFileUploadStatus ", "CheckFileUploadStatus", Log.MessageType.Detail);
        }

        private void ProcessJsonFile(string filePath, string connection, string SNID)
        {
            try
            {
                loginfo.WriteToLog("Entered the ProcessJsonFile method", "ProcessJsonFile", Log.MessageType.Detail);
                // Read the JSON file
                string jsonData = File.ReadAllText(filePath);

                // Deserialize the JSON data into a dynamic object
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

                // Create a DataTable to store the node values
                DataTable MinnotraTable = new DataTable();
                MinnotraTable.Columns.Add("Channel", typeof(int));
                MinnotraTable.Columns.Add("ID", typeof(int));
                MinnotraTable.Columns.Add("Name", typeof(string));
                MinnotraTable.Columns.Add("CreatedON", typeof(DateTime));
                MinnotraTable.Columns.Add("Value", typeof(float));
                DateTime CreatedOn = jsonObject.logdt;
                loginfo.WriteToLog("Column Names are added", "", Log.MessageType.Detail);
                try
                {
                    foreach (var device in jsonObject.device)
                    {
                        // Access channel and id
                        int channel = device.channel;
                        int id = device.id;

                        // Access node array
                        foreach (var node in device.node)
                        {

                            string name = node.name;
                            string value = node.value;

                            if (value == "nan")
                            {
                                value = "0";
                            }

                            // Add the values to the DataTable
                            MinnotraTable.Rows.Add(channel, id, name, CreatedOn, value);

                            //MinnotraTable = null;

                        }
                        //loginfo.WriteToLog("Data are added in column MeterID :" + id, "ProcessJsonFile", Log.MessageType.Detail);
                    }
                }
                catch (Exception ex)
                {
                    loginfo.WriteToLog("Add a a chanene, ID , Values throw error ex=" + ex, "ProcessJsonFile", Log.MessageType.Detail);
                }
                // Access device array
                bool flage = false;
                loginfo.WriteToLog("Data is inserted tem Minnotra table and loop start", "ProcessJsonFile", Log.MessageType.Detail);
                for (int j = 1; j <= 2; j++)
                {
                    DataRow[] GateWayDetailsValues = GateWayDetailsFull.Tables[0].Select("Channel ='" + j + "' and sn='" + SNID + "'");

                    if (GateWayDetailsValues.Count() > 0)
                    {
                        DataSet ds = null;
                        BLL_Login localresult = new BLL_Login(GateWayDetailsValues[0].ItemArray[11].ToString(), j);
                        int datacount = MinnotraTable.Select("Channel ='" + j + "'").Count();
                        if(datacount > 0)
                        {
                            DataRow[] MeterValues = MinnotraTable.Select("Channel ='" + j + "'");

                            loginfo.WriteToLog("Db name :" + GateWayDetailsValues[0].ItemArray[11].ToString() + " ID :" + j, "ProcessJsonFile", Log.MessageType.Detail);

                            DataSet dataSet1 = localresult.InsertDataMinHistorical(MeterValues.CopyToDataTable(), SNID);

                            loginfo.WriteToLog("Data is inserted in " + GateWayDetailsValues[0].ItemArray[11].ToString(), "ProcessJsonFile", Log.MessageType.Detail);

                            flage = true;
                        }
                        else
                        {
                            loginfo.WriteToLog("Db name :" + GateWayDetailsValues[0].ItemArray[11].ToString()  +  "Data are not available in json file This ChannelID : "+j, "ProcessJsonFile", Log.MessageType.Detail);
                        }

                    }



                }

                MinnotraTable.Clear();

                if (flage == true)
                {
                    // Move the file to the completed folder
                    MoveFileToCompletedFolder(filePath);
                }
                else
                {
                    loginfo.WriteToLog("Flage status false Json file not moved to completed folder", "ProcessJsonFile", Log.MessageType.Detail);
                }
            }
            catch (Exception ex)
            {
                loginfo.WriteToLog("Error processing file method name ProcessJsonFile ", "ProcessJsonFile", Log.MessageType.Detail);

                loginfo.WriteToLog(ex.Message, "", Log.MessageType.Detail);
            }
        }

        private void MoveFileToCompletedFolder(string filePath)
        {
            try
            {
                // Specify the completed folder path
                string completedFolderPath = Path.Combine(Path.GetDirectoryName(filePath), "Completed");

                // Create the completed folder if it doesn't exist
                if (!Directory.Exists(completedFolderPath))
                {
                    Directory.CreateDirectory(completedFolderPath);
                }

                // Get the file name
                string fileName = Path.GetFileName(filePath);

                // Move the file to the completed folder
                string destinationPath = Path.Combine(completedFolderPath, fileName);
                File.Move(filePath, destinationPath);

                loginfo.WriteToLog("File moved to completed folder name :" + filePath, "MoveFileToCompletedFolder", Log.MessageType.Detail);
            }
            catch (Exception ex)
            {
                loginfo.WriteToLog("Error moving file to completed folder Method name MoveFileToCompletedFolder ex=" + ex, "MoveFileToCompletedFolder", Log.MessageType.Detail);
            }
        }


        public void deletejsonfile()
        {
            try
            {
                // Get today's date
                DateTime today = DateTime.Today;

                // Check if the method has already been executed today
                if (today != lastExecutionDate)
                {
                    // Use a lock to ensure thread safety
                    lock (lockObject)
                    {
                        // Check again inside the lock to prevent race conditions
                        if (today != lastExecutionDate)
                        {
                            BLL_Login bLL_ = new BLL_Login("", 0);

                            int ServiceNo = 1;
                            DataSet GateWayDetails = bLL_.GetjsonStorageGateways(ServiceNo);

                            DataTable dataTable = GateWayDetails.Tables[0];

                            for (int i = 0; i < dataTable.Rows.Count; i++)
                            {
                                string SNID = dataTable.Rows[i]["sn"].ToString();
                                string directoryPath = FolderPath + SNID + "\\" + "Completed";

                                string[] existingFiles = Directory.GetFiles(directoryPath, "*.json");



                                foreach (string filePath in existingFiles)
                                {
                                    
                                    FileInfo fileInfo = new FileInfo(filePath);
                                    DateTime ModifiedDatetime = fileInfo.LastWriteTime;
                                    DateTime ModifiedDateDateOnly = ModifiedDatetime.Date;
                                    DateTime currentDatetime = DateTime.Now;
                                    DateTime currentDateOnly = currentDatetime.Date;

                                    DateTime date30DaysAgo = currentDateOnly.AddDays(-30);

                                    if (date30DaysAgo > ModifiedDateDateOnly)
                                    {
                                        File.Delete(filePath);
                                    }


                                }

                                loginfo.WriteToLog("Deleted folder Sn Numbers " + SNID, "", Log.MessageType.Detail);
                            }
                            lastExecutionDate = today;
                            loginfo.WriteToLog("Delete Method was Executed ", "", Log.MessageType.Detail);
                        }
                    }
                }
            }
            catch
            {
                loginfo.WriteToLog("Delete Method was Not Executed ", "", Log.MessageType.Detail);
            }


        }


    }
}
