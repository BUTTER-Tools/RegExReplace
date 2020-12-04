namespace RegExReplace
{
    partial class SettingsForm_RegExReplace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm_RegExReplace));
            this.OKButton = new System.Windows.Forms.Button();
            this.SetFileButton = new System.Windows.Forms.Button();
            this.SelectedFileTextbox = new System.Windows.Forms.TextBox();
            this.EncodingDropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DataGridPreview = new System.Windows.Forms.DataGridView();
            this.CompactWhitespaceCheckbox = new System.Windows.Forms.CheckBox();
            this.CaseSensitiveCheckbox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(447, 372);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(118, 40);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // SetFileButton
            // 
            this.SetFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetFileButton.Location = new System.Drawing.Point(9, 153);
            this.SetFileButton.Name = "SetFileButton";
            this.SetFileButton.Size = new System.Drawing.Size(118, 40);
            this.SetFileButton.TabIndex = 0;
            this.SetFileButton.Text = "Choose File";
            this.SetFileButton.UseVisualStyleBackColor = true;
            this.SetFileButton.Click += new System.EventHandler(this.SetFolderButton_Click);
            // 
            // SelectedFileTextbox
            // 
            this.SelectedFileTextbox.Enabled = false;
            this.SelectedFileTextbox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedFileTextbox.Location = new System.Drawing.Point(9, 124);
            this.SelectedFileTextbox.MaxLength = 2147483647;
            this.SelectedFileTextbox.Name = "SelectedFileTextbox";
            this.SelectedFileTextbox.Size = new System.Drawing.Size(471, 23);
            this.SelectedFileTextbox.TabIndex = 1;
            // 
            // EncodingDropdown
            // 
            this.EncodingDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EncodingDropdown.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncodingDropdown.FormattingEnabled = true;
            this.EncodingDropdown.Location = new System.Drawing.Point(12, 50);
            this.EncodingDropdown.Name = "EncodingDropdown";
            this.EncodingDropdown.Size = new System.Drawing.Size(268, 23);
            this.EncodingDropdown.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select RegEx Replacement File (.txt)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select RegEx File Encoding";
            // 
            // DataGridPreview
            // 
            this.DataGridPreview.AllowUserToAddRows = false;
            this.DataGridPreview.AllowUserToDeleteRows = false;
            this.DataGridPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridPreview.Location = new System.Drawing.Point(548, 31);
            this.DataGridPreview.Name = "DataGridPreview";
            this.DataGridPreview.ReadOnly = true;
            this.DataGridPreview.RowHeadersVisible = false;
            this.DataGridPreview.Size = new System.Drawing.Size(420, 305);
            this.DataGridPreview.TabIndex = 27;
            this.DataGridPreview.VirtualMode = true;
            // 
            // CompactWhitespaceCheckbox
            // 
            this.CompactWhitespaceCheckbox.AutoSize = true;
            this.CompactWhitespaceCheckbox.Checked = true;
            this.CompactWhitespaceCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CompactWhitespaceCheckbox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompactWhitespaceCheckbox.Location = new System.Drawing.Point(9, 280);
            this.CompactWhitespaceCheckbox.Name = "CompactWhitespaceCheckbox";
            this.CompactWhitespaceCheckbox.Size = new System.Drawing.Size(167, 20);
            this.CompactWhitespaceCheckbox.TabIndex = 12;
            this.CompactWhitespaceCheckbox.Text = "Compact Whitespace";
            this.CompactWhitespaceCheckbox.UseVisualStyleBackColor = true;
            // 
            // CaseSensitiveCheckbox
            // 
            this.CaseSensitiveCheckbox.AutoSize = true;
            this.CaseSensitiveCheckbox.Checked = true;
            this.CaseSensitiveCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CaseSensitiveCheckbox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaseSensitiveCheckbox.Location = new System.Drawing.Point(12, 224);
            this.CaseSensitiveCheckbox.Name = "CaseSensitiveCheckbox";
            this.CaseSensitiveCheckbox.Size = new System.Drawing.Size(188, 20);
            this.CaseSensitiveCheckbox.TabIndex = 11;
            this.CaseSensitiveCheckbox.Text = "Case sensitive RegExes?";
            this.CaseSensitiveCheckbox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "(This setting is applied when you load your list.)";
            // 
            // SettingsForm_RegExReplace
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 424);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CompactWhitespaceCheckbox);
            this.Controls.Add(this.CaseSensitiveCheckbox);
            this.Controls.Add(this.DataGridPreview);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EncodingDropdown);
            this.Controls.Add(this.SelectedFileTextbox);
            this.Controls.Add(this.SetFileButton);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm_RegExReplace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plugin Name";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button SetFileButton;
        private System.Windows.Forms.TextBox SelectedFileTextbox;
        private System.Windows.Forms.ComboBox EncodingDropdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DataGridPreview;
        private System.Windows.Forms.CheckBox CompactWhitespaceCheckbox;
        private System.Windows.Forms.CheckBox CaseSensitiveCheckbox;
        private System.Windows.Forms.Label label3;
    }
}