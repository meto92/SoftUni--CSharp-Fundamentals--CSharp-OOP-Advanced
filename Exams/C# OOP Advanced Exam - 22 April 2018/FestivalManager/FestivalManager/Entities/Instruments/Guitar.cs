namespace FestivalManager.Entities.Instruments
{
    public class Guitar : Instrument
    {
        private const int GuitarRepairAmunt = 60;

        protected override int RepairAmount => GuitarRepairAmunt;
    }
}