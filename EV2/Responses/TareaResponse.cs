﻿using EV2.Models;

namespace EV2.Responses
{
    public class TareaResponse : ResponseBase<Tarea>
    {
    }

    public class TareasResponse : ResponseBase<List<Tarea>>
    {
    }

    public class NuevaTareaResponse : ResponseBase<bool>
    {
    }

    public class UpdateTareaResponse : ResponseBase<bool>
    {
    }

    public class DeleteTareaResponse : ResponseBase<bool>
    {
    }
}
