﻿using AutenticacaoMVC.Models;

namespace AutenticacaoMVC.IRepository
{
    public interface IUsuarioRepository
    {
         bool Add(Usuario usuario);

        bool LoginExists(Usuario usuario);
    }
}
