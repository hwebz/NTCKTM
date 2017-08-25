# KTM Company

## Local development setup

[More info](docs/local-dev-setup.md)

Continuous deployment steps:
* When code changes detected on _develop_ branch on GitHub, build step gets triggered on [Team City server](http://tc.geta.no).
* Build step builds solution, creates NuGet packages, creates Octopus release and triggers deploy on Octopus for Test environment.
* Octopus deploys _KtmCompany.Web_ on Test environment.
* Then Octopus runs smoke tests for both sites and verifies that no error code returned on the main pages.

Usually the whole process from checking till deployment takes 2-4 minutes.

The Test sites address:

http://ktmcompany.geta.no

CMS admin username/password:
Geta Active directory user

## Branching and deployment

Develop is the development branch.

Main is the production ready branch.
