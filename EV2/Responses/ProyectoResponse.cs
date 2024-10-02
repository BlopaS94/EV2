using EV2.Models;

namespace EV2.Responses
{
    public class ProyectoResponse : ResponseBase<Proyecto>
    {
    }
    public class ProyectosResponse : ResponseBase<List<Proyecto>>
    {
    }
 
    public class NuevoProyectoResponse : ResponseBase<bool>
    {
    }

    public class UpdateProyectoResponse : ResponseBase<bool>
    {
    }
 
    public class DeleteProyectoResponse : ResponseBase<bool>
    {
    }
}
