using MissionPlanner.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using MissionPlanner.Controls.PreFlight;
using MissionPlanner.Controls;
using System.Linq;
using System.Drawing;

namespace MissionPlanner.NewMessage
{
    public class NewMessagePlugin : MissionPlanner.Plugin.Plugin
    {

        public TabPage newMessagePage = new TabPage();
        public override string Name
        {
            get { return "NewMessage"; }
        }

        public override string Version
        {
            get { return "0.1"; }
        }

        public override string Author
        {
            get { return "Add your name here"; }
        }

        //[DebuggerHidden]
        public override bool Init()
		//Init called when the plugin dll is loaded
        {
            loopratehz = 1;  //Loop runs every second (The value is in Hertz, so 2 means every 500ms, 0.1f means every 10 second...) 

            return true;	 // If it is false then plugin will not load
        }

        public override bool Loaded()
		//Loaded called after the plugin dll successfully loaded
        {


            newMessagePage.Text = "TTTTTTTT";
            newMessagePage.Click += undockDockNewMessagePage_Click;
            Host.MainForm.FlightData.tabControlactions.TabPages.Add(newMessagePage);



            return true;     //If it is false plugin will not start (loop will not called)
        }

        public override bool Loop()
		//Loop is called in regular intervalls (set by loopratehz)
        {

            return true;	//Return value is not used
        }

        public override bool Exit()
		//Exit called when plugin is terminated (usually when Mission Planner is exiting)
        {
            return true;	//Return value is not used
        }


        private void undockDockNewMessagePage_Click(object sender, EventArgs e)
        {

            Form dropout = new Form();
            TabControl tab = new TabControl();
            dropout.FormBorderStyle = FormBorderStyle.Sizable;
            dropout.ShowInTaskbar = false;
            dropout.Size = new Size(300, 450);
            //tabQuickDetached = true;
            tab.Appearance = TabAppearance.FlatButtons;
            tab.ItemSize = new Size(0, 0);
            tab.SizeMode = TabSizeMode.Fixed;
            tab.Size = new Size(dropout.ClientSize.Width, dropout.ClientSize.Height + 22);
            tab.Location = new Point(0, -22);

            tab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            dropout.Text = "Flight DATA";
            Host.MainForm.FlightData.tabControlactions.Controls.Remove(newMessagePage);
            tab.Controls.Add(newMessagePage);
            newMessagePage.BorderStyle = BorderStyle.Fixed3D;
            dropout.FormClosed += dropoutQuick_FormClosed;
            dropout.Controls.Add(tab);
            dropout.RestoreStartupLocation();
            dropout.Show();
            //tabQuickDetached = true;
            //(sender as ToolStripMenuItem).Visible = false;
        }

        void dropoutQuick_FormClosed(object sender, FormClosedEventArgs e)
        {
            (sender as Form).SaveStartupLocation();
            Host.MainForm.FlightData.tabControlactions.Controls.Add(newMessagePage);
            Host.MainForm.FlightData.tabControlactions.SelectedTab = newMessagePage;
            //tabQuickDetached = false;
            //contextMenuStripQuickView.Items["undockToolStripMenuItem"].Visible = true;
        }



    }
}