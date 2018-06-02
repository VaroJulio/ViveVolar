using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Auxiliares
{
    public class ViveVolarException : ApplicationException
    {
        public ViveVolarException(string messageKey, params object[] parameters)
            : base(AuxiliarViveVolar.TraducirMensaje(messageKey, parameters)) { }
    }
}
