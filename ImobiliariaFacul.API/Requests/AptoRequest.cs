using System.Drawing;

namespace ImobiliariaFacul.API.Requests;

public record AptoRequest(float valor, string endereco, float areaTotal, float areaPrivativa);
