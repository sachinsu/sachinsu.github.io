using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Org.BouncyCastle.Tls.Crypto.Impl.BC;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Tls;


 class CustomTlsClient : DefaultTlsClient
{
    public CustomTlsClient():   base(new BcTlsCrypto()) {}
    public override TlsAuthentication GetAuthentication() => new CustomTlsAuthentication();
}

 class CustomTlsAuthentication : TlsAuthentication
{
    public TlsCredentials GetClientCredentials(CertificateRequest certificateRequest) => null;
 
    public void NotifyServerCertificate(TlsServerCertificate serverCertificate)
    {
        
    }
}

 class Program
    {
        const string ServerName = "txuat.mrlpay.com";
        const string UrlnQuery = "/BFL_QR/bqrcallback.php";
  private static void WriteUtf8Line(Stream output, string line)
        {
            byte[] buf = Encoding.UTF8.GetBytes(line + "\r\n");
            output.Write(buf, 0, buf.Length);
            Console.WriteLine(">>> " + line);
        }
        
        static void Main(string[] args)
        {
            using (var client = new TcpClient(ServerName, 443))
            {
                var sr = new SecureRandom();
                // var cl = new CustomTlsClient();
                TlsClientProtocol protocol = new TlsClientProtocol(client.GetStream());
                protocol.Connect(new CustomTlsClient());

                using (var stream = protocol.Stream)
                {
                   var hdr = new StringBuilder();
                    hdr.AppendFormat("GET {0} HTTP/1.1\r\n",UrlnQuery);
                    hdr.AppendFormat("Host: {0}\r\n",ServerName);
                    hdr.AppendLine("Content-Type: text/html; charset=utf-8");
                    hdr.AppendLine("Connection: close");
                    hdr.AppendLine();

                    var dataToSend = Encoding.UTF8.GetBytes(hdr.ToString());
                    hdr.Clear();

                    stream.Write(dataToSend, 0, dataToSend.Length);
            
                    int totalRead = 0;
                    string response = "";
                    byte[] buff = new byte[1000];
                    do
                    {
                        totalRead = stream.Read(buff, 0, buff.Length);
                        response += Encoding.ASCII.GetString(buff, 0, totalRead);
                    } while (totalRead == buff.Length);

                    Console.WriteLine(response);
                }
            }
        }
    }