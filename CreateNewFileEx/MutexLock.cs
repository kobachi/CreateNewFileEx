using System;
using System.Threading;

namespace CreateNewFileEx {
	public class MutexAlreadyExists: Exception {
	}

	public class MutexLock: IDisposable {
		Mutex m;

		public MutexLock(string mutexname) {
			m = new Mutex(false, mutexname);
			if(m.WaitOne(0, false) == false) {
				throw new MutexAlreadyExists();
			}
		}

		#region IDisposable メンバー

		public void Dispose() {
			m.ReleaseMutex();
			m.Close();
		}

		#endregion
	}
}
