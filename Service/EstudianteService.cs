using DB.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EstudianteService : IService<Estudiante>
    {
        private readonly EstudianteRepository _estudianteRepository;

        public EstudianteService(EstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        public async Task<Estudiante> Create(Estudiante entity)
        {
            return await _estudianteRepository.Create(entity);
        }

        public async Task<Estudiante> Delete(int id)
        {
            return await _estudianteRepository.Delete(id);
        }

        public async Task<List<Estudiante>> GetAll()
        {
            return await _estudianteRepository.GetAll();
        }

        public async Task<Estudiante> GetByID(int id)
        {
            return await _estudianteRepository.GetByID(id);
        }

        public async Task<Estudiante> Update(Estudiante entity)
        {
            return await _estudianteRepository.Update(entity);
        }
    }
}
