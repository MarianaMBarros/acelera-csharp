using System;

namespace Codenation.Challenge {
    public class CesarCypher : ICrypt, IDecrypt {
        public string Crypt (string message) {
            if (message == null) {
                throw new ArgumentNullException ();
            }

            if (message == "") {
                return "";
            }

            var newPhrase = "";
            message = message.ToLower ();
            foreach (var item in message) {
                var letterCode = (int) item;
                if (letterCode >= 97 && letterCode <= 122) {
                    var newLetterCode = ((letterCode - 97 + 3) % 26) + 97;
                    var letterAlphabet = (char) newLetterCode;
                    newPhrase += letterAlphabet;
                } else if (letterCode >= 48 && letterCode <= 57) {
                    newPhrase += item;
                } else if (letterCode == 32) {
                    newPhrase += item;
                } else {
                    throw new ArgumentOutOfRangeException ();
                }
            }
            return newPhrase;
        }

        public string Decrypt (string cryptedMessage) {
            if (cryptedMessage == null) {
                throw new ArgumentNullException ();
            }

            if (cryptedMessage == "") {
                return "";
            }

            var newPhrase = "";
            cryptedMessage = cryptedMessage.ToLower ();
            foreach (var item in cryptedMessage) {
                var letterCode = (int) item;
                if (letterCode >= 97 && letterCode <= 122) {
                    var newLetterCode = ((letterCode - 122 - 3) % 26) + 122;
                    var letterAlphabet = (char) newLetterCode;
                    newPhrase += letterAlphabet;
                } else if (letterCode >= 48 && letterCode <= 57) {
                    newPhrase += item;
                } else if (letterCode == 32) {
                    newPhrase += item;
                } else {
                    throw new ArgumentOutOfRangeException ();
                }
            }
            return newPhrase;

        }

    }

}