                              AnimalCare Veterinary (ASP.NET Database First)
                                     Objectifs du Projet
                                     
Gérer efficacement les administrateurs, employés, animaux, propriétaires et rendez-vous vétérinaires.
Implémenter des opérations CRUD complètes (Create, Read, Update, Delete).
Faciliter l'accès rapide aux informations clés :

Rendez-vous quotidiens
Animaux actifs et historiques
Disponibilités des vétérinaires
Rapports médicaux et diagnostics des animaux

                                    Technologies utilisées

Technologie	Détails

Framework	ASP.NET Web Forms (.NET Framework)
ORM	Entity Framework (Database First, EDMX)
Base de données	SQL Server
Langages	C#, SQL, HTML, CSS
Gestion Code	Git, GitHub, Visual Studio.

                                    Fonctionnalités réalisées 
    ADMIN 
CRUD pour les employés.
Page "EmployeeContacts" pour gérer les employés.
Page accueil historique des visites : "HistoryVisit".
Vue complète des disponibilités des vétérinaires.

   VÉTÉRINAIRE 
Gestion des disponibilités des vétérinaires.
Page accueil pour consulter les rendez-vous quotidiens (VisitsForToday).
Consultation complète du dossier animal (rapports, historique des traitements : ActivePetTreatments).
Horaire complet "VeterinarySchedule".

   SECRÉTAIRE 
Page accueil "VisitsForToday" et "ActiveVisitsForPets".
CRUD complet des animaux.
CRUD complet des propriétaires.

   PAGE RENDEZ-VOUS 
CRUD complet des rendez-vous.
Affichage des visites actives et disponibilités hebdomadaires vétérinaires (VeterinaryAvailabilityForWeek).

                                     Interface utilisateur (Front-end)
                                     
Formulaires intuitifs pour gérer animaux, propriétaires, employés, rendez-vous.
Boutons d’accès rapide :

-Visites du jour
-Animaux actifs
-Liste complète des animaux
-Disponibilité du vétérinaire
-Rapports médicaux et diagnostics
-Affichage clair via GridViews.

                                      Gestion des données (Back-end)
                                      
Utilisation optimisée de vues SQL :

-vw_VisitsForToday (visites du jour)
-vw_VeterinaryAvailabilityForWeek
-vw_ActiveVisitsForPets (visites actives avec détails)
-vw_ActivePetsTreatements

Méthodes robustes de CRUD sur animaux, propriétaires, employés, rendez-vous.
Contexte Entity Framework centralisé (AnimalCareDb.Context.cs).

                                    Structure du Projet

AnimalCare_dbFirst/
├── AnimalCareDb.edmx                // Modèle EDMX Entity Framework
├── Web.config                       // Connexions et configurations
├── WebFormAdmin.aspx                // Page administration
├── WebFormEmployee.aspx             // Gestion des employés
├── WebFormGesPets2.aspx             // Gestion des animaux (CRUD, visites, etc.)
├── WebFormOwners1.aspx              // Gestion des propriétaires
├── WebFormRec.aspx                  // Page d'accueil secrétaire
├── WebFormVet.aspx                  // Page d'accueil vétérinaire
├── WebFormVetSchedule.aspx          // Calendrier complet vétérinaire
├── WebFormVisits.aspx               // Gestion complète des rendez-vous
├── WebFormLogin.aspx                // Page de connexion utilisateurs
│
├── App_Code/
│   └── AnimalCareDb.Context.cs      // Contexte EF généré automatiquement
│
└── README.md                        // Documentation du projet 



                Instructions pour lancer le projet localement
                      
1. Cloner le dépôt GitHub

git clone https://github.com/ton_nom_utilisateur/AnimalCare_dbFirst.git

2. Ouvrir dans Visual Studio
   
Double-clic sur AnimalCare_dbFirst.sln.

3. Configurer la connexion SQL Server
   
Modifier la chaîne de connexion dans web.config.

4. Exécuter le projet
   
F5 pour lancer l'application depuis Visual Studio.


                                  Contributeurs
                
Jean-Noël
Alejandro Berrio
Jeremy poirre
Fosso Fosso

