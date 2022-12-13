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
 * 
 * 
 * Milestone 4:
 * 
 * 
 * Bonus Milestone:
 * 
 */

using GestoreEventi;


Console.WriteLine("Inserisci un titolo per il tuo evento: ");
string titolo = Console.ReadLine();

Console.WriteLine("Inserisci una data per il tuo evento:");
DateOnly dataEvento;
while (!DateOnly.TryParseExact(Console.ReadLine(), "d/M/yyyy", out dataEvento)) {
    Console.WriteLine("La data inserita non è una data valida. Riprova: ");
}

Console.WriteLine("Inserisci la capienza massima per il tuo evento: ");
int capienzaMassima;
while (!int.TryParse(Console.ReadLine(), out capienzaMassima)) {
    Console.WriteLine("La capienza massima inserita non è un numero. Riprova: ");
}

Evento mioEvento = new Evento(titolo, dataEvento, (uint)capienzaMassima);


uint postiDaPrenotare;
string opzione;
Console.WriteLine("Vuoi prenotare dei posti?");
do {
    opzione = Console.ReadLine();
} while (opzione != "si" && opzione != "no");

while (opzione == "si") {
    opzione = string.Empty;
    Console.WriteLine("Quanti posti desideri prenotare? ");
    postiDaPrenotare = uint.Parse(Console.ReadLine());

    mioEvento.PrenotaPosti(postiDaPrenotare);
    Console.WriteLine($"Posti prenotati: {mioEvento.PostiPrenotati}; Posti disponibili: {mioEvento.PostiDisponibili}");

    Console.WriteLine("Vuoi prenotare altri posti?");
    do {
        opzione = Console.ReadLine();
    } while (opzione != "si" && opzione != "no");
}


uint postiDaDisdire;
Console.WriteLine("Vuoi disdire dei posti?");
do {
    opzione = Console.ReadLine();
} while (opzione != "si" && opzione != "no");

while (opzione == "si") {
    opzione = string.Empty;
    Console.WriteLine("Quanti posti desideri disdire? ");
    postiDaDisdire = uint.Parse(Console.ReadLine());

    mioEvento.DisdiciPosti(postiDaDisdire);
    Console.WriteLine($"Posti prenotati: {mioEvento.PostiPrenotati}; Posti disponibili: {mioEvento.PostiDisponibili}");

    Console.WriteLine("Vuoi prenotare altri posti?");
    do {
        opzione = Console.ReadLine();
    } while (opzione != "si" && opzione != "no");
}