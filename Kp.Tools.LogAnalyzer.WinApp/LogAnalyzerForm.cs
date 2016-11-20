using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

using Kp.Tools.LogAnalyzer.Common;

namespace Kp.Tools.LogAnalyzer.WinApp
{
    public partial class LogAnalyzerForm : Form
    {
        private Dictionary<string, IList<FilterResultItem>> m_CurrentResults = new Dictionary<string, IList<FilterResultItem>>();

        public LogAnalyzerForm()
        {
            InitializeComponent();

            InitializeResultDataGridView();

            InitializeTooltips();

            InitializeControlDefaultValues();
        }

        private void InitializeControlDefaultValues()
        {
            txtLogFolder.Text = @"C:\logs";
            txtFileFilter.Text = "*.log";
        }

        private void InitializeTooltips()
        {
            var toolTipDictionary = new Dictionary<Control, string>()
            {
                { txtFileFilter, "E.g. *.log" },
                { txtStartLine, "Specify from which line to start the search. The first line is 0." },
                { txtResultCount, "Specify the number of first results to stop the search. 0 means 'search for all results'." },
                { txtQuickFilter, BuildTooltip(
                    "When Line Mode is checked, these syntaxes are effective.",
                    " 10: Get first 10 items",
                    " 5-10: Get from item 5 to 10 (1st item is 1)",
                    " :10: Get last 10 items",
                    " 5-: Get from item 5 to the last one",
                    " Otherwise: Invalid"
                )},
                { chkSearchTextIsExclusive, BuildTooltip(
                    "If checked, search results are those that do not match the search text.",
                    "If unchecked, search results are those that match the search text."
                )},
                { chkQuickFilterIsExclusive, BuildTooltip(
                    "If checked, search results are those that do not match the quick filter.",
                    "If unchecked, search results are those that match the quick filter."
                )}
            };

            foreach (var control in toolTipDictionary.Keys)
            {
                toolTip.SetToolTip(control, toolTipDictionary[control]);
            }
        }

        private void btnBrowseLogFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtLogFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            ExecuteWithWatch(() =>
            {
                string logFolder = txtLogFolder.Text;
                var fileSearchOption = (chkIncludesSubFolders.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                var files = Directory.GetFiles(logFolder, txtFileFilter.Text, fileSearchOption);
                if (files.Length == 0)
                {
                    this.ShowInfo("There is no file to analyze.");
                    return false;
                }

                ResetControlsForNewAnalysis();

                var options = new LogFilterOptions()
                {
                    SearchTextIsCaseSensitive = chkSearchTextIsCaseSensitive.Checked,
                    SearchTextIsRegex = chkSearchTextIsRegex.Checked,
                    SearchTextIsExclusive = chkSearchTextIsExclusive.Checked,
                    SearchText = txtSearchText.Text,

                    ItemStartKeyword = txtStartItemPattern.Text,
                    ItemStartKeywordIsCaseSensitive = chkStartItemPatternIsCaseSensitive.Checked,
                    ItemStartKeywordIsRegex = chkStartItemPatternIsRegex.Checked,

                    StartLine = int.Parse(txtStartLine.Text),
                    TopResults = int.Parse(txtResultCount.Text)
                };

                foreach (var file in files)
                {
                    using (var reader = new StreamReader(File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                    {
                        IStringSource stringSource = new TextFileStringSource(file.ExtractRelativePath(logFolder), reader);
                        IList<FilterResultItem> resultItems = LogReader.Analyze(stringSource, options);
                        if (resultItems.Count > 0)
                        {
                            m_CurrentResults[file] = resultItems;
                        }
                    }
                }

                cboResultGroups.DataSource = m_CurrentResults.Keys.ToArray();
                return true;
            });
        }

        private void ResetControlsForNewAnalysis()
        {
            m_CurrentResults.Clear();
            cboResultGroups.DataSource = null;
            resultDataGridView.DataSource = null;
            txtDetailView.Text = string.Empty;
            txtQuickFilter.Text = string.Empty;
        }

        private void InitializeResultDataGridView()
        {
            resultDataGridView.ColumnCount = 2;
            resultDataGridView.AutoGenerateColumns = false;
            resultDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var column0 = resultDataGridView.Columns[0];
            column0.Name = "Line";
            column0.DataPropertyName = "LineNo";
            column0.SortMode = DataGridViewColumnSortMode.Automatic;
            column0.Width = 80;

            var column1 = resultDataGridView.Columns[1];
            column1.Name = "First line";
            column1.DataPropertyName = "FirstLine";
            column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            resultDataGridView.RowPostPaint += resultDataGridView_RowPostPaint;
        }

        private void chkAutoInferSaveFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoInferSaveFolder.Checked)
            {
                txtSaveFolder.Text = InferSaveFolder(txtLogFolder.Text);
            }

            txtSaveFolder.Enabled = !chkAutoInferSaveFolder.Checked;
        }

