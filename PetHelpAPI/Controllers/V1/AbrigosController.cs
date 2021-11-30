using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetHelpAPI.Exceptions;
using PetHelpAPI.InputModel;
using PetHelpAPI.Services;
using PetHelpAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetHelpAPI.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class AbrigosController : ControllerBase
    {
        private readonly IAbrigoService _abrigoService;

        public AbrigosController(IAbrigoService abrigoService)
        {
            _abrigoService = abrigoService;
        }

        /// <summary>
        /// Método que busca todos os abrigos cadastados
        /// </summary>
        /// <param name="pagina"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AbrigoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var abrigos = await _abrigoService.Obter(pagina, quantidade);

            if (abrigos.Count() == 0)
                return NoContent();

            return Ok(abrigos);
        }

        /// <summary>
        /// Método que busca um abrigo de acordo com o ID
        /// </summary>
        /// <param name="idAbrigo"></param>
        /// <returns></returns>
        [HttpGet("{idAbrigo:guid}")]
        public async Task<ActionResult<AbrigoViewModel>> Obter([FromRoute] Guid idAbrigo)
        {
            var abrigo = await _abrigoService.Obter(idAbrigo);

            if (abrigo == null)
                return NoContent();

            return Ok(abrigo);
        }

        /// <summary>
        /// Método para cadastrar um abrigo
        /// </summary>
        /// <param name="abrigoInputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<AbrigoViewModel>> Adicionar([FromBody] AbrigoInputModel abrigoInputModel)
        {
            try
            {
                var abrigo = await _abrigoService.Inserir(abrigoInputModel);

                return Ok(abrigo);
            }
            catch (AbrigoJaCadastradoException ex)
            {
                return UnprocessableEntity("Já existe um abrigo com este nome para este endereço");
            }
        }

        /// <summary>
        /// Método para atualizar um abrigo
        /// </summary>
        /// <param name="idAbrigo"></param>
        /// <param name="abrigoInputModel"></param>
        /// <returns></returns>
        [HttpPut("{idAbrigo:guid}")]
        public async Task<ActionResult> AtualizarAbrigo([FromRoute] Guid idAbrigo, [FromBody] AbrigoInputModel abrigoInputModel)
        {
            try
            {
                await _abrigoService.Atualizar(idAbrigo, abrigoInputModel);

                return Ok();
            }
            catch (AbrigoNaoCadastradoException ex)
            {
                return NotFound("Não existe este abrigo");
            }
        }

        /// <summary>
        /// Método que deleta um abrigo
        /// </summary>
        /// <param name="idAbrigo"></param>
        /// <returns></returns>
        [HttpDelete("{idAbrigo:guid}")]
        public async Task<ActionResult> DeletarAbrigo([FromRoute] Guid idAbrigo)
        {
            try
            {
                await _abrigoService.Remover(idAbrigo);

                return Ok();
            }
            catch (AbrigoNaoCadastradoException ex)
            {
                return NotFound("Não existe este abrigo");
            }
        }
    }
}
