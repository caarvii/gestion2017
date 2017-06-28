using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Facturacion
{
    class ItemFactura
    {
        public int viajeId { get; set; }
        public String viajeDesc { get; set; }
        public double viajeCosto { get; set; }

        public ItemFactura(int viajeId, String viajeDesc, double viajeCosto)
        {
            this.viajeId = viajeId;
            this.viajeDesc = viajeDesc;
            this.viajeCosto = viajeCosto;
        }
    }
}