        private void UpdateSaveFolderIfNeeded()
        {
            if (chkAutoInferSaveFolder.Checked)
            {
                txtSaveFolder.Text = InferSaveFolder(txtLogFolder.Text);
            }
        }

        private string InferSaveFolder(string logFolder)
        {
            if (string.IsNullOrEmpty(logFolder))
            {
                return string.Empty;
            }

            return Path.Combine(logFolder, "{0:yyyy.MM.dd-HH.mm.ss}");
        }

        private void txtLogFolder_TextChanged(object sender, EventArgs e)
        {
            UpdateSaveFolderIfNeeded();
        }

        private void cboResultGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resultGroup = GetSelectedResultGroup();
            SetDataSourceForResultDataGridView(resultGroup);
        }

        private IList<FilterResultItem> GetSelectedResultGroup()
        {
            var key = cboResultGroups.SelectedItem as string;
            return (key == null ? null : m_CurrentResults[key]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ExecuteWithWatch(() =>
            {
                if (m_CurrentResults.Count == 0)
                {
                    this.ShowInfo("No file to save.");
                    return false;
                }

                string saveFolder = string.Format(txtSaveFolder.Text, DateTime.Now);
                LogWriter.WriteToFiles(m_CurrentResults, saveFolder, name => name.ExtractRelativePath(txtLogFolder.Text), null, "[{LineNo}]");
                return true;
            });
        }

        /// <summary>
        /// </summary>
        /// <param name="action">Returns true if the action has done successfully.</param>
        private void ExecuteWithWatch(Func<bool> action)
        {
            Stopwatch watch = new Stopwatch();
            try
            {
                watch.Start();
                bool done = action.Invoke();
                watch.Stop();
                if (done)
                {
                    this.ShowInfo("Done after {0} ms.", watch.ElapsedMilliseconds);
                }
            }
            catch (Exception ex)
            {
                watch.Stop();
                this.ShowError(ex, "Error after {0} ms.", watch.ElapsedMilliseconds);
            }
        }

        private void txtQuickFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) { return; }

            var resultGroup = GetSelectedResultGroup();
            if (resultGroup == null) { return; }

            string filter = txtQuickFilter.Text;
            int totalCount = resultGroup.Count;
            if (totalCount == 0 || string.IsNullOrEmpty(filter))
            {
                SetDataSourceForResultDataGridView(resultGroup);
                return;
            }

