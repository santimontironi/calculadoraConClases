using Operacion;
using Historial;
using System.Collections.Generic;

static void Menu()
{
    List<Historiales> listaHistorial = new List<Historiales>(); //Se crea una lista vacia que solo puede contener instancias de la clase Historiales.

    bool corriendoMenu = true; //Variable bandera para que el menu se ejecute.

    while (corriendoMenu)
    {
        Console.WriteLine("**MENU PRINCIPAL DEL SISTEMA**\n" +
                                  "1 -> Sumar\n" +
                                  "2 -> Restar\n" +
                                  "3 -> Multiplicar\n" +
                                  "4 -> Dividir\n" +
                                  "5 -> Ver historial\n" +
                                  "6 -> Ver que operación se realizó mas veces \n" +
                                  "7 -> Salir del programa");

        Console.WriteLine("Por favor ingrese una opcion:");
        string input = Console.ReadLine();
        int opcion = int.Parse(input);
        Console.Clear(); //Se limpia la consola para solo mostrar que es lo que se hace al ingresar una opcion y no reciclar la muestra del menu.

        if (opcion == 1)
        {
            realizarOperacion("suma", listaHistorial); //Se llama a la funcion realizarOperacion junto con la operacion correspondiente y la listaHistorial para poder usar en dicha funcion.
        }
        else if (opcion == 2)
        {
            realizarOperacion("resta", listaHistorial);
        }
        else if (opcion == 3)
        {
            realizarOperacion("multiplicacion", listaHistorial);
        }
        else if (opcion == 4)
        {
            realizarOperacion("division", listaHistorial);

        }
        else if (opcion == 5)
        {
            verHistorial(listaHistorial);
        }
        else if (opcion == 6)
        {
            operacionMasRealizada(listaHistorial);
        }
        else if (opcion == 7)
        {
            Console.WriteLine("Gracias por usar la calculadora. Hasta pronto!");
            corriendoMenu = false; //La variable bandera cambia su estado a false para poder terminar el recorrido del menu y cerrar el programa.
        }
        else
        {
            Console.WriteLine("Opcion no valida, por favor ingrese nuevamente"); //Mensaje en caso de que se ingrese un numero invalido.
        }
    }
}


Menu();

static void realizarOperacion(string operacion, List<Historiales> listaHistorial) //Funcion que realiza las operaciones, obtiene la operacion y la lista vacia de la clase historiales.
{
    Console.WriteLine("Por favor ingrese el primer numero:");
    string inputNum1 = Console.ReadLine();
    double num1 = double.Parse(inputNum1);

    Console.WriteLine("Por favor ingrese el segundo numero:");
    string inputNum2 = Console.ReadLine();
    double num2 = double.Parse(inputNum2);

    double resultado = 0; //Se declara la variable resultado en 0 para luego actualizarla en cada operacion y almacenarla luego en el historial.
    string operando = ""; //Se declara la variable operando en '' para luego actualizarla en cada operacion y almacenarla luego en el historial.

    Operaciones operacion1 = new Operaciones(); //Se crea una nueva instancia de la clase operaciones para luego usar cada metodo correspondiente.

    if (operacion == "suma")
    {
        Console.Clear();
        resultado = operacion1.sumar(num1, num2); //Se llama al metodo sumar de la clase Operaciones.
        operando = "+"; //Se actualiza la variable operando con su respectivo operando.
        Console.WriteLine($"El resultado de la suma es {resultado}"); //Mensaje que muestra el resultado de la suma.
    }
    else if (operacion == "resta")
    {
        Console.Clear();
        resultado = operacion1.restar(num1, num2);
        operando = "-";
        Console.WriteLine($"El resultado de la resta es {resultado}");
    }
    else if (operacion == "multiplicacion")
    {
        Console.Clear();
        resultado = operacion1.multiplicar(num1, num2);
        operando = "*";
        Console.WriteLine($"El resultado de la multiplicación es {resultado}");
    }
    else if (operacion == "division")
    {
        operando = "/";
        Console.Clear();
        if (num2 == 0)
        {
            resultado= 0;
            Console.WriteLine("No se puede dividir por 0");
        }
        else
        {
            resultado = operacion1.dividir(num1, num2);
            
            Console.WriteLine($"El resultado de la división es {resultado}");

        }
    }

    listaHistorial.Add(new Historiales(num1, num2, operando, operacion ,resultado)); //Se crea una nueva instancia de historiales y se agrega a la lista de la clase Historiales y ya se hace referencia a cada uno de sus atributos.


    Console.WriteLine("Presione ENTER para ver otra vez el menu");
    Console.ReadKey();
   
}

