using System;

namespace Codenation.Challenge {
    public class Country {
        public State[] Top10StatesByArea () {
            State[] states = new State[10] {
                new State ("Amazonas", "AM"),
                new State ("Pará", "PA"),
                new State ("Mato Grosso", "MT"),
                new State ("Minas Gerais", "MG"),
                new State ("Bahia", "BA"),
                new State ("Mato Grosso do Sul", "MS"),
                new State ("Goiás", "GO"),
                new State ("Maranhão", "MA"),
                new State ("Rio Grande do Sul", "RS"),
                new State ("Tocantins", "TO"),
            };
            return states;
        }

    }

}