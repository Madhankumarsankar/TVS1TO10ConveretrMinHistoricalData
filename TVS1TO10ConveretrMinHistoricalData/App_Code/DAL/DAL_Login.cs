using System;
using System.Data;
using System.Configuration;
/// <summary>
/// Summary description for DAL_LoginNicxs_InsertDate
/// </summary>
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;

namespace DAL
{/// 

    public class DAL_Login
    {
        string Connection;

        #region Properties
        //public static DataAccessLayer dataAccess;
        SqlDatabase sqlCon;
        #endregion
        public DAL_Login(string DBID, int channelID)
        {
            // 
            // TODO: Add constructor logic here
            //

            try
            {
                string conString = GetConnectionString(DBID, channelID);

                Connection = conString;

                sqlCon = new SqlDatabase(conString);
            }
            catch (Exception err)
            {
                throw;
            }
        }
        private static string GetConnectionString(string DBID, int channelID)
        {

            try
            {
                
                if (DBID == "TVSCN1" && channelID == 2)
                {
                    return ConfigurationManager.AppSettings["ConnectionString1"].ToString();
                }
                else if (DBID == "TVSCN1B" && channelID == 1)
                {
                    return ConfigurationManager.AppSettings["ConnectionString1B"].ToString();
                }
                else if (DBID == "TVSCN2" && channelID == 1)
                {
                    return ConfigurationManager.AppSettings["ConnectionString2"].ToString();
                }
                else if (DBID == "TVSCN2B" && channelID == 2)
                {
                    return ConfigurationManager.AppSettings["ConnectionString2B"].ToString();
                }
                else if (DBID == "TVSCN3" && channelID == 1)
                {
                    return ConfigurationManager.AppSettings["ConnectionString3"].ToString();
                }
                else if (DBID == "TVSCN3B" && channelID == 2)
                {
                    return ConfigurationManager.AppSettings["ConnectionString3B"].ToString();
                }
                else if (DBID == "TVSCN4" && channelID == 1)
                {
                    return ConfigurationManager.AppSettings["ConnectionString4"].ToString();
                }
                else if (DBID == "TVSCN4B" && channelID == 2)
                {
                    return ConfigurationManager.AppSettings["ConnectionString4B"].ToString();
                }
                else if (DBID == "TVSCN5" && channelID == 1)
                {
                    return ConfigurationManager.AppSettings["ConnectionString5"].ToString();
                }
                else if (DBID == "TVSCN5B" && channelID == 2)
                {
                    return ConfigurationManager.AppSettings["ConnectionString5B"].ToString();
                }
                else if (DBID == "TVSCN6" && channelID == 1)
                {
                    return ConfigurationManager.AppSettings["ConnectionString6"].ToString();
                }
                else if (DBID == "TVSCN6B" && channelID == 2)
                {
                    return ConfigurationManager.AppSettings["ConnectionString6B"].ToString();
                }
                else if (DBID == "TVSCN7" && channelID == 1)
                {
                    return ConfigurationManager.AppSettings["ConnectionString7"].ToString();
                }
                else if (DBID == "TVSCN7B" && channelID == 2)
                {
                    return ConfigurationManager.AppSettings["ConnectionString7B"].ToString();
                }
                else if (DBID == "TVSCN8" && channelID == 1)
                {
                    return ConfigurationManager.AppSettings["ConnectionString8"].ToString();
                }
                else if (DBID == "TVSCN8B" && channelID == 2)
                {
                    return ConfigurationManager.AppSettings["ConnectionString8B"].ToString();
                }
                else if (DBID == "TVSCN9" && channelID == 1)
                {
                    return ConfigurationManager.AppSettings["ConnectionString9"].ToString();
                }
                else if (DBID == "TVSCN9B" && channelID == 2)
                {
                    return ConfigurationManager.AppSettings["ConnectionString9B"].ToString();
                }
                else if (DBID == "TVSCN10" && channelID == 1)
                {
                    return ConfigurationManager.AppSettings["ConnectionString10"].ToString();
                }
                else if (DBID == "TVSCN10B" && channelID == 2)
                {
                    return ConfigurationManager.AppSettings["ConnectionString10B"].ToString();
                }
                else
                {
                    return ConfigurationManager.AppSettings["ConnectionString"].ToString();
                }

            }
            catch (Exception err)
            {
                throw;
            }
        }
        //------------------------------------------------------------------------------------------------------------------

