using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyP_Tarea4_cliente
{
    /// <summary>
    /// clase auxiliar que creé para formatear la salida de texto por consola, permitiendo definir cada  salida de forma individual
    /// y regresar automaticamente al formato estandard para la siguiente linea. Creé metodos para los distintos casos de querer modificar
    /// el color del texto o del fondo o ambos a la vez, tanto saltando para el metodo WriteLine como para el Write.
    /// 
    /// La secuencia de acciones de los metodos es:
    /// 
    /// 1. guardar los atributos por defecto en una variable de tipo ConnsoleColor.
    /// 2. Definir los parametros que queremos aplicar a esa entrada en cuestion
    /// 3. Pintar el texto por pantalla
    /// 4. Restaurar valores por defecto
    /// 
    /// Asimismo, guarda una cabecera personailaza para esta aplicacion, sin mayor valor que el estético
    /// </summary>
    public static class Acc
    {
        public static void ImprimirLineaColorTextoYFondo(string texto, ConsoleColor colorTexto, ConsoleColor colorFondo)
        {
            ConsoleColor colorTextoOriginal = Console.ForegroundColor;
            ConsoleColor colorFondoOriginal = Console.BackgroundColor;
            Console.ForegroundColor = colorTexto;
            Console.BackgroundColor = colorFondo;
            Console.WriteLine(texto);
            Console.ForegroundColor = colorTextoOriginal;
            Console.BackgroundColor = colorFondoOriginal;
        }

        public static void ImprimirLineaColorTexto(string texto, ConsoleColor colorTexto)
        {
            ConsoleColor colorTextoOriginal = Console.ForegroundColor;
            Console.ForegroundColor = colorTexto;
            Console.WriteLine(texto);
            Console.ForegroundColor = colorTextoOriginal;
        }

        public static void ImprimirLineaColorFondo(string texto, ConsoleColor colorFondo)
        {
            ConsoleColor colorFondoOriginal = Console.BackgroundColor;
            Console.BackgroundColor = colorFondo;
            Console.WriteLine(texto);
            Console.BackgroundColor = colorFondoOriginal;
        }

        public static void ImprimirColorTextoYFondo(string texto, ConsoleColor colorTexto, ConsoleColor colorFondo)
        {
            ConsoleColor colorTextoOriginal = Console.ForegroundColor;
            ConsoleColor colorFondoOriginal = Console.BackgroundColor;
            Console.ForegroundColor = colorTexto;
            Console.BackgroundColor = colorFondo;
            Console.Write(texto);
            Console.ForegroundColor = colorTextoOriginal;
            Console.BackgroundColor = colorFondoOriginal;
        }

        public static void ImprimirColorTexto(string texto, ConsoleColor colorTexto)
        {
            ConsoleColor colorTextoOriginal = Console.ForegroundColor;
            Console.ForegroundColor = colorTexto;
            Console.Write(texto);
            Console.ForegroundColor = colorTextoOriginal;
        }

        public static void ImprimirColorFondo(string texto, ConsoleColor colorFondo)
        {
            ConsoleColor colorFondoOriginal = Console.BackgroundColor;
            Console.BackgroundColor = colorFondo;
            Console.Write(texto);
            Console.BackgroundColor = colorFondoOriginal;
        }

        public static void PrintCabecera() 
        {
                PrintLineaMeta();
              
            Console.Write("\n\n");

            //ImprimirColorTextoYFondo("\t\tJuego del MasterMind", ConsoleColor.Black, ConsoleColor.Gray);
            
            Console.Write("\n");
            ImprimirLineaColorTexto("\t\t    █     █      █       ████  █████  █████  ████ ", ConsoleColor.Red);
            ImprimirLineaColorTexto("\t\t    ██   ██     █ █    ██        █    █      █  █ ", ConsoleColor.Yellow);
            ImprimirLineaColorTexto("\t\t    █ █ █ █    █   █     ███     █    ███    ████ ", ConsoleColor.Blue);
            ImprimirLineaColorTexto("\t\t    █  █  █   █     █      ██    █    █      █ █  ", ConsoleColor.Green);
            ImprimirLineaColorTexto("\t\t    █     █  █ █████ █      ██   █    █      █  █ ", ConsoleColor.White);
            ImprimirLineaColorTexto("\t\t    █     █ █         █ ████     █    █████  █   █", ConsoleColor.Magenta);
            //Console.WriteLine("\n");
            ImprimirLineaColorTextoYFondo("\t\t\t  ██    ██  ██████  ██    ██   ███    ", ConsoleColor.Black, ConsoleColor.Green);
            ImprimirLineaColorTextoYFondo("\t\t\t  ███  ███    ██    ███   ██   ██ ██  ", ConsoleColor.Black, ConsoleColor.DarkYellow);
            ImprimirLineaColorTextoYFondo("\t\t\t  ████████    ██    ████  ██   ██  ██ ", ConsoleColor.Black, ConsoleColor.Red);
            ImprimirLineaColorTextoYFondo("\t\t\t  ██ ██ ██    ██    ██ ██ ██   ██  ██ ", ConsoleColor.Black, ConsoleColor.White);
            ImprimirLineaColorTextoYFondo("\t\t\t  ██    ██    ██    ██  ████   ██ ██  ", ConsoleColor.Black, ConsoleColor.Blue);
            ImprimirLineaColorTextoYFondo("\t\t\t  ██    ██  ██████  ██   ███   ███    ", ConsoleColor.Black, ConsoleColor.Magenta);

            ImprimirLineaColorTextoYFondo("\n\t\tEl juego de descubrir el codigo secreto, te atreves?", ConsoleColor.DarkGreen, ConsoleColor.White);
            //Console.WriteLine("\n");

            //PrintLineaMeta();
            Console.WriteLine("\n\tPara everiguar el código de 4 colores deberás escribir tu predicción\n\tde entre los 6 coloeres disponibles." +
                "Te iré indicando cuantos colores\n\thas acertado su posicion y cuantos colores acertaste pero desubicadas.\n\tLos colores disponibles son los siguientes: \n");

            ImprimirLineaColorTexto("\t\t\t   * Escribe R para rojo ", ConsoleColor.Red);
            ImprimirLineaColorTexto("\t\t\t   * Escribe A para azul ", ConsoleColor.Blue);
            ImprimirLineaColorTexto("\t\t\t   * Escribe V para verde ", ConsoleColor.Green);
            ImprimirLineaColorTexto("\t\t\t   * Escribe Y para amarillo ", ConsoleColor.Yellow);
            ImprimirLineaColorTexto("\t\t\t   * Escribe B para blanco ", ConsoleColor.White);
            ImprimirLineaColorTexto("\t\t\t   * Escribe M para magenta ", ConsoleColor.Magenta);

            Console.WriteLine("\n\tSolo tendrás que escribir una secuencia de 4 iniciales. Ejemplo: \"RDMB\".\n\tPero cuidado, si te equivocas y" +
                "escribes un caracter que no está entre\n\tlos 6 aceptados, cuenta como una predicción y no te daré información\n\tde como lo has hecho en esa ronda." +
                "El recuadro parecerá en color gris\n");


        }

        public static void PrintLineaMeta() 
        {
            int contadorlinea = 0;
            Console.Write("\t");
            while (contadorlinea < 17)
            {
                ImprimirColorFondo("  ", ConsoleColor.Black);
                ImprimirColorFondo("  ", ConsoleColor.White);
                contadorlinea++;
            }
            Console.Write("\n");

            Console.Write("\t    ");
            contadorlinea = 0;
            while (contadorlinea < 16)
            {
                ImprimirColorFondo("  ", ConsoleColor.White);
                ImprimirColorFondo("  ", ConsoleColor.Black);
                contadorlinea++;
            }
            Console.Write("\n");

            Console.Write("\t");
            contadorlinea = 0;
            while (contadorlinea < 17)
            {
                ImprimirColorFondo("  ", ConsoleColor.Black);
                ImprimirColorFondo("  ", ConsoleColor.White);
                contadorlinea++;
            }
        }
        public static void PrintENcabezado()
        {
            int contadorlinea = 0;
            Console.Write("\t");
            while (contadorlinea < 16)
            {
                ImprimirColorFondo("  ", ConsoleColor.Black);
                ImprimirColorFondo("  ", ConsoleColor.White);
                contadorlinea++;
            }
            Console.Write("\n");

            Console.Write("\t    ");
            contadorlinea = 0;
            while (contadorlinea < 15)
            {
                ImprimirColorFondo("  ", ConsoleColor.White);
                ImprimirColorFondo("  ", ConsoleColor.Black);
                contadorlinea++;
            }
            Console.Write("\n");

            Console.Write("\t");
            contadorlinea = 0;
            while (contadorlinea < 16)
            {
                ImprimirColorFondo("  ", ConsoleColor.Black);
                ImprimirColorFondo("  ", ConsoleColor.White);
                contadorlinea++;
            }
            Console.Write("\n\n");
            ImprimirLineaColorTexto("\t\t   █   █   █    ██ ███ ███ ███  █   █ █ █  █ ██    ", ConsoleColor.Red);
            ImprimirLineaColorTexto("\t\t   █ █ █  █ █  █    █  █   █  █ █ █ █ █ ██ █ █ █   ", ConsoleColor.Yellow);
            ImprimirLineaColorTexto("\t\t   █   █ █ █ █   █  █  ██  ███  █   █ █ █ ██ █ █   ", ConsoleColor.Blue);
            ImprimirLineaColorTexto("\t\t   █   █ █   █ ██   █  █ █ █  █ █   █ █ █  █ ██    ", ConsoleColor.Green);

            ImprimirLineaColorTextoYFondo("\n\t\t      El juego de descubrir el codigo secreto      ", ConsoleColor.DarkGreen, ConsoleColor.White);
            Console.WriteLine();
        }

        //no borrar
        //
        //    ImprimirLineaColorTexto("\t\tM     M       A         SSSS  TTTTT  EEEEE    RRRR  ", ConsoleColor.Red);
        //    ImprimirLineaColorTexto("\t\tMM   MM      A A      SS        T    E        R   R ", ConsoleColor.Yellow);
        //    ImprimirLineaColorTexto("\t\tM M M M     A   A       SSS     T    EEE      RRRR  ", ConsoleColor.Blue);
        //    ImprimirLineaColorTexto("\t\tM  M  M    A     A        SS    T    E        R R   ", ConsoleColor.Green);
        //    ImprimirLineaColorTexto("\t\tM     M   A AAAAA A        S    T    E        R  R  ", ConsoleColor.White);
        //    ImprimirLineaColorTexto("\t\tM     M  A         A   SSSS     T    EEEEE    R   R ", ConsoleColor.Magenta);
        //}
    }

}
