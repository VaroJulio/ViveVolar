using System.Configuration;

namespace Common.Auxiliares
{
    public static class AuxiliarViveVolar
    {
        public static string ObtenerAtributoDeConfiguracion(string llaveAtributo, bool esObligatorio)
        {
            string valor = ConfigurationManager.AppSettings.Get(llaveAtributo);

            if (valor == null && esObligatorio)
            {
                throw new ViveVolarException("ViveVolarError_MensajeValorConfiguracion", llaveAtributo);
            }

            return valor;
        }

        public static string TraducirMensaje(string claveMensaje, params object[] args)
        {
            string mensaje = TraducirMensaje(claveMensaje);
            string mensajeTraducido = (args != null) ? string.Format(mensaje, args) : mensaje;
            return mensajeTraducido;
        }
    }
}
