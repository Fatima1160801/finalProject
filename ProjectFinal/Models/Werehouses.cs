using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ProjectFinal.ConnectionOracle;



namespace ProjectFinal.Models
{
    public class Werehouses
    {


        dbAccess con1;
        OracleCommand cmd;
        OracleConnection aOracleConnection;

        public DataTable QueryReader(string QUERY)
        {
            //Open Connection
            Open();
            OracleTransaction CmdTrans = aOracleConnection.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                // Set the command
                cmd = new OracleCommand(QUERY, aOracleConnection);
                cmd.Transaction = CmdTrans;
                cmd.CommandType = CommandType.Text;
                // Bind 
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                CmdTrans.Commit();
                return dt;
            }
            catch (Exception ex)
            {
                CmdTrans.Rollback();
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                Close();
            }
        }
        public DataTable QueryReader(string QUERY, OracleTransaction CmdTrans, OracleConnection aaOracleConnection)
        {
            try
            {
                // Set the command
                cmd = new OracleCommand(QUERY, aaOracleConnection);
                cmd.Transaction = CmdTrans;
                cmd.CommandType = CommandType.Text;
                // Bind 
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public string Insert_C_PASSPORT_TYPES_TB(string WEREHOUSE_ID, string WEREHOUSE_NAME, string WEREHOUSE_ADDRESS, string WEREHOUSE_TELEPHON
            , string WEREHOUSE_DEFULTE, string WEREHOUSE_TYPE_ID, string WEREHOUSE_COUNTRY_ID, string WEREHOUSE_STATE_ID, string WEREHOUSE_CITY_ID)
        {
            //Open Connection
            Open();
            OracleTransaction CmdTrans = aOracleConnection.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {

                var cmdText = "INSERT INTO werehouse ( " +
                                    "WEREHOUSE_ID, " +
                                    "WEREHOUSE_NAME, " +
                                    "WEREHOUSE_ADDRESS, " +
                                    "WEREHOUSE_TELEPHON, " +
                                    "WEREHOUSE_DEFULTE, " +
                                    "WEREHOUSE_TYPE_ID, " +
                                     "WEREHOUSE_COUNTRY_ID, " +
                                     "WEREHOUSE_STATE_ID, " +
                                     "WEREHOUSE_CITY_ID " +



                                ") VALUES( " +
                                    ":WEREHOUSE_ID, " +
                                    ":WEREHOUSE_NAME, " +
                                    ":WEREHOUSE_ADDRESS, " +
                                    ":WEREHOUSE_TELEPHON, " +
                                    ":WEREHOUSE_DEFULTE, " +
                                    ":WEREHOUSE_TYPE_ID, " +
                                     ":WEREHOUSE_COUNTRY_ID, " +
                                     ":WEREHOUSE_STATE_ID, " +
                                     ":WEREHOUSE_CITY_ID " +



                                ") ";

                // create command and set properties  
                OracleCommand cmd = aOracleConnection.CreateCommand();
                cmd.Transaction = CmdTrans;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = cmdText;
                cmd.Parameters.Add(":WEREHOUSE_ID", OracleDbType.NVarchar2).Value = WEREHOUSE_ID;
                cmd.Parameters.Add(":WEREHOUSE_NAME", OracleDbType.NVarchar2).Value = WEREHOUSE_NAME;
                cmd.Parameters.Add(":WEREHOUSE_ADDRESS", OracleDbType.NVarchar2).Value = WEREHOUSE_ADDRESS;
                cmd.Parameters.Add(":WEREHOUSE_TELEPHON", OracleDbType.NVarchar2).Value = WEREHOUSE_TELEPHON;
                cmd.Parameters.Add(":WEREHOUSE_DEFULTE", OracleDbType.NVarchar2).Value = WEREHOUSE_DEFULTE;
                cmd.Parameters.Add(":WEREHOUSE_TYPE_ID", OracleDbType.NVarchar2).Value = WEREHOUSE_TYPE_ID;
                cmd.Parameters.Add(":WEREHOUSE_COUNTRY_ID", OracleDbType.NVarchar2).Value = WEREHOUSE_COUNTRY_ID;
                cmd.Parameters.Add(":WEREHOUSE_STATE_ID", OracleDbType.NVarchar2).Value = WEREHOUSE_STATE_ID;
                cmd.Parameters.Add(":WEREHOUSE_CITY_ID", OracleDbType.NVarchar2).Value = WEREHOUSE_CITY_ID;




                cmd.ExecuteNonQuery();


                CmdTrans.Commit();
                return WEREHOUSE_ID;

            }

            catch (Exception ex)
            {
                CmdTrans.Rollback();
                throw new Exception(ex.Message.ToString());

            }
            finally
            {
                Close();
            }
        }
        public string DELETE_WEREHOUSE(string WEREHOUSE_ID)
        {
            //Open Connection
            Open();
            OracleTransaction CmdTrans = aOracleConnection.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {


                var cmdText = "DELETE from werehouse where WEREHOUSE_ID =  " +
                                    WEREHOUSE_ID +

                                "";

                // create command and set properties  
                OracleCommand cmd = aOracleConnection.CreateCommand();
                cmd.Transaction = CmdTrans;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = cmdText;



                cmd.ExecuteNonQuery();


                CmdTrans.Commit();
                return "1";

            }

            catch (Exception ex)
            {
                CmdTrans.Rollback();
                throw new Exception(ex.Message.ToString());

            }
            finally
            {
                Close();
            }
        }

        public int IfWerehouse_Empty(int werehouse_id)
        {
            //Open Connection
            Open();
            OracleTransaction CmdTrans = aOracleConnection.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {


                var cmdText = "SELECT count(*) from items where WEREHOUSE_ID = " + werehouse_id;

                // create command and set properties  
                OracleCommand cmd = aOracleConnection.CreateCommand();
                cmd.Transaction = CmdTrans;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = cmdText;


                cmd.ExecuteNonQuery();


                CmdTrans.Commit();
                return werehouse_id;

            }

            catch (Exception ex)
            {
                CmdTrans.Rollback();
                throw new Exception(ex.Message.ToString());

            }
            finally
            {
                Close();
            }
        }
        public string UPDATE_WEREHOUSE(string WEREHOUSE_ID, string WEREHOUSE_NAME, string WEREHOUSE_ADDRESS, string WEREHOUSE_TELEPHON
          , string WEREHOUSE_DEFULTE, string WEREHOUSE_TYPE_ID, string WEREHOUSE_COUNTRY_ID, string WEREHOUSE_STATE_ID, string WEREHOUSE_CITY_ID)
        {
            //Open Connection
            Open();
            OracleTransaction CmdTrans = aOracleConnection.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {

                var cmdText = "INSERT INTO werehouse ( " +
                                    "WEREHOUSE_ID, " +
                                    "WEREHOUSE_NAME, " +
                                    "WEREHOUSE_ADDRESS, " +
                                    "WEREHOUSE_TELEPHON, " +
                                    "WEREHOUSE_DEFULTE, " +
                                    "WEREHOUSE_TYPE_ID, " +
                                     "WEREHOUSE_COUNTRY_ID, " +
                                     "WEREHOUSE_STATE_ID, " +
                                     "WEREHOUSE_CITY_ID " +



                                ") VALUES( " +
                                    ":WEREHOUSE_ID, " +
                                    ":WEREHOUSE_NAME, " +
                                    ":WEREHOUSE_ADDRESS, " +
                                    ":WEREHOUSE_TELEPHON, " +
                                    ":WEREHOUSE_DEFULTE, " +
                                    ":WEREHOUSE_TYPE_ID, " +
                                     ":WEREHOUSE_COUNTRY_ID, " +
                                     ":WEREHOUSE_STATE_ID, " +
                                     ":WEREHOUSE_CITY_ID " +



                                ") ";

                // create command and set properties  
                OracleCommand cmd = aOracleConnection.CreateCommand();
                cmd.Transaction = CmdTrans;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = cmdText;
                cmd.Parameters.Add(":WEREHOUSE_ID", OracleDbType.NVarchar2).Value = WEREHOUSE_ID;
                cmd.Parameters.Add(":WEREHOUSE_NAME", OracleDbType.NVarchar2).Value = WEREHOUSE_NAME;
                cmd.Parameters.Add(":WEREHOUSE_ADDRESS", OracleDbType.NVarchar2).Value = WEREHOUSE_ADDRESS;
                cmd.Parameters.Add(":WEREHOUSE_TELEPHON", OracleDbType.NVarchar2).Value = WEREHOUSE_TELEPHON;
                cmd.Parameters.Add(":WEREHOUSE_DEFULTE", OracleDbType.NVarchar2).Value = WEREHOUSE_DEFULTE;
                cmd.Parameters.Add(":WEREHOUSE_TYPE_ID", OracleDbType.NVarchar2).Value = WEREHOUSE_TYPE_ID;
                cmd.Parameters.Add(":WEREHOUSE_COUNTRY_ID", OracleDbType.NVarchar2).Value = WEREHOUSE_COUNTRY_ID;
                cmd.Parameters.Add(":WEREHOUSE_STATE_ID", OracleDbType.NVarchar2).Value = WEREHOUSE_STATE_ID;
                cmd.Parameters.Add(":WEREHOUSE_CITY_ID", OracleDbType.NVarchar2).Value = WEREHOUSE_CITY_ID;




                cmd.ExecuteNonQuery();


                CmdTrans.Commit();
                return WEREHOUSE_ID;

            }

            catch (Exception ex)
            {
                CmdTrans.Rollback();
                throw new Exception(ex.Message.ToString());

            }
            finally
            {
                Close();
            }
        }
            
        void Open()
        {
            con1 = new dbAccess();
            aOracleConnection = con1.get_con();
        }

        void Close()
        {
            con1.Close(aOracleConnection);
        }
    }
}
