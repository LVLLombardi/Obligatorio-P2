using Dominio.Interfaces;

namespace Dominio;

public class Administrador : IValidable
{
    private string _apodo;
    private string _correoAdmin;
    private string _contraseniaAdmin;

    public Administrador(string apodo, string correoAdmin, string contraseniaAdmin)
    {
        _apodo = apodo;
        _correoAdmin = correoAdmin;
        _contraseniaAdmin = contraseniaAdmin;
    }

    public void Validar()
    {
        throw new NotImplementedException();
    }
}