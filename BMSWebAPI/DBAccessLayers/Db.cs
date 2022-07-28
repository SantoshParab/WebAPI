using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
//using MySql.Data.MySqlClient;
using MySqlConnector;
using System.Configuration;
using BMSWebAPI.Models;
using BMSWebAPI.Common;

namespace BMSWebAPI.DBAccessLayers
{
    public class Db
    {
        #region santosh code
        public string dateformat1 = "%Y/%m/%d";
        public string dateformat2 = "%d/%m/%Y";
        public string dateformat3 = "%e/%c/%Y %r";
        public User GetUsers(string userName, string password)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.GetUserDetails, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();


                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@UserName", userName);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        MySqlDataReader reader = cmd.ExecuteReader();
                        User entry = new User();
                        while (reader.Read())
                        {


                            if (reader["UserId"] != DBNull.Value)
                                entry.UserId = Convert.ToInt32(reader["UserId"].ToString());

                            if (reader["UserName"] != DBNull.Value)
                                entry.UserName = (reader["UserName"].ToString());

                            if (reader["Password"] != DBNull.Value)
                                entry.Password = (reader["Password"].ToString());

                            if (reader["UserTypeId"] != DBNull.Value)
                                entry.UserTypeId = Convert.ToInt32(reader["UserTypeId"].ToString());

                            if (reader["IsActive"] != DBNull.Value)
                                entry.IsActive = Convert.ToInt32(reader["IsActive"].ToString());

                            if (reader["UserType"] != DBNull.Value)
                                entry.UserType = reader["UserType"].ToString();


                        }
                        return entry;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return null;
                    }
                    catch (Exception ex)
                    {

                        return null;
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }

        //public  List<Hospital> GetHospitals()
        //{

        //    string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        //    using (MySqlConnection con = new MySqlConnection(_connectionString))
        //    {

        //        using (MySqlCommand cmd = new MySqlCommand(DBQueries.GetHospitals, con))
        //        {
        //            cmd.CommandType = CommandType.Text;

        //            cmd.Parameters.Clear();



        //            try
        //            {
        //                if (con.State != ConnectionState.Open)
        //                {
        //                    con.Open();
        //                }

        //                MySqlDataReader reader = cmd.ExecuteReader();
        //                List<Hospital> result = new List<Hospital>();
        //                while (reader.Read())
        //                {

        //                    Hospital entry = new Hospital();
        //                    if (reader["HospitalId"] != DBNull.Value)
        //                        entry.HospitalId = Convert.ToInt32(reader["HospitalId"].ToString());

        //                    if (reader["PHC"] != DBNull.Value)
        //                        entry.PHC = (reader["PHC"].ToString());

        //                    if (reader["Code"] != DBNull.Value)
        //                        entry.Code = (reader["Code"].ToString());

        //                    if (reader["Zone"] != DBNull.Value)
        //                        entry.Zone =(reader["Zone"].ToString());

        //                    if (reader["IsActive"] != DBNull.Value)
        //                        entry.IsActive = Convert.ToInt32(reader["IsActive"].ToString());

        //                    if (reader["Email"] != DBNull.Value)
        //                        entry.Email = reader["Email"].ToString();

        //                    if (reader["CreatedBy"] != DBNull.Value)
        //                        entry.CreatedBy = Convert.ToInt32(reader["CreatedBy"].ToString());

        //                    result.Add(entry);
        //                }
        //                return result;
        //            }
        //            catch (MySqlException sqlEx)
        //            {

        //                return null;
        //            }
        //            catch (Exception ex)
        //            {

        //                return null;
        //            }
        //            finally
        //            {
        //                con.Close();
        //            }

        //        }
        //    }
        //}

