# ZADATAK
Potrebno je napraviti evidenciju putnih naloga gdje bi imali službene automobile, djelatnike te datum putovanja relacija i kilometraža. 

Djelatnici i automobili su tzv. Sifrarnici pa se prilikom unosa u evidenciju biraju ne tipkaju. 

Znači baza podataka bi imala 3 tablice 
* Djelatnik ( ime i prezime)
* Automobil ( naziv i registracija) 
* Putni nalog (FK djelatnik, FK automobil, datum putovanja, kilometraža, relacija tekstualno)

Omogućiti CRUD operacije nad djelatnikom, automobilom i putnom nalogu .

Na kraju izvući analitiku za vremenski period koji djelatnik je imao najviše putnih naloga i koje je auto najviše kilometara prešlo 

Napravi .net backend i React frontend da postoje forme za unos izmjenu i brisanje podataka uz kontrolu 

<b>Kontrola</b>: 

Brisanje dozvoljeno ako nije korišteno u evidenciji putni nalog da javi lijepu poruku podatak korišten pa nije moguće obrisati 
