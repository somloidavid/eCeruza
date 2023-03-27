using eCeruza.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

List<Teacher> teachers = JsonSerializer.Deserialize<Teacher[]>(File.ReadAllText("Source/teachers.json")).ToList();
string[] days = { "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek" };
string[] subjects = { "Történelem", "Matematika", "Fizika", "Irodalom", "Nyelvtan", "Programozás", "IKT Projektmunka" };
string[] classes = { "9A", "9B", "9C", "10A", "10B", "10C", "11A", "11B", "11C", "12A", "12B", "12C", };
string[] rooms = { "13", "14", "15", "101", "102", "103", "104", "105", "106", "107", "108", "109", "110", "111", "112", "113", "114", "115", "116", "117", "118", "201", "202", "203", "204", "205", "206", "207", "208", "209", "210", "211", "212", "213", "214", "215" };
List<string> rows = new List<string>();

foreach(string c in classes)
{
    foreach(string d in days)
    {
        for (int i = 1; i <= 6; i++)
        {
            foreach (var s in teachers)
            {
                rows.Add(s.ToString());
            }
            Random random = new Random();
            string row = "{";
            row += $"\"Nap\":\"{d}\"";
            row += $"\"Ora\":\"{i}\"";
            //row += $"\"
            rows.Add(row);
        }
    }
}