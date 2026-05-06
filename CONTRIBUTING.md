# CONTRIBUTING.md

## Objet
Ce document décrit la convention de branches et les règles de contribution pour ce dépôt. L'objectif est de garder le code organisé, simple à comprendre et sûr pour les déploiements.

## Branches principales
Nous utilisons trois branches principales :

- `main`
  - Branche de production. Contient uniquement du code prêt pour déploiement.
  - Protégée : les push directs sont interdits, seules les Pull Requests (PR) fusionnées après revue passent.

- `develop`
  - Branche d'intégration. Regroupe les fonctionnalités prêtes à être testées ensemble.
  - Base pour préparer des versions vers `main`.

- `feature`
  - Branche de collaboration pour développement en cours. Utilisez-la pour partager des travaux longs ou centraliser plusieurs petites tâches quand nécessaire.
  - Pour les travaux isolés, créez des branches locales décrites dans la section suivante et fusionnez dans `feature` ou `develop` via PR.

> Remarque : on conserve ces trois branches comme branches de référence. Les développeurs peuvent créer des branches temporaires supplémentaires pour les features/bugfixs selon les conventions ci-dessous.

## Conventions de nommage
- Branches locales/temporaires :
  - `feature/<short-description>` — nouvelles fonctionnalités.
  - `bugfix/<issue-number>-<short-description>` — corrections de bugs.
  - `hotfix/<short-description>` — corrections critiques à fusionner rapidement.

- Pull Request : titre clair, référence le ticket/issue (ex. `[#123] Ajouter authentification OAuth`) et décrit le changement.

## Flux de travail recommandé
1. Mettre à jour `develop` : `git checkout develop && git pull origin develop`.
2. Créer une branche locale : `git checkout -b feature/<short-desc>`.
3. Travailler, commit souvent avec des messages clairs.
4. Pousser la branche : `git push -u origin feature/<short-desc>`.
5. Ouvrir une PR vers `develop` (ou `main` si prêt pour prod), demander une revue.
6. Après validation et tests, fusionner via l'interface (Merge / Squash selon la politique) et supprimer la branche distante.

## Commandes Git utiles
Initialiser et créer les trois branches (ex. sur une nouvelle repo distante) :

```bash
git init
git add .
git commit -m "Initial commit"
# Associer la remote (ex : GitHub)
git remote add origin <url-de-votre-repo>
# Créer et pousser main
git branch -M main
git push -u origin main
# Créer et pousser develop
git checkout -b develop
git push -u origin develop
# Créer et pousser feature
git checkout -b feature
git push -u origin feature
```

Créer rapidement une branche locale de feature et la pousser :

```bash
git checkout develop
git pull origin develop
git checkout -b feature/ma-nouvelle-fonctionnalite
git push -u origin feature/ma-nouvelle-fonctionnalite
```

## Protection des branches
- `main` et `develop` doivent être protégées : révision obligatoire, builds verts (CI) et approbation de reviewers.
- Interdire les push directs sur les branches protégées.

## Revue de code et checklist PR
Avant de demander une revue :
- La branche doit passer les builds locaux/CI.
- Les tests automatisés passent.
- Les messages de commit sont clairs.
- La PR contient une description et, si nécessaire, captures d'écran ou preuves de test.

## Visual Studio
Pour travailler depuis Visual Studio 2022 : utilisez le panneau __Git Changes__ ou __Team Explorer__ pour gérer les branches, commits et push/pull.

## Questions / Exceptions
Si vous avez un cas particulier (mono-commit urgent, migration, etc.), ouvrez une issue et documentez la raison du contournement.

Merci de suivre ces règles pour garder le dépôt propre et maintenable.