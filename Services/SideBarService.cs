using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlIngresoApp.Client.Services
{
public class SidebarService
{
    public event Action<string>? OnPanelRequest;

    public void AbrirPanel(string nombre)
    {
        OnPanelRequest?.Invoke(nombre);
    }
}
}