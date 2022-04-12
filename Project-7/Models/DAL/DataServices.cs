using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using Project_7.Models;
using System.Data;


namespace Project_7.Models.DAL
{


    public class DataServices
    {

        SqlConnection Connect(string connectionStringName)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            return con;
        }


        //גייטפסים

        public List<GatePass> ReadgatePass()
        {
            SqlConnection con = null;

            try
            {
                con = Connect("FinalProject");
                SqlCommand selectCommand = CreateSelectCommandGatePass(con);
                List<GatePass> gatePassList = new List<GatePass>();
                SqlDataReader dataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    GatePass a =new GatePass();
                    a.Id = Convert.ToInt32(dataReader["GPS_Id"]);
                    a.ContainerNum = (string)dataReader["GPS_ContainerNum"];
                    a.ContainerType = (string)dataReader["GPS_ContainerType"];
                    a.TransportCompany = (string)dataReader["GPS_TransportCompany"];
                    a.Importer = (string)dataReader["GPS_Importer"];
                    a.Note = (string)dataReader["GPS_Note"];
                    a.CreatedDate = (DateTime)dataReader["GPS_CreatedDate"];

                    gatePassList.Add(a);
                }
                return gatePassList;
            }
            catch (Exception ex)
            {

                throw new Exception("failed in reading of GatePass list", ex);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }

        //data set 
        private SqlCommand CreateSelectCommandGatePass(SqlConnection con)
        {
            string commandStr = "SELECT * FROM SHAY_GatePass WHERE GPS_IsActive=N'+'";
            SqlCommand cmd = createCommand(con, commandStr);
 
            return cmd;
        }




