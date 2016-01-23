using System;
using System.Collections;
using System.Drawing;

namespace MazeGame
{
	public enum difficulty {VeryEasy, Easy, Normal, Hard, VeryHard};

	/// <summary>
	/// Summary description for MazeGame.
	/// </summary>
	public class MazeGame
	{
		//public static difficulty[] Difficulties = {VeryEasy, Easy, Normal, Hard, VeryHard};

		public MazeGame()
		{
		}

		public Maze maze
		{
			get {return _maze;}
		}

		public IPerson player
		{
			get {return _player;}
		}

		public IPerson monster
		{
			get {return _monster;}
		}

		public difficulty Difficulty
		{
			get {return _difficulty;}
			set {_difficulty = value;}
		}

		public int MoveCount
		{
			get {return _moveCount;}
			set 
			{
				_moveCount = value;
				_view.MoveCount = value;
			}
		}

		public void CreateMaze()
		{
			_maze = _builder.GetMaze(_difficulty);
			_player.Location = _maze.StartRoom;
			_monster.Location = _maze.FinishRoom;
			MoveCount = 0;
		}

		internal MazeBuilder Builder
		{
			get {return _builder;}
		}

		internal MazeView View
		{
			set {_view = value;}
		}

		/*
		void CreateMaze (IMazeFactory factory)
		{
			Room r1 = factory.MakeRoom();
			Room r2 = factory.MakeRoom();
			Room r3 = factory.MakeRoom();

			Door d = factory.MakeDoor(r2,r3);

			r1.Join(r2,South);

			_maze.AnchorRoom = r1;
		}
		*/
		
		public bool PlayerWon
		{
			get {return _player.Location == _maze.FinishRoom;}
		}
		
		public bool PlayerLost
		{
			get {return _player.Location == _monster.Location;}
		}

		public bool GameOver 
		{
			get {return PlayerWon || PlayerLost;}
		}

		MazeView _view;
		MazeBuilder _builder = new MazeBuilder();
		Maze _maze;
		MazeExplorer _player = new MazeExplorer();
		Monster _monster = new Monster();
		difficulty _difficulty = difficulty.VeryEasy;
		int _moveCount = 0;
	}
}




/*

	/// interface based on abstract factory design pattern
	public interface IMazeFactory
	{
		public Maze MakeMaze();
		public Room MakeRoom();
		public Wall MakeWall();
		public Door MakeDoor();
	}

	/// implementation based on abstract factory design pattern public class StandardMazeFactory : IMazeFactory {
	public virtual Maze MakeMaze()
	{
		return new Maze();
	}

		public virtual Room MakeRoom()
	{
		return new Room();
	}

		public virtual Wall MakeWall (Room r1, Room r2, IDirection d)
	{
		return new Wall(r1,r2,d);
	}

		public virtual Door MakeDoor (Room r1, Room r2, IDirection d)
	{
		return new Door(r1,r2,d);
	}
	}

	public class MazeBuilder
	{
		public virtual Maze BuildMaze()
		{
		}
		
		public virtual Room BuildRoom()
		{
		}
		
		public virtual IMapSite BuildDoor()
		{
		}
		
		public virtual IMapSite BuildWall()
		{
		}
		
		public virtual Maze GetMaze()
		{
			return _maze;
		}
		
		Maze _maze;
	}

	public class MazeAssembler
	{
	}


*/

