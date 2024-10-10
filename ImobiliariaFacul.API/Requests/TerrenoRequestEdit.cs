namespace ImobiliariaFacul.API.Requests;

public record TerrenoRequestEdit(int Id, float valor, string endereco, float areaTotal, string tipo) : TerrenoRequest(valor, endereco, areaTotal, tipo);

