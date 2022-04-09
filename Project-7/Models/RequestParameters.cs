using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT_5.Models
{
    public class RequestParameters
    {


        public String scope { get; set; }
        public String access_type { get; set; }
        public String include_granted_scopes { get; set; }
        public String response_type { get; set;}
        public String state { get; set; }
        public String redirect_uri { get; set; }
        public String client_id { get; set; }
        public String code { get; set; }
        public String client_secret { get; set; }
        public String grant_type { get; set; }
        public bool IsCreated { get; set; }

        public RequestParameters()
        {
            this.scope= "https://mail.google.com";
            this.access_type = "offline";
            this.include_granted_scopes = "true";
            this.response_type = "code";
            this.state = "state_parameter_passthrough_value";
            this.redirect_uri = "https://localhost:44357";
            this.client_id = "79174569678-adeuegbvh6bn963o9c9666e3da9k80hu.apps.googleusercontent.com";
            this.IsCreated = true;

        }

        public string CreateHref()
        {
            if (IsCreated == true)
            {
                return "https://accounts.google.com/o/oauth2/v2/auth?scope="+this.scope+"&access_type="+this.access_type+ "&include_granted_scopes="+this.include_granted_scopes+"&response_type="+this.response_type+"&state="+this.state+"&redirect_uri="+this.redirect_uri+"&client_id="+this.client_id;

            }

            else
            {

                return null;
            }
        }

    }



}