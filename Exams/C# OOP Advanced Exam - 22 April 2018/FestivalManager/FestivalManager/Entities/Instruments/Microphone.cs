namespace FestivalManager.Entities.Instruments
{
    public class Microphone : Instrument
    {
        private const int MicrophoneRepairAmunt = 80;

        protected override int RepairAmount => MicrophoneRepairAmunt;
    }
}