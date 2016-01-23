using System;
using System.Drawing;

namespace MazeGame
{
	/// <summary>
	/// extends Wall by allowing passage
	/// </summary>
	[Serializable]
	public class Door : Connector
	{
		public Door (Room r1, Direction d) : base(r1,d) {}

		//a door always allows passage to the room on the other side
		public override bool Enter (IPerson p) 
		{
			if (!_isOpen)
				return false;

			IMapSite TargetRoom = null;
			foreach (Direction d in Direction.Directions)
			{
				if (Neighbors[d] == p.Location)
				{
					TargetRoom = Neighbors[d.opposite];
					break;
				}
			}

			return (TargetRoom == null) ? false : TargetRoom.Enter(p);
		}

		public override void Draw (DrawContext context)
		{
			RectangleF r = Bounds, l1 = new RectangleF(), l2 = new RectangleF();

			float spacing = .15F;
			float width = .2F;
			
			if (r.Width==0)
			{
				l1 = new RectangleF(r.X,r.Y,0,spacing);
				l2 = new RectangleF(r.X,r.Bottom-spacing,0,spacing);
				r.Height -= spacing*2;
				r.Y += spacing;
				r.Width = width;
				r.X -= width/2;
			}
			else
			{
				r.Width = spacing*2;
				r.X += spacing;
				r.Height = width;
				r.Y -= width/2;
			}

			r = context.TransformF(r);
			l1 = context.TransformF(l1);
			l2 = context.TransformF(l2);
			context.graphics.DrawRectangle(context.WallPen,r.Left,r.Top,r.Width,r.Height);
			context.graphics.DrawLine(context.WallPen,l1.Left,l1.Top,l1.Right,l1.Bottom);
			context.graphics.DrawLine(context.WallPen,l2.Left,l2.Top,l2.Right,l2.Bottom);
		}

		bool _isOpen = false;
		
	}
}
