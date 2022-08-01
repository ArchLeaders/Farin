using Discord;
using FarinResponceTool.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarinResponceTool
{
    public partial class FormApp : Form
    {
        private Dictionary<string, Dictionary<string, List<List<string>>>> jsonData = new();
        private string? currentKey;
        private bool isAuto = false;
        private List<string> hasRequested = new();

        private string Mode => CbxMode.Text.Replace("Requires @Farin", "Farin").Replace("Any message", "Any");

        public FormApp() => InitializeComponent();
        private void FormApp_FormClosed(object sender, FormClosedEventArgs e) => File.Delete(".\\temp.json");
        private async void FormApp_Load(object sender, EventArgs e)
        {
            await DiscordExtension.Connect(() => { return Task.CompletedTask; });

            Application.ThreadException += new ThreadExceptionEventHandler(async (s, e) => {
                Exception ex = e.Exception;
                MessageBox.Show(ex.Message, "Unhandled Exception");
                await ex.ReportToDiscord();
            });
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(async (s, e) => {
                Exception ex = (e.ExceptionObject as Exception)!;
                MessageBox.Show(ex.Message, "Unhandled Exception");
                await ex.ReportToDiscord();
            });

            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("farin-request-data", "responces");
            byte[] content = await client.GetByteArrayAsync("https://raw.githubusercontent.com/ArchLeaders/Farin/master/data/farin.json?v=8");

            jsonData = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, List<List<string>>>>>(content)!;

            GenerateItems();
            currentKey = null;
        }

        private void GenerateItems(string create = "None", string? selectedItem = null)
        {
            List<string> groups = new();
            string select = selectedItem ?? "";

            foreach (var mode in new string[] {"Farin", "Any"}) {
                jsonData[mode] = jsonData.ContainsKey(mode) ? jsonData[mode] : new();

                int i = 0;
                foreach (var set in jsonData[mode]) {
                    i++;
                    groups.Add($"{mode} ({i}) - [{(set.Value[1][0],20).Item1.Trim()}]");
                }

                if (mode == create && i + 1 >= jsonData[mode].Count) {
                    i++;
                    select = $"{mode} ({i}) - [{(TbTriggerResponce.Text, 20).Text.Trim()}]";
                    groups.Add(select);
                }
            }

            isAuto = true;
            CbxGroups.DataSource = groups;
            CbxGroups.Text = select;
            isAuto = false;
        }

        private void SetJson(bool del = false)
        {
            if (del) {
                jsonData[Mode].Remove(currentKey!);
            }
            else {
                jsonData[Mode][currentKey!] = new() {
                    TbTriggerWords.Text.Split("\r\n").ToList(),
                    new() {
                        TbTriggerResponce.Text,
                        $"{currentKey}|{TbTriggerWords.Text}|{TbTriggerResponce.Text}".Md5Hash(),
                    }
                };
            }

            File.WriteAllText(".\\temp.json", JsonSerializer.Serialize(jsonData, new JsonSerializerOptions() {
                WriteIndented = true
            }));
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            currentKey = $"{Mode}{jsonData[Mode].Keys.Count+1}";
            GenerateItems(Mode);

            TbTriggerWords.Text = "";
            TbTriggerResponce.Text = "";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (currentKey == null) {
                currentKey = $"{Mode}{jsonData[Mode].Keys.Count+1}";
                GenerateItems(Mode);
            }

            SetJson();
            GenerateItems(selectedItem: CbxGroups.Text);
        }

        private async void BtnRequest_Click(object sender, EventArgs e)
        {
            if (currentKey == null) {
                currentKey = $"{Mode}{jsonData[Mode].Keys.Count + 1}";
                GenerateItems(Mode);
            }

            string hash = $"{currentKey}|{TbTriggerWords.Text}|{TbTriggerResponce.Text}".Md5Hash();
            if (!hasRequested.Contains(hash)) {
                await TbTriggerResponce.Text.PushRequest(TbTriggerWords.Text, currentKey!);
                hasRequested.Add(hash);
            }
        }

        private void CbxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbxMode.Text = CbxGroups.Text.Split(' ')[0].Replace("Farin", "Requires @Farin").Replace("Any", "Any message");

            if (!isAuto) {
                currentKey = $"{Mode}{CbxGroups.Text.Split('(')[1].Split(')')[0]}";
            }
            else {
                return;
            }

            if (jsonData[Mode].ContainsKey(currentKey)) {
                TbTriggerWords.Text = string.Join("\r\n", jsonData[Mode][currentKey][0]);
                TbTriggerResponce.Text = jsonData[Mode][currentKey][1][0];
            }
        }


        private void BtnDel_Click(object sender, EventArgs e)
        {
            SetJson(del: true);
            GenerateItems();
        }

        private string? GetKey()
        {
            if (!File.Exists(".\\public.key")) {
                MessageBox.Show(this, "Could not find public key. Please use the request feature instead.", "Error");
                return null;
            }

            byte[] data = File.ReadAllBytes(".\\public.key");

            DialogPassword pswdDialog = new();
            pswdDialog.ShowDialog(this);

            if (pswdDialog.Password != null) {
                try {
                    data = data.DecryptBytes(pswdDialog.Password);
                }
                catch {
                    MessageBox.Show(this, "Password did not match.", "Error");
                    BtnSave_Click(null!, null!);
                }
            }

            return Encoding.ASCII.GetString(data);
        }

        private void BtnCreateKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Key File (*.key)|*.key";
            openFileDialog.Title = "Open key file.";
            var res = openFileDialog.ShowDialog();

            if (res == DialogResult.OK) {

                byte[] data = File.ReadAllBytes(openFileDialog.FileName);

                if (MessageBox.Show("Decrypt key first?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes) {

                    DialogPassword dePswdDlg = new();
                    dePswdDlg.ShowDialog();

                    bool success = false;
                    while (!success) {
                        try {

                            while (dePswdDlg.Password == null)
                                dePswdDlg.ShowDialog();

                            data = data.DecryptBytes(dePswdDlg.Password);
                            success = true;
                        }
                        catch {
                            continue;
                        }
                    }
                }

                DialogPassword pswdDlg = new();
                pswdDlg.Text = "Enter New Password";
                pswdDlg.ShowDialog();

                while (pswdDlg.Password == null)
                    pswdDlg.ShowDialog();

                data = data.EncryptBytes(pswdDlg.Password);
                File.WriteAllBytes(openFileDialog.FileName, data);
            }
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string? key = GetKey();

            // sync
        }

        private void CbxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isAuto) {
                currentKey = $"{Mode}{(CbxGroups.Text != "" ? CbxGroups.Text.Split('(')[1].Split(')')[0] : jsonData[Mode].Keys.Count+1)}";
            }
        }
    }
}
