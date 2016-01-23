using System;
using System.Collections;
using System.Drawing;

namespace MazeGame
{
	[Serializable]
	public class SquareMaze : Maze
	{
		public TimeSpan AlogorithmTime;
		public int PassCount;

		/// <summary>
		/// Creates a new square maze with the specified dimension.
		/// </summary>
		/// <param name="size"></param>
		public void CreateMaze(int size)
		{
			CreateSquare(size);
			DateTime d1 = DateTime.Now;
			AddWallsSequentially();
			DateTime d2 = DateTime.Now;
			AlogorithmTime = d2 - d1;
		}

		private struct RoomPair
		{
			public RoomPair(IMapSite r1, IMapSite r2)
			{
				Room1 = r1.Coordinates;
				Room2 = r2.Coordinates;

				if (Room1.X > Room2.X || (Room1.X == Room2.X && Room1.Y > Room2.Y))
				{
					PointF temp = Room1;
					Room1 = Room2;
					Room2 = temp;
				}
			}
			public PointF Room1;
			public PointF Room2;
		}

		private void AddWallsSequentially()
		{
			Room[,] r = _rooms;

			//capacity should be rooms * 2?
			ArrayList ExcludeWalls = new ArrayList(r.Length * 2);

			Random random = new Random();
			SolutionFinder finder = new SolutionFinder();
			finder.FindSolution(this);

			PassCount = 0;
			while (finder.CycleFound)
			{
				PassCount++;
				foreach (Room room in r)
				{
					//if there's already only one way out of this room, then skip it
					if (room.PassableNeighbors < 2)
						continue;

					Direction d = random.Next(4);
					Room neighbor = room.Neighbors[d] as Room;

					//if the selected neighbor isn't a room, move on
					if (neighbor == null)
						continue;

					//if there's already only one way out of the selected neighbor, move on
					if (neighbor.PassableNeighbors < 2)
						continue;

					RoomPair pair = new RoomPair(room, room.Neighbors[d]);

					//if we've already determined that we can't add this wall, don't try again
					if (ExcludeWalls.Contains(pair))
						continue;

					//now try to add the new wall, and make sure all the rooms are still reachable
					new Wall(room, d);
					finder.FindSolution(this);
					if (finder.RoomsConnected < r.Length)
					{
						room.RemoveConnector(d);
						ExcludeWalls.Add(pair);
						finder.CycleFound = true;
						finder.RoomsConnected = r.Length;
					}

					//break out of the foreach loop early if we've already eliminated all cycles
					if (!finder.CycleFound)
						break;
				}
			}
		}

		private void AddWallsRandomly()
		{
			Room[,] r = _rooms;
			Random random = new Random();
			SolutionFinder finder = new SolutionFinder();
			finder.FindSolution(this);
			while (finder.CycleFound /*&& finder.RoomsConnected == r.Length*/)
			{
				int i = random.Next(r.GetUpperBound(0) + 1);
				int j = random.Next(r.GetUpperBound(1) + 1);
				Direction d = random.Next(4);
				Room room = r[i, j];
				if (room.Neighbors[d] is Room)
				{
					new Wall(room, d);
					finder.FindSolution(this);
					if (finder.RoomsConnected < r.Length)
					{
						room.RemoveConnector(d);
						finder.FindSolution(this);
					}
				}
			}
		}

		private void CreateSquare(int size)
		{
			_rooms = new Room[size, size];

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					_rooms[i, j] = new Room();
				}
			}

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					if (i > 0)
					{
						_rooms[i, j].Join(_rooms[i - 1, j], Direction.West);
					}
					if (j > 0)
					{
						_rooms[i, j].Join(_rooms[i, j - 1], Direction.North);
					}
				}
			}

			StartRoom = _rooms[0, 0];
			FinishRoom = _rooms[size - 1, size - 1];
		}
	}
}
