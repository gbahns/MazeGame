using System;
using System.Drawing;
using System.Collections;

namespace MazeGame
{
	[Serializable]
	public class Maze
	{
		public Maze()
		{
		}

		public Room StartRoom
		{
			get {return _startRoom;}
			set {_startRoom = value;}
		}

		public Room FinishRoom
		{
			get {return _finishRoom;}
			set {_finishRoom = value;}
		}

		private class MapSiteAction_CalcMapBounds : IMapSiteAction
		{
			public MapSiteAction_CalcMapBounds (RectangleF bounds)
			{
				Bounds = bounds;
			}

			public void Act (IMapSite site)
			{
				if (site is Room)
					Bounds = RectangleF.Union(Bounds,site.Bounds);
			}

			public RectangleF Bounds;
		}

		public RectangleF Bounds
		{
			get
			{
				return RectangleF.Union(
					_rooms[0,0].Bounds,
					_rooms[_rooms.GetUpperBound(0),_rooms.GetUpperBound(1)].Bounds
					);

				//the following algorithm can be used to calculate the map bounds
				//when the underlying data structure isn't known - quite inefficient.
//				IMazeTraverser traverser = new MazeTraverser_BreadthFirst();
//				MapSiteAction_CalcMapBounds action = new MapSiteAction_CalcMapBounds(StartRoom.Bounds);
//				traverser.Traverse(this,action);
//				return action.Bounds;
			}
		}

		public Room[,] Rooms
		{
			get {return _rooms;}
		}

		protected Room[,] _rooms;
		Room _startRoom;
		Room _finishRoom;
	}
}
