using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace taskmanager2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGetProcess_Click(object sender, EventArgs e)
        {
            GetMyProcesses();
        }

        private void GetMyProcesses()
        {
            Process[] task = Process.GetProcesses();
            foreach (Process proc in task)
                listProcess.Items.Add(proc.ProcessName);
        }

        private void btnEndTask_Click(object sender, EventArgs e)
        {
            Process[] task = Process.GetProcesses();
            foreach (Process proc in task)
                if(listProcess.SelectedItem.ToString()== proc.ProcessName)
                    
                {
                    try
                    {
                        proc.Kill();
                        break;
                    }

                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            
        }

        private void btnStartTask_Click(object sender, EventArgs e)
        {
            string path = Microsoft.VisualBasic.Interaction.InputBox("Enter Process Path", "Task Manager", "", 350, 350);
            Process.Start(path);
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {
            Process[] task = Process.GetProcesses();
            foreach (Process proc in task)
                if (listProcess.SelectedItem.ToString() == proc.ProcessName)
                {
                    string temp = string.Empty;
                    temp += "Process ID: " + proc.Id.ToString();
                    temp += "\nUser Time : " + proc.UserProcessorTime.ToString();
                    temp += "\nStart Time: " + proc.StartTime.ToString();
                    MessageBox.Show(temp);
                    break;

                }
        }
    }
}
