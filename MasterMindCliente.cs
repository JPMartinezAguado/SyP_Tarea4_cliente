using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyP_Tarea4_cliente
{
    /// <summary>
    /// Clase  contenida en la aplicacion del cliente que contiene la parte de juego que ha de ser manejada por éste.
    /// Basicamente, formatear la respuesta enviada por el servidor con el resultado de la prediccion hecha por el jugador
    /// para ser mostrado de forma facilmente entendible por este
    /// </summary>
    class MasterMindCliente
    {
        #region Campos
        //campos de clase, que serán accedidos desde los distintos metodos de la clase
        //hay valores numericos (correctos, descolocados, intentos) que ya que en esta aplicacion no se realiza ninguna operacion con ellos
        //son tratados como strings, aun siendo menos eficiente en temas de uso de recursos del ordenador, al tratarse de una aplicacion tan sencilla
        //y falicitar el trabajo de los datos, no teniendo que realizar parseos de string a int, para volver a convertirlos a string de nuevo

        static string correctos;//numero de colores adivinados en su posicion correcta
        static string descolocados;//numero de colores adivinados, pero que no estan en la posicion correcta
        static string intentos;//contador de intentos realizados por el jugados

        static char[] charColores = new char[4];//array de caracteres que recogera los codigos de color que devuleve el servidor 

        //array especial que devolverá el servidor en caso de haber acertado el codigo. 
        static char[] ganadora = { 'x', 'x', 'x', 'x' };
        #endregion

        #region Metodos
        /// <summary>
        /// metodo que recoge la respuesta con el resultado del turno de juego enviada por el servidor y la "trocea" para analizar sus datos 
        /// de cara a la impresion por pantalla
        /// </summary>
        /// <param name="respuesta"></param>Respuesta recibida desde el servidor
        internal static void ComprobarResultado(string respuesta)
        {
            //crea un array de strings subdividiendo la respuesta del servidor, usando como splitter un caracter poco usual, esperando que el jugador no lo haya 
            //utilizado. NOTA AL RESPECTO. Como separador, intenté usar ocmo en una tarea anterior, un caracter cirilico, para hacer aun mas complicado el que el
            //jugador lo introduzca en su secuencia. Sin embargo, debido a la codificacion quew realiza el programa para enviar los datos por el flujo,
            //parece que no maneja bien ese caracter, por eso usé éste (quien lo meta, ya lo hace a mala leche :)
            string[] comprobaciones = respuesta.Split('^');

            string colores = comprobaciones[0];//recoge el primer indice del array
            correctos = comprobaciones[1];//el segundo indice indica los aciertos
            descolocados = comprobaciones[2];//el terce indice los aciertos pero no bien posicionados
            intentos = comprobaciones[3];//el cuarto indice el numero de intentos que lleva el jugador

            //llenamos el array de caracteres charColores con los 4 caracteres que contiene el string de colores
            int i = 0;
            foreach (char c in colores)
            {
                if (i < charColores.Length)
                {
                    charColores[i] = c;
                    i++;
                }
            }
        }

        /// <summary>
        /// metodo que formate la salida por pantalla de la respuesta recibida desde el servidor
        /// </summary>
        internal static void MostrarResultado()
        {
            //Formato de impresion personalizada, usando las librerias de la clase Acc (de accesorios), y en la que se pintan espacios vacios utilizando 
            //como fondo el color recogido por cada indice del array de chars creado a partir de la respuesta del servidor y pasados por un metodo que recoge 
            //un char y devulve un color de consola dependiendo del valor del char
            Acc.ImprimirColorTexto("\tTu secuencia es  \t", ConsoleColor.Cyan);
            Acc.ImprimirColorFondo("  ", ObtenerColor(charColores[0]));
            Console.Write("\t");
            Acc.ImprimirColorFondo("  ", ObtenerColor(charColores[1]));
            Console.Write("\t");
            Acc.ImprimirColorFondo("  ", ObtenerColor(charColores[2]));
            Console.Write("\t");
            Acc.ImprimirColorFondo("  ", ObtenerColor(charColores[3]));
            Console.Write("\n\n");

            if (charColores.SequenceEqual(ganadora))//si la secuencia es ganadora (el servidor habrá devuelto "{x,x,x,x}") muestra el mensaje por pantalla y cierra el programa
            {
                Acc.ImprimirColorTextoYFondo($"\n\tENHORABUENA!!, ", ConsoleColor.Red, ConsoleColor.DarkGreen);
                Acc.ImprimirColorTextoYFondo("HAS CONSEGUIDO DESCIFRAR ", ConsoleColor.Cyan, ConsoleColor.DarkGreen);
                Acc.ImprimirColorTextoYFondo(" EL CÓDIGO SECRETO EN", ConsoleColor.Black, ConsoleColor.DarkGreen);
                Acc.ImprimirColorTextoYFondo($" {intentos} INTENTOS", ConsoleColor.Yellow, ConsoleColor.DarkGreen);
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                //Si no ha acertado, se muestran los aciertos, descolocados e intentos del jugador
                Console.Write("\t");
                Acc.ImprimirColorTexto($"CORRECTOS :{correctos}", ConsoleColor.Green);
                Console.Write("\t  ");
                Acc.ImprimirColorTexto($"DESCOLOCADOS :{descolocados}", ConsoleColor.Yellow);
                Console.Write("\t  ");
                Acc.ImprimirColorTexto($"INTENTOS :{intentos}", ConsoleColor.Gray);
                Console.WriteLine("\n");
            }

        }

        /// <summary>
        /// Metodo que recoge el un caracter y le asigna un color de consola en funcion de su valor
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static ConsoleColor ObtenerColor(char c)
        {
            switch (c)
            {
                case 'R': return ConsoleColor.Red;
                case 'V': return ConsoleColor.Green;
                case 'A': return ConsoleColor.Blue;
                case 'Y': return ConsoleColor.Yellow;
                case 'B': return ConsoleColor.White;
                case 'M': return ConsoleColor.Magenta;
                default: return ConsoleColor.DarkGray;//en caso de no haber dado un valor de color válido, el cuadrado se mostratá gris
            }
        }
        #endregion

    }
}
