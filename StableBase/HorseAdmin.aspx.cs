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
    /// This is the implementation of the HorseAdmin class
    /// </summary>
    public partial class HorseAdmin : System.Web.UI.Page
    {
        /// <summary>
        /// This is the event handler triggered after the web page is loaded.
        /// </summary>
        /// <param name="sender">sender is the instance of the Page control</param>
        /// <param name="e">e is an instance of the EventArgs class and contains the event data</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This is the event handler triggered when the selection of the drop-down list DropDownListHorse 
        /// is changed.
        /// </summary>
        /// <param name="sender">sender is DropDownListHorse, an instance of the DropDownList control</param>
        /// <param name="e">e contains the event data</param>
        protected void DropDownListHorse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListHorse.SelectedValue != "0")
            {
                PanelHorseDetails.Visible = true;
                DropDownListHorse.Enabled = false;
                ButtonAddNewHorse.Enabled = false;
                ButtonSave.Visible = true;
                ButtonSaveNewHorse.Visible = false;

                using (StableBaseDataContext Data = new StableBaseDataContext())
                {
                    Horse HorseToEdit = Data.Horses.Single(H => H.HorseID == Convert.ToInt32(DropDownListHorse.SelectedValue));
                    TextBoxHorseName.Text = HorseToEdit.HorseName;
                    TextBoxHorseSize.Text = HorseToEdit.HorseSize.ToString("0.00");
                    TextBoxHorseWeight.Text = HorseToEdit.HorseWeight.ToString("0.00");
                    TextBoxHorseRidingSchool.Text = HorseToEdit.HorseRidingSchool.ToString("0.00");
                    TextBoxHorseShowJumping.Text = HorseToEdit.HorseShowJumping.ToString("0.00");
                    TextBoxHorseDressage.Text = HorseToEdit.HorseDressage.ToString("0.00");
                    TextBoxHorseRacing.Text = HorseToEdit.HorseRacing.ToString("0.00");
                    if (HorseToEdit.HorsePicture != null)
                    {
                        // Convert the binary into byte[]
                        byte[] bytes = (byte[])HorseToEdit.HorsePicture.ToArray();
                        // Convert the byte[] into a special string
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        // Set the image
                        ImageHorsePicture.ImageUrl = "data:image/png;base64," + base64String;
                        //ImageHorsePicture.ImageUrl = "~/GetPicture.aspx?HorseID=" + HorseToEdit.HorseID;
                    }
                    else
                    {
                        ImageHorsePicture.ImageUrl = "~/Images/NoPic.jpg";
                    }
                }
            }
            else
            {
                PanelHorseDetails.Visible = false;
                DropDownListHorse.Enabled = true;
                ButtonAddNewHorse.Enabled = true;
            }
        }

        /// <summary>
        /// This is the event handler triggered when the Add New Horse button is clicked.
        /// </summary>
        /// <param name="sender">sender is ButtonAddNewHorse, an instance of the Button control</param>
        /// <param name="e">e contains the event data</param>
        protected void ButtonAddNewHorse_Click(object sender, EventArgs e)
        {
            PanelHorseDetails.Visible = true;
            DropDownListHorse.Enabled = false;
            ButtonAddNewHorse.Enabled = false;
            ButtonSave.Visible = false;
            ButtonSaveNewHorse.Visible = true;
            TextBoxHorseName.Text = "";
            TextBoxHorseSize.Text = "";
            TextBoxHorseWeight.Text = "";
            TextBoxHorseRidingSchool.Text = "";
            TextBoxHorseShowJumping.Text = "";
            TextBoxHorseDressage.Text = "";
            TextBoxHorseRacing.Text = "";
            ImageHorsePicture.ImageUrl = "~/Images/NoPic.jpg";
        }

        /// <summary>
        /// This is the event handler triggered when the Cancel button is clicked.
        /// </summary>
        /// <param name="sender">sender is ButtonCancel, an instance of the Button control</param>
        /// <param name="e">e contains the event data</param>
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            DropDownListHorse.SelectedIndex = 0;
            PanelHorseDetails.Visible = false;
            DropDownListHorse.Enabled = true;
            ButtonAddNewHorse.Enabled = true;
        }

        /// <summary>
        /// This is the event handler triggered when the Save button is clicked.
        /// </summary>
        /// <param name="sender">sender is ButtonSave, an instance of the Button control</param>
        /// <param name="e">e contains the event data</param>
        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            using (StableBaseDataContext Data = new StableBaseDataContext())
            {
                Horse HorseToEdit = Data.Horses.Single(H => H.HorseID == Convert.ToInt32(DropDownListHorse.SelectedValue));
                HorseToEdit.HorseName = TextBoxHorseName.Text;
                HorseToEdit.HorseSize = Convert.ToDecimal(TextBoxHorseSize.Text);
                HorseToEdit.HorseWeight = Convert.ToDecimal(TextBoxHorseWeight.Text);
                HorseToEdit.HorseRidingSchool = Convert.ToDecimal(TextBoxHorseRidingSchool.Text);
                HorseToEdit.HorseShowJumping = Convert.ToDecimal(TextBoxHorseShowJumping.Text);
                HorseToEdit.HorseDressage = Convert.ToDecimal(TextBoxHorseDressage.Text);
                HorseToEdit.HorseRacing = Convert.ToDecimal(TextBoxHorseRacing.Text);

                if (FileUploadHorsePicture.HasFile)
                {
                    HorseToEdit.HorsePicture = FileUploadHorsePicture.FileBytes;
                }

                // Save changes
                Data.SubmitChanges();
            }

            //Reset some field values
            DropDownListHorse.SelectedIndex = 0;
            PanelHorseDetails.Visible = false;
            DropDownListHorse.Enabled = true;
            ButtonAddNewHorse.Enabled = true;
        }

        /// <summary>
        /// This is the event handler triggered when the Add Horse button is clicked.
        /// </summary>
        /// <param name="sender">sender is ButtonSaveNewHorse, an instance of the Button control</param>
        /// <param name="e">e contains the event data</param>
        protected void ButtonSaveNewHorse_Click(object sender, EventArgs e)
        {
            using (StableBaseDataContext Data = new StableBaseDataContext())
            {
                Horse NewHorse = new Horse();
                NewHorse.HorseName = TextBoxHorseName.Text;
                NewHorse.HorseSize = Convert.ToDecimal(TextBoxHorseSize.Text);
                NewHorse.HorseWeight = Convert.ToDecimal(TextBoxHorseWeight.Text);
                NewHorse.HorseRidingSchool = Convert.ToDecimal(TextBoxHorseRidingSchool.Text);
                NewHorse.HorseShowJumping = Convert.ToDecimal(TextBoxHorseShowJumping.Text);
                NewHorse.HorseDressage = Convert.ToDecimal(TextBoxHorseDressage.Text);
                NewHorse.HorseRacing = Convert.ToDecimal(TextBoxHorseRacing.Text);

                if (FileUploadHorsePicture.HasFile)
                {
                    // Convert the byte[] into binary
                    NewHorse.HorsePicture = FileUploadHorsePicture.FileBytes;
                }

                // Insert a new horse
                Data.Horses.InsertOnSubmit(NewHorse);

                // Change the new record.
                Data.SubmitChanges();
            }

            // Reset some field values.
            DropDownListHorse.SelectedIndex = 0;
            PanelHorseDetails.Visible = false;
            DropDownListHorse.Enabled = true;
            ButtonAddNewHorse.Enabled = true;
        }
    }
}