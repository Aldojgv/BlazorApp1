using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlIngresoApp.Model;
using ControlIngresoApp.Shared.DTOs;

namespace ControlIngresoApp.Client.Services
{
    public interface IEmpresaService
    {
   
    Task<List<EmpresaDTO>> ObtenerEmpresasAsync();


    }
}