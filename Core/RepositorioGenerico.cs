﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core
{
    public class RepositorioGenerico<T> where T : class
    {
        protected DbContext Contexto;
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

        public void InsertarMultiples(ICollection<T> entidades)
        {
            DbSet.AddRange(entidades);
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
            bool covnertirInt = false;
            Type  tipo = DbSet.GetType();
            var nombreTipo = tipo.GetMethods()[0].ReturnType.Name;

            //Esto se puede cambiar por una consulta en el webconfig o en base de datos en una tabla de parámetros
            if (nombreTipo != "Pasajero")
            {
                covnertirInt = int.TryParse(id, out int parameter);

                if (covnertirInt)
                    return await DbSet.FindAsync(parameter);
                else
                    return await DbSet.FindAsync(id);
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
