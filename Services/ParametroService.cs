using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ControlIngresoApp.Model;
using ControlIngresoApp.Shared.DTOs;

namespace ControlIngresoApp.Client.Services
{
    public class ParametroService : IParametroService
    {
    private readonly HttpClient _http;

    public ParametroService(HttpClient http)
    {
        _http = http;
    }
        public async Task<List<PaisDTO>> ObtenerPaisesAsync()
        {
            var response = await _http.GetFromJsonAsync<List<PaisDTO>>("Pais/paises");
            return response ?? new List<PaisDTO>();

        }

        public async Task<List<ParametroDTO>> ObtenerValorParametroAsync(string codParametro)
        {
            var response = await _http.GetFromJsonAsync<List<ParametroDTO>>($"Parametro/{codParametro}");
            return response?? new List<ParametroDTO>();
        }
    }
}