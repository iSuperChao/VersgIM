using agsXMPP;
using agsXMPP.protocol.client;
using agsXMPP.Xml.Dom;
using IM.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IM
{
    public partial class frmMain : Form
    {
        private XmppClientConnection xmppConn;

        delegate void OnMessageDelegate(object sender, agsXMPP.protocol.client.Message msg);
        delegate void OnIqDelegate(object sender, Node e);
        delegate void OnPresenceDelegate(object sender, Presence pres);
        delegate void OnMeetingDelegate(object sender, Presence pres);


        public frmMain()
        {
            InitializeComponent();

            xmppConn = XmppClientConnectionFactory.CreateXmppClientConnection();
            xmppConn.OnLogin += new ObjectHandler(xmppConn_OnLogin);
            xmppConn.OnRosterItem += new agsXMPP.XmppClientConnection.RosterHandler(xmppConn_OnRosterItem);
            xmppConn.OnMessage += new MessageHandler(xmppConn_OnMessage);
            xmppConn.OnPresence += new PresenceHandler(xmppConn_OnPresence);
            xmppConn.OnIq += new IqHandler(xmppConn__OnIq);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin(xmppConn);
            if (login.ShowDialog() == DialogResult.OK)
            {
                Thread mythread = new Thread(()=> { xmppConn.Open(); });
                mythread.Start();
                login.ShowDialog();
            }
            else
            {
                this.Close();
                Application.Exit();
            }
        }
        private void xmppConn_OnLogin(object sender)
        {
            //发送在线状态给其他用户
            xmppConn.Show = ShowType.chat;
            xmppConn.SendMyPresence();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void xmppConn_OnRosterItem(object sender, agsXMPP.protocol.iq.roster.RosterItem item)
        {
            if (InvokeRequired)
            {
              		
                BeginInvoke(new agsXMPP.XmppClientConnection.RosterHandler(xmppConn_OnRosterItem), new object[] { this, item });
                return;
            }
            //获取好友列表

            //TODO
        }


        private void xmppConn_OnMessage(object sender, agsXMPP.protocol.client.Message msg)
        {
            if (InvokeRequired)
            {			
                BeginInvoke(new OnMessageDelegate(xmppConn_OnMessage), new object[] { sender, msg });
                return;
            }
            //处理点对点聊天消息
            if (msg.Type == MessageType.chat)
            {
            }
            //处理群聊消息
            if (msg.Type == MessageType.groupchat)
            {
                
            }
        }

        private void xmppConn_OnPresence(object sender, Presence pres)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new OnPresenceDelegate(xmppConn_OnPresence), new object[] { sender, pres });
                return;
            }
            //用户上线消息
            if (pres.Show == ShowType.chat)
            {
               
            }
            //用户下线消息
            else if (pres.Type == PresenceType.unavailable)
            {
               
            }
            //会议创建消息
            else if (pres.Type == PresenceType.probe)
            {
               
            }
            //会议取消消息
            else if (pres.Type == PresenceType.invisible)
            {
                
            }
            //用户登入会议消息
            else if (pres.Type == PresenceType.subscribe)
            {
                
            }
            //用户退出会议消息
            else if (pres.Type == PresenceType.unsubscribe)
            {
               
            }
        }

        private void xmppConn__OnIq(object sender, Node e)
        {
            if (InvokeRequired)
            {
               		
                BeginInvoke(new OnIqDelegate(xmppConn__OnIq), new object[] { sender, e });
                return;
            }

        }
    }
}
