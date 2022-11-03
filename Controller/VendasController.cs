using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using salaodebeleza.Data;
using salaodebeleza.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net;
using salaodebeleza.Helpers;

namespace salaodebeleza.Controller {
    [Route("api/vendas")]
    [ApiController]
    public class VendasController : ControllerBase {
        private readonly AppDb _context;

        public VendasController(AppDb context)
        {
            _context = context;
        }

        // GET: api/Vendas
        [Route("{Action}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> GetVendas()
        {
            try {
                var vendas = await _context.Vendas.Include(venda => venda.Cliente).Include(venda => venda.Itens).ToListAsync();
                return vendas;
            }
            catch (Exception ex) {

                throw ex;
            }
        }

        // GET: api/Vendas/5
        //[Route("{Action}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
            var venda = await _context.Vendas.Include(venda => venda.Itens).ThenInclude(item => item.Servico).FirstAsync(venda => venda.ID == id);

            if (venda == null) {
                return NotFound();
            }

            return venda;
        }

        // PUT: api/Vendas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenda(int id, Venda venda)
        {
            if (HoraExists(venda.DataAgendamento))
            {
                return NotFound();
            }
            else
            {
                if (id != venda.ID)
                {
                    return BadRequest();
                }

                _context.Update(venda);

                //Determinando como Adicionado os itens de ID = 0
                foreach (var item in venda.Itens)
                {
                    if (item.ID == 0)
                    {
                        _context.Entry(item).State = EntityState.Added;
                    }
                }
            }
            //Remover itens do banco
            var itens = await _context.VendasItens.Where(item => item.VendaID == venda.ID && !venda.Itens.Select(it => it.ID).Contains(item.ID)).ToListAsync();

            foreach (var item in itens) {
                _context.Entry(item).State = EntityState.Deleted;
            }

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!VendaExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vendas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Venda>> PostVenda(Venda venda)
        {
            if (HoraExists(venda.DataAgendamento))
            {
                return NotFound();
            }
            else
            {
                try
                {
                    foreach (var item in venda.Itens)
                    {
                        item.Servico = null;
                    }

                    _context.Vendas.Add(venda);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetVenda", new { id = venda.ID }, venda);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        // DELETE: api/Vendas/5
        //[Route("{Action}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenda(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null) {
                return NotFound();
            }

            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendaExists(int id)
        {
            return _context.Vendas.Any(e => e.ID == id);
        }
        private bool HoraExists(DateTime dataAgendamento)
        {
            return _context.Vendas.Any(e => e.DataAgendamento == dataAgendamento);
        }
    }
}
