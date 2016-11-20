namespace Kp.Tools.LogAnalyzer.WinApp
{
    partial class LogAnalyzerForm
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
            this.components = new System.ComponentModel.Container();
            this.btnBrowseLogFolder = new System.Windows.Forms.Button();
            this.txtLogFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileFilter = new System.Windows.Forms.TextBox();
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.resultDataGridView = new System.Windows.Forms.DataGridView();
            this.chkSearchTextIsCaseSensitive = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSaveFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseSaveFolder = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkAutoInferSaveFolder = new System.Windows.Forms.CheckBox();
            this.cboResultGroups = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStartItemPattern = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStartLine = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtResultCount = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtDetailView = new System.Windows.Forms.TextBox();
            this.txtQuickFilter = new System.Windows.Forms.TextBox();
            this.chkSearchTextIsRegex = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkStartItemPatternIsRegex = new System.Windows.Forms.CheckBox();
            this.chkQuickFilterByLineMode = new System.Windows.Forms.CheckBox();
            this.chkStartItemPatternIsCaseSensitive = new System.Windows.Forms.CheckBox();
            this.chkShowGridLineNo = new System.Windows.Forms.CheckBox();
            this.btnCopyItemContentToClipboard = new System.Windows.Forms.Button();
            this.chkWrapTextInResultGridView = new System.Windows.Forms.CheckBox();
            this.chkQuickFilterIsRegex = new System.Windows.Forms.CheckBox();
            this.chkQuickFilterIsCaseSensitive = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.chkIncludesSubFolders = new System.Windows.Forms.CheckBox();
            this.chkSearchTextIsExclusive = new System.Windows.Forms.CheckBox();
            this.chkQuickFilterIsExclusive = new System.Windows.Forms.CheckBox();
            this.btnSelectFont = new System.Windows.Forms.Button();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.btnCopySelectedItemsToClipboard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowseLogFolder
            // 
            this.btnBrowseLogFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseLogFolder.Location = new System.Drawing.Point(662, 4);
            this.btnBrowseLogFolder.Name = "btnBrowseLogFolder";
            this.btnBrowseLogFolder.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseLogFolder.TabIndex = 3;
            this.btnBrowseLogFolder.Text = "...";
            this.btnBrowseLogFolder.UseVisualStyleBackColor = true;
            this.btnBrowseLogFolder.Click += new System.EventHandler(this.btnBrowseLogFolder_Click);
            // 
            // txtLogFolder
            // 
            this.txtLogFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogFolder.Location = new System.Drawing.Point(81, 6);
            this.txtLogFolder.Name = "txtLogFolder";
            this.txtLogFolder.Size = new System.Drawing.Size(575, 20);
            this.txtLogFolder.TabIndex = 1;
            this.txtLogFolder.TextChanged += new System.EventHandler(this.txtLogFolder_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Log folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "File filter";
            // 
            // txtFileFilter
            // 
            this.txtFileFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileFilter.Location = new System.Drawing.Point(81, 33);
            this.txtFileFilter.Name = "txtFileFilter";
            this.txtFileFilter.Size = new System.Drawing.Size(490, 20);
            this.txtFileFilter.TabIndex = 5;
            // 
            // txtSearchText
            // 
            this.txtSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchText.Location = new System.Drawing.Point(81, 85);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(370, 20);
            this.txtSearchText.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Search text";
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(12, 151);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(75, 23);
            this.btnAnalyze.TabIndex = 32;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // resultDataGridView
            // 
            this.resultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultDataGridView.Location = new System.Drawing.Point(0, 0);
            this.resultDataGridView.Name = "resultDataGridView";
            this.resultDataGridView.Size = new System.Drawing.Size(334, 254);
            this.resultDataGridView.TabIndex = 1;
            this.resultDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultDataGridView_RowEnter);
            // 
            // chkSearchTextIsCaseSensitive
            // 
            this.chkSearchTextIsCaseSensitive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSearchTextIsCaseSensitive.AutoSize = true;
            this.chkSearchTextIsCaseSensitive.Location = new System.Drawing.Point(457, 87);
            this.chkSearchTextIsCaseSensitive.Name = "chkSearchTextIsCaseSensitive";
            this.chkSearchTextIsCaseSensitive.Size = new System.Drawing.Size(94, 17);
            this.chkSearchTextIsCaseSensitive.TabIndex = 22;
            this.chkSearchTextIsCaseSensitive.Text = "Case-sensitive";
            this.chkSearchTextIsCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Start item pattern";
            // 
            // txtSaveFolder
            // 
            this.txtSaveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaveFolder.Enabled = false;
            this.txtSaveFolder.Location = new System.Drawing.Point(79, 111);
            this.txtSaveFolder.Name = "txtSaveFolder";
            this.txtSaveFolder.Size = new System.Drawing.Size(513, 20);
            this.txtSaveFolder.TabIndex = 26;
            // 
            // btnBrowseSaveFolder
            // 
            this.btnBrowseSaveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseSaveFolder.Location = new System.Drawing.Point(598, 109);
            this.btnBrowseSaveFolder.Name = "btnBrowseSaveFolder";
            this.btnBrowseSaveFolder.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseSaveFolder.TabIndex = 28;
            this.btnBrowseSaveFolder.Text = "...";
            this.btnBrowseSaveFolder.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(539, 151);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(153, 23);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Save results to file";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkAutoInferSaveFolder
            // 
            this.chkAutoInferSaveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoInferSaveFolder.AutoSize = true;
            this.chkAutoInferSaveFolder.Checked = true;
            this.chkAutoInferSaveFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoInferSaveFolder.Location = new System.Drawing.Point(644, 113);
            this.chkAutoInferSaveFolder.Name = "chkAutoInferSaveFolder";
            this.chkAutoInferSaveFolder.Size = new System.Drawing.Size(48, 17);
            this.chkAutoInferSaveFolder.TabIndex = 30;
            this.chkAutoInferSaveFolder.Text = "Auto";
            this.chkAutoInferSaveFolder.UseVisualStyleBackColor = true;
            this.chkAutoInferSaveFolder.CheckedChanged += new System.EventHandler(this.chkAutoInferSaveFolder_CheckedChanged);
            // 
            // cboResultGroups
            // 
            this.cboResultGroups.FormattingEnabled = true;
            this.cboResultGroups.Location = new System.Drawing.Point(93, 153);
            this.cboResultGroups.Name = "cboResultGroups";
            this.cboResultGroups.Size = new System.Drawing.Size(422, 21);
            this.cboResultGroups.TabIndex = 34;
            this.cboResultGroups.SelectedIndexChanged += new System.EventHandler(this.cboResultGroups_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Save folder";
            // 
            // txtStartItemPattern
            // 
            this.txtStartItemPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartItemPattern.Location = new System.Drawing.Point(105, 60);
            this.txtStartItemPattern.Name = "txtStartItemPattern";
            this.txtStartItemPattern.Size = new System.Drawing.Size(125, 20);
            this.txtStartItemPattern.TabIndex = 10;
            this.txtStartItemPattern.Text = "[";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(431, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Start line";
            // 
            // txtStartLine
            // 
            this.txtStartLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartLine.Location = new System.Drawing.Point(485, 61);
            this.txtStartLine.Name = "txtStartLine";
            this.txtStartLine.Size = new System.Drawing.Size(57, 20);
            this.txtStartLine.TabIndex = 16;
            this.txtStartLine.Text = "0";
            this.txtStartLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(571, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Result limit";
            // 
            // txtResultCount
            // 
            this.txtResultCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultCount.Location = new System.Drawing.Point(634, 60);
            this.txtResultCount.Name = "txtResultCount";
            this.txtResultCount.Size = new System.Drawing.Size(57, 20);
            this.txtResultCount.TabIndex = 18;
            this.txtResultCount.Text = "0";
            this.txtResultCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 208);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.resultDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtDetailView);
            this.splitContainer1.Size = new System.Drawing.Size(680, 254);
            this.splitContainer1.SplitterDistance = 334;
            this.splitContainer1.TabIndex = 45;
            // 
            // txtDetailView
            // 
            this.txtDetailView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetailView.Location = new System.Drawing.Point(0, 0);
            this.txtDetailView.Multiline = true;
            this.txtDetailView.Name = "txtDetailView";
            this.txtDetailView.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDetailView.Size = new System.Drawing.Size(342, 254);
            this.txtDetailView.TabIndex = 3;
            // 
            // txtQuickFilter
            // 
            this.txtQuickFilter.Location = new System.Drawing.Point(144, 185);
            this.txtQuickFilter.Name = "txtQuickFilter";
            this.txtQuickFilter.Size = new System.Drawing.Size(226, 20);
            this.txtQuickFilter.TabIndex = 38;
            this.txtQuickFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQuickFilter_KeyUp);
            // 
            // chkSearchTextIsRegex
            // 
            this.chkSearchTextIsRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSearchTextIsRegex.AutoSize = true;
            this.chkSearchTextIsRegex.Location = new System.Drawing.Point(557, 87);
            this.chkSearchTextIsRegex.Name = "chkSearchTextIsRegex";
            this.chkSearchTextIsRegex.Size = new System.Drawing.Size(57, 17);
            this.chkSearchTextIsRegex.TabIndex = 24;
            this.chkSearchTextIsRegex.Text = "Regex";
            this.chkSearchTextIsRegex.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(267, 470);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 33;
            this.lblStatus.Text = "0 item";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Quick filter (Enter to start)";
            // 
            // chkStartItemPatternIsRegex
            // 
            this.chkStartItemPatternIsRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkStartItemPatternIsRegex.AutoSize = true;
            this.chkStartItemPatternIsRegex.Location = new System.Drawing.Point(336, 63);
            this.chkStartItemPatternIsRegex.Name = "chkStartItemPatternIsRegex";
            this.chkStartItemPatternIsRegex.Size = new System.Drawing.Size(57, 17);
            this.chkStartItemPatternIsRegex.TabIndex = 14;
            this.chkStartItemPatternIsRegex.Text = "Regex";
            this.chkStartItemPatternIsRegex.UseVisualStyleBackColor = true;
            // 
            // chkQuickFilterByLineMode
            // 
            this.chkQuickFilterByLineMode.AutoSize = true;
            this.chkQuickFilterByLineMode.Location = new System.Drawing.Point(376, 188);
            this.chkQuickFilterByLineMode.Name = "chkQuickFilterByLineMode";
            this.chkQuickFilterByLineMode.Size = new System.Drawing.Size(75, 17);
            this.chkQuickFilterByLineMode.TabIndex = 39;
            this.chkQuickFilterByLineMode.Text = "Line mode";
            this.chkQuickFilterByLineMode.UseVisualStyleBackColor = true;
            // 
            // chkStartItemPatternIsCaseSensitive
            // 
            this.chkStartItemPatternIsCaseSensitive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkStartItemPatternIsCaseSensitive.AutoSize = true;
            this.chkStartItemPatternIsCaseSensitive.Location = new System.Drawing.Point(236, 62);
            this.chkStartItemPatternIsCaseSensitive.Name = "chkStartItemPatternIsCaseSensitive";
            this.chkStartItemPatternIsCaseSensitive.Size = new System.Drawing.Size(94, 17);
            this.chkStartItemPatternIsCaseSensitive.TabIndex = 12;
            this.chkStartItemPatternIsCaseSensitive.Text = "Case-sensitive";
            this.chkStartItemPatternIsCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // chkShowGridLineNo
            // 
            this.chkShowGridLineNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowGridLineNo.AutoSize = true;
            this.chkShowGridLineNo.Location = new System.Drawing.Point(41, 469);
            this.chkShowGridLineNo.Name = "chkShowGridLineNo";
            this.chkShowGridLineNo.Size = new System.Drawing.Size(130, 17);
            this.chkShowGridLineNo.TabIndex = 50;
            this.chkShowGridLineNo.Text = "Show grid line number";
            this.chkShowGridLineNo.UseVisualStyleBackColor = true;
            this.chkShowGridLineNo.CheckedChanged += new System.EventHandler(this.chkShowGridLineNo_CheckedChanged);
            // 
            // btnCopyItemContentToClipboard
            // 
            this.btnCopyItemContentToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyItemContentToClipboard.Location = new System.Drawing.Point(557, 464);
            this.btnCopyItemContentToClipboard.Name = "btnCopyItemContentToClipboard";
            this.btnCopyItemContentToClipboard.Size = new System.Drawing.Size(134, 23);
            this.btnCopyItemContentToClipboard.TabIndex = 54;
            this.btnCopyItemContentToClipboard.Text = "Copy text to Clipboard";
            this.btnCopyItemContentToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyItemContentToClipboard.Click += new System.EventHandler(this.btnCopyItemContentToClipboard_Click);
            // 
            // chkWrapTextInResultGridView
            // 
            this.chkWrapTextInResultGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkWrapTextInResultGridView.AutoSize = true;
            this.chkWrapTextInResultGridView.Location = new System.Drawing.Point(177, 469);
            this.chkWrapTextInResultGridView.Name = "chkWrapTextInResultGridView";
            this.chkWrapTextInResultGridView.Size = new System.Drawing.Size(72, 17);
            this.chkWrapTextInResultGridView.TabIndex = 52;
            this.chkWrapTextInResultGridView.Text = "Wrap text";
            this.chkWrapTextInResultGridView.UseVisualStyleBackColor = true;
            this.chkWrapTextInResultGridView.CheckedChanged += new System.EventHandler(this.chkWrapTextInResultGridView_CheckedChanged);
            // 
            // chkQuickFilterIsRegex
            // 
            this.chkQuickFilterIsRegex.AutoSize = true;
            this.chkQuickFilterIsRegex.Location = new System.Drawing.Point(557, 188);
            this.chkQuickFilterIsRegex.Name = "chkQuickFilterIsRegex";
            this.chkQuickFilterIsRegex.Size = new System.Drawing.Size(57, 17);
            this.chkQuickFilterIsRegex.TabIndex = 41;
            this.chkQuickFilterIsRegex.Text = "Regex";
            this.chkQuickFilterIsRegex.UseVisualStyleBackColor = true;
            // 
            // chkQuickFilterIsCaseSensitive
            // 
            this.chkQuickFilterIsCaseSensitive.AutoSize = true;
            this.chkQuickFilterIsCaseSensitive.Location = new System.Drawing.Point(457, 187);
            this.chkQuickFilterIsCaseSensitive.Name = "chkQuickFilterIsCaseSensitive";
            this.chkQuickFilterIsCaseSensitive.Size = new System.Drawing.Size(94, 17);
            this.chkQuickFilterIsCaseSensitive.TabIndex = 40;
            this.chkQuickFilterIsCaseSensitive.Text = "Case-sensitive";
            this.chkQuickFilterIsCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // chkIncludesSubFolders
            // 
            this.chkIncludesSubFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIncludesSubFolders.AutoSize = true;
            this.chkIncludesSubFolders.Location = new System.Drawing.Point(577, 36);
            this.chkIncludesSubFolders.Name = "chkIncludesSubFolders";
            this.chkIncludesSubFolders.Size = new System.Drawing.Size(115, 17);
            this.chkIncludesSubFolders.TabIndex = 6;
            this.chkIncludesSubFolders.Text = "Include sub-folders";
            this.chkIncludesSubFolders.UseVisualStyleBackColor = true;
            // 
            // chkSearchTextIsExclusive
            // 
            this.chkSearchTextIsExclusive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSearchTextIsExclusive.AutoSize = true;
            this.chkSearchTextIsExclusive.Location = new System.Drawing.Point(620, 87);
            this.chkSearchTextIsExclusive.Name = "chkSearchTextIsExclusive";
            this.chkSearchTextIsExclusive.Size = new System.Drawing.Size(71, 17);
            this.chkSearchTextIsExclusive.TabIndex = 25;
            this.chkSearchTextIsExclusive.Text = "Exclusive";
            this.chkSearchTextIsExclusive.UseVisualStyleBackColor = true;
            // 
            // chkQuickFilterIsExclusive
            // 
            this.chkQuickFilterIsExclusive.AutoSize = true;
            this.chkQuickFilterIsExclusive.Location = new System.Drawing.Point(620, 187);
            this.chkQuickFilterIsExclusive.Name = "chkQuickFilterIsExclusive";
            this.chkQuickFilterIsExclusive.Size = new System.Drawing.Size(71, 17);
            this.chkQuickFilterIsExclusive.TabIndex = 42;
            this.chkQuickFilterIsExclusive.Text = "Exclusive";
            this.chkQuickFilterIsExclusive.UseVisualStyleBackColor = true;
            this.chkQuickFilterIsExclusive.CheckedChanged += new System.EventHandler(this.chkQuickFilterIsExclusive_CheckedChanged);
            // 
            // btnSelectFont
            // 
            this.btnSelectFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectFont.Location = new System.Drawing.Point(12, 465);
            this.btnSelectFont.Name = "btnSelectFont";
            this.btnSelectFont.Size = new System.Drawing.Size(23, 23);
            this.btnSelectFont.TabIndex = 49;
            this.btnSelectFont.Text = "F";
            this.btnSelectFont.UseVisualStyleBackColor = true;
            this.btnSelectFont.Click += new System.EventHandler(this.btnSelectFont_Click);
            // 
            // btnCopySelectedItemsToClipboard
            // 
            this.btnCopySelectedItemsToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopySelectedItemsToClipboard.Location = new System.Drawing.Point(369, 465);
            this.btnCopySelectedItemsToClipboard.Name = "btnCopySelectedItemsToClipboard";
            this.btnCopySelectedItemsToClipboard.Size = new System.Drawing.Size(182, 23);
            this.btnCopySelectedItemsToClipboard.TabIndex = 53;
            this.btnCopySelectedItemsToClipboard.Text = "Copy selected items to Clipboard";
            this.btnCopySelectedItemsToClipboard.UseVisualStyleBackColor = true;
            this.btnCopySelectedItemsToClipboard.Click += new System.EventHandler(this.btnCopySelectedItemsToClipboard_Click);
            // 
            // LogAnalyzerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 494);
            this.Controls.Add(this.btnCopySelectedItemsToClipboard);
            this.Controls.Add(this.btnSelectFont);
            this.Controls.Add(this.chkQuickFilterIsExclusive);
            this.Controls.Add(this.chkSearchTextIsExclusive);
            this.Controls.Add(this.chkIncludesSubFolders);
            this.Controls.Add(this.chkQuickFilterIsRegex);
            this.Controls.Add(this.chkQuickFilterIsCaseSensitive);
            this.Controls.Add(this.chkWrapTextInResultGridView);
            this.Controls.Add(this.btnCopyItemContentToClipboard);
            this.Controls.Add(this.chkShowGridLineNo);
            this.Controls.Add(this.chkStartItemPatternIsCaseSensitive);
            this.Controls.Add(this.chkQuickFilterByLineMode);
            this.Controls.Add(this.chkStartItemPatternIsRegex);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.chkSearchTextIsRegex);
            this.Controls.Add(this.txtQuickFilter);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtResultCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStartLine);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStartItemPattern);
            this.Controls.Add(this.cboResultGroups);
            this.Controls.Add(this.chkAutoInferSaveFolder);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSaveFolder);
            this.Controls.Add(this.btnBrowseSaveFolder);
            this.Controls.Add(this.chkSearchTextIsCaseSensitive);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFileFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLogFolder);
            this.Controls.Add(this.btnBrowseLogFolder);
            this.MinimumSize = new System.Drawing.Size(720, 532);
            this.Name = "LogAnalyzerForm";
            this.ShowIcon = false;
            this.Text = "Log Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseLogFolder;
        private System.Windows.Forms.TextBox txtLogFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileFilter;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.DataGridView resultDataGridView;
        private System.Windows.Forms.CheckBox chkSearchTextIsCaseSensitive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSaveFolder;
        private System.Windows.Forms.Button btnBrowseSaveFolder;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkAutoInferSaveFolder;
        private System.Windows.Forms.ComboBox cboResultGroups;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStartItemPattern;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStartLine;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtResultCount;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtDetailView;
        private System.Windows.Forms.TextBox txtQuickFilter;
        private System.Windows.Forms.CheckBox chkSearchTextIsRegex;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkStartItemPatternIsRegex;
        private System.Windows.Forms.CheckBox chkQuickFilterByLineMode;
        private System.Windows.Forms.CheckBox chkStartItemPatternIsCaseSensitive;
        private System.Windows.Forms.CheckBox chkShowGridLineNo;
        private System.Windows.Forms.Button btnCopyItemContentToClipboard;
        private System.Windows.Forms.CheckBox chkWrapTextInResultGridView;
        private System.Windows.Forms.CheckBox chkQuickFilterIsRegex;
        private System.Windows.Forms.CheckBox chkQuickFilterIsCaseSensitive;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox chkIncludesSubFolders;
        private System.Windows.Forms.CheckBox chkSearchTextIsExclusive;
        private System.Windows.Forms.CheckBox chkQuickFilterIsExclusive;
        private System.Windows.Forms.Button btnSelectFont;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Button btnCopySelectedItemsToClipboard;
    }
}

