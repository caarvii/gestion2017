using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Dto;

namespace UberFrba.Interface
{
    public interface ListadoSeleccionListener
    {
        void onOperationFinish(TurnoDTO turno);

        //void onOperationFinishChofer(TurnoDTO chofer);


    }
}
