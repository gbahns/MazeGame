using System;
using System.Collections;

namespace MazeGame
{
	/// <summary>
	/// Summary description for SolutionFinder.
	/// </summary>
	public class SolutionFinder
	{
		public SolutionFinder()
		{
		}

		public void FindSolution (Maze maze)
		{
			_solutionFound = false;
			_cycleFound = false;
			_visited.Clear();
			_robot.Location = maze.StartRoom;
			Explore(null,maze.StartRoom);
			_solutionFound = _visited.Contains(maze.FinishRoom);
			_roomsConnected = _visited.Count;
		}

		void Explore (IMapSite fromSite, IMapSite Site)
		{
			_visited.Add(Site);

			foreach (IMapSite Neighbor in Site.Neighbors)
			{
				if (Neighbor != null && Neighbor != fromSite)
				{
					//try to enter this neighbor
					Neighbor.Enter(_robot);

					//check to see if it succeeded
					if (_robot.Location != Site)
					{
						//if it succeeded, but we've already been there once,
						//then we've found a cycle, otherwise continue exploring
						//from this neighbor
						if (_visited.Contains(_robot.Location))
						{
							_cycleFound = true;
						}
						else
						{
							Explore(Site,_robot.Location);
						}
					}
					
					//after exploring that neighbor,
					//reset to this location to explore the other neighbors
					_robot.Location = Site;

					//if (_solutionFound)
					//	break;
				}
			}
		}

		/// <summary>
		/// indicates whether or not the SolutionFinder algorithm has succeeded in finding a solution
		/// </summary>
		public bool SolutionFound
		{
			get {return _solutionFound;}
			set {_solutionFound = value;}
		}
		
		/// <summary>
		/// indicates whether or not the SolutionFinder algorithm found any cycles while searching for the solution
		/// </summary>
		public bool CycleFound
		{
			get {return _cycleFound;}
			set {_cycleFound = value;}
		}

		public int RoomsConnected
		{
			get {return _roomsConnected;}
			set {_roomsConnected = value;}
		}

		ArrayList _visited = new ArrayList();

		bool _solutionFound = false;
		bool _cycleFound = false;
		int _roomsConnected = 0;

		IPerson _robot = new MazeExplorer();

	}
}
