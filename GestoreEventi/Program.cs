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
 * 
 * 
 * Bonus Milestone:
 * 
 */

using GestoreEventi;

List<Evento> events = new List<Evento>() {
    new Evento("Classi",                         new DateOnly(year: 2024, month: 12, day: 17), 200),
    new Evento("Variabili",                      new DateOnly(year: 2024, month: 12, day: 15), 200),
    new Evento("Tipi per value e per reference", new DateOnly(year: 2024, month: 12, day: 16), 200),
    new Evento("Encapsulazione degli attributi", new DateOnly(year: 2024, month: 12, day: 19), 200),
    new Evento("Metodi nelle classi",            new DateOnly(year: 2024, month: 12, day: 18), 200),
};

ProgrammaEventi testProgramma = new ProgrammaEventi("Generation C# Testing");

foreach(Evento evento in events) {
    testProgramma.AggiungiEvento(evento);
}

testProgramma.RiordinaEventi();
testProgramma.StampaProgramma();