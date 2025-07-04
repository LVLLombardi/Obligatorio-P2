using Dominio.Interfaces;

namespace Dominio;

public class Aeropuerto : IValidable
{
    private string _codigoIATA;
    private string _ciudad;
    private double _costoOp;
    private double _costoTasas;

    public Aeropuerto(string codigoIATA, string ciudad, double costoOp, double costoTasas)
    {
        _codigoIATA = codigoIATA;
        _ciudad = ciudad;
        _costoOp = costoOp;
        _costoTasas = costoTasas;
    }

    public double CostoOp
    {
        get { return _costoOp; }
    }

    public double CostoTasas
    {
        get { return _costoTasas; }
    }
    
    public string Codigo
    {
        get { return _codigoIATA; }
    }

    public void Validar()
    {
        if (!ValidarCodigoIata(_codigoIATA)) throw new Exception("El código IATA es un identificador único de 3 letras"); 
        if (string.IsNullOrEmpty(_ciudad)) throw new Exception("La ciudad no puede ser vacía");
        if (_costoOp < 0) throw new Exception("El costo de Operación debe ser positivo.");
        if(_costoTasas < 0) throw new Exception("El costo de Tasas es obligatorio y debe ser positivo");
    }

    // FUNCION PARA VALIDAR EL CODIGO IATA , VACIO, LENGTH DISTINTO DE 3 Y QUE TENGA LETRAS
    private static bool ValidarCodigoIata(string codigo)
    {
        bool esValido = true;
        if (string.IsNullOrEmpty(codigo) || codigo.Length != 3) throw new Exception("El código IATA debe tener exactamente 3 caracteres.");
        
        for (int i = 0; i < 3; i++)
        {
            char c = codigo[i];
            if (!Char.IsLetter(c)) throw new Exception($"El carácter en la posición {i + 1} no es una letra válida.");
        }
        
        return esValido;
    }

    public override bool Equals(object obj)
    {
        Aeropuerto a = obj as Aeropuerto;
        return a != null && this._codigoIATA == a._codigoIATA;
    }
    
    public override string ToString()
    {
        return $"Aeropuerto -> Codigo IATA: {_codigoIATA} -  Ciudad: {_ciudad} - Costo operación : {_costoOp} - Costo tasas : {_costoTasas}";
    }
}