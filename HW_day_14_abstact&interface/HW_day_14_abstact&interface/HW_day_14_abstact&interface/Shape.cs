namespace HW_day_14_abstact_interface
{
    abstract class Shape
    {
        public abstract double Perimeter();
        public abstract double Area();
        public double Distance(Point p1, Point p2) // ყველა კლასში ცალ ცალკე ეს მეთოდი აღარ
                                                   //დავაკოპირე და საერთო დავწერე ინტერფეისში და აბსტრაქტ კლასში
        {
            int distance = (int)(Math.Pow(p2.X - p1.X, 2)) + (int)(Math.Pow(p2.Y - p1.Y, 2));
            return Math.Sqrt(distance);
        }
    }
}