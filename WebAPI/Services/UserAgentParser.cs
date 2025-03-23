using UAParser;

namespace WebAPI.Services;

public class UserAgentParser
{
    public static string GetBrowserInfo(string userAgent)
    {
        var uaParser = Parser.GetDefault();
        ClientInfo client = uaParser.Parse(userAgent);
        Console.WriteLine(client.UA.ToString());

        return $"{client.UA.Family} {client.UA.Major}.{client.UA.Minor}";
    }
}