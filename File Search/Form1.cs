namespace File_Search
{
    using System.Text.RegularExpressions;
    using FileSearchOptions;
    public partial class Form1 : Form
    {
        ManualResetEvent[] manual_event = { new(true), new(false), new(false) };
        SynchronizationContext? uiContext;
        Thread? t;
        int Counter_Files;
        bool Check;
        public Form1()
        {
            InitializeComponent();
            string[] LogicalDrives = System.IO.Directory.GetLogicalDrives();
            uiContext = SynchronizationContext.Current;
            Counter_Files = 0;
            Check = false;
            button2.Enabled = false;
            button3.Enabled = false;
            timer1.Start();
            comboBox1.DataSource = LogicalDrives;
        }
        public void ResultCountFiles(object value)
        {
            try
            {
                if (value is FileSearchOptions)
                {
                    int CountFiles = 0;
                    StreamReader? reader = null;
                    MatchCollection mc;
                    FileSearchOptions file_search_options = (FileSearchOptions)value;
                    FileInfo[] files = file_search_options.dirInfo.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        if (file_search_options.regMask.IsMatch(file.Name))
                        {
                            manual_event[0].WaitOne();
                            if (manual_event[1].WaitOne(0))
                                break;
                            ++CountFiles;
                            ++Counter_Files;
                            SendOrPostCallback result = (parametr) => label4.Text = $"Результати пошуку: кількість знайдених файлів: {CountFiles}";
                            uiContext?.Send(result, null);
                            SendOrPostCallback result_files = (parametr) => listBox1.Items.Add($"Name: {file.Name}  Folder: {file.FullName}  Size: {file.Length}  Date: {file.LastWriteTime}");
                            uiContext?.Send(result_files, null);
                            if (file_search_options.regText != null)
                            {
                                reader = new(file.FullName);
                                string read_to_end = reader.ReadToEnd();
                                mc = file_search_options.regText.Matches(read_to_end);
                                foreach (Match m in mc)
                                {
                                    SendOrPostCallback position_word = (parametr) => label4.Text = $"Результати пошуку: {m.Index}. Кількість знайдених файлів: {CountFiles}";
                                    uiContext?.Send(position_word, null);
                                }
                            }
                        }
                    }
                    if (manual_event[2].WaitOne(0))
                    {
                        DirectoryInfo[] di = file_search_options.dirInfo.GetDirectories();
                        foreach (DirectoryInfo d in di)
                        {
                            if (manual_event[1].WaitOne(0))
                                break;
                            ResultCountFiles(new FileSearchOptions { regText = file_search_options.regText, dirInfo = d, regMask = file_search_options.regMask });
                        }
                    }
                    SendOrPostCallback return_result = (parametr) =>
                    {
                        label4.Text = $"Результати пошуку: кількість знайдених файлів: {Counter_Files}";
                    };
                    uiContext?.Send(return_result, null);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Click_Search(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                manual_event[1].Reset();
                manual_event[0].Set();
                listBox1.Items.Clear();
                Counter_Files = 0;
                button3.Text = "Призупинити";
                button2.Enabled = true;
                button3.Enabled = true;
                string path = comboBox1.Text;
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (dirInfo.Exists)
                {
                    string? word;
                    if (textBox2.Text != "")
                        word = Regex.Escape(textBox2.Text);
                    else
                        word = null;
                    Regex? textReg = (word == null) ? null : new Regex(word, RegexOptions.IgnoreCase);
                    string mask = textBox1.Text.Replace(".", @"\.");
                    mask = mask.Replace('?', '.');
                    mask = mask.Replace("(", @"\(");
                    mask = mask.Replace(")", @"\)");
                    mask = mask.Replace("*", ".*");
                    mask = "^" + mask + "$";
                    Regex maskReg = new(mask, RegexOptions.IgnoreCase);
                    FileSearchOptions value = new FileSearchOptions { regText = textReg, dirInfo = dirInfo, regMask = maskReg };
                    t = new(ResultCountFiles!);
                    t.Start(value);
                }
            }
            else
                MessageBox.Show("Заповніть поле", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Click_CheckBox(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                manual_event[2].Set();
            }
            else
                manual_event[2].Reset();
        }

        private void Click_Stop(object sender, EventArgs e)
        {
            manual_event[1].Set();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void Click_Suspend(object sender, EventArgs e)
        {
            if (!Check)
            {
                manual_event[0].Reset();
                button1.Enabled = false;
                button3.Text = "Відновити";
                Check = true;
            }
            else
            {
                manual_event[0].Set();
                button1.Enabled = false;
                button3.Text = "Призупинити";
                Check = false;
            }
        }

        private void Tick_CheckIsAlive(object sender, EventArgs e)
        {
            if (t?.ThreadState == ThreadState.Stopped)
            {
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }
    }
}
