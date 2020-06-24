using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeDatos
{
    class CControladora
    {
        static void Main(string[] args)
        {
            CLibros listadoLibros = new CLibros();
            char opcion;
            ulong auxCodigo;
            do
            {
                char.TryParse(CInterfaz.DarOpcion().ToUpper(), out opcion);
                //.ToUpper() Convierte la cadena a MAYÚSCULAS.
                switch (opcion)
                {
                    case 'C':
                        listadoLibros.SetAlquiler(Convert.ToSingle(CInterfaz.PedirDato("Precio General Alquiler")));
                        break;
                    case 'G':
                        CInterfaz.MostrarInfo(Convert.ToString(listadoLibros.GetAlquiler()));
                        break;
                    case 'A':
                        auxCodigo = Convert.ToUInt64(CInterfaz.PedirDato("Codigo"));
                        string auxApellidos = CInterfaz.PedirDato("Editorial");
                        string auxNombres = CInterfaz.PedirDato("Titulo");
                        byte auxStock = Convert.ToByte(CInterfaz.PedirDato("Stock"));
                        if (!listadoLibros.CrearLibro(auxCodigo, auxApellidos, auxNombres, auxStock))
                        {
                            CInterfaz.MostrarInfo("Codigo Preexistente");
                        }
                        break;
                    case 'M':
                        auxCodigo = Convert.ToUInt64(CInterfaz.PedirDato("Codigo"));
                        CInterfaz.MostrarInfo(listadoLibros.DarDatos(auxCodigo));
                        break;
                    case 'L':
                        listadoLibros.Ordenar();
                        CInterfaz.MostrarInfo(listadoLibros.DarDatos());
                        break;
                    case 'R':
                        auxCodigo = Convert.ToUInt64(CInterfaz.PedirDato("Codigo"));
                        if (!listadoLibros.EliminarLibro(auxCodigo))
                        {
                            CInterfaz.MostrarInfo("Libro Inexistente");
                        }
                        break;
                    case 'S':
                        break;
                    default:
                        CInterfaz.MostrarInfo("Opción inválida");
                        break;
                }
            } while (opcion != 'S');
        }
    }
    
}
