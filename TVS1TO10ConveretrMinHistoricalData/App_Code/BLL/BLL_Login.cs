using System;

/// <summary>
/// Summary description for BLL_Login
/// </summary>
/// 

using DAL;
using System.Data;
namespace BLL
{
    public class BLL_Login
    {

        DAL_Login company;
        public BLL_Login(string DBID, int channelID)
        {
            //
            // TODO: Add constructor logic heres
            //
            company = new DAL_Login(DBID, channelID);

        }


        public DataSet EmployeeDetails_GetDetails()
        {
            try
            {
                return company.EmployeeDetails_GetDetails();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet TM_Telegram_Requests_Check()
        {
            try
            {
                return company.TM_Telegram_Requests_Check();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet TM_DailyAlertsCheck()
        {
            try
            {

                return company.TM_DailyAlertsCheck();
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

                return company.TM_RequestQuery_Check();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }





        public DataSet COD_Meter_List_Lan()
        {
            try
            {

                return company.COD_Meter_List_Lan();
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

                return company.COD_Meter_List();
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

                return company.GetLastPollID(DBname);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetNicxsData(long LastPollID)
        {
            try
            {

                return company.GetNicxsData(LastPollID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet InsertNicxsData(DataTable Table, string DBname)
        {
            try
            {

                return company.InsertNicxsData(Table, DBname);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public DataSet InsertDataMinHistorical(DataTable bulkData, string SNo)
        {
            try
            {

                return company.InsertDataMinHistorical(bulkData, SNo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet GetgatewayDetails()
        {
            try
            {

                return company.GetgatewayDetails();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet GetjsonStorageGateways(int ServiceNo)
        {
            try
            {

                return company.GetjsonStorageGateways(ServiceNo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}