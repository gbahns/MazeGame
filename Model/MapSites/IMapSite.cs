using System;
using System.Collections;
using System.Drawing;

namespace MazeGame
{
	/// <summary>
	/// IMapSite defines a standard interface for locations in the map
	/// where a person or object may be located or pass through.
	/// 
	/// Persons in the map can enter or leave a map site.  The map site
	/// can respond to the request to Enter by either allowing or disallowing
	/// entry.  For example, a standard room would always allow entry.
	/// A standard wall would not allow entry.  A door would allow entry
	/// and automatically pass the person through to the next room.
	/// </summary>
	public interface IMapSite
	{
		bool Enter (IPerson p);
		bool Leave (IPerson p, Direction d);
		PointF Coordinates {get;}
		RectangleF Bounds {get;}
		Rectangle GetDrawingBounds (DrawContext context);
		IMapSite[] Neighbors {get;}
		PointF GetAdjacentCoords (Direction d);
		void Draw (DrawContext context);
	}
}


