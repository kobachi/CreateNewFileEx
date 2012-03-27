using System.Security.Principal;

namespace CreateNewFileEx {
	public static class UAC {
		public static bool IsAdministrator {
			get {
				bool isAllowed = false;
				try {
					WindowsIdentity wi = WindowsIdentity.GetCurrent();
					WindowsPrincipal wp = new WindowsPrincipal(wi);
					isAllowed = wp.IsInRole(WindowsBuiltInRole.Administrator);
				}
				catch {
					isAllowed = false;
				}

				return isAllowed;
			}
		}
	}
}