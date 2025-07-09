using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ControlIngresoApp.Model;
using ControlIngresoApp.Shared.DTOs;

namespace ControlIngresoApp.Client.Services
{

    public class PersonaService : IPersonaService
    {
        private readonly HttpClient _http;
        public PersonaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<PersonaDTO>> ObtenerPersonasByDocumentoNombreApellidoAsync(string documento, string nombre, string apellido)
        {
            try
            {
                var response = await _http.GetFromJsonAsync<List<PersonaDTO>>($"/Persona/personas?documento={documento}&nombre={nombre}&apellido={apellido}");
                if (response != null)
                {
                    return response;
                }
                return new List<PersonaDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener las personas: {ex.Message}");
                return new List<PersonaDTO>();
            }

        }
        public async Task<int> CrearPersonaAsync(PersonaCreateDTO persona)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("/Persona/crear", persona);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<int>();
                    return result;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la persona: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> ActualizarPersonaAsync(PersonaUpdateDTO persona)
        {
            try
            {
                var response = await _http.PutAsJsonAsync("/Persona/actualizar", persona);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<int>();
                    return result;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la persona: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> ActualizarEstadoPersonaAsync(PersonaUpdateEstadoDTO personaUpdateEstado)
        {
            try
            {
                var response = await _http.PutAsJsonAsync("/Persona/actualizarEstado", personaUpdateEstado);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<int>();
                    return result;
                }
                return 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el estado de la persona: {ex.Message}");
                return 0;
            }
        }
    }
}