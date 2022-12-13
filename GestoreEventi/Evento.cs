/*
 * Milestone 1:
 *      [] Classe evento con:
 *          [x] Titolo - r/w
 *          [x] Data - r/w
 *          [x] Capienza massima - r/
 *          [x] Posti prenotati - r/
 *          [x] Costruttore che prende titolo, data, e capienza massima
 *          [x] PrenotaPosti()
 *          [x] DisdiciPosti()
 *          [x] override ToString
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
                if (DataPassata(value)) {
                    throw new DataPassataException($"Data {nameof(value)} non può essere nel passato.");
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
        public uint PostiDisponibili {
            get => CapienzaMassima - PostiPrenotati;
        }

        // COSTRUTTORI
        private Evento(string titolo, uint capienzaMassima) {
            Titolo = titolo;
            CapienzaMassima = capienzaMassima;
            PostiPrenotati = 0;

        }
        public Evento(string titolo, DateTime data, uint capienzaMassima) : this(titolo, capienzaMassima) {
            Data = DateOnly.FromDateTime(data);
        }

        public Evento(string titolo, DateOnly data, uint capienzaMassima) : this(titolo, capienzaMassima) {
            Data = data;
        }

        public Evento(Evento eventoDaCopiare) : this(eventoDaCopiare.Titolo, eventoDaCopiare.Data, eventoDaCopiare.CapienzaMassima) {
            PostiPrenotati = eventoDaCopiare.PostiPrenotati;
        }

        // METODI PUBBLICI
        public void PrenotaPosti(uint postiDaPrenotare) {
            if (postiDaPrenotare < 1) throw new NotSupportedException("Non puoi prenotare zero o meno posti.");
            if (postiDaPrenotare + PostiPrenotati > CapienzaMassima) {
                throw new ArgumentOutOfRangeException(nameof(postiDaPrenotare), "Non puoi prenotare più posti di quelli disponibili.");
            }
            if (DataPassata()) {
                throw new DataPassataException("Non puoi prenotare posti per un evento già passato.");
            }

            PostiPrenotati += postiDaPrenotare;
        }

        public void DisdiciPosti(uint postiDaDisdire) {
            if (postiDaDisdire < 1) throw new NotSupportedException("Non puoi disdire zero o meno posti.");
            if (postiDaDisdire > PostiPrenotati) {
                throw new ArgumentOutOfRangeException(nameof(postiDaDisdire), "Non puoi disdire più posti di quelli già prenotati.");
            }
            if (DataPassata()) {
                throw new DataPassataException("Non puoi disdire posti per un evento già passato.");
            }

            PostiPrenotati -= postiDaDisdire;
        }

        public override string ToString() {
            return $"{Data.ToString(CultureInfo.CurrentCulture)} - {Titolo}";
        }

        // METODI PRIVATI
        protected bool DataPassata() {
            return Data < DateOnly.FromDateTime(DateTime.Now);
        }

        protected static bool DataPassata(DateOnly data) {
            return data < DateOnly.FromDateTime(DateTime.Now);
        }

        protected static bool DataPassata(DateTime data) {
            return DateOnly.FromDateTime(data) < DateOnly.FromDateTime(DateTime.Now);
        }

    }
}
