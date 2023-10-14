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


namespace Livestock_Tracking
{
    public partial class TrackingData : Form
    {

        string connectionString = "Server=localhost;Database=EastwoodFarm_DB;Integrated Security=True;";
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable dataTable;

        private void TrackingData_Load(object sender, EventArgs e)
        {
            cowTrackingData();
            dateList();
        }

        public void allAnimalsData()
        {
            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("displayAllTrackingData", connection);

            command.CommandType = CommandType.StoredProcedure;

            adapter = new SqlDataAdapter(command);

            dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvTrackingData.DataSource = dataTable;

            connection.Close();
        }

        public void cowTrackingData()
        {
            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("displayCowTrackingData", connection);

            command.CommandType = CommandType.StoredProcedure;

            adapter = new SqlDataAdapter(command);

            dataTable = new DataTable();

            adapter.Fill(dataTable);

            dgvTrackingData.DataSource = dataTable;

            connection.Close();
        }

        public void goatTrackingData() 
        {
            connection = new SqlConnection(connectionString);

            connection.Open();

            command = new SqlCommand("displayGoatTrackingData", connection);

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
            string text = File.ReadAllText(path);

            // Specify the path to python.exe and your Python script
            string pythonPath = @"..\..\Scripts\venv\Scripts\python.exe"; // Change to your Python interpreter path
            string scriptPath = @"..\Scripts\main.py"; // Change to your Python script path

            // Create a new process
            Process process = new Process();
            process.StartInfo.FileName = pythonPath;
            process.StartInfo.Arguments = scriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.WorkingDirectory = @"..\..\Scripts";

            // Start the process
            process.Start();

            // Read the output of the Python script (if needed)
            string output = process.StandardOutput.ReadToEnd();

            // Wait for the process to exit
            process.WaitForExit();

            // Display output (if needed)
            MessageBox.Show("Python script executed:\n" + output);
        


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("simulateFlight", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@animalCount", int.Parse(text));
                    command.Parameters.AddWithValue("@dateTime", DateTime.Now);

                    command.ExecuteNonQuery();

                }
            }

        }

        public void simulateDroneFlightHorses()
        {
            string path = @"..\..\Scripts\sheep_counts.txt";
            string text = File.ReadAllText(path);

            // Specify the path to python.exe and your Python script
            string pythonPath = @"..\..\Scripts\venv\Scripts\python.exe"; // Change to your Python interpreter path
            string scriptPath = @"..\Scripts\Horses.py"; // Change to your Python script path

            // Create a new process
            Process process = new Process();
            process.StartInfo.FileName = pythonPath;
            process.StartInfo.Arguments = scriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.WorkingDirectory = @"..\..\Scripts";

            // Start the process
            process.Start();

            // Read the output of the Python script (if needed)
            string output = process.StandardOutput.ReadToEnd();

            // Wait for the process to exit
            process.WaitForExit();

            // Display output (if needed)
            MessageBox.Show("Python script executed:\n" + output);
        }

        public void SimulateDroneFightSheep()
        {
            string path = @"..\..\Scripts\sheep_counts.txt";
            string text = File.ReadAllText(path);

            // Specify the path to python.exe and your Python script
            string pythonPath = @"..\..\Scripts\venv\Scripts\python.exe"; // Change to your Python interpreter path
            string scriptPath = @"..\Scripts\Sheep.py"; // Change to your Python script path

            // Create a new process
            Process process = new Process();
            process.StartInfo.FileName = pythonPath;
            process.StartInfo.Arguments = scriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.WorkingDirectory = @"..\..\Scripts";

            // Start the process
            process.Start();

            // Read the output of the Python script (if needed)
            string output = process.StandardOutput.ReadToEnd();

            // Wait for the process to exit
            process.WaitForExit();

            // Display output (if needed)
            MessageBox.Show("Python script executed:\n" + output);
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

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            cowTrackingData();
        }

        private void btnCows_Click(object sender, EventArgs e)
        {
            simulateDroneFlightCows();
        }

        private void btnSheep_Click(object sender, EventArgs e)
        {
            SimulateDroneFightSheep();
        }

