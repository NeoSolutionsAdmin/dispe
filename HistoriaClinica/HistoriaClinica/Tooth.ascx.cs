using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke;
using ConnectionDispensario.Modelos;

namespace Christoc.Modules.HistoriaClinica
{
    public partial class Tooth : System.Web.UI.UserControl
    {

        int mycool;
        Diente D = null;
        
        public void  SetTooth(int cool=0) 
        {
            mycool = cool;
            ToothData.ClientIDMode = ClientIDMode.Static;
            ContainerTooth.ClientIDMode = ClientIDMode.Static;
           

        }

        public void SetState(ConnectionDispensario.Modelos.Diente p_D)
        {
            D = p_D;
            ContainerTooth.ID = "ContainerToothLoaded";
            ToothData.Attributes["value"] = p_D.Estadodiente;
            Page_Load(this,null);
           
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            numeroElemento.InnerText = mycool.ToString();
            this.numeroElemento.ClientIDMode = ClientIDMode.Static;
            if (D == null)
            {
                toothstate.Attributes["value"] = "new";
            }
            else
            {
                toothstate.Attributes["value"] = "loaded";
                
                
            }
        }
    }
}