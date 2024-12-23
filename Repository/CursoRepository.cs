using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CursoRepository : IRepository<Curso>
    {
        private readonly RegContext _context;

        public CursoRepository(RegContext context)
        {
            _context = context;
        }

        public async Task<Curso> Create(Curso entity)
        {
            _context.Cursos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Curso> Delete(int id)
        {
            Curso curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
                return curso;
            }
            return null;
        }

        public async Task<List<Curso>> GetAll()
        {
            List<Curso> cursos = await _context.Cursos.ToListAsync();
            return cursos;
        }

        public async Task<Curso> GetByID(int id)
        {
            Curso curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                return curso;
            }
            return null;
        }

        public async Task<Curso> Update(Curso entity)
        {
            _context.Cursos.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
