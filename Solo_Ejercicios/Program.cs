using System;

namespace Sistema_Retiro_Bancario;

class Program
{
    static void Main(string[] args)
    {
        //Orden alfabético de variables

        double saldo = 0, descuento = 0, retiro = 0, retiroAcumulado = 0;
        int registro = 0, contraseñaUsuario = 0;
        bool opcion = true, VerificarAcceso = true;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== SISTEMA DE RETIROS BANCARIOS ===");
        Console.WriteLine("Por favor, ingresa tu contraseña.");

        if (! ValidarAcceso(1234, 3))  
        {
            return;
        }

        Console.WriteLine("Por favor, ingresa el saldo inicial de tu cuenta bancaria..");
        try
        {
            saldo = Convert.ToDouble(Console.ReadLine());
            Console.Clear();
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: El saldo ingresado no es válido. Por favor, ingresa un número.");
            Console.WriteLine("Sesión cerrada.");
            return;
        }

        Console.WriteLine("Por favor, ingresa el monto a retirar..");

            try
            {
                retiro = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: El monto ingresado no es válido. Por favor, ingresa un número.");
                Console.WriteLine("Sesión cerrada.");
                return;
            }


        while (saldo > 0)
        {
            if (retiro < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El retiro asignado es inválido. Por intenta nuevamente");

                try
                {
                    retiro = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El monto ingresado no es válido. Por favor, ingresa un número.");
                    Console.WriteLine("Sesión cerrada.");
                    return;
                }
            }
            else 
            {
                if (retiro > saldo)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El retiro no ha sido aceptado, supera el saldo disponible.");

                }
                else 
                {
                    saldo -= retiro;
                    retiroAcumulado += retiro;
                    registro++;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Has retirado el monto con éxito.");
                    Console.WriteLine("Monto retirado: {0} ", retiro);
                    Console.WriteLine("Saldo actual: {0} ", saldo);
                    Console.ResetColor();

                    Console.WriteLine("");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("¿Deseas retirar otro monto adicional? S/N");
                    opcion = Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase); 
                    Console.Clear();

                }

            }

            if (opcion == true)
            {
                Console.WriteLine("Por favor, ingresa el monto a retirar");
                retiro = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
            }
            else if (opcion == false)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Gracias por usar el sistema de retiros bancarios.");
                Console.WriteLine("Número de retiros realizados: {0}", registro);
                Console.WriteLine("Monto retirado acumulado: {0} ", retiroAcumulado);
                Console.WriteLine("Saldo final: {0}", saldo);
                return;
            }

        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Te has quedado sin saldo en tu cuenta bancaria.");
        Console.WriteLine("Gracias por usar el sistema de retiros bancarios.");
        Console.WriteLine("Monto retirado acumulado: {0} ", retiroAcumulado);
        Console.WriteLine("Número de retiros realizados: {0}", registro);
        Console.WriteLine("Saldo final: {0}", saldo);
        return;

    }

    static bool ValidarAcceso(int pinCorrecto, int intentosMaximos)
    {
        int intentos = 0;
        int pinIngresado = 0;

       

        while (intentos < intentosMaximos)
        {
            try
            {
                pinIngresado = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: El PIN ingresado no es válido");
                return false;
            }

            if (pinIngresado == 1234)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Acceso concedido.");
                return true;
                
            }
            else
            {
                intentos++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Contraseña incorrecta. Intento {0} de {1}.", intentos, intentosMaximos);
                
            }
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Has excedido el número máximo de intentos. Acceso denegado.");
        return false;
    }
}