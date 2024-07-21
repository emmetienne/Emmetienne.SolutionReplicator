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
            this.sourceSolutionGroupBox = new System.Windows.Forms.GroupBox();
            this.solutionTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.solutionGridView = new System.Windows.Forms.DataGridView();
            this.solutionFilterTableLayou = new System.Windows.Forms.TableLayoutPanel();
            this.solutionFilterTextBox = new System.Windows.Forms.TextBox();
            this.componentsAndOptionsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.sourceSolutionComponentsGroupBox = new System.Windows.Forms.GroupBox();
            this.solutionComponentDataGridView = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.targetSolutionGroupBox = new System.Windows.Forms.GroupBox();
            this.targetSolutionSettingsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.solutionNameTextBox = new System.Windows.Forms.TextBox();
            this.solutionNameLabel = new System.Windows.Forms.Label();
            this.publisherLabel = new System.Windows.Forms.Label();
            this.publisherComboBox = new System.Windows.Forms.ComboBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.versionTextBox = new System.Windows.Forms.TextBox();
            this.replicateSolutionButton = new System.Windows.Forms.Button();
            this.solutionExportGroupBox = new System.Windows.Forms.GroupBox();
            this.exportTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.exportFolderLabel = new System.Windows.Forms.Label();
            this.exportSourceSolutionButton = new System.Windows.Forms.Button();
            this.exportPathTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.exportPathTextBox = new System.Windows.Forms.TextBox();
            this.openFolderSelectionButton = new System.Windows.Forms.Button();
            this.targetSolutionExportAndOpenTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.openTargetSolutionButton = new System.Windows.Forms.Button();
            this.exportTargetSolutionButton = new System.Windows.Forms.Button();
            this.splitContainerLayout = new System.Windows.Forms.SplitContainer();
            this.logGroupBox = new System.Windows.Forms.GroupBox();
            this.logDataGridView = new System.Windows.Forms.DataGridView();
            this.timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exception = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.severity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.showManagedCheckBox = new System.Windows.Forms.CheckBox();
            this.filterNameSolution = new System.Windows.Forms.Label();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.sourceSolutionGroupBox.SuspendLayout();
            this.solutionTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solutionGridView)).BeginInit();
            this.solutionFilterTableLayou.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.componentsAndOptionsSplitContainer)).BeginInit();
            this.componentsAndOptionsSplitContainer.Panel1.SuspendLayout();
            this.componentsAndOptionsSplitContainer.Panel2.SuspendLayout();
            this.componentsAndOptionsSplitContainer.SuspendLayout();
            this.sourceSolutionComponentsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.solutionComponentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.targetSolutionGroupBox.SuspendLayout();
            this.targetSolutionSettingsTableLayout.SuspendLayout();
            this.solutionExportGroupBox.SuspendLayout();
            this.exportTableLayout.SuspendLayout();
            this.exportPathTableLayoutPanel.SuspendLayout();
            this.targetSolutionExportAndOpenTableLayout.SuspendLayout();
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
            this.splitContainer.Panel1.Controls.Add(this.sourceSolutionGroupBox);
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
            // sourceSolutionGroupBox
            // 
            this.sourceSolutionGroupBox.BackColor = System.Drawing.Color.White;
            this.sourceSolutionGroupBox.Controls.Add(this.solutionTableLayout);
            this.sourceSolutionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceSolutionGroupBox.Location = new System.Drawing.Point(0, 0);
            this.sourceSolutionGroupBox.Name = "sourceSolutionGroupBox";
            this.sourceSolutionGroupBox.Size = new System.Drawing.Size(422, 502);
            this.sourceSolutionGroupBox.TabIndex = 2;
            this.sourceSolutionGroupBox.TabStop = false;
            this.sourceSolutionGroupBox.Text = "Source solution";
            // 
            // solutionTableLayout
            // 
            this.solutionTableLayout.ColumnCount = 1;
            this.solutionTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.solutionTableLayout.Controls.Add(this.solutionGridView, 0, 1);
            this.solutionTableLayout.Controls.Add(this.solutionFilterTableLayou, 0, 0);
            this.solutionTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solutionTableLayout.Location = new System.Drawing.Point(3, 16);
            this.solutionTableLayout.Name = "solutionTableLayout";
            this.solutionTableLayout.RowCount = 2;
            this.solutionTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.solutionTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.solutionTableLayout.Size = new System.Drawing.Size(416, 483);
            this.solutionTableLayout.TabIndex = 1;
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
            this.solutionGridView.Location = new System.Drawing.Point(3, 33);
            this.solutionGridView.MultiSelect = false;
            this.solutionGridView.Name = "solutionGridView";
            this.solutionGridView.ReadOnly = true;
            this.solutionGridView.RowHeadersVisible = false;
            this.solutionGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.solutionGridView.ShowCellErrors = false;
            this.solutionGridView.ShowCellToolTips = false;
            this.solutionGridView.ShowEditingIcon = false;
            this.solutionGridView.ShowRowErrors = false;
            this.solutionGridView.Size = new System.Drawing.Size(410, 457);
            this.solutionGridView.TabIndex = 0;
            // 
            // solutionFilterTableLayou
            // 
            this.solutionFilterTableLayou.ColumnCount = 3;
            this.solutionFilterTableLayou.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.solutionFilterTableLayou.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.solutionFilterTableLayou.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.solutionFilterTableLayou.Controls.Add(this.solutionFilterTextBox, 1, 0);
            this.solutionFilterTableLayou.Controls.Add(this.showManagedCheckBox, 2, 0);
            this.solutionFilterTableLayou.Controls.Add(this.filterNameSolution, 0, 0);
            this.solutionFilterTableLayou.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solutionFilterTableLayou.Location = new System.Drawing.Point(3, 3);
            this.solutionFilterTableLayou.Name = "solutionFilterTableLayou";
            this.solutionFilterTableLayou.RowCount = 1;
            this.solutionFilterTableLayou.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.solutionFilterTableLayou.Size = new System.Drawing.Size(410, 24);
            this.solutionFilterTableLayou.TabIndex = 2;
            // 
            // solutionFilterTextBox
            // 
            this.solutionFilterTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solutionFilterTextBox.Location = new System.Drawing.Point(43, 3);
            this.solutionFilterTextBox.Name = "solutionFilterTextBox";
            this.solutionFilterTextBox.Size = new System.Drawing.Size(249, 20);
            this.solutionFilterTextBox.TabIndex = 1;
            // 
            // componentsAndOptionsSplitContainer
            // 
            this.componentsAndOptionsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.componentsAndOptionsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.componentsAndOptionsSplitContainer.Name = "componentsAndOptionsSplitContainer";
            // 
            // componentsAndOptionsSplitContainer.Panel1
            // 
            this.componentsAndOptionsSplitContainer.Panel1.Controls.Add(this.sourceSolutionComponentsGroupBox);
            // 
            // componentsAndOptionsSplitContainer.Panel2
            // 
            this.componentsAndOptionsSplitContainer.Panel2.Controls.Add(this.splitContainer1);
            this.componentsAndOptionsSplitContainer.Size = new System.Drawing.Size(598, 502);
            this.componentsAndOptionsSplitContainer.SplitterDistance = 336;
            this.componentsAndOptionsSplitContainer.TabIndex = 1;
            // 
            // sourceSolutionComponentsGroupBox
            // 
            this.sourceSolutionComponentsGroupBox.Controls.Add(this.solutionComponentDataGridView);
            this.sourceSolutionComponentsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceSolutionComponentsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.sourceSolutionComponentsGroupBox.Name = "sourceSolutionComponentsGroupBox";
            this.sourceSolutionComponentsGroupBox.Size = new System.Drawing.Size(336, 502);
            this.sourceSolutionComponentsGroupBox.TabIndex = 1;
            this.sourceSolutionComponentsGroupBox.TabStop = false;
            this.sourceSolutionComponentsGroupBox.Text = "Source solution components";
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
            this.solutionComponentDataGridView.Location = new System.Drawing.Point(3, 16);
            this.solutionComponentDataGridView.Name = "solutionComponentDataGridView";
            this.solutionComponentDataGridView.ReadOnly = true;
            this.solutionComponentDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.solutionComponentDataGridView.RowHeadersVisible = false;
            this.solutionComponentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.solutionComponentDataGridView.Size = new System.Drawing.Size(330, 483);
            this.solutionComponentDataGridView.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.targetSolutionGroupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.solutionExportGroupBox);
            this.splitContainer1.Size = new System.Drawing.Size(258, 502);
            this.splitContainer1.SplitterDistance = 192;
            this.splitContainer1.TabIndex = 1;
            // 
            // targetSolutionGroupBox
            // 
            this.targetSolutionGroupBox.Controls.Add(this.targetSolutionSettingsTableLayout);
            this.targetSolutionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetSolutionGroupBox.Location = new System.Drawing.Point(0, 0);
            this.targetSolutionGroupBox.Name = "targetSolutionGroupBox";
            this.targetSolutionGroupBox.Size = new System.Drawing.Size(258, 192);
            this.targetSolutionGroupBox.TabIndex = 0;
            this.targetSolutionGroupBox.TabStop = false;
            this.targetSolutionGroupBox.Text = "Target solution settings";
            // 
            // targetSolutionSettingsTableLayout
            // 
            this.targetSolutionSettingsTableLayout.ColumnCount = 1;
            this.targetSolutionSettingsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 252F));
            this.targetSolutionSettingsTableLayout.Controls.Add(this.solutionNameTextBox, 0, 1);
            this.targetSolutionSettingsTableLayout.Controls.Add(this.solutionNameLabel, 0, 0);
            this.targetSolutionSettingsTableLayout.Controls.Add(this.publisherLabel, 0, 2);
            this.targetSolutionSettingsTableLayout.Controls.Add(this.publisherComboBox, 0, 8);
            this.targetSolutionSettingsTableLayout.Controls.Add(this.versionLabel, 0, 9);
            this.targetSolutionSettingsTableLayout.Controls.Add(this.versionTextBox, 0, 10);
            this.targetSolutionSettingsTableLayout.Controls.Add(this.replicateSolutionButton, 0, 12);
            this.targetSolutionSettingsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetSolutionSettingsTableLayout.Location = new System.Drawing.Point(3, 16);
            this.targetSolutionSettingsTableLayout.Name = "targetSolutionSettingsTableLayout";
            this.targetSolutionSettingsTableLayout.RowCount = 22;
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.targetSolutionSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.targetSolutionSettingsTableLayout.Size = new System.Drawing.Size(252, 173);
            this.targetSolutionSettingsTableLayout.TabIndex = 0;
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
            this.versionTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionTextBox.Location = new System.Drawing.Point(3, 95);
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.Size = new System.Drawing.Size(246, 20);
            this.versionTextBox.TabIndex = 4;
            this.versionTextBox.Text = "1.0.0.0";
            // 
            // replicateSolutionButton
            // 
            this.replicateSolutionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.replicateSolutionButton.Location = new System.Drawing.Point(3, 121);
            this.replicateSolutionButton.Name = "replicateSolutionButton";
            this.replicateSolutionButton.Size = new System.Drawing.Size(246, 44);
            this.replicateSolutionButton.TabIndex = 6;
            this.replicateSolutionButton.Text = "Replicate solution";
            this.replicateSolutionButton.UseVisualStyleBackColor = true;
            this.replicateSolutionButton.Click += new System.EventHandler(this.OnReplicateSolutionButtonClick);
            // 
            // solutionExportGroupBox
            // 
            this.solutionExportGroupBox.Controls.Add(this.exportTableLayout);
            this.solutionExportGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solutionExportGroupBox.Location = new System.Drawing.Point(0, 0);
            this.solutionExportGroupBox.Name = "solutionExportGroupBox";
            this.solutionExportGroupBox.Size = new System.Drawing.Size(258, 306);
            this.solutionExportGroupBox.TabIndex = 1;
            this.solutionExportGroupBox.TabStop = false;
            this.solutionExportGroupBox.Text = "Solution export settings";
            // 
            // exportTableLayout
            // 
            this.exportTableLayout.ColumnCount = 1;
            this.exportTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.exportTableLayout.Controls.Add(this.exportFolderLabel, 0, 0);
            this.exportTableLayout.Controls.Add(this.exportSourceSolutionButton, 0, 2);
            this.exportTableLayout.Controls.Add(this.exportPathTableLayoutPanel, 0, 1);
            this.exportTableLayout.Controls.Add(this.targetSolutionExportAndOpenTableLayout, 0, 3);
            this.exportTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportTableLayout.Location = new System.Drawing.Point(3, 16);
            this.exportTableLayout.Name = "exportTableLayout";
            this.exportTableLayout.RowCount = 5;
            this.exportTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.exportTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.exportTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.exportTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.exportTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.exportTableLayout.Size = new System.Drawing.Size(252, 287);
            this.exportTableLayout.TabIndex = 0;
            // 
            // exportFolderLabel
            // 
            this.exportFolderLabel.AutoSize = true;
            this.exportFolderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportFolderLabel.Location = new System.Drawing.Point(3, 0);
            this.exportFolderLabel.Name = "exportFolderLabel";
            this.exportFolderLabel.Size = new System.Drawing.Size(246, 20);
            this.exportFolderLabel.TabIndex = 8;
            this.exportFolderLabel.Text = "Folder";
            // 
            // exportSourceSolutionButton
            // 
            this.exportSourceSolutionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportSourceSolutionButton.Location = new System.Drawing.Point(3, 50);
            this.exportSourceSolutionButton.Name = "exportSourceSolutionButton";
            this.exportSourceSolutionButton.Size = new System.Drawing.Size(246, 29);
            this.exportSourceSolutionButton.TabIndex = 9;
            this.exportSourceSolutionButton.Text = "Download source solution";
            this.exportSourceSolutionButton.UseVisualStyleBackColor = true;
            // 
            // exportPathTableLayoutPanel
            // 
            this.exportPathTableLayoutPanel.ColumnCount = 2;
            this.exportPathTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.42857F));
            this.exportPathTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.exportPathTableLayoutPanel.Controls.Add(this.exportPathTextBox, 0, 0);
            this.exportPathTableLayoutPanel.Controls.Add(this.openFolderSelectionButton, 1, 0);
            this.exportPathTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportPathTableLayoutPanel.Location = new System.Drawing.Point(0, 20);
            this.exportPathTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.exportPathTableLayoutPanel.Name = "exportPathTableLayoutPanel";
            this.exportPathTableLayoutPanel.RowCount = 1;
            this.exportPathTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.exportPathTableLayoutPanel.Size = new System.Drawing.Size(252, 27);
            this.exportPathTableLayoutPanel.TabIndex = 11;
            // 
            // exportPathTextBox
            // 
            this.exportPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportPathTextBox.Location = new System.Drawing.Point(3, 3);
            this.exportPathTextBox.Name = "exportPathTextBox";
            this.exportPathTextBox.Size = new System.Drawing.Size(174, 20);
            this.exportPathTextBox.TabIndex = 0;
            // 
            // openFolderSelectionButton
            // 
            this.openFolderSelectionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openFolderSelectionButton.Location = new System.Drawing.Point(183, 3);
            this.openFolderSelectionButton.Name = "openFolderSelectionButton";
            this.openFolderSelectionButton.Size = new System.Drawing.Size(66, 21);
            this.openFolderSelectionButton.TabIndex = 1;
            this.openFolderSelectionButton.Text = "...";
            this.openFolderSelectionButton.UseVisualStyleBackColor = true;
            // 
            // targetSolutionExportAndOpenTableLayout
            // 
            this.targetSolutionExportAndOpenTableLayout.ColumnCount = 2;
            this.targetSolutionExportAndOpenTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.targetSolutionExportAndOpenTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.targetSolutionExportAndOpenTableLayout.Controls.Add(this.openTargetSolutionButton, 1, 0);
            this.targetSolutionExportAndOpenTableLayout.Controls.Add(this.exportTargetSolutionButton, 0, 0);
            this.targetSolutionExportAndOpenTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetSolutionExportAndOpenTableLayout.Location = new System.Drawing.Point(3, 85);
            this.targetSolutionExportAndOpenTableLayout.Name = "targetSolutionExportAndOpenTableLayout";
            this.targetSolutionExportAndOpenTableLayout.RowCount = 1;
            this.targetSolutionExportAndOpenTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.targetSolutionExportAndOpenTableLayout.Size = new System.Drawing.Size(246, 39);
            this.targetSolutionExportAndOpenTableLayout.TabIndex = 12;
            // 
            // openTargetSolutionButton
            // 
            this.openTargetSolutionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openTargetSolutionButton.Location = new System.Drawing.Point(175, 3);
            this.openTargetSolutionButton.Name = "openTargetSolutionButton";
            this.openTargetSolutionButton.Size = new System.Drawing.Size(68, 33);
            this.openTargetSolutionButton.TabIndex = 11;
            this.openTargetSolutionButton.Text = "Open target solution";
            this.openTargetSolutionButton.UseVisualStyleBackColor = true;
            // 
            // exportTargetSolutionButton
            // 
            this.exportTargetSolutionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportTargetSolutionButton.Location = new System.Drawing.Point(3, 3);
            this.exportTargetSolutionButton.Name = "exportTargetSolutionButton";
            this.exportTargetSolutionButton.Size = new System.Drawing.Size(166, 33);
            this.exportTargetSolutionButton.TabIndex = 10;
            this.exportTargetSolutionButton.Text = "Download target solution";
            this.exportTargetSolutionButton.UseVisualStyleBackColor = true;
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
            // showManagedCheckBox
            // 
            this.showManagedCheckBox.AutoSize = true;
            this.showManagedCheckBox.Location = new System.Drawing.Point(298, 3);
            this.showManagedCheckBox.Name = "showManagedCheckBox";
            this.showManagedCheckBox.Size = new System.Drawing.Size(106, 17);
            this.showManagedCheckBox.TabIndex = 2;
            this.showManagedCheckBox.Text = "Show managed?";
            this.showManagedCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showManagedCheckBox.UseVisualStyleBackColor = true;
            // 
            // filterNameSolution
            // 
            this.filterNameSolution.AutoSize = true;
            this.filterNameSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterNameSolution.Location = new System.Drawing.Point(3, 0);
            this.filterNameSolution.Name = "filterNameSolution";
            this.filterNameSolution.Size = new System.Drawing.Size(34, 24);
            this.filterNameSolution.TabIndex = 3;
            this.filterNameSolution.Text = "Filter:";
            this.filterNameSolution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.sourceSolutionGroupBox.ResumeLayout(false);
            this.solutionTableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.solutionGridView)).EndInit();
            this.solutionFilterTableLayou.ResumeLayout(false);
            this.solutionFilterTableLayou.PerformLayout();
            this.componentsAndOptionsSplitContainer.Panel1.ResumeLayout(false);
            this.componentsAndOptionsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.componentsAndOptionsSplitContainer)).EndInit();
            this.componentsAndOptionsSplitContainer.ResumeLayout(false);
            this.sourceSolutionComponentsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.solutionComponentDataGridView)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.targetSolutionGroupBox.ResumeLayout(false);
            this.targetSolutionSettingsTableLayout.ResumeLayout(false);
            this.targetSolutionSettingsTableLayout.PerformLayout();
            this.solutionExportGroupBox.ResumeLayout(false);
            this.exportTableLayout.ResumeLayout(false);
            this.exportTableLayout.PerformLayout();
            this.exportPathTableLayoutPanel.ResumeLayout(false);
            this.exportPathTableLayoutPanel.PerformLayout();
            this.targetSolutionExportAndOpenTableLayout.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel targetSolutionSettingsTableLayout;
        private System.Windows.Forms.Label solutionNameLabel;
        private System.Windows.Forms.TextBox solutionNameTextBox;
        private System.Windows.Forms.Label publisherLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.TextBox versionTextBox;
        private System.Windows.Forms.DataGridView logDataGridView;
        private System.Windows.Forms.Button replicateSolutionButton;
        private System.Windows.Forms.ComboBox publisherComboBox;
        private System.Windows.Forms.ToolStripButton tsbSecondEnvinronment;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn message;
        private System.Windows.Forms.DataGridViewTextBoxColumn exception;
        private System.Windows.Forms.DataGridViewTextBoxColumn severity;
        private System.Windows.Forms.TableLayoutPanel solutionTableLayout;
        private System.Windows.Forms.TextBox solutionFilterTextBox;
        private System.Windows.Forms.GroupBox sourceSolutionComponentsGroupBox;
        private System.Windows.Forms.GroupBox sourceSolutionGroupBox;
        private System.Windows.Forms.Label exportFolderLabel;
        private System.Windows.Forms.Button exportSourceSolutionButton;
        private System.Windows.Forms.Button exportTargetSolutionButton;
        private System.Windows.Forms.TableLayoutPanel exportPathTableLayoutPanel;
        private System.Windows.Forms.TextBox exportPathTextBox;
        private System.Windows.Forms.Button openFolderSelectionButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox solutionExportGroupBox;
        private System.Windows.Forms.TableLayoutPanel exportTableLayout;
        private System.Windows.Forms.TableLayoutPanel targetSolutionExportAndOpenTableLayout;
        private System.Windows.Forms.Button openTargetSolutionButton;
        private System.Windows.Forms.TableLayoutPanel solutionFilterTableLayou;
        private System.Windows.Forms.CheckBox showManagedCheckBox;
        private System.Windows.Forms.Label filterNameSolution;
    }
}
