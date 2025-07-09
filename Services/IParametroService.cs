using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlIngresoApp.Model;
using ControlIngresoApp.Shared.DTOs;

namespace ControlIngresoApp.Client.Services
{
  public interface IParametroService
  {

    Task<List<ParametroDTO>> ObtenerValorParametroAsync(string codParametro);
    Task<List<PaisDTO>> ObtenerPaisesAsync();
    }
}