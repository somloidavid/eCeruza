//[{"Name": "Teszt Elek","Password": "Test123","Class": "9A","Language":"Angol","Grades": [{"Subject": "Matematika","Message": "Témazáró Dolgozat","Value": 5,"Date": "2023-09-03T00:00:00"},{"Subject": "Történelem","Message": "Szóbeli Felelet","Value": 3,"Date": "2023-09-05T00:00:00"}]}]

using System;
using System.IO.Packaging;
using System.Linq;
using System.Text;

string[] firstNames = { "Balázs", "Ármin", "Dániel", "Krisztián", "Károly", "Béla", "Gergely", "Ákos", "Bence", "Zoltán", "Ildikó", "Hanna", "Nóra", "Katalin", "Kaludia", "Sára", "Lívia", "Réka", "Anna", "Gyöngyi" };
string[] lastNames = { "Kovács", "Horváth", "Varga", "Kocsis", "Szűcs", "Papp", "Soós", "Tamás", "Faragó", "Vörös", "Sipos" };
string[] subjects = { "Történelem", "Matematika", "Fizika", "Irodalom", "Angol", "Német", "Osztályfőnöki", "Nyelvtan", "Programozás", "IKT Projektmunka" };
string[] messages = { "Témazáró Dolgozat", "Írásbeli Felelet", "Szóbeli Felelet", "Órai Munka" };
string[] classes = { "9A", "9B", "9C", "10A", "10B", "10C", "11A", "11B", "11C", "12A", "12B", "12C", };
string[] languages = { "Angol", "Német"};
//string f = File.WriteAllLines("Students.json",);
string[] rows = new string[192];
foreach (string clazz in classes)
{
	for (int i = 0; i < 16; i++)
	{
		string randomized = "{";
		Random rnd = new Random();
		randomized += $"\"Name\":\"{lastNames[rnd.Next(lastNames.Length)]} {firstNames[rnd.Next(firstNames.Length)]}\"";
        randomized += $",\"Password\":\"{CreatePassword(rnd.Next(10))}\"";
        randomized += $",\"Class\":\"{clazz}\"";
        randomized += $",\"Language\":\"{languages[rnd.Next()]}\"";
        string gradesString = "\"Grades\":[";
        for (int j = 0; j < rnd.Next(14); j++)
        {
            gradesString += $"\"Subject\":";
        }
    }
}

string CreatePassword(int length)
{
    const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    StringBuilder res = new StringBuilder();
    Random rnd = new Random();
    while (0 < length--)
    {
        res.Append(valid[rnd.Next(valid.Length)]);
    }
    return res.ToString();
}