public class Alarm : IAlarm
{
    private const double LowPressureThreshold = 17;
    private const double HighPressureThreshold = 21;

    private readonly ISensor _sensor;
    private bool _alarmOn;

    public Alarm(ISensor sensor)
    {
        _sensor = sensor;
        _alarmOn = false;
    }

    public void Check()
    {
        double psiPressureValue = _sensor.PopNextPressurePsiValue();

        if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
        {
            _alarmOn = true;
        }
    }

    public bool AlarmOn => _alarmOn;
}