namespace ConsoleApp26.CalcLibrary
{
    public interface ISmsService
    {
        string GetAdminNumber();
        void SendSms(string message, string phone);
    }
}