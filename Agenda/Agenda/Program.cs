using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agenda
{
    class Program
    {
        static void Main(string[] args){
            //INICIALIZACION DE UNA ESTRUCTURA
            //-------------Forma 1
            /*Agenda[]Contactos=new Agenda[5];
            Contactos[1].nombre = "Juan";
            Contactos[1].apellido = "Mendoza";
            Contactos[1].direccion = "Av. Papa Francisco 200";
            Contactos[1].num = 4204780;
            Console.WriteLine(Contactos[1].ToString());*/
            //-------------Forma 2
            /*Agenda Contactos = new Agenda("Juan","Mendoza","Av. Papa Francisco 200",4204780);
            Console.WriteLine(Contactos.ToString());*/

            List<Agenda> Contactos = new List<Agenda>(); //Inicializo la lista
            char Seguir = 's';
            int opcion;
            //Agrego unos contactos
            Contactos.Add(new Agenda() { nombre="Juan", apellido="Mendoza", direccion="Av. Papa Francisco 200", num=4204780});
            Contactos.Add(new Agenda() { nombre = "Pablo", apellido = "Cordoba", direccion = "Av. Mate de Luna 200", num = 4205450 });
            Contactos.Add(new Agenda() { nombre = "Lucia", apellido = "Mendez", direccion = "Av. Salta 240", num = 4244582});
            Console.WriteLine("---Lista de contactos: \n");
            do{
                //Muestro a pantalla los contactos
                for (int i = 0; i < Contactos.Count; i++) {
                     Console.WriteLine(Contactos[i].ToString());
                }
                //Console.WriteLine(Contactos[1].ToString());
                Console.WriteLine("Cantidad de Contactos: " + Contactos.Count + "\n\n"); //Muestro la cantidad de contactos

                Console.WriteLine("---Elija una de estas opciones\n");
                Console.WriteLine("1) Agregar contacto\n");
                Console.WriteLine("2) Buscar contacto\n");
                Console.WriteLine("3) Eliminar contacto\n");
                Console.WriteLine("Ingrese aqui: ");
                opcion = opcion_menu();
                switch (opcion) {
                    case 1 :
                        //---Agrego  contactos
                        Console.WriteLine("-----Ingrese la cantidad de contactos: ");
                        int cant  = Convert.ToInt32(Console.ReadLine());;
                        int contador = 1;
                        for (int i = 0; i < cant; i++ ){
                            Console.WriteLine("-----Ingrese los datos [" + contador + "]");
                            Console.WriteLine("--Nombre: ");
                            string nom = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("--Apellido: ");
                            string ape = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("--Direccion: ");
                            string dir = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("--Numero de telefono: ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            Contactos.Add(new Agenda() { nombre = nom, apellido = ape, direccion = dir, num = num });
                            contador++;
                        }
                        break;
                    case 2:
                        //---Busco por numero de telefono
                        Console.WriteLine("--Elija el numero de telefono: ");
                        int _tel = Convert.ToInt32(Console.ReadLine());

                        //Verifico que el contacto exista
                        if (Contactos.Exists(x => x.num == _tel) == true){
                            Console.WriteLine(Contactos.Where(x => x.num == _tel).FirstOrDefault()); //Busco el contacto
                        }
                        else Console.WriteLine("--No exite el contacto");
                        break;
                    case 3:
                        //---Borro por numero de telefono
                        Console.WriteLine("--Elija el numero de telefono: ");
                        int num_tel = Convert.ToInt32(Console.ReadLine());
                        //Verifico que el contacto exista
                        if (Contactos.Exists(x => x.num == num_tel) == true) {
                            Contactos.Remove(Contactos.Where(x => x.num == num_tel).FirstOrDefault()); //Elimino el contacto
                        }
                        else Console.WriteLine("--No exite el contacto");
                         
                        break;
                }
                Seguir = continuar();
            }while(Seguir == 'S' || Seguir == 's');

            Console.ReadKey();

        }
        public struct Agenda {
            public string nombre;
            public string apellido;
            public string direccion;
            public int num;

            public Agenda(string A_nombre, String A_Ape,String A_Dir, int A_num) {
                nombre = A_nombre;
                apellido = A_Ape;
                direccion = A_Dir;
                num = A_num;
            }

            public override String ToString() {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("--- Nombre: {0}, Apellido: {1},  Direccion: {2}, Telefono: {3}", nombre, apellido, direccion, num);
                return (sb.ToString());
            }
        }
        static char continuar(){
            char letra;
            Console.WriteLine("Desea continuar? (S/N): ");
            letra = Convert.ToChar(Console.ReadLine());
            while(letra != 's' && letra != 'S' && letra != 'n' && letra !='N'){
                Console.WriteLine("*Elija una opcion valida\nDesea continuar? (S/N): ");
                letra = Convert.ToChar(Console.ReadLine());
            }
            return letra;
        }
        static int opcion_menu() {
            int num;
            num = Convert.ToInt32(Console.ReadLine());
            while (num < 1 && num > 3) {
                Console.WriteLine("*Elija una opcion valida\nIngrese aqui:  ");
                num = Convert.ToInt32(Console.ReadLine());
            }
            return num;
        }
    }
}
