using agsXMPP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IM
{
    public partial class frmLogin : Form
    {
        XmppClientConnection xmppConn;
        public frmLogin(XmppClientConnection conn)
        {
            InitializeComponent();
            this.xmppConn = conn;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            xmppConn.Username = "";
            xmppConn.Server = "xingliao.versg.com";
            xmppConn.Password ="";
            xmppConn.Port = 5222;
            xmppConn.Resource = "Resource";
            this.DialogResult = DialogResult.OK;
        }
    }
}
