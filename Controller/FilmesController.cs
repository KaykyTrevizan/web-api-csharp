﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiFilmesSeries.Data;
using WebApiFilmesSeries.Models;


namespace WebApiFilmesSeries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly AppDbContext _context;

        //metodo para se comunicar com dbContext
        public FilmesController(AppDbContext context)
        {
            _context = context;
        }

        //Listar todos os filmes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> GetFilmes()
        {
            return await _context.Filmes.ToListAsync();
        }

        //Listar todos os filmes por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> GetFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)return NotFound();
            return filme;
        }

        //Adicionar novo filme
        [HttpPost]
        public async Task<ActionResult<Filme>> PostFilme(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilme", new { id = filme.Id }, filme);
        }

        //Atualizar filme
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilme(int id, Filme filme)
        {
            if (id != filme.Id) return BadRequest();

            _context.Entry(filme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeExists(id)) return NotFound();
                else throw;
            }
            return NoContent();
        }
        //atualizar parcialmente o filme
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchFilme(int idFilme, [FromBody] Filme filmeAtualizado)
        {
            try
            {
                var filmeExistente = await _context.Filmes.FindAsync(idFilme);

                if (filmeExistente == null)
                    return NotFound();

                // Atualize apenas as propriedades que foram fornecidas no filmeAtualizado
                if (filmeAtualizado.Nome != null)
                    filmeExistente.Nome = filmeAtualizado.Nome;

                if (filmeAtualizado.Ano != 0)
                    filmeExistente.Ano = filmeAtualizado.Ano;

                if (filmeAtualizado.Diretor != null)
                    filmeExistente.Diretor = filmeAtualizado.Diretor;

                if (filmeAtualizado.Duracao != 0)
                    filmeExistente.Duracao = filmeAtualizado.Duracao;

                if (filmeAtualizado.Genero != null)
                    filmeExistente.Genero = filmeAtualizado.Genero;

                if (filmeAtualizado.Estudio != null)
                    filmeExistente.Estudio = filmeAtualizado.Estudio;

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            { 
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    
        //apagar filme
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);

            if (filme == null) return NotFound();

            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //metodo para verifcar filme existente (usado para atualizar)
        private bool FilmeExists(int id)
        {
            return _context.Filmes.Any(e => e.Id == id);
        }
    }
}
