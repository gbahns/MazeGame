using System;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGame
{
	/// <summary>
	/// In the Model-View-Controller design pattern, MazeView
	/// covers the view component.  It contains all the logic
	/// to draw the maze in the given graphics context.
	/// </summary>
	public class MazeView
	{
		public MazeView (MazeGame game, MainForm form)
		{
			_context = new DrawContext(null);
			_game = game;
			_game.View = this;
			_form = form;
			_control = _form.pnlMazeView;
		}

		public void Refresh()
		{
			_form.Refresh();
		}

		public void Refresh (Room roomToRefresh)
		{
			//Rectangle OldDrawingBounds = game.player.Location.GetDrawingBounds(_view.Context);
			Rectangle DrawingBounds = roomToRefresh.GetDrawingBounds(_context);
			DrawingBounds.Inflate(-1,-1);
			_form.pnlMazeView.Invalidate(DrawingBounds);
		}

		public void NewGame()
		{
			_form.imgWinner.Visible = false;
			_form.imgPenguin.Visible = false;
			_form.txtYouHaveWon.Visible = false;
			Refresh();
		}

		public void GameOver(bool PlayerWon)
		{
			if (PlayerWon)
			{
				_form.txtYouHaveWon.Text = "You have won!";
				_form.txtYouHaveWon.Visible = true;
				_form.imgWinner.Visible = true;
			}
			else
			{
				_form.txtYouHaveWon.Text = "The monster got you!";
				_form.txtYouHaveWon.Visible = true;
				_form.imgPenguin.Visible = true;
			}
		}

		public void Draw (PaintEventArgs e)
		{
			if (_game.maze == null)
				return;

			_context.EventArgs = e;
			_context.maze = _game.maze;

			RectangleF MapBounds = _game.maze.Bounds;
			
			int maxRoomWidth = (int)(_control.Width / MapBounds.Width)-1;
			int maxRoomHeight = (int)(_control.Height / MapBounds.Height)-1;
			int roomSize = Math.Min(maxRoomWidth,maxRoomHeight);
			_context.RoomSize = roomSize;

			//roomSize * MapBounds = DrawingMapBounds
			//this more or less centers the map in the view
			_context.Offset = new SizeF((_control.Width - roomSize*MapBounds.Width) / 2,0);

			//convert these screen co-ordinates to map co-ordinates
			RectangleF MapClipRect = _context.ScreenToWorldF(_context.ClipRect);

			//restrict the redrawing bounds to the size of our map
			MapClipRect.Intersect(MapBounds);

			PointF BottomRight = new PointF(
				(float)Math.Ceiling(MapClipRect.Right),
				(float)Math.Ceiling(MapClipRect.Bottom));

			MapClipRect.Location = new PointF(
				(float)Math.Floor(MapClipRect.X),
				(float)Math.Floor(MapClipRect.Y));

			MapClipRect.Size = new SizeF(
				BottomRight.X - MapClipRect.X,
				BottomRight.Y - MapClipRect.Y);


			for (int i=(int)MapClipRect.X; i<(int)MapClipRect.Right; i++)
			{
				for (int j=(int)MapClipRect.Y; j<(int)MapClipRect.Bottom; j++)
				{
					Room r = _game.maze.Rooms[i,j];
					r.Draw(_context);
					foreach (IMapSite n in r.Neighbors)
					{
						if (n!= null && n is Wall)
							n.Draw(_context);
					}

				}
			}

			/*MazeTraverser_BreadthFirst traverser = new MazeTraverser_BreadthFirst();
			traverser.Traverse(_context.maze,new MapSiteAction_Draw(_context));*/
			_game.player.Draw(_context);
			_game.monster.Draw(_context);

			_context.EventArgs = null;
		}

		public DrawContext Context
		{
			get {return _context;}
		}

		public int MoveCount
		{
			set 
			{
				_form.txtMoveCount.Text = value.ToString();
			}
		}

        
		DrawContext _context;
		MazeGame _game;
		Control _control;
		MainForm _form;
	}
}
