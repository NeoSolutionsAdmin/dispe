using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data2.Class
{
    public class Struct_Remito
    {
        public int UserId;
        public Struct_Supplier Supplier;

        string NumeroRemito;
        public List<Struct_DetalleRemito> ListaArticulos = new List<Struct_DetalleRemito>();
        public int IdRemito;
        public int IdProveedor;
        public DateTime Fecha;
        public decimal total;

        public static Struct_Remito Get_Remito(int IdRemito, int IdUser) 
        {
            Connection.D_Remito R = new Connection.D_Remito();
            System.Data.DataRow DR = R.Get_RemitoById(IdRemito, IdUser);
            if (DR != null)
            {
                return new Struct_Remito(DR);
            }
            else 
            {
                return null;
            }
        }

        public List<Struct_DetalleRemito> GetAndFillDetalle()
        {
            ListaArticulos = new List<Struct_DetalleRemito>();
            Data2.Connection.D_Remito D = new Connection.D_Remito();
            System.Data.DataTable DT = D.Get_DetalleRemito(IdRemito);
            if (DT != null) 
            {
                foreach (System.Data.DataRow DR in DT.Rows) 
                {
                    ListaArticulos.Add(new Struct_DetalleRemito(DR,UserId));
                }
                if (ListaArticulos.Count>0)
                {
                    return ListaArticulos;
                } else 
                {
                    return null;
                }
            } else 
            {
                return null;
            }
        }
        

        public Struct_Remito(System.Data.DataRow DR) 
        {
            IdRemito = int.Parse(DR["Id"].ToString());
            UserId = int.Parse(DR["IdUser"].ToString());
            IdProveedor = int.Parse(DR["IdProveedor"].ToString());
            Supplier = new Struct_Supplier(UserId, IdProveedor);
            NumeroRemito = DR["NroRemito"].ToString();
            Fecha = DateTime.Parse(DR["Fecha"].ToString());
            total = Statics.Conversion.GetDecimal(DR["Total"].ToString());

            

        }

        public static List<Struct_Remito> GetAllRemitos(int UserId) 
        {
            List<Struct_Remito> SR;
            Connection.D_Remito DR = new Connection.D_Remito();
            System.Data.DataTable DT = DR.Select_allRemitos(UserId);
            if (DT != null && DT.Rows.Count > 0)
            {
                SR = new List<Struct_Remito>();
                for (int a = 0; a < DT.Rows.Count; a++)
                {
                    SR.Add(new Struct_Remito(DT.Rows[a]));
                }
                return SR;
            }
            else 
            {
                return null;
            }
        }

        public bool SaveRemito() 
        {
            bool falla = true;
            Connection.D_Remito R = new Connection.D_Remito();
            decimal total = 0;
            if (ListaArticulos != null && ListaArticulos.Count > 0)
            {
                for (int a = 0; a < ListaArticulos.Count; a++)
                {
                    total = total + ListaArticulos[a].getTotal();
                }
                IdRemito = R.insert_Remito(UserId, Supplier.Id, NumeroRemito, DateTime.Now, total);
                if (IdRemito != 0)
                {
                    for (int a = 0; a < ListaArticulos.Count; a++)
                    {
                       bool detected = ListaArticulos[a].SaveDetalle(IdRemito);

                       if (detected == false)
                       {
                           falla = false;
                           break;
                       }
                       else 
                       {
                           ListaArticulos[a].SaveNewStock();
                       }
                    }
                    return falla;
                }
                else 
                {
                    return false;
                }
            }
            else 
            {
                return false;
            }
        }

        public string NUMEROREMITO
        {
            get { return NumeroRemito; }
            set { NumeroRemito = value; }
        }

        public Struct_Supplier set_SUPPLIER(int idSupplier)
        {
            Supplier = new Struct_Supplier(UserId, idSupplier);
            if (Supplier != null)
            {
                return Supplier;
            }
            else 
            {
                return null;
            }
        }

        public bool AddArticle(int IdArt, string CANT)
        {
            ListaArticulos.Add(new Struct_DetalleRemito(IdArt, UserId, CANT));
            if (ListaArticulos[ListaArticulos.Count - 1].P != null)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public Struct_Supplier get_SUPPLIER() 
        {
            return Supplier;
        }

        public Struct_Remito(int p_UserId) 
        {
            UserId = p_UserId;
        }

       
    }
}
