using System.Collections.Specialized;

namespace Emmetienne.SolutionReplicator
{
    partial class SolutionReplicatorControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolutionReplicatorControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbLoadSolution = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSecondEnvinronment = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.solutionGridView = new System.Windows.Forms.DataGridView();
            this.componentsAndOptionsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.solutionComponentDataGridView = new System.Windows.Forms.DataGridView();
            this.targetSolutionGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.solutionNameTextBox = new System.Windows.Forms.TextBox();
            this.solutionNameLabel = new System.Windows.Forms.Label();
            this.publisherLabel = new System.Windows.Forms.Label();
            this.publisherComboBox = new System.Windows.Forms.ComboBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.versionTextBox = new System.Windows.Forms.TextBox();
            this.pruneComponentcheckBox = new System.Windows.Forms.CheckBox();
            this.replicateSolutionButton = new System.Windows.Forms.Button();
            this.splitContainerLayout = new System.Windows.Forms.SplitContainer();
            this.logGroupBox = new System.Windows.Forms.GroupBox();
            this.logDataGridView = new System.Windows.Forms.DataGridView();
            this.timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exception = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.severity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solutionGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentsAndOptionsSplitContainer)).BeginInit();
            this.componentsAndOptionsSplitContainer.Panel1.SuspendLayout();
            this.componentsAndOptionsSplitContainer.Panel2.SuspendLayout();
            this.componentsAndOptionsSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solutionComponentDataGridView)).BeginInit();
            this.targetSolutionGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLayout)).BeginInit();
            this.splitContainerLayout.Panel1.SuspendLayout();
            this.splitContainerLayout.Panel2.SuspendLayout();
            this.splitContainerLayout.SuspendLayout();
            this.logGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoadSolution,
            this.tssSeparator1,
            this.tsbSecondEnvinronment});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1025, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbLoadSolution
            // 
            this.tsbLoadSolution.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbLoadSolution.Name = "tsbLoadSolution";
            this.tsbLoadSolution.Size = new System.Drawing.Size(179, 22);
            this.tsbLoadSolution.Text = "Connect to source environment";
            this.tsbLoadSolution.Click += new System.EventHandler(this.tsbLoadSolution_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSecondEnvinronment
            // 
            this.tsbSecondEnvinronment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSecondEnvinronment.Image = ((System.Drawing.Image)(resources.GetObject("tsbSecondEnvinronment.Image")));
            this.tsbSecondEnvinronment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSecondEnvinronment.Name = "tsbSecondEnvinronment";
            this.tsbSecondEnvinronment.Size = new System.Drawing.Size(175, 22);
            this.tsbSecondEnvinronment.Text = "Connect to target environment";
            this.tsbSecondEnvinronment.Click += new System.EventHandler(this.tsbSecondEnvinronment_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.CausesValidation = false;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.solutionGridView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer.Panel2.Controls.Add(this.componentsAndOptionsSplitContainer);
            this.splitContainer.Size = new System.Drawing.Size(1025, 502);
            this.splitContainer.SplitterDistance = 422;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 5;
            // 
            // solutionGridView
            // 
            this.solutionGridView.AllowUserToAddRows = false;
            this.solutionGridView.AllowUserToDeleteRows = false;
            this.solutionGridView.AllowUserToOrderColumns = true;
            this.solutionGridView.AllowUserToResizeRows = false;
            this.solutionGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.solutionGridView.BackgroundColor = System.Drawing.Color.White;
            this.solutionGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.solutionGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.solutionGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.solutionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.solutionGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solutionGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.solutionGridView.Location = new System.Drawing.Point(0, 0);
            this.solutionGridView.MultiSelect = false;
            this.solutionGridView.Name = "solutionGridView";
            this.solutionGridView.ReadOnly = true;
            this.solutionGridView.RowHeadersVisible = false;
            this.solutionGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.solutionGridView.ShowCellErrors = false;
            this.solutionGridView.ShowCellToolTips = false;
            this.solutionGridView.ShowEditingIcon = false;
            this.solutionGridView.ShowRowErrors = false;
            this.solutionGridView.Size = new System.Drawing.Size(422, 502);
            this.solutionGridView.TabIndex = 0;
            // 
            // componentsAndOptionsSplitContainer
            // 
            this.componentsAndOptionsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.componentsAndOptionsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.componentsAndOptionsSplitContainer.Name = "componentsAndOptionsSplitContainer";
            // 
            // componentsAndOptionsSplitContainer.Panel1
            // 
            this.componentsAndOptionsSplitContainer.Panel1.Controls.Add(this.solutionComponentDataGridView);
            // 
            // componentsAndOptionsSplitContainer.Panel2
            // 
            this.componentsAndOptionsSplitContainer.Panel2.Controls.Add(this.targetSolutionGroupBox);
            this.componentsAndOptionsSplitContainer.Size = new System.Drawing.Size(598, 502);
            this.componentsAndOptionsSplitContainer.SplitterDistance = 336;
            this.componentsAndOptionsSplitContainer.TabIndex = 1;
            // 
            // solutionComponentDataGridView
            // 
            this.solutionComponentDataGridView.AllowUserToAddRows = false;
            this.solutionComponentDataGridView.AllowUserToDeleteRows = false;
            this.solutionComponentDataGridView.AllowUserToResizeRows = false;
            this.solutionComponentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.solutionComponentDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.solutionComponentDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.solutionComponentDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.solutionComponentDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.solutionComponentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.solutionComponentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solutionComponentDataGridView.Location = new System.Drawing.Point(0, 0);
            this.solutionComponentDataGridView.Name = "solutionComponentDataGridView";
            this.solutionComponentDataGridView.ReadOnly = true;
            this.solutionComponentDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.solutionComponentDataGridView.RowHeadersVisible = false;
            this.solutionComponentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.solutionComponentDataGridView.Size = new System.Drawing.Size(336, 502);
            this.solutionComponentDataGridView.TabIndex = 0;
            // 
            // targetSolutionGroupBox
            // 
            this.targetSolutionGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.targetSolutionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetSolutionGroupBox.Location = new System.Drawing.Point(0, 0);
            this.targetSolutionGroupBox.Name = "targetSolutionGroupBox";
            this.targetSolutionGroupBox.Size = new System.Drawing.Size(258, 502);
            this.targetSolutionGroupBox.TabIndex = 0;
            this.targetSolutionGroupBox.TabStop = false;
            this.targetSolutionGroupBox.Text = "Target solution settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 252F));
            this.tableLayoutPanel1.Controls.Add(this.solutionNameTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.solutionNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.publisherLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.publisherComboBox, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.versionLabel, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.versionTextBox, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.pruneComponentcheckBox, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.replicateSolutionButton, 0, 12);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(252, 483);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // solutionNameTextBox
            // 
            this.solutionNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solutionNameTextBox.Location = new System.Drawing.Point(3, 16);
            this.solutionNameTextBox.Name = "solutionNameTextBox";
            this.solutionNameTextBox.Size = new System.Drawing.Size(246, 20);
            this.solutionNameTextBox.TabIndex = 1;
            // 
            // solutionNameLabel
            // 
            this.solutionNameLabel.AutoSize = true;
            this.solutionNameLabel.Location = new System.Drawing.Point(3, 0);
            this.solutionNameLabel.Name = "solutionNameLabel";
            this.solutionNameLabel.Size = new System.Drawing.Size(74, 13);
            this.solutionNameLabel.TabIndex = 0;
            this.solutionNameLabel.Text = "Solution name";
            // 
            // publisherLabel
            // 
            this.publisherLabel.AutoSize = true;
            this.publisherLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.publisherLabel.Location = new System.Drawing.Point(3, 39);
            this.publisherLabel.Name = "publisherLabel";
            this.publisherLabel.Size = new System.Drawing.Size(246, 13);
            this.publisherLabel.TabIndex = 2;
            this.publisherLabel.Text = "Publisher";
            // 
            // publisherComboBox
            // 
            this.publisherComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.publisherComboBox.FormattingEnabled = true;
            this.publisherComboBox.Location = new System.Drawing.Point(3, 55);
            this.publisherComboBox.Name = "publisherComboBox";
            this.publisherComboBox.Size = new System.Drawing.Size(246, 21);
            this.publisherComboBox.TabIndex = 7;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionLabel.Location = new System.Drawing.Point(3, 79);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(246, 13);
            this.versionLabel.TabIndex = 3;
            this.versionLabel.Text = "Version";
            // 
            // versionTextBox
            // 
            this.versionTextBox.Location = new System.Drawing.Point(3, 95);
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.Size = new System.Drawing.Size(207, 20);
            this.versionTextBox.TabIndex = 4;
            this.versionTextBox.Text = "1.0.0.0";
            // 
            // pruneComponentcheckBox
            // 
            this.pruneComponentcheckBox.AutoSize = true;
            this.pruneComponentcheckBox.Enabled = false;
            this.pruneComponentcheckBox.Location = new System.Drawing.Point(3, 121);
            this.pruneComponentcheckBox.Name = "pruneComponentcheckBox";
            this.pruneComponentcheckBox.Size = new System.Drawing.Size(172, 17);
            this.pruneComponentcheckBox.TabIndex = 5;
            this.pruneComponentcheckBox.Text = "Prune auto-added components";
            this.pruneComponentcheckBox.UseVisualStyleBackColor = true;
            // 
            // replicateSolutionButton
            // 
            this.replicateSolutionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.replicateSolutionButton.Location = new System.Drawing.Point(3, 144);
            this.replicateSolutionButton.Name = "replicateSolutionButton";
            this.replicateSolutionButton.Size = new System.Drawing.Size(246, 44);
            this.replicateSolutionButton.TabIndex = 6;
            this.replicateSolutionButton.Text = "Replicate solution";
            this.replicateSolutionButton.UseVisualStyleBackColor = true;
            this.replicateSolutionButton.Click += new System.EventHandler(this.replicateSolutionButton_Click);
            // 
            // splitContainerLayout
            // 
            this.splitContainerLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLayout.Location = new System.Drawing.Point(0, 25);
            this.splitContainerLayout.Name = "splitContainerLayout";
            this.splitContainerLayout.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLayout.Panel1
            // 
            this.splitContainerLayout.Panel1.Controls.Add(this.splitContainer);
            // 
            // splitContainerLayout.Panel2
            // 
            this.splitContainerLayout.Panel2.Controls.Add(this.logGroupBox);
            this.splitContainerLayout.Size = new System.Drawing.Size(1025, 660);
            this.splitContainerLayout.SplitterDistance = 502;
            this.splitContainerLayout.TabIndex = 6;
            // 
            // logGroupBox
            // 
            this.logGroupBox.AutoSize = true;
            this.logGroupBox.BackColor = System.Drawing.Color.White;
            this.logGroupBox.Controls.Add(this.logDataGridView);
            this.logGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logGroupBox.Location = new System.Drawing.Point(0, 0);
            this.logGroupBox.Name = "logGroupBox";
            this.logGroupBox.Size = new System.Drawing.Size(1025, 154);
            this.logGroupBox.TabIndex = 0;
            this.logGroupBox.TabStop = false;
            this.logGroupBox.Text = "Logs";
            // 
            // logDataGridView
            // 
            this.logDataGridView.AllowUserToAddRows = false;
            this.logDataGridView.AllowUserToDeleteRows = false;
            this.logDataGridView.AllowUserToResizeRows = false;
            this.logDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.logDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.logDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logDataGridView.CausesValidation = false;
            this.logDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.logDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.logDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timestamp,
            this.message,
            this.exception,
            this.severity});
            this.logDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logDataGridView.GridColor = System.Drawing.Color.White;
            this.logDataGridView.Location = new System.Drawing.Point(3, 16);
            this.logDataGridView.Name = "logDataGridView";
            this.logDataGridView.ReadOnly = true;
            this.logDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.logDataGridView.RowHeadersVisible = false;
            this.logDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.logDataGridView.Size = new System.Drawing.Size(1019, 135);
            this.logDataGridView.TabIndex = 0;
            // 
            // timestamp
            // 
            this.timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.timestamp.HeaderText = "Timestamp";
            this.timestamp.Name = "timestamp";
            this.timestamp.ReadOnly = true;
            this.timestamp.Width = 120;
            // 
            // message
            // 
            this.message.HeaderText = "Message";
            this.message.Name = "message";
            this.message.ReadOnly = true;
            // 
            // exception
            // 
            this.exception.HeaderText = "Exception";
            this.exception.Name = "exception";
            this.exception.ReadOnly = true;
            // 
            // severity
            // 
            this.severity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.severity.HeaderText = "Severity";
            this.severity.Name = "severity";
            this.severity.ReadOnly = true;
            this.severity.Width = 70;
            // 
            // SolutionReplicatorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerLayout);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "SolutionReplicatorControl";
            this.Size = new System.Drawing.Size(1025, 685);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.solutionGridView)).EndInit();
            this.componentsAndOptionsSplitContainer.Panel1.ResumeLayout(false);
            this.componentsAndOptionsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.componentsAndOptionsSplitContainer)).EndInit();
            this.componentsAndOptionsSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.solutionComponentDataGridView)).EndInit();
            this.targetSolutionGroupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainerLayout.Panel1.ResumeLayout(false);
            this.splitContainerLayout.Panel2.ResumeLayout(false);
            this.splitContainerLayout.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLayout)).EndInit();
            this.splitContainerLayout.ResumeLayout(false);
            this.logGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void ConnectionDetailsUpdated(NotifyCollectionChangedEventArgs e)
        {
            // sistemare che non ho capito che fa
            return;
        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbLoadSolution;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView solutionGridView;
        private System.Windows.Forms.SplitContainer splitContainerLayout;
        private System.Windows.Forms.GroupBox logGroupBox;
        private System.Windows.Forms.DataGridView solutionComponentDataGridView;
        private System.Windows.Forms.SplitContainer componentsAndOptionsSplitContainer;
        private System.Windows.Forms.GroupBox targetSolutionGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label solutionNameLabel;
        private System.Windows.Forms.TextBox solutionNameTextBox;
        private System.Windows.Forms.Label publisherLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.TextBox versionTextBox;
        private System.Windows.Forms.DataGridView logDataGridView;
        private System.Windows.Forms.CheckBox pruneComponentcheckBox;
        private System.Windows.Forms.Button replicateSolutionButton;
        private System.Windows.Forms.ComboBox publisherComboBox;
        private System.Windows.Forms.ToolStripButton tsbSecondEnvinronment;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn message;
        private System.Windows.Forms.DataGridViewTextBoxColumn exception;
        private System.Windows.Forms.DataGridViewTextBoxColumn severity;
    }
}
