using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlIngresoApp.Model;
using ControlIngresoApp.Shared.DTOs;

namespace ControlIngresoApp.Client.Services
{
    public interface IPersonaService
    {

        Task<List<PersonaDTO>> ObtenerPersonasByDocumentoNombreApellidoAsync(string documento, string nombre, string apellido);
        Task<int> CrearPersonaAsync(PersonaCreateDTO nuevaPersona);
        Task<int> ActualizarPersonaAsync(PersonaUpdateDTO persona);

        Task<int> ActualizarEstadoPersonaAsync(PersonaUpdateEstadoDTO persona);
        
    }
}