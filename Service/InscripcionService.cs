using DB.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class InscripcionService : IService<Inscripcion>
    {
        private readonly InscripcionRepository _inscripcionRepository;

        public InscripcionService(InscripcionRepository inscripcionRepository)
        {
            _inscripcionRepository = inscripcionRepository;
        }

        public async Task<Inscripcion> Create(Inscripcion entity)
        {
            return await _inscripcionRepository.Create(entity);
        }

        public async Task<Inscripcion> Delete(int id)
        {
            return await _inscripcionRepository.Delete(id);
        }

        public async Task<List<Inscripcion>> GetAll()
        {
            return await _inscripcionRepository.GetAll();
        }

        public async Task<Inscripcion> GetByID(int id)
        {
            return await _inscripcionRepository.GetByID(id);
        }

        public async Task<Inscripcion> Update(Inscripcion entity)
        {
            return await _inscripcionRepository.Update(entity);
        }
    }
}
