/*
 * Milestone 1:
 *      [] Classe evento con:
 *          [x] Titolo - r/w
 *          [x] Data - r/w
 *          [x] Capienza massima - r/
 *          [x] Posti prenotati - r/
 *          [x] Costruttore che prende titolo, data, e capienza massima
 *          [] PrenotaPosti()
 *          [] DisdiciPosti()
 *          [] override ToString
 */


namespace GestoreEventi {
    public class Evento {

        // ATTRIBUTI
        private string titolo;
        private DateOnly data;
        private readonly uint capienzaMassima;
        private uint postiPrenotati;

        // PROPRIETÀ
        public string Titolo {
            get => titolo;
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentNullException(nameof(value), $"Titolo {nameof(value)} non può essere nullo o vuoto.");
                }
                titolo = value;
            }
        }
        public DateOnly Data {
            get => data;
            set {
                if (value.CompareTo(DateTime.Now) < 0) {
                    throw new ArgumentOutOfRangeException(nameof(value), $"Data {nameof(value)} non può essere nel passato.");
                }
                data = value;
            }
        }
        public uint CapienzaMassima {
            get => capienzaMassima;
            init {
                if (value < 1) {
                    throw new ArgumentOutOfRangeException(nameof(value), $"Capienza Massima {nameof(value)} non può essere zero o meno.");
                }
                capienzaMassima = value;
            }
        }
        public uint PostiPrenotati {
            get => postiPrenotati;
            protected set {
                if (value > CapienzaMassima) {
                    throw new ArgumentOutOfRangeException(nameof(value), $"Posti prenotati {nameof(value)} non può superare la capienza massima.");
                }
                postiPrenotati = value;
            }
        }

        // COSTRUTTORI
        public Evento(string titolo, DateTime data, uint capienzaMassima) {
            Titolo = titolo;
            Data = DateOnly.FromDateTime(data);
            CapienzaMassima = capienzaMassima;
            PostiPrenotati = 0;
        }


        // METODI PUBBLICI


        // METODI PRIVATI

    }
}
