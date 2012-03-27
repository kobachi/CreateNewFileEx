using System;
using System.Windows.Forms;
using System.IO;

namespace CreateNewFileEx {
	static class Program {
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main(string[] args) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			using(new MutexLock("CreateNewFileEx")) {
				string file = "";
				if(args.Length == 1) {
					file = args[0];
				}
				Application.Run(new FormMain(file));
			}
		}
	}
}
