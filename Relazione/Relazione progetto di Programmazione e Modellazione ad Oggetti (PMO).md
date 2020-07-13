# Relazione progetto di Programmazione e Modellazione ad Oggetti (PMO)

## Specifica di Progetto

Il progetto consiste nella realizzazione di un supporto per la creazione di personaggi di RPG.
L'utente potrà scegliere se generare il personaggio casualmente oppure tramite una creazione guidata, dove avrà la piena libertà di scegliere come personalizzare la sua creazione.
##### Generazione Casuale
Nel caso in cui la generazione sia casuale, l'utente potrà selezionare a quale livello far partire il suo personaggio, da un minimo di 1 ad un massimo di 5. Verrano poi generate le statistiche, lasciando la possibilità all'utente di inserirle manualmente o di inserirle casualmente. Infine, verranno scelti dei talenti speciali per il personaggio scelto. L'utente potrà anche scegliere il nome, il sesso e altre caratteristiche del personaggio. Alla fine della creazione, l'utente riceverà, sia a schermo che in un file .txt, una piccola descrizione della classe e tutte le caratteristiche che lo rappresentano.
##### Generazione Guidata
Nel caso in cui l'utente decida di utilizzare la generazione guidata, dovrà innanzitutto scegliere quale classe (tra le disponibili) utilizzare, per poi andare a specificare nome, sesso ed altre caratteristiche non prettamente inerenti al combattimento. Successivamente, verrà chiesto all'utente di inserire le statistiche del personaggio, che potranno essere generate casualmente dal programma o inserite manualmente dall'utente. Infine, l'utente dovra scegliere quali talenti speciali utilizzare. Tutte le informazioni verranno poi stampate a schermo e salvate su un file .txt.

## Studio del Problema
La specifica in sè non presenta problemi enormi. Gli inconvenienti maggiori sono:
- Gestione della generazione guidata
- Gestione della generazione casuale
- Lettura e scrittura da file. 

La gestione della generazione giudata può creare problemi per il gran numero di scelte da dover gestire; inoltre qui sono presenti diverse operazioni che richiedono l'input da tastiera da parte dell'utente, che devono essere gestite.

La gestione della generazione randomica è diversa rispetto a quella guidata; infatti, la generazione randomica si interessa poco delle interazioni con l'utente, ma sfrutta la randomicità per poter creare il personaggio. Questo potrebbe essere motivo di problemi.


