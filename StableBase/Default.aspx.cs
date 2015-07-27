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
    /// This is the implementation of the _Default class.
    /// </summary>
    public partial class _Default : Page
    {
        /// <summary>
        /// This is the event handler triggered after the web page is loaded.
        /// </summary>
        /// <param name="sender">sender is the instance of the Page control</param>
        /// <param name="e">e contains the event data</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a web soap client.
            NewServiceReference.NewWebServiceSoapClient RemotWebService = new NewServiceReference
            .NewWebServiceSoapClient();
           //int[] ints = { 10, 45, 15, 39, 21, 26 };
           //int itotal = ints.Sum();
           //Using web service to get all field data of the table News.
           string[] NewsItems = RemotWebService.GetNews().ToArray(); 
          //  string hellowStr = RemotWebService.HelloWorld();
            foreach (string item in NewsItems)
            {
                LabelNews.Text += item + "<br/>";
            }
        }

        /// <summary>
        /// This is the event handler triggered when the TimerNews Timer control ticks.
        /// The content of the label LabelNews is updated every time this event hanlder is triggered.
        /// </summary>
        /// <param name="sender">sender is the instance of the Timer control</param>
        /// <param name="e">e contains the event data</param>
        protected void TimerNews_Tick(object sender, EventArgs e)
        {
            using (StableBaseDataContext Data = new StableBaseDataContext())
            {
                var NewsItems = Data.News.Select(news => news.NewsText);
                LabelNews.Text = "";

                foreach (string item in NewsItems)
                {
                    LabelNews.Text += item + "<br/>";
                }
            }
        }
    }
}