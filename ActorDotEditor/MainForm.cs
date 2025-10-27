using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ActorDotEditor
{
    public partial class MainForm : Form
    {
        private string currentJsonPath;
        private string currentEffectsPath;
        private readonly Dictionary<string, Dictionary<string, string>> L10n;
        private string currentLang = "en";

        public MainForm()
        {
            InitializeComponent();
            

            // Initialize localization dictionary
            L10n = new Dictionary<string, Dictionary<string, string>>
            {
                ["en"] = new Dictionary<string, string>
                {
                    ["MainForm_Title"] = "Actor Dot Editor",
                    ["labelId"] = "Actor Dot ID",
                    ["label1"] = "切换语言/Language",
                    ["labelHero"] = "Hero/Monster Name",
                    ["labelUpdateType"] = "Update Type",
                    ["button_OpenJson"] = "Open JSON",
                    ["button_NewJson"] = "New JSON",
                    ["button_SaveJson"] = "Only Save JSON",
                    ["button_LoadEffects"] = "Load effect File",
                    ["button_AddToCompletion"] = "Add to Completion",
                    ["button_AddToIncrement"] = "Add to Increment",
                    ["button_AddTemplate"] = "Add once AD",
                    ["button_GenerateFiles"] = "Generate JSON Files and Animation",
                    ["msg_JsonSaved"] = "JSON saved.",
                    ["err_CompletionChanceLastOnly"] = "Only the last element may have completion_chance = 1.0.",
                    ["msg_GenerationComplete"] = "Generation complete. Check ADskeloutput folder.",
                    ["column_CompletionChance"] = "Completion Chance",
                    ["column_CompletionEffects"] = "Completion Effects (comma-separated)",
                    ["column_IncrementEffects"] = "Increment Effects (comma-separated)",
                    ["button_Developer"] = "Developer/开发者信息",
                    ["dev_Title"] = "Developer",
                    ["dev_VersionLabel"] = "Version",
                    ["dev_Author"] = "Author",
                    ["dev_ActorDotEditor"] = "ActorDotEditor"
                },
                ["zh"] = new Dictionary<string, string>
                {
                    ["MainForm_Title"] = "Actor Dot 编辑器",
                    ["labelId"] = "Actor Dot ID",
                    ["label1"] = "切换语言/Language",
                    ["labelHero"] = "英雄/怪物名",
                    ["labelUpdateType"] = "更新类型",
                    ["button_OpenJson"] = "打开 JSON",
                    ["button_NewJson"] = "新建 JSON",
                    ["button_SaveJson"] = "只保存 JSON",
                    ["button_LoadEffects"] = "加载 effect 文件",
                    ["button_AddToCompletion"] = "添加到完成",
                    ["button_AddToIncrement"] = "添加到未完成",
                    ["button_AddTemplate"] = "AD次数添加一次",
                    ["button_GenerateFiles"] = "生成JSON文件和动画",
                    ["msg_JsonSaved"] = "JSON 已保存。",
                    ["err_CompletionChanceLastOnly"] = "只有最后一个元素可设置完成概率为 1.0。",
                    ["msg_GenerationComplete"] = "文件生成完毕，见 ADskeloutput 文件夹。",
                    ["column_CompletionChance"] = "完成概率",
                    ["column_CompletionEffects"] = "完成效果 (逗号分隔)",
                    ["column_IncrementEffects"] = "未完成效果 (逗号分隔)",
                    ["button_Developer"] = "Developer/开发者信息",
                    ["dev_Title"] = "开发者信息",
                    ["dev_VersionLabel"] = "版本",
                    ["dev_Author"] = "作者",
                    ["dev_ActorDotEditor"] = "AD编辑器"
                }
            };

            // Setup language selector
            languageComboBox.Items.AddRange(new object[] { "en", "zh" });
            languageComboBox.SelectedItem = currentLang;
            languageComboBox.SelectedIndexChanged += LanguageComboBox_SelectedIndexChanged;
            ApplyLocalization();

            // Populate update type options
            updateTypeComboBox.Items.AddRange(new[] { "after_turn_attack", "after_turn_attack_kill", "after_turn_friendly" });

            // Add Developer Page button at runtime
            var dict = L10n[currentLang];
            var devBtn = new Button
            {
                Text = dict["button_Developer"],
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(this.ClientSize.Width - 400, 10)
            };
            devBtn.Click += (s, e) =>
            {
                var dictDev = L10n[currentLang];
                using var devForm = new DeveloperForm(dictDev, Application.ProductVersion, this.Icon);
                devForm.ShowDialog();
            };
            this.Controls.Add(devBtn);
            devBtn.BringToFront();
            // Enable auto-resize for rows and wrap text in effect columns
            durationElementsGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            completionEffectsColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            incrementEffectsColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // Keep columns flexible
            completionEffectsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            incrementEffectsColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentLang = languageComboBox.SelectedItem.ToString();
            ApplyLocalization();
        }

        private void ApplyLocalization()
        {
            var dict = L10n[currentLang];
            Text = dict["MainForm_Title"];
            labelId.Text = dict["labelId"];
            labelHero.Text = dict["labelHero"];
            labelUpdateType.Text = dict["labelUpdateType"];
            openJsonButton.Text = dict["button_OpenJson"];
            newJsonButton.Text = dict["button_NewJson"];
            saveJsonButton.Text = dict["button_SaveJson"];
            loadEffectsButton.Text = dict["button_LoadEffects"];
            addToCompletionButton.Text = dict["button_AddToCompletion"];
            addToIncrementButton.Text = dict["button_AddToIncrement"];
            addTemplateButton.Text = dict["button_AddTemplate"];
            generateButton.Text = dict["button_GenerateFiles"];
            completionChanceColumn.HeaderText = dict["column_CompletionChance"];
            completionEffectsColumn.HeaderText = dict["column_CompletionEffects"];
            incrementEffectsColumn.HeaderText = dict["column_IncrementEffects"];
            label1.Text = dict["label1"];
        }

        private void openJsonButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "JSON Files (*.json)|*.json" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentJsonPath = ofd.FileName;
                    var data = JsonConvert.DeserializeObject<ActorDotFile>(File.ReadAllText(currentJsonPath));
                    PopulateUI(data);
                }
            }
        }

        private void PopulateUI(ActorDotFile data)
        {
            if (data.entries == null || data.entries.Count == 0) return;
            var entry = data.entries[0];
            idTextBox.Text = entry.id;
            //heroTextBox.Text = entry.id;
            updateTypeComboBox.SelectedItem = entry.update_duration_type;
            durationElementsGrid.Rows.Clear();
            foreach (var elem in entry.duration_elements)
            {
                durationElementsGrid.Rows.Add(elem.completion_chance, string.Join(",", elem.completion_effects), string.Join(",", elem.increment_effects));
            }
        }

        private void saveJsonButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentJsonPath)) return;
            var entries = CollectEntriesFromUI();
            if (!ValidateElements(entries[0].duration_elements)) return;
            File.WriteAllText(currentJsonPath, JsonConvert.SerializeObject(new ActorDotFile { entries = entries }, Formatting.Indented));
            MessageBox.Show(L10n[currentLang]["msg_JsonSaved"]);
        }

        private void newJsonButton_Click(object sender, EventArgs e)
        {
            currentJsonPath = null;
            idTextBox.Clear();
            heroTextBox.Clear();
            updateTypeComboBox.SelectedIndex = -1;
            durationElementsGrid.Rows.Clear();
        }

        private List<Entry> CollectEntriesFromUI()
        {
            var elems = new List<DurationElement>();
            foreach (DataGridViewRow row in durationElementsGrid.Rows)
            {
                if (row.IsNewRow) continue;
                double.TryParse(row.Cells[0].Value?.ToString(), out double chance);
                var comp = row.Cells[1].Value?.ToString().Split(',').ToList() ?? new List<string>();
                var inc = row.Cells[2].Value?.ToString().Split(',').ToList() ?? new List<string>();
                elems.Add(new DurationElement { completion_chance = chance, completion_effects = comp, increment_effects = inc });
            }
            return new List<Entry> { new Entry { id = idTextBox.Text, update_duration_type = updateTypeComboBox.SelectedItem?.ToString(), duration_elements = elems } };
        }

        private bool ValidateElements(List<DurationElement> elements)
        {
            for (int i = 0; i < elements.Count - 1; i++)
            {
                if (Math.Abs(elements[i].completion_chance - 1.0) < 1e-6)
                {
                    MessageBox.Show(L10n[currentLang]["err_CompletionChanceLastOnly"]);
                    return false;
                }
            }
            return true;
        }

        private void loadEffectsButton_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog { Filter = "Darkest Effects (*.darkest)|*.darkest" };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            currentEffectsPath = ofd.FileName;

            // Read and parse effect names
            var lines = File.ReadAllLines(currentEffectsPath);
            var names = lines
                .Where(l => l.TrimStart().StartsWith("effect:", StringComparison.OrdinalIgnoreCase) && l.Contains(".name"))
                .Select(l =>
                {
                    int idx = l.IndexOf(".name", StringComparison.Ordinal);
                    int start = l.IndexOf('"', idx);
                    int end = l.IndexOf('"', start + 1);
                    return (start >= 0 && end > start) ? l.Substring(start + 1, end - start - 1) : null;
                })
                .Where(n => !string.IsNullOrEmpty(n))
                .Distinct()
                .ToArray();

            // Populate list box
            effectsListBox.Items.Clear();
            effectsListBox.Items.AddRange(names);
            effectsListBox.HorizontalScrollbar = true;

            // Adjust horizontal extent based on longest item
            using var g = effectsListBox.CreateGraphics();
            int maxWidth = 0;
            foreach (var item in effectsListBox.Items)
            {
                int w = (int)g.MeasureString(item.ToString(), effectsListBox.Font).Width;
                if (w > maxWidth) maxWidth = w;
            }
            effectsListBox.HorizontalExtent = maxWidth;

            // Optional: adjust height to fit all items
            effectsListBox.Height = effectsListBox.ItemHeight * Math.Min(effectsListBox.Items.Count, 10) + 4;
        }

        private void addToCompletionButton_Click(object sender, EventArgs e)
        {
            if (effectsListBox.SelectedItem == null || durationElementsGrid.CurrentRow == null) return;
            var row = durationElementsGrid.CurrentRow;
            var cellVal = row.Cells[1].Value as string;
            var list = string.IsNullOrWhiteSpace(cellVal) ? new List<string>() : cellVal.Split(',').ToList();
            list.Add(effectsListBox.SelectedItem.ToString());
            row.Cells[1].Value = string.Join(",", list);
            durationElementsGrid.AutoResizeColumn(1);
            durationElementsGrid.AutoResizeRow(row.Index, DataGridViewAutoSizeRowMode.AllCells);
        }

        private void addToIncrementButton_Click(object sender, EventArgs e)
        {
            if (effectsListBox.SelectedItem == null || durationElementsGrid.CurrentRow == null) return;
            var row = durationElementsGrid.CurrentRow;
            var cellVal = row.Cells[2].Value as string;
            var list = string.IsNullOrWhiteSpace(cellVal) ? new List<string>() : cellVal.Split(',').ToList();
            list.Add(effectsListBox.SelectedItem.ToString());
            row.Cells[2].Value = string.Join(",", list);
            durationElementsGrid.AutoResizeColumn(2);
            durationElementsGrid.AutoResizeRow(row.Index, DataGridViewAutoSizeRowMode.AllCells);
        }

        private void addTemplateButton_Click(object sender, EventArgs e)
        {
            var template = new object[] { 0.0, string.Empty, string.Empty };
            int insertIdx;
            var cell = durationElementsGrid.CurrentCell;
            if (cell == null || cell.RowIndex == durationElementsGrid.NewRowIndex)
            {
                insertIdx = durationElementsGrid.Rows.Count - 1;
                durationElementsGrid.Rows.Insert(insertIdx, template);
            }
            else
            {
                insertIdx = cell.RowIndex + 1;
                durationElementsGrid.Rows.Insert(insertIdx, template);
            }
            durationElementsGrid.CurrentCell = durationElementsGrid.Rows[insertIdx].Cells[0];
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            var entries = CollectEntriesFromUI();
            if (!ValidateElements(entries[0].duration_elements)) return;
            var json = JsonConvert.SerializeObject(new ActorDotFile { entries = entries }, Formatting.Indented);

            // Prepare directories
            var baseOut = Path.Combine(Application.StartupPath, "ADskeloutput");
            var jsonOut = Path.Combine(baseOut, "ADjson");
            Directory.CreateDirectory(jsonOut);
            Directory.CreateDirectory(baseOut);

            // Write JSON into ADjson folder
            var jsonName = Path.Combine(jsonOut, $"{idTextBox.Text}.actor_dot.json");
            File.WriteAllText(jsonName, json);

            // Copy skel/atlas/png from sampleADskel as heroname.sprite.id
            var sampleBase = "heroname.sprite.id";
            var hero = heroTextBox.Text.Trim();
            var id = idTextBox.Text.Trim();
            var newBase = $"{hero}.sprite.{id}";
            var sampleDir = Path.Combine(Application.StartupPath, "sampleADskel");
            foreach (var ext in new[] { ".atlas", ".png", ".skel" })
            {
                var src = Path.Combine(sampleDir, sampleBase + ext);
                var dst = Path.Combine(baseOut, newBase + ext);
                File.Copy(src, dst, true);
                if (ext == ".atlas")
                {
                    var content = File.ReadAllText(dst);
                    content = content.Replace("heroname.sprite.id.png", $"{newBase}.png");
                    File.WriteAllText(dst, content);
                }
            }

            MessageBox.Show(L10n[currentLang]["msg_GenerationComplete"]);
        }

        private void languageComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
    // Developer Page Form
    public class DeveloperForm : Form
    {
        public DeveloperForm(Dictionary<string, string> dict, string version, Icon appIcon)
        {
            Text = dict["dev_Title"];
            Icon = appIcon;
            Size = new Size(400, 200);
            var txt = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                BackColor = this.BackColor,
                Font = new Font("Segoe UI", 10),
                Text = $"{dict["dev_ActorDotEditor"]}{Environment.NewLine}" +
                       $"{dict["dev_Author"]}: InuiDame{Environment.NewLine}" +
                       $"{dict["dev_VersionLabel"]}: {version}{Environment.NewLine}" +
                       $"My Steam: https://steamcommunity.com/id/InuiDame/"
            };
            Controls.Add(txt);
        }
    }

    // Data models
    public class ActorDotFile { public List<Entry> entries { get; set; } }
    public class Entry { public string id { get; set; } public string update_duration_type { get; set; } public List<DurationElement> duration_elements { get; set; } }
    public class DurationElement { public double completion_chance { get; set; } public List<string> completion_effects { get; set; } public List<string> increment_effects { get; set; } }
}
