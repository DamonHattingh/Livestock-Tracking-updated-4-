using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Automation;
using Microsoft.Scripting.Hosting;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace Livestock_Tracking
{
    public partial class TrackingData : Form
    {

        string connectionString = "Server=localhost;Database=EastwoodFarm_database;Integrated Security=True;";
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable dataTable;

        private void TrackingData_Load(object sender, EventArgs e)
        {
            overallData();
            // dateList();
        }


        // Methods to display data of all animals and specific animals in the data grid view.
        public void overallData()
        {
            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("overallData", connection);

            command.CommandType = CommandType.StoredProcedure;

            adapter = new SqlDataAdapter(command);

            dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvTrackingData.DataSource = dataTable;

            connection.Close();
        }

        public void cowData()
        {
            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("cowData", connection);

            command.CommandType = CommandType.StoredProcedure;

            adapter = new SqlDataAdapter(command);

            dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvTrackingData.DataSource = dataTable;

            connection.Close();
        }

        public void horseData()
        {
            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("horseData", connection);

            command.CommandType = CommandType.StoredProcedure;

            adapter = new SqlDataAdapter(command);

            dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvTrackingData.DataSource = dataTable;

            connection.Close();
        }

        public void sheepData()
        {
            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("sheepData", connection);

            command.CommandType = CommandType.StoredProcedure;

            adapter = new SqlDataAdapter(command);

            dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvTrackingData.DataSource = dataTable;

            connection.Close();
        }

        public void simulateDroneFlightCows()
        {
            string path = @"..\..\Scripts\cow_counts.txt";
            string count = File.ReadAllText(path);

            string pythonPath = @"..\..\Scripts\venv\Scripts\python.exe"; 
            string scriptPath = @"..\Scripts\main.py"; 

            Process process = new Process();
            process.StartInfo.FileName = pythonPath;
            process.StartInfo.Arguments = scriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.WorkingDirectory = @"..\..\Scripts";

            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            MessageBox.Show("Python script executed:\n" + output);
        


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("simulateCowFlight", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@animalCount", int.Parse(count));
                    command.Parameters.AddWithValue("@date", DateTime.Now);

                    command.ExecuteNonQuery();

                }
            }

        }

        public void simulateDroneFlightHorses()
        {
            string path = @"..\..\Scripts\horse_counts.txt";
            string count = File.ReadAllText(path);

            string pythonPath = @"..\..\Scripts\venv\Scripts\python.exe"; 
            string scriptPath = @"..\Scripts\Horses.py"; 

            Process process = new Process();
            process.StartInfo.FileName = pythonPath;
            process.StartInfo.Arguments = scriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.WorkingDirectory = @"..\..\Scripts";

            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            // Display output (if needed)
            MessageBox.Show("Python script executed:\n" + output);

            // --------------------------------------------

            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("simulateHorseFlight", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@animalCount", int.Parse(count));
            command.Parameters.AddWithValue("@date", DateTime.Now);

            command.ExecuteNonQuery();
        }

        public void simulateDroneFightSheep()
        {
            string path = @"..\..\Scripts\sheep_counts.txt";
            string count = File.ReadAllText(path);

            string pythonPath = @"..\..\Scripts\venv\Scripts\python.exe";
            string scriptPath = @"..\Scripts\Sheep.py"; 

            Process process = new Process();
            process.StartInfo.FileName = pythonPath;
            process.StartInfo.Arguments = scriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.WorkingDirectory = @"..\..\Scripts";

            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            MessageBox.Show("Python script executed:\n" + output);

            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("simulateSheepFlight", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@animalCount", int.Parse(count));
            command.Parameters.AddWithValue("@date", DateTime.Now);

            command.ExecuteNonQuery();
        }


        public void dateList()
        {
            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("dateDisplayList", connection);
 
            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DateTime valueOfDate = reader.GetDateTime(0);
                cbDatesList.Items.Add(valueOfDate.ToString("yyyy-MM-dd")); 
            }

            reader.Close();

            connection.Close();
        }

        public TrackingData()
        {
            InitializeComponent();
        }

        private void cbDatesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbDatesList.SelectedItem.ToString();

            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("viewTrackingViaDate", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@listDate", selectedValue);

            adapter = new SqlDataAdapter(command);

            dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvTrackingData.DataSource = dataTable;

            connection.Close();
        }


        private void btnCows_Click(object sender, EventArgs e)
        {
            simulateDroneFlightCows();

            cowData();
        }

        private void btnSheep_Click(object sender, EventArgs e)
        {
            simulateDroneFightSheep();

            sheepData();
        }

        private void btnHorse_Click(object sender, EventArgs e)
        {
            simulateDroneFlightHorses();

            horseData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimise_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login loginForm = new Login();
            loginForm.Show();
        }

        //this method is for launching the ardu pilot application:
        private async void btnLaunch_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Launching ArduPilot...");
                string cygwinExecutable = @"C:\cygwin64\bin\mintty.exe"; 
                string commands = "cd /cygdrive/e/ardupilot/ArduCopter && ../Tools/autotest/sim_vehicle.py --map --console";

                ProcessStartInfo cygwinStartInfo = new ProcessStartInfo
                {
                    FileName = cygwinExecutable,
                    Arguments = $"-e /bin/bash -l -c \"{commands} 2>&1\"", 
                    WorkingDirectory = "C:\\cygwin64\\bin", 
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                };

                Process cygwinProcess = new Process
                {
                    StartInfo = cygwinStartInfo,
                    EnableRaisingEvents = true
                };

                cygwinProcess.Start();

                await Task.Run(() => cygwinProcess.WaitForExit());

                ProcessStartInfo cmdStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true, 
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process cmdProcess = new Process
                {
                    StartInfo = cmdStartInfo,
                    EnableRaisingEvents = true
                };

                cmdProcess.Start();

                StreamWriter sw = cmdProcess.StandardInput;
                StreamReader sr = cmdProcess.StandardOutput;

                // Change the drive to E:
                sw.WriteLine("E:");

                sw.WriteLine(@"E:\ardupilot\Tools\autotest\fg_quad_view.bat 2>&1");

                sw.Close();
                await Task.Run(() => cmdProcess.WaitForExit());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        
        private void btnEvening_Click(object sender, EventArgs e)
        {
            try
            {
                string pythonExecutable = @"..\..\Scripts\venv\Scripts\python.exe"; 
                string pythonScript = @"..\Scripts\mainArdu.py"; 

                ProcessStartInfo pythonStartInfo = new ProcessStartInfo
                {
                    FileName = pythonExecutable,
                    Arguments = pythonScript,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = @"C:\Github Repos\Livestock-Tracking-updated-4-\Livestock Tracking(updated)\Livestock Tracking\Scripts", // Set this to the correct working directory.
                };

                using (Process pythonProcess = new Process { StartInfo = pythonStartInfo })
                {
                    pythonProcess.Start();
                    pythonProcess.WaitForExit();
                }

                Console.WriteLine("Script successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnMorning_Click(object sender, EventArgs e)
        {
            try
            {
                string pythonExecutable = @"..\..\Scripts\venv\Scripts\python.exe"; 
                string pythonScript = @"..\Scripts\mainArdu2.py"; 


                ProcessStartInfo pythonStartInfo = new ProcessStartInfo
                {
                    FileName = pythonExecutable,
                    Arguments = pythonScript,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = @"C:\Github Repos\Livestock-Tracking-updated-4-\Livestock Tracking(updated)\Livestock Tracking\Scripts", // Set this to the correct working directory.
                };

                using (Process pythonProcess = new Process { StartInfo = pythonStartInfo })
                {
                    pythonProcess.Start();
                    pythonProcess.WaitForExit();
                }

                Console.WriteLine("script successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        public void Thermal()
        {
            string path = @"..\..\Scripts\temperature.txt";
            string text = File.ReadAllText(path);

            string pythonPath = @"..\..\Scripts\venv\Scripts\python.exe"; 
            string scriptPath = @"..\Scripts\Thermal.py"; 

            Process process = new Process();
            process.StartInfo.FileName = pythonPath;
            process.StartInfo.Arguments = scriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.WorkingDirectory = @"..\..\Scripts";

            
            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            MessageBox.Show("Python script executed:\n" + output);
        }


        public void simulateDroneFlightTigers()
        {
            string path = @"..\..\Scripts\tiger_counts.txt";
            string text = File.ReadAllText(path);

            string pythonPath = @"..\..\Scripts\venv\Scripts\python.exe"; 
            string scriptPath = @"..\Scripts\Tigers.py"; 

            Process process = new Process();
            process.StartInfo.FileName = pythonPath;
            process.StartInfo.Arguments = scriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.WorkingDirectory = @"..\..\Scripts";

            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            MessageBox.Show("Python script executed:\n" + output);



            

        }


        private void btnTiger_Click(object sender, EventArgs e)
        {
            simulateDroneFlightTigers();
        }

        private void btnThermal_Click(object sender, EventArgs e)
        {
            Thermal();
        }

        private void btnCows1_Click(object sender, EventArgs e)
        {
            cowData();

            lblHeader.Text = "Cows";
        }

        private void btnHorses1_Click(object sender, EventArgs e)
        {
            horseData();

            lblHeader.Text = "Horses";
        }

        private void btnSheep1_Click(object sender, EventArgs e)
        {
            sheepData();

            lblHeader.Text = "Sheep";
        }

        private void btnOverall_Click(object sender, EventArgs e)
        {
            overallData();
        }

        private void dgvTrackingData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvTrackingData.Rows)
            {
                
                if (row.Cells[4] != null && row.Cells[4].Value != null)
                {
                    if (row.Cells[4].Value.ToString() != "0")
                    {
                        row.Cells[4].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        
                        row.Cells[4].Style.BackColor = dgvTrackingData.DefaultCellStyle.BackColor;
                    }
                }
            }

        }

        private void btnWebCam_Click(object sender, EventArgs e)
        {
            string path = @"..\..\Scripts\people_counts.txt";
            string count = File.ReadAllText(path);

            string pythonPath = @"..\..\Scripts\venv\Scripts\python.exe"; 
            string scriptPath = @"..\Scripts\DroneCamera.py"; 

            Process process = new Process();
            process.StartInfo.FileName = pythonPath;
            process.StartInfo.Arguments = scriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.WorkingDirectory = @"..\..\Scripts";

            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            MessageBox.Show("Python script executed:\n" + output);



            
        }
    }
}
