using System;
using System.Windows.Forms;

namespace System.Windows.Forms
{
	/// <summary>
	/// Summary description for MyLinkLabel.
	/// </summary>
	public class GameLinkLabel : LinkLabel
	{
		private System.Windows.Forms.LinkLabel linkLabel1;

		private void InitializeComponent()
		{
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(17, 17);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.TabIndex = 0;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "linkLabel1";

		}
	
		protected override bool ProcessDialogKey(System.Windows.Forms.Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Up:
				case Keys.Down:
				case Keys.Left:
				case Keys.Right:
					return false;
				default:
					return true;
			}
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus (e);
			this.Parent.Focus();
		}

	}

}
