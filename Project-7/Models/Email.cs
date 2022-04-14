using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT_7.Models
{
    public class Email
    {
        private string email_adress_userId;
        private bool include_SpamTrash;
        private int max_Results;
        private string q_has_attachment;
        private string format;
        private string thread_Id;
        private string msg_Id;
        private string attachmet_id;
        private string file_name;
        private string content_type;
        private string attachment_data;
        private string api_Key;
        private string client_Id;
        private string discovery_Docs;
        private string scopes;

        public string Email_adress_userId { get => email_adress_userId; set => email_adress_userId = value; }
        public bool Include_SpamTrash { get => include_SpamTrash; set => include_SpamTrash = value; }
        public int Max_Results { get => max_Results; set => max_Results = value; }
        public string Q_has_attachment { get => q_has_attachment; set => q_has_attachment = value; }
        public string Format { get => format; set => format = value; }
        public string Thread_Id { get => thread_Id; set => thread_Id = value; }
        public string Msg_Id { get => msg_Id; set => msg_Id = value; }
        public string Attachmet_id { get => attachmet_id; set => attachmet_id = value; }
        public string File_name { get => file_name; set => file_name = value; }
        public string Content_type { get => content_type; set => content_type = value; }
        public string Attachment_data { get => attachment_data; set => attachment_data = value; }
        public string Api_Key { get => api_Key; set => api_Key = value; }
        public string Client_Id { get => client_Id; set => client_Id = value; }
        public string Discovery_Docs { get => discovery_Docs; set => discovery_Docs = value; }
        public string Scopes { get => scopes; set => scopes = value; }

        public Email()
        {
            Include_SpamTrash = false;
            Format = "full";
            Api_Key = "AIzaSyBXKp-12V1r0N0GbJOuzKcaXbgAl4C_CDg";
        }

        public string GetEmailsList()
        {
            Q_has_attachment = "has:attachment";
            Email_adress_userId = "rupi662022@gmail.com";
            Max_Results = 1;
            Format = "full";

            var myData = new
            {
                Email_adress_userId = Email_adress_userId,
                Max_Results = Max_Results,
                Q_has_attachment = Q_has_attachment,
                Format = Format,
            };


            string jsonData = JsonConvert.SerializeObject(myData);
            return jsonData;

        }


        //public void GetListOfMsgs()
        //{
        //    Email_adress_userId = "rupi662022@gmail.com";
        //    Include_SpamTrash = false;
        //    Max_Results = 1;
        //    Q_has_attachment = "has:attachment";
        //    Format = "full";

        //}
        //public void Init()
        //{
        //    Api_Key = "AIzaSyDSdMaEiTVy_P0IBuvRWrEZSdnHJzmGJH8";
        //    Client_Id = "444171297629-u3ii66o4ovl3sb62c326uusnam9g4vfd.apps.googleusercontent.com";
        //    Discovery_Docs =["https://www.googleapis.com/discovery/v1/apis/gmail/v1/rest"];
        //    Scopes = "https://www.googleapis.com/auth/gmail.modify";


        //}


        public void GetAttachId(string msg_id)
        {

            Msg_Id = msg_id;

        }

        public void GetAttachmentFile(string attach_id)
        {


            Attachmet_id = attach_id;
        }

        public void GetAttachmentData(string file_name, string content_type, string attach_data)
        {
            File_name = file_name;
            Content_type = content_type;
            Attachment_data = attach_data;


        }
    }
}