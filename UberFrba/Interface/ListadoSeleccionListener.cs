using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Dao;
using UberFrba.Dto;

namespace UberFrba.Interface
{
    public interface ListadoSeleccionListener
    {
        void onOperationFinishTurno(TurnoDTO turno);
        void onOperationFinishChofer(ChoferDTO chofer);
        void onOperationFinishCliente(ClienteDTO cliente);
        //void onOperationFinishChofer(TurnoDTO chofer);

       
    }
}
