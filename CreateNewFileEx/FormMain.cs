using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

namespace CreateNewFileEx {
	public partial class FormMain: Form {
		string dir = Environment.CurrentDirectory;
		List<char> invalidChars = new List<char>();

		public FormMain(string newfile) {
			InitializeComponent();
			//
			if(newfile != "") {
				var d = Path.GetDirectoryName(newfile);
				if(Directory.Exists(d)) {
					dir = d;
				}
				try {
					if(File.Exists(newfile)) {
						File.Delete(newfile);
					}
				}
				catch {
				}
			}
			//
			foreach(var c in Path.GetInvalidFileNameChars()) {
				if(invalidChars.Contains(c))
					continue;
				invalidChars.Add(c);
			}
			foreach(var c in Path.GetInvalidPathChars()) {
				if(invalidChars.Contains(c))
					continue;
				invalidChars.Add(c);
			}
		}

		private void buttonSettings_Click(object sender, EventArgs e) {
			contextMenuSetting.Show(buttonSettings, new Point(0, buttonSettings.Height));
		}

		private void contextMenuSetting_Popup(object sender, EventArgs e) {
			try {
				if(Registry.ClassesRoot.GetSubKeyNames().Contains(".createnewfileex")) {
					menuItemInstall.Enabled = false;
					menuItemUninstall.Enabled = true;
				}
				else {
					menuItemInstall.Enabled = true;
					menuItemUninstall.Enabled = false;
				}
			}
			catch {
				menuItemInstall.Enabled = false;
				menuItemUninstall.Enabled = false;
			}
		}

		string title = "Create New File";

		private void menuItemInstall_Click(object sender, EventArgs e) {
			install();
		}

		void install() {
			try {
				using(var ext = Registry.ClassesRoot.CreateSubKey(".createnewfileex")) {
					ext.SetValue("", "kobachi.CreateNewFileEx", RegistryValueKind.String);
					using(var shellnew = ext.CreateSubKey("ShellNew")) {
						shellnew.SetValue("Command", "\"" + Application.ExecutablePath + "\" \"%1\"");
						shellnew.SetValue("IconPath", "\"" + Application.ExecutablePath + "\",0");
					}
				}
				using(var filetype = Registry.ClassesRoot.CreateSubKey("kobachi.CreateNewFileEx")) {
					filetype.SetValue("", title, RegistryValueKind.String);
					filetype.SetValue("NeverShowExt", "");
					using(var icon = filetype.CreateSubKey("DefaultIcon")) {
						icon.SetValue("", "\"" + Application.ExecutablePath + "\",0");
					}
					using(var shell_open_command = filetype.CreateSubKey(@"shell\open\command")) {
						shell_open_command.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"");
					}
				}
				MessageBox.Show(this, installCompleteMessage, installCompleteTitle, MessageBoxButtons.OK);
			}
			catch {
				uninstall();
			}
		}

		private void menuItemUninstall_Click(object sender, EventArgs e) {
			uninstall();
		}

		void uninstall() {
			try {
				Registry.ClassesRoot.DeleteSubKeyTree(".createnewfileex");
			}
			catch {
			}
			try {
				Registry.ClassesRoot.DeleteSubKeyTree("kobachi.CreateNewFileEx");
			}
			catch {
			}
			MessageBox.Show(this, uninstallCompleteMessage, uninstallCompleteTitle, MessageBoxButtons.OK);
		}

		private void buttonCreate_Click(object sender, EventArgs e) {
			var f = textBoxFileName.Text.Trim();
			try {
				File.Create(Path.Combine(dir, f));
			}
			catch {
			}
			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void textBoxFileName_TextChanged(object sender, EventArgs e) {
			var f = textBoxFileName.Text.Trim();
			if(validateFileName(f)) {
				if(!buttonCreate.Enabled) {
					buttonCreate.Enabled = true;
				}
			}
			else {
				if(buttonCreate.Enabled) {
					buttonCreate.Enabled = false;
				}
			}
		}

		string emptyfilename = "Empty file name.";
		string alreadyexists = "Specified file name was already exists.";
		string invalidfilename = "Specified file name contains invalid path/name character.";

		bool validateFileName(string f) {
			if(f.Length == 0) {
				errorProvider.SetError(textBoxFileName, emptyfilename);
				return false;
			}
			if(File.Exists(Path.Combine(dir, f))) {
				errorProvider.SetError(textBoxFileName, alreadyexists);
				return false;
			}
			bool invalid = false;
			foreach(var c in f.ToCharArray()) {
				if(invalidChars.Contains(c)) {
					invalid = true;
					break;
				}
			}
			if(invalid) {
				errorProvider.SetError(textBoxFileName, invalidfilename);
				return false;
			}
			if(Path.GetFileNameWithoutExtension(f) == "" && Path.GetExtension(f) == "") {
				errorProvider.SetError(textBoxFileName, emptyfilename);
				return false;
			}
			errorProvider.SetError(textBoxFileName, "");
			return true;
		}

		string installCompleteTitle = "Install";
		string installCompleteMessage = "Install was successfully completed.";

		string uninstallCompleteTitle = "Uninstall";
		string uninstallCompleteMessage = "Uninstall was successfully completed.";

		private void FormMain_Load(object sender, EventArgs e) {
			buttonSettings.Visible = UAC.IsAdministrator;
			//
			var langfile = Path.Combine(Application.StartupPath, "lang.ini");
			if(File.Exists(langfile)) {
				var l = new Language(langfile);
				title = l.GetLocalization("CreateNewFileEx");
				Text = title;
				labelFileName.Text = l.GetLocalization("FileNameLabel");
				buttonSettings.Text = l.GetLocalization("SettingsButton");
				buttonCreate.Text = l.GetLocalization("CreateButton");
				buttonCancel.Text = l.GetLocalization("CancelButton");
				menuItemInstall.Text = l.GetLocalization("InstallMenu");
				menuItemUninstall.Text = l.GetLocalization("UninstallMenu");
				emptyfilename = l.GetLocalization("EmptyFileNameError");
				alreadyexists = l.GetLocalization("AlreadyExistsError");
				invalidfilename = l.GetLocalization("InvalidFileNameError");
				installCompleteTitle = l.GetLocalization("InstallCompleteTitle");
				installCompleteMessage = l.GetLocalization("InstallCompleteMessage");
				uninstallCompleteTitle = l.GetLocalization("UninstallCompleteTitle");
				uninstallCompleteMessage = l.GetLocalization("UninstallCompleteMessage");
			}
			//
			var suggestfile = Path.Combine(Application.StartupPath, "suggests.lst");
			if(File.Exists(suggestfile)) {
				using(StreamReader sr = new StreamReader(suggestfile)) {
					List<string> suggests = new List<string>();
					while(!sr.EndOfStream) {
						var l = sr.ReadLine().Trim();
						if(l.Length == 0)
							continue;
						if(suggests.Contains(l))
							continue;
						suggests.Add(l);
					}
					textBoxFileName.AutoCompleteCustomSource.AddRange(suggests.ToArray());
				}
			}
		}
	}
}
