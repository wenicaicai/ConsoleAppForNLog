using NLog;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleAppForNLog.TransferData
{
    public class TransferFromDB
    {
        //日志记录器
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public void GetDataFromDB()
        {
            
            Stopwatch myTime = new Stopwatch();
            int totalRows = 0;
            DataTable dataTable = new DataTable();
            string connectionStr = @"server=rm-wz9xn9658f13gapx80o.sqlserver.rds.aliyuncs.com,3433;database=fywdb;uid=fairhr;pwd=Fairhr@))$2004;pooling=true;min pool size=5;max pool size=512;connect timeout = 20;";
            string testDB = @"server=192.168.10.104;database=NewFYW;uid=sa;pwd=Fyw@556677;pooling=true;min pool size=5;max pool size=512;connect timeout = 20";
            string sqlStr = "select * from SO_SOCIALSECURITY";
            myTime.Start();
            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlStr, sqlConnection);
                
                dataAdapter.Fill(dataTable);
                totalRows = dataTable.Rows.Count;

                SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                myTime.Stop();
                logger.Info("读取数据行数：" + totalRows);
                logger.Info("读取数据用时：" + myTime.ElapsedMilliseconds + "（ms）");
                myTime.Restart();
                using (SqlConnection conn = new SqlConnection(testDB))
                {
                    conn.Open();
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                    {
                        bulkCopy.DestinationTableName = "dbo.SO_SOCIALSECURITY_BulkCopy";
                        try
                        {
                            // Write from the source to the destination.
                            bulkCopy.WriteToServer(sqlDataReader);
                        }
                        catch (Exception ex)
                        {
                            logger.Error(ex.Message);
                        }
                        finally
                        {
                            // Close the SqlDataReader. The SqlBulkCopy
                            // object is automatically closed at the end
                            // of the using block.
                            sqlDataReader.Close();
                            conn.Close();
                            sqlConnection.Close();
                        }
                    }
                }
                myTime.Stop();
                logger.Info("批量读取用时：" + totalRows);
                logger.Info("批量读取行数：" + myTime.ElapsedMilliseconds + "（ms）");
            }
            
            myTime.Restart();
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, dataTable);
            myTime.Stop();
            logger.Info("序列化"+ totalRows + "数据花费时间"+ myTime.ElapsedMilliseconds + "（ms）");



            
        }
        

    }
}