static void verHistorial(List<Historiales> listaHistorial) //Funcion para ver el historial que toma como argumento la lista de tipo Historiales.
{
    Console.WriteLine("Historial de operaciones:");
    foreach (var historial in listaHistorial) //Se recorre cada historial.
    {
        Console.WriteLine($"{historial.Numero1} {historial.Operando} {historial.Numero2} = {historial.Resultado}"); //Se muestra el mensaje de todas las operaciones con su resultado.
    }
    Console.WriteLine("Presione ENTER para volver al menú");
    Console.ReadKey();
}

static void operacionMasRealizada(List<Historiales> listaHistorial) //Funcion para ver que operacion se realizo mas veces y muestra cuantas veces respectivamente se hicieron.
{
    //Contadores en 0 de cada operacion para luego sumar 1 en 1.
    int contSuma = 0;
    int contResta = 0;
    int contMultiplicacion = 0;
    int contDivision = 0;

    foreach (var  historial in listaHistorial)
    {
        if(historial.Operacion == "suma")
        {
            contSuma = contSuma + 1;
        }
        if(historial.Operacion == "resta")
        {
            contResta = contResta + 1;
        }
        if(historial.Operacion == "multiplicacion")
        {
            contMultiplicacion = contMultiplicacion + 1;
        }
        if(historial.Operacion == "division")
        {
            contDivision = contDivision + 1;
        }
    }

    //Condicionales en caso de que las operaciones sean mayores a otras o iguales.
    if (contSuma > contResta && contSuma > contMultiplicacion && contSuma > contDivision)
    {
        Console.WriteLine($"La operación mas veces realizada es SUMA. Se realizó {contSuma} veces.");
    }
    else if (contResta > contSuma && contResta > contMultiplicacion && contResta > contDivision)
    {
        Console.WriteLine($"La operación mas veces realizada es RESTA. Se realizó {contResta} veces.");
    }
    else if (contMultiplicacion > contSuma && contMultiplicacion > contResta && contMultiplicacion > contDivision)
    {
        Console.WriteLine($"La operación mas veces realizada es MULTIPLICACIÓN. Se realizó {contMultiplicacion} veces.");
    }
    else if (contDivision > contSuma && contDivision > contResta && contDivision > contMultiplicacion)
    {
        Console.WriteLine($"La operación mas veces realizada es DIVISIÓN. Se realizó {contDivision} veces.");
    }
    else if (contSuma == contResta || contSuma == contMultiplicacion || contSuma == contDivision)
    {
        Console.WriteLine("Se han realizado la misma cantidad de operaciones.");
    }
    else if (contResta == contSuma || contResta == contMultiplicacion || contResta == contDivision)
    {
        Console.WriteLine("Se han realizado la misma cantidad de operaciones.");
    }
    else if (contMultiplicacion == contResta || contMultiplicacion == contSuma || contMultiplicacion == contDivision)
    {
        Console.WriteLine("Se han realizado la misma cantidad de operaciones.");
    }
    else if (contDivision == contResta || contDivision == contMultiplicacion || contDivision == contSuma)
    {
        Console.WriteLine("Se han realizado la misma cantidad de operaciones.");
    }
    else
    {
        Console.WriteLine("No se han realizado operaciones aún");
    }
}