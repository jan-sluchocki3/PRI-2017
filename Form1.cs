using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using TikaOnDotNet;
using TikaOnDotNet.TextExtraction;
using System.IO;
using System.Xml;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace PRI_KATALOGOWANIE_PLIKÓW
{
    public partial class Form1 : Form
    {
        public static string[] extends = { "txt", "csv", "doc", "docx", "odt", "ods", "odp", "xls", "xlsx", "pdf", "ppt", "pptx", "pps", "fb2", "htm", "html", "tsv", "xml", "jpg", "jpeg", "tiff", "bmp", "mp4", "avi", "mp3", "wav"};
        private string regex = @"((u|s|wy){0,1}(tw((órz)|(orzyć)|(orzenie))))(\s)(etykiet(y|ę){0,1})(\s)((<[a-ząęśćżźół\#]+\$>)+)(\s)((dla){0,1})(\s)((każde){0,1}((go)|j){0,1})(\s){0,1}((grupy){0,1})(\s){0,1}((((plik)|(obiekt))(u|ów))|(lokacji))(\s)(((\*{0,1})\.{0,1}[a-z0-9]{3,4}\s{0,1})+)";
        private string regexCreate = @"(create)(\s)(label)(\s)((<[a-ząęśćżźół\#]+\$>)+)(\s)((for){0,1})(\s)((every)|(all)|(each){0,1})(\s){0,1}((group of files)|(files' group){0,1})(\s)(((\*{0,1})\.{0,1}[a-z0-9]{3,4}\s{0,1})+)";
        private string[] exampleCommands = { "utwórz etykietę <x$> dla pliku *.mp3", "utwórz etykietę <x$> dla obiektu *.mp3", "utwórz etykietę <x$> dla lokacji *.mp3", "utwórz etykiety <x$><y$> dla grupy plików *.mp3 *wav", "utwórz etykiety <x$><y$> dla plików *.mp3 *wav", "utwórz etykiety <x$><y$> plików *.mp3 *wav", "utwórz etykiety <x$><y$> dla obiektów *.mp3 *wav", "utwórz etykiety <x$><y$> dla lokacji *.mp3 *wav" };
        private string[] exampleCommandsCreate = { "create label <x$> for every file *.mp3", "create label <x$> for each file *.mp3", "create label <x$> for all file *.mp3", "create label <x$> for file *.mp3", "create label <x$><y$> for files' group *.mp3 *wav", "create label <x$><y$> for group of file *.mp3 *wav", };
        int randResult = 0;
        int randResultCreate = 0;
        Dictionary<Tuple<string, string>, string> metadata;
        Dictionary<string, string> fileLabels;
        List<string> excludedMetadata;
        List<string> names;
        bool equals;
        const string path = @"C:\Users\lenovo\Documents\Visual Studio 2012\Projects\PRI-KATALOGOWANIE-PLIKÓW\PRI-KATALOGOWANIE-PLIKÓW\metadata.xml";
        const string pathTxt = @"C:\Users\lenovo\Documents\Visual Studio 2012\Projects\PRI-KATALOGOWANIE-PLIKÓW\PRI-KATALOGOWANIE-PLIKÓW\$$$.txt";
        public Form1()
        {
            InitializeComponent();

            this.txtCommand.LostFocus += TxtCommand_LostFocus;
            this.chkMetadata.LostFocus += ChkMetadata_LostFocus;
            this.tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
            names = new List<string>();
            excludedMetadata = new List<string>();
            metadata = new Dictionary<Tuple<string, string>, string>();
            fileLabels = new Dictionary<string, string>();
            equals = false;
        }
        /*
         * Obsługuje odpowiednie klawisze klawiatury
         * NumPad(i) = cyfra należąca do części numerycznej (po str NumLock)
         * D(i) = cyfra należąca do części alfanumerycznej
         * i = 0,...,9
         */
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control
                && (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1))
            {
                this.tabControl1.SelectedTab = this.tabPage1;
            }
            else if (Control.ModifierKeys == Keys.Control
                && (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2))
            {
                this.tabControl1.SelectedTab = this.tabPage2;
            }
            else if (Control.ModifierKeys == Keys.Control
                && e.KeyCode == Keys.U)
            {
                this.chkUseCreteRule.Checked = true;
            }
            else if (Control.ModifierKeys == Keys.Control
                && e.KeyCode == Keys.R)
            {
                this.chkUseEquality.Checked = true;
            }
            else if (Control.ModifierKeys == Keys.Control
                && e.KeyCode == Keys.K)
            {
                this.chkExcludeMetadata.Checked = true;
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 1)
            {
                /*
                 * ToDo: Wypełnić listę w zakładce "Praca":
                 * Plik = plik, nad którym pracujemy
                 * Etykieta = etykieta pliku (daje pierwszeńtswo katalogowania)
                 * Metadata = metadane pliku
                 * Ostatnia modyfikacja = kiedy plik był ostatnio modyfikowany
                 * Średnia, moda, kwawrtyle, ochylenie kwartylne, czas trwania = parametry statystyczne, albo czas trwania jako metryki porównywania spektogramów
                 * Stan = przydzielenie danego pliku. Każdy domyślnie ma stan NIEPRZYDZIELONY
                 */
            }

        }

        private void ChkMetadata_LostFocus(object sender, EventArgs e)
        {
            List<string> files = new List<string>();
            
            var diff = metadata.Where(x => !excludedMetadata.Contains(x.Key.Item1));

            foreach (var item in diff)
            {
                files.Add(item.Value);
            }

            var lookup = diff.ToLookup(x => x.Value);    
            files = files.Distinct().ToList();
            int i = 0;
            string[] s = new string[files.Count];
            foreach (var file in files)
            {
                i++;
                s[i-1] += file.Replace(" ", "_");
                foreach (var name in lookup[files[i-1]])
                    s[i-1] += "; " + name.Key.Item1;
            }
            string[] columnHeader = null;
            string flag = String.Empty;
            foreach (var _s in s)
            {
                columnHeader = _s.Split(' ');
                for (int j = 1; j <= columnHeader.Length - 1; j++)
                {
                    /*
                     * ToDo : Utworzyć nazwy kolumn tabeli bazy danych. Będą one odpowiednimi nazwami metadanych.
                     * Pierwsza kolumna będzie zaerzerwowana na pliki.
                     */
                }
            }

            Random rand = new Random();
            List<XmlNode> node = new List<XmlNode>();
            char randChar = (char)rand.Next(65, 90);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement _metadata = xDoc.CreateElement("metadata");

            string strMachineUserName = Environment.MachineName + "_" + Environment.UserName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff");

            string strMd5 = this.Encrypt(strMachineUserName, true);
            string strMd5MachineUserName = this.Encrypt("machineUserName", true);

            string key = randChar + strMd5MachineUserName.Substring(1).Replace("=", string.Empty).Replace("+", string.Empty).Replace("/", string.Empty);

            _metadata.SetAttribute(key, strMd5);
            System.IO.File.SetAttributes(pathTxt, FileAttributes.Normal);
            System.IO.File.AppendAllText(pathTxt, key + "$" + strMd5MachineUserName + Environment.NewLine);
            
            foreach (var _s in s)
            {
                columnHeader = _s.Split(' ');
                MessageBox.Show(columnHeader[0]);
                string content = randChar + columnHeader[0].Substring(columnHeader[0].LastIndexOf("\\") + 1).Trim(';');
                node.Add(xDoc.CreateElement(Regex.Replace(content, "^[0-9]", "X")));
            }

            foreach (var n in node)
                foreach (var _s in s)
                {
                    columnHeader = _s.Split(' ');
                    n.InnerText = this.Assign(columnHeader[0]);
                }
                    

            foreach (var n in node)
                _metadata.AppendChild(n);

            xDoc.DocumentElement.AppendChild(_metadata);
            xDoc.Save(path);

            System.IO.File.SetAttributes(pathTxt, FileAttributes.ReadOnly | FileAttributes.Hidden);
            ListViewItem row = new ListViewItem();
            string allMetadata = string.Empty;
            foreach (var m in metadata)
                allMetadata += m.Key + "=>" + m.Value + ";";
            foreach (var name in names.Distinct())
            {
                foreach (var item in fileLabels)
                    if (name.EndsWith(item.Value))
                    {
                        row.SubItems.Insert(0, new ListViewItem.ListViewSubItem(new ListViewItem(), name));
                        row.SubItems.Insert(1, new ListViewItem.ListViewSubItem(new ListViewItem(), item.Key));
                        row.SubItems.Insert(2, new ListViewItem.ListViewSubItem(new ListViewItem(), allMetadata));
                        //...
                        this.listView1.Items.Add(row);
                    }
            }
        }

        /// <summary>
        /// Przypisuje flagę do pliku
        /// </summary>
        /// <param name="to">Plik, do którego chcemy utworzyć przypisanie</param>
        /// <param name="flag">Flaga ustawiana podczas przypisania. Początkowo flaga jest ustawiona na NIEPRZYDZIELONY</param>
        private string Assign(string to)
        {
            string assign = "NIEPRZYDZIELONY$";
            return assign;
            /*
             * ToDo : Utworzyć przypisania dla poszczególnych typów plików
             */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            randResult = rand.Next(0, exampleCommands.Length - 1);
            randResultCreate = rand.Next(0, exampleCommandsCreate.Length - 1);
            this.lbExampleCommand.Text += exampleCommands[randResult];
        }

        private void TxtCommand_LostFocus(object sender, EventArgs e)
        {
            Match m = Regex.Match(exampleCommands[randResult], regex);
            Regex rxCreate = new Regex(regexCreate, RegexOptions.IgnoreCase);

            Match mCreate = Regex.Match(exampleCommandsCreate[randResultCreate], regexCreate);
            Regex rx = new Regex(regex, RegexOptions.IgnoreCase);

            Match mtxtCommand = Regex.Match(this.txtCommand.Text, regex);

            var groupRegexCreate = GroupRegex(rxCreate, mCreate);
            //if (this.chkUseCreteRule.Checked)
            //{
            //    if (Clipboard.ContainsText())
            //        this.txtCommand.Text = Clipboard.GetText();
                foreach (var item in this.GroupRegex(rx, mtxtCommand))
                    _group.Add(item);
                var groupRegex = GroupRegex(rx, m);
                var split = txtCommand.Text.Split(' ');
                
                if (this.txtCommand.Text.Length != 0)
                    foreach (var group in this.Groups(groupRegex, groupRegexCreate))
                        foreach (var s in split)
                            if (s == group.Key)
                                equals = true;
            string[] _split = null;
                var notSupported = String.Empty;
                try
                {
                    _split = _group[_group.Count - 2].Split(new char[] { ' ', '*', '.' });
                    MessageBox.Show(_group[_group.Count - 2]);
                    foreach (var s in _split)
                        if (s != " " && s != "")
                            if (!extends.Contains(s))
                                notSupported += " " + s;

                if (notSupported.Length > 0) MessageBox.Show("Nieobsługiwana grupa rozszerzeń: " + this.RemoveDuplicates(notSupported), "Grupa rozszerzeń", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    
                }
                catch (Exception) { }
            if (equals)
                foreach (var group in this.Groups(groupRegex, groupRegexCreate))
                    this.txtCommand.Text += " " + group.Value;

            if (this.txtCommand.Text.Length != 0)
                try
                {
                    this.txtCommand.Text += " " + _group[5] + " " + _group[_group.Count - 2];
                }
                catch (Exception) { }
            this.txtCommand.Text = RemoveDuplicates(txtCommand.Text);
            //foreach (var g in _group)
            //    MessageBox.Show(g);
         
            MessageBox.Show(_group[5]);
            Regex rxLabel = new Regex(@"(<[a-ząęśćżźół\#]+\$>)", RegexOptions.IgnoreCase);
            Match mLabel = Regex.Match(_group[5], @"(<[a-ząęśćżźół\#]+\$>)");

            int i = 0;
            MessageBox.Show(_group[4]);
            foreach (var group in this.GroupRegex(rxLabel, mLabel))
            {
                    try
                    {
                        if (group != " " && group != "")
                        {
                            fileLabels.Add(group.Trim('<').Trim('>').Replace("$", (i+1).ToString()), _split[2*i+1]);
                            i++;
                        }   
                    }
                    catch (Exception) { };
            }

            foreach (var item in fileLabels)
                MessageBox.Show(item.Key + " => " + item.Value);

            //}
            //else
            //{
            //    _group.Clear();
            //    Clipboard.SetText(this.txtCommand.Text);
            //}

        }

        /// <summary>
        /// Tłumaczy każde słowo tekstu podanego na wejściu
        /// </summary>
        /// <param name="normal">lista słów języka wejściowego tekstu</param>
        /// <param name="create">lista słów "języka 'create'"</param>
        /// <returns>Słownik słowo-tłumaczenie</returns>
        private Dictionary<string, string> Groups(List<string> normal, List<string> create)
        {
            Dictionary<string, string> groups = new Dictionary<string, string>();
            string[] filesGroup = { "files' group", "group of files" };
            string[] forEach = { "each", "all", "every" };
            Random rand = new Random();
            int index = rand.Next(1, 2);
            int i = rand.Next(0,forEach.Length - 1);
            try
            {
                groups.Add(normal[0], create[0]);
                groups.Add(normal[index], create[1]);
                groups.Add("każdego", forEach[i]);
                groups.Add("każdej", forEach[i]);
                groups.Add("dla", "for");
                groups.Add("grupy plików", filesGroup[index]);
            }
            catch { }

            return groups;
        }

        /// <summary>
        /// Grupuje tekst podany na wejściu względem wyrażenia regularnego
        /// </summary>
        /// <param name="rx">Wyrażenie regularne, do którego tekst wejściowy będzie dopasowywany</param>
        /// <param name="match">Dopasowanie zawierające tekst podany na wejściu</param>
        /// <returns>Dopasowane grupy tekstu podanego na wejściu</returns>
        private List<string> GroupRegex(Regex rx, Match match)
        {
            List<string> groups = new List<string>();
         
            while (match.Success)
            {
                for (int i = 1; i <= 50; i++)
                {
                    Group g = match.Groups[i];
                    string gToString = g.ToString();
                    if (!gToString.Equals("") && !gToString.Equals(" ") && gToString.Length != 1 && !gToString.Equals("o"))
                        groups.Add(gToString);

                }
                match = match.NextMatch();
            }
            return groups;
        }

        private void txtCommand_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCommand.Text.Contains("<")) 
                this.toolTip1.SetToolTip(txtCommand, "nazwa_etykiety$");
            if (this.txtCommand.Text.Contains(">"))
                this.toolTip1.RemoveAll();
            if (this.txtCommand.Text.Contains(".") || this.txtCommand.Text.Contains("*"))
            {
                string text = String.Empty;
                for (int i = 0; i < extends.Length; i++)
                {
                    text += extends[i] + "\n";
                }
                this.toolTip1.SetToolTip(txtCommand, text);
            }
        }
        List<string> _group = new List<string>();
        private void chkUseCreteRule_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkUseCreteRule.Checked)
            {
                this.lbExampleCommand.Text = "";
                this.lbExampleCommand.Text += "E.g. " +exampleCommandsCreate[randResultCreate];
            }
            else
            {
                this.lbExampleCommand.Text = "";
                this.lbExampleCommand.Text += "Np.: " + exampleCommands[randResult];
            }

            this.chkUseEquality.Enabled = true;

            Regex rx = new Regex(regex, RegexOptions.IgnoreCase);
            Match m = Regex.Match(exampleCommands[randResult], regex);

            Regex rxCreate = new Regex(regexCreate, RegexOptions.IgnoreCase);
            Match mCreate = Regex.Match(exampleCommandsCreate[randResultCreate], regexCreate);
            var groupRegex = GroupRegex(rx, m);
            var groupRegexCreate = GroupRegex(rxCreate, mCreate);
            var split = txtCommand.Text.Split(' ');
            equals = false;

            if (this.txtCommand.Text.Length != 0)
                foreach (var group in this.Groups(groupRegex, groupRegexCreate))
                    foreach (var s in split)
                        if (s == group.Key)
                            equals = true;

            Match mtxtCommand = Regex.Match(this.txtCommand.Text, regex);

            foreach (var item in this.GroupRegex(rx, mtxtCommand))
                _group.Add(item);

            if (this.chkUseCreteRule.Checked)
            {
                this.txtCommand.Text = String.Empty;
                if (equals)
                    foreach (var group in this.Groups(groupRegex, groupRegexCreate))
                        this.txtCommand.Text += " " + group.Value;

                if (this.txtCommand.Text.Length != 0)
                    try
                    {
                        this.txtCommand.Text += " " + _group[5] + " " + _group[_group.Count - 2];
                    }
                    catch (Exception) { }
                this.txtCommand.Text = RemoveDuplicates(txtCommand.Text);
                foreach (var g in _group)
                    MessageBox.Show(g);
            }
        }

        private string RemoveDuplicates(string p)
        {
            var distinct = string.Join(" ",

                Regex.Matches(p, @"([^\s]+)")
                         .OfType<Match>()
                     .Select(m => m.Groups[0].Value)
                     .Distinct()

            );

            return distinct;

        }

        private void chkUseEquality_CheckedChanged(object sender, EventArgs e)
        {
            Regex rx = new Regex(@"((each)|(all)|(every))(\s)(for)(\s)(((group of files)|(files' group)){0,1})");
            this.txtCommand.Text = rx.Replace(this.txtCommand.Text, "=");
        }

        private void chkExcludeMetadata_CheckedChanged(object sender, EventArgs e)
        {
            int j = 0;
            if (this.chkExcludeMetadata.Checked)
            {
                foreach (var item in this.chkMetadata.Items)
                {
                    this.chkMetadata.SetItemChecked(j, false);
                    j++;
                }
                this.chkMetadata.Enabled = true;
                string nameSafe = String.Empty;
                //Dictionary<string, string> names = new Dictionary<string, string>();
                string filter = String.Empty;
                using (FolderBrowserDialog open = new FolderBrowserDialog())
                {
                    if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        var files = Directory.GetFiles(open.SelectedPath, "*", SearchOption.AllDirectories);
                        foreach (var file in files)
                            names.Add(file);
                       
                        if (names.Count == 0) MessageBox.Show("Katalog " + open.SelectedPath + " jest pusty", "Grupa rozszerzeń", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                /*
                 * Tworzyt listę metadanych wyszystkich plików znajdujących się w wybranym katalogu
                 */
                var extractors = new List<TikaOnDotNet.TextExtraction.TextExtractor>();
                foreach (var name in names)
                    extractors.Add(new TikaOnDotNet.TextExtraction.TextExtractor());
                foreach (var ext in extractors)

                    foreach (var name in names)
                    {
                        try
                        {
                            var ex = ext.Extract(name);
                            foreach (var _e in ex.Metadata)
                            {
                                this.chkMetadata.Items.Add(_e.Key + "=" + _e.Value + " [w] " + name);
                                metadata.Add(new Tuple<string, string>(_e.Key, _e.Value), name);
                            }
                        }
                        catch (Exception) { }
                    }
            }
            else
            {
                this.chkMetadata.Enabled = false;
                this.metadata.Clear();
                this.chkMetadata.Items.Clear();
            }
        }

        private void PostXML(string v, string requestData)
        {
            /*
             * ToDo : umieścic plik XML na serwerze www
             */
        }

        private string Encrypt(string v, bool isHashUsed)
        {
            byte[] keyArray;
            byte[] encrypted = UTF8Encoding.UTF8.GetBytes(v);

            System.Configuration.AppSettingsReader appSettings = new System.Configuration.AppSettingsReader();

            string key = appSettings.GetValue("SecurityKey", typeof(String)) as string;

            if (isHashUsed)
            {
                MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
                keyArray = md5provider.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                md5provider.Clear();
            }
            else keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.CFB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cryptoTransform = tdes.CreateEncryptor();
            byte[] resultArray = cryptoTransform.TransformFinalBlock(encrypted, 0, encrypted.Length);

            tdes.Clear();
            
            return Convert.ToBase64String(resultArray, 0, resultArray.Length); 
        }

        private void chkMetadata_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
                this.toolTip1.SetToolTip(this.chkMetadata, this.chkMetadata.SelectedItem.ToString());
        }

        private void bnCatalogue_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip1.Visible = true;
        }

        private void chkMetadata_DoubleClick(object sender, EventArgs e)
        {
            this.excludedMetadata.Remove(this.chkMetadata.SelectedItem.ToString());
        }

        private void chkMetadata_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.excludedMetadata.Add(this.chkMetadata.SelectedItem.ToString().Substring(0, this.chkMetadata.SelectedItem.ToString().IndexOf("=")));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var extractor = new TikaOnDotNet.TextExtraction.TextExtractor().Extract(path);
            string xmlNoSpaces = Regex.Replace(extractor.Text, @"\s+", string.Empty);

            Regex rx = new Regex("(<.*?>)", RegexOptions.IgnoreCase);
            Match mTxt = Regex.Match(extractor.Text, "(<.*?>)");
            try
            {
                System.IO.File.SetAttributes(pathTxt, FileAttributes.Normal);
            }
            catch (Exception) { }
            StreamReader reader = new StreamReader(pathTxt);
            
            string line = String.Empty;
            
            string subgroup = String.Empty;
            string _subgroup = String.Empty;
            var regex = @"([A-Za-z]+)(_[A-Za-z]+)(_[0-9]+)$";

            foreach (var group in this.GroupRegex(rx, mTxt))
                if (group.Length > 22)
                {
                    subgroup = group.Substring(group.IndexOf("=")+2);
                    _subgroup = this.Decrypt(Regex.Replace(subgroup, @">$", string.Empty).TrimEnd('"'), true).Substring(8);
                    break;
                }

            Regex rxMachineUser = new Regex(regex, RegexOptions.IgnoreCase);
            Match m = Regex.Match(_subgroup, regex);
            string r = this.GroupRegex(rxMachineUser, m)[0] + this.GroupRegex(rxMachineUser, m)[1] + this.GroupRegex(rxMachineUser, m)[2];
            
            var stream = System.IO.File.OpenRead(pathTxt);
            reader = new StreamReader(stream);
            
            line = Regex.Replace(reader.ReadLine(), @"\$(.+)", String.Empty);
            
            string x = this.Decrypt(Regex.Replace(subgroup, @">$", string.Empty).TrimEnd('"'), true).Substring(8);
            //MessageBox.Show(this.GetRealMachine(x));
            int lenMachine = this.GetRealMachine(x).Length;
            int lenUser = this.GetRealUser(x).Length;

            XDocument xDoc = XDocument.Load(path);

            var query = xDoc.Descendants("Metadata")
                            .Where(parent => parent.Elements("metadata")
                            .Any(child =>
                                ((bool)this.Decrypt(child.Attribute(line).Value, true).Contains(this.GetRealMachine(x))
                                && (bool)this.Decrypt(child.Attribute(line).Value, true).Contains(this.GetRealUser(x)))));
            bool realMachineUser = false;
            string[] assignmentKeyWords = null;
            foreach (var q in query)
            {
                assignmentKeyWords = q.Value.Split('$');
                foreach (var group in this.GroupRegex(rx, mTxt))
                    if (group.Length > 22)
                    {
                        subgroup = group.Substring(group.IndexOf("=") + 2);
                        _subgroup = this.Decrypt(Regex.Replace(subgroup, @">$", string.Empty).TrimEnd('"'), true).Substring(8);
                        break;
                    }
            }
            realMachineUser = Environment.MachineName.Contains(this.GroupRegex(rxMachineUser, m)[0]) && Environment.UserName.Equals(this.GroupRegex(rxMachineUser, m)[1].Replace("_", String.Empty));
            List<string> metadataKey = new List<string>();
            if (realMachineUser)
                foreach (var group in this.GroupRegex(rx, mTxt))
                    if (group.Length <= 32 && !group.Contains("/") && !group.Equals("<Metadata>"))
                        metadataKey.Add(Regex.Replace(group, "<|>", String.Empty));

            var metadataKeyDist = metadataKey.Distinct();
            Dictionary<string, string> assignments = new Dictionary<string, string>();
            
            foreach (var key in metadataKeyDist)
                foreach (var assignment in assignmentKeyWords)
                    if (assignment != String.Empty && !assignments.ContainsKey(key))
                        assignments.Add(key, assignment);
        }

        private string GetRealMachine(string input)
        {
            string machine = String.Empty;
            var extractor = new TikaOnDotNet.TextExtraction.TextExtractor().Extract(path);
            Regex rx = new Regex("(<.*?>)", RegexOptions.IgnoreCase);
            Match mTxt = Regex.Match(extractor.Text, "(<.*?>)");
            string subgroup = String.Empty;
            string _subgroup = String.Empty;
            string regex = @"([A-Za-z]+)(_[A-Za-z]+)(_[0-9]+)$";
            foreach (var group in this.GroupRegex(rx, mTxt))
                if (group.Length > 22)
                {
                    subgroup = group.Substring(group.IndexOf("=") + 2);
                    _subgroup = this.Decrypt(Regex.Replace(subgroup, @">$", string.Empty).TrimEnd('"'), true).Substring(8);
                    break;
                }

            Regex rxMachineUser = new Regex(regex, RegexOptions.IgnoreCase);
            Match m = Regex.Match(_subgroup, regex);
            machine = this.GroupRegex(rxMachineUser, m)[0];

            return machine;
        }

        private string GetRealUser(string input)
        {
            string user = String.Empty;
            var extractor = new TikaOnDotNet.TextExtraction.TextExtractor().Extract(path);
            Regex rx = new Regex("(<.*?>)", RegexOptions.IgnoreCase);
            Match mTxt = Regex.Match(extractor.Text, "(<.*?>)");
            string subgroup = String.Empty;
            string _subgroup = String.Empty;
            string regex = @"([A-Za-z]+)(_[A-Za-z]+)(_[0-9]+)$";
            foreach (var group in this.GroupRegex(rx, mTxt))
                if (group.Length > 22)
                {
                    subgroup = group.Substring(group.IndexOf("=") + 2);
                    _subgroup = this.Decrypt(Regex.Replace(subgroup, @">$", string.Empty).TrimEnd('"'), true).Substring(8);
                    break;
                }
            Regex rxMachineUser = new Regex(regex, RegexOptions.IgnoreCase);
            Match m = Regex.Match(_subgroup, regex);
            user = this.GroupRegex(rxMachineUser, m)[1].Replace("_", String.Empty);
            return user;
        }

        private string Decrypt(string v1, bool v2)
        {
            byte[] keyArray;
            byte[] encrypted = Convert.FromBase64String(v1);

            System.Configuration.AppSettingsReader appSettings = new System.Configuration.AppSettingsReader();

            string key = appSettings.GetValue("SecurityKey", typeof(String)) as string;

            if (v2)
            {
                MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
                keyArray = md5provider.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                md5provider.Clear();
            }
            else keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.CFB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cryptoTransform = tdes.CreateDecryptor();
            byte[] resultArray = cryptoTransform.TransformFinalBlock(encrypted, 0, encrypted.Length);

            tdes.Clear();

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
