using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SyP_Tarea4_cliente
{
    /// <summary>
    /// Clase prijncipal de la aplicacion cliente, que maneja la conecxion y el envio de datos bidireccional con el servidor
    /// </summary>
    class Program
    {
        //Punto de arranque de la aplicación
        static void Main(string[] args)
        {

            Acc.PrintCabecera();//imprime la cabecera del programa, previamente diseñada en la clase accesoria Acc

            bool conectado = false;//boolenano que comprueba si existe conexion con el servidor

            //Objetos TcpClinet y NetworkStream declarados fuera del try/catch para que puyedan ser accedidos desde otras partes del metodo Main
            TcpClient cliente = null;
            NetworkStream stream = null;

            //Bucle que reintentará conectar con el servidor mientras éste esté activo
            while (!conectado)
            {
                try
                {
                    //IP y puerto donde el programa va a intentar localizar al servidor
                    string server = "127.0.0.1";
                    int puerto = 1234;

                    cliente = new TcpClient(server, puerto);//se crea un objeto de protocolo de coenxion con la Ip y puerto declarados
                    stream = cliente.GetStream();//se abre un flujo de datos entre el cliente y el servidor
                    
                    
                    conectado = true;//se informa de que la ocnexion ha sido exitosa para que salga del bucle de reintento de conexion
                }
                //excepcion que captura el hecho de que el servidor no esté disponible. Informa de la circunstancia y duerme el hilo por 5 segundos
                //antes de reintentar la conecxion, al permanecer el booleano conectado como false
                catch (Exception ex)
                {
                    Console.WriteLine("\tServidor no disponible, Intentando conectar de nuevo en 5 segndos");
                    Thread.Sleep(5000);

                }
            }

            Console.Clear();
            Acc.PrintENcabezado();
            Console.WriteLine("\tConectado al juego. Escribe una prediccion o escribe 'SALIR' para salir:");
            //Una vez conectado, se intenta enviar y recibir mensajes mientras haya datos en el flujo
            try
            { 
                while (true)
                {
                    // Recoger mensaje del usuario
                    Console.Write("\t");
                    string mensaje = Console.ReadLine().ToUpper();

                    // Si el usuario escribe "SALIR", sale del bucle y ejecuta el cierre del flujo y el objeto protocolo de conexion
                    if (mensaje == "SALIR")
                    {
                        break;
                    }

                    // Enviar mensaje al servidor
                    byte[] data = Encoding.ASCII.GetBytes(mensaje);
                    stream.Write(data, 0, data.Length);

                    // Recibir respuesta del servidor
                    Byte[] data2 = new byte[1024];
                    int bytes = stream.Read(data2, 0, data2.Length);
                    string respuesta = Encoding.ASCII.GetString(data2, 0, bytes);

                    //llamada a los metodo que formatea el resultado obtenido desde el servidor 
                    MasterMindCliente.ComprobarResultado(respuesta);

                    //llamada al metodo que recoge los datos formateados por el metod anterior y muestra el resultado por pantalla
                    MasterMindCliente.MostrarResultado();
                }

                // Cerrar flujo y conexion
                stream.Close();
                cliente.Close();
            }
            catch (Exception e)
            {
                //Mensaje que recibe el usuario si una vez realizada la conexion, no es posible establecer un flujo de datos
                //porque el servidor ya ha alcanzado el limite de conexiones que tiene establecido. Despues de mostrar el mensaje, espera por el usuario
                //para cerrar la aplicacion
                Acc.ImprimirColorFondo("\tNO ERES TU, SOY YO. Lo sineto, pero ahora estoy muy lleno. Vuelve mas tarde  ", ConsoleColor.Red);
                Console.Write("\n\t");
                Acc.ImprimirColorFondo("         a ver si alguno de los jugadores ha abandonado el servidor.         ", ConsoleColor.Red);
                Console.Write("\n\n\t");
                Acc.ImprimirColorFondo("            Ahora pulsa cualquier tecla para cerrar la aplicacion            ", ConsoleColor.Red);
                Console.ReadKey();
            }
        }
    }
}
