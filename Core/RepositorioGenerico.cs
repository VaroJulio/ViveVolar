using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class RepositorioGenerico<T> where T : class
    {
        protected DbContext Contexto;
        //= ViveVolarDbContext.GetDbContext();
        protected DbSet<T> DbSet;

        public RepositorioGenerico()
        {
            DbSet = Contexto.Set<T>();
        }

        public RepositorioGenerico(DbContext contexto)
        {
            Contexto = contexto;
            DbSet = Contexto.Set<T>();
        }

        public void Insertar(T entidad)
        {
            DbSet.Add(entidad);
        }

        public void Eliminar(T entidad)
        {
            DbSet.Remove(entidad);
        }

        public IQueryable<T> Filtrar(Expression<Func<T, bool>> expresion)
        {
            return DbSet.Where(expresion);
        }

        public async Task<T> ObtenerPorId(string id)
        {
            int parameter;
            if (int.TryParse(id, out parameter))
            {
                return await DbSet.FindAsync(parameter);
            }
            else
            {
                return await DbSet.FindAsync(id);
            }
            
        }

        public IQueryable<T> ObtenerTodos()
        {
            return DbSet;
        }

        public void GuardarCambios()
        {
            Contexto.SaveChanges();
        }
    }
}
