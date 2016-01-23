using System;
using System.Collections;
using System.Drawing;

namespace MazeGame
{
	[Serializable]
	public class Room : BaseMapSite
	{
		internal int PassableNeighbors
		{
			get
			{
				int count = 0;
				foreach (IMapSite neighbor in Neighbors)
				{
					if (neighbor is Room)
						count++;
				}
				return count;
			}
		}

		
		internal void RemoveConnector (Direction d)
		{
			IMapSite c = Neighbors[d];
			if (c is Connector)
			{
				Join(c.Neighbors[d],d);
			}
		}
		
		#region IMapSite implementation

		//a standard room always allows entry
		public override bool Enter (IPerson p)
		{
			p.Location = this;
			return true;
		}

		public override bool Leave (IPerson p, Direction d)
		{
			//ask the TargetSite for entry
			return (Neighbors[d] == null) ? false : Neighbors[d].Enter(p);
		}

		//connect this site to the specified site
		//assume that the specified site is already connected and has valid 
		//coordinates within the map
		//direction d specifes the direction from "site" to "this"
		public virtual void Join (IMapSite site, Direction d)
		{
			Neighbors[d] = site;
			site.Neighbors[d.opposite] = this;
			_coords = site.GetAdjacentCoords(d.opposite);
		}

		public override PointF Coordinates
		{
			get {return _coords;}
		}

		public override RectangleF Bounds
		{
			get {return new RectangleF(_coords,new SizeF(1,1));}
		}

		public new Rectangle GetDrawingBounds (DrawContext context)
		{
			return context.Transform(Bounds);
		}

		public RectangleF GetBorderLine (Direction d)
		{
			switch (d.direction)
			{
				case Compass.North: return new RectangleF(Bounds.Left,Bounds.Top,Bounds.Width,0);
				case Compass.South: return new RectangleF(Bounds.Left,Bounds.Bottom,Bounds.Width,0);
				case Compass.West: return new RectangleF(Bounds.Left,Bounds.Top,0,Bounds.Height);
				case Compass.East: return new RectangleF(Bounds.Right,Bounds.Top,0,Bounds.Height);
				default: return new RectangleF();
			}
		}

		public override PointF GetAdjacentCoords (Direction d)
		{
			switch (d.direction)
			{
				case Compass.North: return _coords + new Size(0,-1);
				case Compass.South: return _coords + new Size(0,+1);
				case Compass.West: return _coords + new Size(-1,0);
				case Compass.East: return _coords + new Size(+1,0);
				default: return new PointF(0,0);
			}
		}

		public override void Draw (DrawContext context)
		{
			if (!context.ClipRect.IntersectsWith(GetDrawingBounds(context)))
				return;

			DrawContents(context);
			foreach (Direction d in Direction.Directions)
			{
				if (Neighbors[d] == null)
				{
					RectangleF r = context.TransformF(GetBorderLine(d));
					context.graphics.DrawLine(context.WallPen,r.Left,r.Top,r.Right,r.Bottom);
				}
				/*
				else if (Neighbors[d] is Room)
				{
					RectangleF r = context.TransformF(GetBorderLine(d));
					context.graphics.DrawLine(context.GridPen,r.Left,r.Top,r.Right,r.Bottom);
				}
				*/
			}
		}

		public void DrawContents (DrawContext context)
		{
			RectangleF r = context.TransformF(Bounds);
			//float spacing = .25F*r.Width;
			if (this == context.maze.StartRoom)
			{
				//context.graphics.FillEllipse(System.Drawing.Brushes.Green,r.X+spacing,r.Y+spacing,r.Width-spacing*2,r.Height-spacing*2);
				context.graphics.FillRectangle(System.Drawing.Brushes.LightGreen,r);
			}
			else if (this == context.maze.FinishRoom)
			{
				//context.graphics.FillEllipse(System.Drawing.Brushes.Red,r.X+spacing,r.Y+spacing,r.Width-spacing*2,r.Height-spacing*2);
				r.Offset(1,1);
				context.graphics.FillRectangle(System.Drawing.Brushes.LightPink,r);
			}
			//context.graphics.DrawString(Bounds.X+","+Bounds.Y, new Font("Verdana",7), System.Drawing.Brushes.Gray, r.X, r.Y);
		}

		#endregion

		public Room()
		{
		}

		#region Private Data
		//private IMapSite[] _neighbors = CreateDefaultSides();
		//private RoomSides _sides = new RoomSides();
		PointF _coords = new PointF(0,0);
		#endregion
	}
}
