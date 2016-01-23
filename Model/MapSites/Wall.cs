using System;
using System.Drawing;

namespace MazeGame
{
	/// <summary>
	///a standard Wall adjoins two rooms, but does not allow passage
	///a wall is created by specifying a room that it forms the border of,
	///and the direction from the room that is bordered by this wall.
	/// </summary>
	[Serializable]
	public class Wall : Connector
	{
		public Wall (Room r1, Direction d) : base(r1,d) {}

		public override void Draw (DrawContext context)
		{
			RectangleF r = context.TransformF(Bounds);
			context.graphics.DrawLine(context.WallPen,r.Left,r.Top,r.Right,r.Bottom);
		}
	}
}
