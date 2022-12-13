/*
 * Milestone 1:
 *      [x] Classe Evento 
 * 
 * Milestone 2:
 *      [x] Chiedi un nuovo evento all'utente
 *      [x] Chiedi se e quante prenotazioni vuole fare l'utente
 *      [x] Stampare il numero di posti prenotati e posti disponibili
 *      [x] Chiedere se e quanti posti da disdire
 * 
 * Milestone 3:
 *      [x] Classe ProgrammaEventi
 * 
 * 
 * Milestone 4:
 *      [x] Usa le classi create! 
 * 
 */

using GestoreEventi;

Console.Write("Inserisci il titolo del tuo programma: ");
string titoloProgramma = Console.ReadLine().Trim();
while (string.IsNullOrWhiteSpace(titoloProgramma)) {
    Console.Write("Il titolo non può essere vuoto. Riprova: ");
    titoloProgramma = Console.ReadLine().Trim();
}

uint numeroDiEventiDaInserire;
Console.Write("\nInserisci il numero di eventi da inserire: ");
while (!uint.TryParse(Console.ReadLine(), out numeroDiEventiDaInserire)) {
    Console.Write("Questo non è un numero valido. Riprova: ");
}


ProgrammaEventi programmaUtente = new ProgrammaEventi(titoloProgramma);
uint eventiAggiuntiSuccessivamente = 0;
string titoloEvento;
DateOnly dataEvento;
uint capienzaMassima;
while (eventiAggiuntiSuccessivamente < numeroDiEventiDaInserire) {
    Console.Write($"\n\nInserisci il titolo del tuo #{eventiAggiuntiSuccessivamente + 1} evento: ");
    titoloEvento = Console.ReadLine().Trim();

    Console.Write("Inserisci la data del tuo evento in formato \"gg/mm/yyyy\": ");
    while (!DateOnly.TryParseExact(Console.ReadLine(), "d/M/yyyy", out dataEvento)) {
        Console.Write("Questa non è una data valida. Riprova: ");
    }

    Console.Write("Inserisci la capienza massima per il tuo evento: ");
    while (!uint.TryParse(Console.ReadLine(), out capienzaMassima)) {
        Console.Write("Questo non è un numero valido. Riprova: ");
    }

    try {
        Evento nuovoEvento = new Evento(titoloEvento, dataEvento, capienzaMassima);
        programmaUtente.AggiungiEvento(nuovoEvento);
        eventiAggiuntiSuccessivamente++;
    }
    catch (DataPassataException e) {
        Console.WriteLine($"È stato rialzato un errore. Hai inserito una data futura?\nErrore: {e.Message}\n");
    }
    catch (ArgumentNullException e) {
        Console.WriteLine($"È stato rialzato un errore. Hai inserito un titolo per il tuo evento?\nErrore: {e.Message}\n");
    }
    catch (ArgumentOutOfRangeException e) {
        Console.WriteLine($"È stato rialzato un errore. Hai inserito una capienza massima maggiore a zero?\nErrore: {e.Message}\n");
    }
    catch (Exception e) {
        Console.WriteLine($@"È stato rialzato un errore non previsto!
Contatta il developer di questo software a ""thomasyoussef.business@protonmail.com"",
e mostragli questo errore.
Errore: {e.Message}
");
    }
}

Console.WriteLine($@"Il numero di eventi nel programma {programmaUtente.Titolo} è: {programmaUtente.Eventi.Count}
Ecco il tuo programma:
{programmaUtente}");

DateOnly dataDaCercare;
Console.Write("\n\nInserisci una data in formato \"gg/mm/yyyy\" per sapere che eventi ci saranno quel giorno: ");
while (!DateOnly.TryParseExact(Console.ReadLine(), "d/M/yyyy", out dataDaCercare)) {
    Console.Write("\nQuesta non è una data valida. Riprova: ");
}

List<Evento> eventiInData = programmaUtente.EventiInData(dataDaCercare);
ProgrammaEventi.RiordinaEventi(eventiInData);

if (eventiInData.Count > 0) {
    Console.WriteLine($"Il {dataDaCercare.ToShortDateString()} ci sono questi eventi:");
    string listaEventiTrovati = ProgrammaEventi.StringaListaEventi(eventiInData);
    Console.WriteLine(listaEventiTrovati);
}
else {
    Console.WriteLine($"Non sono stati trovati eventi nel tuo programma per il {dataDaCercare.ToShortDateString()}");
}