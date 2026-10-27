# PhysicalLibrary

## Comment j'ai construit le projet
- API .NET 10 avec Entity Framework et SQL Server LocalDB, testée avec Swagger.
- Un dossier par domaine (livres, adhérents, emprunts), avec à chaque fois un contrôleur, un service et un repository.
- Les règles d'emprunt sont toutes dans `LoanService`, donc faciles à tester.
- J'ai choisi 404 quand quelque chose n'existe pas, 400 quand la requête est mal remplie, et 409 quand une règle métier bloque.

## Mes hypothèses
- Les exemplaires, c'est un simple compteur sur le livre. On ne sait pas quel exemplaire précis est sorti.
- Un livre a au moins un exemplaire, et on ne peut pas descendre sous le nombre déjà empruntés.
- Un emprunt est en cours tant qu'il n'a pas de date de retour.
- Un adhérent avec un livre en retard pas rendu ne peut plus emprunter. Dès qu'il le rend, c'est bon.
- Trois semaines, j'ai compté 21 jours.
- L'email est unique par adhérent.

## Ce que je n'ai pas fait
- Les fonctionnalités optionnelles : l'expérience m'a appris qu'il vaut mieux une base qui fonctionne que plein de fonctionnalités instables. Le modèle est prêt pour la suite.
- Les tests unitaires : je les aurais bien faits, mais je n'ai pas eu le temps. J'ai testé tous les cas à la main avec Swagger.

## Avec le recul
- J'ai hésité sur la modélisation. J'essayais d'anticiper avec plutôt un `IMedia`, parce que dans le futur on pourrait louer des DVD, par exemple, avec une autre règle de location. Finalement je suis resté sur les livres, avec des interfaces sur les entités.
- J'ai surtout galéré sur la gestion des erreurs dans les contrôleurs.
- Il y a plein de pistes d'amélioration, que je détaillerai à l'oral.
