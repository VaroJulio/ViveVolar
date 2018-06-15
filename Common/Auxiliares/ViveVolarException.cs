using System;

namespace Common.Auxiliares
{
    [Serializable]
    public class ViveVolarException : Exception
    {
        public ViveVolarException(string messageKey, params object[] parameters)
            : base(AuxiliarViveVolar.TraducirMensaje(messageKey, parameters)) { }
    }
}
