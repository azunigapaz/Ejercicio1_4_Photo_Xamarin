using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Ejercicio1_3App.Models;
using System.Threading.Tasks;
using System.IO;

namespace Ejercicio1_3App.Controllers
{
    public class PersonasDB
    {
        readonly SQLiteAsyncConnection db;

        // Constructor de clase vacio
        public PersonasDB()
        {
        }

        // Constructor con parametros
        public PersonasDB(String pathbasedatos)
        {
            db = new SQLiteAsyncConnection(pathbasedatos);

            // creacion de tabla de Base de Datos
            db.CreateTableAsync<Personas>();

        }

        // Procedimientos y funciones CRUD

        // Retorna la tabla de personas como una lista
        public Task<List<Personas>> listapersonas()
        {

            return db.Table<Personas>().ToListAsync();
            

        }

        // Buscar persona por ID
        public Task<Personas> ObtenerPersona(int pcodigo)
        {
            return db.Table<Personas>()
                .Where(i => i.codigo == pcodigo)
                .FirstOrDefaultAsync();
        }

        // guardar o actualizar persona
        public Task<Int32> PersonaGuardar(Personas persona)
        {
            if(persona.codigo != 0)
            {
                return db.UpdateAsync(persona);
            }
            else
            {
                return db.InsertAsync(persona);
            }
        }

        // Eliminar persona
        public Task<Int32> PersonaEliminar(Personas persona)
        {
            return db.DeleteAsync(persona);
        }

        public Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

    }
}
