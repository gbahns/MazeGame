using System;
using System.Collections;
using System.Drawing;

namespace MazeGame
{
	/// <summary>
	/// Summary description for MazeDrawer.
	/// </summary>
	public class MazeDrawer	/*: IMazeTraverser*/
	{
		public MazeDrawer (Graphics g)
		{
			_g = g;
		}

		#region IMazeTraverser Members

		public void Traverse (Maze maze)
		{
			//RectangleF bounds = g.VisibleClipBounds;
			//Point a = new Point((int)bounds.Width/2, (int)bounds.Height/2);
			//DrawRoom(maze.AnchorRoom);
		}

		/*
		public void MazeGame.Algorithms.IMazeTraverser.Traverse(IMaze maze, IAction action)
		{
		}
		*/

		#endregion


		/*
		void Visit (IMapSite site, IMapSite fromsite, int x, int y)
		{
			if (site.IsVisible())
			{
				AddSiteLine(site,fromsite,x,y);
			}
			action.Act(site);
			_visited.Add(site);

			foreach (IMapSite Neighbor in site.Neighbors)
			{
				if (!_visited.Contains(Neighbor))
				{
					Visit(Neighbor,action);
				}
			}
		}

		void AddSiteLine (IMapSite site, IMapSite fromsite, int x, int y)
		{
			Type tr = typeof(Room);
			Type tw = typeof(SolidWall);
			if (tr.IsInstanceOfType(t) || tw.IsInstanceOfType(t))
			{
				int d = _room_size / 2;
				Rectangle r = new Rectangle(x-d,y-d,x+d,y+d);
				switch (site)
				{
					case fromsite.Sides[North]: lines.Add(new Rectangle(r.Left,r.Top,r.Right,r.Top));
					case fromsite.Sides[South]: lines.Add(new Rectangle(r.Left,r.Bottom,r.Right,r.Bottom));
					case fromsite.Sides[West]: lines.Add(new Rectangle(r.Left,r.Top,r.Left,r.Bottom));
					case fromsite.Sides[East]: lines.Add(new Rectangle(r.Right,r.Top,r.Right,r.Bottom));
				}
			}
		}

		void DrawMaze (Graphics g)
		{
			foreach (Rectangle r in lines)
			{
				g.DrawLine(r);
			}
		}
		*/

		Graphics _g;
		ArrayList _visited = new ArrayList();
		//Rectangle[] lines = new Rectangle[];

		System.Drawing.Pen WallPen = System.Drawing.Pens.Black;
		System.Drawing.Pen GridPen = System.Drawing.Pens.LightGray;
	}

}
