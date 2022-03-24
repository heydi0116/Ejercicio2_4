using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Ejercicio2_4.Modelos;
using System.Threading.Tasks;

namespace Ejercicio2_4.Modelos
{
    public class bd
    {
        readonly SQLiteAsyncConnection db;

        public bd()
        {

        }

        public bd(String pathbasedatos)
        {
            db = new SQLiteAsyncConnection(pathbasedatos);
            db.CreateTableAsync<Datos>();

        }

        public Task<List<Datos>> listaempleados()
        {
            return db.Table<Datos>().ToListAsync();
        }

        public Task<Datos> ObtenerEmpleado(Int32 pcodigo)
        {
            return db.Table<Datos>().Where(i => i.codigo == pcodigo).FirstOrDefaultAsync();
        }

        public Task<Int32> EmpleadoGuardar(Datos emple)
        {
            if (emple.codigo != 0)
            {
                return db.UpdateAsync(emple);
            }
            else
            {
                return db.InsertAsync(emple);
            }
        }

        public Task<Int32> EmpleadoBorrar(Datos emple)
        {
            return db.DeleteAsync(emple);
        }


    }
}
