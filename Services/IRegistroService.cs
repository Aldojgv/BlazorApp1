using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlIngresoApp.Model;
using ControlIngresoApp.Shared.DTOs;
namespace ControlIngresoApp.Client.Services
{
    public interface IRegistroService
    {
        Task<List<RegistroDTO>> ObtenerRegistrosByFechaAsync(string fechaIngreso);
        Task<int> CrearRegistroAsync(RegistroCreateDTO registro);
    }
}