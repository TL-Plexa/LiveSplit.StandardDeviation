namespace LiveSplit.UI.Components
{
    partial class StandardDeviationSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.topLevelLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainGroup = new System.Windows.Forms.GroupBox();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.chkShowCurrent = new System.Windows.Forms.CheckBox();
            this.chkShowPrevious = new System.Windows.Forms.CheckBox();
            this.chkDisplay2Rows = new System.Windows.Forms.CheckBox();
            this.decimalGroup = new System.Windows.Forms.GroupBox();
            this.decimalLayout = new System.Windows.Forms.TableLayoutPanel();
            this.rdoDecimalWhole = new System.Windows.Forms.RadioButton();
            this.rdoDecimalTenths = new System.Windows.Forms.RadioButton();
            this.rdoDecimalHundredths = new System.Windows.Forms.RadioButton();
            this.currentGroup = new System.Windows.Forms.GroupBox();
            this.currentLayout = new System.Windows.Forms.TableLayoutPanel();
            this.chkCurrentSigma = new System.Windows.Forms.CheckBox();
            this.chkCurrentAverage = new System.Windows.Forms.CheckBox();
            this.chkCurrentCount = new System.Windows.Forms.CheckBox();
            this.previousGroup = new System.Windows.Forms.GroupBox();
            this.previousLayout = new System.Windows.Forms.TableLayoutPanel();
            this.chkPreviousSigma = new System.Windows.Forms.CheckBox();
            this.chkPreviousAverage = new System.Windows.Forms.CheckBox();
            this.chkPreviousCount = new System.Windows.Forms.CheckBox();
            this.timeFormatGroup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rdoTimeFormatSeconds = new System.Windows.Forms.RadioButton();
            this.rdoTimeFormatTime = new System.Windows.Forms.RadioButton();
            this.topLevelLayoutPanel.SuspendLayout();
            this.mainGroup.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.decimalGroup.SuspendLayout();
            this.decimalLayout.SuspendLayout();
            this.currentGroup.SuspendLayout();
            this.currentLayout.SuspendLayout();
            this.previousGroup.SuspendLayout();
            this.previousLayout.SuspendLayout();
            this.timeFormatGroup.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topLevelLayoutPanel
            // 
            this.topLevelLayoutPanel.AutoSize = true;
            this.topLevelLayoutPanel.ColumnCount = 1;
            this.topLevelLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topLevelLayoutPanel.Controls.Add(this.mainGroup, 0, 0);
            this.topLevelLayoutPanel.Controls.Add(this.currentGroup, 0, 1);
            this.topLevelLayoutPanel.Controls.Add(this.previousGroup, 0, 2);
            this.topLevelLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topLevelLayoutPanel.Location = new System.Drawing.Point(10, 10);
            this.topLevelLayoutPanel.Name = "topLevelLayoutPanel";
            this.topLevelLayoutPanel.RowCount = 3;
            this.topLevelLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topLevelLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topLevelLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topLevelLayoutPanel.Size = new System.Drawing.Size(464, 532);
            this.topLevelLayoutPanel.TabIndex = 0;
            // 
            // mainGroup
            // 
            this.mainGroup.AutoSize = true;
            this.mainGroup.Controls.Add(this.mainLayout);
            this.mainGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGroup.Location = new System.Drawing.Point(3, 3);
            this.mainGroup.Name = "mainGroup";
            this.mainGroup.Padding = new System.Windows.Forms.Padding(10);
            this.mainGroup.Size = new System.Drawing.Size(458, 230);
            this.mainGroup.TabIndex = 0;
            this.mainGroup.TabStop = false;
            this.mainGroup.Text = "Display Options";
            // 
            // mainLayout
            // 
            this.mainLayout.AutoSize = true;
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.chkShowCurrent, 0, 0);
            this.mainLayout.Controls.Add(this.chkShowPrevious, 0, 1);
            this.mainLayout.Controls.Add(this.chkDisplay2Rows, 0, 2);
            this.mainLayout.Controls.Add(this.decimalGroup, 0, 3);
            this.mainLayout.Controls.Add(this.timeFormatGroup, 0, 4);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(10, 23);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 5;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayout.Size = new System.Drawing.Size(438, 197);
            this.mainLayout.TabIndex = 0;
            // 
            // chkShowCurrent
            // 
            this.chkShowCurrent.AutoSize = true;
            this.chkShowCurrent.Checked = true;
            this.chkShowCurrent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowCurrent.Location = new System.Drawing.Point(6, 6);
            this.chkShowCurrent.Margin = new System.Windows.Forms.Padding(6);
            this.chkShowCurrent.Name = "chkShowCurrent";
            this.chkShowCurrent.Size = new System.Drawing.Size(207, 17);
            this.chkShowCurrent.TabIndex = 0;
            this.chkShowCurrent.Text = "Show Current Split Standard Deviation";
            this.chkShowCurrent.UseVisualStyleBackColor = true;
            this.chkShowCurrent.CheckedChanged += new System.EventHandler(this.chkShowCurrent_CheckedChanged);
            // 
            // chkShowPrevious
            // 
            this.chkShowPrevious.AutoSize = true;
            this.chkShowPrevious.Location = new System.Drawing.Point(6, 35);
            this.chkShowPrevious.Margin = new System.Windows.Forms.Padding(6);
            this.chkShowPrevious.Name = "chkShowPrevious";
            this.chkShowPrevious.Size = new System.Drawing.Size(214, 17);
            this.chkShowPrevious.TabIndex = 1;
            this.chkShowPrevious.Text = "Show Previous Split Standard Deviation";
            this.chkShowPrevious.UseVisualStyleBackColor = true;
            this.chkShowPrevious.CheckedChanged += new System.EventHandler(this.chkShowPrevious_CheckedChanged);
            // 
            // chkDisplay2Rows
            // 
            this.chkDisplay2Rows.AutoSize = true;
            this.chkDisplay2Rows.Location = new System.Drawing.Point(6, 64);
            this.chkDisplay2Rows.Margin = new System.Windows.Forms.Padding(6);
            this.chkDisplay2Rows.Name = "chkDisplay2Rows";
            this.chkDisplay2Rows.Size = new System.Drawing.Size(99, 17);
            this.chkDisplay2Rows.TabIndex = 2;
            this.chkDisplay2Rows.Text = "Display 2 Rows";
            this.chkDisplay2Rows.UseVisualStyleBackColor = true;
            this.chkDisplay2Rows.CheckedChanged += new System.EventHandler(this.chkDisplay2Rows_CheckedChanged);
            // 
            // decimalGroup
            // 
            this.decimalGroup.AutoSize = true;
            this.decimalGroup.Controls.Add(this.decimalLayout);
            this.decimalGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decimalGroup.Location = new System.Drawing.Point(3, 90);
            this.decimalGroup.Name = "decimalGroup";
            this.decimalGroup.Padding = new System.Windows.Forms.Padding(6);
            this.decimalGroup.Size = new System.Drawing.Size(432, 48);
            this.decimalGroup.TabIndex = 3;
            this.decimalGroup.TabStop = false;
            this.decimalGroup.Text = "Decimal Precision";
            // 
            // decimalLayout
            // 
            this.decimalLayout.AutoSize = true;
            this.decimalLayout.ColumnCount = 3;
            this.decimalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.decimalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.decimalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.decimalLayout.Controls.Add(this.rdoDecimalWhole, 0, 0);
            this.decimalLayout.Controls.Add(this.rdoDecimalTenths, 1, 0);
            this.decimalLayout.Controls.Add(this.rdoDecimalHundredths, 2, 0);
            this.decimalLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decimalLayout.Location = new System.Drawing.Point(6, 19);
            this.decimalLayout.Name = "decimalLayout";
            this.decimalLayout.RowCount = 1;
            this.decimalLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.decimalLayout.Size = new System.Drawing.Size(420, 23);
            this.decimalLayout.TabIndex = 0;
            // 
            // rdoDecimalWhole
            // 
            this.rdoDecimalWhole.AutoSize = true;
            this.rdoDecimalWhole.Location = new System.Drawing.Point(3, 3);
            this.rdoDecimalWhole.Name = "rdoDecimalWhole";
            this.rdoDecimalWhole.Size = new System.Drawing.Size(76, 17);
            this.rdoDecimalWhole.TabIndex = 0;
            this.rdoDecimalWhole.Text = "Whole (1s)";
            this.rdoDecimalWhole.UseVisualStyleBackColor = true;
            this.rdoDecimalWhole.CheckedChanged += new System.EventHandler(this.rdoDecimalWhole_CheckedChanged);
            // 
            // rdoDecimalTenths
            // 
            this.rdoDecimalTenths.AutoSize = true;
            this.rdoDecimalTenths.Location = new System.Drawing.Point(143, 3);
            this.rdoDecimalTenths.Name = "rdoDecimalTenths";
            this.rdoDecimalTenths.Size = new System.Drawing.Size(87, 17);
            this.rdoDecimalTenths.TabIndex = 1;
            this.rdoDecimalTenths.Text = "Tenths (1.1s)";
            this.rdoDecimalTenths.UseVisualStyleBackColor = true;
            this.rdoDecimalTenths.CheckedChanged += new System.EventHandler(this.rdoDecimalTenths_CheckedChanged);
            // 
            // rdoDecimalHundredths
            // 
            this.rdoDecimalHundredths.AutoSize = true;
            this.rdoDecimalHundredths.Checked = true;
            this.rdoDecimalHundredths.Location = new System.Drawing.Point(283, 3);
            this.rdoDecimalHundredths.Name = "rdoDecimalHundredths";
            this.rdoDecimalHundredths.Size = new System.Drawing.Size(115, 17);
            this.rdoDecimalHundredths.TabIndex = 2;
            this.rdoDecimalHundredths.TabStop = true;
            this.rdoDecimalHundredths.Text = "Hundredths (1.11s)";
            this.rdoDecimalHundredths.UseVisualStyleBackColor = true;
            this.rdoDecimalHundredths.CheckedChanged += new System.EventHandler(this.rdoDecimalHundredths_CheckedChanged);
            // 
            // currentGroup
            // 
            this.currentGroup.AutoSize = true;
            this.currentGroup.Controls.Add(this.currentLayout);
            this.currentGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentGroup.Location = new System.Drawing.Point(3, 239);
            this.currentGroup.Name = "currentGroup";
            this.currentGroup.Padding = new System.Windows.Forms.Padding(10);
            this.currentGroup.Size = new System.Drawing.Size(458, 120);
            this.currentGroup.TabIndex = 1;
            this.currentGroup.TabStop = false;
            this.currentGroup.Text = "Current Split Extra Data";
            // 
            // currentLayout
            // 
            this.currentLayout.AutoSize = true;
            this.currentLayout.ColumnCount = 1;
            this.currentLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.currentLayout.Controls.Add(this.chkCurrentSigma, 0, 0);
            this.currentLayout.Controls.Add(this.chkCurrentAverage, 0, 1);
            this.currentLayout.Controls.Add(this.chkCurrentCount, 0, 2);
            this.currentLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentLayout.Location = new System.Drawing.Point(10, 23);
            this.currentLayout.Name = "currentLayout";
            this.currentLayout.RowCount = 3;
            this.currentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.currentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.currentLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.currentLayout.Size = new System.Drawing.Size(438, 87);
            this.currentLayout.TabIndex = 0;
            // 
            // chkCurrentSigma
            // 
            this.chkCurrentSigma.AutoSize = true;
            this.chkCurrentSigma.Enabled = false;
            this.chkCurrentSigma.Location = new System.Drawing.Point(6, 6);
            this.chkCurrentSigma.Margin = new System.Windows.Forms.Padding(6);
            this.chkCurrentSigma.Name = "chkCurrentSigma";
            this.chkCurrentSigma.Size = new System.Drawing.Size(182, 17);
            this.chkCurrentSigma.TabIndex = 0;
            this.chkCurrentSigma.Text = "Show Sigma Comparison (±X.Xσ)";
            this.chkCurrentSigma.UseVisualStyleBackColor = true;
            this.chkCurrentSigma.CheckedChanged += new System.EventHandler(this.chkCurrentSigma_CheckedChanged);
            // 
            // chkCurrentAverage
            // 
            this.chkCurrentAverage.AutoSize = true;
            this.chkCurrentAverage.Enabled = false;
            this.chkCurrentAverage.Location = new System.Drawing.Point(6, 35);
            this.chkCurrentAverage.Margin = new System.Windows.Forms.Padding(6);
            this.chkCurrentAverage.Name = "chkCurrentAverage";
            this.chkCurrentAverage.Size = new System.Drawing.Size(181, 17);
            this.chkCurrentAverage.TabIndex = 1;
            this.chkCurrentAverage.Text = "Show Average Time (avg:X.XXs)";
            this.chkCurrentAverage.UseVisualStyleBackColor = true;
            this.chkCurrentAverage.CheckedChanged += new System.EventHandler(this.chkCurrentAverage_CheckedChanged);
            // 
            // chkCurrentCount
            // 
            this.chkCurrentCount.AutoSize = true;
            this.chkCurrentCount.Enabled = false;
            this.chkCurrentCount.Location = new System.Drawing.Point(6, 64);
            this.chkCurrentCount.Margin = new System.Windows.Forms.Padding(6);
            this.chkCurrentCount.Name = "chkCurrentCount";
            this.chkCurrentCount.Size = new System.Drawing.Size(150, 17);
            this.chkCurrentCount.TabIndex = 2;
            this.chkCurrentCount.Text = "Show Sample Count (n=X)";
            this.chkCurrentCount.UseVisualStyleBackColor = true;
            this.chkCurrentCount.CheckedChanged += new System.EventHandler(this.chkCurrentCount_CheckedChanged);
            // 
            // previousGroup
            // 
            this.previousGroup.AutoSize = true;
            this.previousGroup.Controls.Add(this.previousLayout);
            this.previousGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previousGroup.Location = new System.Drawing.Point(3, 365);
            this.previousGroup.Name = "previousGroup";
            this.previousGroup.Padding = new System.Windows.Forms.Padding(10);
            this.previousGroup.Size = new System.Drawing.Size(458, 164);
            this.previousGroup.TabIndex = 2;
            this.previousGroup.TabStop = false;
            this.previousGroup.Text = "Previous Split Extra Data";
            // 
            // previousLayout
            // 
            this.previousLayout.AutoSize = true;
            this.previousLayout.ColumnCount = 1;
            this.previousLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.previousLayout.Controls.Add(this.chkPreviousSigma, 0, 0);
            this.previousLayout.Controls.Add(this.chkPreviousAverage, 0, 1);
            this.previousLayout.Controls.Add(this.chkPreviousCount, 0, 2);
            this.previousLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previousLayout.Location = new System.Drawing.Point(10, 23);
            this.previousLayout.Name = "previousLayout";
            this.previousLayout.RowCount = 3;
            this.previousLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.previousLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.previousLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.previousLayout.Size = new System.Drawing.Size(438, 131);
            this.previousLayout.TabIndex = 0;
            // 
            // chkPreviousSigma
            // 
            this.chkPreviousSigma.AutoSize = true;
            this.chkPreviousSigma.Enabled = false;
            this.chkPreviousSigma.Location = new System.Drawing.Point(6, 6);
            this.chkPreviousSigma.Margin = new System.Windows.Forms.Padding(6);
            this.chkPreviousSigma.Name = "chkPreviousSigma";
            this.chkPreviousSigma.Size = new System.Drawing.Size(182, 17);
            this.chkPreviousSigma.TabIndex = 0;
            this.chkPreviousSigma.Text = "Show Sigma Comparison (±X.Xσ)";
            this.chkPreviousSigma.UseVisualStyleBackColor = true;
            this.chkPreviousSigma.CheckedChanged += new System.EventHandler(this.chkPreviousSigma_CheckedChanged);
            // 
            // chkPreviousAverage
            // 
            this.chkPreviousAverage.AutoSize = true;
            this.chkPreviousAverage.Enabled = false;
            this.chkPreviousAverage.Location = new System.Drawing.Point(6, 35);
            this.chkPreviousAverage.Margin = new System.Windows.Forms.Padding(6);
            this.chkPreviousAverage.Name = "chkPreviousAverage";
            this.chkPreviousAverage.Size = new System.Drawing.Size(181, 17);
            this.chkPreviousAverage.TabIndex = 1;
            this.chkPreviousAverage.Text = "Show Average Time (avg:X.XXs)";
            this.chkPreviousAverage.UseVisualStyleBackColor = true;
            this.chkPreviousAverage.CheckedChanged += new System.EventHandler(this.chkPreviousAverage_CheckedChanged);
            // 
            // chkPreviousCount
            // 
            this.chkPreviousCount.AutoSize = true;
            this.chkPreviousCount.Enabled = false;
            this.chkPreviousCount.Location = new System.Drawing.Point(6, 64);
            this.chkPreviousCount.Margin = new System.Windows.Forms.Padding(6);
            this.chkPreviousCount.Name = "chkPreviousCount";
            this.chkPreviousCount.Size = new System.Drawing.Size(150, 17);
            this.chkPreviousCount.TabIndex = 2;
            this.chkPreviousCount.Text = "Show Sample Count (n=X)";
            this.chkPreviousCount.UseVisualStyleBackColor = true;
            this.chkPreviousCount.CheckedChanged += new System.EventHandler(this.chkPreviousCount_CheckedChanged);
            // 
            // timeFormatGroup
            // 
            this.timeFormatGroup.Controls.Add(this.tableLayoutPanel1);
            this.timeFormatGroup.Location = new System.Drawing.Point(3, 144);
            this.timeFormatGroup.Name = "timeFormatGroup";
            this.timeFormatGroup.Size = new System.Drawing.Size(426, 50);
            this.timeFormatGroup.TabIndex = 4;
            this.timeFormatGroup.TabStop = false;
            this.timeFormatGroup.Text = "Time Format";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rdoTimeFormatSeconds, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rdoTimeFormatTime, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(283, 24);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rdoTimeFormatSeconds
            // 
            this.rdoTimeFormatSeconds.AutoSize = true;
            this.rdoTimeFormatSeconds.Location = new System.Drawing.Point(3, 3);
            this.rdoTimeFormatSeconds.Name = "rdoTimeFormatSeconds";
            this.rdoTimeFormatSeconds.Size = new System.Drawing.Size(117, 17);
            this.rdoTimeFormatSeconds.TabIndex = 0;
            this.rdoTimeFormatSeconds.TabStop = true;
            this.rdoTimeFormatSeconds.Text = "Only show seconds";
            this.rdoTimeFormatSeconds.UseVisualStyleBackColor = true;
            this.rdoTimeFormatSeconds.CheckedChanged += new System.EventHandler(this.rdoTimeFormatSeconds_CheckedChanged_1);
            // 
            // rdoTimeFormatTime
            // 
            this.rdoTimeFormatTime.AutoSize = true;
            this.rdoTimeFormatTime.Location = new System.Drawing.Point(144, 3);
            this.rdoTimeFormatTime.Name = "rdoTimeFormatTime";
            this.rdoTimeFormatTime.Size = new System.Drawing.Size(113, 17);
            this.rdoTimeFormatTime.TabIndex = 1;
            this.rdoTimeFormatTime.TabStop = true;
            this.rdoTimeFormatTime.Text = "Use hh:mm:ss time";
            this.rdoTimeFormatTime.UseVisualStyleBackColor = true;
            this.rdoTimeFormatTime.CheckedChanged += new System.EventHandler(this.rdoTimeFormatTime_CheckedChanged_1);
            // 
            // StandardDeviationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.topLevelLayoutPanel);
            this.Name = "StandardDeviationSettings";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(484, 552);
            this.Load += new System.EventHandler(this.StandardDeviationSettings_Load);
            this.topLevelLayoutPanel.ResumeLayout(false);
            this.topLevelLayoutPanel.PerformLayout();
            this.mainGroup.ResumeLayout(false);
            this.mainGroup.PerformLayout();
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.decimalGroup.ResumeLayout(false);
            this.decimalGroup.PerformLayout();
            this.decimalLayout.ResumeLayout(false);
            this.decimalLayout.PerformLayout();
            this.currentGroup.ResumeLayout(false);
            this.currentGroup.PerformLayout();
            this.currentLayout.ResumeLayout(false);
            this.currentLayout.PerformLayout();
            this.previousGroup.ResumeLayout(false);
            this.previousGroup.PerformLayout();
            this.previousLayout.ResumeLayout(false);
            this.previousLayout.PerformLayout();
            this.timeFormatGroup.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel topLevelLayoutPanel;
        private System.Windows.Forms.GroupBox mainGroup;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.CheckBox chkShowCurrent;
        private System.Windows.Forms.CheckBox chkShowPrevious;
        private System.Windows.Forms.CheckBox chkDisplay2Rows;
        private System.Windows.Forms.GroupBox decimalGroup;
        private System.Windows.Forms.TableLayoutPanel decimalLayout;
        private System.Windows.Forms.RadioButton rdoDecimalWhole;
        private System.Windows.Forms.RadioButton rdoDecimalTenths;
        private System.Windows.Forms.RadioButton rdoDecimalHundredths;
        private System.Windows.Forms.GroupBox currentGroup;
        private System.Windows.Forms.TableLayoutPanel currentLayout;
        private System.Windows.Forms.CheckBox chkCurrentSigma;
        private System.Windows.Forms.CheckBox chkCurrentAverage;
        private System.Windows.Forms.CheckBox chkCurrentCount;
        private System.Windows.Forms.GroupBox previousGroup;
        private System.Windows.Forms.TableLayoutPanel previousLayout;
        private System.Windows.Forms.CheckBox chkPreviousSigma;
        private System.Windows.Forms.CheckBox chkPreviousAverage;
        private System.Windows.Forms.CheckBox chkPreviousCount;
        private System.Windows.Forms.GroupBox timeFormatGroup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton rdoTimeFormatSeconds;
        private System.Windows.Forms.RadioButton rdoTimeFormatTime;
    }
}
