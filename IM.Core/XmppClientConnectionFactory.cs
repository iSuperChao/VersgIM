using agsXMPP;
using agsXMPP.protocol.client;
using agsXMPP.Xml.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IM.Core
{
    public class XmppClientConnectionFactory
    {

        private static XmppClientConnection xmppClientConn;
        public static XmppClientConnection CreateXmppClientConnection()
        {

            xmppClientConn = new XmppClientConnection();
         
            xmppClientConn.OnError += new ErrorHandler((object sender, Exception ex) =>
            {
                Application.Exit();
            });

            agsXMPP.Factory.ElementFactory.AddElementType("Info", "agsoftware:Info", typeof(IMMemberInfo));

            return xmppClientConn;

        }

    }
}
