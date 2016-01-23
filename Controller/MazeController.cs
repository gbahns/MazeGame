using System;

namespace MazeGame
{
	/// <summary>
	/// Summary description for MazeController.
	/// </summary>
	public class MazeController
	{
		private System.Windows.Forms.Timer _monsterTimer = new System.Windows.Forms.Timer();

		public MazeController(MazeGame game, MazeView view)
		{
			_game = game;
			_view = view;
			_monsterTimer.Tick += new System.EventHandler(this.monsterTimer_Tick);
			_monsterTimer.Interval = 200;
			//_monsterTimer.Start();
		}

		private void CheckEndGame()
		{
			if (_game.GameOver)
			{
			   _monsterTimer.Stop();
				_view.GameOver(_game.PlayerWon);
			}
		}

		private bool MovePerson (IPerson person, Direction d)
		{
			if (d == -1)
				return false;

			Room OldLocation = person.Location as Room;
			if (person.Move(d))
			{
				_view.Refresh(OldLocation);
				_view.Refresh(person.Location as Room);
				CheckEndGame();
				return true;
			}
			return false;
		}

		public void MovePlayer (Direction d)
		{
			if (_game.maze==null || _game.GameOver)
				return;

			if (MovePerson(_game.player, d))
			{
				_game.MoveCount++;
				if (!_monsterTimer.Enabled)
					_monsterTimer.Start();
			}
		}

		private void monsterTimer_Tick(object sender, System.EventArgs e)
		{
			if (_game.maze==null || _game.GameOver)
				return;
			while (!MovePerson(_game.monster, _random.Next(4)));
		}

		public difficulty Difficulty
		{
			get {return _game.Difficulty;}
			set {_game.Difficulty = value;}
		}

		public void CreateMaze()
		{
			_monsterTimer.Stop();
			_game.CreateMaze();
			_view.NewGame();
			_gameOver = false;
		}

		public bool GameOver
		{
			get {return _gameOver;}
		}

		MazeView _view;
		MazeGame _game;
		bool _gameOver = false;
		private Random _random = new Random();
	}
}
