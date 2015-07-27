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
    /// This is the implementation of the Horse class.
    /// </summary>
    public partial class Horses : System.Web.UI.Page
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
        /// This is the event handler triggered when a command field is clicked.
        /// </summary>
        /// <param name="sender">sender is the instance of the GridView control</param>
        /// <param name="e">e is an instance of the GridViewCommandEventArgs class and contains the event data</param>
        protected void GridViewHorse_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            PanelScreenMask.Visible = true;

            //
            // Check what commandName is clicked
            //
            if (e.CommandName == "ViewDetails")
            {
                PanelHorseDetails.Visible = true;
                int RowClicked = Convert.ToInt32(e.CommandArgument);
                int HorseID = Convert.ToInt32(GridViewHorse.DataKeys[RowClicked].Value);

                using (StableBaseDataContext Data = new StableBaseDataContext())
                {
                    Horse HorseToDisplay = Data.Horses.Single(Horse => Horse.HorseID == HorseID);
                    LabelHorseName.Text = HorseToDisplay.HorseName;
                    LabelHorseSize.Text = HorseToDisplay.HorseSize.ToString("0.00");
                    LabelHorseWeight.Text = HorseToDisplay.HorseWeight.ToString("0.00");

                    if (HorseToDisplay.HorsePicture != null)
                    {
                        // Convert the binary into byte[]
                        byte[] bytes = (byte[])HorseToDisplay.HorsePicture.ToArray();
                        // Convert the byte[] into a special string
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        // Set the image
                        ImageHorsePicture.ImageUrl = "data:image/png;base64," + base64String;
                        //ImageHorsePicture.ImageUrl = "~/GetPicture.aspx?HorseID=" + HorseToDisplay.HorseID;
                    }
                    else
                    {
                        ImageHorsePicture.ImageUrl = "~/Images/NoPic.jpg";
                    }

                    FormatProficiencyBar(PanelRidingSchoolProficiency, HorseToDisplay.HorseRidingSchool);
                    FormatProficiencyBar(PanelShowJumpingProficiency, HorseToDisplay.HorseShowJumping);
                    FormatProficiencyBar(PanelDressageProficiency, HorseToDisplay.HorseDressage);
                    FormatProficiencyBar(PanelRacingProficiency, HorseToDisplay.HorseRacing);
                }
            }
            else if (e.CommandName == "ViewChecklist")
            {
                PanelHorseChecklist.Visible = true;
                int RowClicked = Convert.ToInt32(e.CommandArgument);
                int HorseID = Convert.ToInt32(GridViewHorse.DataKeys[RowClicked].Value);

                using (StableBaseDataContext Data = new StableBaseDataContext())
                {
                    Horse HorseToDisplay = Data.Horses.Single(Horse => Horse.HorseID == HorseID);
                    LabelChecklistHorseName.Text = HorseToDisplay.HorseName;
                    var HorseTasksMorning = Data.HorseTasks
                                                .Where(HorseTask => (HorseTask.HorseTaskIsDaily == true || (HorseTask.HorseTaskStartDate <= DateTime.Today && HorseTask.HorseTaskEndDate >= DateTime.Today)) && HorseTask.HorseTaskIsMorning == true && HorseTask.Horse.HorseID == HorseID)
                                                .Select(HorseTask => new { HorseTask.Task.TaskName, HorseTask.HorseTaskNotes });
                    GridViewChecklistMorning.DataSource = HorseTasksMorning;
                    GridViewChecklistMorning.DataBind();

                    var HorseTasksEvening = Data.HorseTasks
                                .Where(HorseTask => (HorseTask.HorseTaskIsDaily == true || (HorseTask.HorseTaskStartDate <= DateTime.Today && HorseTask.HorseTaskEndDate >= DateTime.Today)) && HorseTask.HorseTaskIsMorning == false && HorseTask.Horse.HorseID == HorseID)
                                .Select(HorseTask => new { HorseTask.Task.TaskName, HorseTask.HorseTaskNotes });
                    GridViewChecklistEvening.DataSource = HorseTasksEvening;
                    GridViewChecklistEvening.DataBind();
                }
            }
        }

        /// <summary>
        /// This function is to set the background color of a panel.
        /// </summary>
        /// <param name="BarToColor">BarToColor is an instance of the Panel control</param>
        /// <param name="ProficiencyLevel">ProficiencyLevel is a numeric number</param>
        private void FormatProficiencyBar(Panel BarToColor, decimal ProficiencyLevel)
        {
            BarToColor.Width = (Unit)(ProficiencyLevel * 2);
            if (ProficiencyLevel >= 50)
            {
                BarToColor.BackColor = System.Drawing.Color.Green;
            }
            else if (ProficiencyLevel >= 25)
            {
                BarToColor.BackColor = System.Drawing.Color.Orange;
            }
            else
            {
                BarToColor.BackColor = System.Drawing.Color.Red;
            }
        }

        /// <summary>
        /// This is the event handler triggered when the LinkButtonCloseHorseDetailsPanel linkButton is clicked.
        /// </summary>
        /// <param name="sender">sender is the instance of the LinkButton control</param>
        /// <param name="e">e contains the event data</param>
        protected void LinkButtonCloseHorseDetailsPanel_Click(object sender, EventArgs e)
        {
            PanelHorseDetails.Visible = false;
            PanelScreenMask.Visible = false;
        }

        /// <summary>
        /// This is the event handler triggered when the LinkButtonCloseChecklist linkButton is clicked.
        /// </summary>
        /// <param name="sender">sender is the instance of the LinkButton control</param>
        /// <param name="e">e contains the event data</param>
        protected void LinkButtonCloseChecklist_Click(object sender, EventArgs e)
        {
            PanelHorseChecklist.Visible = false;
            PanelScreenMask.Visible = false;
        }

        /// <summary>
        /// This is the event handler triggered when the LinkButtonEditHorseDetails linkButton is clicked.
        /// </summary>
        /// <param name="sender">sender is the instance of the LinkButton control</param>
        /// <param name="e">e contains the event data</param>
        protected void LinkButtonEditHorseDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HorseAdmin.aspx");
        }

        /// <summary>
        /// This is the event handler triggered when the LinkButtonEditCheckList linkButton is clicked.
        /// </summary>
        /// <param name="sender">sender is the instance of the LinkButton control</param>
        /// <param name="e">e contains the event data</param>
        protected void LinkButtonEditCheckList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ScheduleAdmin.aspx");
        }
    }
}