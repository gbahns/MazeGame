using System;
using System.Drawing;
using System.Text;
using NUnit.Framework;


namespace MazeGame
{
	using NUnit.Framework;

	[TestFixture]
	public class UnitTest
	{
		public UnitTest()
		{
		}

		
		/// <summary>
		/// TestFixtureSetUp and TestFixtureTearDown are provided for use when performance
		/// considerations make it inconvenient to use SetUp and TearDown, which are run 
		/// for each test case. Users should consider that use of these attributes leads 
		/// to greater interdependency between tests. In general, use SetUp and TearDown 
		/// in preference to these attributes.
		/// </summary>
		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			//Console.WriteLine("TestFixtureSetUp");
		}

		[SetUp]
		public void SetUp()
		{
			//Console.WriteLine("SetUp");
		}

		[TearDown]
		public void TearDown()
		{
			//Console.WriteLine("TearDown");
		}

		[TestFixtureTearDown]
		public void TestFixtureTearDown()
		{
			//Console.WriteLine("TestFixtureTearDown");
		}

		[Test]
		[Ignore("Can't instantiate BaseMapSite, therefore nothing to test")]
		public void TestBaseMapSite()
		{
			//this class cannot be instantiated
			//site.Bounds.
			//site.
		}

		[Test]
		public void CreateBaseWall()
		{
			BaseWall wall = new BaseWall();
			Assert.AreEqual(typeof(BaseWall),wall.GetType());
			Assert.AreEqual(new RectangleF(0,0,0,0),wall.Bounds);
			Assert.AreEqual(new PointF(0,0),wall.Coordinates);
			Assert.AreEqual(4,wall.Neighbors.Length,"there should be 4 neighbors");
			foreach (IMapSite neighbor in wall.Neighbors)
				Assert.IsNull(neighbor,"all neighbors should be null");
		}

		[Test]
		[Ignore("Not implemented")]
		public void CreateWall()
		{

			/*BaseWall wall = new Wall();
			Assert.AreEqual(typeof(BaseWall),wall.GetType());
			Assert.AreEqual(new RectangleF(0,0,0,0),wall.Bounds);
			Assert.AreEqual(new PointF(0,0),wall.Coordinates);
			Assert.AreEqual(4,wall.Neighbors.Length,"there should be 4 neighbors");
			foreach (IMapSite neighbor in wall.Neighbors)
				Assert.IsNull(neighbor,"all neighbors should be null");*/
		}

		[Test]
		public void TestDirection()
		{
			//verify that the Direction objects match the corresponding Compass enumeration
			Assert.IsTrue(Compass.East==Direction.East);
			Assert.IsTrue(Compass.West==Direction.West);
			Assert.IsTrue(Compass.North==Direction.North);
			Assert.IsTrue(Compass.South==Direction.South);

			//verify that the Direction opposites are correct
			Assert.AreEqual(Direction.West,Direction.East.opposite);
			Assert.AreEqual(Direction.East,Direction.West.opposite);
			Assert.AreEqual(Direction.North,Direction.South.opposite);
			Assert.AreEqual(Direction.South,Direction.North.opposite);

			//verify that the Direction string conversions are correct
			Assert.AreEqual("West",Direction.West.ToString());
			Assert.AreEqual("East",Direction.East.ToString());
			Assert.AreEqual("South",Direction.South.ToString());
			Assert.AreEqual("North",Direction.North.ToString());

			//verify that there are 4 directions in the Directions array
			//and that all 4 directions are listed
			Assert.AreEqual(4,Direction.Directions.Length);
			StringBuilder sb = new StringBuilder();
			foreach (Direction d in Direction.Directions)
				sb.Append(d.ToString());
			String s = sb.ToString();
			Assert.IsTrue(s.IndexOf("West") != -1);
			Assert.IsTrue(s.IndexOf("East") != -1);
			Assert.IsTrue(s.IndexOf("North") != -1);
			Assert.IsTrue(s.IndexOf("South") != -1);
			
			Direction d1 = Direction.East;
			d1 = Direction.West;
			d1 = d1.opposite;
			d1 = Compass.North;
		}

		[Test]
		[ExpectedException(typeof(ApplicationException))]
		public void TestInvalidDirection()
		{
			Direction d1 = 4;
			Direction d2 = d1.opposite;
		}

		[Test]
		public void TestSquareMazeCreate()
		{
			SquareMaze m = new SquareMaze();
			m.CreateMaze(10);
			Assert.AreEqual(100,m.Rooms.Length);
			Assert.AreEqual(2,m.Rooms.Rank);
			AssertMazeCreationTime(m.Rooms.GetLength(0),60,m.AlogorithmTime.Milliseconds);

			m.CreateMaze(20);
			Assert.AreEqual(400,m.Rooms.Length);
			Assert.AreEqual(2,m.Rooms.Rank);
			AssertMazeCreationTime(m.Rooms.GetLength(0),1000,m.AlogorithmTime.Milliseconds);

			Console.WriteLine("Bounds: {0}",m.Bounds);
			Console.WriteLine("FinishRoom: {0}",m.FinishRoom);
			Console.WriteLine("StartRoom: {0}",m.StartRoom);
			Console.WriteLine("PassCount: {0}",m.PassCount);
			
		}

		public void AssertMazeCreationTime(int size, int ExpectedMS, int ActualMS)
		{
			Assert.IsTrue(ActualMS<=ExpectedMS,String.Format("{2}x{2} maze took {0} milliseconds to create, should be no more than {1}",ActualMS,ExpectedMS,size));
		}
	}
}
