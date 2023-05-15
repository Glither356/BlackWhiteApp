using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace BlackWhiteApp.Cods
{
    public class Server
    {
        private static string _nick = "Glither";

        private static TcpClient _client = new();

        public static TcpClient Client
        {
            get
            {
                return _client;
            }
        }

        public static string Nick
        {
            get
            {
                return _nick;
            }
        }

        public async static Task ConnectAsync() =>
             await _client.ConnectAsync("139.28.222.132", 8888);

        public async static Task Disconect() =>
            _client.Close();

        public static async Task<int> getDiamondOre(string name)
        {
            var stream = _client.GetStream();
            var response = new List<byte>();

            int bytesRead;
            string number;
            string answer;
            string fullAnswer;

            var text = Encoding.UTF8.GetBytes("giveAP*&" + name + '\n');

            await stream.FlushAsync();

            await stream.WriteAsync(text);

            while ((bytesRead = stream.ReadByte()) != '\n')
                response.Add((byte)bytesRead);

            answer = Encoding.UTF8.GetString(response.ToArray());
            fullAnswer = Encoding.UTF8.GetString(response.ToArray());

            if (answer != "DIAMOND_ORES"
                && !answer.Contains('|'))
                return 0;

            number = fullAnswer.Remove(0, fullAnswer.IndexOf('*') + 1);
            number = number.Substring(0, number.IndexOf(';'));

            return int.Parse(number);
        }

        public static async Task<bool> sendOfAP(string nameSender, string nameRecipient, int countOfAP)
        {
            var stream = _client.GetStream();
            var response = new List<byte>();

            int bytesRead;
            string answer;

            var text = Encoding.UTF8.GetBytes("send*" + $";{nameRecipient}" + $"/{countOfAP}" + $"&{nameSender}" + '\n');

            await stream.FlushAsync();

            await stream.WriteAsync(text);

            while ((bytesRead = stream.ReadByte()) != '\n')
                response.Add((byte)bytesRead);

            answer = Encoding.UTF8.GetString(response.ToArray());

            if (answer == "send_accept-" + nameSender)
                return true;

            return false;
        }

        public static async Task<bool> getLogin(string name)
        {

            _nick = name;

            var stream = _client.GetStream();
            var response = new List<byte>();

            int bytesRead;
            string answer;

            var cmd = $"LoginCheck*&{name}"+'\n';

            await stream.FlushAsync();
            await stream.WriteAsync(Encoding.UTF8.GetBytes(cmd));

            while ((bytesRead = stream.ReadByte()) != '\n')
                response.Add((byte)bytesRead);

            answer = Encoding.UTF8.GetString(response.ToArray());

            if (answer == $"LoginCheck{name}true")
                return true; 
            else if(answer != $"LoginCheck{name}true")
                return false;

            return false;
        }

        public static async Task<bool> getRegiser(string name)
        {
            _nick = name;

            var stream = _client.GetStream();
            var response = new List<byte>();

            int bytesRead;
            string answer;

            var cmd = $"Refister*&{name}" + '\n';

            await stream.FlushAsync();
            await stream.WriteAsync(Encoding.UTF8.GetBytes(cmd));

            while ((bytesRead = stream.ReadByte()) != '\n')
                response.Add((byte)bytesRead);

            answer = Encoding.UTF8.GetString(response.ToArray());

            if (answer == $"Register&{name}*True")
                return true;
            else if (answer != $"Register&{name}*True")
                return false;

            return false;
        }
    }
}
