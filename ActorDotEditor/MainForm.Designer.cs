namespace ActorDotEditor
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // 控件声明
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox heroTextBox;
        private System.Windows.Forms.ComboBox updateTypeComboBox;
        private System.Windows.Forms.DataGridView durationElementsGrid;
        private System.Windows.Forms.ListBox effectsListBox;
        private System.Windows.Forms.Button openJsonButton;
        private System.Windows.Forms.Button newJsonButton;
        private System.Windows.Forms.Button saveJsonButton;
        private System.Windows.Forms.Button loadEffectsButton;
        private System.Windows.Forms.Button addToCompletionButton;
        private System.Windows.Forms.Button addToIncrementButton;
        private System.Windows.Forms.Button addTemplateButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelHero;
        private System.Windows.Forms.Label labelUpdateType;
        // 新增：列声明
        private System.Windows.Forms.DataGridViewTextBoxColumn completionChanceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn completionEffectsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn incrementEffectsColumn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.heroTextBox = new System.Windows.Forms.TextBox();
            this.updateTypeComboBox = new System.Windows.Forms.ComboBox();
            this.durationElementsGrid = new System.Windows.Forms.DataGridView();
            this.completionChanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.completionEffectsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incrementEffectsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.effectsListBox = new System.Windows.Forms.ListBox();
            this.openJsonButton = new System.Windows.Forms.Button();
            this.newJsonButton = new System.Windows.Forms.Button();
            this.saveJsonButton = new System.Windows.Forms.Button();
            this.loadEffectsButton = new System.Windows.Forms.Button();
            this.addToCompletionButton = new System.Windows.Forms.Button();
            this.addToIncrementButton = new System.Windows.Forms.Button();
            this.addTemplateButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.labelId = new System.Windows.Forms.Label();
            this.labelHero = new System.Windows.Forms.Label();
            this.labelUpdateType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.durationElementsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(100, 11);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(200, 21);
            this.idTextBox.TabIndex = 1;
            // 
            // heroTextBox
            // 
            this.heroTextBox.Location = new System.Drawing.Point(100, 39);
            this.heroTextBox.Name = "heroTextBox";
            this.heroTextBox.Size = new System.Drawing.Size(200, 21);
            this.heroTextBox.TabIndex = 3;
            // 
            // updateTypeComboBox
            // 
            this.updateTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.updateTypeComboBox.Location = new System.Drawing.Point(100, 66);
            this.updateTypeComboBox.Name = "updateTypeComboBox";
            this.updateTypeComboBox.Size = new System.Drawing.Size(200, 20);
            this.updateTypeComboBox.TabIndex = 5;
            // 
            // durationElementsGrid
            // 
            this.durationElementsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.durationElementsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.completionChanceColumn,
            this.completionEffectsColumn,
            this.incrementEffectsColumn});
            this.durationElementsGrid.GridColor = System.Drawing.SystemColors.Control;
            this.durationElementsGrid.Location = new System.Drawing.Point(15, 102);
            this.durationElementsGrid.Name = "durationElementsGrid";
            this.durationElementsGrid.Size = new System.Drawing.Size(600, 166);
            this.durationElementsGrid.TabIndex = 6;
            // 
            // completionChanceColumn
            // 
            this.completionChanceColumn.DataPropertyName = "completion_chance";
            this.completionChanceColumn.HeaderText = "Completion Chance";
            this.completionChanceColumn.Name = "completionChanceColumn";
            // 
            // completionEffectsColumn
            // 
            this.completionEffectsColumn.DataPropertyName = "completion_effects";
            this.completionEffectsColumn.HeaderText = "Completion Effects";
            this.completionEffectsColumn.Name = "completionEffectsColumn";
            // 
            // incrementEffectsColumn
            // 
            this.incrementEffectsColumn.DataPropertyName = "increment_effects";
            this.incrementEffectsColumn.HeaderText = "Increment Effects";
            this.incrementEffectsColumn.Name = "incrementEffectsColumn";
            // 
            // effectsListBox
            // 
            this.effectsListBox.FormattingEnabled = true;
            this.effectsListBox.ItemHeight = 12;
            this.effectsListBox.Location = new System.Drawing.Point(630, 11);
            this.effectsListBox.Name = "effectsListBox";
            this.effectsListBox.Size = new System.Drawing.Size(200, 184);
            this.effectsListBox.TabIndex = 7;
            // 
            // openJsonButton
            // 
            this.openJsonButton.Location = new System.Drawing.Point(15, 277);
            this.openJsonButton.Name = "openJsonButton";
            this.openJsonButton.Size = new System.Drawing.Size(75, 42);
            this.openJsonButton.TabIndex = 10;
            this.openJsonButton.Text = "Open JSON";
            this.openJsonButton.UseVisualStyleBackColor = true;
            this.openJsonButton.Click += new System.EventHandler(this.openJsonButton_Click);
            // 
            // newJsonButton
            // 
            this.newJsonButton.Location = new System.Drawing.Point(100, 277);
            this.newJsonButton.Name = "newJsonButton";
            this.newJsonButton.Size = new System.Drawing.Size(75, 42);
            this.newJsonButton.TabIndex = 11;
            this.newJsonButton.Text = "New JSON";
            this.newJsonButton.UseVisualStyleBackColor = true;
            this.newJsonButton.Click += new System.EventHandler(this.newJsonButton_Click);
            // 
            // saveJsonButton
            // 
            this.saveJsonButton.Location = new System.Drawing.Point(185, 277);
            this.saveJsonButton.Name = "saveJsonButton";
            this.saveJsonButton.Size = new System.Drawing.Size(75, 42);
            this.saveJsonButton.TabIndex = 12;
            this.saveJsonButton.Text = "Save JSON";
            this.saveJsonButton.UseVisualStyleBackColor = true;
            this.saveJsonButton.Click += new System.EventHandler(this.saveJsonButton_Click);
            // 
            // loadEffectsButton
            // 
            this.loadEffectsButton.Location = new System.Drawing.Point(270, 277);
            this.loadEffectsButton.Name = "loadEffectsButton";
            this.loadEffectsButton.Size = new System.Drawing.Size(110, 42);
            this.loadEffectsButton.TabIndex = 13;
            this.loadEffectsButton.Text = "Load .darkest File";
            this.loadEffectsButton.UseVisualStyleBackColor = true;
            this.loadEffectsButton.Click += new System.EventHandler(this.loadEffectsButton_Click);
            // 
            // addToCompletionButton
            // 
            this.addToCompletionButton.Location = new System.Drawing.Point(630, 203);
            this.addToCompletionButton.Name = "addToCompletionButton";
            this.addToCompletionButton.Size = new System.Drawing.Size(200, 21);
            this.addToCompletionButton.TabIndex = 8;
            this.addToCompletionButton.Text = "Add to Completion";
            this.addToCompletionButton.UseVisualStyleBackColor = true;
            this.addToCompletionButton.Click += new System.EventHandler(this.addToCompletionButton_Click);
            // 
            // addToIncrementButton
            // 
            this.addToIncrementButton.Location = new System.Drawing.Point(630, 240);
            this.addToIncrementButton.Name = "addToIncrementButton";
            this.addToIncrementButton.Size = new System.Drawing.Size(200, 21);
            this.addToIncrementButton.TabIndex = 9;
            this.addToIncrementButton.Text = "Add to Increment";
            this.addToIncrementButton.UseVisualStyleBackColor = true;
            this.addToIncrementButton.Click += new System.EventHandler(this.addToIncrementButton_Click);
            // 
            // addTemplateButton
            // 
            this.addTemplateButton.Location = new System.Drawing.Point(390, 277);
            this.addTemplateButton.Name = "addTemplateButton";
            this.addTemplateButton.Size = new System.Drawing.Size(100, 42);
            this.addTemplateButton.TabIndex = 14;
            this.addTemplateButton.Text = "Add Element";
            this.addTemplateButton.UseVisualStyleBackColor = true;
            this.addTemplateButton.Click += new System.EventHandler(this.addTemplateButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(500, 277);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(100, 53);
            this.generateButton.TabIndex = 15;
            this.generateButton.Text = "Generate Files";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // languageComboBox
            // 
            this.languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Location = new System.Drawing.Point(630, 299);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(80, 20);
            this.languageComboBox.TabIndex = 16;
            this.languageComboBox.SelectedIndexChanged += new System.EventHandler(this.languageComboBox_SelectedIndexChanged_1);
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(12, 14);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(17, 12);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "ID";
            // 
            // labelHero
            // 
            this.labelHero.AutoSize = true;
            this.labelHero.Location = new System.Drawing.Point(12, 42);
            this.labelHero.Name = "labelHero";
            this.labelHero.Size = new System.Drawing.Size(29, 12);
            this.labelHero.TabIndex = 2;
            this.labelHero.Text = "Hero";
            // 
            // labelUpdateType
            // 
            this.labelUpdateType.AutoSize = true;
            this.labelUpdateType.Location = new System.Drawing.Point(12, 69);
            this.labelUpdateType.Name = "labelUpdateType";
            this.labelUpdateType.Size = new System.Drawing.Size(71, 12);
            this.labelUpdateType.TabIndex = 4;
            this.labelUpdateType.Text = "Update Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(628, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "Language";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 342);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.languageComboBox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.addTemplateButton);
            this.Controls.Add(this.loadEffectsButton);
            this.Controls.Add(this.saveJsonButton);
            this.Controls.Add(this.newJsonButton);
            this.Controls.Add(this.openJsonButton);
            this.Controls.Add(this.addToIncrementButton);
            this.Controls.Add(this.addToCompletionButton);
            this.Controls.Add(this.effectsListBox);
            this.Controls.Add(this.durationElementsGrid);
            this.Controls.Add(this.updateTypeComboBox);
            this.Controls.Add(this.labelUpdateType);
            this.Controls.Add(this.heroTextBox);
            this.Controls.Add(this.labelHero);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.labelId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Actor Dot Editor";
            ((System.ComponentModel.ISupportInitialize)(this.durationElementsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}