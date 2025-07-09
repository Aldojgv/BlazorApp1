using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ControlIngresoApp.Model;
using ControlIngresoApp.Shared.DTOs;

namespace ControlIngresoApp.Client.Services
{
    public class RegistroService : IRegistroService
    {
        private readonly HttpClient _httpClient;
        public RegistroService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<List<RegistroDTO>> ObtenerRegistrosByFechaAsync(string fechaIngreso)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<RegistroDTO>>($"Registro/{fechaIngreso}");
                if (response != null)
                {
                    return response;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los registros por fecha: {ex.Message}");
                return new List<RegistroDTO>();
            }
            return new List<RegistroDTO>();
        }
        public async Task<int> CrearRegistroAsync(RegistroCreateDTO registro)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Registro", registro);
                if (response.IsSuccessStatusCode)
                {
                    int? registroCreado = await response.Content.ReadFromJsonAsync<int>();
                    if (registroCreado.HasValue && registroCreado.Value > 0)
                    {
                        Console.WriteLine("Registro creado exitosamente.");
                        return registroCreado.Value;
                    }
                    else
                    {
                        Console.WriteLine("No se pudo crear el registro.");
                        return 0;
                    }
                }
                else
                {
                    Console.WriteLine($"Error al crear el registro: {response.ReasonPhrase}");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el registro: {ex.Message}");
                return 0;
            }
        }

    }
}