using System;

namespace MazeGame
{
	public enum Compass {North, South, East, West}

	/// <summary>
	/// IDirection defines an interface for compass direction classes.
	/// </summary>
	/*
	public interface IDirection
	{
		Compass direction {get; set;}
		IDirection opposite {get;}
		public static implicit operator int(IDirection d);
	}
	*/
	public struct Direction
	{
		public static Direction North = new Direction(Compass.North);
		public static Direction South = new Direction(Compass.South);
		public static Direction East = new Direction(Compass.East);
		public static Direction West = new Direction(Compass.West);

		public static Direction[] Directions = {North,South,East,West};

		/// <summary>
		/// implicity convert a Direction to an integer
		/// </summary>
		/// <param name="d"></param>
		/// <returns></returns>
		public static implicit operator int(Direction d)
		{
			return (int)d._direction;
		}

		/// <summary>
		/// implicitly convert an integer to a Direction
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public static implicit operator Direction (int n)
		{
			return new Direction((Compass)n);
		}

		public static implicit operator Direction (Compass d)
		{
			return new Direction(d);
		}

		public static implicit operator Compass (Direction d)
		{
			return d.direction;
		}

		public override string ToString()
		{
			return _direction.ToString();
		}

		public Direction (Compass d)
		{
			_direction = d;
		}

		public Compass direction
		{
			get {return _direction;}
			set {_direction = value;}
		}

		public Direction opposite
		{
			get
			{
				switch (_direction)
				{
					case Compass.North: return South;
					case Compass.South: return North;
					case Compass.East: return West;
					case Compass.West: return East;
					default: throw new ApplicationException("invalid direction value");
				}
			}
		}

		private Compass _direction;
	}

}
