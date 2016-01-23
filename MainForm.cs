using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MazeGame
{
	/// <summary>
	/// This is the main form for the MazeGame Windows application.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Panel pnlMazeView;
		internal System.Windows.Forms.Label lblSolutionMsg;
		internal System.Windows.Forms.Label lblCyclesMsg;
		internal System.Windows.Forms.Label lblConnectedCount;
		internal System.Windows.Forms.Label txtMoveCount;
		internal System.Windows.Forms.PictureBox imgWinner;
		internal System.Windows.Forms.Label txtYouHaveWon;
		internal System.Windows.Forms.Panel panel1;
		internal System.Windows.Forms.GameLinkLabel lnkQuit;
		internal System.Windows.Forms.ComboBox cmbDifficulty;
		internal System.Windows.Forms.GameLinkLabel lnkNewGame;
		internal System.Windows.Forms.Label txtStatus;
		private System.Windows.Forms.Timer pollingTimer;
		private System.Windows.Forms.Label VeryEasy;
		private System.Windows.Forms.Label Easy;
		private System.Windows.Forms.Label Normal;
		private System.Windows.Forms.Label Hard;
		private System.Windows.Forms.Label VeryHard;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		internal System.Windows.Forms.PictureBox imgPenguin;
		private System.ComponentModel.IContainer components;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.pnlMazeView = new System.Windows.Forms.Panel();
			this.imgWinner = new System.Windows.Forms.PictureBox();
			this.imgPenguin = new System.Windows.Forms.PictureBox();
			this.txtYouHaveWon = new System.Windows.Forms.Label();
			this.lblConnectedCount = new System.Windows.Forms.Label();
			this.lblSolutionMsg = new System.Windows.Forms.Label();
			this.lblCyclesMsg = new System.Windows.Forms.Label();
			this.txtMoveCount = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.VeryEasy = new System.Windows.Forms.Label();
			this.cmbDifficulty = new System.Windows.Forms.ComboBox();
			this.txtStatus = new System.Windows.Forms.Label();
			this.Easy = new System.Windows.Forms.Label();
			this.Normal = new System.Windows.Forms.Label();
			this.Hard = new System.Windows.Forms.Label();
			this.VeryHard = new System.Windows.Forms.Label();
			this.pollingTimer = new System.Windows.Forms.Timer(this.components);
			this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.lnkNewGame = new System.Windows.Forms.GameLinkLabel();
			this.lnkQuit = new System.Windows.Forms.GameLinkLabel();
			this.pnlMazeView.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgWinner)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgPenguin)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMazeView
			// 
			this.pnlMazeView.BackColor = System.Drawing.SystemColors.Control;
			this.pnlMazeView.Controls.Add(this.imgWinner);
			this.pnlMazeView.Controls.Add(this.imgPenguin);
			this.pnlMazeView.Controls.Add(this.txtYouHaveWon);
			this.pnlMazeView.Controls.Add(this.lblConnectedCount);
			this.pnlMazeView.Controls.Add(this.lblSolutionMsg);
			this.pnlMazeView.Controls.Add(this.lblCyclesMsg);
			this.pnlMazeView.Location = new System.Drawing.Point(0, 8);
			this.pnlMazeView.Name = "pnlMazeView";
			this.pnlMazeView.Size = new System.Drawing.Size(592, 592);
			this.pnlMazeView.TabIndex = 0;
			this.pnlMazeView.Paint += new System.Windows.Forms.PaintEventHandler(this.MazeView_Paint);
			// 
			// imgMarco
			// 
			this.imgWinner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imgWinner.Cursor = System.Windows.Forms.Cursors.Hand;
			this.imgWinner.Image = ((System.Drawing.Image)(resources.GetObject("imgMarco.Image")));
			this.imgWinner.Location = new System.Drawing.Point(27, 88);
			this.imgWinner.Name = "imgMarco";
			this.imgWinner.Size = new System.Drawing.Size(535, 384);
			this.imgWinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgWinner.TabIndex = 0;
			this.imgWinner.TabStop = false;
			this.imgWinner.Visible = false;
			this.imgWinner.Click += new System.EventHandler(this.imgMarco_Click);
			// 
			// imgPenguin
			// 
			this.imgPenguin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.imgPenguin.Image = ((System.Drawing.Image)(resources.GetObject("imgPenguin.Image")));
			this.imgPenguin.Location = new System.Drawing.Point(104, 208);
			this.imgPenguin.Name = "imgPenguin";
			this.imgPenguin.Size = new System.Drawing.Size(364, 209);
			this.imgPenguin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.imgPenguin.TabIndex = 4;
			this.imgPenguin.TabStop = false;
			this.imgPenguin.Visible = false;
			// 
			// txtYouHaveWon
			// 
			this.txtYouHaveWon.BackColor = System.Drawing.Color.Transparent;
			this.txtYouHaveWon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.txtYouHaveWon.Font = new System.Drawing.Font("Verdana", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtYouHaveWon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.txtYouHaveWon.Location = new System.Drawing.Point(8, 472);
			this.txtYouHaveWon.Name = "txtYouHaveWon";
			this.txtYouHaveWon.Size = new System.Drawing.Size(576, 48);
			this.txtYouHaveWon.TabIndex = 1;
			this.txtYouHaveWon.Text = "You have won!";
			this.txtYouHaveWon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.txtYouHaveWon.Visible = false;
			// 
			// lblConnectedCount
			// 
			this.lblConnectedCount.Location = new System.Drawing.Point(336, 536);
			this.lblConnectedCount.Name = "lblConnectedCount";
			this.lblConnectedCount.Size = new System.Drawing.Size(168, 16);
			this.lblConnectedCount.TabIndex = 3;
			this.lblConnectedCount.Text = "# of rooms connected";
			this.lblConnectedCount.Visible = false;
			// 
			// lblSolutionMsg
			// 
			this.lblSolutionMsg.Location = new System.Drawing.Point(184, 536);
			this.lblSolutionMsg.Name = "lblSolutionMsg";
			this.lblSolutionMsg.Size = new System.Drawing.Size(152, 16);
			this.lblSolutionMsg.TabIndex = 2;
			this.lblSolutionMsg.Text = "Solution?";
			this.lblSolutionMsg.Visible = false;
			// 
			// lblCyclesMsg
			// 
			this.lblCyclesMsg.Location = new System.Drawing.Point(24, 536);
			this.lblCyclesMsg.Name = "lblCyclesMsg";
			this.lblCyclesMsg.Size = new System.Drawing.Size(168, 16);
			this.lblCyclesMsg.TabIndex = 3;
			this.lblCyclesMsg.Text = "Cycles?";
			this.lblCyclesMsg.Visible = false;
			// 
			// txtMoveCount
			// 
			this.txtMoveCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtMoveCount.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMoveCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.txtMoveCount.Location = new System.Drawing.Point(0, 0);
			this.txtMoveCount.Name = "txtMoveCount";
			this.txtMoveCount.Size = new System.Drawing.Size(64, 24);
			this.txtMoveCount.TabIndex = 0;
			this.txtMoveCount.Text = "0";
			this.txtMoveCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.VeryEasy);
			this.panel1.Controls.Add(this.lnkNewGame);
			this.panel1.Controls.Add(this.lnkQuit);
			this.panel1.Controls.Add(this.txtMoveCount);
			this.panel1.Controls.Add(this.cmbDifficulty);
			this.panel1.Controls.Add(this.txtStatus);
			this.panel1.Controls.Add(this.Easy);
			this.panel1.Controls.Add(this.Normal);
			this.panel1.Controls.Add(this.Hard);
			this.panel1.Controls.Add(this.VeryHard);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 608);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(592, 24);
			this.panel1.TabIndex = 9;
			this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
			// 
			// VeryEasy
			// 
			this.VeryEasy.AutoSize = true;
			this.VeryEasy.Location = new System.Drawing.Point(160, 8);
			this.VeryEasy.Name = "VeryEasy";
			this.VeryEasy.Size = new System.Drawing.Size(13, 13);
			this.VeryEasy.TabIndex = 14;
			this.VeryEasy.Text = "0";
			// 
			// cmbDifficulty
			// 
			this.cmbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDifficulty.Items.AddRange(new object[] {
            "Very Easy",
            "Easy",
            "Normal",
            "Hard",
            "Very Hard"});
			this.cmbDifficulty.Location = new System.Drawing.Point(352, 0);
			this.cmbDifficulty.Name = "cmbDifficulty";
			this.cmbDifficulty.Size = new System.Drawing.Size(121, 21);
			this.cmbDifficulty.TabIndex = 11;
			this.cmbDifficulty.TabStop = false;
			this.cmbDifficulty.SelectedIndexChanged += new System.EventHandler(this.cmbDifficulty_SelectedIndexChanged);
			// 
			// txtStatus
			// 
			this.txtStatus.Location = new System.Drawing.Point(64, 0);
			this.txtStatus.Name = "txtStatus";
			this.txtStatus.Size = new System.Drawing.Size(88, 23);
			this.txtStatus.TabIndex = 13;
			this.txtStatus.Text = "Maze Game";
			this.txtStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Easy
			// 
			this.Easy.AutoSize = true;
			this.Easy.Location = new System.Drawing.Point(184, 8);
			this.Easy.Name = "Easy";
			this.Easy.Size = new System.Drawing.Size(13, 13);
			this.Easy.TabIndex = 14;
			this.Easy.Text = "0";
			// 
			// Normal
			// 
			this.Normal.AutoSize = true;
			this.Normal.Location = new System.Drawing.Point(208, 8);
			this.Normal.Name = "Normal";
			this.Normal.Size = new System.Drawing.Size(13, 13);
			this.Normal.TabIndex = 14;
			this.Normal.Text = "0";
			// 
			// Hard
			// 
			this.Hard.AutoSize = true;
			this.Hard.Location = new System.Drawing.Point(232, 8);
			this.Hard.Name = "Hard";
			this.Hard.Size = new System.Drawing.Size(13, 13);
			this.Hard.TabIndex = 14;
			this.Hard.Text = "0";
			// 
			// VeryHard
			// 
			this.VeryHard.AutoSize = true;
			this.VeryHard.Location = new System.Drawing.Point(256, 8);
			this.VeryHard.Name = "VeryHard";
			this.VeryHard.Size = new System.Drawing.Size(13, 13);
			this.VeryHard.TabIndex = 14;
			this.VeryHard.Text = "0";
			// 
			// pollingTimer
			// 
			this.pollingTimer.Enabled = true;
			this.pollingTimer.Tick += new System.EventHandler(this.pollingTimer_Tick);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3});
			this.menuItem1.Text = "Maze";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "New Game";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "Quit";
			// 
			// lnkNewGame
			// 
			this.lnkNewGame.Location = new System.Drawing.Point(480, 0);
			this.lnkNewGame.Name = "lnkNewGame";
			this.lnkNewGame.Size = new System.Drawing.Size(64, 24);
			this.lnkNewGame.TabIndex = 12;
			this.lnkNewGame.TabStop = true;
			this.lnkNewGame.Text = "New Game";
			this.lnkNewGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lnkNewGame.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNewGame_LinkClicked);
			// 
			// lnkQuit
			// 
			this.lnkQuit.Location = new System.Drawing.Point(552, 0);
			this.lnkQuit.Name = "lnkQuit";
			this.lnkQuit.Size = new System.Drawing.Size(32, 24);
			this.lnkQuit.TabIndex = 5;
			this.lnkQuit.TabStop = true;
			this.lnkQuit.Text = "Quit";
			this.lnkQuit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lnkQuit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkQuit_LinkClicked);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 632);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pnlMazeView);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.Text = "Maze Game";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.pnlMazeView.ResumeLayout(false);
			this.pnlMazeView.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgWinner)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgPenguin)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			//control initialization to enable proper resizing
			lnkQuitOffset = panel1.Width - lnkQuit.Left;
			lnkNewGameOffset = panel1.Width - lnkNewGame.Left;
			cmbDifficultyOffset = panel1.Width - cmbDifficulty.Left;
			MazeViewOffset = new Size(Width - pnlMazeView.Width, Height - pnlMazeView.Height);

			//MVC initialization
			game = new MazeGame();
			view = new MazeView(game,this);
			controller = new MazeController(game,view);
			controller.Difficulty = difficulty.Easy;
			//controller.CreateMaze();
			this.cmbDifficulty.SelectedIndex = (int)controller.Difficulty;
		}

		private void NewGame()
		{
			try
			{
				Cursor = Cursors.WaitCursor;
				controller.CreateMaze();
			}
			catch
			{
				MessageBox.Show("Maze currently under construction; please wait or select a different difficulty");
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void MazeView_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			view.Draw(e);
		}

		private Direction GetDesiredDirection (Keys c)
		{
			//switch (char.ToUpper(e.KeyChar))
			switch (c)
			{
				case Keys.Down: return Direction.South;
				case Keys.Right: return Direction.East;
				case Keys.Up: return Direction.North;
				case Keys.Left: return Direction.West;
				default: return -1;
			}
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress (e);
		}
		
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown (e);
			controller.MovePlayer(GetDesiredDirection(e.KeyCode));
		}


		protected override bool ProcessDialogKey(System.Windows.Forms.Keys keyData)
		{
			return false;
			//return base.ProcessDialogKey(keyData);
		}

		private void imgMarco_Click(object sender, System.EventArgs e)
		{
			
			NewGame();
		}

		private void lnkNewGame_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			NewGame();
		}

		private void lnkQuit_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			Close();
		}

		private void cmbDifficulty_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			game.Difficulty = (difficulty)cmbDifficulty.SelectedIndex;
			//for now require the user to click "New Game" after changing the difficulty
			//NewGame();
			this.pnlMazeView.Focus();
		}

		private void panel1_Resize(object sender, System.EventArgs e)
		{
			lnkQuit.Left = panel1.Width - lnkQuitOffset;
			lnkNewGame.Left = panel1.Width - lnkNewGameOffset;
			cmbDifficulty.Left = panel1.Width - cmbDifficultyOffset;

			imgWinner.Left = (panel1.Width - imgWinner.Width) / 2;
			imgWinner.Top = (int)((panel1.Width - imgWinner.Width) * .4);
			imgPenguin.Left = (panel1.Width - imgWinner.Width) / 2;
			imgPenguin.Top = (int)((panel1.Width - imgWinner.Width) * .4);
			txtYouHaveWon.Top = imgWinner.Bottom;
			txtYouHaveWon.Left = (panel1.Width - txtYouHaveWon.Width) / 2;
		}

		private void MainForm_Resize(object sender, System.EventArgs e)
		{
			pnlMazeView.Width = Width - MazeViewOffset.Width;
			pnlMazeView.Height = Height - MazeViewOffset.Height;
			pnlMazeView.Refresh();
		}

		MazeGame game;
		MazeView view;
		MazeController controller;

		int lnkQuitOffset;
		int lnkNewGameOffset;
		int cmbDifficultyOffset;
		Size MazeViewOffset;

		private void pollingTimer_Tick(object sender, System.EventArgs e)
		{
			int[] MazeCounts = game.Builder.QueryMazeCounts();
			
			VeryEasy.Text = MazeCounts[(int)difficulty.VeryEasy].ToString();
			Easy.Text = MazeCounts[(int)difficulty.Easy].ToString();
			Normal.Text = MazeCounts[(int)difficulty.Normal].ToString();
			Hard.Text = MazeCounts[(int)difficulty.Hard].ToString();
			VeryHard.Text = MazeCounts[(int)difficulty.VeryHard].ToString();
			
			lnkNewGame.Enabled = (MazeCounts[(int)game.Difficulty] > 0);
		}
	}

}
