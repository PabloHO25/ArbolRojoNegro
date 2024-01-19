using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABB
{
    class Arbol
    {
        private Nodo raiz;
        private Nodo NRotar;
        internal Nodo Raiz { get => raiz; set => raiz = value; }
        public Arbol()
        {
            Raiz = null;
            NRotar = null;
        }
        public bool Vacio()
        {
            return Raiz == null;
        }
        private Nodo CreaNodo(int dato, char n)
        {
            Nodo Nuevo = new Nodo(dato);
            Nuevo.Color= n;
            return Nuevo;
        }
        public void Insertar(int dato)
        {
            Nodo x;
            if (Vacio())
                Raiz = CreaNodo(dato,'n');
            else
                AgregaNodo(dato, Raiz);
            x = BuscaRegresaDireccion(Raiz, dato);
            VerificaCaso(x);
           Raiz.Color = 'n';


        }
        public void AgregaNodo(int dato, Nodo Dir)
        {

            if (dato < Dir.Dato)
                if (Dir.HijoIzquierdo == null)
                    Dir.HijoIzquierdo = CreaNodo(dato,'r');
                else
                    AgregaNodo(dato, Dir.HijoIzquierdo);
            else
                 if (Dir.HijoDerecho == null)
                          Dir.HijoDerecho = CreaNodo(dato,'r');
            else
                AgregaNodo(dato, Dir.HijoDerecho);

        }


        //imprimir un arbol a traves del recorrido
        public void ListadoPreOrden()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("         Listado en PreOrden ");
            Console.WriteLine("----------------------------------------------");
            PreOrden(Raiz);
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------");
        }
        public void ListadoInOrden()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("         Listado en PreOrden ");
            Console.WriteLine("----------------------------------------------");
            InOrden(Raiz);
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------");
        }
        public void ListadoPosOrden()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("         Listado en PreOrden ");
            Console.WriteLine("----------------------------------------------");
            PosOrden(Raiz);
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------");
        }
        public void PreOrden(Nodo direccion)
        {
            if (direccion == null)
            {
                return;
            }

            Console.Write(direccion.Dato + " ,");
            PreOrden(direccion.HijoIzquierdo);
            PreOrden(direccion.HijoDerecho);


        }
        public void InOrden(Nodo direccion)
        {
            if (direccion == null)
            {
                return;
            }

            InOrden(direccion.HijoIzquierdo);
            Console.Write(direccion.Dato + " ,");
            InOrden(direccion.HijoDerecho);


        }
        public void PosOrden(Nodo direccion)
        {
            if (direccion == null)
            {
                return;
            }

            PosOrden(direccion.HijoIzquierdo);
            PosOrden(direccion.HijoDerecho);
            Console.Write(direccion.Dato + " ,");
        }

        public int CuentaNodos(Nodo Dir)
        {
            if (Dir == null)
                return 0;
            return CuentaNodos(Dir.HijoIzquierdo) + CuentaNodos(Dir.HijoDerecho) + 1;

        }


        public int CuentaHojas(Nodo Dir)
        {
            if (Dir == null)
                return 0;
            if (Dir.HijoDerecho == null && Dir.HijoIzquierdo == null)
                return 1;
            return CuentaHojas(Dir.HijoIzquierdo) + CuentaHojas(Dir.HijoDerecho);
        }

        public bool Busca(Nodo Dir, int v)
        {
            if (Dir == null)
                return false;
            if (v == Dir.Dato)
                return true;
            else
                    if (v < Dir.Dato)
                return Busca(Dir.HijoIzquierdo, v);
            else
                return Busca(Dir.HijoDerecho, v);

        }

        public bool invocaEliminar(int valor)
        {
            return invocaEliminar(valor);
        }

        public Nodo Eliminar(Nodo Dir, int valor)
        {
            Nodo aux;
            if (Dir == null)
                return null;
            if (valor < Dir.Dato)
            {
                Dir.HijoIzquierdo = Eliminar(Dir.HijoIzquierdo, valor);
            }
            else
                if (valor > Dir.Dato)
            {
                Dir.HijoDerecho = Eliminar(Dir.HijoDerecho, valor);
            }
            else ///se encontro el nodo a eliminar
            {
                if (Dir.HijoIzquierdo == null)
                    if (Dir.HijoDerecho == null)
                        return null;
                    else
                        return Dir.HijoDerecho;
                else // hijo izq existe
                    if (Dir.HijoDerecho == null)
                    return Dir.HijoIzquierdo;
                else // existen los 2 hijos
                {


                    aux = BuscaPequeño(Dir.HijoDerecho);
                    Dir.Dato = aux.Dato;
                  
                    
                    Dir.HijoDerecho = Eliminar(Dir.HijoDerecho, Dir.Dato);


                }





            }


            return Dir;
        }








        public void ImprimeArbol(Nodo Dir, int n)
        {
            
            if (Dir == null)
                return;//Console.WriteLine("Impresion del arbol");
            ImprimeArbol(Dir.HijoDerecho, n + 1);
            for (int i = 0; i < n; i++)
                Console.Write("    ");
            Console.WriteLine(Dir.Dato +""+Dir.Color);
            ImprimeArbol(Dir.HijoIzquierdo, n + 1);

        }

        public Nodo BuscaPequeño(Nodo Dir)
        {
            if (Dir == null)
                return null;
            if (Dir.HijoIzquierdo == null)
            {
                return Dir;
            }
            return BuscaPequeño(Dir.HijoIzquierdo);
        }



        public Nodo MayorIzquierdo(Nodo Dir) ///OBTIENE EL MAYOR DEL SUBARBOL IZQUIERDO
        {
            if(Dir== null)
                return null ;
            if (Dir.HijoDerecho == null)
                return Dir;
            return MayorIzquierdo(Dir.HijoDerecho);
        }






        


        public Nodo BuscaRegresaDireccion(Nodo Dir, int v)
        {
            if (Dir == null)
                return null;
            if (v == Dir.Dato)
                return Dir;
            else
                    if (v < Dir.Dato)
                return BuscaRegresaDireccion(Dir.HijoIzquierdo, v);
            else
                return BuscaRegresaDireccion(Dir.HijoDerecho, v);

        }
        public int Altura(Nodo Dir)
        {
            int izq, der;
            if (Dir == null)
                return 0;
            if (Dir.HijoIzquierdo == null && Dir.HijoDerecho == null)
                return 0;
            izq = Altura(Dir.HijoIzquierdo);
            der = Altura(Dir.HijoDerecho);
            if (izq > der)
                return izq + 1;
            else
                return der + 1;
        }


        public bool EstrictamenteBinario(Nodo Dir)
        {

            if (Dir == null)
                return false;
            if (Dir.HijoIzquierdo == null && Dir.HijoDerecho == null)
                return true;

            if (Dir.HijoIzquierdo != null && Dir.HijoDerecho != null)
            {
                return EstrictamenteBinario(Dir.HijoIzquierdo) && EstrictamenteBinario(Dir.HijoDerecho);
            }
            return false;

        }

        public Nodo ObtenerPadre(Nodo Dir, int v)
        {

            if(Dir==null)
                return null;
            if (v < Dir.Dato)
            {
                if (Dir.HijoIzquierdo == null)
                    return null;
                else
                      if (Dir.HijoIzquierdo.Dato == v)
                          return Dir;
                      else
                         return ObtenerPadre(Dir.HijoIzquierdo, v);
            }
            else
                if (Dir.HijoDerecho == null)
                return null;
            else
                if (Dir.HijoDerecho.Dato == v)
                         return Dir;
                 else
                    return ObtenerPadre(Dir.HijoDerecho, v);
        
        }

        public int ABinarioCompleto(Nodo Dir)
        {
            int izq, der;
            if (Dir == null)
                return 0;
            if (Dir.HijoIzquierdo == null && Dir.HijoDerecho == null)
            {
                return 0;
            }
            if (Dir.HijoIzquierdo != null && Dir.HijoDerecho != null)
            {
                izq = ABinarioCompleto(Dir.HijoIzquierdo);
                der = ABinarioCompleto(Dir.HijoDerecho);
                if (izq == der)
                    if (izq != -1)
                        return ++izq;
                return -1;
            }
            return -1;
        }
        public string InvocaBinarioCompleto()
        {
            int Resultado = ABinarioCompleto(Raiz);
            if (Vacio())
                return " Un arbol Vacio no es Binario Completo";
            if (Resultado == -1)
                return "NO Es un arbol Binario Completo";
            return " Es un Arbol Binario Completo: " + Resultado.ToString();
        }

        public string InvocaBinarioCompleto(Nodo Dir)
        {
            int Resultado = ABinarioCompleto(Dir);
            if (Vacio())
                return " Un arbol Vacio no es Binario Completo";
            if (Resultado == -1)
                return "NO Es un arbol Binario Completo";
            return " Es un Arbol Binario Completo: " + Resultado.ToString();
        }



        public bool BinarioCompleto(Nodo Dir)
        {

            int izq, der;
            if (Dir == null)
                return false;
            if (Dir.HijoIzquierdo == null && Dir.HijoDerecho == null)
            {
                return true;
            }
            if (Dir.HijoIzquierdo != null && Dir.HijoDerecho != null)
            {
                izq = Altura(Dir.HijoIzquierdo);
                der = Altura(Dir.HijoDerecho);

                if (izq == der)
                {
                    return BinarioCompleto(Dir.HijoDerecho) && BinarioCompleto(Dir.HijoIzquierdo);
                }
                else
                    return false;
            }
            else

                return false;


        }
        public bool EncuentraNodo(Nodo Dir, int Valor, bool encontrado)
        {

            if (encontrado)
            {
                return true;

            }
            if (Dir == null)
                return false;

            if (Dir.Dato == Valor)
            {
                return true;

            }
       
            Console.WriteLine(Dir.Dato);

            if (encontrado = EncuentraNodo(Dir.HijoIzquierdo, Valor, encontrado))
                return true;

            if (encontrado = EncuentraNodo(Dir.HijoDerecho, Valor, encontrado))
                return true;
            else return false;

        }




        /*************************************************************** AVL******************************************/
        public int AsignaAltura(Nodo Dir)
        {
            int AIzq, ADer;
            if (Dir == null)
                return -1;


            if (Dir.HijoIzquierdo == null)
                if (Dir.HijoDerecho == null)
                    Dir.NAltura = 0;
                else
                    Dir.NAltura = AsignaAltura(Dir.HijoDerecho) + 1;

            else
                    if (Dir.HijoDerecho != null)
            {
                AIzq = AsignaAltura(Dir.HijoIzquierdo);
                ADer = AsignaAltura(Dir.HijoDerecho);
                if (ADer > AIzq)
                    Dir.NAltura = ADer + 1;
                else
                    Dir.NAltura = AIzq + 1;
            }
            else
                Dir.NAltura = AsignaAltura(Dir.HijoIzquierdo) + 1;



            return Dir.NAltura;



        }
        public Nodo buscaTio(Nodo Dir, int dato)
        {
            int date;
           Nodo Tio = ObtenerPadre(Dir, dato);//padre
            date = Tio.Dato;
            Tio = ObtenerPadre(Dir, Tio.Dato);
            if (date < Tio.Dato)
                return Tio.HijoDerecho;
            return Tio.HijoIzquierdo;
            
        }

      
        public void RotaDer(Nodo Dir)
        {
            Nodo hijo = Dir.HijoIzquierdo;

            Nodo Padre;
          //  hijo = Dir.HijoIzquierdo;
            if (hijo.HijoDerecho != null)
                Dir.HijoIzquierdo = hijo.HijoDerecho;
            else
                Dir.HijoIzquierdo = null;
            hijo.HijoDerecho = Dir;
            if (Dir == raiz)
                raiz = hijo;
            else
            {
                Padre = ObtenerPadre(Raiz, Dir.Dato);
                if (Dir.Dato < Padre.Dato)
                    Padre.HijoIzquierdo = hijo;
                else
                    Padre.HijoIzquierdo = hijo;
                    
            }
            




         
        }
        public void RotaDerecha(Nodo Dir)//ref Nodo Padre
        {
            Nodo hijo = Dir.HijoIzquierdo;

           // Nodo Padre = new Nodo();
            //  hijo = Dir.HijoIzquierdo;
            if (hijo.HijoDerecho != null)
                Dir.HijoIzquierdo = hijo.HijoDerecho;
            else
                Dir.HijoIzquierdo = null;
            hijo.HijoDerecho = Dir;
            

            if (Dir == Raiz)
                Raiz = hijo;
           else
            {
                Nodo Padre;
                Padre=ObtenerPadre(Raiz,Dir.Dato);
                if (Dir.Dato < Padre.Dato)
                    Padre.HijoIzquierdo = hijo;
                else
                    Padre.HijoDerecho = hijo;
            }
       

        }

        public void Rotaizq(Nodo Dir)
        {
            Nodo hijo = (Dir.HijoDerecho);

            // Nodo Padre = new Nodo();
            //  hijo = Dir.HijoIzquierdo;
            if (hijo.HijoIzquierdo != null)
                    Dir.HijoDerecho = hijo.HijoIzquierdo;
            else
                Dir.HijoDerecho = null;
            hijo.HijoIzquierdo= Dir;


            if (Dir == Raiz)
                Raiz = hijo;
            else
            {
                Nodo Padre;
                Padre = ObtenerPadre(Raiz, Dir.Dato);
                if (Dir.Dato < Padre.Dato)
                    Padre.HijoIzquierdo = hijo;
                else
                    Padre.HijoDerecho = hijo;
            }

        }

        public void Rotaciones()
        {
            


            switch (identificaTipo())
            {

                case 1:
                    Console.WriteLine(" Arbol izq - izq");
                    Console.WriteLine(" Rotacion Derecha con el nodo padre = {0} ", NRotar.Dato);
                  RotaDerecha(NRotar);
                    Console.WriteLine(" Se realizo la rotacion");
                    break;
                case 2:
                    Console.WriteLine(" Arbol izq-der");
                    Console.WriteLine(" Rotacion Izquierda con el nodo hijo ={0}", NRotar.HijoIzquierdo.Dato);
                    Rotaizq(NRotar.HijoIzquierdo);
                    RotaDerecha(NRotar); 
                    Console.WriteLine(" Rotacion Derecha con el nodo padre={0}", NRotar.Dato);

                    Console.WriteLine(" Se realizo la rotacion");
                    break;
                case 3:
                    Console.WriteLine(" Arbol Der - der");
                    Console.WriteLine(" Rotacion Izquierda con el nodo padre = {0}",NRotar.Dato);
                    Rotaizq(NRotar);

                    break;
                case 4:
                    Console.WriteLine("/////////");
                    Console.WriteLine(" Arbol Der - Izq");
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine("Rotacion Derecha con el nodo hijo ={0}",NRotar.HijoDerecho.Dato);
                    RotaDerecha(NRotar.HijoDerecho);
                    Rotaizq(NRotar);
                    break;           
            }
            AsignaAltura(Raiz);
            AsignaFe(Raiz);
            NRotar = null;
        }

        public int identificaTipo()
        {
         
            if (NRotar.FE > 1)
            {
                if (NRotar.HijoDerecho.FE > 0)
                {

                    return 3;
                }
                
                else

                    return 4;
            }
            else //hijoizquierdo
            {
                if (NRotar.HijoIzquierdo.FE < 0)
                {
                    return 1;
                }
                   
                else
                    return 2;
            }

        }



        public void ListadoAltura()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("         Listado del dato y altura");
            Console.WriteLine("----------------------------------------------");
            RecorridoAltura(Raiz);
          
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------");

        }
        public void ListadoFE()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("         Listado del factor de equilibrio de los Nodos");
            Console.WriteLine("----------------------------------------------");
            RecorridoFE(Raiz);

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------");


        }
        public void IdentificaNodoRotar(Nodo Dir)
        {
            if (Dir == null)
                return;

            IdentificaNodoRotar(Dir.HijoIzquierdo);
            IdentificaNodoRotar(Dir.HijoDerecho);


            if ((Dir.FE < -1 || Dir.FE > 1 )&& NRotar == null)
                NRotar = Dir;
            return;
                   


        }
        public void RecorridoAltura(Nodo dir)
        {
           
            if (dir == null)
                return;
            RecorridoAltura(dir.HijoIzquierdo);
            Console.Write(" ({0}, {1} ), ", dir.Dato, dir.NAltura);
            RecorridoAltura(dir.HijoDerecho);
        }
        public void RecorridoFE(Nodo dir)
        {

            if (dir == null)
                return;
            RecorridoFE(dir.HijoIzquierdo);
            Console.Write(" ({0}, {1} ), ", dir.Dato, dir.FE);
            RecorridoFE(dir.HijoDerecho);
        }
        public void AsignaFe(Nodo Dir)
        {
            int izq=0, der=0;
            if (Dir == null)
                    return;



            if (Dir.HijoIzquierdo != null)
            {
                izq = Dir.HijoIzquierdo.NAltura+1;
                AsignaFe(Dir.HijoIzquierdo);
            }
            else
                izq = 0;

            if (Dir.HijoDerecho != null)
            {
                der = Dir.HijoDerecho.NAltura+1;
                AsignaFe(Dir.HijoDerecho);
            
            }
            else
                der = 0;
            Dir.FE = der - izq;
        }
        public void  Menu()
        {
            int opcion, a;
            Nodo DirAux;
            do
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("        Menu de opciones ");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine(" 1.-Insertar Numero");
                Console.WriteLine(" 2.-Recorridos del Arbol");
                Console.WriteLine(" 3.- Informacion del arbol");
                Console.WriteLine(" 4.- Encuentra valor");
                Console.WriteLine(" 5.- Altura");
                Console.WriteLine(" 6.- Binario Completo");
                Console.WriteLine(" 7.- Padre");
                Console.WriteLine( " 8.- Eliminar");
                Console.WriteLine(" 9.- SAlir");
                Console.WriteLine("---------------------------------------------");
                Console.Write("             Selecione una opcion: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine(" 1.-Insertar");
                        Console.Write(" Digite el numero a ingresar: ");
                        a = int.Parse(Console.ReadLine());
                        Insertar(a);





                        break;
                    case 2:
                        Console.WriteLine(" 2.-Recorridos del Arbol");
                        Console.WriteLine();
                        Console.WriteLine("-----------------------------------------------");
                        ImprimeArbol(Raiz,0);


                        break;
                    case 3:
                        Console.WriteLine(" 3.- Informacion del arbol");
                        Console.WriteLine(" Cantidad de nodos: "+CuentaNodos(Raiz));
                        Console.WriteLine(" Cantidad de hojas: "+ CuentaHojas(Raiz));
                        if(EstrictamenteBinario(Raiz))
                            Console.WriteLine(" El arbol es estrictamente Binario");
                        else
                            Console.WriteLine(" El arbol NO es estrictamente Binario");

                        
                        Console.WriteLine(InvocaBinarioCompleto());
                        break;
                    case 4:
                        Console.WriteLine(" 4.- Encuentra valor: ");
                        if (Vacio())
                            Console.WriteLine(" El arbol se encuentra vacio");
                        else
                        {

                            Console.Write(" Digite el valor a buscar: ");
                            a = int.Parse(Console.ReadLine());
                            DirAux = BuscaRegresaDireccion(Raiz,a);
                            if (DirAux != null)
                            {
                                Console.WriteLine(" El nodo se encuentra en el arbol");
                                if (DirAux == Raiz)
                                    Console.WriteLine(" Es la raiz del arbol");
                                else 
                                    if (DirAux.HijoIzquierdo != null)
                                {
                                    if (DirAux.HijoDerecho != null)
                                    {
                                        Console.WriteLine(" Es un padre con 2 hijos");
                                    }
                                    else
                                        Console.WriteLine(" Es un Padre con hijo derecho");
                                }
                                else
                                        if (DirAux.HijoDerecho == null)
                                    Console.WriteLine(" Es una  hoja");
                                else
                                    Console.WriteLine(" Es un Padre con Hijo Izquierdo");

                                Console.WriteLine(" Se ha Encontrado el valor en el arbol con  las siguientes caracteristicas: ");
                                Console.WriteLine(" Cantidad de nodos: " + CuentaNodos(DirAux));
                                Console.WriteLine(" Cantidad de hojas: " + CuentaHojas(DirAux));
                                if (EstrictamenteBinario(DirAux))
                                {
                                    
                                        Console.WriteLine(" El arbol es estrictamente Binario");
                                }
                                else
                                    Console.WriteLine(" El arbol NO es estrictamente Binario");







                                  
                                Console.WriteLine(InvocaBinarioCompleto(DirAux));

                            }



                              

                    
                            else
                                Console.WriteLine("No se ha Encontrado el valor en el arbol");
                        }
                          
                        break;
                    case 5:
                        Console.WriteLine(" 5.- Altura");
                        Console.WriteLine("La altura es: "+Altura(Raiz));
                        break;

                    case 6:
                        Console.WriteLine(" 6.- Binario Completo");

                        if(BinarioCompleto(Raiz))
                            Console.WriteLine("El arbol es binario completo");
                        else
                            Console.WriteLine("El arbol NO es binario completo");

                        break;
                    case 7:
                        Console.WriteLine(" Padre DEL NODO");
                        Console.Write(" Digite el valor a buscar:");
                        a = int.Parse(Console.ReadLine());
                        DirAux = ObtenerPadre(Raiz, a);
                        
     
                          
                        if (Vacio())
                            Console.WriteLine(" aRBOL VACIO ");
                        else if(DirAux==null)
                            Console.WriteLine(" el nodo dado no existe");
                        else
                        {
                            if (a == Raiz.Dato)
                                Console.WriteLine(" Es la raiz del arbol por lo tanto no tiene padre");
                            else

                                Console.WriteLine(" EL PADRE ES: "+ DirAux.Dato);

                        }
                        break;
                    case 8:
                        Console.WriteLine(" 8.- Eliminar");
                        if (Vacio())
                            Console.WriteLine("Arbol vacio");
                        else
                        {
                            Console.Write(" Digite el valor a eliminar: ");
                            a = int.Parse(Console.ReadLine());
                             Borrado(raiz, a);

                            ImprimeArbol(raiz, 0);
                            //Console.WriteLine(" se elimino el nodo");
                           



                        }
                        break;
                    case 9:
                        Console.WriteLine(" 9.- SAlir");
                        break;
                    default:
                        Console.WriteLine(" Opcion invalida");
                        break;
                }
            } while (opcion != 9);
            
        }





        /***************************************************************** arboles Rojo-negro******************************************************************/