        //יצירת גייטפס
        public int InsertGatePass(GatePass g)
        {
            //int res = 0;
            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("NewGatePass", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ContainerNum", g.ContainerNum);
                    cmd.Parameters.AddWithValue("@ContainerType", g.ContainerType);
                    cmd.Parameters.AddWithValue("@TransportCompany", g.TransportCompany);
                    cmd.Parameters.AddWithValue("@Importer", g.Importer);
                    cmd.Parameters.AddWithValue("@CustomsBroker", g.CustomsBroker);
                    cmd.Parameters.AddWithValue("@ShippingCompanyAndLine", g.ShippingCompanyAndLine);
                    cmd.Parameters.AddWithValue("@StorageCertificate", g.StorageCertificate);
                    cmd.Parameters.AddWithValue("@CaseNumber", g.CaseNumber);
                    cmd.Parameters.AddWithValue("@Note", g.Note);
                    cmd.Parameters.AddWithValue("@OfficeNote", g.OfficeNote);
                    cmd.Parameters.AddWithValue("@GoToRepair", g.GoToRepair);
                    cmd.Parameters.AddWithValue("@ReturnFromRepair", g.ReturnFromRepair);
                    cmd.Parameters.AddWithValue("@IsActive", g.IsActive);
                    cmd.Parameters.AddWithValue("@UserEmail", g.UserEmail);
                    cmd.Parameters.AddWithValue("@CreatedDate", g.CreatedDate);

                    //var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
                    //returnParameter.Direction = ParameterDirection.ReturnValue;
                    //cmd.ExecuteNonQuery();
                    //var result = returnParameter.Value;
                    numEffected = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return numEffected;
        }






        //with Procedure
        public int UpdateGatePass(GatePass g)
        {
            //int res = 0;
            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("UpdateGatePass", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", g.Id);
                    cmd.Parameters.AddWithValue("@ContainerNum", g.ContainerNum);
                    cmd.Parameters.AddWithValue("@ContainerType", g.ContainerType);
                    cmd.Parameters.AddWithValue("@TransportCompany", g.TransportCompany);
                    cmd.Parameters.AddWithValue("@Importer", g.Importer);
                    //cmd.Parameters.AddWithValue("@CustomsBroker", g.CustomsBroker);
                    //cmd.Parameters.AddWithValue("@ShippingCompanyAndLine", g.ShippingCompanyAndLine);
                    //cmd.Parameters.AddWithValue("@StorageCertificate", g.StorageCertificate);
                    //cmd.Parameters.AddWithValue("@CaseNumber", g.CaseNumber);
                    //cmd.Parameters.AddWithValue("@Note", g.Note);
                    //cmd.Parameters.AddWithValue("@OfficeNote", g.OfficeNote);
                    //cmd.Parameters.AddWithValue("@GoToRepair", g.GoToRepair);
                    //cmd.Parameters.AddWithValue("@ReturnFromRepair", g.ReturnFromRepair);
                    //cmd.Parameters.AddWithValue("@IsActive", g.IsActive);
                    //cmd.Parameters.AddWithValue("@UserEmail", g.UserEmail);
                    //cmd.Parameters.AddWithValue("@CreatedDate", g.CreatedDate);

                    //var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
                    //returnParameter.Direction = ParameterDirection.ReturnValue;
                    //cmd.ExecuteNonQuery();
                    //var result = returnParameter.Value;
                    numEffected = cmd.ExecuteNonQuery();

                    //if (result.Equals(1))
                    //{
                    //    res = 1;

                    //}
                    //return res;
                }
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return numEffected;
        }










        public int InsertDriver(Driver d)
        {
            //int res = 0;
            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("NewDriver", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DriverId", d.DriverID);
                        cmd.Parameters.AddWithValue("@TransportCompany", d.TransportComany);
                        cmd.Parameters.AddWithValue("@FirstName", d.DriverFname);
                        cmd.Parameters.AddWithValue("@LastName", d.DriverLname);
                        cmd.Parameters.AddWithValue("@PhoneNumber", d.DriverPhone);
                        cmd.Parameters.AddWithValue("@LicenceType", d.DriverLicense);



                        numEffected = cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return numEffected;
        }







        //טבלה גייטפס- ארכיון

        public List<GatePass> ReadNegativGatePass(string isActive)
        {
            SqlConnection con = null;

            try
            {
                con = Connect("FinalProject");
                SqlCommand selectCommand = CreateSelectCommandNegGatePass(con, isActive);
                List<GatePass> GatePassList = new List<GatePass>();
                SqlDataReader dataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    GatePass g = new GatePass();

                    g.Id = Convert.ToInt32(dataReader["GPS_Id"]);
                    g.ContainerNum = (string)dataReader["GPS_ContainerNum"];
                    g.ContainerType = (string)dataReader["GPS_ContainerType"];
                    g.TransportCompany = (string)dataReader["GPS_TransportCompany"];
                    g.Importer = (string)dataReader["GPS_Importer"];
                    g.CreatedDate = Convert.ToDateTime(dataReader["GPS_CreatedDate"]);

                    GatePassList.Add(g);
                }
                return GatePassList;
            }
            catch (Exception ex)
            {

                throw new Exception("failed in reading of Negetive GatePass list", ex);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
        private SqlCommand CreateSelectCommandNegGatePass(SqlConnection con,string isActive)
        {
            string commandStr = "SELECT * FROM SHAY_GatePass WHERE GPS_IsActive=@isActive";
            SqlCommand cmd = createCommand(con, commandStr);
            cmd.Parameters.Add("@isActive", SqlDbType.NVarChar);
            cmd.Parameters["@isActive"].Value = isActive;
            return cmd;
        }







        //הגייטפסים שלי

        public List<GatePass> ReadMygatePass(string userType, string transportCompany)
        {
            SqlConnection con = null;

            try
            {
                con = Connect("FinalProject");
                SqlCommand selectCommand = CreateSelectCommandMyGatePass(con, userType, transportCompany);
                List<GatePass> MyGatePassList = new List<GatePass>();
                SqlDataReader dataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    GatePass g = new GatePass();

                    g.Id = Convert.ToInt32(dataReader["GPS_Id"]);
                    g.ContainerNum = (string)dataReader["GPS_ContainerNum"];
                    g.ContainerType = (string)dataReader["GPS_ContainerType"];
                    g.TransportCompany = (string)dataReader["GPS_TransportCompany"];
                    g.Importer = (string)dataReader["GPS_Importer"];
                    g.CreatedDate = Convert.ToDateTime(dataReader["GPS_CreatedDate"]);

                    MyGatePassList.Add(g);
                }
                return MyGatePassList;
            }
            catch (Exception ex)
            {

                throw new Exception("failed in reading of my GatePass list", ex);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
        private SqlCommand CreateSelectCommandMyGatePass(SqlConnection con,string userType, string transportCompany)
        {
            string commandStr = "select * from SHAY_GatePass G inner join SHAY_TransportCompany T on G.GPS_TransportCompany = T.TPC_CompanyName inner join SHAY_User U on T.TPC_CompanyName = U.USR_Company WHERE GPS_IsActive = '+' AND USR_Type = @userType AND GPS_TransportCompany = @transportCompany";
                                         
                           
            SqlCommand cmd = createCommand(con, commandStr);
            cmd.Parameters.Add("@transportCompany", SqlDbType.NVarChar);
            cmd.Parameters["@transportCompany"].Value = transportCompany;
            cmd.Parameters.Add("@userType", SqlDbType.NVarChar);
            cmd.Parameters["@userType"].Value = userType;
            return cmd;
        }









        //Driver Actions
        public List<Driver> ReadDrivers()
        {
            SqlConnection con = null;

            try
            {
                con = Connect("FinalProject");
                SqlCommand selectCommand = CreateSelectCommandDrivers(con);
                List<Driver> DriversList = new List<Driver>();
                SqlDataReader dataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    Driver d = new Driver();
                    d.DriverID = Convert.ToInt32(dataReader["DRI_DriverId"]);
                    d.TransportComany = (string)dataReader["DRI_TransportCompany"];
                    d.DriverFname = (string)dataReader["DRI_Fname"];
                    d.DriverLname = (string)dataReader["DRI_Lname"];
                    d.DriverPhone = (string)dataReader["DRI_PhoneNumber"];
                    d.DriverLicense = (string)dataReader["DRI_licenseType"];


                    DriversList.Add(d);
                }
                return DriversList;
            }
            catch (Exception ex)
            {

                throw new Exception("failed in reading of Drivers list", ex);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
        private SqlCommand CreateSelectCommandDrivers(SqlConnection con)
        {
            string commandStr = "SELECT * FROM SHAY_Driver ";
            SqlCommand cmd = createCommand(con, commandStr);

            return cmd;
        }




        //טבלה חברות הובלה
        public List<TransportCompany> ReadTransportCompany()
        {
            SqlConnection con = null;

            try
            {
                con = Connect("FinalProject");
                SqlCommand selectCommand = CreateSelectCommandTransportCompany(con);
                List<TransportCompany> TransportCompanyList = new List<TransportCompany>();
                SqlDataReader dataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    TransportCompany t = new TransportCompany();

                    t.CompanyId = Convert.ToInt32(dataReader["TPC_Id"]);
                    t.CompanyName = (string)dataReader["TPC_CompanyName"];
                    t.CompanyAdress = (string)dataReader["TPC_Adress"];
                    t.CompanyFax = (string)dataReader["TPC_Fax"];
                    t.CompanyPhone = (string)dataReader["TPC_PhoneNumber"];


                    TransportCompanyList.Add(t);
                }
                return TransportCompanyList;
            }
            catch (Exception ex)
            {

                throw new Exception("failed in reading of TransportCompany List", ex);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
        private SqlCommand CreateSelectCommandTransportCompany(SqlConnection con)
        {
            string commandStr = "SELECT * FROM SHAY_TransportCompany ";
            SqlCommand cmd = createCommand(con, commandStr);

            return cmd;
        }








        public int UpdateDrivers(Driver d)
        {
            //int res = 0;
            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("UpdateDriver", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DriverId", d.DriverID);
                    cmd.Parameters.AddWithValue("@TransportCompany", d.TransportComany);
                    cmd.Parameters.AddWithValue("@FirstName", d.DriverFname);
                    cmd.Parameters.AddWithValue("@LastName", d.DriverLname);
                    cmd.Parameters.AddWithValue("@PhoneNumber", d.DriverPhone);
                    cmd.Parameters.AddWithValue("@LicenceType", d.DriverLicense);

                    numEffected = cmd.ExecuteNonQuery();

                    //if (result.Equals(1))
                    //{
                    //    res = 1;

                    //}
                    //return res;
                }
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return numEffected;
        }




        //SEND GATEPASS TO ARCHIVE

        public void SendGateToArchive(int id)
        {
            SqlConnection con = null;

            try
            {
                con = Connect("FinalProject");
                SqlCommand selectCommand = createSelectCommandSendGateToArchive(con, id);
                SqlDataReader dataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {

                throw new Exception("failed in reading of artical", ex);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }

        private SqlCommand createSelectCommandSendGateToArchive(SqlConnection con, int id)
        {
            string commandStr = "UPDATE SHAY_GatePass SET GPS_IsActive=N'-' Where GPS_Id=@Id and GPS_IsActive<>N'-'";
            SqlCommand cmd = createCommand(con, commandStr);
            cmd.Parameters.Add("@Id", SqlDbType.Int);
            cmd.Parameters["@Id"].Value = id;

            return cmd;
        }





        public int InsertUser(User user)
        {
            //int res = 0;
            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("NewUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@UserEmail", user.UserEmail);
                    cmd.Parameters.AddWithValue("@UserPassword", user.UserPassword);
                    cmd.Parameters.AddWithValue("@UserCompany", user.UserCompany);
                    cmd.Parameters.AddWithValue("@UserType", user.UserType);

                    //var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
                    //returnParameter.Direction = ParameterDirection.ReturnValue;
                    //cmd.ExecuteNonQuery();
                    //var result = returnParameter.Value;
                    numEffected = cmd.ExecuteNonQuery();

                    //if (result.Equals(1))
                    //{
                    //    res = 1;

                    //}
                    //return res;

                }
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return numEffected;
        }







        //כניסה לאתר

        public User ReadUser(string userEmail)
        {

            SqlConnection con = null;

            try
            {
                con = Connect("FinalProject");
                SqlCommand selectCommand = CreateSelectCommandUser(con, userEmail);

                SqlDataReader dr = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

                User u = new User();

                while (dr.Read())
                {


                    u.UserID = Convert.ToInt32(dr["USR_Id"]);
                    u.UserEmail = (string)dr["USR_Email"];
                    u.UserPassword = (string)dr["USR_Password"];
                    u.UserName = (string)dr["USR_UserName"];
                    u.UserCompany = (string)dr["USR_Company"];


                }
                dr.Close();

                return u;

            }
            catch (Exception ex)
            {

                throw new Exception("failed in reading of Users", ex);
            }
            finally
            {

                if (con != null)
                    con.Close();
            }

        }
        private SqlCommand CreateSelectCommandUser(SqlConnection con, string userEmail)
        {
            string commandStr = "SELECT * FROM SHAY_User WHERE USR_Email=@email ";
            SqlCommand cmd = createCommand(con, commandStr);
            //cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.Add("@email", SqlDbType.NVarChar);
            cmd.Parameters["@email"].Value = userEmail;
            //cmd.Parameters.Add("@password", SqlDbType.VarChar);
            //cmd.Parameters["@password"].Value = userPassword;
            return cmd;
        }




        SqlCommand createCommand(SqlConnection con, string CommandSTR)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = CommandSTR;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandTimeout = 5;
            return cmd;
        }





        ///Custom Brokers Actions


        //Read
        public List<CustomsBroker> ReadBrokers()
        {
            SqlConnection con = null;

            try
            {
                con = Connect("FinalProject");
                SqlCommand selectCommand = CreateSelectCommandCustomsBroker(con);
                List<CustomsBroker> CustomsBrokerList = new List<CustomsBroker>();
                SqlDataReader dataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    CustomsBroker b = new CustomsBroker();
                    b.Id = Convert.ToInt32(dataReader["CSB_Id"]);
                    b.BrokerName = (string)dataReader["CSB_BrokerName"];
                    b.Adress = (string)dataReader["CSB_Adress"];
                    b.PhoneNumber = (string)dataReader["CSB_PhoneNumber"];
                    b.Fax = (string)dataReader["CSB_FAX"];



                    CustomsBrokerList.Add(b);
                }
                return CustomsBrokerList;
            }
            catch (Exception ex)
            {

                throw new Exception("failed in reading of Customs Brokers list", ex);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
        private SqlCommand CreateSelectCommandCustomsBroker(SqlConnection con)
        {
            string commandStr = "SELECT * from SHAY_CustomsBroker ";
            SqlCommand cmd = createCommand(con, commandStr);

            return cmd;
        }

   ///Update

        public int UpdateBroker(CustomsBroker b)
        {
            //int res = 0;
            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("UpdateCustomsBroker", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", b.Id);
                    cmd.Parameters.AddWithValue("@BrokerName", b.BrokerName);
                    cmd.Parameters.AddWithValue("@Adress", b.Adress);
                    cmd.Parameters.AddWithValue("@PhoneNumber", b.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Fax", b.Fax);
             

                    numEffected = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return numEffected;
        }

        //insert

        public int InsertBroker(CustomsBroker b)
        {
            //int res = 0;
            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("NewCustomsBroker", con))
                {
           
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BrokerName", b.BrokerName);
                    cmd.Parameters.AddWithValue("@Adress", b.Adress);
                    cmd.Parameters.AddWithValue("@PhoneNumber", b.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Fax", b.Fax);


                    numEffected = cmd.ExecuteNonQuery();


                }
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return numEffected;
        }







        //חברות תובלה







        //Read
        public List<TransportCompany> ReadCompany()
        {
            SqlConnection con = null;

            try
            {
                con = Connect("FinalProject");
                SqlCommand selectCommand = CreateSelectCommandCompany(con);
                List<TransportCompany> TransportCompanyList = new List<TransportCompany>();
                SqlDataReader dataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    TransportCompany t = new TransportCompany();
                    t.CompanyId = Convert.ToInt32(dataReader["TPC_Id"]);
                    t.CompanyName = (string)dataReader["TPC_CompanyName"];
                    t.CompanyAdress = (string)dataReader["TPC_Adress"];
                    t.CompanyFax = (string)dataReader["TPC_Fax"];
                    t.CompanyPhone = (string)dataReader["TPC_PhoneNumber"];



                    TransportCompanyList.Add(t);
                }
                return TransportCompanyList;
            }
            catch (Exception ex)
            {

                throw new Exception("failed in reading of Transporty Companies list", ex);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
        private SqlCommand CreateSelectCommandCompany(SqlConnection con)
        {
            string commandStr = "SELECT * from SHAY_TransportCompany ";
            SqlCommand cmd = createCommand(con, commandStr);

            return cmd;
        }

        ///Update

        public int UpdateCompany(TransportCompany t)
        {
            //int res = 0;
            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("UpdateTransportCompany", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyName", t.CompanyName);
                    cmd.Parameters.AddWithValue("@BrokerName", t.CompanyAdress);
                    cmd.Parameters.AddWithValue("@Adress", t.CompanyFax);
                    cmd.Parameters.AddWithValue("@PhoneNumber", t.CompanyPhone);
                   


                    numEffected = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return numEffected;
        }

        //insert

        //public int InsertCompany(TransportCompany t)
        //{
        //    //int res = 0;
        //    SqlConnection con = null;
        //    int numEffected = 0;
        //    try
        //    {
        //        con = Connect("FinalProject");
        //        using (SqlCommand cmd = new SqlCommand("NewTransportCompany", con))
        //        {
        //            cmd.Parameters.AddWithValue("@CompanyName", t.CompanyName);
        //            cmd.Parameters.AddWithValue("@BrokerName", t.CompanyAdress);
        //            cmd.Parameters.AddWithValue("@Adress", t.CompanyFax);
        //            cmd.Parameters.AddWithValue("@PhoneNumber", t.CompanyPhone);


        //            numEffected = cmd.ExecuteNonQuery();


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // write to log
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        if (con != null)
        //        {
        //            con.Close();
        //        }
        //    }
        //    return numEffected;
        //}






















        //public int UpdateGatePass(GatePass g)
        //{
        //    SqlConnection con = null;
        //    int numEffected = 0;
        //    try
        //    {
        //        con = Connect("FinalProject");
        //        SqlCommand selectCommand = createSelectCommandUpdateGate(con,g);
        //        SqlDataReader dataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception("failed in Updating", ex);
        //    }
        //    finally
        //    {
        //        if (con != null)
        //            con.Close();
        //    }
        //    return numEffected;
        //}

        //private SqlCommand createSelectCommandUpdateGate(SqlConnection con, GatePass g)
        //{
        //    string commandStr = "UPDATE SHAY_GatePass SET GPS_TransportCompany=@TransportCompany Where GPS_Id=@Id and GPS_IsActive<>N'-'";
        //    SqlCommand cmd = createCommand(con, commandStr);
        //    cmd.Parameters.Add("@Id", SqlDbType.Int);
        //    cmd.Parameters["@Id"].Value = g.Id;
        //    cmd.Parameters.Add("@Company", SqlDbType.NVarChar);
        //    cmd.Parameters["@TransportCompany"].Value=g.TransportCompany;

        //    return cmd;
        //}


        //SEND GATEPASS TO ARCHIVE PROC TRY

        //public int SendGateToArchive(int id)
        //{
        //    //int res = 0;
        //    SqlConnection con = null;
        //    int numEffected = 0;
        //    try
        //    {
        //        con = Connect("FinalProject");
        //        using (SqlCommand cmd = new SqlCommand("SendGateToArchive", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Id", g.Id);
        //            cmd.Parameters.AddWithValue("@IsActive", g.IsActive);


        //            //var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
        //            //returnParameter.Direction = ParameterDirection.ReturnValue;
        //            //cmd.ExecuteNonQuery();
        //            //var result = returnParameter.Value;
        //            numEffected = cmd.ExecuteNonQuery();

        //            //if (result.Equals(1))
        //            //{
        //            //    res = 1;

        //            //}
        //            //return res;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // write to log
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        if (con != null)
        //        {
        //            con.Close();
        //        }
        //    }
        //    return numEffected;
        //}



        //עדכון גייטפס

        //public int UpdateGatePass(GatePass g)
        //{
        //    //int res = 0;
        //    SqlConnection con = null;
        //    int numEffected = 0;
        //    try
        //    {
        //        con = Connect("FinalProject");
        //        using (SqlCommand cmd = new SqlCommand("UpdateGatePass", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@ContainerNum", g.ContainerNum);
        //            cmd.Parameters.AddWithValue("@IsActive", g.IsActive);
        //            cmd.Parameters.AddWithValue("@CreatedDate", g.CreatedDate);

        //            //var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
        //            //returnParameter.Direction = ParameterDirection.ReturnValue;
        //            //cmd.ExecuteNonQuery();
        //            //var result = returnParameter.Value;
        //            numEffected = cmd.ExecuteNonQuery();

        //            //if (result.Equals(1))
        //            //{
        //            //    res = 1;

        //            //}
        //            //return res;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // write to log
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        if (con != null)
        //        {
        //            con.Close();
        //        }
        //    }
        //    return numEffected;
        //}







        //   public int logInUsr(User user)------test for Procedure
        //   {
        //       //List<GatePass> Users = new List<GatePass>();
        //       SqlConnection con = null;
        //       int res = 0;

        //       try
        //       {
        //           con = Connect("FinalProject");

        //           using (SqlCommand cmd = new SqlCommand("CheckUser", con))
        //           {
        //               cmd.CommandType = CommandType.StoredProcedure;

        //               cmd.Parameters.AddWithValue("@UserEmail", user.UserEmail);
        //               cmd.Parameters.AddWithValue("@UserPassword", user.UserPassword);
        //               var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
        //               returnParameter.Direction = ParameterDirection.ReturnValue;
        //               cmd.ExecuteNonQuery();

        //               using (SqlDataReader dr = cmd.ExecuteReader())
        //               {
        //                   var result = returnParameter.Value;
        //                   if (result.Equals(1))
        //                   {
        //                       while (dr.Read())
        //                       {
        //                           if (dr["USR_UserName"] != DBNull.Value)
        //                           {
        //                               user.UserID = Convert.ToInt32(dr["USR_Id"]);
        //                               user.UserName = (string)dr["USR_UserName"];
        //                               user.UserEmail = (string)dr["USR_Email"];
        //                               user.UserPassword = (string)dr["USR_Password"];
        //                               user.UserType = (string)dr["USR_Type"];
        //                               res = 1;
        //                           }
        //                       }

        //                   }
        //               }

        //           }
        //           return res;
        //       }

        //       catch (Exception ex)
        //       {
        //           throw (ex);
        //       }
        //       finally
        //       {
        //           if (con != null)
        //           {
        //               con.Close();
        //           }
        //       }
        //}






        ///// Read Drivers
        ///// 
        //SqlDataAdapter da;
        //public DataTable dt;

        //public DataTable ReadDrivers()
        //{

        //    SqlConnection con = null;

        //    try
        //    {
        //        con = Connect("FinalProject");

        //        string selectString = "SELECT * FROM SHAY_Driver";

        //        da = new SqlDataAdapter(selectString, con);

        //        DataSet ds = new DataSet();

        //        da.Fill(ds);

        //        dt = ds.Tables[0];

        //        return dt;
        //    }

        //    catch (Exception ex)
        //    {
        //        // write to log file

        //        throw new Exception("Error in Read to DataTable", ex);
        //    }

        //    finally
        //    {
        //        if (con != null)
        //            con.Close();
        //    }
        //}







        //public List<User> ReadUsers()
        //{
        //    return UsersList;
        //}

        //private SqlCommand createSelectCommandNewsByName(SqlConnection con, string name, int user)
        //{
        //    string commandStr = "SELECT * FROM UsersArticles_2022 u join Articles_2022 a on u.newsId = a.newsId WHERE [name] = @name and userId =@user and u.statusAr='True' ";
        //    SqlCommand cmd = createCommand(con, commandStr);
        //    cmd.Parameters.Add("@name", SqlDbType.NVarChar);
        //    cmd.Parameters["@name"].Value = name;
        //    cmd.Parameters.Add("@user", SqlDbType.Int);
        //    cmd.Parameters["@user"].Value = user;
        //    return cmd;
        //}












        //        public void InsertUser(User user)
        //        {
        //            SqlConnection con = null;

        //            try
        //            {
        //                con = Connect("FinalProject");
        //                SqlCommand command = CreateInsertUser(user, con);
        //                command.ExecuteNonQuery();
        //                //string emailExist=;
        //                //if (emailExist == user.UserEmail)
        //                //    UsersList = new List<User>();
        //                //UsersList.Add(user);
        //                //return affected;
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception("Failed in Insert user", ex);
        //            }

        //            finally
        //            {
        //                con.Close();
        //            }
        //        }

        //        private SqlCommand CreateInsertUser(User user, SqlConnection con)
        //        {
        //<<<<<<< HEAD
        //            throw new NotImplementedException();
        //=======
        //            string insertStr = "INSERT INTO SHAY_User ([USR_Id],[USR_UserName],[USR_Email],[USR_Password],USR_Type) " +
        //                "VALUES('" + user.UserID + "','" + user.UserName + "','" + user.UserEmail + "','" + user.UserPassword + "','" + user.UserType + "')";
        //            SqlCommand command = new SqlCommand(insertStr, con);
        //            command.CommandType = System.Data.CommandType.Text;
        //            command.CommandTimeout = 30;
        //            return command;
        ////>>>>>>> b126fda96eb08b2a8a45c92140bab2099abc6cfa
        //        }
        //public void InsertUser(User user)
        //{
        //    SqlConnection con = null;

        //    try
        //    {
        //        con = Connect("FinalProject");
        //        SqlCommand command = CreateInsertUser(user, con);
        //        command.ExecuteNonQuery();
        //        //string emailExist=;
        //        //if (emailExist == user.UserEmail)
        //        //    UsersList = new List<User>();
        //        //UsersList.Add(user);
        //        //return affected;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Failed in Insert user", ex);
        //    }

        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        //private SqlCommand CreateInsertUser(User user, SqlConnection con)
        //{
        //    throw new NotImplementedException();
        //    string insertStr = "INSERT INTO SHAY_User ([USR_Id],[USR_UserName],[USR_Email],[USR_Password],USR_Type) " +
        //        "VALUES('" + user.UserID + "','" + user.UserName + "','" + user.UserEmail + "','" + user.UserPassword + "','" + user.UserType + "')";
        //    SqlCommand command = new SqlCommand(insertStr, con);
        //    command.CommandType = System.Data.CommandType.Text;
        //    command.CommandTimeout = 30;
        //    return command;
        //}



    }
}