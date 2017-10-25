Pensez a changer le project.json pour le passer en core et non en dot net standard


 "dependencies": {
    "Microsoft.NETCore.App": {
      "version": "1.0.0",
      "type": "platform"
    }

	.
	.
	.

	 "frameworks": {
    "netcoreapp1.0": {}
  }


  --------------------------------------------------------------------------------------------------------------------------------------------------------------------


1 : Installer les package suivant
	"Microsoft.EntityFrameworkCore.Tools": "1.0.0-preview3-final",
    "Microsoft.EntityFrameworkCore.SqlServer.Design": "1.0.1",
    "Microsoft.EntityFrameworkCore.SqlServer": "1.0.1",
    "Microsoft.EntityFrameworkCore.Design": "1.0.1",
    "Microsoft.EntityFrameworkCore": "1.0.1"

2 : Ajouter un tools pour la commande dotnet ef : 
 "tools": {
    "Microsoft.EntityFrameworkCore.Tools": {
      "version": "1.0.0-preview3-final",
      "imports": [
        "portable-net45+win8+dnxcore50",
        "portable-net45+win8"
      ]
    }
  }

3 : Definir le classLibrairy comme projet de démarrage
4 : Creer un dossier Models
5 : Lancer le scaffold dans le PAckage Manager console
	Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=MVC6_Person" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models