public Nodo BuscaAbuelo(Nodo Dir , int v)
        {
            if( Dir== null)
                return null;
            Nodo Padre = ObtenerPadre(Dir,v);
            Nodo Abuelo = ObtenerPadre(Dir, Padre.Dato);
            return Abuelo;
        }
        public Nodo BuscaHermano(Nodo Dir, int v)
        {
            if(Dir==null)
                return null;
            Nodo Padre=ObtenerPadre (Raiz,v);
            if (Padre.HijoDerecho != null)
            { if (v == Padre.HijoDerecho.Dato)
                {

                    return Padre.HijoIzquierdo;
                }
                else return Padre.HijoDerecho;
            }
            return null;

        }
        public void VerificaCaso(Nodo x)
        {
            Nodo Padre;
            Nodo Tio;
            Nodo Abuelo;
            if (x.Dato == Raiz.Dato)
            {
               Raiz.Color = 'n';
              //  Console.WriteLine("LLego a la raiz");
            }
            else
            {
                Padre = ObtenerPadre(raiz, x.Dato);

                if (Padre.Color == 'r')
                {
                    Abuelo = BuscaAbuelo(raiz, x.Dato);
                    Tio = BuscaHermano(raiz, Padre.Dato);

                    if (Tio == null)
                    {
                        Tio = new Nodo();
                        Tio.Color = 'n';
                    }
                    if (Abuelo.HijoIzquierdo == Padre)
                    {
                        if (Tio.Color == 'r') //caso1
                        {
                       //     Console.WriteLine("caso1");
                            Padre.Color = 'n';

                            Tio.Color = 'n';
                            Abuelo.Color = 'r';
                            VerificaCaso(Abuelo);
                        }
                        else
                        {
                            if (Padre.HijoDerecho == x) // caso2
                            {
                            //    Console.WriteLine("caso2");

                                Rotaizq(Padre);
                                VerificaCaso(Padre);

                            }
                            else // caso3
                            { 
                            
                       //        Console.WriteLine("caso3");
                           
                                RotaDerecha(Abuelo);
                                Padre.cambiaColr();
                                Abuelo.cambiaColr();
                           
                                
                            }

                        }
                    }
                    else // cuando el padre es hijo derecho del abuelo
                    {
                 

                        if (Tio == null)
                        {
                            Tio = new Nodo();
                            Tio.Color = 'n';
                        }



                        if (Tio.Color == 'r')
                        {
  //                          Console.WriteLine("caso4");
                            Padre.Color = 'n';
                            Tio.Color = 'n';
                            Abuelo.Color = 'r';

//                            Console.WriteLine(Abuelo.Dato + " " + Abuelo.Color);
                            VerificaCaso(Abuelo);
                        }
                        else
                        {
                            if (Padre.HijoIzquierdo == x) // caso2
                            {
                             //   Console.WriteLine("caso5");
                                RotaDerecha(Padre);
                                VerificaCaso(Padre);

                            }
                            else //caso 3
                            {
                          ///      Console.WriteLine("caso6");
                                Rotaizq(Abuelo);
                                Abuelo.cambiaColr();
                                Padre.cambiaColr();
                            }
                        }



                    }
                }
            Raiz.Color = 'n';
                        //}
                }
            
            

        }
        public void Restructura(Nodo Padre, Nodo Dir) //// Le Paso el padre del nodo a eliminar y el nodo a eliminar
        {//VERIFICA LOS CASOS TRIVIALES

            //Nodo Padre;
            Nodo Hermano;
            Nodo hijo;
            Nodo Aux;

            if (Padre.HijoIzquierdo == Dir)//ES HIJOIZQUIERDO
            {
                //Conozco que soy el hijoIzquierdo POR LO TANTO MI HERMANO ES EL HIJODERECHO
                Hermano = Padre.HijoDerecho;
                if (Dir.Color == 'r')// no puede tener hijos rojos
                {// NO IMPORTA EL COLOR DEL HERMANO                    
                 //CONOCER EL HIJO SI EXISTE
                 // CASO TRIVIAL 1 IZQUIERDA
                    if (Dir.HijoIzquierdo == null)
                        if (Dir.HijoDerecho == null)
                            Padre.HijoIzquierdo = null; // EL NODO ELIMINADO ERA HOJA
                        else
                            Padre.HijoIzquierdo = Dir.HijoDerecho;
                    else
                        Padre.HijoIzquierdo = Dir.HijoIzquierdo;
                }
                else // EL NODO A BORRAR ES NEGRO  || puede tener hijos rojos
                {// caso trivial 2
                 //AQUI SOLO SE COMPARA SI TIENE UN HIJO YA QUE SOLO PUEDE TENER UNO
                 if(Dir.HijoIzquierdo==null)
                        if(Dir.HijoDerecho==null) // es una hoja
                        {
                            Padre.HijoIzquierdo = null;
                            Casos(Padre.HijoIzquierdo, Padre);
                        }else // el hijo derecho existe
                        {
                            if (Dir.HijoDerecho.Color == 'r')
                            {
                                Dir.HijoDerecho.cambiaColr();
                                Padre.HijoIzquierdo = Dir.HijoDerecho;
                            }
                            else // NODO BORRADO NEGRO E HIJO NEGRO
                            {
                                Padre.HijoIzquierdo = Dir.HijoDerecho;
                                Casos(Padre.HijoIzquierdo, Padre);
                            }   
                        }
                    else // EL HIJO IZQUIERDO EXISTE
                    {
                        if (Dir.HijoIzquierdo.Color == 'r')
                        {
                            Dir.HijoIzquierdo.cambiaColr();
                            Padre.HijoIzquierdo = Dir.HijoIzquierdo;
                        }
                        else // nodo borrado negro e hijo negro
                        {
                            Padre.HijoIzquierdo = Dir.HijoIzquierdo;
                            Casos(Padre.HijoIzquierdo, Padre);
                        }

                    }
                        


                       
                }
            }// es   HIJO DERECHO
            else
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////  
                //Conozco que soy el hijoDERECHO POR LO TANTO MI HERMANO ES EL HIJOIZQUIERDO
                Hermano = Padre.HijoIzquierdo;
                if(Dir.Color == 'r')
                {
                    if (Dir.HijoIzquierdo == null)
                        if (Dir.HijoDerecho == null)
                            Padre.HijoDerecho = null;
                        else
                            Padre.HijoDerecho = Dir.HijoDerecho;
                    else
                        Padre.HijoDerecho = Dir.HijoIzquierdo;
                }
                else // DIR ES NEGRO    
                {
                    if (Dir.HijoIzquierdo == null)
                        if (Dir.HijoDerecho == null) 
                        {
                            Padre.HijoDerecho = null;
                            Casos(Padre.HijoDerecho, Padre);
                        }
                        else
                        {
                            if (Dir.HijoDerecho.Color == 'r') //CASO TRIVIAL2
                            {
                                Dir.HijoDerecho.cambiaColr();
                                Padre.HijoDerecho = Dir.HijoDerecho;
                            }
                            else
                            {
                                Padre.HijoDerecho = Dir.HijoDerecho;
                                Casos(Padre.HijoDerecho, Padre);
                            }
                        }
                    else //EL QUE EXISTE ES HIJO IZQUIERDO
                    {
                        if (Dir.HijoIzquierdo.Color == 'r')
                        {
                            Dir.HijoIzquierdo.cambiaColr();
                            Padre.HijoDerecho = Dir.HijoIzquierdo;
                        }else // hijo negro
                        {
                            Padre.HijoDerecho = Dir.HijoIzquierdo;
                            Casos(Padre.HijoDerecho, Padre);
                        }
                    }
                }

                
                       
                    
            } 
        }


                ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            
   
       public void Casos (Nodo Dir, Nodo Padre) // CASOS DEL 1 AL 5 // necesito un parametro para saber si soy IZQUIERDO O DERECHO PORQUE DIR PUEDE SER NULL
        {// ya realize la eliminacion
            Nodo hermano;
            Nodo aux;
            Nodo ApuntaRaiz = Raiz;
            //CONSIDERAR QUE DIR PUEDE SER NULO
            if (Padre.HijoIzquierdo == Dir) //VERIFICO QUE HIJO SOY IZQUIERDO O DERECHO
            {
                hermano = Padre.HijoDerecho;
                if (Padre.Color == 'n') // VERIFICO QUE EL PADRE ES NEGRO
                {
                    if(hermano==null)
                        Console.WriteLine("caso imposible");
                        // caso imposible
                    else
                    {
                        if (hermano.Color == 'r')
                        {//CASO 1
                            Padre.cambiaColr();
                            hermano.cambiaColr();
                            Rotaizq(Padre);
                            if (Padre == raiz)
                                raiz = hermano;
                            Casos(Dir, Padre);
                        }
                        else // HERMANO NEGRO NO NULO
                        {
                            if (hermano.HijoIzquierdo == null)
                                if (hermano.HijoDerecho == null)
                                {//CASO2
                                    hermano.cambiaColr();
                                    if (Padre != raiz)
                                        Casos(Padre, ObtenerPadre(raiz, Padre.Dato));
                                }
                                else //el sobrino derecho existe
                                {
                                    if (hermano.HijoDerecho.Color == 'r')
                                    { //CASO 5
                                        hermano.Color = Padre.Color;
                                        Padre.Color = 'n';
                                        hermano.HijoDerecho.cambiaColr();
                                        Rotaizq(Padre);
                                        if (Padre == raiz)
                                            raiz = hermano;
                                      //TERMINA
                                    }
                                    else // sobrino derecho negro no nulo
                                    {//CASO2
                                        hermano.cambiaColr();
                                        if (Padre != raiz)
                                            Casos(Padre, ObtenerPadre(raiz, Padre.Dato));
                                    }
                                }
                            else // SOBRINO IZQUERDO EXISTE
                            {
                                if(hermano.HijoDerecho==null)
                                {
                                    if (hermano.HijoIzquierdo.Color == 'r')
                                    { // CASO 4
                                        hermano.cambiaColr();
                                        hermano.HijoIzquierdo.cambiaColr();
                                        RotaDerecha(hermano);
                                        Casos(Dir, Padre);
                                    }
                                    else // sobrino izquierdo negro
                                    { // caso 2
                                        hermano.cambiaColr();
                                        if (Padre != raiz)
                                            Casos(Padre, ObtenerPadre(raiz,Padre.Dato));
                                    }
                                }
                                else// EL SOBRINO DERECHO E IZQUIERDO EXISTEN
                                {
                                    if (hermano.HijoIzquierdo.Color == 'r')
                                        if (hermano.HijoDerecho.Color == 'r')
                                        {//caso 5
                                            hermano.Color = Padre.Color;
                                            Padre.Color = 'n';
                                            hermano.HijoDerecho.cambiaColr();
                                            Rotaizq(Padre);
                                            if (raiz == Padre)
                                                raiz = hermano;
                                        }
                                        else
                                        {//caso4
                                            hermano.cambiaColr();
                                            hermano.HijoIzquierdo.cambiaColr();
                                            RotaDerecha(hermano);
                                            Casos(Dir, Padre);
                                        }
                                    else // el sobrino izquierdo es negro
                                    {
                                        if(hermano.HijoDerecho.Color=='r')
                                        {//CASO 5
                                            hermano.Color = Padre.Color;
                                            hermano.HijoDerecho.cambiaColr();
                                            Padre.Color = 'n';
                                            Rotaizq(Padre);
                                            if (raiz == Padre)
                                                raiz = hermano;
                                        }else // SOBRINOS NEGROS
                                        {//CASO2
                                            hermano.cambiaColr();
                                            if (Padre != raiz)
                                                Casos(Padre, ObtenerPadre(raiz, Padre.Dato));
                                        }
                                    }
                                }

                            }
                        }
                    }                  
             }
                else // EL PADRE ES ROJO
                {// imposible que padre sea la raiz || el hermano es negro por defecto casos 3,4,5
                    if(hermano.HijoIzquierdo==null)
                        if(hermano.HijoDerecho==null)
                        {//caso3
                            hermano.cambiaColr();
                            Padre.cambiaColr();
                        }
                        else
                        {
                            if (hermano.HijoDerecho.Color == 'r')
                            {//caso5 
                                hermano.Color = Padre.Color;
                                Padre.Color = 'n';
                                hermano.HijoDerecho.cambiaColr();
                                Rotaizq(Padre);
                            }
                            else
                            {//caso 3
                                hermano.cambiaColr();
                                Padre.cambiaColr();
                            }
                        }
                    else
                    {
                        if (hermano.HijoDerecho == null)
                        {
                            if (hermano.HijoIzquierdo.Color == 'r')
                            {//caso4
                                hermano.HijoIzquierdo.cambiaColr();
                                hermano.cambiaColr();
                                RotaDerecha(hermano);
                                Casos(Dir, Padre);
                            }
                            else
                            {//caso3
                                hermano.cambiaColr();
                                Padre.cambiaColr();
                            }
                        }
                        else
                        {//ambos sobrinos existen
                            if(hermano.HijoIzquierdo.Color=='r')
                                if(hermano.HijoDerecho.Color=='r')
                                {//caso 5
                                    hermano.Color = Padre.Color;
                                    Padre.Color ='n';
                                    hermano.HijoDerecho.cambiaColr();
                                    Rotaizq(Padre);
                                }
                                else
                                {//caso4
                                    hermano.cambiaColr();
                                    hermano.HijoIzquierdo.cambiaColr();
                                    RotaDerecha(hermano);
                                    Casos(Dir, Padre);
                                } 
                            else
                            {
                                if (hermano.HijoDerecho.Color == 'r')
                                {//caso 5
                                    hermano.Color = Padre.Color;
                                    Padre.Color = 'n';
                                    hermano.HijoDerecho.cambiaColr();
                                    Rotaizq(Padre);
                                }else
                                {//caso 3
                                    hermano.cambiaColr();
                                    Padre.cambiaColr();
                                }
                            }

                        }
                    }   
                }
            }
            else // SOY HIJODERECHO CASO SIMETRICO
            {
                hermano = Padre.HijoIzquierdo;
                if (Padre.Color == 'n')
                {// casos 1,2,4,5
                    if (hermano == null)
                    {
                        Console.WriteLine("caso imposible");
                    }
                    else
                    {
                        if (hermano.Color == 'r')
                        {//caso 1
                            hermano.cambiaColr();
                            Padre.cambiaColr();
                            RotaDerecha(Padre);
                            if (Padre == raiz)
                                hermano = raiz;
                            Casos(Dir, Padre);
                        }
                        else// HERMANO NEGRO
                        {
                            if(hermano.HijoIzquierdo==null)
                                if (hermano.HijoDerecho == null)
                                {//caso2
                                    hermano.cambiaColr();
                                    if (Padre != raiz)
                                        Casos(Padre, ObtenerPadre(raiz, Padre.Dato));
                                }
                                else
                                {
                                    if (hermano.HijoDerecho.Color == 'r')
                                    {// *caso 4
                                        hermano.cambiaColr();
                                        hermano.HijoDerecho.cambiaColr();
                                        Rotaizq(hermano);
                                        Casos(Dir, Padre);

                                    }
                                    else
                                    {//CASO 2
                                        hermano.cambiaColr();
                                        if (Padre != raiz)
                                            Casos(Padre, ObtenerPadre(raiz, Padre.Dato));
                                    }
                                }
                            else //SOBRINO IZQUIERDO EXISTE
                            {
                                if (hermano.HijoDerecho == null)
                                {
                                    if (hermano.HijoIzquierdo.Color == 'r')
                                    {//*caso 5
                                        hermano.Color = Padre.Color;
                                        Padre.Color = 'n';
                                        hermano.HijoIzquierdo.cambiaColr();
                                        RotaDerecha(Padre);
                                        if (Padre == raiz)
                                            raiz = hermano;
                                        Casos(Dir, Padre);
                                    }
                                    else //caso 2
                                    {
                                        hermano.cambiaColr();
                                        if (Padre != raiz)
                                            Casos(Padre, ObtenerPadre(raiz, Padre.Dato));
                                    }
                                }
                                else //EXISTEN LOS 2 SOBRINOS
                                {
                                    if(hermano.HijoIzquierdo.Color=='r')
                                        if (hermano.HijoDerecho.Color == 'r')
                                        {//caso5
                                            hermano.Color = Padre.Color;
                                            Padre.Color = 'n';
                                            hermano.HijoIzquierdo.cambiaColr();
                                            RotaDerecha(Padre);
                                            if (Padre == raiz)
                                                raiz = hermano;
                                        }
                                        else
                                        {//caso 5
                                            hermano.Color = Padre.Color;
                                            Padre.Color = 'n';
                                            hermano.HijoIzquierdo.cambiaColr();
                                            RotaDerecha(Padre);
                                            if (Padre == raiz)
                                                raiz = hermano;
                                        }
                                    else
                                    {
                                        if (hermano.HijoDerecho.Color == 'r')
                                        { //caso4
                                            hermano.cambiaColr();
                                            hermano.HijoDerecho.cambiaColr();
                                            Rotaizq(hermano);
                                            Casos(Dir, Padre);

                                        }
                                        else
                                        {//CASO 2
                                            hermano.cambiaColr();
                                            if (Padre != raiz)
                                                Casos(Padre, ObtenerPadre(raiz, Padre.Dato));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }else //PADRE ES ROJO
                {//CASOS POSIBLES 3,4,5 EL HERMANO ES NEGRO, EL PADRE NO PUEDE SER LA RAIZ
                    if(hermano.HijoIzquierdo==null)
                        if (hermano.HijoDerecho == null)
                        {//caso 3
                            hermano.cambiaColr();
                            Padre.cambiaColr();
                        }
                        else
                        {
                            if (hermano.HijoDerecho.Color == 'r')
                            {//caso 4
                                hermano.cambiaColr();
                                hermano.HijoDerecho.cambiaColr();
                                Rotaizq(hermano);
                                Casos(Dir, Padre);

                            }
                            else
                            {//caso 3
                                hermano.cambiaColr();
                                Padre.cambiaColr();
                            }
                        }
                    else
                    {// el hermano izquierdo existe
                        if (hermano.HijoDerecho == null)
                        {
                            if (hermano.HijoIzquierdo.Color == 'r')
                            {//caso 5
                                hermano.Color = Padre.Color;
                                Padre.Color = 'n';
                                hermano.HijoIzquierdo.cambiaColr();
                                RotaDerecha(Padre);
                                if (Padre == raiz)
                                    raiz = hermano;
                            }
                            else
                            {//caso 3
                                hermano.cambiaColr();
                                Padre.cambiaColr();
                            }
                        }
                        else
                        {
                            if(hermano.HijoIzquierdo.Color=='r')
                                if (hermano.HijoDerecho.Color == 'r')
                                {//caso 5
                                    hermano.Color = Padre.Color;
                                    Padre.Color = 'n';
                                    hermano.HijoIzquierdo.cambiaColr();
                                    RotaDerecha(Padre);

                                }
                                else
                                {//caso 5
                                    hermano.Color = Padre.Color;
                                    Padre.Color = 'n';
                                    hermano.HijoIzquierdo.cambiaColr();
                                    RotaDerecha(Padre);
                                }
                            else
                            {
                                if(hermano.HijoDerecho.Color=='r')
                                {//caso *4
                                    hermano.cambiaColr();
                                    hermano.HijoDerecho.cambiaColr();
                                    Rotaizq(hermano);
                                    Casos(Dir, Padre);

                                }
                                else
                                {//caso 3
                                    hermano.cambiaColr();
                                    Padre.cambiaColr();
                                }
                            }
                        }
                    }
                }

            }
        }

        public void Borrado(Nodo Dir,int valor)
        {
            Nodo aux;
            Nodo padre;
            if (Dir == null)
                return;

            if (valor < Dir.Dato)
                    Borrado(Dir.HijoIzquierdo, valor);
            else
                if (valor > Dir.Dato)
                      Borrado(Dir.HijoDerecho, valor);
            else //ESTOY EN EL NODO A ELIMINAR
            {
                //VERIFICAR QUE TENGA 2 HIJOS
                if (Dir.HijoIzquierdo != null)
                {
                    if (Dir.HijoDerecho != null) // TIENE 2 HIJOS
                    {
                        int var;
                            aux = BuscaPequeño(Dir.HijoDerecho);
                            var = Dir.Dato;
                            padre = ObtenerPadre(raiz, aux.Dato);
                            Dir.Dato = aux.Dato; // intercambio de datos
                          aux.Dato = var;
                            Restructura( padre,aux); // va a borrar el nodo mayor de la izquierda // caera en los otros caso                
                    }
                    else
                    {
                        padre=ObtenerPadre(raiz, Dir.Dato);
                        Restructura(padre, Dir); // solo tiene hijo izquierdo
                        return;
                    }
                }
                else
                {
                    if (Dir.HijoDerecho != null)
                    {
                        padre = ObtenerPadre(raiz, Dir.Dato);

                        Restructura(padre, Dir); //tiene solo hijo derecho
                        return;
                    }
                    else
                    {
                        padre=ObtenerPadre(raiz, Dir.Dato);
                        Restructura(padre, Dir); // no tiene hijos
                        return;
                    }
                }
             }
        
            ImprimeArbol(raiz,0);
                }


    }
    class Par
    {
        private bool completo;
        private int altura;
        public Par (bool completo, int altura)
        {
            this.Completo = completo;
            this.Altura = altura;
        }

        public bool Completo { get => completo; set => completo = value; }
        public int Altura { get => altura; set => altura = value; }
    }
}
