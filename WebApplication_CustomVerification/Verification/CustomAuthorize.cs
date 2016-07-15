using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_CustomVerification.Verification
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        public int ListId { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            //判斷是否已驗證
            if (httpContext.User.Identity.IsAuthenticated == false)
            {
                return false;
            }

            bool boolIsRight = false;

            //Session過期，要求重新登入
            HttpSessionStateBase session = httpContext.Session;
            if (session.Count != 0 &&
                session["Permissions"] != null &&
                session["Permissions"].ToString() != "")
            {
                List<string> list = session["Permissions"].ToString().Split(',').ToList();
                foreach (var item in list)
                {
                    if (item == ListId.ToString())
                    {
                        boolIsRight = true;
                        break;
                    }
                }
            }

            return boolIsRight;
        }
    }

}