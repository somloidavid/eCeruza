////[{"Name": "Teszt Elek","Password": "Test123","Class": "9A","Language":"Angol","Grades": [{"Subject": "Matematika",
////"Message": "Témazáró Dolgozat","Value": 5,"Date": "2023-09-03T00:00:00"},
////{"Subject": "Történelem","Message": "Szóbeli Felelet","Value": 3,"Date": "2023-09-05T00:00:00"}]}]

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.IO.Packaging;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks.Dataflow;

//string[] firstNames = { "Balázs", "Ármin", "Dániel", "Krisztián", "Károly", "Béla", "Gergely", "Ákos", "Bence", "Zoltán", "Ildikó", "Hanna", "Nóra", "Katalin", "Kaludia", "Sára", "Lívia", "Réka", "Anna", "Gyöngyi" };
//string[] lastNames = { "Kovács", "Horváth", "Varga", "Kocsis", "Szűcs", "Papp", "Soós", "Tamás", "Faragó", "Vörös", "Sipos" };
//string[] subjects = { "Történelem", "Matematika", "Fizika", "Irodalom", "Nyelvtan", "Programozás", "IKT Projektmunka" };
//string[] messages = { "Témazáró Dolgozat", "Írásbeli Felelet", "Szóbeli Felelet", "Órai Munka" };
//string[] classes = { "9A", "9B", "9C", "10A", "10B", "10C", "11A", "11B", "11C", "12A", "12B", "12C", };
//string[] languages = { "Angol", "Német"};
//List<string> rows = new List<string>();
//foreach (string clazz in classes)
//{
//	for (int i = 0; i < 16; i++)
//	{
//		string randomized = "{";
//		Random rnd = new Random();
//        string[] lang = new string[1];
//        lang[0] = languages[rnd.Next(2)];

//        randomized += $"\"Name\":\"{lastNames[rnd.Next(lastNames.Length)]} {firstNames[rnd.Next(firstNames.Length)]}\"";
//        randomized += $",\"Password\":\"{CreatePassword(rnd.Next(10))}\"";
//        randomized += $",\"Class\":\"{clazz}\"";
//        randomized += $",\"Subjects\":[";
//        for (int k = 0; k < subjects.Length; k++)
//        {
//            if (k != 0)
//            {
//                randomized += $",\"{subjects[k]}\"";
//            }
//            else
//            {
//                randomized += $"\"{subjects[k]}\"";
//            }
//        }
//        randomized += "]";
//        randomized += $",\"Language\":\"{lang[0]}\"";
//        string gradesString = ",\"Grades\":[";

//        gradesString +=  GenerateGrades(messages, rnd, subjects);
//        gradesString += GenerateGrades(messages, rnd, lang);
//        gradesString += "]";
//        randomized += gradesString;
//        randomized += "},";
//        rows.Add(randomized);
//    }
//}
//File.WriteAllLines("Students.json", rows.ToArray());

//string CreatePassword(int length)
//{
//    const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
//    StringBuilder res = new StringBuilder();
//    Random rnd = new Random();
//    while (0 < length--)
//    {
//        res.Append(valid[rnd.Next(valid.Length)]);
//    }
//    return res.ToString();
//}

