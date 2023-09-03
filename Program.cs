using System;

namespace ConsoleApp2
{
    class Program
    {
        static string[] codigo = new string[100];
        static string[] nombre = new string[100];
        static DateTime[] fechaNacimiento = new DateTime[100];
        static string[] grado = new string[100];
        static int[] añoRegistro = new int[100];
        static int totalAlumnos = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menú Principal");
                Console.WriteLine("1. Agregar un alumno");
                Console.WriteLine("2. Mostrar listado de alumnos");
                Console.WriteLine("3. Buscar alumno por código");
                Console.WriteLine("4. Editar información de un alumno por código");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                int opcion;
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        AgregarAlumno();
                        break;
                    case 2:
                        MostrarListadoAlumnos();
                        break;
                    case 3:
                        BuscarAlumnoPorCodigo();
                        break;
                    case 4:
                        EditarAlumnoPorCodigo();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
        }

        static void AgregarAlumno()
        {
            Console.WriteLine("Agregar un nuevo alumno:");

            Console.Write("Código: ");
            string codigoAlumno = Console.ReadLine();

            Console.Write("Nombre completo: ");
            string nombreAlumno = Console.ReadLine();

            Console.Write("Fecha de nacimiento (yyyy-MM-dd): ");
            DateTime fechaNacimientoAlumno;
            if (!DateTime.TryParse(Console.ReadLine(), out fechaNacimientoAlumno))
            {
                Console.WriteLine("Fecha de nacimiento no válida.");
                return;
            }

            Console.Write("Grado: ");
            string gradoAlumno = Console.ReadLine();

            Console.Write("Año de registro: ");
            int añoRegistroAlumno;
            if (!int.TryParse(Console.ReadLine(), out añoRegistroAlumno))
            {
                Console.WriteLine("Año de registro no válido.");
                return;
            }

            codigo[totalAlumnos] = codigoAlumno;
            nombre[totalAlumnos] = nombreAlumno;
            fechaNacimiento[totalAlumnos] = fechaNacimientoAlumno;
            grado[totalAlumnos] = gradoAlumno;
            añoRegistro[totalAlumnos] = añoRegistroAlumno;

            totalAlumnos++;
        }

        static void MostrarListadoAlumnos()
        {
            Console.WriteLine("Listado de Alumnos:");
            Console.WriteLine("Código\tNombre\tFecha de Nacimiento\tGrado\tAño de Registro");

            for (int i = 0; i < totalAlumnos; i++)
            {
                Console.WriteLine($"{codigo[i]}\t{nombre[i]}\t{fechaNacimiento[i]:yyyy-MM-dd}\t{grado[i]}\t{añoRegistro[i]}");
            }
        }

        static void BuscarAlumnoPorCodigo()
        {
            Console.Write("Ingrese el código del alumno a buscar: ");
            string codigoBuscado = Console.ReadLine();

            int indice = -1;
            for (int i = 0; i < totalAlumnos; i++)
            {
                if (codigo[i] == codigoBuscado)
                {
                    indice = i;
                    break;
                }
            }

            if (indice != -1)
            {
                Console.WriteLine($"Alumno encontrado:");
                Console.WriteLine($"Código: {codigo[indice]}");
                Console.WriteLine($"Nombre: {nombre[indice]}");
                Console.WriteLine($"Fecha de Nacimiento: {fechaNacimiento[indice]:yyyy-MM-dd}");
                Console.WriteLine($"Grado: {grado[indice]}");
                Console.WriteLine($"Año de Registro: {añoRegistro[indice]}");
            }
            else
            {
                Console.WriteLine("Alumno no encontrado.");
            }
        }

        static void EditarAlumnoPorCodigo()
        {
            Console.Write("Ingrese el código del alumno a editar: ");
            string codigoBuscado = Console.ReadLine();

            int indice = -1;
            for (int i = 0; i < totalAlumnos; i++)
            {
                if (codigo[i] == codigoBuscado)
                {
                    indice = i;
                    break;
                }
            }

            if (indice != -1)
            {
                Console.WriteLine("Editar información del alumno:");
                Console.Write("Nuevo nombre completo: ");
                nombre[indice] = Console.ReadLine();

                Console.Write("Nueva fecha de nacimiento (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out fechaNacimiento[indice]))
                {
                    Console.WriteLine("Fecha de nacimiento no válida.");
                    return;
                }

                Console.Write("Nuevo grado: ");
                grado[indice] = Console.ReadLine();

                Console.Write("Nuevo año de registro: ");
                if (!int.TryParse(Console.ReadLine(), out añoRegistro[indice]))
                {
                    Console.WriteLine("Año de registro no válido.");
                    return;
                }

                Console.WriteLine("Información actualizada.");
            }
            else
            {
                Console.WriteLine("Alumno no encontrado.");
            }
        }
    }
}
