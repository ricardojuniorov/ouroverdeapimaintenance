using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OuroVerde.API.Maintenance.Queries;

namespace OuroVerde.API.Maintenance.Controllers
{
    [Route("api/[controller]")]
    public class AMCaseController : Controller
    {
        public readonly IAMCaseQuery _amCaseQuery;

        public AMCaseController(IAMCaseQuery amCaseQuery)
        {
            _amCaseQuery = amCaseQuery ?? throw new ArgumentNullException(nameof(amCaseQuery));
        }

        /// <summary>
        /// Retornar as ocorrências do fornecedor
        /// </summary>
        /// <param name="contaFornecedor">Conta do Fornecedor</param>
        /// <returns></returns>
        [HttpGet("{contaFornecedor}/Stored")]
        [AllowAnonymous]
        public async Task<IActionResult> GetStored(string contaFornecedor)
        {
            try
            {

                if (string.IsNullOrEmpty(contaFornecedor))
                {
                    return BadRequest("O campo 'conta do fornecedor' deve ser preenchido");
                }

                var result = await _amCaseQuery.GetStored(contaFornecedor);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Retornar as ocorrências do fornecedor
        /// </summary>
        /// <param name="contaFornecedor">Conta do Fornecedor</param>
        /// <returns></returns>
        [HttpGet("{contaFornecedor}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string contaFornecedor)
        {
            try
            {
                if (string.IsNullOrEmpty(contaFornecedor))
                {
                    return BadRequest("O campo 'conta do fornecedor' deve ser preenchido");
                }

                var result = await _amCaseQuery.Get(contaFornecedor);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Retornar os itens da ocorrências
        /// </summary>
        /// <param name="numeroOcorrencia">Número da Ocorrência</param>
        /// <returns></returns>
        [HttpGet("{numeroOcorrencia}/itens")]
        [AllowAnonymous]
        public async Task<IActionResult> GetItems(string numeroOcorrencia)
        {
            try
            {
                if (string.IsNullOrEmpty(numeroOcorrencia))
                {
                    return BadRequest("O campo 'número da ocorrencia' deve ser preenchido");
                }

                var result = await _amCaseQuery.GetItems(numeroOcorrencia);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
