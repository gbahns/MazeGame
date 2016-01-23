using System;
using System.Collections;

namespace MazeGame
{
	/// <summary>
	/// Summary description for MazeTraverser_BreadthFirst.
	/// </summary>
	public class MazeTraverser_BreadthFirst : IMazeTraverser
	{
		public MazeTraverser_BreadthFirst()
		{
		}

		public void Traverse (Maze maze, IMapSiteAction action)
		{
			_action = action;
			Visit(maze.StartRoom);
		}

		void Visit (IMapSite site)
		{
			_visited.Add(site);
			_action.Act(site);

			foreach (IMapSite Neighbor in site.Neighbors)
			{
				if (Neighbor != null && !_visited.Contains(Neighbor))
				{
					Visit(Neighbor);
				}
			}
		}

		ArrayList _visited = new ArrayList();
		IMapSiteAction _action;
	}
}