La scrittura viene richiesta da specifica, mentre la lettura sarà una scelta implementativa per poter conservare delle informazioni essenziali durante l'esecuzione del programma, ma non strettamente collegate all'esecuzione dello stesso (queste informazioni sono "statiche", ovvero non cambiano durante l'esecuzione del programma e il file di testo in cui sono immagazzinate funge da "database fittizzio")

##### Gestione della Generazione Guidata
La gestione della generazione guidata viene effettuata dalla classe *GuidedGenerator()*; questa classe è una classe statica che restituisce un valore di tipo *CharacterCombat()*. All'interno di questa classe vengono gestite tutte le scelte al quale l'utente si deve sottoporre per poter creare in maniera procedurale un personaggio.

##### Gestione della Generazione Randomica
All'interno della classe *RandomGenerator()* avviene la creazione randomica del personaggio. Questa classe sfrutta la classe *DiceRoll()* per poter generare numeri randomici. Quest'ultima classe viene utilizzata anche in altre parti del programma; non è una classe estremamente necessaria, ma per migliorare la mia conoscenza ed esperienza con C# ho deciso comunque di utilizzarla.

##### Lettura e scrittura su file
In generale, questa funzionalità non dovrebbe presentare enormi problemi. Tuttavia, ho deciso di complicarmi le cose e rendere la lettura e scrittura pseudo-dinamiche: sia per la lettura, sia per la scrittura, viene caricata la path al file da scrivere o leggere in maniera dinamica, senza il bisogno di cambiare manualmente path all'interno del progetto.
# Scelte Architetturali

Non ci sono scelte architetturali significative; la scelta principale è stata la selezione delle strutture dati adeguate per poter andare a memorizzare i dati inseriti dall'utente.

##### Dictionary <key, value>
Una delle strutture dati più utilizzate all'interno del programma sono *Dictionary<key, value>*. Questa struttura dati mi permette di memorizzare nome e valore di determinate variabili utili per delle fasi più avanzate dell'esecuzione. 
Pro:
- Semplice da usare
- Permette di fare storage di una key e un valore associato

Cons:
- La lettura, modifica ed eliminazione di un elemento in questa struttura dati può portare a delle eccezioni che devono essere gestite
 
##### Dove sono i Pattern?
Purtroppo, nessun pattern è stato implementato all'interno di questo progetto a causa di una mancanza di esperienza nell'utilizzo degli stessi. Non ho riconosciuto i pattern più adeguati fino al completamento del codice stesso.
Inoltre, ho preferito evitare di utilizzare forzatamente i pattern; alcuni potevano essere implementati, ma sarebbero stati "inutili" o esageratamente forzati.

##### Singleton
Per l'apertura di un determinato file all'interno del mio programma avrei potuto implementare il pattern creazionale Singleton. Ho ritenuto inopportuno farlo perchè, già di principio, quella classe viene istanziata solo una volta per ogni esecuzione del programma.

##### Visitor
Durante la scrittura del file, avrei potuto utilizzare il pattern comportamentale Visitor. Ho preferito non farlo perchè effettuare questa operazione implicava la creazione di una ulteriore struttura dati dove andare ad immagazzinare elementi da altre strutture dati che già avevo popolato, solo per poter applicare il pattern su di essa.

##### Factory Method
Il pattern principale che avrei dovuto implementare è proprio questo, il Factory Method. L'unico problema di questo pattern è che ho capito la sua importanza all'interno di un progetto come il mio solo a poche ore dalla consegna. Il Factory Method mi avrebbe permesso di risparmiare tempo, codice e risorse.

### Diagramma delle Classi

![Diagramma UML delle classi](https://github.com/NocturneCrowz/PMO-Image/blob/master/RPG%20Character%20Creator%20(1).png)

### Documentazione sull'utilizzo
Una volta compilato, il software non ha bisogno di parametri particolari per poter eseguire. Tutte le interazioni necessarie per poter portare a buon fine l'esecuzione verranno richieste a schermo dal programma stesso.

##### Nota
La lettura e scrittura su file vengono effettuati in maniera dinamica. Date le mie lacune di conoscenza, ho cercato modi per rendere tali operazioni più "sicure" possibile. Sono a conoscenza di possibili bug dovuti a queste operazioni, ma non sono ancora riuscito a risolverli. 
Per poter testare il programma, si consiglia di utilizzare Visual Studio su Windows 10; inoltre, la cartella del progetto va estratta nel Desktop. Cercherò di risolvere questo bug nelle future release.

### Use Cases con relativo schema UML
Data la relativa semplicità del progetto, gli Use Cases sono abbastanza limitati. Inoltre, si è preferito adottare una versione più discorsiva rispetto ai diagrammi UML.
________________________________________________________________________________

##### Use Case
Generazione Guidata di un personaggio
##### ID
UC1
##### Actor
User (U1)
##### Precondition
- U1 ha scelto la generazione guidata
##### Basic Course of Events
- U1 sceglie la classe del suo personaggio
- U1 sceglie il livello del personaggio
- U1 inserisce le statistiche del personaggio
- (Opzionale) Le statistiche vengono generate casualmente
- U1 sceglie la razza del suo personaggio
- U1 inserisce il valore dei suoi HP
- (Opzionale) U1 inserisce talenti bonus (se presenti)
- U1 inserisce tutti i dati opzionali nella creazione (nome, età, ecc...)
- U1 salva il personaggio ed esce dalla creazione guidata
##### Postcondition
- Un file .txt verrà creato sul Desktop di U1 contenente tutte le informazioni del suo personaggio

________________________________________________________________________________

##### Use Case
Generazione Randomica di un personaggio
##### ID
UC2
##### Actor
User (U1)
##### Precondition
- U1 ha scelto la generazione randomica
##### Basic Course of Events
- Tutte le statistiche vengono generate randomicamente (entro i range previsti dal manuale)
- (Opzionale) U1 inserisce manualmente le caratteristiche base
- U1 inserisce tutti i dati opzionali nella creazione (nome, età, ecc...)
- U1 salva il personaggio ed esce dalla creazione guidata
##### Postcondition
- Un file .txt verrà creato sul Desktop di U1 contenente tutte le informazioni del suo personaggio



