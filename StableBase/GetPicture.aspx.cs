using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StableBase
{
    /// <summary>
    /// This is the implementation of the GetPicture class.
    /// </summary>
    public partial class GetPicture : System.Web.UI.Page
    {
        /// <summary>
        /// This is the event handler triggered after the web page is loaded.
        /// </summary>
        /// <param name="sender">sender is the instance of the Page control</param>
        /// <param name="e">e contains the event data</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["HorseID"] != null)
            {
                int HorseID = Convert.ToInt32(Request.QueryString["HorseID"]);
                using (StableBaseDataContext Data = new StableBaseDataContext())
                {
                    Horse HorseForImage = Data.Horses.Single(Horse => Horse.HorseID == HorseID);
                    if (HorseForImage.HorsePicture != null)
                    {
                        // Convert the binary into byte[]
                        byte[] bytes = (byte[])HorseForImage.HorsePicture.ToArray();
                        // Convert the byte[] into a special string
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        // Return the image
                        Response.Write("data:image/png;base64," + base64String);
                    }
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}