namespace DelegateDemo
{
    internal class Assistant
    {
        public required string Name { get; set; }

        public string AssistTrainer(FacilityInvoker facilityInvoker, int count)
        {
            return facilityInvoker(count);
        }
    }
}
