using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace OxfordCC.ContrOCC.SQLUtilities.Presentation
{
	public static class oApplication
	{
		public static bool InDesign()
		{
			return Process.GetCurrentProcess().ToString().Contains("devenv.exe");
		}
	}
}
