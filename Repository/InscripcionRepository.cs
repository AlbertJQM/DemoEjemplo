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
    public class InscripcionRepository : IRepository<Inscripcion>
    {
        private readonly RegContext _context;

        public InscripcionRepository(RegContext context)
        {
            _context = context;
        }

        public async Task<Inscripcion> Create(Inscripcion entity)
        {
            _context.Inscripciones.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Inscripcion> Delete(int id)
        {
            Inscripcion inscripcion = await _context.Inscripciones.FindAsync(id);
            if (inscripcion != null)
            {
                _context.Inscripciones.Remove(inscripcion);
                await _context.SaveChangesAsync();
                return inscripcion;
            }
            return null;
        }

        public async Task<List<Inscripcion>> GetAll()
        {
            List<Inscripcion> inscripciones = await _context.Inscripciones.Include(e => e.Estudiante).Include(c => c.Curso).ToListAsync();
            return inscripciones;
        }

        public async Task<Inscripcion> GetByID(int id)
        {
            Inscripcion inscripcion = await _context.Inscripciones.Include(e => e.Estudiante).Include(c => c.Curso).FirstOrDefaultAsync(i => i.InscripcionID == id);
            if (inscripcion != null)
            {
                return inscripcion;
            }
            return null;
        }

        public async Task<Inscripcion> Update(Inscripcion entity)
        {
            _context.Inscripciones.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
