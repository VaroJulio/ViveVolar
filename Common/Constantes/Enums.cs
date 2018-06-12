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
        IdAeropuerto,
        CodMundial,
        IdOrigenDestino
    }

    public enum EsOrigenODestino
    {
        NoAplica,
        EsOrigen,
        EsDestino
    }

    public enum FiltroVueloOrigen
    {
        IdOrigen,
        IdCiudadOrigen,
        IdPaisOrigen
    }

    public enum FiltroVueloDestino
    {
        IdDestino,
        IdCiudadDestino,
        IdPaisDestino
    }
}
