using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_Paschoalott_Back_End.DTOs;
using Teste_Paschoalott_Back_End.Interfaces;
using Teste_Paschoalott_Back_End.Models;

namespace Teste_Paschoalott_Back_End.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TitulosController : ControllerBase
    {
        private readonly ITituloService _tituloService;

        public TitulosController(ITituloService tituloService)
        {
            _tituloService = tituloService;
        }

        [HttpGet]
        [Route("api/Titulo/GetAll")]
        public IEnumerable<TituloDTO> GetTitulos()
        {
            return _tituloService.GetTitulos();
        }

        [HttpPost]
        [Route("api/AdicionarTitulo")]
        public void AdicionarTitulo(Titulo titulo)
        {
            try
            {
               _tituloService.AdicionarTitulo(titulo);
            }
            catch (Exception e)
            {
                throw(new Exception("Erro ao incluir titulo: " + e.Message));
            }
        }
    }
}
