using System;

namespace MazeGame
{
	/// <summary>
	/// Summary description for IMazeTraverser.
	/// </summary>
	public interface IMazeTraverser
	{
		//void Traverse (Maze maze);
		void Traverse (Maze maze, IMapSiteAction action);
	}

	public interface IMapSiteAction
	{
		void Act (IMapSite site);
	}


}