        public DataTable GetHospitals()
        {

            DataTable dt = new DataTable();
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.GetHospitals, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();



                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        return dt;

                    }
                    catch (MySqlException sqlEx)
                    {

                        return dt;
                    }
                    catch (Exception ex)
                    {

                        return dt;
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }
        public Hospital GetHospital(int hospitalID)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.GetHospital, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@HospitalId", hospitalID);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        MySqlDataReader reader = cmd.ExecuteReader();
                        Hospital entry = new Hospital();
                        while (reader.Read())
                        {
                            if (reader["HospitalId"] != DBNull.Value)
                                entry.HospitalId = Convert.ToInt32(reader["HospitalId"].ToString());

                            if (reader["PHC"] != DBNull.Value)
                                entry.PHC = (reader["PHC"].ToString());

                            if (reader["Code"] != DBNull.Value)
                                entry.Code = (reader["Code"].ToString());

                            if (reader["Zone"] != DBNull.Value)
                                entry.Zone = (reader["Zone"].ToString());

                            if (reader["IsActive"] != DBNull.Value)
                                entry.IsActive = Convert.ToInt32(reader["IsActive"].ToString());

                            if (reader["Email"] != DBNull.Value)
                                entry.Email = reader["Email"].ToString();

                            if (reader["CreatedBy"] != DBNull.Value)
                                entry.CreatedBy = Convert.ToInt32(reader["CreatedBy"].ToString());


                        }
                        return entry;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return null;
                    }
                    catch (Exception ex)
                    {

                        return null;
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }
        public int InsertSampleRecieved(DataTable dtsample, int userID, int hospitalID)
        {
            if (dtsample.Rows.Count > 0)
            {
                Commn objcommn = new Commn();
                DataTable exceldata = objcommn.GetExcelTable();
                Int64 bulknumber = GetBulkNumber();
                Int64 totaltransactions = 0;
                if (bulknumber == 0)
                {
                    return 0;
                }
                Hospital hspt = GetHospital(hospitalID);

                string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                MySqlTransaction transaction = null;
                using (MySqlConnection con = new MySqlConnection(_connectionString))
                {

                    using (MySqlCommand cmd = new MySqlCommand(DBQueries.InsertSamples, con))
                    {
                        cmd.CommandType = CommandType.Text;

                        try
                        {
                            con.Open();
                            transaction = con.BeginTransaction();

                            for (int i = 1; i < dtsample.Rows.Count; i++)
                            {
                                Int64 labID = GetLabID(hospitalID);

                                if (labID == 0)
                                {
                                    transaction.Rollback();
                                    return 0;
                                }

                                Int64 kmionumber = GetKMIO();
                                if (kmionumber == 0 || labID == 0)
                                {
                                    return 0;
                                }

                                cmd.Parameters.Clear();
                                string lab = objcommn.GenerateLabID(labID.ToString(), hspt.Code);
                                cmd.Transaction = transaction;
                                cmd.Parameters.AddWithValue("@Name", (dtsample.Rows[i][1]));
                                cmd.Parameters.AddWithValue("@Age", (dtsample.Rows[i][2]));
                                cmd.Parameters.AddWithValue("@Gender", (dtsample.Rows[i][3]));
                                cmd.Parameters.AddWithValue("@MobileNumber", (dtsample.Rows[i][4]));
                                cmd.Parameters.AddWithValue("@SRFID", (dtsample.Rows[i][5]));
                                cmd.Parameters.AddWithValue("@LabId", lab);
                                cmd.Parameters.AddWithValue("@KMIO", kmionumber);
                                cmd.Parameters.AddWithValue("@IsProcessed", 1);
                                cmd.Parameters.AddWithValue("@IsUnderProcess", 0);
                                cmd.Parameters.AddWithValue("@BulkNumber", bulknumber);
                                cmd.Parameters.AddWithValue("@PlateNumber", 0);
                                cmd.Parameters.AddWithValue("@IsBlockedByPlate", 0);
                                cmd.Parameters.AddWithValue("@HospitalId", hospitalID);
                                cmd.Parameters.AddWithValue("@Result", 0);
                                cmd.Parameters.AddWithValue("@IsICMRProcessed", 0);
                                cmd.Parameters.AddWithValue("@ImporterById", userID);
                                cmd.Parameters.AddWithValue("@ProcessedById", 0);
                                cmd.Parameters.AddWithValue("@ResultById", 0);
                                cmd.Parameters.AddWithValue("@ModifiedById", 0);

                                cmd.ExecuteNonQuery();
                                labID++;
                                totaltransactions++;

                                string kmio = objcommn.GenerateKMIO(kmionumber.ToString());
                                DataRow newRow = exceldata.NewRow();
                                newRow["SL NO"] = totaltransactions;
                                newRow["Name"] = dtsample.Rows[i][1];
                                newRow["Age"] = dtsample.Rows[i][2];
                                newRow["Gender"] = dtsample.Rows[i][3];
                                newRow["Mobile No"] = dtsample.Rows[i][4];
                                newRow["SRF ID"] = dtsample.Rows[i][5];
                                newRow["LAB ID"] = lab;
                                newRow["KMIO"] = kmio;
                                newRow["RT PCR RESULTS"] = "Under Process";
                                exceldata.Rows.Add(newRow);
                            }
                            var path = objcommn.ExportToExcel(exceldata, bulknumber.ToString(), 1, hspt.PHC);
                            string excelpath = path.Item1;
                            string pdfpath = path.Item2;
                            cmd.Parameters.Clear();

                            cmd.CommandText = DBQueries.InsertBulkTransaction;
                            cmd.Parameters.AddWithValue("@BulkNumber", bulknumber);
                            cmd.Parameters.AddWithValue("@TotalTransaction", totaltransactions);
                            cmd.Parameters.AddWithValue("@CompletedTransaction", 0);
                            cmd.Parameters.AddWithValue("@Status", 0);
                            cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@ExcelLink", excelpath);
                            cmd.Parameters.AddWithValue("@PdfLink", pdfpath);

                            cmd.ExecuteNonQuery();

                            transaction.Commit();
                            return 1;

                        }
                        catch (MySqlException sqlEx)
                        {
                            transaction.Rollback();
                            return 0;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            return 0;
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }

            return 0;
        }

        public int ValidateExcelData(DataTable dtsample, int userID, int hospitalID)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.InsertValidateTransaction, con))
                {
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        con.Open();

                        for (int i = 1; i < dtsample.Rows.Count; i++)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@Name", (dtsample.Rows[i][1]));
                            cmd.Parameters.AddWithValue("@Age", (dtsample.Rows[i][2]));
                            cmd.Parameters.AddWithValue("@Gender", (dtsample.Rows[i][3]));
                            cmd.Parameters.AddWithValue("@MobileNumber", (dtsample.Rows[i][4]));
                            cmd.Parameters.AddWithValue("@SRFID", (dtsample.Rows[i][5]));
                            cmd.Parameters.AddWithValue("@LabId", "0");
                            cmd.Parameters.AddWithValue("@KMIO", "0");
                            cmd.Parameters.AddWithValue("@IsProcessed", 1);
                            cmd.Parameters.AddWithValue("@IsUnderProcess", 0);
                            cmd.Parameters.AddWithValue("@BulkNumber", "0");
                            cmd.Parameters.AddWithValue("@PlateNumber", 0);
                            cmd.Parameters.AddWithValue("@IsBlockedByPlate", 0);
                            cmd.Parameters.AddWithValue("@HospitalId", hospitalID);
                            cmd.Parameters.AddWithValue("@Result", 0);
                            cmd.Parameters.AddWithValue("@IsICMRProcessed", 0);
                            cmd.Parameters.AddWithValue("@ImporterById", userID);
                            cmd.Parameters.AddWithValue("@ProcessedById", 0);
                            cmd.Parameters.AddWithValue("@ResultById", 0);
                            cmd.Parameters.AddWithValue("@ModifiedById", 0);

                            cmd.ExecuteNonQuery();
                        }

                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public Int64 GetLabID(int hospitalID)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            Int64 labID = 0;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.CheckIfExistLabID, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();


                    cmd.Parameters.AddWithValue("@hospitalid", hospitalID);
                    cmd.Parameters.AddWithValue("@Day", DateTime.Now.Day);
                    cmd.Parameters.AddWithValue("@Month", DateTime.Now.Month);
                    cmd.Parameters.AddWithValue("@Year", DateTime.Now.Year);
                    cmd.Parameters.AddWithValue("@SerialNumber", 1);
                    try
                    {
                        con.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 0)
                        {
                            int ret = InsertLabID(hospitalID);

                            if (ret == 1)
                            {

                                cmd.CommandText = DBQueries.GetLabID;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@hospitalid", hospitalID);
                                cmd.Parameters.AddWithValue("@Day", DateTime.Now.Day);
                                cmd.Parameters.AddWithValue("@Month", DateTime.Now.Month);
                                cmd.Parameters.AddWithValue("@Year", DateTime.Now.Year);

                                labID = Convert.ToInt64(cmd.ExecuteScalar());
                                int labupdate = UpdateLabID(hospitalID, labID + 1);
                                if (labupdate == 0)
                                {

                                    return 0;

                                }
                            }
                            else
                            {
                                return 0;
                            }
                        }
                        else
                        {
                            cmd.CommandText = DBQueries.GetLabID;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@hospitalid", hospitalID);
                            cmd.Parameters.AddWithValue("@Day", DateTime.Now.Day);
                            cmd.Parameters.AddWithValue("@Month", DateTime.Now.Month);
                            cmd.Parameters.AddWithValue("@Year", DateTime.Now.Year);
                            labID = Convert.ToInt64(cmd.ExecuteScalar());

                            int labupdate = UpdateLabID(hospitalID, labID + 1);
                            if (labupdate == 0)
                            {

                                return 0;

                            }
                        }
                        return labID;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public Int64 GetBulkNumber()
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            Int64 bulknumber = 0;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.GetBulkNumber, con))
                {
                    cmd.CommandType = CommandType.Text;

                    try
                    {
                        con.Open();
                        var count = (cmd.ExecuteScalar());
                        if (count == null)
                        {
                            InsertBulkNumber(2);
                            return 1;

                        }
                        else
                            UpdateBulkNumber(Convert.ToInt64(count) + 1);
                        return Convert.ToInt64(count);

                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public Int64 GetKMIO()
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            Int64 bulknumber = 0;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.GetKMIONumber, con))
                {
                    cmd.CommandType = CommandType.Text;

                    try
                    {
                        con.Open();
                        var count = (cmd.ExecuteScalar());
                        if (count == null)
                        {
                            InsertKMIONumber(2);
                            return 1;
                        }
                        else
                            UpdateKMIONumber(Convert.ToInt64(count) + 1);
                        return Convert.ToInt64(count);

                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public int InsertLabID(int hospitalID)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.InsertLabID, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();


                    cmd.Parameters.AddWithValue("@hospitalid", hospitalID);
                    cmd.Parameters.AddWithValue("@Day", DateTime.Now.Day);
                    cmd.Parameters.AddWithValue("@Month", DateTime.Now.Month);
                    cmd.Parameters.AddWithValue("@Year", DateTime.Now.Year);
                    cmd.Parameters.AddWithValue("@SerialNumber", 1);



                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public int UpdateLabID(int hospitalID, Int64 labid)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.UpdateLabID, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();


                    cmd.Parameters.AddWithValue("@hospitalid", hospitalID);
                    cmd.Parameters.AddWithValue("@Day", DateTime.Now.Day);
                    cmd.Parameters.AddWithValue("@Month", DateTime.Now.Month);
                    cmd.Parameters.AddWithValue("@Year", DateTime.Now.Year);
                    cmd.Parameters.AddWithValue("@SerialNumber", labid);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public int UpdateBulkNumber(Int64 bulknumber)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.UpdateBulkNumber, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();


                    cmd.Parameters.AddWithValue("@bulknumber", bulknumber);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public int InsertBulkNumber(Int64 bulknumber)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.InsertBulkNumber, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();


                    cmd.Parameters.AddWithValue("@bulknumber", bulknumber);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        public int UpdateKMIONumber(Int64 kmio)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.UpdateKMIO, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();


                    cmd.Parameters.AddWithValue("@KMIONumber", kmio);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public int InsertKMIONumber(Int64 kmio)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.InsertKMIO, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();


                    cmd.Parameters.AddWithValue("@KMIONumber", kmio);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public Int64 GetPlateNUmber()
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            Int64 plateno = 0;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.GetNextPlateNUmber, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Month", DateTime.Now.Month);
                    cmd.Parameters.AddWithValue("@Year", DateTime.Now.Year);
                    try
                    {
                        con.Open();
                        var count = (cmd.ExecuteScalar());
                        if (count == null)
                        {
                            InsertPlateNumber(2);
                            return 1;

                        }
                        else
                            UpdatePlateNumber(Convert.ToInt64(count) + 1);
                        return Convert.ToInt64(count);

                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public Int64 GetTentativePlateNUmber()
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            Int64 plateno = 0;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.GetNextPlateNUmber, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Month", DateTime.Now.Month);
                    cmd.Parameters.AddWithValue("@Year", DateTime.Now.Year);
                    try
                    {
                        con.Open();
                        var count = (cmd.ExecuteScalar());
                        if (count == null)
                        {
                            //InsertPlateNumber(2);
                            return 1;

                        }
                        else
                            return Convert.ToInt64(count);

                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public int UpdatePlateNumber(Int64 plateno)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.UpdatePlateNumber, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@plateno", plateno);
                    cmd.Parameters.AddWithValue("@Month", DateTime.Now.Month);
                    cmd.Parameters.AddWithValue("@Year", DateTime.Now.Year);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public int InsertPlateNumber(Int64 plateno)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.InsertPlateNumber, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@plateno", plateno);
                    cmd.Parameters.AddWithValue("@Month", DateTime.Now.Month);
                    cmd.Parameters.AddWithValue("@Year", DateTime.Now.Year);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        public Tuple<DataTable, int> GetBulkSamples(string fromdate, string todate, string userid, string index)
        {
            Commn objcommn = new Commn();

            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            DataTable dt = new DataTable();
            var limits = objcommn.GetLimits(index);

            if (string.IsNullOrEmpty(fromdate))
            {
                fromdate = "2021/05/01";

            }
            if (string.IsNullOrEmpty(todate))
            {
                todate = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            }
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.GetBulkSamplesCount, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@dateformat2", dateformat2);
                    cmd.Parameters.AddWithValue("@dateformat1", dateformat1);
                    cmd.Parameters.AddWithValue("@fromdate", fromdate);
                    cmd.Parameters.AddWithValue("@todate", todate);
                    cmd.Parameters.AddWithValue("@userid", Convert.ToInt32(userid));
                    cmd.Parameters.AddWithValue("@lowerlimit", limits.Item1);
                    cmd.Parameters.AddWithValue("@upperlimit", limits.Item2);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        DataTable dp = new DataTable();
                        cmd.CommandText = DBQueries.GetBulkSamplesCount;
                        MySqlDataAdapter dap = new MySqlDataAdapter(cmd);
                        dap.Fill(dp);

                        cmd.CommandText = DBQueries.GetBulkSamples;
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        return Tuple.Create(dt, dp.Rows.Count);
                    }
                    catch (MySqlException sqlEx)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    catch (Exception ex)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }

        public Tuple<DataTable, int> SamplesForPlate(string fromdate, string todate, string userid, string index, string bulknumber, string hospitalID, string fromlab, string tolab, int PlateType)
        {
            Commn objcommn = new Commn();

            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            DataTable dt = new DataTable();
            var limits = objcommn.GetLimits_N(index, PlateType);
            string strDBQuery = string.Empty;
            string strDBQueryCount = string.Empty;
            if (string.IsNullOrEmpty(fromdate))
            {
                fromdate = "2021/05/01";


            }
            if (string.IsNullOrEmpty(todate))
            {
                todate = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            }
            if (string.IsNullOrEmpty(bulknumber))
            {
                bulknumber = "0";
            }
            if (string.IsNullOrEmpty(hospitalID))
            {
                hospitalID = "0";
            }
            if (bulknumber != "0")
            {
                if (hospitalID == "0")
                {
                    strDBQuery = "BulkScanPHCNull";
                    strDBQueryCount = "BulkScanPHCNullcount";
                }
                else
                {
                    strDBQuery = "BulkScan";
                    strDBQueryCount = "BulkScancount";
                }
            }

            if (hospitalID == "0" && bulknumber == "0")
            {
                strDBQuery = "BothNull";
                strDBQueryCount = "BothNullcount";
            }
            else if (hospitalID == "0" && bulknumber != "0" && string.IsNullOrEmpty(fromlab) && string.IsNullOrEmpty(tolab))
            {
                strDBQuery = "PHCNull";
                strDBQueryCount = "PHCNullcount";
            }
            else if (hospitalID != "0" && bulknumber == "0")
            {
                strDBQuery = "BulkNull";
                strDBQueryCount = "BulkNullcount";
            }
            else
            {
                if (string.IsNullOrEmpty(fromlab) && string.IsNullOrEmpty(tolab))
                {
                    strDBQuery = "BulkPHC";
                    strDBQueryCount = "BulkPHCcount";
                }
            }

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand("", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Clear();
                    //cmd.Parameters.AddWithValue("@dateformat2", dateformat2);
                    //cmd.Parameters.AddWithValue("@dateformat1", dateformat1);
                    cmd.Parameters.AddWithValue("@FromDate", fromdate);
                    cmd.Parameters.AddWithValue("@ToDate", todate);
                    cmd.Parameters.AddWithValue("@BulkNumber", bulknumber);
                    cmd.Parameters.AddWithValue("@PHC", hospitalID);
                    cmd.Parameters.AddWithValue("@LowerLimit", limits.Item1);
                    cmd.Parameters.AddWithValue("@UpperLimit", limits.Item2);
                    cmd.Parameters.AddWithValue("@FromLab", fromlab);
                    cmd.Parameters.AddWithValue("@ToLab", tolab);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        cmd.CommandText = strDBQueryCount;
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd.CommandText = strDBQuery;
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        return Tuple.Create(dt, count);
                    }
                    catch (MySqlException sqlEx)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    catch (Exception ex)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }

        public string BlockSamples(List<SampleProcess> bulklist)
        {
            Commn objcomn = new Commn();
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            MySqlTransaction transaction = null;

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand("SampleValidation", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;



                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();

                        }
                        transaction = con.BeginTransaction();

                        cmd.Transaction = transaction;
                        foreach (SampleProcess obj in bulklist)
                        {
                            cmd.Parameters.Clear();
                            //  cmd.Parameters.AddWithValue("@PlateNumber", plate);
                            cmd.Parameters.AddWithValue("@SampleId", obj.SampleID);
                            //  cmd.Parameters.AddWithValue("@ProcessedById", obj.UserID);
                            //  cmd.Parameters.AddWithValue("@ModifiedById", obj.UserID);
                            int output = Convert.ToInt32(cmd.ExecuteScalar());
                            if (output > 0)
                            {
                                // transaction.Rollback();
                                return "Error: Entry already processed.";
                            }

                        }
                        // transaction.Commit();
                        //   return plate;
                    }
                    catch (MySqlException sqlEx)
                    {
                        transaction.Rollback();
                        return string.Empty;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return string.Empty;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }


            Int64 plateno = GetTentativePlateNUmber();

            if (plateno == 0)
            {
                return string.Empty;
            }
            string plate = objcomn.GeneratePlateNumber(plateno.ToString());
            //   MySqlTransaction transaction = null;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.BlockSamples, con))
                {
                    cmd.CommandType = CommandType.Text;



                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();

                        }
                        transaction = con.BeginTransaction();

                        cmd.Transaction = transaction;
                        foreach (SampleProcess obj in bulklist)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@PlateNumber", plate);
                            cmd.Parameters.AddWithValue("@SampleId", obj.SampleID);
                            cmd.Parameters.AddWithValue("@ProcessedById", obj.UserID);
                            cmd.Parameters.AddWithValue("@ModifiedById", obj.UserID);
                            int output = cmd.ExecuteNonQuery();
                            if (output == 0)
                            {
                                transaction.Rollback();
                                return string.Empty;
                            }

                        }
                        transaction.Commit();
                        return plate;
                    }
                    catch (MySqlException sqlEx)
                    {
                        transaction.Rollback();
                        return string.Empty;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return string.Empty;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

        }

        public string ConfirmPlate(List<SampleProcess> bulklist)
        {
            Commn objcomn = new Commn();
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            Int64 plateno = GetPlateNUmber();

            if (plateno == 0)
            {
                return string.Empty;
            }
            string plate = objcomn.GeneratePlateNumber(plateno.ToString());
            MySqlTransaction transaction = null;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.AllotPlateNumber, con))
                {
                    cmd.CommandType = CommandType.Text;



                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();

                        }
                        transaction = con.BeginTransaction();

                        cmd.Transaction = transaction;
                        foreach (SampleProcess obj in bulklist)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@PlateNumber", plate);
                            cmd.Parameters.AddWithValue("@SampleId", obj.SampleID);
                            cmd.Parameters.AddWithValue("@ProcessedById", obj.UserID);
                            cmd.Parameters.AddWithValue("@ModifiedById", obj.UserID);
                            cmd.Parameters.AddWithValue("@SampleProcessedOrder", obj.SampleProcessedOrder);
                            cmd.Parameters.AddWithValue("@PoolNumber", obj.PoolNumber);
                            cmd.Parameters.AddWithValue("@PlateType", obj.PlateType);

                            int output = cmd.ExecuteNonQuery();
                            if (output == 0)
                            {
                                transaction.Rollback();
                                return string.Empty;
                            }

                        }
                        transaction.Commit();
                        return plate;
                    }
                    catch (MySqlException sqlEx)
                    {
                        transaction.Rollback();
                        return string.Empty;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return string.Empty;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

        }

        public int DeAssignPlate(List<SampleProcess> bulklist)
        {
            Commn objcomn = new Commn();
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


            MySqlTransaction transaction = null;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.DisAllotPlateNumber, con))
                {
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();

                        }
                        transaction = con.BeginTransaction();

                        cmd.Transaction = transaction;
                        foreach (SampleProcess obj in bulklist)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@SampleId", obj.SampleID);
                            cmd.Parameters.AddWithValue("@ProcessedById", 0);
                            cmd.Parameters.AddWithValue("@ModifiedById", obj.UserID);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

        }

        public int DeAssignPlate(SampleProcess objbulk)
        {
            Commn objcomn = new Commn();
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


            MySqlTransaction transaction = null;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.DisAllotPlateNumber, con))
                {
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();

                        }
                        transaction = con.BeginTransaction();
                        cmd.Parameters.Clear();
                        cmd.Transaction = transaction;


                        cmd.Parameters.AddWithValue("@SampleId", objbulk.SampleID);
                        cmd.Parameters.AddWithValue("@ProcessedById", 0);
                        cmd.Parameters.AddWithValue("@ModifiedById", objbulk.UserID);
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

        }

        public Tuple<DataTable, int> GetAssignedPlates(string userid, string index)
        {
            Commn objcommn = new Commn();

            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            DataTable dt = new DataTable();
            var limits = objcommn.GetLimits(index);
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.GetPlateProcessedSamplesCount, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@dateformat2", dateformat2);
                    cmd.Parameters.AddWithValue("@lowerlimit", limits.Item1);
                    cmd.Parameters.AddWithValue("@upperlimit", limits.Item2);
                    cmd.Parameters.AddWithValue("@ProcessedById", userid);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }


                        DataTable dp = new DataTable();
                        MySqlDataAdapter dap = new MySqlDataAdapter(cmd);
                        dap.Fill(dp);

                        cmd.CommandText = DBQueries.GetPlateProcessedSamples;
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        return Tuple.Create(dt, dp.Rows.Count);
                    }
                    catch (MySqlException sqlEx)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    catch (Exception ex)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }

        }

        public Tuple<DataTable, int> GetPlates(string Platenumber, string index)
        {
            Commn objcommn = new Commn();

            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            DataTable dt = new DataTable();
            var limits = objcommn.GetLimits(index);
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.GetProccessedSamplesCount, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();
                    //cmd.Parameters.AddWithValue("@dateformat2", dateformat2);
                    cmd.Parameters.AddWithValue("@lowerlimit", limits.Item1);
                    cmd.Parameters.AddWithValue("@upperlimit", limits.Item2);
                    cmd.Parameters.AddWithValue("@PlateNumber", Platenumber);
                    //cmd.Parameters.AddWithValue("@ProcessedById", userid);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        if (string.IsNullOrEmpty(Platenumber))
                        {
                            DataTable dp = new DataTable();
                            MySqlDataAdapter dap = new MySqlDataAdapter(cmd);
                            dap.Fill(dp);

                            cmd.CommandText = DBQueries.GetProccessedSamples;
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dt);
                            return Tuple.Create(dt, dp.Rows.Count);
                        }
                        else
                        {
                            cmd.CommandText = DBQueries.GetProccessedSamplesPlatewise;
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dt);
                            return Tuple.Create(dt, 1);
                        }
                    }
                    catch (MySqlException sqlEx)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    catch (Exception ex)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }

        }

        public Tuple<DataTable, int> GetAllLabID(string platenuber, string usertype, string index)
        {
            Commn objcommn = new Commn();

            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            DataTable dt = new DataTable();
            var limits = objcommn.GetLimits(index);


            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand("", con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@PlateNumber", platenuber);
                    cmd.Parameters.AddWithValue("@lowerlimit", limits.Item1);
                    cmd.Parameters.AddWithValue("@upperlimit", limits.Item2);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        if (usertype == "Admin")
                        {
                            cmd.CommandText = DBQueries.GetAllLabIDforResultAdminCount;
                            int count = Convert.ToInt32(cmd.ExecuteScalar());

                            cmd.CommandText = DBQueries.GetAllLabIDforResultAdmin;
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dt);
                            return Tuple.Create(dt, dt.Rows.Count);
                        }
                        else
                        {
                            cmd.CommandText = DBQueries.GetAllLabIDforResultCount;
                            int count = Convert.ToInt32(cmd.ExecuteScalar());

                            cmd.CommandText = DBQueries.GetAllLabIDforResult;
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dt);
                            return Tuple.Create(dt, dt.Rows.Count);
                        }

                    }
                    catch (MySqlException sqlEx)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    catch (Exception ex)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }

        public Tuple<DataTable, int> GetLabID(string platenuber, string usertype, string index, string LabID)
        {
            Commn objcommn = new Commn();

            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            DataTable dt = new DataTable();
            var limits = objcommn.GetLimits(index);


            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand("", con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@PlateNumber", platenuber);
                    cmd.Parameters.AddWithValue("@lowerlimit", limits.Item1);
                    cmd.Parameters.AddWithValue("@upperlimit", limits.Item2);
                    cmd.Parameters.AddWithValue("@LabID", LabID);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        if (usertype == "Admin")
                        {


                            cmd.CommandText = DBQueries.GetLabIDforResultAdmiin;
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dt);
                            return Tuple.Create(dt, 1);
                        }
                        else
                        {


                            cmd.CommandText = DBQueries.GetLabIDforResult;
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dt);
                            return Tuple.Create(dt, 1);
                        }

                    }
                    catch (MySqlException sqlEx)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    catch (Exception ex)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }

        public int UpdateResult(List<Sample> objsample)
        {
            Commn objcomn = new Commn();
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


            MySqlTransaction transaction = null;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand("RESULTS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();

                        }
                        transaction = con.BeginTransaction();
                        cmd.Parameters.Clear();
                        cmd.Transaction = transaction;

                        foreach (Sample obj in objsample)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@Result", obj.TResult);
                            cmd.Parameters.AddWithValue("@LabID", obj.LabId);
                            cmd.Parameters.AddWithValue("@ResultById", obj.ResultById);
                            cmd.Parameters.AddWithValue("@ModifiedById", obj.ResultById);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

        }

        public DataTable GetTestingKit()
        {
            DataTable dt = new DataTable();
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.GetTestingKits, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();



                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        return dt;

                    }
                    catch (MySqlException sqlEx)
                    {

                        return dt;
                    }
                    catch (Exception ex)
                    {

                        return dt;
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }

        public Tuple<DataTable, int> GetICMRData(string fromdate, string todate, string index)
        {
            Commn objcommn = new Commn();

            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            DataTable dt = new DataTable();
            var limits = objcommn.GetLimits(index);
            if (string.IsNullOrEmpty(fromdate))
            {
                fromdate = "2021/05/01";
            }
            if (string.IsNullOrEmpty(todate))
            {
                todate = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            }
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.GetICMRCount, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();
                    //cmd.Parameters.AddWithValue("@dateformat2", dateformat2);
                    cmd.Parameters.AddWithValue("@lowerlimit", limits.Item1);
                    cmd.Parameters.AddWithValue("@upperlimit", limits.Item2);
                    cmd.Parameters.AddWithValue("@FromDate", fromdate);
                    cmd.Parameters.AddWithValue("@ToDate", todate);
                    cmd.Parameters.AddWithValue("@dateformat2", dateformat2);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }


                        DataTable dp = new DataTable();
                        cmd.CommandText = DBQueries.GetICMRCount;
                        MySqlDataAdapter dap = new MySqlDataAdapter(cmd);
                        dap.Fill(dp);


                        cmd.CommandText = DBQueries.GetICMRData;
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        return Tuple.Create(dt, dp.Rows.Count);


                    }
                    catch (MySqlException sqlEx)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    catch (Exception ex)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }

        }

        public Tuple<int, string> GenerateICMRData(ICMR obj)
        {
            //string date = Convert.ToDateTime(obj.CollectionDate).ToString();
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            var path = Tuple.Create("", "");
            MySqlTransaction transaction = null;
            Commn objcomn = new Commn();
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.InsertICMR, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@FromDate", obj.Fromdate);
                    cmd.Parameters.AddWithValue("@ToDate", (obj.ToDate));
                    cmd.Parameters.AddWithValue("@CollectionDate", (obj.CollectionDate));
                    cmd.Parameters.AddWithValue("@ReceivingDate", (obj.ReceivingDate));
                    cmd.Parameters.AddWithValue("@TestingDate", (obj.TestingDate));
                    cmd.Parameters.AddWithValue("@kit", obj.KitID);
                    cmd.Parameters.AddWithValue("@ICMRReportUser", obj.UserID);

                    try
                    {
                        int reportID = 0;
                        con.Open();
                        transaction = con.BeginTransaction();
                        cmd.Transaction = transaction;


                        int output = cmd.ExecuteNonQuery();
                        if (output == 0)
                        {
                            transaction.Rollback();
                            return Tuple.Create(0, "");

                        }
                        else
                        {
                            cmd.CommandText = DBQueries.GetreportID;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@ICMRReportUser", obj.UserID);
                            reportID = Convert.ToInt32(cmd.ExecuteScalar());

                            if (reportID == 0)
                            {
                                transaction.Rollback();
                                return Tuple.Create(0, "");
                            }
                            else
                            {

                                cmd.CommandText = DBQueries.GetICMRExcel;
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@FromDate", obj.Fromdate);
                                cmd.Parameters.AddWithValue("@ToDate", obj.ToDate);
                                cmd.Parameters.AddWithValue("@CollectionDate", obj.CollectionDate);
                                cmd.Parameters.AddWithValue("@Receivedate", obj.ReceivingDate);
                                cmd.Parameters.AddWithValue("@Testingdate", obj.TestingDate);
                                cmd.Parameters.AddWithValue("@TestingKit", obj.KitID);
                                cmd.Parameters.AddWithValue("@dateformat3", dateformat3);

                                DataTable dt = new DataTable();
                                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                                da.Fill(dt);

                                if (dt.Rows.Count == 0)
                                {
                                    transaction.Rollback();
                                    return Tuple.Create(0, "");

                                }
                                else
                                {
                                    path = objcomn.ExportToExcel(dt, reportID.ToString(), 2, string.Empty);

                                    cmd.CommandText = DBQueries.UpdateICMRForSample;
                                    cmd.Parameters.Clear();
                                    cmd.Parameters.AddWithValue("@ReportId", reportID);
                                    cmd.Parameters.AddWithValue("@FromDate", obj.Fromdate);
                                    cmd.Parameters.AddWithValue("@ToDate", obj.ToDate);

                                    int count = Convert.ToInt32(cmd.ExecuteNonQuery());

                                    if (count == 0)
                                    {
                                        transaction.Rollback();
                                        return Tuple.Create(0, "");

                                    }
                                    else
                                    {
                                        cmd.CommandText = DBQueries.UpdateICMR;
                                        cmd.Parameters.Clear();
                                        cmd.Parameters.AddWithValue("@GeneratedFileLink", path.Item1);
                                        cmd.Parameters.AddWithValue("@ReportId", reportID);
                                        cmd.Parameters.AddWithValue("@ICMRReportUser", obj.UserID);
                                        int count1 = Convert.ToInt32(cmd.ExecuteNonQuery());

                                        if (count1 == 0)
                                        {

                                            transaction.Rollback();
                                            return Tuple.Create(0, "");
                                        }
                                    }
                                }

                            }

                        }
                        transaction.Commit();
                        return Tuple.Create(1, path.Item1);
                    }
                    catch (MySqlException sqlEx)
                    {
                        transaction.Rollback();
                        return Tuple.Create(0, "");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return Tuple.Create(0, "");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public int CreateUser(User objusr)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.InsertUser, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@username", objusr.UserName);
                    cmd.Parameters.AddWithValue("@password", objusr.Password);
                    cmd.Parameters.AddWithValue("@usertypeid", objusr.UserTypeId);
                    cmd.Parameters.AddWithValue("@loggedinuserid", objusr.CreatedBy);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public int EditUser(User objusr)
        {
            string strDBQry = "";

            if (string.IsNullOrEmpty(objusr.Password))
            {
                strDBQry = "UpdateuserPasswordNull";

            }
            else
            {
                strDBQry = "UpdateuserWithPassword";
            }
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(strDBQry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Clear();


                    cmd.Parameters.AddWithValue("@username", objusr.UserName);
                    cmd.Parameters.AddWithValue("@password", objusr.Password);
                    cmd.Parameters.AddWithValue("@IsActive", objusr.IsActive);
                    cmd.Parameters.AddWithValue("@usertypeid", objusr.UserTypeId);
                    cmd.Parameters.AddWithValue("@loggedinuserid", objusr.CreatedBy);
                    cmd.Parameters.AddWithValue("@UserId", objusr.UserId);



                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public Tuple<DataTable, int> GetAllUsers(User obj)
        {
            Commn objcommn = new Commn();

            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            DataTable dt = new DataTable();
            var limits = objcommn.GetLimits(obj.Index);

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand("", con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@lowerlimit", limits.Item1);
                    cmd.Parameters.AddWithValue("@upperlimit", limits.Item2);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        if (string.IsNullOrEmpty(obj.UserName))
                        {
                            cmd.CommandText = DBQueries.GetAllUsersCount;
                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            cmd.CommandText = DBQueries.GetAllUsers;
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dt);
                            return Tuple.Create(dt, count);
                        }
                        else
                        {
                            string strDBQry = DBQueries.GetUser.Replace("@username", obj.UserName);
                            cmd.Parameters.Clear();

                            cmd.CommandText = strDBQry;

                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dt);
                            return Tuple.Create(dt, dt.Rows.Count);

                        }

                    }
                    catch (MySqlException sqlEx)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    catch (Exception ex)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }

        public Tuple<DataTable, int> GetUser(string username)
        {
            DataTable dt = new DataTable();
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.GetUser, con))
                {
                    cmd.CommandType = CommandType.Text;


                    string strDBQry = DBQueries.GetUser.Replace("@username", username);
                    cmd.Parameters.Clear();

                    cmd.CommandText = strDBQry;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        return Tuple.Create(dt, dt.Rows.Count);

                    }
                    catch (MySqlException sqlEx)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    catch (Exception ex)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }


        public DataTable GetUserTypes()
        {
            DataTable dt = new DataTable();
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.GetUserTypes, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();



                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        return dt;

                    }
                    catch (MySqlException sqlEx)
                    {

                        return dt;
                    }
                    catch (Exception ex)
                    {

                        return dt;
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }


        public int CreatePHC(Hospital obj)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.InsertHospital, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@PHC", obj.PHC);
                    cmd.Parameters.AddWithValue("@code", obj.Code);
                    cmd.Parameters.AddWithValue("@zone", obj.Zone);
                    cmd.Parameters.AddWithValue("@email", obj.Email);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public int EditPHC(Hospital obj)
        {

            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.UpdateHospital, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();


                    cmd.Parameters.AddWithValue("@PHC", obj.PHC);
                    cmd.Parameters.AddWithValue("@Code", obj.Code);
                    cmd.Parameters.AddWithValue("@Zone", obj.Zone);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
                    cmd.Parameters.AddWithValue("@HospitalId", obj.HospitalId);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public Tuple<DataTable, int> GetAllPHC(Hospital obj)
        {
            Commn objcommn = new Commn();

            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            DataTable dt = new DataTable();
            var limits = objcommn.GetLimits(obj.Index);

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand("", con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@lowerlimit", limits.Item1);
                    cmd.Parameters.AddWithValue("@upperlimit", limits.Item2);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        if (string.IsNullOrEmpty(obj.PHC))
                        {
                            cmd.CommandText = DBQueries.GetHospitalsCount;
                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            cmd.CommandText = DBQueries.GetHospitals_N;
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dt);
                            return Tuple.Create(dt, count);
                        }
                        else
                        {
                            string strDBQry = DBQueries.GetPHC.Replace("@PHC", obj.PHC);
                            cmd.Parameters.Clear();

                            cmd.CommandText = strDBQry;

                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dt);
                            return Tuple.Create(dt, dt.Rows.Count);

                        }

                    }
                    catch (MySqlException sqlEx)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    catch (Exception ex)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }

        public int CreateKit(Kit obj)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.InsertTestingKit, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@kitname", obj.TestingKitName);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public int EditKit(Kit obj)
        {

            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.UpdateTestingKit, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();


                    cmd.Parameters.AddWithValue("@kitname", obj.TestingKitName);
                    cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
                    cmd.Parameters.AddWithValue("@TestingKitId", obj.TestingKitId);


                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                    catch (MySqlException sqlEx)
                    {

                        return 0;
                    }
                    catch (Exception ex)
                    {

                        return 0;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public Tuple<DataTable, int> GetAllkits(Kit obj)
        {
            Commn objcommn = new Commn();

            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            DataTable dt = new DataTable();
            var limits = objcommn.GetLimits(obj.Index);

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand("", con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@lowerlimit", limits.Item1);
                    cmd.Parameters.AddWithValue("@upperlimit", limits.Item2);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        if (string.IsNullOrEmpty(obj.TestingKitName))
                        {
                            cmd.CommandText = DBQueries.GetTestingKitCount;
                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            cmd.CommandText = DBQueries.GetTestingKits_N;
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dt);
                            return Tuple.Create(dt, count);
                        }
                        else
                        {
                            string strDBQry = DBQueries.GetTestingKit.Replace("@kitname", obj.TestingKitName);
                            cmd.Parameters.Clear();

                            cmd.CommandText = strDBQry;

                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dt);
                            return Tuple.Create(dt, dt.Rows.Count);

                        }

                    }
                    catch (MySqlException sqlEx)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    catch (Exception ex)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }

        #endregion

        #region Nandeep code





        //BOC Report methods
        public Tuple<List<BulkReceivedOutput>, int> BulkReceived(ReportInput reportInput)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            Commn objcommn = new Commn();
            var limits = objcommn.GetLimits_P100(reportInput.Index);

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(DBQueries.GetBulkReceivedReport, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();


                    cmd.Parameters.AddWithValue("@FromDate", reportInput.FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", reportInput.ToDate);
                    cmd.Parameters.AddWithValue("@lowerlimit", limits.Item1);
                    cmd.Parameters.AddWithValue("@upperlimit", limits.Item2);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        MySqlDataReader reader = cmd.ExecuteReader();
                        List<BulkReceivedOutput> result = new List<BulkReceivedOutput>();
                        while (reader.Read())
                        {
                            BulkReceivedOutput entry = new BulkReceivedOutput();

                            if (reader["bulknumber"] != DBNull.Value)
                                entry.Bulknumber = Convert.ToInt32(reader["bulknumber"].ToString());

                            if (reader["ImportedDate"] != DBNull.Value)
                                entry.ImportedDate = Convert.ToDateTime(reader["ImportedDate"].ToString());

                            if (reader["UserName"] != DBNull.Value)
                                entry.UserName = (reader["UserName"].ToString());

                            if (reader["UserType"] != DBNull.Value)
                                entry.UserType = reader["UserType"].ToString();

                            if (reader["ExcelLink"] != DBNull.Value)
                                entry.ExcelLink = reader["ExcelLink"].ToString();
                            result.Add(entry);
                        }

                        reader.Close();

                        cmd.CommandText = DBQueries.GetBulkReceivedReportCount;

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        return Tuple.Create(result, count);

                        // return result;
                    }
                    catch (MySqlException sqlEx)
                    {
                        return null;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }

        public Tuple<List<BulkOutput>, int> Bulk(ReportInput reportInput)
        {
            string strDBQuery = "";
            string strDBQueryCount = "";

            if (reportInput.BulkNumber == 0)
            {
                strDBQuery = DBQueries.GetBulkReportwNull;
                strDBQueryCount = DBQueries.GetBulkReportwNullCount;
            }
            else
            {
                strDBQuery = DBQueries.GetBulkReport;
                strDBQueryCount = DBQueries.GetBulkReportCount;
            }

            Commn objcommn = new Commn();
            var limits = objcommn.GetLimits_P100(reportInput.Index);

            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(strDBQuery, con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Clear();


                    cmd.Parameters.AddWithValue("@FromDate", reportInput.FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", reportInput.ToDate);
                    cmd.Parameters.AddWithValue("@bulknumber", reportInput.BulkNumber);
                    cmd.Parameters.AddWithValue("@lowerlimit", limits.Item1);
                    cmd.Parameters.AddWithValue("@upperlimit", limits.Item2);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        MySqlDataReader reader = cmd.ExecuteReader();
                        List<BulkOutput> result = new List<BulkOutput>();
                        while (reader.Read())
                        {
                            BulkOutput entry = new BulkOutput();

                            if (reader["BulkNumber"] != DBNull.Value)
                                entry.BulkNumber = Convert.ToInt32(reader["BulkNumber"]);

                            if (reader["ImportDate"] != DBNull.Value)
                                entry.ImportDate = Convert.ToDateTime(reader["ImportDate"]);

                            if (reader["PHC"] != DBNull.Value)
                                entry.PHC = (reader["PHC"].ToString());

                            entry.TotalCount = Convert.ToInt32(reader["TotalCount"]);

                            if (reader["UnderProcessCount"] != DBNull.Value)
                                entry.UnderProcessCount = Convert.ToInt32(reader["UnderProcessCount"]);

                            if (reader["ProcessedCount"] != DBNull.Value)
                                entry.ProcessedCount = Convert.ToInt32(reader["ProcessedCount"]);

                            if (reader["PositiveCount"] != DBNull.Value)
                                entry.PositiveCount = Convert.ToInt32(reader["PositiveCount"]);

                            if (reader["NegativeCount"] != DBNull.Value)
                                entry.NegativeCount = Convert.ToInt32(reader["NegativeCount"]);

                            if (reader["RejectedCount"] != DBNull.Value)
                                entry.RejectedCount = Convert.ToInt32(reader["RejectedCount"]);


                            result.Add(entry);
                        }


                        reader.Close();

                        cmd.CommandText = strDBQueryCount;

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        return Tuple.Create(result, count);

                        //  return result;
                    }
                    catch (MySqlException sqlEx)
                    {
                        return null;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }


        public List<BulkPlusOutput> BulkPlus(ReportInput reportInput)
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand("BulkReportPlus", con))
                {
                    // cmd.CommandType = CommandType.Text;
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Clear();


                    cmd.Parameters.AddWithValue("@FromDate", reportInput.FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", reportInput.ToDate);
                    cmd.Parameters.AddWithValue("@BulkNumber", reportInput.BulkNumber);
                    cmd.Parameters.AddWithValue("@Results", reportInput.Result);
                    cmd.Parameters.AddWithValue("@IsProcessed", reportInput.Status);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        MySqlDataReader reader = cmd.ExecuteReader();
                        List<BulkPlusOutput> result = new List<BulkPlusOutput>();
                        while (reader.Read())
                        {
                            BulkPlusOutput entry = new BulkPlusOutput();

                            if (reader["BulkNumber"] != DBNull.Value)
                                entry.BulkNumber = Convert.ToInt32(reader["BulkNumber"]);

                            if (reader["ImportDate"] != DBNull.Value)
                                entry.ImportDate = Convert.ToDateTime(reader["ImportDate"]);

                            if (reader["LabId"] != DBNull.Value)
                                entry.LabId = Convert.ToString(reader["LabId"]);

                            if (reader["Status2"] != DBNull.Value)
                                entry.Status2 = Convert.ToString(reader["Status2"]);

                            if (reader["Result"] != DBNull.Value)
                                entry.Result = Convert.ToString(reader["Result"]);

                            result.Add(entry);
                        }
                        return result;
                    }
                    catch (MySqlException sqlEx)
                    {
                        return null;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }

        public Tuple<List<SampleReceiveOutput>, int> SampleReceive(ReportInput reportInput)
        {
            string strDBQuery = "";
            string strDBQueryCount = "";
            Commn objcommn = new Commn();
            var limits = objcommn.GetLimits_P100(reportInput.Index);

            if ((reportInput.LabId == null) || (reportInput.LabId == ""))
            {
                strDBQuery = "SampleReceiveReportNoLabID";
                strDBQueryCount = "SampleReceiveReportNoLabIDCount";
            }
            else
            {
                strDBQuery = "SampleReceiveReportWithLabID";
                strDBQueryCount = "SampleReceiveReportWithLabIDCount";
            }
            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(strDBQuery, con))
                {
                    // cmd.CommandType = CommandType.Text;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Clear();


                    cmd.Parameters.AddWithValue("@FromDate", reportInput.FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", reportInput.ToDate);
                    cmd.Parameters.AddWithValue("@Results", reportInput.Result);
                    cmd.Parameters.AddWithValue("@IsProcessed", reportInput.Status);
                    cmd.Parameters.AddWithValue("@lowerlimit", limits.Item1);
                    cmd.Parameters.AddWithValue("@upperlimit", limits.Item2);

                    if (!((reportInput.LabId == null) || (reportInput.LabId == "")))
                    {
                        cmd.Parameters.AddWithValue("@LabId", reportInput.LabId);
                    }


                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        MySqlDataReader reader = cmd.ExecuteReader();
                        List<SampleReceiveOutput> result = new List<SampleReceiveOutput>();
                        while (reader.Read())
                        {
                            SampleReceiveOutput entry = new SampleReceiveOutput();

                            if (reader["BulkNumber"] != DBNull.Value)
                                entry.BulkNumber = Convert.ToInt32(reader["BulkNumber"]);

                            if (reader["ImportDate"] != DBNull.Value)
                                entry.ImportDate = Convert.ToDateTime(reader["ImportDate"]);

                            if (reader["LabId"] != DBNull.Value)
                                entry.LabId = Convert.ToString(reader["LabId"]);

                            if (reader["Status2"] != DBNull.Value)
                                entry.Status2 = Convert.ToString(reader["Status2"]);

                            if (reader["Result"] != DBNull.Value)
                                entry.Result = Convert.ToString(reader["Result"]);

                            if (reader["Name"] != DBNull.Value)
                                entry.Name = Convert.ToString(reader["Name"]);

                            if (reader["SRFID"] != DBNull.Value)
                                entry.SRFID = Convert.ToString(reader["SRFID"]);

                            if (reader["Gender"] != DBNull.Value)
                                entry.Gender = Convert.ToString(reader["Gender"]);

                            if (reader["PHC"] != DBNull.Value)
                                entry.PHC = Convert.ToString(reader["PHC"]);

                            if (reader["Age"] != DBNull.Value)
                                entry.Age = Convert.ToInt32(reader["Age"]);

                            result.Add(entry);
                        }
                        reader.Close();

                        cmd.CommandText = strDBQueryCount;

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        //Nanddeep
                        // return result;
                        return Tuple.Create(result, count);
                    }
                    catch (MySqlException sqlEx)
                    {
                        return null;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }

        public Tuple<List<SampleOutput>, int> Sample(ReportInput reportInput)
        {

            Commn objcommn = new Commn();
            var limits = objcommn.GetLimits_P100(reportInput.Index);

            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand("SampleReport", con))
                {
                    // cmd.CommandType = CommandType.Text;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Clear();


                    cmd.Parameters.AddWithValue("@FromDate", reportInput.FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", reportInput.ToDate);
                    cmd.Parameters.AddWithValue("@PHC", reportInput.PHC);
                    cmd.Parameters.AddWithValue("@lowerlimit", limits.Item1);
                    cmd.Parameters.AddWithValue("@upperlimit", limits.Item2);
                    //   cmd.Parameters.Add("@PHC", MySqlDbType.VarChar, 1000).Value = reportInput.PHC;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        MySqlDataReader reader = cmd.ExecuteReader();
                        List<SampleOutput> result = new List<SampleOutput>();
                        while (reader.Read())
                        {
                            SampleOutput entry = new SampleOutput();

                            if (reader["HospitalId"] != DBNull.Value)
                                entry.HospitalId = Convert.ToInt32(reader["HospitalId"]);

                            if (reader["PHC"] != DBNull.Value)
                                entry.PHC = Convert.ToString(reader["PHC"]);

                            if (reader["TotalCount"] != DBNull.Value)
                                entry.TotalCount = Convert.ToInt32(reader["TotalCount"]);

                            if (reader["UnderProcessCount"] != DBNull.Value)
                                entry.UnderProcessCount = Convert.ToInt32(reader["UnderProcessCount"]);

                            if (reader["ProcessedCount"] != DBNull.Value)
                                entry.ProcessedCount = Convert.ToInt32(reader["ProcessedCount"]);

                            if (reader["PositiveCount"] != DBNull.Value)
                                entry.PositiveCount = Convert.ToInt32(reader["PositiveCount"]);

                            if (reader["NegativeCount"] != DBNull.Value)
                                entry.NegativeCount = Convert.ToInt32(reader["NegativeCount"]);

                            if (reader["RejectedCount"] != DBNull.Value)
                                entry.RejectedCount = Convert.ToInt32(reader["RejectedCount"]);

                            result.Add(entry);
                        }

                        reader.Close();

                        cmd.CommandText = "SampleReportCount";

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        return Tuple.Create(result, count);
                        //  return result;
                    }
                    catch (MySqlException sqlEx)
                    {
                        return null;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }


        public List<SamplePlusOutput> SamplePlus(ReportInput reportInput)
        {

            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand("SampleReportPlus", con))
                {
                    // cmd.CommandType = CommandType.Text;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@HospitalId", reportInput.HospitalID);
                    cmd.Parameters.AddWithValue("@FromDate", reportInput.FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", reportInput.ToDate);
                    cmd.Parameters.AddWithValue("@Results", reportInput.Result);
                    cmd.Parameters.AddWithValue("@IsProcessed", reportInput.Status);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        MySqlDataReader reader = cmd.ExecuteReader();
                        List<SamplePlusOutput> result = new List<SamplePlusOutput>();
                        while (reader.Read())
                        {
                            SamplePlusOutput entry = new SamplePlusOutput();

                            if (reader["PHC"] != DBNull.Value)
                                entry.PHC = Convert.ToString(reader["PHC"]);

                            if (reader["ImportedDate"] != DBNull.Value)
                                entry.ImportedDate = Convert.ToDateTime(reader["ImportedDate"]);

                            if (reader["BulkNumber"] != DBNull.Value)
                                entry.BulkNumber = Convert.ToInt32(reader["BulkNumber"]);

                            if (reader["LabId"] != DBNull.Value)
                                entry.LabId = Convert.ToString(reader["LabId"]);

                            if (reader["Status2"] != DBNull.Value)
                                entry.Status2 = Convert.ToString(reader["Status2"]);

                            if (reader["Result"] != DBNull.Value)
                                entry.Result = Convert.ToString(reader["Result"]);

                            result.Add(entry);
                        }
                        return result;
                    }
                    catch (MySqlException sqlEx)
                    {
                        return null;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
        }

        public Tuple<DataTable, int> BulkPlate(ReportInput reportInput)
        {
            string strDBQuery = "";
            string strDBQueryCount = "";

            if ((reportInput.BulkNumber == 0) && (reportInput.PlateNo == null))
            {
                strDBQuery = "BulkPlateReportBothNull";
                strDBQueryCount = "BulkPlateReportBothNullCount";
            }
            else if ((reportInput.BulkNumber != 0) && (reportInput.PlateNo == null))
            {
                strDBQuery = "BulkPlateReportPlateNull";
                strDBQueryCount = "BulkPlateReportPlateNullCount";
            }
            else if ((reportInput.BulkNumber == 0) && (reportInput.PlateNo != null))
            {
                strDBQuery = "BulkPlateReportBulkNull";
                strDBQueryCount = "BulkPlateReportBulkNullCount";
            }
            else if ((reportInput.BulkNumber != 0) && (reportInput.PlateNo != null))
            {
                strDBQuery = "BulkPlateReport";
                strDBQueryCount = "BulkPlateReportCount";
            }
            //else
            //{
            //    strDBQuery = DBQueries.GetBulkReport;
            //}

            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            Commn objcommn = new Commn();
            var limits = objcommn.GetLimits_P100(reportInput.Index);

            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand("", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Clear();
                    //cmd.Parameters.AddWithValue("@dateformat2", dateformat2);
                    //cmd.Parameters.AddWithValue("@dateformat1", dateformat1);
                    cmd.Parameters.AddWithValue("@FromDate", reportInput.FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", reportInput.ToDate);
                    cmd.Parameters.AddWithValue("@bulk", reportInput.BulkNumber);
                    cmd.Parameters.AddWithValue("@plate", reportInput.PlateNo);
                    cmd.Parameters.AddWithValue("@lowerlimit", limits.Item1);
                    cmd.Parameters.AddWithValue("@upperlimit", limits.Item2);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        cmd.CommandText = strDBQueryCount;

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd.CommandText = strDBQuery;
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        return Tuple.Create(dt, count);
                    }
                    catch (MySqlException sqlEx)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    catch (Exception ex)
                    {

                        return Tuple.Create(dt, 0);
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }

        }

        public Tuple<DataTable, DataTable> PlateData(ReportInput reportInput)
        {
            string strDBQuery = "BulkPlatePlateData";
            string strDBQueryCount = "BulkPlatePlateDataCount";


            string _connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            DataTable dtcount = new DataTable();
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand("", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@plate", reportInput.PlateNo);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        cmd.CommandText = strDBQueryCount;

                        //int count = Convert.ToInt32(cmd.ExecuteScalar());
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dtcount);

                        cmd.CommandText = strDBQuery;
                        //  MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        return Tuple.Create(dt, dtcount);
                    }
                    catch (MySqlException sqlEx)
                    {

                        return Tuple.Create(dt, dtcount);
                    }
                    catch (Exception ex)
                    {

                        return Tuple.Create(dt, dtcount);
                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }

        }


        //EOC Report methods



        #endregion

    }
}