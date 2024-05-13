using InfoedukaCLI;
using InfoedukaDto;

Console.Write("Username: ");
var username = Console.ReadLine();

Console.Write("Password: ");
var password = ConsoleUtils.ReadPassword();

InfoedukaRepo repo = new();
await repo.Login(username, password);

InfoedukaResponse ieResponse = await repo.GetInfo();

foreach (var akademskeGodina in ieResponse.Data.Reverse())
{
    foreach (var upisanaGodina in akademskeGodina.UpisaneGodine)
    {
        Console.WriteLine($"------ {upisanaGodina.Godina}. godina {upisanaGodina.Studij} -----");
        foreach (var predmet in upisanaGodina.Predmeti)
        {
            Console.WriteLine($"\t{predmet.IdPredmet} : {predmet.ImePredmeta}");
        }
    }
}

