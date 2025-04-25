namespace DelegateDemo
{
    internal class Trainer
    {
        public required Assistant Assistant { get; set; }

        public void UseFacilities()
        {
            Facilities facilities = new();
            FacilityInvoker markerInvoker = new(facilities.GetMarker);
            Console.WriteLine(Assistant.AssistTrainer(markerInvoker, 2));
        }
    }
}
