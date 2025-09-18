namespace BemEstar.ApiHabitos.Models;

public class Habitos: BaseModel
{
    public string Nome { get; set; } = string.Empty;
    public string Frequencia {  get; set; } = string.Empty;
    public string Meta { get; set; } = string.Empty;
 
}

