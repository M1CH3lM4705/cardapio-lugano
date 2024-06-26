using System.Reflection.Metadata;

namespace CardapioLugano.Modelos.Modelos;
public abstract class BaseModel
{
    public abstract Dictionary<string, object?> ToMap();
    public abstract BaseModel ConvertTo(Document data);
}
