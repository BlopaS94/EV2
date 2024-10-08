﻿using EV2.Models;

namespace EV2.Responses
{
    public class UsuarioResponse : ResponseBase<Usuario>
    {
    }

    public class UsuariosResponse : ResponseBase<List<Usuario>>
    {
    }

    public class NuevoUsuarioResponse : ResponseBase<bool>
    {
    }

    public class UpdateUsuarioResponse : ResponseBase<bool>
    {
    }

    public class DeleteUsuarioResponse : ResponseBase<bool>
    {
    }
}
