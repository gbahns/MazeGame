using System;
using System.Drawing;

namespace MazeGame
{
	/// <summary>
	/// SolidRock represents ubiquitous impassable space
	/// this is a singleton class which is used as the adjacent site for
	/// rooms that cannot be exited in a given direction
	/// 
	/// the Enter and Leave methods do nothing
	/// by definition, you cannot enter solid rock
	/// </summary>
//	public class SolidRock : BaseWall
//	{
//		static public IMapSite Instance {get {return _instance;}}
//		private SolidRock() {}
//		static private SolidRock _instance = new SolidRock();
//	}
}
