using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace AutoCreateProfileGPM
{
    public partial class Form1 : Form
    {
        const String PythonHelper = "TeleAPI.py";
        const String API_URL_GROUPS = "http://127.0.0.1:19995/api/v3/groups";
        const String API_URL_CREATE_PROFILE = "http://127.0.0.1:19995/api/v3/profiles/create";
        const String API_URL_START_PROFILE = "http://127.0.0.1:19995/api/v3/profiles/start/{id}";
        const String API_HASH = "45a942eda56632cefbed8f575937f453";
        const String API_ID = "27978242";

        String sessionFilePath = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            reloadGroup();
        }

        private void btn_browser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                txt_FolderSession.Text = browserDialog.SelectedPath;
                sessionFilePath = browserDialog.SelectedPath;
            }
            loadAllSessionFile();

        }

        private List<String> getAllSessionFile(String path)
        {
            List<String> list = new List<String>();
            if (path == null || path.Length == 0)
            {
                return list;
            }
            String[] files = System.IO.Directory.GetFiles(path);

            foreach (String file in files)
            {
                if (file.EndsWith(".session"))
                {
                    list.Add(file);
                }
            }
            return list;
        }

        private void loadAllSessionFile()
        {
            List<String> list = getAllSessionFile(txt_FolderSession.Text);
            foreach (String file in list)
            {
                String[] arr = file.Split('\\');
                String fileName = arr[arr.Length - 1];
                lb_sessionfile.Items.Add(fileName);
            }
        }

        static string RunPythonScript(string relativeScriptPath, String agr)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string scriptPath = Path.Combine(baseDirectory, relativeScriptPath);

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "cmd.exe";
            start.Arguments = $"/C python {scriptPath} {agr}";
            Console.WriteLine(start.Arguments);
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            start.UseShellExecute = false;
            start.CreateNoWindow = true;

            string result = "";

            using (Process process = Process.Start(start))
            {
                // Ensure the process completes before reading the output
                process.WaitForExit();  // Wait for Python to finish

                using (System.IO.StreamReader reader = process.StandardOutput)
                {
                    result = reader.ReadToEnd();  // Capture the result
                }

                string error = process.StandardError.ReadToEnd();
                if (!string.IsNullOrEmpty(error))
                {
                    result += "false";
                }
            }

            return result;
        }


        private void btn_refreshGroup_Click(object sender, EventArgs e)
        {
            reloadGroup();
        }

        private void reloadGroup()
        {
            //.\TeleAPI.py get_groups http://127.0.0.1:19995/api/v3/groups

            string result = RunPythonScript(PythonHelper,  " get_groups " + API_URL_GROUPS);
            if (result == "false")
            {
                MessageBox.Show("Error when get group");
                return;
            }
            String[] Groups = result.Split('-');
            foreach (String group in Groups)
            {
                cbo_GPMGroup.Items.Add(group);
            }
        }

        private void btn_f2aDisplay_Click(object sender, EventArgs e)
        {
            if(btn_f2aDisplay.Text == "Show")
            {
                btn_f2aDisplay.Text = "Hide";
                txt_F2A.UseSystemPasswordChar = false;
            }
            else
            {
                btn_f2aDisplay.Text = "Show";
                txt_F2A.UseSystemPasswordChar = true;
            }

        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            //foreach (String sessionFile in lb_sessionfile.Items)
            //{
            //    startAutoCreateProfile(sessionFile);
            //}

            List<String> list = lb_sessionfile.Items.Cast<String>().ToList();
            int maxThread = Convert.ToInt32(N_Thread.Value);

            using (SemaphoreSlim concurrencySemaphore = new SemaphoreSlim(maxThread)
            {
                var tasks = list.Select(sessionFile => Task.Run(() =>
                {
                    concurrencySemaphore.Wait();
                    try
                    {
                        startAutoCreateProfile(sessionFile);
                    }
                    finally
                    {
                        concurrencySemaphore.Release();
                    }
                })).ToArray();
            }
        }


        private void startAutoCreateProfile(string sessionFile)
        {
            // lấy số điện thoại từ tên file
            string phoneNumber = sessionFile.Split('.')[0];
            string group = cbo_GPMGroup.Text;
            string f2a = txt_F2A.Text;

            // tạo profile cần đường dẫn api , số điện thoại, group, f2a
            String cmdCreateProfile =" create_profile " + $"\"{API_URL_CREATE_PROFILE}\" \"{phoneNumber}\" \"{ group.Trim()}\"";
            string result = RunPythonScript(PythonHelper, cmdCreateProfile).Trim();
            if (result == "false")
            {
                Console.WriteLine("Error when create profile");
                return;
            }

            // lấy id profile
            string idProfile = result;


            // khởi chạy profile

            String cmdStartProfile =  " start_profile " + API_URL_START_PROFILE + " " + idProfile;
            result = RunPythonScript(PythonHelper, cmdStartProfile).Trim();
            if (result == "false")
            {
                Console.WriteLine("Error when start profile");
                return;
            }

            string debuggerAddress = result.Split('-')[0].Trim();
            string driverPath = result.Split('-')[1].Trim();
            
            // đăng nhập bằng selenium
            startAutoLogin(driverPath, debuggerAddress, phoneNumber);

            // thoát khỏi profile
            // chưa triển khai


        }

        private string GetOTP(string sessionPath, string api_id, string api_hash)
        {
            //.\TeleAPI.py get_otp http://

            String cmdGetOTP = " getOTPCode " + sessionPath + " " + api_id + " " + api_hash;
            string result = RunPythonScript(PythonHelper, cmdGetOTP);
            if (result == "false")
            {
                Console.WriteLine("Error when get OTP");
                return "";
            }
            return result;
        }

    // startAutoLogin cũng dùng async
    private async Task startAutoLoginAsync(string DriverPath, string DebuggerAddress, string phoneNumber)
    {
        ChromeOptions options = new ChromeOptions();
        options.DebuggerAddress = DebuggerAddress;

        ChromeDriver driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl("https://web.telegram.org");
        await Task.Delay(30000); // Thay thế Thread.Sleep bằng Task.Delay để tránh khóa luồng

        Console.WriteLine("Find And Click Login By Phone");
        IWebElement element = driver.FindElement(By.CssSelector("#auth-pages > div > div.tabs-container.auth-pages__container > div.tabs-tab.page-signQR.active > div > div.input-wrapper > button"));
        element.Click();
        await Task.Delay(5000);

        Console.WriteLine("Input Phone Number");
        IWebElement phone = driver.FindElement(By.CssSelector("#auth-pages > div > div.tabs-container.auth-pages__container > div.tabs-tab.page-sign.active > div > div.input-wrapper > div.input-field.input-field-phone > div.input-field-input"));
        phone.SendKeys(phoneNumber);
        await Task.Delay(5000);

        Console.WriteLine("Click Next");
        IWebElement next = driver.FindElement(By.CssSelector("#auth-pages > div > div.tabs-container.auth-pages__container > div.tabs-tab.page-sign.active > div > div.input-wrapper > button.btn-primary.btn-color-primary.rp"));
        next.Click();

        // Get OTP
        String otpString = await GetOTPAsync(sessionFilePath + "\\" + phoneNumber + ".session", API_ID, $"\"{API_HASH}\"");
        Console.WriteLine("OTP: " + otpString);

        await Task.Delay(5000);

        Console.WriteLine("Input OTP Code");
        IWebElement otp = driver.FindElement(By.CssSelector("#auth-pages > div > div.tabs-container.auth-pages__container > div.tabs-tab.page-authCode.active > div > div.input-wrapper > div > input"));
        otp.SendKeys(otpString);

        driver.Quit();
    }

    private void btn_test_Click(object sender, EventArgs e)
        {

            String otp = GetOTP(sessionFilePath + "\\" + "84364440335" + ".session", API_ID, $"\"{API_HASH}\"");
            Console.WriteLine("OTP: " + otp);

        }
    }
}
