﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using salaodebeleza.Data;
using salaodebeleza.Models;

namespace salaodebeleza.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDb _context;

        public ClientesController(AppDb context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [Route("{action}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes(int id, string info, DateTime dataNascimentoInicial, DateTime dataNascimentoFinal)
        {
            dataNascimentoFinal = dataNascimentoFinal == DateTime.MinValue ? DateTime.MaxValue : dataNascimentoFinal;
            return await _context.Clientes
                .Where(x => id > 0 ? x.ID == id : true)
                .Where(x => info != "-" ? x.Nome.ToLower().Contains(info.ToLower()) || x.CPF.Contains(info) : true)
                .Where(x => x.DataNascimento.Date >= dataNascimentoInicial.Date)
                .Where(x => x.DataNascimento.Date <= dataNascimentoFinal.Date)
                .ToListAsync();
            //return await _context.Clientes.ToListAsync();
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.ID)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {

            if (ClienteExistsCpf(cliente.CPF))
            {
                return NotFound();
            }
            else
            {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCliente", new { id = cliente.ID }, cliente);
            }
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)=>
            _context.Clientes.Any(e => e.ID == id);
        
        private bool ClienteExistsCpf(string cpf) =>
            _context.Clientes.Any(e => e.CPF.Equals(cpf));
            
        
        bool ClienteEmUso(int clienteID) =>
            _context.Vendas.Any(x => x.ClienteID == clienteID);
    }
}
