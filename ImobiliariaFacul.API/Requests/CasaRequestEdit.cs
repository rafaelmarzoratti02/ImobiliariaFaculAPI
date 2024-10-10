namespace ImobiliariaFacul.API.Requests;

public record CasaRequestEdit(int Id, float valor, string endereco, float areaTotal, float areaConstruida) : CasaRequest( valor,  endereco,  areaTotal,  areaConstruida);

