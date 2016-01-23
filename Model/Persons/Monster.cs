using System;
using System.Drawing;

namespace MazeGame
{
	/// <summary>
	/// Summary description for MazeExplorer.
	/// </summary>

	public class Monster : IPerson
	{
		/// <summary>
		/// attempts to leave the current location by moving the
		/// person in the specified direction
		/// </summary>
		/// <param name="d">direction the player wants to move</param>
		/// <returns>true if the Move operation succeeds</returns>
		public bool Move (Direction d)
		{
			return _location.Leave(this,d);
		}
        
		//sets/gets the person's Location
		public IMapSite Location
		{
			get {return _location;}
			set {_location = value;}
		}

		public virtual void Draw (DrawContext context)
		{
			RectangleF r = context.Transform(_location.Bounds);
			float spacing = .25F*r.Width;
			context.graphics.FillEllipse(System.Drawing.Brushes.Black,r.X+spacing,r.Y+spacing,r.Width-spacing*2,r.Height-spacing*2);
			spacing = .38F*r.Width;
			context.graphics.FillEllipse(System.Drawing.Brushes.Red,r.X+spacing,r.Y+spacing,r.Width-spacing*2,r.Height-spacing*2);
		}

		public Monster()
		{
		}

		private IMapSite _location = null;
	}

}
