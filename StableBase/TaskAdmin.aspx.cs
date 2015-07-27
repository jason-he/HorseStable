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
    /// This is the implementation of the TaskAdmin class
    /// </summary>
    public partial class TaskAdmin : System.Web.UI.Page
    {
        /// <summary>
        /// This is the event handler triggered  after this page is loaded
        /// </summary>
        /// <param name="sender">sender is the instance of the Page control</param>
        /// <param name="e">e is an instance of the EventArgs class and contains the event data</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This is the event handler triggered when the Add Task button is clicked.
        /// </summary>
        /// <param name="sender">sender is ButtonAddNewTask, an instance of the Button control</param>
        /// <param name="e">e is an instance of the EventArgs class and contains the event data</param>
        protected void ButtonAddNewTask_Click(object sender, EventArgs e)
        {
            if (TextBoxNewTaskName.Text.Length > 0)
            {
                using (StableBaseDataContext Data = new StableBaseDataContext())
                {
                    Task NewTask = new Task();
                    NewTask.TaskName = TextBoxNewTaskName.Text;
                    Data.Tasks.InsertOnSubmit(NewTask);
                    Data.SubmitChanges();
                    GridViewTask.DataBind();
                }
            }
        }
    }
}