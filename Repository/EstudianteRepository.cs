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
    public class EstudianteRepository : IRepository<Estudiante>
    {
        private readonly RegContext _context;

        public EstudianteRepository(RegContext context)
        {
            _context = context;
        }

        public async Task<Estudiante> Create(Estudiante entity)
        {
            _context.Estudiantes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Estudiante> Delete(int id)
        {
            Estudiante estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                await _context.SaveChangesAsync();
                return estudiante;
            }
            return null;
        }

        public async Task<List<Estudiante>> GetAll()
        {
            List<Estudiante> estudiantes = await _context.Estudiantes.ToListAsync();
            return estudiantes;
        }

        public async Task<Estudiante> GetByID(int id)
        {
            Estudiante estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                return estudiante;
            }
            return null;
        }

        public async Task<Estudiante> Update(Estudiante entity)
        {
            _context.Estudiantes.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
