using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading.Tasks;
using ControlIngresoApp.Model;
using ControlIngresoApp.Shared.DTOs;

namespace ControlIngresoApp.Client.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly HttpClient _http;

        public EmpresaService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<EmpresaDTO>> ObtenerEmpresasAsync()
        {
            try
            {
                var response = await _http.GetAsync("Empresa/empresas");

                if (response.IsSuccessStatusCode)
                {
                    var empresas = await response.Content.ReadFromJsonAsync<List<EmpresaDTO>>();
                    return empresas ?? new List<EmpresaDTO>();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener las empresas: {ex.Message}");
            }
            // Return an empty list if there was an exception or the response was not successful
            return new List<EmpresaDTO>();
        }
    }
}