using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System;
using System.Collections.Generic;





namespace RegExReplace
{
    internal partial class SettingsForm_RegExReplace : Form
    {


        #region Get and Set Options

        public string SelectedEncoding { get; set; }
        public string RegexFile { get; set; }
        public Regex[] RegexArray { get; set; }
        public string[] ReplacementArray { get; set; }
        public bool fileLoaded { get; set; }
        public bool RegexCaseSensitive { get; set; }
        public bool CompactWhitespace { get; set; }

        #endregion



        public SettingsForm_RegExReplace(string RegexFile, string SelectedEncoding, Regex[] RegexArray, string[] ReplacementArray, bool fileLoaded, bool CaseSens, bool CompactWhite)

        {
            InitializeComponent();

            foreach (var encoding in Encoding.GetEncodings())
            {
                EncodingDropdown.Items.Add(encoding.Name);
            }

            try
            {
                EncodingDropdown.SelectedIndex = EncodingDropdown.FindStringExact(SelectedEncoding);
            }
            catch
            {
                EncodingDropdown.SelectedIndex = EncodingDropdown.FindStringExact(Encoding.Default.BodyName);
            }

            SelectedFileTextbox.Text = RegexFile;
            this.SelectedEncoding = SelectedEncoding;
            this.fileLoaded = fileLoaded;
            this.RegexArray = RegexArray;
            this.ReplacementArray = ReplacementArray;


            DataTable dt = new DataTable();
            dt.Columns.Add("RegEx");
            dt.Columns.Add("Replacement");

            CompactWhitespaceCheckbox.Checked = CompactWhite;
            CaseSensitiveCheckbox.Checked = CaseSens;

            if (fileLoaded)
            {
                //Map out the input entries
                for (int i = 0; i < RegexArray.Length; i++)
                {

                    System.Data.DataTable table = new System.Data.DataTable("RegExTable");

                    dt.Rows.Add(new string[] { RegexArray[i].ToString(), ReplacementArray[i] });

                }

                DataGridPreview.DataSource = null;
                DataGridPreview.Columns.Clear();
                DataGridPreview.Rows.Clear();
                DataGridPreview.DataSource = dt;
                DataGridPreview.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                DataGridPreview.AutoResizeColumns();
                DataGridPreview.Update();

            }









        }












        private void SetFolderButton_Click(object sender, System.EventArgs e)
        {


            SelectedFileTextbox.Text = "";

            using (var dialog = new OpenFileDialog())
            {
                dialog.Multiselect = false;
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.ValidateNames = true;
                dialog.Title = "Please choose your RegEx Dictionary File";
                dialog.FileName = "RegEx-Dictionary.txt";
                dialog.Filter = "Text File (*.txt)|*.txt";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SelectedFileTextbox.Text = dialog.FileName;

                    string RegexListFileRawText = "";

                    //Load dictionary file now
                    try
                    {
                        RegexListFileRawText = File.ReadAllText(dialog.FileName, Encoding.GetEncoding(EncodingDropdown.SelectedItem.ToString()));


                        //parse out the the dictionary file
                        List<Regex> RegexList = new List<Regex>();
                        List<string> ReplacementList = new List<string>();



                        DataTable dt = new DataTable();
                        dt.Columns.Add("RegEx");
                        dt.Columns.Add("Replacement");


                        string[] EntryLines = RegexListFileRawText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                        //Map out the input entries
                        for (int i = 0; i < EntryLines.Length; i++)
                        {

                            System.Data.DataTable table = new System.Data.DataTable("RegExTable");


                            string[] EntryRow = EntryLines[i].Split(new char[] { '\t' });

                            dt.Rows.Add(new string[] { EntryRow[0], EntryRow[1] });

                            if (CaseSensitiveCheckbox.Checked)
                            {
                                RegexList.Add(new Regex(@EntryRow[0], RegexOptions.Compiled));
                            }
                            else
                            {
                                RegexList.Add(new Regex(@EntryRow[0], RegexOptions.Compiled | RegexOptions.IgnoreCase));
                            }
                            ReplacementList.Add(EntryRow[1]);

                        }


                        RegexArray = RegexList.ToArray();
                        ReplacementArray = ReplacementList.ToArray();

                        fileLoaded = true;

                        DataGridPreview.DataSource = null;
                        DataGridPreview.Columns.Clear();
                        DataGridPreview.Rows.Clear();
                        DataGridPreview.DataSource = dt;
                        DataGridPreview.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        DataGridPreview.AutoResizeColumns();
                        DataGridPreview.Update();



                        MessageBox.Show("Your regular expression list has been successfully loaded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch
                    {
                        DataGridPreview.DataSource = null;
                        DataGridPreview.Columns.Clear();
                        DataGridPreview.Rows.Clear();
                        DataGridPreview.ColumnCount = 2;
                        DataGridPreview.Columns[0].Name = "RegEx";
                        DataGridPreview.Columns[1].Name = "Repacement";
                        DataGridPreview.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        DataGridPreview.Update();
                        SelectedFileTextbox.Text = "";
                        fileLoaded = false;
                        RegexArray = new Regex[0];
                        ReplacementArray = new string[0];
                        MessageBox.Show("BUTTER is having trouble reading data from your RegEx file. Is it open in another application?", "RegEx File Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            }

        }










        private void OKButton_Click(object sender, System.EventArgs e)
        {
            this.SelectedEncoding = EncodingDropdown.SelectedItem.ToString();
            this.RegexFile = SelectedFileTextbox.Text;
            this.RegexCaseSensitive = CaseSensitiveCheckbox.Checked;
            this.CompactWhitespace = CompactWhitespaceCheckbox.Checked;
            this.DialogResult = DialogResult.OK;

        }

        
    }
}
