using System;
using System.Collections.Generic;

namespace Codenation.Challenge {
    public class Math {
        public List<int> Fibonacci () {
            List<int> lista = new List<int> ();

            int numOne = 0;
            int numTwoo = 1;
            int result = 0;

            lista.Add (0);
            lista.Add (1);
            while (result < 350) {
                result = numOne + numTwoo;
                if (result > 350) {
                    break;
                }
                lista.Add (result);
                numOne = numTwoo;
                numTwoo = result;
            }

            return lista;
        }

        public bool IsFibonacci (int numberToTest) {
            var lista = Fibonacci ();
            var result = lista.Contains (numberToTest);
            return result;
        }
    }
}