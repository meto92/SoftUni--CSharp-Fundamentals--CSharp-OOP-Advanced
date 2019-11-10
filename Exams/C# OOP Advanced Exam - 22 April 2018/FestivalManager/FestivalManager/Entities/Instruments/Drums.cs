namespace FestivalManager.Entities.Instruments
{
    public class Drums : Instrument
    {
        private const int DrumsRepairAmunt = 20;

        protected override int RepairAmount => DrumsRepairAmunt;
    }
}