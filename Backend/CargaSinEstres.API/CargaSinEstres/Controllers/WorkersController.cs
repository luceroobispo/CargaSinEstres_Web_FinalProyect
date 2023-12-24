using AutoMapper;
using CargaSinEstres.API.CargaSinEstres.Domain.Models;
using CargaSinEstres.API.CargaSinEstres.Domain.Services;
using CargaSinEstres.API.CargaSinEstres.Resources;
using CargaSinEstres.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CargaSinEstres.API.Security.Domain.Services;

namespace CargaSinEstres.API.CargaSinEstres.Controllers
{
    /// <summary>
    /// Controlador para manejar las operaciones relacionadas con los trabajadores.
    /// </summary>
    /// <remarks> Grupo 1: Carga sin estres </remarks>
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService _workerService;
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;
        private readonly ICompanyService _companyService;

        /// <summary>
        /// Constructor del controlador de trabajadores.
        /// </summary>
        /// <param name="workerService">Servicio de trabajadores.</param>
        /// <param name="mapper">Instancia de AutoMapper para el mapeo de objetos.</param>
        /// <param name="commentService">Servicio de comentarios.</param>
        public WorkersController(IWorkerService workerService, IMapper mapper, ICommentService commentService, ICompanyService companyService)
        {
            _workerService = workerService;
            _mapper = mapper;
            _commentService = commentService;
            _companyService = companyService;
        }

        /// <summary>
        /// Obtiene la información de un trabajador por su identificador.
        /// </summary>
        /// <param name="id">Identificador del trabajador.</param>
        /// <returns>Información del trabajador.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkerById(int id)
        {
            var workers = await _workerService.ListByWorkerIdAsync(id);
            
                
            var resource = _mapper.Map<Worker, WorkerResource>(workers);
            return Ok(resource);
        }

        /// <summary>
        /// Actualiza los comentarios de un trabajador mediante la operación PATCH.
        /// </summary>
        /// <param name="id">Identificador del trabajador.</param>
        /// <param name="updateCommentResource">Recursos para la actualización de comentarios.</param>
        /// <returns>Resultado de la operación y recursos actualizados del trabajador.</returns>
        [HttpPatch("{id}/comments")]
        public async Task<IActionResult> PatchWorkerComments(int id, [FromBody] UpdateCommentResource updateCommentResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var comments = await _commentService.ListByWorkerIdAsync(id);
            //setear comentarios
           
            var result = await _workerService.UpdateCommentsAsync(id, updateCommentResource);

            if (!result.Success)
                return BadRequest(result.Message);

            var workerResource = _mapper.Map<Worker, WorkerResource>(result.Resource);
            return Ok(workerResource);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync([FromBody] SaveWorkerResource resource, [FromQuery] int companyId){
            if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
             //confirm company existence
            var company = await _companyService.GetByIdAsync(companyId); 
            if (company == null)
            {
                throw new Exception("Company not found");
            }
        
            var NewWorker = _mapper.Map<SaveWorkerResource, Worker>(resource);
            NewWorker.CompanyId = companyId;

            var result = await _workerService.SaveAsync(NewWorker); 
        
            if (!result.Success)
                return BadRequest(result.Message);
        

        
            //show created worker
            var workerResource = _mapper.Map<Worker, WorkerResource>(result.Resource); 
            return Ok(workerResource);

        }

        
    }
}
