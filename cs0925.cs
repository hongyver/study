using System;

namespace Study
{
	class Point
	{
		int x, y;

		public Point(int x, int y)
		{
			this.x =x; this.y = y;
		}

		public override string ToString()
		{
			return "X:"+x+" Y:"+y;
		}
	};

	abstract class DrawingObject
	{
		public abstract void Draw();
		public void Move() { Console.WriteLine("Move"); }
	};

	class Line : DrawingObject
	{
		Point pt1, pt2;

		public Line(Point pt1, Point pt2)
		{
			this.pt1 = pt1;
			this.pt2 = pt2;
		}

		public override void Draw()
		{
			Console.WriteLine("Line "+pt1.ToString()+" ~ "+pt2.ToString());
		}
	};

	class Study
	{
		static void Main(string[] args)
		{
			DrawingObject line = new Line(new Point(10,10), new Point(20,20));

			line.Draw();
		}
	};
}
