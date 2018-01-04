/*
 * Created by SharpDevelop.
 * User: ramazan
 * Date: 11/7/2017
 * Time: 1:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ChildProcess
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Process process = new Process();
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			this.WindowState = FormWindowState.Minimized;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		void process_Exited(object sender, EventArgs e)
		{
			
			Application.Exit();
			
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			try {
				process.StartInfo.FileName = "mspaint.exe";
				process.EnableRaisingEvents = true;
				process.Exited += new EventHandler(process_Exited);
				process.Start();
				timer1.Enabled = true;
				
			} catch (Exception) {
				
				
			}
		
			
	
			
	
	
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			Process[] processList = Process.GetProcesses();
			foreach(Process list in processList){
				//uygulama ismi CS6ServiceManager olan process i kapatir
				if(list.ProcessName.Contains("CS6ServiceManager")){
					try {
						
						list.Kill();
					} catch (Exception) {
						
						
					}
					//Uyari mesaji CS6ServiceManager olan ekrani kapatir
				}else if(list.MainWindowTitle.Contains("CS6ServiceManager")){
					try {
						list.CloseMainWindow();
					} catch (Exception) {
						
						
					}
				}
			}
			
	
		}
		
	}
}
