namespace ImobiliariaFacul.API.Requests;

public record AptoRequestEdit(int Id, float valor, string endereco, float areaTotal, float areaPrivativa): AptoRequest( valor,  endereco,  areaTotal, areaPrivativa);

