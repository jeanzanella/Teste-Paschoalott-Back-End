using System;
using System.Collections.Generic;
using Teste_Paschoalott_Back_End.DTOs;
using Teste_Paschoalott_Back_End.Models;

namespace Teste_Paschoalott_Back_End.Interfaces
{
    public interface ITituloService
    {
        IEnumerable<TituloDTO> GetTitulos();
        void AdicionarTitulo(Titulo titulo);
    }
}
