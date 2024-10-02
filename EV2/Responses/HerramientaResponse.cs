using EV2.Models;

namespace EV2.Responses
{
    public class HerramientaResponse : ResponseBase<Herramienta>
    {
    }
    public class HerramientasResponse : ResponseBase<List<Herramienta>>
    {
    }

    public class NuevoHerramientaResponse : ResponseBase<bool>
    {
    }

    public class UpdateHerramientaResponse : ResponseBase<bool>
    {
    }

    public class DeleteHerramientaResponse : ResponseBase<bool>
    {
    }
}
