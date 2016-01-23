using System;
using System.Drawing;

namespace MazeGame
{
	/// <summary>
	/// Serves as base class for objects that connect two rooms.
	/// e.g. doors and walls
	/// </summary>
	[Serializable]
	public class Connector : BaseWall
	{
		//provide default implementations that do nothing

		protected Connector (Room r1, Direction d)
		{
			Room r2 = (Room)r1.Neighbors[d];

			r1.Neighbors[d] = this;
			Neighbors[d] = r2;

			r2.Neighbors[d.opposite] = this;
			Neighbors[d.opposite] = r1;
		}

		public override RectangleF Bounds
		{
			get 
			{
				foreach (Direction d in Direction.Directions)
				{
					Room r = Neighbors[d] as Room;
					if (r != null)
					{
						return r.GetBorderLine(d.opposite);
					}
				}
				return new RectangleF();
			}
		}
	}

}
