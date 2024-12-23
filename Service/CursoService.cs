using DB.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CursoService : IService<Curso>
    {
        private readonly CursoRepository _cursoRepository;

        public CursoService(CursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<Curso> Create(Curso entity)
        {
            return await _cursoRepository.Create(entity);
        }

        public async Task<Curso> Delete(int id)
        {
            return await _cursoRepository.Delete(id);
        }

        public async Task<List<Curso>> GetAll()
        {
            return await _cursoRepository.GetAll();
        }

        public async Task<Curso> GetByID(int id)
        {
            return await _cursoRepository.GetByID(id);
        }

        public async Task<Curso> Update(Curso entity)
        {
            return await _cursoRepository.Update(entity);
        }
    }
}
