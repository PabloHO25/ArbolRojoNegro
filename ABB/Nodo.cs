using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABB
{
    //clase Nodo
    class Nodo
    {
        private int dato;
        private Nodo hijoIzquierdo;
        private Nodo hijoDerecho;
        private int fE;
        private char color;
        int nAltura;
        public Nodo(int d)
        {
            color = 'r';
            Dato = d;
            HijoDerecho = null;
            HijoIzquierdo = null;
            FE = 0;
            NAltura = -1;

        }
        public Nodo()
        {
            color = 'r';
            Dato = 0;
            HijoDerecho = null;
            HijoIzquierdo = null;
            FE = 0;
            NAltura = -1;

        }


        public Nodo (Nodo N)
        {
            dato = N.dato;
            hijoIzquierdo=N.hijoIzquierdo;
            FE = N.FE;
            nAltura = N.NAltura;
            hijoDerecho=N.hijoDerecho;
            color = 'r';
                
        }
        public int Dato { get => dato; set => dato = value; }
        public int FE { get => fE; set => fE = value; }
        public int NAltura { get => nAltura; set => nAltura = value; }
        internal Nodo HijoIzquierdo { get => hijoIzquierdo; set => hijoIzquierdo = value; }
        internal Nodo HijoDerecho { get => hijoDerecho; set => hijoDerecho = value; }
        public char Color { get => color; set => color = value; }
        public void cambiaColr()
        {
            if (color == 'r')
                 color = 'n';
            else
                    color='r';
        }
    }
}
