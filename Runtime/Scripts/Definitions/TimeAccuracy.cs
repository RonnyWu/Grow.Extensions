namespace Grow.Extensions
{
    public enum TimeAccuracy
    {
        Tick, // 100 nanoseconds = 1 tick
        Ns,   // 1000 nanoseconds = 1 microsecond
        Us,   // 1000 microseconds = 1 millisecond
        Ms,   // 1000 milliseconds = 1 second
        Sec   // 1 second
    }
}