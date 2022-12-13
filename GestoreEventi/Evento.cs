/*
 * Milestone 1:
 *      [] Classe evento con:
 *          [x] Titolo - r/w
 *          [x] Data - r/w
 *          [x] Capienza massima - r/
 *          [x] Posti prenotati - r/
 *          [] Costruttore che prende titolo, data, e capienza massima
 *          [] PrenotaPosti()
 *          [] DisdiciPosti()
 *          [] override ToString
 */


namespace GestoreEventi {
    public class Evento {

        // ATTRIBUTI
        private string titolo;
        private DateOnly data;
        private uint capienzaMassima;
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
        public uint CapienzaMassima { get => capienzaMassima; init => capienzaMassima = value; }
        public uint PostiPrenotati { get => postiPrenotati; protected set => postiPrenotati = value; }

        // COSTRUTTORI


        // METODI PUBBLICI


        // METODI PRIVATI

    }
}
