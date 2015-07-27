using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace StableBase
{
    /// <summary>
    /// Summary description for NewWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NewWebService : System.Web.Services.WebService
    {
        /// <summary>
        /// This web service just get a literal string.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// This web service is used to get all field data of the table News.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string[] GetNews()
        {
            using (StableBaseDataContext Data = new StableBaseDataContext())
            {
                return Data.News.Select(aRec => aRec.NewsText).ToArray();
            }
        }
    }
}
