using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Constantes
{
    public enum TipoInicializador
    {
        Ninguno,
        NoExiste,
        ModeloCambio,
        Siempre,
        Migracion
    }

    public enum FiltroGeografico
    {
        IdPais,
        IdEstado,
        IdCiudad,
    }

    public enum FiltroAeropuerto
    {
        IdMundial,
        IdOrigenDestino
    }

    public enum EsOrigenODestino
    {
        NoAplica,
        EsOrigen,
        EsDestino
    }
}
