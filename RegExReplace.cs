using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using PluginContracts;
using OutputHelperLib;
using System.Text.RegularExpressions;


namespace RegExReplace
{
    public class RegExReplace : Plugin
    {


        public string[] InputType { get; } = { "String" };
        public string OutputType { get; } = "String";

        public Dictionary<int, string> OutputHeaderData { get; set; } = new Dictionary<int, string>() { { 0, "TokenizedText" } };
        public bool InheritHeader { get; } = true;

        #region Plugin Details and Info

        public string PluginName { get; } = "RegEx Replacement";
        public string PluginType { get; } = "Preprocessing";
        public string PluginVersion { get; } = "1.0.1";
        public string PluginAuthor { get; } = "Ryan L. Boyd (ryan@ryanboyd.io)";
        public string PluginDescription { get; } = "Find and replace parts of your text using Regular Expressions. Example RegEx Replacement lists can be found here:" + Environment.NewLine + Environment.NewLine +
            "https://osf.io/t9q3r/" + Environment.NewLine + Environment.NewLine +
            "More information on Regular Expressions can be found here:" + Environment.NewLine + Environment.NewLine +
            "https://www.regular-expressions.info/";
        public bool TopLevel { get; } = false;
        public string PluginTutorial { get; } = "Coming Soon";


        public Icon GetPluginIcon
        {
            get
            {
                return Properties.Resources.icon;
            }
        }

        #endregion








        private string SelectedEncoding { get; set; } = "utf-8";
        private string RegexFile { get; set; } = "";
        private Regex[] RegexArray { get; set; }
        private string[] ReplacementArray { get; set; }
        private bool fileLoaded { get; set; } = false;
        private bool RegexCaseSensitive { get; set; } = false;
        private bool CompactWhitespace { get; set; } = true;

        public void ChangeSettings()
        {

            using (var form = new SettingsForm_RegExReplace(RegexFile, SelectedEncoding, RegexArray, ReplacementArray, fileLoaded, RegexCaseSensitive, CompactWhitespace))
            {


                form.Icon = Properties.Resources.icon;
                form.Text = PluginName;


                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    RegexFile = form.RegexFile;
                    SelectedEncoding = form.SelectedEncoding;
                    RegexArray = form.RegexArray;
                    ReplacementArray = form.ReplacementArray;
                    fileLoaded = form.fileLoaded;
                    RegexCaseSensitive = form.RegexCaseSensitive;
                    CompactWhitespace = form.CompactWhitespace;
                }
            }

        }





        public Payload RunPlugin(Payload Input)
        {



            Payload pData = new Payload();
            pData.FileID = Input.FileID;
            pData.SegmentID = Input.SegmentID;


            for (int i = 0; i < Input.StringList.Count; i++)
            {


                string inputText = Input.StringList[i];
                if (CompactWhitespace) inputText = Regex.Replace(inputText, @"\s+", " ");

                for (int j = 0; j < RegexArray.Length; j++)
                {

                    int NumMatches = RegexArray[j].Matches(inputText).Count;

                    if (NumMatches == 0) continue;

                    //NumberOfMatches[j] += (uint)NumMatches;
                    //TotalFilesMatched[j] += 1;

                    inputText = RegexArray[j].Replace(inputText, ReplacementArray[j]);

                }

                pData.StringList.Add(inputText);
                pData.SegmentNumber.Add(Input.SegmentNumber[i]);

            }

            return (pData);

        }



        public void Initialize() { }



        public bool InspectSettings()
        {
            if (fileLoaded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Payload FinishUp(Payload Input)
        {
            return (Input);
        }



        #region Import/Export Settings
        public void ImportSettings(Dictionary<string, string> SettingsDict)
        {
            RegexFile = SettingsDict["RegexFile"];
            SelectedEncoding = SettingsDict["SelectedEncoding"];
            fileLoaded = Boolean.Parse(SettingsDict["fileLoaded"]);
            RegexCaseSensitive = Boolean.Parse(SettingsDict["RegexCaseSensitive"]);
            CompactWhitespace = Boolean.Parse(SettingsDict["CompactWhitespace"]);
            int RegexArrayLength = int.Parse(SettingsDict["RegexArrayLength"]);
            int ReplacementArrayLength = int.Parse(SettingsDict["ReplacementArrayLength"]);

            RegexArray = new Regex[RegexArrayLength];
            ReplacementArray = new string[ReplacementArrayLength];

            for (int i = 0; i < ReplacementArrayLength; i++)
            {
                ReplacementArray[i] = SettingsDict["ReplacementArray" + i.ToString()];
            }

            for (int i = 0; i < RegexArrayLength; i++)
            {

                if (RegexCaseSensitive)
                {
                    RegexArray[i] = new Regex(SettingsDict["RegexArray" + i.ToString()], RegexOptions.Compiled);
                }
                else
                {
                    RegexArray[i] = new Regex(SettingsDict["RegexArray" + i.ToString()], RegexOptions.Compiled | RegexOptions.IgnoreCase);
                }

                
            }

        }

        public Dictionary<string, string> ExportSettings(bool suppressWarnings)
        {
            Dictionary<string, string> SettingsDict = new Dictionary<string, string>();
            SettingsDict.Add("RegexFile", RegexFile);
            SettingsDict.Add("SelectedEncoding", SelectedEncoding);
            SettingsDict.Add("fileLoaded", fileLoaded.ToString());
            SettingsDict.Add("RegexCaseSensitive", RegexCaseSensitive.ToString());
            SettingsDict.Add("CompactWhitespace", CompactWhitespace.ToString());

            int RegexArrayLength = 0;
            int ReplacementArrayLength = 0;

            if (RegexArray != null) RegexArrayLength = RegexArray.Length;
            if (ReplacementArray != null) ReplacementArrayLength = ReplacementArray.Length;
            
            SettingsDict.Add("RegexArrayLength", RegexArrayLength.ToString());
            SettingsDict.Add("ReplacementArrayLength", ReplacementArrayLength.ToString());

            for (int i = 0; i < RegexArrayLength; i++)
            {
                SettingsDict.Add("RegexArray" + i.ToString(), RegexArray[i].ToString());
            }

            for (int i = 0; i < ReplacementArrayLength; i++)
            {
                SettingsDict.Add("ReplacementArray" + i.ToString(), ReplacementArray[i]);
            }

            return (SettingsDict);
        }
        #endregion




    }
}
