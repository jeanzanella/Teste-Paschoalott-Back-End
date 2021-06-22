using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Teste_Paschoalott_Back_End.Data;
using Teste_Paschoalott_Back_End.DTOs;
using Teste_Paschoalott_Back_End.Interfaces;
using Teste_Paschoalott_Back_End.Models;

namespace Teste_Paschoalott_Back_End.Services
{
    public class TituloService : ITituloService
    {
        TestePaschoalottoContext _context;

        public TituloService(TestePaschoalottoContext context)
        {
            _context = context;
        }

        public IEnumerable<TituloDTO> GetTitulos()
        {
            var titulos = _context.Titulos.AsNoTracking().Include(t => t.Parcelas).ToList().Select(t => new TituloDTO() {
                NumeroTitulo = t.NumeroTitulo,
                NomeDevedor = t.NomeDevedor,
                QtdeParcelas = t.Parcelas.Count(),
                ValorOriginal = t.Parcelas.Sum(p => p.Valor),
                DiasEmAtraso = CalculaDiasEmAtraso(t.Parcelas.OrderBy(p => p.DataVencimento).First().DataVencimento, DateTime.Today),
                ValorAtualizado = CalculaValorAtualizadoTitulo(t)
            });
            return titulos;
        }

        public long CalculaDiasEmAtraso(DateTime primeiraData, DateTime segundaData)
        {
            return segundaData.Subtract(primeiraData).Days < 0 ? 0 : segundaData.Subtract(primeiraData).Days;
        }

        public double CalculaValorAtualizadoTitulo(Titulo titulo)
        {
            double valorFinal = titulo.Parcelas.Sum(p => p.Valor);
            if (CalculaDiasEmAtraso(titulo.Parcelas.OrderBy(p => p.DataVencimento).First().DataVencimento, DateTime.Today) > 0)
            {
                valorFinal += ((titulo.PercentualMulta / 100) * valorFinal);
                foreach (var parcela in titulo.Parcelas)
                {
                    var diasEmAtraso = CalculaDiasEmAtraso(parcela.DataVencimento, DateTime.Today);
                    valorFinal += ((titulo.PercentualJuros / 100) / 30) * diasEmAtraso * parcela.Valor;
                }
            }
            return valorFinal;
        }

        public void AdicionarTitulo(Titulo titulo)
        {
            string msgErro = "";
            if (titulo != null)
            {
                if (!TituloJaCadastrado(titulo))
                {
                    if (titulo.Parcelas != null && titulo.Parcelas.Count > 0)
                    {
                        titulo.CpfDevedor = Regex.Replace(titulo.CpfDevedor, @"\D+", "");
                        _context.Titulos.Add(titulo);
                        _context.Parcelas.AddRange(titulo.Parcelas);
                        _context.SaveChanges();
                    }
                    else
                        msgErro = "Titulo deve ter ao menos uma parcela";
                }
                else
                    msgErro = "Titulo com esses dados já esta cadastrado";
            }
            else
                msgErro = "Favor informar titulo";

            if (msgErro.Length > 0)
                throw (new Exception(msgErro));
        }

        public bool TituloJaCadastrado(Titulo titulo)
        {
            return _context.Titulos.Where(t => t.CpfDevedor == Regex.Replace(titulo.CpfDevedor, @"\D+", "") 
                                            && t.NumeroTitulo == titulo.NumeroTitulo).Count() > 0;
        }
    }
}
