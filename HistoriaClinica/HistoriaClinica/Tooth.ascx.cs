using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Christoc.Modules.HistoriaClinica
{
    public partial class Tooth : System.Web.UI.UserControl
    {

        int mycool;
        public void  SetTooth(int cool=0) 
        {
            mycool = cool;
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            numeroElemento.InnerText = mycool.ToString();
        }
    }
}