        private void btnHorse_Click(object sender, EventArgs e)
        {
            simulateDroneFlightHorses();
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

        private async void btnLaunch_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Launching ArduPilot...");
                // Specify the path to the Cygwin64 executable (mintty.exe) and any desired command or arguments.
                string cygwinExecutable = @"C:\cygwin64\bin\mintty.exe"; // Update the path accordingly
                string commands = "cd /cygdrive/e/ardupilot/ArduCopter && ../Tools/autotest/sim_vehicle.py --map --console";

                ProcessStartInfo cygwinStartInfo = new ProcessStartInfo
                {
                    FileName = cygwinExecutable,
                    Arguments = $"-e /bin/bash -l -c \"{commands} 2>&1\"", // Add 2>&1 to redirect both stdout and stderr
                    WorkingDirectory = "C:\\cygwin64\\bin", // Set the working directory if needed
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

                // Wait for the first part (Cygwin) to complete
                await Task.Run(() => cygwinProcess.WaitForExit());

                // Now, start the second part (cmd)
                ProcessStartInfo cmdStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true, // Redirect standard error as well
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

                // Run the specified command
                sw.WriteLine(@"E:\ardupilot\Tools\autotest\fg_quad_view.bat 2>&1"); // Add 2>&1 here as well

                // Close the input stream and wait for the second part (cmd) to complete
                sw.Close();
                await Task.Run(() => cmdProcess.WaitForExit());

            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEvening_Click(object sender, EventArgs e)
        {
            try
            {
                // Specify the path to your Python interpreter (python.exe) and the path to your Python script (main2.py).
                string pythonExecutable = @"E:\GitHub Repos\Livestock-Tracking-updated-4-\Livestock Tracking(updated)\Livestock Tracking\Scripts\venv\Scripts\python.exe"; // Update this path.
                string pythonScript = @"E:\GitHub Repos\Livestock-Tracking-updated-4-\Livestock Tracking(updated)\Livestock Tracking\Scripts\mainArdu.py"; // Update this path.

                ProcessStartInfo pythonStartInfo = new ProcessStartInfo
                {
                    FileName = pythonExecutable,
                    Arguments = pythonScript,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = @"E:\GitHub Repos\Livestock-Tracking-updated-4-\Livestock Tracking(updated)\Livestock Tracking\Scripts", // Set this to the correct working directory.
                };

                using (Process pythonProcess = new Process { StartInfo = pythonStartInfo })
                {
                    pythonProcess.Start();
                    pythonProcess.WaitForExit();
                }

                // Optionally, you can display a message or perform other actions after script execution.
                MessageBox.Show("Python script executed successfully.");
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
                // Specify the path to your Python interpreter (python.exe) and the path to your Python script (main2.py).
                string pythonExecutable = @"E:\GitHub Repos\Livestock-Tracking-updated-4-\Livestock Tracking(updated)\Livestock Tracking\Scripts\venv\Scripts\python.exe"; // Update this path.
                string pythonScript = @"E:\GitHub Repos\Livestock-Tracking-updated-4-\Livestock Tracking(updated)\Livestock Tracking\Scripts\mainArdu2.py"; // Update this path.

                ProcessStartInfo pythonStartInfo = new ProcessStartInfo
                {
                    FileName = pythonExecutable,
                    Arguments = pythonScript,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = @"E:\GitHub Repos\Livestock-Tracking-updated-4-\Livestock Tracking(updated)\Livestock Tracking\Scripts", // Set this to the correct working directory.
                };

                using (Process pythonProcess = new Process { StartInfo = pythonStartInfo })
                {
                    pythonProcess.Start();
                    pythonProcess.WaitForExit();
                }

                // Optionally, you can display a message or perform other actions after script execution.
                MessageBox.Show("Python script executed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SendCommandsToMavProxy(string[] commands)
        {
            Process[] processes = Process.GetProcessesByName("mavproxy");

            foreach (Process process in processes)
            {
                if (!string.IsNullOrWhiteSpace(process.MainWindowTitle) && process.MainWindowTitle.Contains("C:\\Program Files (x86)\\MAVProxy\\mavproxy.exe"))
                {
                    StreamWriter sw = process.StandardInput;
                    foreach (string command in commands)
                    {
                        Debug.WriteLine($"Sending command: {command}");
                        sw.WriteLine(command);
                    }
                    sw.Close();
                }
            }
        }
    }
}
