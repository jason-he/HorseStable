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
    /// This is the implementation of the Checklist class.
    /// </summary>
    public partial class Checklist : System.Web.UI.Page
    {
        /// <summary>
        /// This is the event handler triggered after the web page is loaded.
        /// </summary>
        /// <param name="sender">sender is the instance of the Page control</param>
        /// <param name="e">e contains the event data</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            using (StableBaseDataContext Data = new StableBaseDataContext())
            {
                var HorseTasksMorning = Data.HorseTasks
                                            .Where(HorseTask => (HorseTask.HorseTaskIsDaily == true || (HorseTask.HorseTaskStartDate <= DateTime.Today && HorseTask.HorseTaskEndDate >= DateTime.Today)) && HorseTask.HorseTaskIsMorning == true)
                                            .Select(HorseTask => new { HorseTask.Horse.HorseName, HorseTask.Task.TaskName, HorseTask.HorseTaskNotes });
                //
                // Set the the dataSource of the GridView GridViewMorning
                //
                GridViewMorning.DataSource = HorseTasksMorning;
                //
                // Bind the GridViewMorning to dataSource
                //
                GridViewMorning.DataBind();

                var HorseTasksEvening = Data.HorseTasks
                            .Where(HorseTask => (HorseTask.HorseTaskIsDaily == true || (HorseTask.HorseTaskStartDate <= DateTime.Today && HorseTask.HorseTaskEndDate >= DateTime.Today)) && HorseTask.HorseTaskIsMorning == false)
                            .Select(HorseTask => new { HorseTask.Horse.HorseName, HorseTask.Task.TaskName, HorseTask.HorseTaskNotes });
                //
                // Set the the dataSource of the GridView GridViewEvening
                //
                GridViewEvening.DataSource = HorseTasksEvening;
                //
                // Bind the GridViewEvening to dataSource
                //
                GridViewEvening.DataBind();
            }
        }
    }
}