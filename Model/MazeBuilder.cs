using System;
using System.Collections;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Runtime.Serialization.Formatters.Soap;

namespace MazeGame
{
	/// <summary>
	/// MazeBuilder manages the pre-building of mazes so that they are ready
	/// when the player needs a new maze, and the player doesn't have to wait
	/// for a new one to be built, which can be especially time-consuming for
	/// larger maps.
	/// 
	/// MazeBuilder maintains a thread to build maps in the background.  When
	/// the player starts a new map at a given difficult level, the map is
	/// retrieved from the MazeBuilder, and it immediately begins building
	/// a replacement.
	/// </summary>
	public class MazeBuilder
	{
		private Thread _builderThread;

		private Hashtable _MazeQueues = new Hashtable(Enum.GetValues(typeof(difficulty)).GetLength(0));

		//System.Environment.SpecialFolder.Personal
		//System.Environment.SpecialFolder.LocalApplicationData
		//System.Environment.CurrentDirectory
		//private string MazesDotDat = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)+@"\Mazes.dat";
		private string MazesDotDat = System.Environment.CurrentDirectory + @"\Mazes.dat";

		public MazeBuilder()
		{
			if (File.Exists(MazesDotDat))
			{
				Stream f = File.OpenRead(MazesDotDat);
				BinaryFormatter serializer = new BinaryFormatter();
				_MazeQueues = (Hashtable)serializer.Deserialize(f);
			}
			else
			{
				_MazeQueues[difficulty.VeryEasy] = new Queue(3);
				_MazeQueues[difficulty.Easy] = new Queue(3);
				_MazeQueues[difficulty.Normal] = new Queue(3);
				_MazeQueues[difficulty.Hard] = new Queue(3);
				_MazeQueues[difficulty.VeryHard] = new Queue(3);
			}
			StartBuilding();
		}

		~MazeBuilder()
		{
			//abort the builder thread to make sure it's not trying to add a new maze when
			//we're trying to serialize the mazes
			try
			{
				//_builderThread.Abort();
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message);
			}
			finally
			{
				Stream f = File.Create(MazesDotDat);
				BinaryFormatter serializer = new BinaryFormatter();
				serializer.Serialize(f,_MazeQueues);
			}

		}

		private void StartBuilding()
		{
			_builderThread = new Thread(new ThreadStart(ThreadProc));
			_builderThread.IsBackground = true;
			_builderThread.Priority = ThreadPriority.Lowest;
			_builderThread.Start();
		}

		public void ThreadProc() 
		{
			while (true)
			{
				foreach (difficulty d in Enum.GetValues(typeof(difficulty)))
				{
					Queue q = MazeQueue(d);
					if (q.Count < 3)
					{
						SquareMaze m = new SquareMaze();
						m.CreateMaze(DesiredMapSize(d));
						q.Enqueue(m);
					}
				}
				Thread.Sleep(100);
			}
		}

		private int[] MapSizes = {12,18,24,30,36};

		private int DesiredMapSize (difficulty d)
		{
			return MapSizes[(int)d];
		}

		public Maze GetMaze (difficulty d)
		{
			return (Maze)MazeQueue(d).Dequeue();
		}

		public int QueryMazeCount (difficulty d)
		{
			return MazeQueue(d).Count;
		}

		public int this [difficulty d]
		{
			get {return MazeQueue(d).Count;}
		}

		public int[] QueryMazeCounts()
		{
			int[] counts = new int[5];
			foreach (difficulty d in Enum.GetValues(typeof(difficulty)))
			{
				counts[(int)d] = MazeQueue(d).Count;
			}
			return counts;
		}

		private Queue MazeQueue (difficulty d)
		{
			//return (Queue)((Queue)_MazeQueues[d]).SyncRoot;
			return (Queue)_MazeQueues[d];
		}

		private void SaveMaze (Maze m)
		{
			Stream f = File.Create(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)+@"\SavedMaze.dat");
			BinaryFormatter serializer = new BinaryFormatter();
			serializer.Serialize(f,m);
		}
	}
}
