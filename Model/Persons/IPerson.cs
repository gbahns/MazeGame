using System;

namespace MazeGame
{
	/// <summary>
	/// Summary description for IPerson.
	/// </summary>
	public interface IPerson
	{
		bool Move (Direction d);
		IMapSite Location {get; set;}
		void Draw (DrawContext context);
	}
}
