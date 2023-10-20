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


        public TrackingData()
        {
            InitializeComponent();
        }


        private void TrackingData_Load(object sender, EventArgs e)
        {
            overallData();
            dateList();
        }


        // Methods to collect data from the database and dispaly it in the data grid view. 
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

            lblHeader.Text = "Overall tracking data";
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

            lblHeader.Text = "Cows";
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

            lblHeader.Text = "Horses";
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

            lblHeader.Text = "Sheep";
        }



        // Methods for running Python scripts for the drone simulation flights.
        public void simulateDroneFlightCows()
        {
            string path = @"..\..\Scripts\cow_counts.txt";
            string count = File.ReadAllText(path);

            string pythonExeFile = @"..\..\Scripts\venv\Scripts\python.exe"; 
            string scriptPath = @"..\Scripts\main.py"; 

            Process process = new Process();
            process.StartInfo.FileName = pythonExeFile;
            process.StartInfo.Arguments = scriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.WorkingDirectory = @"..\..\Scripts";

            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            // ------------------------------------------------

            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("simulateCowFlight", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@animalCount", int.Parse(count));
            command.Parameters.AddWithValue("@date", DateTime.Now);

            command.ExecuteNonQuery();

        }

        public void simulateDroneFlightHorses()
        {
            string path = @"..\..\Scripts\horse_counts.txt";
            string count = File.ReadAllText(path);

            string pythonExeFile = @"..\..\Scripts\venv\Scripts\python.exe"; 
            string scriptPath = @"..\Scripts\Horses.py"; 

            Process process = new Process();
            process.StartInfo.FileName = pythonExeFile;
            process.StartInfo.Arguments = scriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.WorkingDirectory = @"..\..\Scripts";

            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            // ------------------------------------------------

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

            string pythonExeFile = @"..\..\Scripts\venv\Scripts\python.exe";
            string scriptPath = @"..\Scripts\Sheep.py"; 

            Process process = new Process();
            process.StartInfo.FileName = pythonExeFile;
            process.StartInfo.Arguments = scriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.WorkingDirectory = @"..\..\Scripts";

            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            // ------------------------------------------------

            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("simulateSheepFlight", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@animalCount", int.Parse(count));
            command.Parameters.AddWithValue("@date", DateTime.Now);

            command.ExecuteNonQuery();
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

            
        }


        // Event for running live cam.
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


        public void dateList()
        {
            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("displayAllDates", connection);

            command.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();

            cbDatesList.Items.Clear();

            while (reader.Read())
            {
                DateTime valueOfDate = reader.GetDateTime(0);
                cbDatesList.Items.Add(valueOfDate.ToString("yyyy-MM-dd"));
            }

            reader.Close();

            connection.Close();
        }

        private void cbDatesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbDatesList.SelectedItem.ToString();

            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("displayByDate", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@selectedDate", selectedValue); ;

            adapter = new SqlDataAdapter(command);

            dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvTrackingData.DataSource = dataTable;

            connection.Close();
        }

        private void btnSearchClear_Click(object sender, EventArgs e)
        {
            overallData();
        }


        // Runs the Python scripts methods, counts the animals on the footage and adds the count to the database.
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


        // Runs the Python scripts methods and detects any threats on the farm.
        private void btnTiger_Click(object sender, EventArgs e)
        {
            simulateDroneFlightTigers();
        }

        // Runs the Python scripts methods, and detects the temperature of animals.
        private void btnThermal_Click(object sender, EventArgs e)
        {
            Thermal();
        }


        // This event is for launching the ardu pilot application.
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

        // This event is for launching a evening flight.
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


        // This event is for launching a morning flight.
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


        // Methods for navigating to different pages on the form to see specific animal data. 
        //private void btnOverallNav_Click(object sender, EventArgs e)

        //public void Thermal()
        //{
        //    string path = @"..\..\Scripts\temperature.txt";
        //    string text = File.ReadAllText(path);

        //    string pythonPath = @"..\..\Scripts\venv\Scripts\python.exe"; 
        //    string scriptPath = @"..\Scripts\Thermal.py"; 

        //    Process process = new Process();
        //    process.StartInfo.FileName = pythonPath;
        //    process.StartInfo.Arguments = scriptPath;
        //    process.StartInfo.UseShellExecute = false;
        //    process.StartInfo.RedirectStandardOutput = true;
        //    process.StartInfo.CreateNoWindow = true;

        //    process.StartInfo.WorkingDirectory = @"..\..\Scripts";

            
        //    process.Start();

        //    string output = process.StandardOutput.ReadToEnd();

        //    process.WaitForExit();

        //    MessageBox.Show("Python script executed:\n" + output);
        //}


        //public void simulateDroneFlightTigers()
        //{
        //    string path = @"..\..\Scripts\tiger_counts.txt";
        //    string text = File.ReadAllText(path);

        //    string pythonPath = @"..\..\Scripts\venv\Scripts\python.exe"; 
        //    string scriptPath = @"..\Scripts\Tigers.py"; 

        //    Process process = new Process();
        //    process.StartInfo.FileName = pythonPath;
        //    process.StartInfo.Arguments = scriptPath;
        //    process.StartInfo.UseShellExecute = false;
        //    process.StartInfo.RedirectStandardOutput = true;
        //    process.StartInfo.CreateNoWindow = true;

        //    process.StartInfo.WorkingDirectory = @"..\..\Scripts";

        //    process.Start();

        //    string output = process.StandardOutput.ReadToEnd();

        //    process.WaitForExit();

        //    MessageBox.Show("Python script executed:\n" + output);



            

        //}


        //private void btnTiger_Click(object sender, EventArgs e)
        //{
        //    simulateDroneFlightTigers();
        //}

        //private void btnThermal_Click(object sender, EventArgs e)
        //{
        //    Thermal();
        //}

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

        private void btnOverallNav_Click(object sender, EventArgs e)
        {
            overallData();
        }


        private void btnSheepNav_Click(object sender, EventArgs e)
        {
            sheepData();           
        }

        private void btnHorsesNav_Click(object sender, EventArgs e)
        {
            horseData();
        }

        private void btnCowsNav_Click(object sender, EventArgs e)
        {
            cowData();
        }

        // Event to log out of the main form and go back to the log in form.
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login loginForm = new Login();
            loginForm.Show();
        }


        // Event for minimizing the form. 
        private void btnMinimise_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Event for closing the form.
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // Event for formatting "missing" column values RED if there are missing animals.
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


       
    }
}
