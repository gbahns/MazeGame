using System;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGame
{
	/// <summary>
	/// Summary description for DrawContext.
	/// </summary>
	public class DrawContext
	{
		public DrawContext (Maze m)
		{
			_maze = m;
		}

		public Maze maze
		{
			get {return _maze;}
			set {_maze = value;}
		}

		public int RoomSize
		{
			set {_scale = new SizeF(value,value);}
		}

		public SizeF Offset
		{
			get {return _offset;}
			set {_offset = value;}
		}

		public PaintEventArgs EventArgs
		{
			get {return _event_args;}
			set {_event_args = value;}
		}

		public Graphics graphics
		{
			get {return _event_args.Graphics;}
		}

		public Rectangle ClipRect
		{
			get {return _event_args.ClipRectangle;}
		}

		public Pen WallPen
		{
			get {return System.Drawing.Pens.Black;}
		}

		public Pen GridPen
		{
			get {return System.Drawing.Pens.LightGray;}
		}

		public Rectangle ScreenToWorld (Rectangle r)
		{
			RectangleF r2 = ScreenToWorldF(r);
			return new Rectangle((int)r2.X,(int)r2.Y,(int)r2.Width,(int)r2.Height);
		}

		public RectangleF ScreenToWorldF (Rectangle r)
		{
			return new RectangleF(
				(r.Left - _offset.Width) / _scale.Width,
				(r.Top - _offset.Height) / _scale.Height,
				r.Width / _scale.Width,
				r.Height / _scale.Height
				);
		}

		public Rectangle Transform (RectangleF r)
		{
			RectangleF r2 = TransformF(r);
			return new Rectangle((int)r2.X,(int)r2.Y,(int)r2.Width,(int)r2.Height);
		}

		public RectangleF TransformF (RectangleF r)
		{
			return new RectangleF(
				r.Left * _scale.Width + _offset.Width,
				r.Top * _scale.Height + _offset.Height,
				r.Width * _scale.Width,
				r.Height * _scale.Height
				);
		}

		PaintEventArgs _event_args;
		Maze _maze;
		SizeF _scale = new SizeF(25,25);
		SizeF _offset = new SizeF(0,0);

		//System.Drawing.Pen WallPen = System.Drawing.Pens.Black;
		//System.Drawing.Pen GridPen = System.Drawing.Pens.LightGray;
	}
}
