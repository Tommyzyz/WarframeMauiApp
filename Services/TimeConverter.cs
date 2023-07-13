namespace WarframeMauiApp.Services;


public static class TimeConverter
{
    public static string UpdateTimeLift(ref int TimeLeft)
    {
        TimeLeft--;
        return SecondstoTimesString(TimeLeft);
    }

    public static string SecondstoTimesString(int time)
    {
        var h = time / (60 * 60);
        var m = (time % (60 * 60)) / 60;
        var s = (time % (60 * 60)) % 60;
        return h.ToString() + ":" + m.ToString() + ":" + s.ToString();

    }

    public static int getliftSeconds(string lifttime)
    {
        var a = lifttime;
        int time;
        var b = a.Split(new char[4] { ',', 'h', 'm', 's' });


        if (b.LongLength == 4)
        {
            var h = int.Parse(b[0]);
            var m = int.Parse(b[1]);
            var s = int.Parse(b[2]);
            time = h * 60 * 60 + m * 60 + s;
        }
        else if (b.LongLength == 3)
        {
            var h = 0;
            var m = int.Parse(b[0]);
            var s = int.Parse(b[1]);
            time = h * 60 * 60 + m * 60 + s;
        }
        else if (b.LongLength == 2)
        {
            var h = 0;
            var m = 0;
            var s = int.Parse(b[0]);
            time = h * 60 * 60 + m * 60 + s;
        }
        else
        {
            return -1;
        }

        return time;
    }
}
