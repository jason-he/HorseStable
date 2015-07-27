//Using System namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Using System namespaces
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StableBase
{
    /// <summary>
    /// This is the implementation of the ScheduleAdmin class
    /// </summary>
    public partial class ScheduleAdmin : System.Web.UI.Page
    {
        /// <summary>
        /// This is the event handler triggered after the web page is loaded.
        /// </summary>
        /// <param name="sender">sender is the instance of the Page control</param>
        /// <param name="e">e contains the event data</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {             
                using (StableBaseDataContext Data = new StableBaseDataContext())
                {
                    List<TaskRow> TableRows = new List<TaskRow>();
                    var HorseTasks = Data.HorseTasks.OrderBy(HorseTask => HorseTask.Horse.HorseName).ThenBy(HorseTask => HorseTask.Task.TaskName);

                    foreach (HorseTask HorseTask in HorseTasks)
                    {
                        TaskRow TableRow = new TaskRow();
                        TableRow.HorseTaskID = HorseTask.HorseTaskID;
                        TableRow.HorseName = HorseTask.Horse.HorseName;
                        TableRow.TaskName = HorseTask.Task.TaskName;
                        TableRow.TaskNotes = HorseTask.HorseTaskNotes;

                        if (HorseTask.HorseTaskIsMorning)
                        {
                            TableRow.TaskTime = "Morning";
                        }
                        else
                        {
                            TableRow.TaskTime = "Evening";
                        }
                        if (HorseTask.HorseTaskIsDaily)
                        {
                            TableRow.TaskInterval = "Every day";
                        }
                        else
                        {
                            TableRow.TaskInterval = "From " + ((DateTime)HorseTask.HorseTaskStartDate).ToString("dd MMM yyyy") + " to " + ((DateTime)HorseTask.HorseTaskEndDate).ToString("dd MMM yyyy");
                        }
                        TableRows.Add(TableRow);
                    }

                    GridViewHorseTask.DataSource = TableRows;
                    GridViewHorseTask.DataBind();
                }
            }
        }

        /// <summary>
        /// This is the event handler triggered when the CheckBox is changed.
        /// </summary>
        /// <param name="sender">sender is the instance of the CheckBox control</param>
        /// <param name="e">e contains the event data</param>
        protected void CheckBoxIsDaily_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxIsDaily.Checked)
            {
                TextBoxStartDate.Text = "";
                TextBoxEndDate.Text = "";
                TextBoxStartDate.Enabled = false;
                TextBoxEndDate.Enabled = false;
            }
            else
            {
                TextBoxStartDate.Text = DateTime.Today.ToString("dd MMM yyyy");
                TextBoxEndDate.Text = DateTime.Today.ToString("dd MMM yyyy");
                TextBoxStartDate.Enabled = true;
                TextBoxEndDate.Enabled = true;
            }
        }

        /// <summary>
        /// This is the event handler triggered when the Add Task button is clicked.
        /// </summary>
        /// <param name="sender">sender is the instance of the Button control</param>
        /// <param name="e">e contains the event data</param>
        protected void ButtonAddTask_Click(object sender, EventArgs e)
        {
            using (StableBaseDataContext Data = new StableBaseDataContext())
            {
                HorseTask NewTask = new HorseTask();
                NewTask.HorseID = Convert.ToInt32(DropDownListHorse.SelectedValue);
                NewTask.TaskID = Convert.ToInt32(DropDownListTask.SelectedValue);
                NewTask.HorseTaskIsDaily = CheckBoxIsDaily.Checked;
                NewTask.HorseTaskIsMorning = Convert.ToBoolean(DropDownListIsMorning.SelectedValue);
                NewTask.HorseTaskNotes = TextBoxTaskNotes.Text;
                Data.HorseTasks.InsertOnSubmit(NewTask);
                Data.SubmitChanges();
                
                //
                // Retrieve GridView data for display.
                //
                List<TaskRow> TableRows = new List<TaskRow>();
                var HorseTasks = Data.HorseTasks.OrderBy(HorseTask => HorseTask.Horse.HorseName).ThenBy(HorseTask => HorseTask.Task.TaskName);
                foreach (HorseTask HorseTask in HorseTasks)
                {
                    TaskRow TableRow = new TaskRow();
                    TableRow.HorseTaskID = HorseTask.HorseTaskID;
                    TableRow.HorseName = HorseTask.Horse.HorseName;
                    TableRow.TaskName = HorseTask.Task.TaskName;
                    TableRow.TaskNotes = HorseTask.HorseTaskNotes;
                    if (HorseTask.HorseTaskIsMorning)
                    {
                        TableRow.TaskTime = "Morning";
                    }
                    else
                    {
                        TableRow.TaskTime = "Evening";
                    }
                    if (HorseTask.HorseTaskIsDaily)
                    {
                        TableRow.TaskInterval = "Every day";
                    }
                    else
                    {
                        TableRow.TaskInterval = "From " + ((DateTime)HorseTask.HorseTaskStartDate).ToString("dd MMM yyyy") + " to " + ((DateTime)HorseTask.HorseTaskEndDate).ToString("dd MMM yyyy");
                    }

                    TableRows.Add(TableRow);
                }

                // Set data source
                GridViewHorseTask.DataSource = TableRows;
                // Bind GridView to tableRows
                GridViewHorseTask.DataBind();
            }
        }

        /// <summary>
        /// This is an event handler triggered when the command field is clicked.
        /// </summary>
        /// <param name="sender">sender is GridViewHorseTask, an instance of the GridView control</param>
        /// <param name="e">e is an instance of the GridViewCommandEventArgs class and contains the event data</param></param>
        protected void GridViewHorseTask_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int RowClicked = Convert.ToInt32(e.CommandArgument);
            int HorseTaskID = Convert.ToInt32(GridViewHorseTask.DataKeys[RowClicked].Value);

            using (StableBaseDataContext Data = new StableBaseDataContext())
            {
                HorseTask TaskToDelete = Data.HorseTasks.Single(HorseTask => HorseTask.HorseTaskID == HorseTaskID);
                Data.HorseTasks.DeleteOnSubmit(TaskToDelete);
                Data.SubmitChanges();

                List<TaskRow> TableRows = new List<TaskRow>();
                var HorseTasks = Data.HorseTasks.OrderBy(HorseTask => HorseTask.Horse.HorseName).ThenBy(HorseTask => HorseTask.Task.TaskName);
                
                foreach (HorseTask HorseTask in HorseTasks)
                {
                    TaskRow TableRow = new TaskRow();
                    TableRow.HorseTaskID = HorseTask.HorseTaskID;
                    TableRow.HorseName = HorseTask.Horse.HorseName;
                    TableRow.TaskName = HorseTask.Task.TaskName;
                    TableRow.TaskNotes = HorseTask.HorseTaskNotes;
                    if (HorseTask.HorseTaskIsMorning)
                    {
                        TableRow.TaskTime = "Morning";
                    }
                    else
                    {
                        TableRow.TaskTime = "Evening";
                    }
                    if (HorseTask.HorseTaskIsDaily)
                    {
                        TableRow.TaskInterval = "Every day";
                    }
                    else
                    {
                        TableRow.TaskInterval = "From " + ((DateTime)HorseTask.HorseTaskStartDate).ToString("dd MMM yyyy") + " to " + ((DateTime)HorseTask.HorseTaskEndDate).ToString("dd MMM yyyy");
                    }
                    TableRows.Add(TableRow);
                }
                
                GridViewHorseTask.DataSource = TableRows;
                GridViewHorseTask.DataBind();
            }
        }
    }

    class TaskRow
    {
        public int HorseTaskID { get; set; }
        public string HorseName { get; set; }
        public string TaskName { get; set; }
        public string TaskNotes { get; set; }
        public string TaskTime { get; set; }
        public string TaskInterval { get; set; }
    }
}