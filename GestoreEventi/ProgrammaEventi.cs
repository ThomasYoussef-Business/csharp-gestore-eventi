/*
 *	[] Classe ProgrammaEventi
 *		[x] Titolo
 *		[x] Lista di Eventi
 *		[x] Costruttore che prende un titolo e inizializza la lista di eventi
 *		[x] AggiungiEvento(Evento): void
 *		[x] EventiInData(DateOnly): List<Evento>
 *		[x] static StringaListaEventi: string
 *		[x] NumeroEventi(): int
 *		[x] SvuotaListaEventi(): void
 *		[x] override ToString(): string
 */

namespace GestoreEventi {
    public class ProgrammaEventi {
        // ATTRIBUTI
        private string titolo;
        private readonly List<Evento> eventi = new List<Evento>();

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
        public List<Evento> Eventi => eventi.ConvertAll(eventoDaClonare => new Evento(eventoDaClonare));

        private List<Evento> VeraListaEventi => eventi;

        // COSTRUTTORI
        public ProgrammaEventi(string titolo) {
            Titolo = titolo;

        }

        // METODI PUBBLICI
        public void AggiungiEvento(Evento eventoDaAggiungere) {
            VeraListaEventi.Add(eventoDaAggiungere);
        }

        public List<Evento> EventiInData(DateOnly data) {
            return VeraListaEventi.Where(evento => evento.Data == data).ToList();
        }

        public List<Evento> EventiInData(DateTime data) {
            return EventiInData(DateOnly.FromDateTime(data));
        }

        public static string StringaListaEventi(List<Evento> listaEventi) {
            return string.Join("\n", listaEventi);

            // Originariamente avevo creato ciò che è scritto sotto, ma grazie ad Alessio,
            // mi sono reso conto che string.Join già chiama ToString su ogni elemento!


            //return string.Join('\n', listaEventi.ConvertAll(e => e.ToString()));
            // Una chicca per Emanuele 😂

            //string stringaFinale = string.Empty;
            //foreach (Evento evento in listaEventi) {
            //    stringaFinale = $"{stringaFinale}{evento}\n";
            //}

            //return stringaFinale;
        }

        public int NumeroEventi() => VeraListaEventi.Count;
        public void SvuotaEventi() => VeraListaEventi.Clear();
        public override string ToString() {
            return $"{Titolo}:\n\t" + StringaListaEventi(VeraListaEventi).Replace("\n", "\n\t");
        }

        public void StampaProgramma() {
            Console.WriteLine(this);
        }
        // METODI PRIVATI

    }
}