            IList<FilterResultItem> filteredResultGroup;
            if (chkQuickFilterByLineMode.Checked)
            {
                // 10: Get first 10 items
                // 5-10: Get from item 5 to 10 (1st item is 1)
                // :10: Get last 10 items
                // 5-: Get from item 5 to the last one
                // Otherwise: Invalid
                int from = 0, to = 0;
                bool valid = false;

                if (filter.StartsWith(":"))
                {
                    int count;
                    valid = int.TryParse(filter.Substring(1), out count);
                    if (valid)
                    {
                        from = totalCount - count + 1;
                    }
                }
                else if (filter.EndsWith("-"))
                {
                    valid = int.TryParse(filter.Substring(0, filter.Length - 1), out from);
                }
                else if (filter.Contains("-"))
                {
                    var parts = filter.Split('-');
                    valid = int.TryParse(parts[0], out from) && int.TryParse(parts[1], out to);
                }
                else
                {
                    valid = int.TryParse(filter, out to);
                }

                if (!valid)
                {
                    txtQuickFilter.Text = "";
                    this.ShowError("Invalid filter expression. Example of valid expressions: 10, 3-10, :10, 5-");
                    return;
                }

                if (from <= 0) { from = 1; }
                if (to <= 0) { to = totalCount; }

                filteredResultGroup = resultGroup.Skip(from - 1).Take(to - from + 1).ToList();
            }
            else
            {
                Func<string, bool> contentMatcher = Helpers.BuildContentMatcher(filter, chkQuickFilterIsCaseSensitive.Checked, chkQuickFilterIsRegex.Checked, false);

                if (chkQuickFilterIsExclusive.Checked)
                {
                    filteredResultGroup = resultGroup.Where(item => !item.Contents.Any(contentMatcher)).ToList();
                }
                else
                {
                    filteredResultGroup = resultGroup.Where(item => item.Contents.Any(contentMatcher)).ToList();
                }
            }

            SetDataSourceForResultDataGridView(filteredResultGroup);
        }

        private void SetDataSourceForResultDataGridView(IList<FilterResultItem> source)
        {
            int count = source == null ? 0 : source.Count;
            lblStatus.Text = string.Format(count < 2 ? "{0} item" : "{0} items", count);
            resultDataGridView.DataSource = source;
        }

        private void resultDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var item = resultDataGridView.Rows[e.RowIndex].DataBoundItem as FilterResultItem;
            if (item == null) { return; }

            txtDetailView.Lines = item.Contents.ToArray();
        }

        private void resultDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (!chkShowGridLineNo.Checked) { return; }

            var grid = sender as DataGridView;
            var rowIndex = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void btnCopyItemContentToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtDetailView.Text);
        }

        private void chkShowGridLineNo_CheckedChanged(object sender, EventArgs e)
        {
            resultDataGridView.Invalidate(resultDataGridView.Bounds);
        }

        private void chkWrapTextInResultGridView_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWrapTextInResultGridView.Checked)
            {
                resultDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            }
            else
            {
                resultDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            }
        }

        private static string BuildTooltip(params string[] args)
        {
            var builder = new StringBuilder();
            foreach (var arg in args)
            {
                builder.AppendLine(arg);
            }

            return builder.ToString();
        }

        private void chkQuickFilterIsExclusive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkQuickFilterIsExclusive.Checked)
            {
                chkQuickFilterByLineMode.Checked = false;
                chkQuickFilterByLineMode.Enabled = false;
            }
            else
            {
                chkQuickFilterByLineMode.Enabled = true;
            }
        }

        private void btnSelectFont_Click(object sender, EventArgs e)
        {
            try
            {
                fontDialog.Font = resultDataGridView.Font;
                if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    resultDataGridView.Font = fontDialog.Font;
                    txtDetailView.Font = fontDialog.Font;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnCopySelectedItemsToClipboard_Click(object sender, EventArgs e)
        {
            int count = resultDataGridView.SelectedRows.Count;
            if (count == 0)
            {
                this.ShowInfo("No item is selected.");
                return;
            }

            var builder = new StringBuilder();
            for (var i = 0; i < count; i++)
            {
                var item = resultDataGridView.Rows[resultDataGridView.SelectedRows[i].Index].DataBoundItem as FilterResultItem;
                if (item == null) { continue; }

                foreach (var line in item.Contents)
                {
                    builder.AppendLine(line);
                }
            }

            Clipboard.SetText(builder.ToString());
        }
    }
}