using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeDatos
{
    public class CLibro : IComparable
    {
        //Variables miembro de instancia
        private ulong codigo;
        private string titulo;
        private string editorial;
        private byte stock;
        //Variables miembro de clase
        private static float alquiler;
        //Metodos miembro de instancia
        //Constructores
        //Por defecto
        public CLibro()
        {
            this.codigo = 0;
            this.titulo = "sin asignar";
            this.editorial = "sin asignar";
            this.stock = 0;
        }
        //Parametrizados
        public CLibro(ulong cod)
        {
            this.codigo = cod;
        }
        public CLibro(ulong cod, string tit, string edit, byte sto)
        {
            this.codigo = cod;
            this.titulo = tit;
            this.editorial = edit;
            this.stock = sto;
        }
        //Setters de instancia
        public void SetCodigo(ulong cod)
        { this.codigo = cod; }
        public void SetTitulo(string tit)
        { this.titulo = tit; }
        public void SetEditorial(string edit)
        { this.editorial = edit; }
        public void SetStock(byte sto)
        { this.stock = sto; }
        //Getters de instancia
        public ulong GetCodigo()
        { return this.codigo; }
        public string GetTitulo()
        { return this.titulo; }
        public string GetEditorial()
        { return this.editorial; }
        public float GetStock()
        { return this.stock; }
        //Propiedades miembro de instancia
        //De lecto escritura
        public ulong Codigo
        {
            set { this.codigo = value; }
            get { return this.codigo; }
        }
        //De solo lectura
        public byte Stock
        {
            set { this.stock = value; }
        }
        //De solo lectura
        public string Titulo
        {
            get { return this.titulo; }
        }
        //Metodos funcionales de instancia
        public string DarDatos()
        {
            string ret = this.codigo.ToString();
            ret += "-" + this.editorial + ", " + this.titulo;
            ret += "-Stock: " + this.stock.ToString() + "Unidades.";
            ret += "-Precio Alquiler: $" + CLibro.alquiler.ToString();
            ret += "-Cuota Personal: $ " + this.DarPrecioAlquiler().ToString();
            return ret;
        }
        public float DarPrecioAlquiler()
        {
            if (this.stock <= 25)
            {
                return CLibro.alquiler += ((CLibro.alquiler * 40) / 100);
            }

            if (this.stock > 25 && this.stock <= 50)
            {
                return CLibro.alquiler += ((CLibro.alquiler * 30) / 100);
            }

            if (this.stock > 50 && this.stock <= 75)
            {
                return CLibro.alquiler += ((CLibro.alquiler * 20) / 100);
            }

            if (this.stock > 75 && this.stock <= 100)
            {
                return CLibro.alquiler += ((CLibro.alquiler * 10) / 100);
            }

            return CLibro.alquiler;
        }
        //Finalizadores
        //Por defecto
        ~CLibro()
        {
            //Procedimiento a realizar inmediatamente antes de la destrucción. No es invocable
            Console.Write("AUXILIOOO!!!");
        }
        //Alternativa invocable
        public void Dispose()
        {
            //Tarea a realizar al momento de la invocacion
            System.GC.SuppressFinalize(this); //No ejecutar el finalizador por defecto
        }
        //Metodos miembro de clase
        //Setter de alquiler
        public static void SetAlquiler(float precioalq)
        { CLibro.alquiler = precioalq; }
        //Getter de alquiler
        public static float GetAlquiler()
        { return CLibro.alquiler; }
        //Propiedades miembro de clase
        public static float Alquiler
        {
            set { CLibro.alquiler = value; }
            get { return CLibro.alquiler; }
        }
        //CompareTo de IComparable
        public int CompareTo(object obj)
        {
            if (obj is CLibro)
            {
                return (int)(this.codigo - ((CLibro)obj).GetCodigo());
            }
            return int.MaxValue;
        }
    } //Fin de la clase
}
