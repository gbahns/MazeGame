using System;
using System.Drawing;

namespace MazeGame
{
	[Serializable]
	abstract public class BaseMapSite : IMapSite
	{
		protected BaseMapSite()
		{
		}
		#region IMapSite Members

		//default implementation does nothing 
		public virtual bool Enter(IPerson p) {return false;}

		//default implementation does nothing
		public virtual bool Leave(IPerson p, Direction d) {return false;}

		//default implementation returns (0,0)
		public virtual PointF Coordinates
		{
			get {return new PointF ();}
		}

		//default implementation returns (0,0)
		public virtual RectangleF Bounds
		{
			get {return new RectangleF();}
		}

		public Rectangle GetDrawingBounds (DrawContext context)
		{
			return context.Transform(Bounds);
		}

		public IMapSite[] Neighbors
		{
			get {return _neighbors;}
		}

		//default implementation returns (0,0)
		public virtual PointF GetAdjacentCoords(Direction d)
		{
			return new PointF ();
		}

		//default implementation does nothing
		public virtual void Draw (DrawContext context) {}

		#endregion

		private IMapSite[] _neighbors = new IMapSite[4];
	}
}
