﻿using CondominioApp.Core.Data;
using CondominioApp.Core.ValueObjects;
using CondominioApp.Principal.Domain;
using CondominioApp.Principal.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CondominioApp.Principal.Infra.Data.Repository
{
    public class CondominioRepository : ICondominioRepository
    {
        private readonly PrincipalContextDB _context;
       
        public CondominioRepository(PrincipalContextDB context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;

        public void Adicionar(Condominio entity)
        {
            _context.Condominios.Add(entity);       
        }

        public void Apagar(Func<Condominio, bool> predicate)
        {
            _context.Condominios.Where(predicate).ToList().ForEach(del => del.EnviarParaLixeira());
        }

        public void Atualizar(Condominio entity)
        {
            _context.Condominios.Update(entity);
        }


        public void AdicionarGrupo(Grupo entity)
        {
            _context.Grupos.Add(entity);
        }

        public void AdicionarUnidade(Unidade entity)
        {
            _context.Unidades.Add(entity);
        }


        public async Task<IEnumerable<Condominio>> Obter(Expression<Func<Condominio, bool>> expression, bool OrderByDesc = false, int take = 0)
        {
            if (OrderByDesc)
            {
                if (take > 0)
                    return await _context.Condominios.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).Take(take).ToListAsync();

                return await _context.Condominios.AsNoTracking().Where(expression)
                                        .OrderByDescending(x => x.DataDeCadastro).ToListAsync();
            }

            if (take > 0)
                return await _context.Condominios.AsNoTracking().Where(expression)
                                        .OrderBy(x => x.DataDeCadastro).Take(take).ToListAsync();

            return await _context.Condominios.AsNoTracking().Where(expression)
                                    .OrderBy(x => x.DataDeCadastro).ToListAsync();
        }

        public async Task<Condominio> ObterPorId(Guid Id)
        {
            return await _context.Condominios
                .Include(c => c.Unidades)
                .Include(c=>c.Unidades)
                .FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<IEnumerable<Condominio>> ObterTodos()
        {
            return await _context.Condominios.Where(u => !u.Lixeira).ToListAsync();
        }


        public async Task<bool> CondominioJaExiste(Cnpj cnpj)
        {
            return await _context.Condominios
                .Where
                    (u => !u.Lixeira &&
                     u.Cnpj.numero == cnpj.numero)
                .CountAsync()>0;
        }

        public async Task<bool> GrupoJaExiste(string descricao, Guid condominioId)
        {
            return await _context.Grupos
                .Where
                    (u => !u.Lixeira &&
                     u.Descricao == descricao &&
                     u.CondominioId == condominioId)
                .CountAsync()>0;
        }

        public async Task<bool> UnidadeJaExiste(string codigo, string numero, string andar, Guid grupoId, Guid condominioId)
        {
            return await _context.Unidades
                .Where
                    (u => !u.Lixeira &&
                     u.Codigo == codigo && 
                     u.Numero == numero &&
                     u.Andar == andar && u.GrupoId == grupoId &&
                     u.CondominioId == condominioId)
                .CountAsync() > 0;
        }

        public async Task<Grupo> ObterGrupoPorId(Guid Id)
        {
            return await _context.Grupos.FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<Unidade> ObterUnidadePorId(Guid Id)
        {
            return await _context.Unidades.FirstOrDefaultAsync(u => u.Id == Id);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
       
    }
}
