using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClienteAPI.Data;
using ClienteAPI.Models;

namespace ClienteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesDocumentosController : ControllerBase
    {
        private readonly BdClientesContext _context;

        public ClientesDocumentosController(BdClientesContext context)
        {
            _context = context;
        }

        // Listar documentos de clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientesDocumento>>> GetDocumentos()
        {
            return await _context.ClientesDocumentos.ToListAsync();
        }

        // Registrar un documento para un cliente
        [HttpPost]
        public async Task<ActionResult<ClientesDocumento>> PostDocumento(ClientesDocumento doc)
        {
            _context.ClientesDocumentos.Add(doc);
            await _context.SaveChangesAsync();
            return Ok(doc);
        }
    }
}