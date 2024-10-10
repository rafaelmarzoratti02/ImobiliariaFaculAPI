using System.Drawing;

namespace ImobiliariaFacul.API.Requests;

public record CasaRequest(float valor, string endereco, float areaTotal, float areaConstruida);

