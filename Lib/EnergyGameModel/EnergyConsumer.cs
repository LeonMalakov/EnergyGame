namespace EnergyGameModel
{
    class EnergyConsumer : IEnergyObject
    {
        public int UseEnergy { get; set; }

        public int Fine { get; set; }

        public int FineSinceTurn { get; set; }
   
    }
}
