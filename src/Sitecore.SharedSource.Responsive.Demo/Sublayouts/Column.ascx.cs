using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sitecore.SharedSource.Responsive.Demo.Sublayouts
{
    public partial class Column : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            label.Control = this;
        }
    }
}