//string GenerateGrades(string[] messages, Random rnd, string[] subjects)
//{
//    string generatedGrades = ""; 
//    foreach (string subject in subjects)
//    {
//        int gradesCount = rnd.Next(14);
//        for (int j = 0; j < gradesCount; j++)
//        {
//            string date = "";
//            int month = rnd.Next(12) + 1;
//            int day;
//            while (month > 5 && month < 9)
//            {
//                month = rnd.Next(12) + 1;
//            }
//            do
//            {
//                day = rnd.Next(31) + 1;
//            } while ((month == 2 && day > 28) || ((month == 4 || month == 6 || month == 9 || month == 11) && day > 30));
//            if (month > 9 && day < 10)
//            {
//                date = $"2022-{month}-0{day}";
//                if (j == 0)
//                {
//                    generatedGrades += $"{{\"Subject\":\"{subject}\",\"Message\":\"{messages[rnd.Next(4)]}\",\"Value\":{rnd.Next(5) + 1},\"Date\":\"{date}\"}}";
//                }
//                else
//                {
//                    generatedGrades += $",{{\"Subject\":\"{subject}\",\"Message\":\"{messages[rnd.Next(4)]}\",\"Value\":{rnd.Next(5) + 1},\"Date\":\"{date}\"}}";
//                }
//            }
//            else if (month == 9 && day < 10)
//            {
//                date = $"2022-0{month}-0{day}";
//                if (j == 0)
//            {
//                generatedGrades += $"{{\"Subject\":\"{subject}\",\"Message\":\"{messages[rnd.Next(4)]}\",\"Value\":{rnd.Next(5) + 1},\"Date\":\"{date}\"}}";
//            }
//            else
//            {
//                generatedGrades += $",{{\"Subject\":\"{subject}\",\"Message\":\"{messages[rnd.Next(4)]}\",\"Value\":{rnd.Next(5) + 1},\"Date\":\"{date}\"}}";
//            }
//            }
//            else if (month > 9 && day > 10)
//            {
//                date = $"2022-{month}-{day}";
//                if (j == 0)
//            {
//                generatedGrades += $"{{\"Subject\":\"{subject}\",\"Message\":\"{messages[rnd.Next(4)]}\",\"Value\":{rnd.Next(5) + 1},\"Date\":\"{date}\"}}";
//            }
//            else
//            {
//                generatedGrades += $",{{\"Subject\":\"{subject}\",\"Message\":\"{messages[rnd.Next(4)]}\",\"Value\":{rnd.Next(5) + 1},\"Date\":\"{date}\"}}";
//            }
//            }
//            else if (month == 9 && day > 10)
//            {
//                date = $"2022-0{month}-{day}";
//                if (j == 0)
//            {
//                generatedGrades += $"{{\"Subject\":\"{subject}\",\"Message\":\"{messages[rnd.Next(4)]}\",\"Value\":{rnd.Next(5) + 1},\"Date\":\"{date}\"}}";
//            }
//            else
//            {
//                generatedGrades += $",{{\"Subject\":\"{subject}\",\"Message\":\"{messages[rnd.Next(4)]}\",\"Value\":{rnd.Next(5) + 1},\"Date\":\"{date}\"}}";
//            }
//            }
//            else if (month < 6 && day < 10)
//            {
//                date = $"2023-0{month}-0{day}";
//                if (j == 0)
//            {
//                generatedGrades += $"{{\"Subject\":\"{subject}\",\"Message\":\"{messages[rnd.Next(4)]}\",\"Value\":{rnd.Next(5) + 1},\"Date\":\"{date}\"}}";
//            }
//            else
//            {
//                generatedGrades += $",{{\"Subject\":\"{subject}\",\"Message\":\"{messages[rnd.Next(4)]}\",\"Value\":{rnd.Next(5) + 1},\"Date\":\"{date}\"}}";
//            }
//            }
//            else if (month < 6 && day > 10)
//            {
//                date = $"2022-0{month}-{day}";
//                if (j == 0)
//            {
//                generatedGrades += $"{{\"Subject\":\"{subject}\",\"Message\":\"{messages[rnd.Next(4)]}\",\"Value\":{rnd.Next(5) + 1},\"Date\":\"{date}\"}}";
//            }
//            else
//            {
//                generatedGrades += $",{{\"Subject\":\"{subject}\",\"Message\":\"{messages[rnd.Next(4)]}\",\"Value\":{rnd.Next(5) + 1},\"Date\":\"{date}\"}}";
//            }
//            }
//        }
//    }
//    return generatedGrades;
//}