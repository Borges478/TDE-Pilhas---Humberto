using System;
using System.Collections.Generic;
using EstruturaPilha.Interfaces;

namespace EstruturaPilha.Entidades
{
    public class PilhaEstatica : IPilha<string>
    {
        private string[] VetorElementos;
        private int TamanhoMaximo;
        private int IndiceProximoItem;

        public PilhaEstatica(int tamanhoMaximo)
        {
            if (tamanhoMaximo < 0)
                throw new ArgumentException("tamanhoMaximo", "Tamanho não pode ser menor " +
                    "ou igual a zero");
            TamanhoMaximo = tamanhoMaximo;
            VetorElementos = new string[TamanhoMaximo];
            IndiceProximoItem = 0;
        }

        public string Desempilha()
        {
            if (EstaVazia())
                throw new InvalidOperationException("Pilha Vazia, operação não pode ser " +
                    "realizada");
            
            return VetorElementos[--IndiceProximoItem];
        }

        public void Empilha(string obj)
        {
            if (IndiceProximoItem == TamanhoMaximo)
                throw new InvalidOperationException("Pilha Cheia, operação não pode ser" +
                    " realizada");
            VetorElementos[IndiceProximoItem] = obj;
            IndiceProximoItem++;
        }

        public IEnumerable<string> RetornaTodosElementos()
        {
            for (int i = IndiceProximoItem-1; i >= 0; i--)
            {
                yield return VetorElementos[i];
            }        
        }

        public int Tamanho()
        {
            return IndiceProximoItem;
        }

        public string Topo()
        {
            if (EstaVazia())
                throw new InvalidOperationException("Exceção: Pilha Vazia");
            return VetorElementos[IndiceProximoItem-1];
        }

        public bool EstaVazia()
        {
            return IndiceProximoItem == 0;
        }

        public bool EstaCheia()
        {
            return TamanhoMaximo == IndiceProximoItem;
        }

        public IEnumerable<string> Esvaziar()
        {
            int tamanho = Tamanho();
            if (EstaVazia())
                throw new NotImplementedException("Pilha vazia, operação " +
                    "não realizada");
            for (int i = 0; i < tamanho; i++)
            {
                yield return Desempilha();
            }
        }

        public IEnumerable<string> MultiPop(int k)
        {
            if(k > Tamanho() + 1)
                throw new InvalidOperationException("A pilha possui menos itens do que a quantidade" +
                    "solicitada. Operacao não realizada");

            var itensRemovidos = new string[k];
            for(int i = 0; i < k; i++)
            {
                itensRemovidos[i] = Desempilha();
            }

            return itensRemovidos;
        }
    }
}
