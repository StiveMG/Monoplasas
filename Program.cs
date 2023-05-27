using System;
using System.Collections.Generic;

// Clase abstracta que representa un vehículo de tipo monoplaza
public abstract class Monoplaza
{
    protected bool encendido;
    protected bool detenido;
    protected bool enMovimiento;

    public Monoplaza()
    {
        encendido = false;
        detenido = true;
        enMovimiento = false;
    }

    public void Encender()
    {
        if (!encendido)
        {
            encendido = true;
            Console.WriteLine("El monoplaza está encendido.");
        }
    }

    public void Apagar()
    {
        if (encendido && detenido)
        {
            encendido = false;
            Console.WriteLine("El monoplaza está apagado.");
        }
    }

    public void Detener()
    {
        if (encendido && enMovimiento)
        {
            detenido = true;
            enMovimiento = false;
            Console.WriteLine("El monoplaza está detenido.");
        }
    }

    public void Mover()
    {
        if (encendido && detenido)
        {
            detenido = false;
            enMovimiento = true;
            Console.WriteLine("El monoplaza está en movimiento.");
        }
    }

    public abstract string ObtenerEscuderia();
}

// Clase que representa un monoplaza de la escudería McLaren
public class McLaren : Monoplaza
{
    public override string ObtenerEscuderia()
    {
        return "McLaren";
    }
}

// Clase que representa un monoplaza de la escudería Ferrari
public class Ferrari : Monoplaza
{
    public override string ObtenerEscuderia()
    {
        return "Ferrari";
    }
}

// Clase que representa un monoplaza de la escudería Red Bull
public class RedBull : Monoplaza
{
    public override string ObtenerEscuderia()
    {
        return "Red Bull";
    }
}

// Clase que representa el circuito
public class Circuito
{
    private string nombre;
    private int vueltasPermitidas;
    private Monoplaza monoplazaActual;
    private List<double> tiemposVueltas;

    public Circuito(string nombre, int vueltasPermitidas)
    {
        this.nombre = nombre;
        this.vueltasPermitidas = vueltasPermitidas;
        monoplazaActual = null;
        tiemposVueltas = new List<double>();
    }

    public void AgregarMonoplaza(Monoplaza monoplaza)
    {
        if (monoplazaActual == null)
        {
            monoplazaActual = monoplaza;
        }
    }

    public void SacarMonoplaza()
    {
        if (monoplazaActual != null)
        {
            monoplazaActual.Apagar();
            monoplazaActual = null;
        }
    }

    public void RealizarPrueba()
    {
        if (monoplazaActual != null)
        {
            monoplazaActual.Encender();
            monoplazaActual.Mover();

            Random random = new Random();
            for (int i = 1; i <= vueltasPermitidas; i++)
            {
                double tiempoVuelta = random.NextDouble() * 900000 + 100000; // Genera un número aleatorio de 6 cifras
                tiemposVueltas.Add(tiempoVuelta);
                Console.WriteLine($"Tiempo de vuelta {i}: {tiempoVuelta}");
            }

            monoplazaActual.Detener();
            monoplazaActual.Apagar();
            monoplazaActual = null;

            Console.WriteLine("Prueba finalizada.");
        }
        else
        {
            Console.WriteLine("No hay monoplaza en el circuito.");
        }
    }

    public void MostrarTablaPosiciones()
    {
        if (tiemposVueltas.Count == 0)
        {
            Console.WriteLine("No se han registrado tiempos de vuelta.");
            return;
        }

        tiemposVueltas.Sort();

        Console.WriteLine("Tabla de Posiciones:");
        Console.WriteLine("Escudería\tTiempo de Vuelta");

        foreach (double tiempo in tiemposVueltas)
        {
            Console.WriteLine($"{monoplazaActual.ObtenerEscuderia()}\t{tiempo}");
        }
    }
}

// Ejemplo de uso del programa
class Program
{
    static void Main(string[] args)
    {
        Circuito circuito = new Circuito("Circuito de Prueba", 5);

        McLaren mclaren = new McLaren();
        Ferrari ferrari = new Ferrari();
        RedBull redBull = new RedBull();

        circuito.AgregarMonoplaza(mclaren);
        circuito.RealizarPrueba();

        circuito.AgregarMonoplaza(ferrari);
        circuito.RealizarPrueba();

        circuito.AgregarMonoplaza(redBull);
        circuito.RealizarPrueba();

        circuito.MostrarTablaPosiciones();
    }
}
