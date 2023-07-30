namespace UserManagement.Utility
{
    public interface IHttpPostMessage
    {
        void SendMessage(string token, string json);
    }
}
