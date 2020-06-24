using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeDatos
{
    class CLibros
    {
        //Variables Miembro
        private ArrayList listado;
        //Constructor
        public CLibros()
        {
            this.listado = new ArrayList();
        }
        public CLibro BuscaLibro(ulong cod)
        {
            foreach (CLibro aux in this.listado)
            {
                if (aux.GetCodigo() == cod) return aux;
            }
            return null;
        }
        public bool CrearLibro(ulong cod, string edit, string tit, byte sto)
        {
            if (this.BuscaLibro(cod) == null)
            {
                this.listado.Add(new CLibro(cod, edit, tit, sto));
                return true;
            }
            return false;
        }
        public string DarDatos(ulong cod)
        {
            CLibro aux = this.BuscaLibro(cod);
            if (aux != null) return aux.DarDatos();
            return "Alumno inexistente";
        }
        public string DarDatos()
        {

            if (this.listado.Count != 0)
            {
                String datos = "";
                foreach (CLibro aux in this.listado) datos += aux.DarDatos() + "\n";
                return datos;
            }
            return "No se registraron Libros válidos";
        }
        public bool EliminarLibro(ulong cod)
        {
            CLibro aux = this.BuscaLibro(cod);
            if (aux != null)
            {
                this.listado.Remove(aux);
                return true;
            }
            return false;
        }
        public void SetAlquiler(float alq)
        {
            CLibro.SetAlquiler(alq);
        }
        public float GetAlquiler()
        {
            return CLibro.GetAlquiler();
        }
        public float DarPrecioAlquiler(ulong cod)
        {
            CLibro aux = this.BuscaLibro(cod);
            if (aux != null) return aux.DarPrecioAlquiler();
            return 0.0f;
        }
        public void Ordenar()
        {
            this.listado.Sort();
        }
    }
}
