using ADOWinForms.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOWinForms.ADO
{
    public interface ICRUD
    {
        List<EstatusAlumno> Consultar();
        EstatusAlumno Consultar(int id);
        int Agregar(EstatusAlumno estatus);
        void Actulizar(EstatusAlumno estatus);
        void Eliminar(EstatusAlumno estatus);
    }
}
