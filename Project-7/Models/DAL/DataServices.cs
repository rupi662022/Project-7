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
        //private object userID;

        SqlConnection Connect(string connectionStringName)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            return con;
        }


        ////////GatePas////////

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
                    GatePass a = new GatePass();
                    a.Id = Convert.ToInt32(dataReader["GPS_Id"]);
                    a.ContainerNum = (string)dataReader["GPS_ContainerNum"];
                    a.ContainerType = (string)dataReader["GPS_ContainerType"];
                    a.TransportCompany = (string)dataReader["GPS_TransportCompany"];
                    a.Note = (string)dataReader["GPS_Note"];
                    a.CustomsBroker = (string)dataReader["GPS_CustomsBroker"];
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
                    //cmd.Parameters.AddWithValue("@Importer", g.Importer);
                    cmd.Parameters.AddWithValue("@CustomsBroker", g.CustomsBroker);
                    cmd.Parameters.AddWithValue("@ShippingCompanyAndLine", g.ShippingCompanyAndLine);
                    cmd.Parameters.AddWithValue("@StorageCertificate", g.StorageCertificate);
                    cmd.Parameters.AddWithValue("@Note", g.Note);
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
                    cmd.Parameters.AddWithValue("@CustomBroker", g.CustomsBroker);

                    //cmd.Parameters.AddWithValue("@Importer", g.Importer);
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




        ///Read Archieve
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
                    //g.Importer = (string)dataReader["GPS_Importer"];
                    g.CustomsBroker=(string)dataReader["GPS_CustomsBroker"];
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
        private SqlCommand CreateSelectCommandNegGatePass(SqlConnection con, string isActive)
        {
            string commandStr = "SELECT * FROM SHAY_GatePass WHERE GPS_IsActive=@isActive";
            SqlCommand cmd = createCommand(con, commandStr);
            cmd.Parameters.Add("@isActive", SqlDbType.NVarChar);
            cmd.Parameters["@isActive"].Value = isActive;
            return cmd;
        }








        ///SEND GATEPASS TO ARCHIVE

        public int SendGateToArchive(GatePass g)
        {
            //int res = 0;
            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("SendGateToArchive", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", g.Id);
                  



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






        ////////Driver////////

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
            string commandStr = "SELECT * FROM SHAY_Driver WHERE DRI_IsActive=N'+'";
            SqlCommand cmd = createCommand(con, commandStr);

            return cmd;
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


        public int DeleteDriver(Driver d)
        {

            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("DeleteDriver", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DriverId", d.DriverID);

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



        ////////User////////

        public List<User> ReadUsers()
        {
            SqlConnection con = null;

            try
            {
                con = Connect("FinalProject");
                SqlCommand selectCommand = CreateSelectCommandUsers(con);
                List<User> UserList = new List<User>();
                SqlDataReader dataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    User u = new User();

                    u.UserID = Convert.ToInt32(dataReader["USR_Id"]);
                    u.UserName = (string)dataReader["USR_UserName"];
                    //u.UserType = (string)dataReader["USR_Type"];
                    u.UserEmail = (string)dataReader["USR_Email"];
                    u.UserPassword = (string)dataReader["USR_Password"];

                    u.IsAdmin = (bool)dataReader["USR_IsAdmin"];



                    UserList.Add(u);
                }
                return UserList;
            }
            catch (Exception ex)
            {

                throw new Exception("failed in reading of Users list", ex);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
        private SqlCommand CreateSelectCommandUsers(SqlConnection con)
        {
            string commandStr = "SELECT * from SHAY_User where USR_Type='U' AND USR_IsActive=N'+'";
            SqlCommand cmd = createCommand(con, commandStr);
    

            return cmd;
        }




        public int InsertUser(User user)
        {

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
                    //cmd.Parameters.AddWithValue("@UserType", user.UserType);


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



        public int DeleteUser(User u)
        {
            //int res = 0;
            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("DeleteUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", u.UserID);



                    numEffected = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

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







        public User ReadLogUser(string userEmail)
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
                    u.UserName = (string)dr["USR_UserName"];
                    u.UserEmail = (string)dr["USR_Email"];
                    u.UserPassword = (string)dr["USR_Password"];
                    u.UserType = (string)dr["USR_Type"];
                    u.IsAdmin = (bool)dr["USR_IsAdmin"];
                }
                dr.Close();
                if (u.UserEmail == null)
                {

                    throw new Exception("one of the parameter incorect");
                }
                return u;

            }
            catch (Exception ex)
            {

                throw new Exception("failed in reading of User", ex);
            }
            finally
            {

                if (con != null)
                    con.Close();
            }

        }
        private SqlCommand CreateSelectCommandUser(SqlConnection con, string userEmail)
        {
            string commandStr = "SELECT * FROM SHAY_User WHERE USR_Email=@userEmail AND USR_IsActive=N'+'";
            SqlCommand cmd = createCommand(con, commandStr);
            cmd.Parameters.Add("@userEmail", SqlDbType.NVarChar);
            cmd.Parameters["@userEmail"].Value = userEmail;

            return cmd;
        }







        public int UpdateUser(User u)
        {
            //int res = 0;
            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("UpdateUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
         
                    cmd.Parameters.AddWithValue("@UserID", u.UserID);
                    cmd.Parameters.AddWithValue("@UserName", u.UserName);
                    cmd.Parameters.AddWithValue("@UserEmail", u.UserEmail);
                    cmd.Parameters.AddWithValue("@UserPassword", u.UserPassword);
                    cmd.Parameters.AddWithValue("@IsAdmin", u.IsAdmin);

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

        ////////Customs Broker////////

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
            string commandStr = "SELECT * from SHAY_CustomsBroker where CSB_IsActive=N'+'";
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



        public int DeleteBroker(CustomsBroker b)
        {
            //int res = 0;
            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("DelteCustomsBroker", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", b.Id);
          


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


        ////////Transport Company////////

        public List<TransportCompany> ReadTransportCompany()
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

                throw new Exception("failed in reading of Transport Companies list", ex);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
        private SqlCommand CreateSelectCommandCompany(SqlConnection con)
        {
            string commandStr = "SELECT * from SHAY_TransportCompany where TPC_IsActive=N'+'";

            SqlCommand cmd = createCommand(con, commandStr);

            return cmd;
        }

   

        public int UpdateTransportComany(TransportCompany t)
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
                    cmd.Parameters.AddWithValue("@CompanyId", t.CompanyId);
                    cmd.Parameters.AddWithValue("@CompanyName", t.CompanyName);
                    cmd.Parameters.AddWithValue("@Adress", t.CompanyAdress);
                    cmd.Parameters.AddWithValue("@Fax", t.CompanyFax);
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

      

        public int InsertTransportComany(TransportCompany t)
        {
            //int res = 0;
            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("NewTransportCompany", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyName", t.CompanyName);
                    cmd.Parameters.AddWithValue("@Adress", t.CompanyAdress);
                    cmd.Parameters.AddWithValue("@Fax", t.CompanyFax);
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


        //Delete
        public int DeleteTransportComany(TransportCompany t)
        {
            //int res = 0;
            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("DeleteTransportCompany", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyName", t.CompanyName);



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


        ////////My GatePass////////

        public List<GatePass> ReadMyGatePass(int userID)
        {

            SqlConnection con = null;

            try
            {
                con = Connect("FinalProject");
               SqlCommand selectCommand = CreateSelectCommandMyGatePass(con, userID);
                List<GatePass> gatePassList = new List<GatePass>();
                SqlDataReader dataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

    
              
                       while (dataReader.Read())
                        {
                            GatePass g = new GatePass();

                            g.Id = Convert.ToInt32(dataReader["GPS_Id"]);
                            g.ContainerNum = (string)dataReader["GPS_ContainerNum"];
                            g.ContainerType = (string)dataReader["GPS_ContainerType"];
                            g.TransportCompany = (string)dataReader["GPS_TransportCompany"];
                            g.Note = (string)dataReader["GPS_Note"];
        
                             g.CustomsBroker = (string)dataReader["GPS_CustomsBroker"];
                            g.CreatedDate = Convert.ToDateTime(dataReader["GPS_CreatedDate"]);


                    gatePassList.Add(g);
                        }
                        return gatePassList;
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
        private SqlCommand CreateSelectCommandMyGatePass(SqlConnection con, int userID)
        {
            string commandStr =
                "if exists(select * from SHAY_Driver where DRI_DriverId=@UserID) begin select * from SHAY_GatePass G inner join SHAY_TransportCompany T on G.GPS_TransportCompany = T.TPC_CompanyName inner join SHAY_Driver D on T.TPC_CompanyName = D.DRI_TransportCompany WHERE DRI_DriverId = @UserId and GPS_IsActive = '+'  end  if exists(select * from SHAY_CustomerAdmin where CUN_AdminId = @UserID)  begin select * from SHAY_GatePass G inner join SHAY_TransportCompany T on G.GPS_TransportCompany = T.TPC_CompanyName inner join SHAY_CustomerAdmin C on T.TPC_CompanyName = C.CUN_TransportCompany  WHERE CUN_AdminId = @UserId and GPS_IsActive = '+' end";

            SqlCommand cmd = createCommand(con, commandStr);
            cmd.Parameters.Add("@userID", SqlDbType.Int);
            cmd.Parameters["@userID"].Value = userID;
            return cmd;
        }


        ////////Customer Admin////////
        public List<CustomerAdmin> ReadCustomerAdmins()
        {
            SqlConnection con = null;

            try
            {
                con = Connect("FinalProject");
                SqlCommand selectCommand = CreateSelectCommandReadCustomerAdmins(con);
                List<CustomerAdmin> AdminList = new List<CustomerAdmin>();
                SqlDataReader dataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    CustomerAdmin a = new CustomerAdmin();
                    a.AdminId = Convert.ToInt32(dataReader["CUN_AdminId"]);
                    a.FullName = (string)dataReader["CUN_FullName"];
                    a.TransportComany = (string)dataReader["CUN_TransportCompany"];
                    a.PhoneNumber = (string)dataReader["CUN_PhoneNumber"];
                    //a.IsAllowed = (bool)dataReader["CUN_IsAllowed"];

                    AdminList.Add(a);
                }
                return AdminList;
            }
            catch (Exception ex)
            {

                throw new Exception("failed in reading of Admin list", ex);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
        private SqlCommand CreateSelectCommandReadCustomerAdmins(SqlConnection con)
        {
            string commandStr = "SELECT * FROM SHAY_CustomerAdmin WHERE CUN_IsActive=N'+'";
            SqlCommand cmd = createCommand(con, commandStr);

            return cmd;
        }




        public int InsertCustomerAdmin(CustomerAdmin c)
        {
            //int res = 0;
            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("NewCustomerAdmin", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AdminId", c.AdminId);
                    cmd.Parameters.AddWithValue("@TransportComany", c.TransportComany);
                    cmd.Parameters.AddWithValue("@FullName", c.FullName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", c.PhoneNumber);


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





         public int UpdateCustomerAdmin(CustomerAdmin c)
        {
            //int res = 0;
            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("UpdateCustomerAdmin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AdminId", c.AdminId);
                    cmd.Parameters.AddWithValue("@TransportComany", c.TransportComany);
                    cmd.Parameters.AddWithValue("@FullName", c.FullName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", c.PhoneNumber);


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



        public int DeleteCustomerAdmin(CustomerAdmin c)
        {
            //int res = 0;
            SqlConnection con = null;
            int numEffected = 0;
            try
            {
                con = Connect("FinalProject");
                using (SqlCommand cmd = new SqlCommand("DelteCustomerAdmin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AdminId", c.AdminId);



                    numEffected = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
     
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







        SqlCommand createCommand(SqlConnection con, string CommandSTR)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = CommandSTR;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandTimeout = 5;
            return cmd;
        }






    }
}