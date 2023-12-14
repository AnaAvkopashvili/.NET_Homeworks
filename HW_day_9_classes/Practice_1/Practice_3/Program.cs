namespace Practice_3
{
    internal class Clock
    {
        int _Hour;
        int _Minute;
        int _Second;

        public int Hour 
        {  get
            {
                return _Hour;
            }
            set 
            {
                if (value <= 23 && value >= 0)
                    _Hour = value;
                else
                    Console.WriteLine("Invalid input");
            }
        }
        public int Minute
        {
            get
            {
                return _Minute;
            }
            set
            {
                if (value <= 59 && value >= 0)
                    _Minute = value;
                else
                    Console.WriteLine("Invalid input");
            }
        }
        public int Second
        {
            get
            {
                return _Second;
            }
            set
            {
                if (value <= 59 && value >= 0)
                    _Second = value;
                else
                    Console.WriteLine("Invalid input");
            }
        }
        public void AddSecond(int hour, int minute, int second)
        {
            if (Second == 59)
            {
                Second = 0;
                AddMinute(hour, minute, second);    
            }
            else
                Second += 1;
        }
        public void AddMinute(int hour, int  minute, int second)
        {
            if (Minute == 59)
            {
                Minute = 0;
                AddHour(hour, minute, second);
            }
            else
                Minute += 1;
        }
        public void AddHour(int hour, int minute, int second)
        {
            if (Hour == 23)
            {
                Hour = 0;
            }
            else
                Hour += 1;
        }
        static void GetCurrentTime(int hour, int minute, int second)
        {
            string formattedMinute = "";
            string formattedHour = "";
            string formattedSecond = "";
            if (minute < 10)
                formattedMinute = $"0{minute}";
            else
                formattedMinute = minute.ToString();
            if (hour < 10)
                formattedHour = $"0{hour}";
            else
                formattedHour = hour.ToString();
            if (second < 10)
                formattedSecond = $"0{second}";
            else
                formattedSecond = second.ToString();
            Console.WriteLine($"{formattedHour}:{formattedMinute}:{formattedSecond}");
        }

        static void Main(string[] args)
        {
            Clock clock = new Clock();
            Console.Write("Enter hour: ");
            clock.Hour = int.Parse(Console.ReadLine());
            Console.Write("Enter minute: ");
            clock.Minute = int.Parse(Console.ReadLine());
            Console.Write("Enter second: ");
            clock.Second = int.Parse(Console.ReadLine());
            GetCurrentTime(clock.Hour, clock.Minute, clock.Second);
            clock.AddMinute(clock.Hour, clock.Minute, clock.Second);
            clock.AddHour(clock.Hour, clock.Minute, clock.Second);
            clock.AddSecond(clock.Hour, clock.Minute, clock.Second);
            GetCurrentTime(clock.Hour, clock.Minute, clock.Second);
        }
    }
}