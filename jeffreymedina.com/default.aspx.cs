using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jeffreymedina.com
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            footeryear.Text = dt.Year.ToString();
        }
    }
}