namespace CreateNewFileEx {
	partial class FormMain {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.labelFileName = new System.Windows.Forms.Label();
			this.textBoxFileName = new System.Windows.Forms.TextBox();
			this.buttonCreate = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSettings = new System.Windows.Forms.Button();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.contextMenuSetting = new System.Windows.Forms.ContextMenu();
			this.menuItemInstall = new System.Windows.Forms.MenuItem();
			this.menuItemUninstall = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// labelFileName
			// 
			this.labelFileName.AutoSize = true;
			this.labelFileName.Location = new System.Drawing.Point(10, 15);
			this.labelFileName.Name = "labelFileName";
			this.labelFileName.Size = new System.Drawing.Size(59, 12);
			this.labelFileName.TabIndex = 0;
			this.labelFileName.Text = "&File Name:";
			// 
			// textBoxFileName
			// 
			this.textBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxFileName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.textBoxFileName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.errorProvider.SetIconAlignment(this.textBoxFileName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
			this.textBoxFileName.Location = new System.Drawing.Point(86, 12);
			this.textBoxFileName.Name = "textBoxFileName";
			this.textBoxFileName.Size = new System.Drawing.Size(296, 19);
			this.textBoxFileName.TabIndex = 1;
			this.textBoxFileName.TextChanged += new System.EventHandler(this.textBoxFileName_TextChanged);
			// 
			// buttonCreate
			// 
			this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCreate.Enabled = false;
			this.buttonCreate.Location = new System.Drawing.Point(226, 38);
			this.buttonCreate.Name = "buttonCreate";
			this.buttonCreate.Size = new System.Drawing.Size(75, 23);
			this.buttonCreate.TabIndex = 2;
			this.buttonCreate.Text = "&Create";
			this.buttonCreate.UseVisualStyleBackColor = true;
			this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(307, 38);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonSettings
			// 
			this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonSettings.Location = new System.Drawing.Point(12, 38);
			this.buttonSettings.Name = "buttonSettings";
			this.buttonSettings.Size = new System.Drawing.Size(75, 23);
			this.buttonSettings.TabIndex = 4;
			this.buttonSettings.Text = "&Settings...";
			this.buttonSettings.UseVisualStyleBackColor = true;
			this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// contextMenuSetting
			// 
			this.contextMenuSetting.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemInstall,
            this.menuItemUninstall});
			this.contextMenuSetting.Popup += new System.EventHandler(this.contextMenuSetting_Popup);
			// 
			// menuItemInstall
			// 
			this.menuItemInstall.Index = 0;
			this.menuItemInstall.Text = "&Install";
			this.menuItemInstall.Click += new System.EventHandler(this.menuItemInstall_Click);
			// 
			// menuItemUninstall
			// 
			this.menuItemUninstall.Index = 1;
			this.menuItemUninstall.Text = "&Uninstall";
			this.menuItemUninstall.Click += new System.EventHandler(this.menuItemUninstall_Click);
			// 
			// FormMain
			// 
			this.AcceptButton = this.buttonCreate;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(394, 73);
			this.Controls.Add(this.buttonSettings);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonCreate);
			this.Controls.Add(this.textBoxFileName);
			this.Controls.Add(this.labelFileName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Create New File";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.FormMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelFileName;
		private System.Windows.Forms.TextBox textBoxFileName;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.Button buttonCreate;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSettings;
		private System.Windows.Forms.ContextMenu contextMenuSetting;
		private System.Windows.Forms.MenuItem menuItemInstall;
		private System.Windows.Forms.MenuItem menuItemUninstall;
	}
}

