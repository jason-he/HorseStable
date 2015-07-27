//Using System namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StableBase
{
    /// <summary>
    /// This is the implementation of the NewsAdmin class
    /// </summary>
    public partial class NewsAdmin : System.Web.UI.Page
    {
        /// <summary>
        /// This is the event handler triggered after the web page is loaded.
        /// </summary>
        /// <param name="sender">sender is the instance of the Page control</param>
        /// <param name="e">e contains the event data</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This is the event handler triggered when the AddNewsItem button is clicked.
        /// </summary>
        /// <param name="sender">sender is the instance of the Button control</param>
        /// <param name="e">e is an instance of the EventArgs class and contains the event data</param>
        protected void ButtonAddNewsItem_Click(object sender, EventArgs e)
        {
            if (TextBoxNews.Text.Length > 0)
            {
                using (StableBaseDataContext Data = new StableBaseDataContext())
                {
                    New NewsItem = new New();
                    NewsItem.NewsText = TextBoxNews.Text;
                    NewsItem.NewsDate = DateTime.Now;
                    Data.News.InsertOnSubmit(NewsItem);
                    Data.SubmitChanges();
                }
            }

            PanelAddNews.Visible = false;
            PanelConfirm.Visible = true;
        }
    }
}