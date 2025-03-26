using ChainOfResponsibilityEx.Ex;

namespace ChainOfResponsibilityEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tier1 Max = new Tier1();
            Tier2 JohnGutter = new Tier2();
            Tier3 DrCoomer = new Tier3();
            Tier4 Gaster = new Tier4();
            Tier666 BlackDoom = new Tier666();

            Max.setSuccessor(JohnGutter);
            JohnGutter.setSuccessor(DrCoomer);
            DrCoomer.setSuccessor(Gaster);
            Gaster.setSuccessor(BlackDoom);

            SupportTicket sampleTicket = new SupportTicket(1, SupportTicket.TicketType.Basic);
            Max.HandleRequest(sampleTicket);

            SupportTicket sampleTicket = new SupportTicket(2, SupportTicket.TicketType.InDepth);
            Max.HandleRequest(sampleTicket);

            SupportTicket sampleTicket = new SupportTicket(3, SupportTicket.TicketType.Advanced);
            Max.HandleRequest(sampleTicket);

            SupportTicket sampleTicket = new SupportTicket(4, SupportTicket.TicketType.Vendor);
            Max.HandleRequest(sampleTicket);

            SupportTicket sampleTicket = new SupportTicket(5, SupportTicket.TicketType.Evil);
            Max.HandleRequest(sampleTicket);

            SupportTicket sampleTicket = new SupportTicket(6, SupportTicket.TicketType.Unknown);
            Max.HandleRequest(sampleTicket);
        }
    }
}