        public bool EmployeeCheckDetails_Insert(int EmployeeID, DateTime CheckDate, DateTime CheckTime, string CheckType)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("EmployeeCheckDetails_Insert");
                sqlCon.AddInParameter(DbCom, "@EmployeeID", DbType.Int32, EmployeeID);
                sqlCon.AddInParameter(DbCom, "@CheckDate", DbType.DateTime, CheckDate);
                sqlCon.AddInParameter(DbCom, "@CheckTime", DbType.DateTime, CheckTime);
                sqlCon.AddInParameter(DbCom, "@CheckType", DbType.String, CheckType);
                if (sqlCon.ExecuteNonQuery(DbCom) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet EmployeeCheckDetails_Getpassword(int EmployeeID)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("EmployeeCheckDetails_Getpassword");
                sqlCon.AddInParameter(DbCom, "@EmployeeID", DbType.Int32, EmployeeID);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public bool EmployeeDetails_Updatepass(int EmployeeID, string Password)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("EmployeeDetails_Updatepass");
                sqlCon.AddInParameter(DbCom, "@EmployeeID", DbType.Int32, EmployeeID);
                sqlCon.AddInParameter(DbCom, "@Password", DbType.String, Password);
                if (sqlCon.ExecuteNonQuery(DbCom) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet EmployeeCheckDetails_Bindgrid(int EmployeeID, DateTime Todate, DateTime FromDate)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("EmployeeCheckDetails_Bindgrid");
                sqlCon.AddInParameter(DbCom, "@EmployeeID", DbType.Int32, EmployeeID);
                sqlCon.AddInParameter(DbCom, "@Todate", DbType.Date, Todate);
                sqlCon.AddInParameter(DbCom, "@FromDate", DbType.Date, FromDate);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataSet EmployeeDetails_GetDetails()
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("EmployeeDetails_GetDetails");
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataSet GetEmployeeName(int EmployeeID, string GetType, string Department)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("GetEmployeeName");
                sqlCon.AddInParameter(DbCom, "@EmployeeID", DbType.Int32, EmployeeID);
                sqlCon.AddInParameter(DbCom, "@GetType", DbType.String, GetType);
                sqlCon.AddInParameter(DbCom, "@Department", DbType.String, Department);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public DataSet TM_Telegram_Requests_Insert(int MessageID, int RequestTelegramID, string ClientName, string RequestType, string RequestMessage, DateTime RequestDate, DateTime RequestTime, string Response)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("TM_Telegram_Requests_Insert");
                sqlCon.AddInParameter(DbCom, "@MessageID", DbType.Int32, MessageID);
                sqlCon.AddInParameter(DbCom, "@RequestTelegramID", DbType.String, RequestTelegramID);
                sqlCon.AddInParameter(DbCom, "@ClientName", DbType.String, ClientName);
                sqlCon.AddInParameter(DbCom, "@RequestType", DbType.String, RequestType);
                sqlCon.AddInParameter(DbCom, "@RequestMessage", DbType.String, RequestMessage);
                sqlCon.AddInParameter(DbCom, "@RequestDate", DbType.Date, RequestDate);
                sqlCon.AddInParameter(DbCom, "@RequestTime", DbType.DateTime, RequestTime);
                sqlCon.AddInParameter(DbCom, "@Response", DbType.String, Response);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public DataSet TM_Telegram_Requests_Check()
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("TM_Telegram_Requests_Check");
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public bool TM_Telegram_Requests_Update(int ReqautoID)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("TM_Telegram_Requests_Update");
                sqlCon.AddInParameter(DbCom, "@METERIDS", DbType.Int32, ReqautoID);
                if (sqlCon.ExecuteNonQuery(DbCom) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet TM_MEaterValues(int METERIDS)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("TM_MEaterValues");
                sqlCon.AddInParameter(DbCom, "@METERIDS", DbType.Int32, METERIDS);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public DataSet Telegram_Members_ID(long PhoneNumber)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Telegram_Members_ID");
                sqlCon.AddInParameter(DbCom, "@PhoneNumber", DbType.Int64, PhoneNumber);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public bool Telegram_Members_Insert(string Name, long PhoneNumber, string TelegramID)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Telegram_Members_Insert");
                sqlCon.AddInParameter(DbCom, "@Name", DbType.String, Name);
                sqlCon.AddInParameter(DbCom, "@PhoneNumber", DbType.Int64, PhoneNumber);
                sqlCon.AddInParameter(DbCom, "@TelegramID", DbType.String, TelegramID);
                if (sqlCon.ExecuteNonQuery(DbCom) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet TM_KWHConsumption(DateTime CurrentDate, int MeterID, int Hours)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("TM_KWHConsumption");
                sqlCon.AddInParameter(DbCom, "@CurrentDate", DbType.DateTime, CurrentDate);
                sqlCon.AddInParameter(DbCom, "@MeterID", DbType.Int32, MeterID);
                sqlCon.AddInParameter(DbCom, "@Hours", DbType.Int32, Hours);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public DataSet TM_NIcxsReport(DateTime CurrentDate, DateTime FromDate)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("TM_NIcxsReport");
                sqlCon.AddInParameter(DbCom, "@CurrentDate", DbType.DateTime, CurrentDate);
                sqlCon.AddInParameter(DbCom, "@FromDate", DbType.DateTime, FromDate);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataSet TM_MeterStatus(string sitename, DateTime From, DateTime To)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("TM_MeterStatus");
                sqlCon.AddInParameter(DbCom, "@sitename", DbType.String, sitename);
                sqlCon.AddInParameter(DbCom, "@From", DbType.DateTime, From);
                sqlCon.AddInParameter(DbCom, "@To", DbType.DateTime, To);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataSet Telegram_Members_Check(string ChatID)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Telegram_Members_Check");
                sqlCon.AddInParameter(DbCom, "@ChatID", DbType.String, ChatID);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public DataSet TM_DailyKWHConsumption(DateTime CurrentDate)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("TM_DailyKWHConsumption");
                sqlCon.AddInParameter(DbCom, "@CurrentDate", DbType.DateTime, CurrentDate);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        public DataSet TM_DailyAlertsCheck()
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("TM_DailyAlertsCheck");
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool TM_DailyAlertsInsert(DateTime DailyAlerts)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("TM_DailyAlertsInsert");
                sqlCon.AddInParameter(DbCom, "@DailyAlerts", DbType.DateTime, DailyAlerts);
                if (sqlCon.ExecuteNonQuery(DbCom) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet TM_RequestQuery_Check()
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("TM_RequestQuery_Check");
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }



        public bool TM_RequestQuery_Update(int AutoID)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("TM_RequestQuery_Update");
                sqlCon.AddInParameter(DbCom, "@AutoID", DbType.Int32, AutoID);
                if (sqlCon.ExecuteNonQuery(DbCom) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //        public bool Nicxs_InsertDate(string SITENAME, int METERID, Single V_R, Single V_Y, Single V_B, Single F, Single V_RY, Single V_YB, Single V_BR, Single V_LLAvg, Single I_R, Single I_Y, Single I_B, Single IAVG, Single Vunb, Single Iunb,
        //            Single KWT, Single KVAT, Single KVART, Single PFT, Single PF_R, Single PF_Y, Single PF_B, Single KW_R, Single KW_Y, Single KW_B, Single KVA_R, Single KVA_Y, Single KVA_B, Single KVAR_R, Single KVAR_Y,
        //Single KVAR_B, Single KWD, Single KVAD, Single SpRh, Single OperatingHoursreal, Single PowersupplyInteruption, Single KWHTotal, Single kWhImport, Single KWHEXPORT, Single kVAh, Single kVArhTotal, Single kVArhinductivereal, Single KVARHCAPACITIVE, DateTime CREATEDON)
        //        {
        //            try
        //            {
        //                DbCommand DbCom = sqlCon.GetStoredProcCommand("Nicxs_InsertDate");
        //                sqlCon.AddInParameter(DbCom, "@SITENAME", DbType.String, SITENAME);
        //                sqlCon.AddInParameter(DbCom, "@METERID", DbType.Int32, METERID);
        //                sqlCon.AddInParameter(DbCom, "@V_R", DbType.Single, V_R);
        //                sqlCon.AddInParameter(DbCom, "@V_Y", DbType.Single, V_Y);
        //                sqlCon.AddInParameter(DbCom, "@V_B", DbType.Single, V_B);
        //                sqlCon.AddInParameter(DbCom, "@F", DbType.Single, F);
        //                sqlCon.AddInParameter(DbCom, "@V_RY", DbType.Single, V_RY);
        //                sqlCon.AddInParameter(DbCom, "@V_YB", DbType.Single, V_YB);
        //                sqlCon.AddInParameter(DbCom, "@V_BR", DbType.Single, V_BR);
        //                sqlCon.AddInParameter(DbCom, "@V_LLAvg", DbType.Single, V_LLAvg);
        //                sqlCon.AddInParameter(DbCom, "@I_R", DbType.Single, I_R);
        //                sqlCon.AddInParameter(DbCom, "@I_Y", DbType.Single, I_Y);
        //                sqlCon.AddInParameter(DbCom, "@I_B", DbType.Single, I_B);
        //                sqlCon.AddInParameter(DbCom, "@IAVG", DbType.Single, IAVG);
        //                sqlCon.AddInParameter(DbCom, "@Vunb", DbType.Single, Vunb);
        //                sqlCon.AddInParameter(DbCom, "@Iunb", DbType.Single, Iunb);

        //                sqlCon.AddInParameter(DbCom, "@KWT", DbType.Single, KWT);
        //                sqlCon.AddInParameter(DbCom, "@KVAT", DbType.Single, KVAT);
        //                sqlCon.AddInParameter(DbCom, "@KVART", DbType.Single, KVART);
        //                sqlCon.AddInParameter(DbCom, "@PFT", DbType.Single, PFT);
        //                sqlCon.AddInParameter(DbCom, "@PF_R", DbType.Single, PF_R);
        //                sqlCon.AddInParameter(DbCom, "@PF_Y", DbType.Single, PF_Y);
        //                sqlCon.AddInParameter(DbCom, "@PF_B", DbType.Single, PF_B);
        //                sqlCon.AddInParameter(DbCom, "@KW_R", DbType.Single, KW_R);
        //                sqlCon.AddInParameter(DbCom, "@KW_Y", DbType.Single, KW_Y);
        //                sqlCon.AddInParameter(DbCom, "@KW_B", DbType.Single, KW_B);
        //                sqlCon.AddInParameter(DbCom, "@KVA_R", DbType.Single, KVA_R);
        //                sqlCon.AddInParameter(DbCom, "@KVA_Y", DbType.Single, KVA_Y);
        //                sqlCon.AddInParameter(DbCom, "@KVA_B", DbType.Single, KVA_B);
        //                sqlCon.AddInParameter(DbCom, "@KVAR_R", DbType.Single, KVAR_R);


        //                sqlCon.AddInParameter(DbCom, "@KVAR_Y", DbType.Single, KVAR_Y);
        //                sqlCon.AddInParameter(DbCom, "@KVAR_B", DbType.Single, KVAR_B);
        //                sqlCon.AddInParameter(DbCom, "@KWD", DbType.Single, KWD);
        //                sqlCon.AddInParameter(DbCom, "@KVAD", DbType.Single, KVAD);
        //                sqlCon.AddInParameter(DbCom, "@SpRh", DbType.Single, SpRh);
        //                sqlCon.AddInParameter(DbCom, "@OperatingHoursreal", DbType.Single, OperatingHoursreal);

        //                sqlCon.AddInParameter(DbCom, "@PowersupplyInteruption", DbType.Single, PowersupplyInteruption);
        //                sqlCon.AddInParameter(DbCom, "@KWHTotal", DbType.Single, KWHTotal);
        //                sqlCon.AddInParameter(DbCom, "@kWhImport", DbType.Single, kWhImport);
        //                sqlCon.AddInParameter(DbCom, "@KWHEXPORT", DbType.Single, KWHEXPORT);
        //                sqlCon.AddInParameter(DbCom, "@kVAh", DbType.Single, kVAh);
        //                sqlCon.AddInParameter(DbCom, "@kVArhTotal", DbType.Single, kVArhTotal);
        //                sqlCon.AddInParameter(DbCom, "@kVArhinductivereal", DbType.Single, kVArhinductivereal);
        //                sqlCon.AddInParameter(DbCom, "@KVARHCAPACITIVE", DbType.Single, KVARHCAPACITIVE);
        //                sqlCon.AddInParameter(DbCom, "@CREATEDON", DbType.DateTime, CREATEDON);
        //                if (sqlCon.ExecuteNonQuery(DbCom) > 0)
        //                {
        //                    return true;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //        }

        public bool Nicxs_Insert_ShiftMeters_Date(string SITENAME, int METERID, Single V_R, Single V_Y, Single V_B, Single F, Single I_R, Single I_Y, Single I_B, Single IAVG,
      Single KWT, Single KVAT, Single KVART, Single PFT, Single PF_R, Single PF_Y, Single PF_B, Single KWHTotal, Single kWhImport, Single KWHEXPORT, Single kVAh, DateTime CREATEDON)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Nicxs_Insert_ShiftMeters_Date");
                sqlCon.AddInParameter(DbCom, "@SITENAME", DbType.String, SITENAME);
                sqlCon.AddInParameter(DbCom, "@METERID", DbType.Int32, METERID);
                sqlCon.AddInParameter(DbCom, "@V_R", DbType.Single, V_R);
                sqlCon.AddInParameter(DbCom, "@V_Y", DbType.Single, V_Y);
                sqlCon.AddInParameter(DbCom, "@V_B", DbType.Single, V_B);
                sqlCon.AddInParameter(DbCom, "@F", DbType.Single, F);
                sqlCon.AddInParameter(DbCom, "@I_R", DbType.Single, I_R);
                sqlCon.AddInParameter(DbCom, "@I_Y", DbType.Single, I_Y);
                sqlCon.AddInParameter(DbCom, "@I_B", DbType.Single, I_B);
                sqlCon.AddInParameter(DbCom, "@IAVG", DbType.Single, IAVG);

                sqlCon.AddInParameter(DbCom, "@KWT", DbType.Single, KWT);
                sqlCon.AddInParameter(DbCom, "@KVAT", DbType.Single, KVAT);
                sqlCon.AddInParameter(DbCom, "@KVART", DbType.Single, KVART);
                sqlCon.AddInParameter(DbCom, "@PFT", DbType.Single, PFT);
                sqlCon.AddInParameter(DbCom, "@PF_R", DbType.Single, PF_R);
                sqlCon.AddInParameter(DbCom, "@PF_Y", DbType.Single, PF_Y);
                sqlCon.AddInParameter(DbCom, "@PF_B", DbType.Single, PF_B);
                sqlCon.AddInParameter(DbCom, "@KWHTotal", DbType.Single, KWHTotal);
                sqlCon.AddInParameter(DbCom, "@kWhImport", DbType.Single, kWhImport);
                sqlCon.AddInParameter(DbCom, "@KWHEXPORT", DbType.Single, KWHEXPORT);
                sqlCon.AddInParameter(DbCom, "@kVAh", DbType.Single, kVAh);
                sqlCon.AddInParameter(DbCom, "@CREATEDON", DbType.DateTime, CREATEDON);
                if (sqlCon.ExecuteNonQuery(DbCom) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet COD_List_Devices_Lan(int METERID, int DataloggerID)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("COD_List_Devices_Lan");
                sqlCon.AddInParameter(DbCom, "@METERID", DbType.Int32, METERID);
                sqlCon.AddInParameter(DbCom, "@DataloggerID", DbType.Int32, DataloggerID);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataSet COD_Meter_List_Lan()
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("COD_Meter_List_Lan");
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        public DataSet COD_ResponseMeterCheck_Lan(int MeterID, int DataloggerID)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("COD_ResponseMeterCheck_Lan");
                sqlCon.AddInParameter(DbCom, "@DataloggerID", DbType.Int32, DataloggerID);
                sqlCon.AddInParameter(DbCom, "@MeterID", DbType.Int32, MeterID);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }



        //        public bool ConzerveEM6400_InsertDate(string SITENAME, int METERID, Single V_R, Single V_Y, Single V_B, Single F, Single V_RY, Single V_YB, Single V_BR, Single V_LLAvg, Single I_R, Single I_Y, Single I_B, Single IAVG,
        //         Single KWT, Single KVAT, Single KVART, Single PFT, Single PF_R, Single PF_Y, Single PF_B, Single KW_R, Single KW_Y, Single KW_B, Single KVA_R, Single KVA_Y, Single KVA_B, Single KVAR_R, Single KVAR_Y,
        //Single KVAR_B, Single KWHTotal, Single kVAh, Single kVArhinductivereal, Single KVARHCAPACITIVE, DateTime CREATEDON)
        //        {
        //            try
        //            {
        //                DbCommand DbCom = sqlCon.GetStoredProcCommand("ConzerveEM6400_InsertDate");
        //                sqlCon.AddInParameter(DbCom, "@SITENAME", DbType.String, SITENAME);
        //                sqlCon.AddInParameter(DbCom, "@METERID", DbType.Int32, METERID);
        //                sqlCon.AddInParameter(DbCom, "@V_R", DbType.Single, V_R);
        //                sqlCon.AddInParameter(DbCom, "@V_Y", DbType.Single, V_Y);
        //                sqlCon.AddInParameter(DbCom, "@V_B", DbType.Single, V_B);
        //                sqlCon.AddInParameter(DbCom, "@F", DbType.Single, F);
        //                sqlCon.AddInParameter(DbCom, "@V_RY", DbType.Single, V_RY);
        //                sqlCon.AddInParameter(DbCom, "@V_YB", DbType.Single, V_YB);
        //                sqlCon.AddInParameter(DbCom, "@V_BR", DbType.Single, V_BR);
        //                sqlCon.AddInParameter(DbCom, "@V_LLAvg", DbType.Single, V_LLAvg);
        //                sqlCon.AddInParameter(DbCom, "@I_R", DbType.Single, I_R);
        //                sqlCon.AddInParameter(DbCom, "@I_Y", DbType.Single, I_Y);
        //                sqlCon.AddInParameter(DbCom, "@I_B", DbType.Single, I_B);
        //                sqlCon.AddInParameter(DbCom, "@IAVG", DbType.Single, IAVG);
        //                //sqlCon.AddInParameter(DbCom, "@Vunb", DbType.Single, Vunb);
        //                //sqlCon.AddInParameter(DbCom, "@Iunb", DbType.Single, Iunb);

        //                sqlCon.AddInParameter(DbCom, "@KWT", DbType.Single, KWT);
        //                sqlCon.AddInParameter(DbCom, "@KVAT", DbType.Single, KVAT);
        //                sqlCon.AddInParameter(DbCom, "@KVART", DbType.Single, KVART);
        //                sqlCon.AddInParameter(DbCom, "@PFT", DbType.Single, PFT);
        //                sqlCon.AddInParameter(DbCom, "@PF_R", DbType.Single, PF_R);
        //                sqlCon.AddInParameter(DbCom, "@PF_Y", DbType.Single, PF_Y);
        //                sqlCon.AddInParameter(DbCom, "@PF_B", DbType.Single, PF_B);
        //                sqlCon.AddInParameter(DbCom, "@KW_R", DbType.Single, KW_R);
        //                sqlCon.AddInParameter(DbCom, "@KW_Y", DbType.Single, KW_Y);
        //                sqlCon.AddInParameter(DbCom, "@KW_B", DbType.Single, KW_B);
        //                sqlCon.AddInParameter(DbCom, "@KVA_R", DbType.Single, KVA_R);
        //                sqlCon.AddInParameter(DbCom, "@KVA_Y", DbType.Single, KVA_Y);
        //                sqlCon.AddInParameter(DbCom, "@KVA_B", DbType.Single, KVA_B);
        //                sqlCon.AddInParameter(DbCom, "@KVAR_R", DbType.Single, KVAR_R);


        //                sqlCon.AddInParameter(DbCom, "@KVAR_Y", DbType.Single, KVAR_Y);
        //                sqlCon.AddInParameter(DbCom, "@KVAR_B", DbType.Single, KVAR_B);
        //                //sqlCon.AddInParameter(DbCom, "@KWD", DbType.Single, KWD);
        //                //sqlCon.AddInParameter(DbCom, "@KVAD", DbType.Single, KVAD);
        //                //sqlCon.AddInParameter(DbCom, "@SpRh", DbType.Single, SpRh);
        //                //sqlCon.AddInParameter(DbCom, "@OperatingHoursreal", DbType.Single, OperatingHoursreal);

        //                //sqlCon.AddInParameter(DbCom, "@PowersupplyInteruption", DbType.Single, PowersupplyInteruption);
        //                sqlCon.AddInParameter(DbCom, "@KWHTotal", DbType.Single, KWHTotal);
        //                //sqlCon.AddInParameter(DbCom, "@kWhImport", DbType.Single, kWhImport);
        //                //sqlCon.AddInParameter(DbCom, "@KWHEXPORT", DbType.Single, KWHEXPORT);
        //                sqlCon.AddInParameter(DbCom, "@kVAh", DbType.Single, kVAh);
        //                //sqlCon.AddInParameter(DbCom, "@kVArhTotal", DbType.Single, kVArhTotal);
        //                sqlCon.AddInParameter(DbCom, "@kVArhinductivereal", DbType.Single, kVArhinductivereal);
        //                sqlCon.AddInParameter(DbCom, "@KVARHCAPACITIVE", DbType.Single, KVARHCAPACITIVE);
        //                sqlCon.AddInParameter(DbCom, "@CREATEDON", DbType.DateTime, CREATEDON);
        //                //sqlCon.AddInParameter(DbCom, "@RecordID", DbType.Int32, RecordID);
        //                //sqlCon.AddInParameter(DbCom, "@Zone_Details", DbType.String, Zone_Details);
        //                //sqlCon.AddInParameter(DbCom, "@DataloggerID", DbType.String, DataloggerID);


        //                if (sqlCon.ExecuteNonQuery(DbCom) > 0)
        //                {
        //                    return true;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //        }

        public bool Nicxs_InsertDate(string SITENAME, int METERID, Single V_R, Single V_Y, Single V_B, Single F, Single V_RY, Single V_YB, Single V_BR, Single V_LLAvg, Single I_R, Single I_Y, Single I_B, Single IAVG, Single Vunb, Single Iunb,
           Single KWT, Single KVAT, Single KVART, Single PFT, Single PF_R, Single PF_Y, Single PF_B, Single KW_R, Single KW_Y, Single KW_B, Single KVA_R, Single KVA_Y, Single KVA_B, Single KVAR_R, Single KVAR_Y,
Single KVAR_B, Single KWD, Single KVAD, Single SpRh, Single OperatingHoursreal, Single PowersupplyInteruption, Single KWHTotal, Single kWhImport, Single KWHEXPORT, Single kVAh, Single kVArhTotal, Single kVArhinductivereal, Single KVARHCAPACITIVE, DateTime CREATEDON, int RecordID, string Zone_Details, int DataloggerID)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Nicxs_InsertDate");
                sqlCon.AddInParameter(DbCom, "@SITENAME", DbType.String, SITENAME);
                sqlCon.AddInParameter(DbCom, "@METERID", DbType.Int32, METERID);
                sqlCon.AddInParameter(DbCom, "@V_R", DbType.Single, V_R);
                sqlCon.AddInParameter(DbCom, "@V_Y", DbType.Single, V_Y);
                sqlCon.AddInParameter(DbCom, "@V_B", DbType.Single, V_B);
                sqlCon.AddInParameter(DbCom, "@F", DbType.Single, F);
                sqlCon.AddInParameter(DbCom, "@V_RY", DbType.Single, V_RY);
                sqlCon.AddInParameter(DbCom, "@V_YB", DbType.Single, V_YB);
                sqlCon.AddInParameter(DbCom, "@V_BR", DbType.Single, V_BR);
                sqlCon.AddInParameter(DbCom, "@V_LLAvg", DbType.Single, V_LLAvg);
                sqlCon.AddInParameter(DbCom, "@I_R", DbType.Single, I_R);
                sqlCon.AddInParameter(DbCom, "@I_Y", DbType.Single, I_Y);
                sqlCon.AddInParameter(DbCom, "@I_B", DbType.Single, I_B);
                sqlCon.AddInParameter(DbCom, "@IAVG", DbType.Single, IAVG);
                sqlCon.AddInParameter(DbCom, "@Vunb", DbType.Single, Vunb);
                sqlCon.AddInParameter(DbCom, "@Iunb", DbType.Single, Iunb);

                sqlCon.AddInParameter(DbCom, "@KWT", DbType.Single, KWT);
                sqlCon.AddInParameter(DbCom, "@KVAT", DbType.Single, KVAT);
                sqlCon.AddInParameter(DbCom, "@KVART", DbType.Single, KVART);
                sqlCon.AddInParameter(DbCom, "@PFT", DbType.Single, PFT);
                sqlCon.AddInParameter(DbCom, "@PF_R", DbType.Single, PF_R);
                sqlCon.AddInParameter(DbCom, "@PF_Y", DbType.Single, PF_Y);
                sqlCon.AddInParameter(DbCom, "@PF_B", DbType.Single, PF_B);
                sqlCon.AddInParameter(DbCom, "@KW_R", DbType.Single, KW_R);
                sqlCon.AddInParameter(DbCom, "@KW_Y", DbType.Single, KW_Y);
                sqlCon.AddInParameter(DbCom, "@KW_B", DbType.Single, KW_B);
                sqlCon.AddInParameter(DbCom, "@KVA_R", DbType.Single, KVA_R);
                sqlCon.AddInParameter(DbCom, "@KVA_Y", DbType.Single, KVA_Y);
                sqlCon.AddInParameter(DbCom, "@KVA_B", DbType.Single, KVA_B);
                sqlCon.AddInParameter(DbCom, "@KVAR_R", DbType.Single, KVAR_R);


                sqlCon.AddInParameter(DbCom, "@KVAR_Y", DbType.Single, KVAR_Y);
                sqlCon.AddInParameter(DbCom, "@KVAR_B", DbType.Single, KVAR_B);
                sqlCon.AddInParameter(DbCom, "@KWD", DbType.Single, KWD);
                sqlCon.AddInParameter(DbCom, "@KVAD", DbType.Single, KVAD);
                sqlCon.AddInParameter(DbCom, "@SpRh", DbType.Single, SpRh);
                sqlCon.AddInParameter(DbCom, "@OperatingHoursreal", DbType.Single, OperatingHoursreal);

                sqlCon.AddInParameter(DbCom, "@PowersupplyInteruption", DbType.Single, PowersupplyInteruption);
                sqlCon.AddInParameter(DbCom, "@KWHTotal", DbType.Single, KWHTotal);
                sqlCon.AddInParameter(DbCom, "@kWhImport", DbType.Single, kWhImport);
                sqlCon.AddInParameter(DbCom, "@KWHEXPORT", DbType.Single, KWHEXPORT);
                sqlCon.AddInParameter(DbCom, "@kVAh", DbType.Single, kVAh);
                sqlCon.AddInParameter(DbCom, "@kVArhTotal", DbType.Single, kVArhTotal);
                sqlCon.AddInParameter(DbCom, "@kVArhinductivereal", DbType.Single, kVArhinductivereal);
                sqlCon.AddInParameter(DbCom, "@KVARHCAPACITIVE", DbType.Single, KVARHCAPACITIVE);
                sqlCon.AddInParameter(DbCom, "@CREATEDON", DbType.DateTime, CREATEDON);
                sqlCon.AddInParameter(DbCom, "@RecordID", DbType.Int32, RecordID);
                sqlCon.AddInParameter(DbCom, "@Zone_Details", DbType.String, Zone_Details);
                sqlCon.AddInParameter(DbCom, "@DataloggerID", DbType.String, DataloggerID);


                if (sqlCon.ExecuteNonQuery(DbCom) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ConzerveEM6400_InsertDate1(string SITENAME, int METERID, Single V_R, Single V_Y, Single V_B, Single F, Single V_RY, Single V_YB, Single V_BR, Single V_LLAvg, Single I_R, Single I_Y, Single I_B, Single IAVG,
         Single KWT, Single KVAT, Single KVART, Single PFT, Single PF_R, Single PF_Y, Single PF_B, Single KW_R, Single KW_Y, Single KW_B, Single KVA_R, Single KVA_Y, Single KVA_B, Single KVAR_R, Single KVAR_Y,
Single KVAR_B, Single KWD, Single KVAD, Single OperatingHoursreal, Single PowersupplyInteruption, Single KWHTotal, Single kVAh, Single kVArhinductivereal, Single KVARHCAPACITIVE, DateTime CREATEDON)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("ConzerveEM6400_InsertDate");
                sqlCon.AddInParameter(DbCom, "@SITENAME", DbType.String, SITENAME);
                sqlCon.AddInParameter(DbCom, "@METERID", DbType.Int32, METERID);
                sqlCon.AddInParameter(DbCom, "@V_R", DbType.Single, V_R);
                sqlCon.AddInParameter(DbCom, "@V_Y", DbType.Single, V_Y);
                sqlCon.AddInParameter(DbCom, "@V_B", DbType.Single, V_B);
                sqlCon.AddInParameter(DbCom, "@F", DbType.Single, F);
                sqlCon.AddInParameter(DbCom, "@V_RY", DbType.Single, V_RY);
                sqlCon.AddInParameter(DbCom, "@V_YB", DbType.Single, V_YB);
                sqlCon.AddInParameter(DbCom, "@V_BR", DbType.Single, V_BR);
                sqlCon.AddInParameter(DbCom, "@V_LLAvg", DbType.Single, V_LLAvg);
                sqlCon.AddInParameter(DbCom, "@I_R", DbType.Single, I_R);
                sqlCon.AddInParameter(DbCom, "@I_Y", DbType.Single, I_Y);
                sqlCon.AddInParameter(DbCom, "@I_B", DbType.Single, I_B);
                sqlCon.AddInParameter(DbCom, "@IAVG", DbType.Single, IAVG);
                //sqlCon.AddInParameter(DbCom, "@Vunb", DbType.Single, Vunb);
                //sqlCon.AddInParameter(DbCom, "@Iunb", DbType.Single, Iunb);

                sqlCon.AddInParameter(DbCom, "@KWT", DbType.Single, KWT);
                sqlCon.AddInParameter(DbCom, "@KVAT", DbType.Single, KVAT);
                sqlCon.AddInParameter(DbCom, "@KVART", DbType.Single, KVART);
                sqlCon.AddInParameter(DbCom, "@PFT", DbType.Single, PFT);
                sqlCon.AddInParameter(DbCom, "@PF_R", DbType.Single, PF_R);
                sqlCon.AddInParameter(DbCom, "@PF_Y", DbType.Single, PF_Y);
                sqlCon.AddInParameter(DbCom, "@PF_B", DbType.Single, PF_B);
                sqlCon.AddInParameter(DbCom, "@KW_R", DbType.Single, KW_R);
                sqlCon.AddInParameter(DbCom, "@KW_Y", DbType.Single, KW_Y);
                sqlCon.AddInParameter(DbCom, "@KW_B", DbType.Single, KW_B);
                sqlCon.AddInParameter(DbCom, "@KVA_R", DbType.Single, KVA_R);
                sqlCon.AddInParameter(DbCom, "@KVA_Y", DbType.Single, KVA_Y);
                sqlCon.AddInParameter(DbCom, "@KVA_B", DbType.Single, KVA_B);
                sqlCon.AddInParameter(DbCom, "@KVAR_R", DbType.Single, KVAR_R);


                sqlCon.AddInParameter(DbCom, "@KVAR_Y", DbType.Single, KVAR_Y);
                sqlCon.AddInParameter(DbCom, "@KVAR_B", DbType.Single, KVAR_B);
                sqlCon.AddInParameter(DbCom, "@KWD", DbType.Single, KWD);
                sqlCon.AddInParameter(DbCom, "@KVAD", DbType.Single, KVAD);
                //sqlCon.AddInParameter(DbCom, "@SpRh", DbType.Single, SpRh);
                sqlCon.AddInParameter(DbCom, "@OperatingHoursreal", DbType.Single, OperatingHoursreal);

                sqlCon.AddInParameter(DbCom, "@PowersupplyInteruption", DbType.Single, PowersupplyInteruption);
                sqlCon.AddInParameter(DbCom, "@KWHTotal", DbType.Single, KWHTotal);
                //sqlCon.AddInParameter(DbCom, "@kWhImport", DbType.Single, kWhImport);
                //sqlCon.AddInParameter(DbCom, "@KWHEXPORT", DbType.Single, KWHEXPORT);
                sqlCon.AddInParameter(DbCom, "@kVAh", DbType.Single, kVAh);
                //sqlCon.AddInParameter(DbCom, "@kVArhTotal", DbType.Single, kVArhTotal);
                sqlCon.AddInParameter(DbCom, "@kVArhinductivereal", DbType.Single, kVArhinductivereal);
                sqlCon.AddInParameter(DbCom, "@KVARHCAPACITIVE", DbType.Single, KVARHCAPACITIVE);
                sqlCon.AddInParameter(DbCom, "@CREATEDON", DbType.DateTime, CREATEDON);
                //sqlCon.AddInParameter(DbCom, "@RecordID", DbType.Int32, RecordID);
                //sqlCon.AddInParameter(DbCom, "@Zone_Details", DbType.String, Zone_Details);
                //sqlCon.AddInParameter(DbCom, "@DataloggerID", DbType.String, DataloggerID);


                if (sqlCon.ExecuteNonQuery(DbCom) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public bool ConzerveEM6400_InsertDate(string SITENAME, int METERID, Single V_R, Single V_Y, Single V_B, Single F, Single V_RY, Single V_YB, Single V_BR, Single V_LLAvg, Single I_R, Single I_Y, Single I_B, Single IAVG,
         Single KWT, Single KVAT, Single KVART, Single PFT, Single PF_R, Single PF_Y, Single PF_B, Single KW_R, Single KW_Y, Single KW_B, Single KVA_R, Single KVA_Y, Single KVA_B, Single KVAR_R, Single KVAR_Y,
Single KVAR_B, Single KWD, Single KVAD, Single OperatingHoursreal, Single KWHTotal, Single kVAh, Single kVArhinductivereal, Single KVARHCAPACITIVE, DateTime CREATEDON)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("ConzerveEM6400_InsertDate");
                sqlCon.AddInParameter(DbCom, "@SITENAME", DbType.String, SITENAME);
                sqlCon.AddInParameter(DbCom, "@METERID", DbType.Int32, METERID);
                sqlCon.AddInParameter(DbCom, "@V_R", DbType.Single, V_R);
                sqlCon.AddInParameter(DbCom, "@V_Y", DbType.Single, V_Y);
                sqlCon.AddInParameter(DbCom, "@V_B", DbType.Single, V_B);
                sqlCon.AddInParameter(DbCom, "@F", DbType.Single, F);
                sqlCon.AddInParameter(DbCom, "@V_RY", DbType.Single, V_RY);
                sqlCon.AddInParameter(DbCom, "@V_YB", DbType.Single, V_YB);
                sqlCon.AddInParameter(DbCom, "@V_BR", DbType.Single, V_BR);
                sqlCon.AddInParameter(DbCom, "@V_LLAvg", DbType.Single, V_LLAvg);
                sqlCon.AddInParameter(DbCom, "@I_R", DbType.Single, I_R);
                sqlCon.AddInParameter(DbCom, "@I_Y", DbType.Single, I_Y);
                sqlCon.AddInParameter(DbCom, "@I_B", DbType.Single, I_B);
                sqlCon.AddInParameter(DbCom, "@IAVG", DbType.Single, IAVG);
                //sqlCon.AddInParameter(DbCom, "@Vunb", DbType.Single, Vunb);
                //sqlCon.AddInParameter(DbCom, "@Iunb", DbType.Single, Iunb);

                sqlCon.AddInParameter(DbCom, "@KWT", DbType.Single, KWT);
                sqlCon.AddInParameter(DbCom, "@KVAT", DbType.Single, KVAT);
                sqlCon.AddInParameter(DbCom, "@KVART", DbType.Single, KVART);
                sqlCon.AddInParameter(DbCom, "@PFT", DbType.Single, PFT);
                sqlCon.AddInParameter(DbCom, "@PF_R", DbType.Single, PF_R);
                sqlCon.AddInParameter(DbCom, "@PF_Y", DbType.Single, PF_Y);
                sqlCon.AddInParameter(DbCom, "@PF_B", DbType.Single, PF_B);
                sqlCon.AddInParameter(DbCom, "@KW_R", DbType.Single, KW_R);
                sqlCon.AddInParameter(DbCom, "@KW_Y", DbType.Single, KW_Y);
                sqlCon.AddInParameter(DbCom, "@KW_B", DbType.Single, KW_B);
                sqlCon.AddInParameter(DbCom, "@KVA_R", DbType.Single, KVA_R);
                sqlCon.AddInParameter(DbCom, "@KVA_Y", DbType.Single, KVA_Y);
                sqlCon.AddInParameter(DbCom, "@KVA_B", DbType.Single, KVA_B);
                sqlCon.AddInParameter(DbCom, "@KVAR_R", DbType.Single, KVAR_R);


                sqlCon.AddInParameter(DbCom, "@KVAR_Y", DbType.Single, KVAR_Y);
                sqlCon.AddInParameter(DbCom, "@KVAR_B", DbType.Single, KVAR_B);
                sqlCon.AddInParameter(DbCom, "@KWD", DbType.Single, KWD);
                sqlCon.AddInParameter(DbCom, "@KVAD", DbType.Single, KVAD);
                //sqlCon.AddInParameter(DbCom, "@SpRh", DbType.Single, SpRh);
                sqlCon.AddInParameter(DbCom, "@OperatingHoursreal", DbType.Single, OperatingHoursreal);

                // sqlCon.AddInParameter(DbCom, "@PowersupplyInteruption", DbType.Single, PowersupplyInteruption);
                sqlCon.AddInParameter(DbCom, "@KWHTotal", DbType.Single, KWHTotal);
                //sqlCon.AddInParameter(DbCom, "@kWhImport", DbType.Single, kWhImport);
                //sqlCon.AddInParameter(DbCom, "@KWHEXPORT", DbType.Single, KWHEXPORT);
                sqlCon.AddInParameter(DbCom, "@kVAh", DbType.Single, kVAh);
                //sqlCon.AddInParameter(DbCom, "@kVArhTotal", DbType.Single, kVArhTotal);
                sqlCon.AddInParameter(DbCom, "@kVArhinductivereal", DbType.Single, kVArhinductivereal);
                sqlCon.AddInParameter(DbCom, "@KVARHCAPACITIVE", DbType.Single, KVARHCAPACITIVE);
                sqlCon.AddInParameter(DbCom, "@CREATEDON", DbType.DateTime, CREATEDON);
                //sqlCon.AddInParameter(DbCom, "@RecordID", DbType.Int32, RecordID);
                //sqlCon.AddInParameter(DbCom, "@Zone_Details", DbType.String, Zone_Details);
                //sqlCon.AddInParameter(DbCom, "@DataloggerID", DbType.String, DataloggerID);


                if (sqlCon.ExecuteNonQuery(DbCom) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool PacMeter3200_InsertDate(string SITENAME, int METERID, Single V_R, Single V_Y, Single V_B, Single F, Single V_RY, Single V_YB, Single V_BR, Single V_LLAvg, Single I_R, Single I_Y, Single I_B, Single IAVG,
       Single KWT, Single KVAT, Single KVART, Single PFT, Single PF_R, Single PF_Y, Single PF_B, Single KW_R, Single KW_Y, Single KW_B, Single KVA_R, Single KVA_Y, Single KVA_B, Single KVAR_R, Single KVAR_Y,
Single KVAR_B, Single KWD, Single KVAD, Single OperatingHoursreal, Single KWHTotal, Single KWHEXPORT, Single kVAh, Single kVArhinductivereal, Single KVARHCAPACITIVE, DateTime CREATEDON)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("PacMeter3200_InsertDate");
                sqlCon.AddInParameter(DbCom, "@SITENAME", DbType.String, SITENAME);
                sqlCon.AddInParameter(DbCom, "@METERID", DbType.Int32, METERID);
                sqlCon.AddInParameter(DbCom, "@V_R", DbType.Single, V_R);
                sqlCon.AddInParameter(DbCom, "@V_Y", DbType.Single, V_Y);
                sqlCon.AddInParameter(DbCom, "@V_B", DbType.Single, V_B);
                sqlCon.AddInParameter(DbCom, "@F", DbType.Single, F);
                sqlCon.AddInParameter(DbCom, "@V_RY", DbType.Single, V_RY);
                sqlCon.AddInParameter(DbCom, "@V_YB", DbType.Single, V_YB);
                sqlCon.AddInParameter(DbCom, "@V_BR", DbType.Single, V_BR);
                sqlCon.AddInParameter(DbCom, "@V_LLAvg", DbType.Single, V_LLAvg);
                sqlCon.AddInParameter(DbCom, "@I_R", DbType.Single, I_R);
                sqlCon.AddInParameter(DbCom, "@I_Y", DbType.Single, I_Y);
                sqlCon.AddInParameter(DbCom, "@I_B", DbType.Single, I_B);
                sqlCon.AddInParameter(DbCom, "@IAVG", DbType.Single, IAVG);
                //sqlCon.AddInParameter(DbCom, "@Vunb", DbType.Single, Vunb);
                //sqlCon.AddInParameter(DbCom, "@Iunb", DbType.Single, Iunb);

                sqlCon.AddInParameter(DbCom, "@KWT", DbType.Single, KWT);
                sqlCon.AddInParameter(DbCom, "@KVAT", DbType.Single, KVAT);
                sqlCon.AddInParameter(DbCom, "@KVART", DbType.Single, KVART);
                sqlCon.AddInParameter(DbCom, "@PFT", DbType.Single, PFT);
                sqlCon.AddInParameter(DbCom, "@PF_R", DbType.Single, PF_R);
                sqlCon.AddInParameter(DbCom, "@PF_Y", DbType.Single, PF_Y);
                sqlCon.AddInParameter(DbCom, "@PF_B", DbType.Single, PF_B);
                sqlCon.AddInParameter(DbCom, "@KW_R", DbType.Single, KW_R);
                sqlCon.AddInParameter(DbCom, "@KW_Y", DbType.Single, KW_Y);
                sqlCon.AddInParameter(DbCom, "@KW_B", DbType.Single, KW_B);
                sqlCon.AddInParameter(DbCom, "@KVA_R", DbType.Single, KVA_R);
                sqlCon.AddInParameter(DbCom, "@KVA_Y", DbType.Single, KVA_Y);
                sqlCon.AddInParameter(DbCom, "@KVA_B", DbType.Single, KVA_B);
                sqlCon.AddInParameter(DbCom, "@KVAR_R", DbType.Single, KVAR_R);


                sqlCon.AddInParameter(DbCom, "@KVAR_Y", DbType.Single, KVAR_Y);
                sqlCon.AddInParameter(DbCom, "@KVAR_B", DbType.Single, KVAR_B);
                sqlCon.AddInParameter(DbCom, "@KWD", DbType.Single, KWD);
                sqlCon.AddInParameter(DbCom, "@KVAD", DbType.Single, KVAD);
                //sqlCon.AddInParameter(DbCom, "@SpRh", DbType.Single, SpRh);
                sqlCon.AddInParameter(DbCom, "@OperatingHoursreal", DbType.Single, OperatingHoursreal);

                // sqlCon.AddInParameter(DbCom, "@PowersupplyInteruption", DbType.Single, PowersupplyInteruption);
                sqlCon.AddInParameter(DbCom, "@KWHTotal", DbType.Single, KWHTotal);
                //sqlCon.AddInParameter(DbCom, "@kWhImport", DbType.Single, kWhImport);
                sqlCon.AddInParameter(DbCom, "@KWHEXPORT", DbType.Single, KWHEXPORT);
                sqlCon.AddInParameter(DbCom, "@kVAh", DbType.Single, kVAh);
                //sqlCon.AddInParameter(DbCom, "@kVArhTotal", DbType.Single, kVArhTotal);
                sqlCon.AddInParameter(DbCom, "@kVArhinductivereal", DbType.Single, kVArhinductivereal);
                sqlCon.AddInParameter(DbCom, "@KVARHCAPACITIVE", DbType.Single, KVARHCAPACITIVE);
                sqlCon.AddInParameter(DbCom, "@CREATEDON", DbType.DateTime, CREATEDON);
                //sqlCon.AddInParameter(DbCom, "@RecordID", DbType.Int32, RecordID);
                //sqlCon.AddInParameter(DbCom, "@Zone_Details", DbType.String, Zone_Details);
                //sqlCon.AddInParameter(DbCom, "@DataloggerID", DbType.String, DataloggerID);


                if (sqlCon.ExecuteNonQuery(DbCom) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet COD_List_Devices(int METERID)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("COD_List_Devices");
                sqlCon.AddInParameter(DbCom, "@METERID", DbType.Int32, METERID);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public bool Nicxs_InsertDate6436h(string SITENAME, int METERID, Single V_R, Single V_Y, Single V_B, Single F, Single V_RY, Single V_YB, Single V_BR, Single V_LLAvg, Single I_R, Single I_Y, Single I_B, Single IAVG,
        Single KWT, Single PFT, Single PF_R, Single PF_Y, Single PF_B, Single KW_R, Single KW_Y, Single KW_B, Single KWHTotal, DateTime CREATEDON)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("Nicxs_InsertDate6436h");
                sqlCon.AddInParameter(DbCom, "@SITENAME", DbType.String, SITENAME);
                sqlCon.AddInParameter(DbCom, "@METERID", DbType.Int32, METERID);
                sqlCon.AddInParameter(DbCom, "@V_R", DbType.Single, V_R);
                sqlCon.AddInParameter(DbCom, "@V_Y", DbType.Single, V_Y);
                sqlCon.AddInParameter(DbCom, "@V_B", DbType.Single, V_B);
                sqlCon.AddInParameter(DbCom, "@F", DbType.Single, F);
                sqlCon.AddInParameter(DbCom, "@V_RY", DbType.Single, V_RY);
                sqlCon.AddInParameter(DbCom, "@V_YB", DbType.Single, V_YB);
                sqlCon.AddInParameter(DbCom, "@V_BR", DbType.Single, V_BR);
                sqlCon.AddInParameter(DbCom, "@V_LLAvg", DbType.Single, V_LLAvg);
                sqlCon.AddInParameter(DbCom, "@I_R", DbType.Single, I_R);
                sqlCon.AddInParameter(DbCom, "@I_Y", DbType.Single, I_Y);
                sqlCon.AddInParameter(DbCom, "@I_B", DbType.Single, I_B);
                sqlCon.AddInParameter(DbCom, "@IAVG", DbType.Single, IAVG);

                sqlCon.AddInParameter(DbCom, "@KWT", DbType.Single, KWT);
                sqlCon.AddInParameter(DbCom, "@PFT", DbType.Single, PFT);
                sqlCon.AddInParameter(DbCom, "@PF_R", DbType.Single, PF_R);
                sqlCon.AddInParameter(DbCom, "@PF_Y", DbType.Single, PF_Y);
                sqlCon.AddInParameter(DbCom, "@PF_B", DbType.Single, PF_B);
                sqlCon.AddInParameter(DbCom, "@KW_R", DbType.Single, KW_R);
                sqlCon.AddInParameter(DbCom, "@KW_Y", DbType.Single, KW_Y);
                sqlCon.AddInParameter(DbCom, "@KW_B", DbType.Single, KW_B);
                sqlCon.AddInParameter(DbCom, "@KWHTotal", DbType.Single, KWHTotal);
                sqlCon.AddInParameter(DbCom, "@CREATEDON", DbType.DateTime, CREATEDON);
                if (sqlCon.ExecuteNonQuery(DbCom) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet COD_Meter_List()
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("COD_Meter_List");
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        public bool ElMeasureInsertDate(string SITENAME, int SITEID, int METERID, Single V_R, Single V_Y, Single V_B, Single F, Single V_RY, Single V_YB, Single V_BR, Single V_LLAvg, Single I_R, Single I_Y, Single I_B, Single IAVG,
         Single KWT, Single KVAT, Single KVART, Single PFT, Single PF_R, Single PF_Y, Single PF_B, Single KW_R, Single KW_Y, Single KW_B, Single KVA_R, Single KVA_Y, Single KVA_B, Single KVAR_R, Single KVAR_Y,
Single KVAR_B, Single kWhImport, Single KWHEXPORT, Single kVAh, DateTime CREATEDON)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("ElMeasureInsertDate");
                sqlCon.AddInParameter(DbCom, "@SITENAME", DbType.String, SITENAME);
                sqlCon.AddInParameter(DbCom, "@SITEID", DbType.Int32, SITEID);
                sqlCon.AddInParameter(DbCom, "@METERID", DbType.Int32, METERID);
                sqlCon.AddInParameter(DbCom, "@V_R", DbType.Single, V_R);
                sqlCon.AddInParameter(DbCom, "@V_Y", DbType.Single, V_Y);
                sqlCon.AddInParameter(DbCom, "@V_B", DbType.Single, V_B);
                sqlCon.AddInParameter(DbCom, "@F", DbType.Single, F);
                sqlCon.AddInParameter(DbCom, "@V_RY", DbType.Single, V_RY);
                sqlCon.AddInParameter(DbCom, "@V_YB", DbType.Single, V_YB);
                sqlCon.AddInParameter(DbCom, "@V_BR", DbType.Single, V_BR);
                sqlCon.AddInParameter(DbCom, "@V_LLAvg", DbType.Single, V_LLAvg);
                sqlCon.AddInParameter(DbCom, "@I_R", DbType.Single, I_R);
                sqlCon.AddInParameter(DbCom, "@I_Y", DbType.Single, I_Y);
                sqlCon.AddInParameter(DbCom, "@I_B", DbType.Single, I_B);
                sqlCon.AddInParameter(DbCom, "@IAVG", DbType.Single, IAVG);

                sqlCon.AddInParameter(DbCom, "@KWT", DbType.Single, KWT);
                sqlCon.AddInParameter(DbCom, "@KVAT", DbType.Single, KVAT);
                sqlCon.AddInParameter(DbCom, "@KVART", DbType.Single, KVART);
                sqlCon.AddInParameter(DbCom, "@PFT", DbType.Single, PFT);
                sqlCon.AddInParameter(DbCom, "@PF_R", DbType.Single, PF_R);
                sqlCon.AddInParameter(DbCom, "@PF_Y", DbType.Single, PF_Y);
                sqlCon.AddInParameter(DbCom, "@PF_B", DbType.Single, PF_B);
                sqlCon.AddInParameter(DbCom, "@KW_R", DbType.Single, KW_R);
                sqlCon.AddInParameter(DbCom, "@KW_Y", DbType.Single, KW_Y);
                sqlCon.AddInParameter(DbCom, "@KW_B", DbType.Single, KW_B);
                sqlCon.AddInParameter(DbCom, "@KVA_R", DbType.Single, KVA_R);
                sqlCon.AddInParameter(DbCom, "@KVA_Y", DbType.Single, KVA_Y);
                sqlCon.AddInParameter(DbCom, "@KVA_B", DbType.Single, KVA_B);
                sqlCon.AddInParameter(DbCom, "@KVAR_R", DbType.Single, KVAR_R);


                sqlCon.AddInParameter(DbCom, "@KVAR_Y", DbType.Single, KVAR_Y);
                sqlCon.AddInParameter(DbCom, "@KVAR_B", DbType.Single, KVAR_B);

                sqlCon.AddInParameter(DbCom, "@kWhImport", DbType.Single, kWhImport);
                sqlCon.AddInParameter(DbCom, "@KWHEXPORT", DbType.Single, KWHEXPORT);
                sqlCon.AddInParameter(DbCom, "@kVAh", DbType.Single, kVAh);
                sqlCon.AddInParameter(DbCom, "@CREATEDON", DbType.DateTime, CREATEDON);


                if (sqlCon.ExecuteNonQuery(DbCom) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet GetLastPollID(string DBname)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("GetLastPollID");
                sqlCon.AddInParameter(DbCom, "@DBName", DbType.String, DBname);
                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public DataSet GetNicxsData(long LastPollID)
        {
            try
            {
                DbCommand DbCom = sqlCon.GetStoredProcCommand("GetNicxsData");
                sqlCon.AddInParameter(DbCom, "@inputLastPollID", DbType.Int64, LastPollID);

                return sqlCon.ExecuteDataSet(DbCom);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public DataSet InsertNicxsData(DataTable bulkData, string DBname)
        {
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(Connection))
                {
                    sqlCon.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("InsertNicxsData", sqlCon))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;


                        SqlParameter parameter2 = sqlCommand.Parameters.AddWithValue("@Dbname", DBname);
                        parameter2.SqlDbType = SqlDbType.VarChar;

                        // Creating a TVP (Table-Valued Parameter) for the DataTable
                        SqlParameter tvpParameter = sqlCommand.Parameters.AddWithValue("@NicxsData", bulkData);
                        tvpParameter.SqlDbType = SqlDbType.Structured;
                        tvpParameter.TypeName = "dbo.InputNicxsData"; // Replace with your actual user-defined table type name

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                        DataSet dataSet = new DataSet();
                        dataAdapter.Fill(dataSet);

                        return dataSet;
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }




        public DataSet InsertDataMinHistorical(DataTable bulkData, string SNo)
        {
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(Connection))
                {
                    sqlCon.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("InsertDataMinHistorical", sqlCon))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;


                        SqlParameter parameter2 = sqlCommand.Parameters.AddWithValue("@SNo", SNo);
                        parameter2.SqlDbType = SqlDbType.VarChar;

                        // Creating a TVP (Table-Valued Parameter) for the DataTable
                        SqlParameter tvpParameter = sqlCommand.Parameters.AddWithValue("@MinHistoricalData", bulkData);
                        tvpParameter.SqlDbType = SqlDbType.Structured;
                        tvpParameter.TypeName = "dbo.BulkDataMinHistorical"; // Replace with your actual user-defined table type name

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                        DataSet dataSet = new DataSet();
                        dataAdapter.Fill(dataSet);

                        return dataSet;
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataSet GetgatewayDetails()
        {
            //For cloud Sp GetgatewayDetails
            DbCommand dbCommand = sqlCon.GetStoredProcCommand("GetgatewayDetails");

            return sqlCon.ExecuteDataSet(dbCommand);
        }


        public DataSet GetjsonStorageGateways(int ServiceNo1)
        {
            //For cloud Sp GetgatewayDetails
            DbCommand dbCommand = sqlCon.GetStoredProcCommand("GetjsonStorageGateways");
            sqlCon.AddInParameter(dbCommand, "@ServiceNo", DbType.Int32, ServiceNo1);

            return sqlCon.ExecuteDataSet(dbCommand);
        }

        //public string InsertDataMinHistorical(DataTable bulkData, string SNo)
        //{
        //    try
        //    {
        //        using (SqlConnection sqlCon = new SqlConnection(Connection))
        //        {
        //            sqlCon.Open();

        //            using (SqlCommand sqlCommand = new SqlCommand("InsertDataMinHistorical", sqlCon))
        //            {
        //                sqlCommand.CommandType = CommandType.StoredProcedure;

        //                // Adding parameters 
        //                sqlCommand.Parameters.AddWithValue("@SNo", SNo);

        //                // Creating a TVP (Table-Valued Parameter) for the DataTable
        //                SqlParameter tvpParameter = sqlCommand.Parameters.AddWithValue("@MinHistoricalData", bulkData);
        //                tvpParameter.SqlDbType = SqlDbType.Structured;
        //                tvpParameter.TypeName = "dbo.BulkDataMinHistorical"; // Replace with your actual user-defined table type name

        //                // ExecuteNonQuery because the procedure doesn't return a DataSet
        //                sqlCommand.ExecuteNonQuery();

        //                return "Success";
        //            }
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        throw err; // It's usually not a good practice to throw the exception directly, but rather log it and handle it appropriately.
        //    }
        //}



    }
}
