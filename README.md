# TRAVEL APP

## Sadržaj
* [Zadatak](#zadatak)
* [.NET Core Web API (+React)](#.NET-Core-Web-API-(+React))
* [.NET Core MVC](#.NET-Core-MVC)
* [Konfiguracija baze podataka](#konfiguracija-baze-podataka)

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

## .NET Core Web API (+React)

Ovaj projekt je implementacija full-stack web aplikacije koristeći .NET Web API za backend i React za frontend. Projekt koristi MS SQL Server za bazu podataka, a tablice se kreiraju korištenjem SQL komandi.

Verzije:
* Verzija sa SQL procedurama: U ovoj verziji, aplikacija koristi SQL Stored Procedures za interakciju sa bazom podataka. Logika za manipulaciju podacima je implementirana unutar tih procedura, koje su pozvane iz backend koda.
* Verzija sa Entity Frameworkom: U ovoj verziji aplikacije, za rad s bazom podataka koristi se Entity Framework kao ORM (Object-Relational Mapping) alat.

Tehnologije:
* Backend: .NET Core Web API
* Frontend: React
* Baza podataka: MSSQL Server
* ORM (Entity Framework verzija): Entity Framework Core

## .NET Core MVC

Ovaj projekt je ASP.NET MVC aplikacija koja koristi Entity Framework za rad s bazom podataka. Tablice i relacije se kreiraju korištenjem EF migracija.

Tehnologije:
Kombinacija Backend i Frontend (cshtml): ASP.NET MVC
Baza podataka: MSSQL Server
ORM: Entity Framework Core

## Konfiguracija baze podataka

Oba projekta pružaju robusna rješenja za rad s podacima kroz različite pristupe, prvi projekt koristi ručne SQL komande za kreiranje tablica te SQL procedure ili Entity Framework za rad sa podacima, dok drugi projekt koristi migracije za kreiranje te Entity Framework za rad sa podacima.
