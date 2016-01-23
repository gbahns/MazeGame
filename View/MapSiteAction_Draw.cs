using System;

namespace MazeGame
{
	/// <summary>
	/// Summary description for MapSiteAction_Draw.
	/// </summary>
	public class MapSiteAction_Draw : IMapSiteAction
	{
		public MapSiteAction_Draw (DrawContext context)
		{
			_context = context;
		}

		public void Act (IMapSite site)
		{
			site.Draw(_context);
		}

		DrawContext _context;
	}

}
