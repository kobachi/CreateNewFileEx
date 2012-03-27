using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CreateNewFileEx {
	public class Language {
		Dictionary<string, string> lang;

		public Language() {
			lang = new Dictionary<string, string>();
		}

		public Language(string file) {
			lang = new Dictionary<string, string>();
			Load(file);
		}

		public void Load(string file) {
			lang.Clear();
			//
			using(StreamReader sr = new StreamReader(file)) {
				while(!sr.EndOfStream) {
					string line = sr.ReadLine();
					int p = line.IndexOf("=");
					if(0 < p && (p + 1) < line.Length) {
						string key = line.Substring(0, p);
						string val = line.Substring(p + 1);
						//
						lang.Add(key, val);
					}
				}
			}
		}

		public string GetLocalization(string key) {
			if(!lang.ContainsKey(key)) {
				return "[" + key + "]";
			}
			return lang[key];
		}
	}

}
