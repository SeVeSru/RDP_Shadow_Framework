using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.IO;
using System.Windows.Forms;

namespace RDP_Shadow_Framework
{
    public partial class Form1 : Form
    {
        private static readonly Timer timer = new Timer();
        private readonly int  timerInterval = 10000; // интервер в мс обновления списка
        private readonly string stDomen = Environment.UserDomainName; // Домен
        //private readonly string  stServer = "192.168.11.225"; // Сервер

        public Form1()
        {
            InitializeComponent();
            
            LDAP_server();

            //RefreshSessionList();

            // Устанавливаем интервал таймера в милисекундах
            timer.Interval = timerInterval;

            // Добавляем обработчик события Tick
            timer.Tick += refreshButton_Click_1;
        }

        private void LDAP_server()
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://DC=" + stDomen + ",DC=loc"); // replace with your AD server address
            DirectorySearcher searcher = new DirectorySearcher(entry);
            searcher.Filter = "(&(objectClass=computer)(operatingSystem=*Server*))"; // filter for server computers

            SearchResultCollection results = searcher.FindAll(); // execute search and get results
            List<string> serverNames = new List<string>();

            foreach (SearchResult result in results)
            {
                string serverName = result.Properties["Name"][0].ToString(); // get server name
                serverNames.Add(serverName); // add server name to List<string>
            }

            serverNames.Sort(); // sort alphabetically

            foreach (string serverName in serverNames)
            {
                serverComboBox.Items.Add(serverName); // add server name to ComboBox
            }
        }

        private string GetFullNameByLogin(string login)
        {
            using (var entry = new DirectoryEntry($"LDAP://{stDomen}"))
            {
                using (var search = new DirectorySearcher(entry))
                {
                    search.Filter = $"(&(objectClass=user)(sAMAccountName={login}))";
                    search.PropertiesToLoad.Add("displayName");
                    var result = search.FindOne();
                    if (result != null)
                    {
                        return result.Properties["displayName"][0].ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
            }
        }
        public void RefreshSessionList()
        {
            // Создаем словарь, где ключ - идентификатор сессии, а значение - элемент списка
            var sessionDict = new Dictionary<string, ListViewItem>();
            foreach (ListViewItem item in sessionListView.Items)
            {
                if (item.SubItems.Count >= 2)
                {
                    sessionDict[item.SubItems[1].Text] = item;
                }
            }
            string queryPath = string.Empty;
            if (Environment.Is64BitOperatingSystem && !Environment.Is64BitProcess)
                queryPath = Path.Combine(Environment.GetEnvironmentVariable("windir"), "Sysnative", "query.exe");
            else
                queryPath = Path.Combine(Environment.GetEnvironmentVariable("windir"), "System32", "query.exe");
            string stServer = serverComboBox.Text;
            Process process = new Process();
            process.StartInfo.FileName = queryPath;
            process.StartInfo.Arguments = $"session /server:{stServer}";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.Domain = Environment.UserDomainName;
            process.StartInfo.CreateNoWindow = true;
            string output = "";
            process.Start();
            bool processExited = process.WaitForExit(5000); // ожидание 5 секунд
            if (processExited)
            {
                output = process.StandardOutput.ReadToEnd();
            }
            else
            {
                process.Kill(); // Убивает процесс
                MessageBox.Show("Сервер не отвечает", "Сервер не отвечает", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Обновляем или добавляем элементы списка
            string[] lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 2; i < lines.Length - 1; i++)
            {
                string[] fields = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (fields.Length >= 3 && fields[0].Contains("rdp-tcp#"))
                {
                    string sessionId = fields[2];
                    ListViewItem item;
                    if (sessionDict.ContainsKey(sessionId))
                    {
                        // Обновляем значения элемента списка
                        item = sessionDict[sessionId];
                        if (item.SubItems.Count >= 3) // Проверяем, что элемент существует
                        {
                            item.SubItems[0].Text = fields[1];
                            item.SubItems[2].Text = fields[3];
                        }
                    }
                    else
                    {
                        // Добавляем новый элемент в список
                        item = new ListViewItem(fields[1]);
                        item.SubItems.Add(sessionId);
                        item.SubItems.Add(fields.Length >= 4 ? fields[3] : ""); // Проверяем, что элемент существует

                        // Получаем ФИО пользователя и добавляем его в колонку списка
                        string login = fields[1].Substring(fields[1].IndexOf("\\") + 1);
                        string fullName = GetFullNameByLogin(login);
                        item.SubItems.Add(fullName);

                        sessionListView.Items.Add(item);
                    }
                    // Удаляем сессию из словаря, чтобы в конце остались только удаленные сессии
                    sessionDict.Remove(sessionId);
                }
            }

            // Удаляем элементы списка, соответствующие удаленным сессиям
            foreach (var pair in sessionDict)
            {
                sessionListView.Items.Remove(pair.Value);
            }
        }

        private void refreshButton_Click_1(object sender, EventArgs e)
        {
            RefreshSessionList();
        }

        private void shadowButton_Click_1(object sender, EventArgs e)
        {
            if (sessionListView.SelectedItems.Count > 0 && sessionListView.SelectedItems[0].SubItems.Count > 1)
            {
                int sessionId = int.Parse(sessionListView.SelectedItems[0].SubItems[1].Text);
                Process process = new Process();
                process.StartInfo.FileName = "mstsc.exe";
                string Options = "/noConsentPrompt";
                if (checkControl.Checked)
                {
                    Options = Options + " /control";
                }
                process.StartInfo.Arguments = $"/shadow:{sessionId} /v:RDP1 {Options}";

                process.Start();
            }
        }

        private void sessionListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            shadowButton_Click_1(sender, e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RefreshSessionList();
                e.Handled = true; // Это предотвращает дальнейшую обработку нажатия клавиши F5 формой
            }
        }

        private void AutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoUpdate.Checked)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }
    }
}
