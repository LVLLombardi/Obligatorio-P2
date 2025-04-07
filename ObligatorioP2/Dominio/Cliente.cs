using Dominio.Interfaces;

namespace Dominio;

public class Cliente : IValidable
{
    private string _documento;
    private string _nombre;
    private string _correoCli;
    private string _contraseniaCli;
    private string _nacionalidad;

    public Cliente(string documento, string nombre, string correoCli, string contraseniaCli, string nacionalidad)
    {
        _documento = documento;
        _nombre = nombre;
        _correoCli = correoCli;
        _contraseniaCli = contraseniaCli;
        _nacionalidad = nacionalidad;
    }

    public void Validar()
    {
        throw new NotImplementedException();
    }
}