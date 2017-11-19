using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Data2.Class
{
    public class Struct_DetalleCuentaCorriente
    {
        public enum TipoDetalleCC { Entrega, Factura, Inicializacion, ErrorEnMovimiento }
        public DateTime Fecha;
        public TipoDetalleCC TIPOCC;
        public decimal Monto;
        public int IdFactura=0;

        public Struct_DetalleCuentaCorriente(DataRow DR, int IdUser)
        {
            Fecha = DateTime.Parse(DR["Fecha"].ToString());
            Monto = Statics.Conversion.GetDecimal(DR["Importe"].ToString());
            switch (DR["TipoMovimiento"].ToString())
            {
                case "F":
                    TIPOCC = TipoDetalleCC.Factura;
                    Connection.D_Factura CONN = new Connection.D_Factura();
                    int IdF = int.Parse(DR["IdFactura"].ToString());
                    IdFactura = IdF;
                    DataRow _DR = CONN.GetFacturaById(IdUser, IdF);
                    Monto = new Struct_Factura(_DR).total;
                    break;
                case "I":
                    TIPOCC = TipoDetalleCC.Inicializacion;
                    break;
                case "E":
                    TIPOCC = TipoDetalleCC.Entrega;
                    break;
                    default:
                        TIPOCC=TipoDetalleCC.ErrorEnMovimiento;
                        break;
            }


        }





    }
}
