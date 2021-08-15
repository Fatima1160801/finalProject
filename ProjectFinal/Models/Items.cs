using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ProjectFinal.ConnectionOracle;



namespace ProjectFinal.Models
{
    public class Items
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
        public string Insert_C_PASSPORT_TYPES_TB(string ITEM_ID, string ITEM_NAME , string WEREHOUSE_ID)
        {
            //Open Connection
            Open();
            OracleTransaction CmdTrans = aOracleConnection.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                var cmdText = "INSERT INTO items ( " +
                                    "ITEM_ID, " +
                                    "ITEM_NAME," +
                                    "WEREHOUSE_ID " +


                                ") VALUES( " +
                                    ":ITEM_ID, " +
                                    ":ITEM_NAME, " +
                                    ":WEREHOUSE_ID " +


                                ") ";

                // create command and set properties  
                OracleCommand cmd = aOracleConnection.CreateCommand();
                cmd.Transaction = CmdTrans;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = cmdText;
                cmd.Parameters.Add(":ITEM_ID", OracleDbType.NVarchar2).Value = ITEM_ID;
                cmd.Parameters.Add(":ITEM_NAME", OracleDbType.NVarchar2).Value = ITEM_NAME;
                cmd.Parameters.Add(":WEREHOUSE_ID", OracleDbType.NVarchar2).Value = WEREHOUSE_ID;


                cmd.ExecuteNonQuery();


                CmdTrans.Commit();
                return ITEM_ID;

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
        public string DELETE_ITEM(string ITEM_ID)
        {
            //Open Connection
            Open();
            OracleTransaction CmdTrans = aOracleConnection.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {


                var cmdText = "DELETE from items where ITEM_ID =  " +
                                    ITEM_ID +

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

          public int UPDATE_ITEM(int item_ID, string item_NAME)
           {
               //Open Connection
               Open();
               OracleTransaction CmdTrans = aOracleConnection.BeginTransaction(IsolationLevel.ReadCommitted);
               try
               {


                   var cmdText = "UPDATE items SET ITEM_NAME =item_NAME where  ITEM_ID = item_ID   ";

                   // create command and set properties  
                   OracleCommand cmd = aOracleConnection.CreateCommand();
                   cmd.Transaction = CmdTrans;
                   cmd.CommandType = CommandType.Text;

                   cmd.CommandText = cmdText;

                   cmd.Parameters.Add(":item_NAME", OracleDbType.NVarchar2).Value = item_NAME;
                   cmd.Parameters.Add(":item_ID", OracleDbType.NVarchar2).Value = item_ID;

                   cmd.ExecuteNonQuery();


                   CmdTrans.Commit();
                   return item_ID;

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
