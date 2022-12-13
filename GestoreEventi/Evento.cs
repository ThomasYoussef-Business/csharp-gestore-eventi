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
                if (value.CompareTo(DateTime.Now) < 0) {
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

        // METODI PUBBLICI
        public void PrenotaPosti(uint postiDaPrenotare) {
            if (Data.CompareTo(DateOnly.FromDateTime(DateTime.Now)) < 0) {
                throw new DataPassataException("Non puoi prenotare posti per un evento già passato.");
            }
            else if (postiDaPrenotare + PostiPrenotati > CapienzaMassima) {
                throw new ArgumentOutOfRangeException(nameof(postiDaPrenotare), "Non puoi prenotare più posti di quelli disponibili.");
            }

            PostiPrenotati += postiDaPrenotare;
        }

        public void DisdiciPosti(uint postiDaDisdire) {
            if (Data.CompareTo(DateOnly.FromDateTime(DateTime.Now)) < 0) {
                throw new DataPassataException("Non puoi disdire posti per un evento già passato.");
            }
            else if (postiDaDisdire > PostiPrenotati) {
                throw new ArgumentOutOfRangeException(nameof(postiDaDisdire), "Non puoi disdire più posti di quelli già prenotati.");
            }

            PostiPrenotati -= postiDaDisdire;
        }

        public override string ToString() {
            return $"{Data.ToString(CultureInfo.CurrentCulture)} - {Titolo}";
        }

        // METODI PRIVATI

    }
}
