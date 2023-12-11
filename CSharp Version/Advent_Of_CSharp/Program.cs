using static EasyCode.Output;
using static EasyCode.Input;

using dir = System.IO.Directory;



void PrintError01()
{
    Color(ConsoleColor.Red, ConsoleColor.Black);
    Log("Error 01: file not found. \n\nPress any key to exit.");
    Console.ReadKey(); Environment.Exit(0);
}



// [ITA] finchè non trovi il file di input risali di un livello ma se esci da AdventOfCode stampa un errore
// [ENG] until you find the input file go up one level but if you exit from AdventOfCode print an error
while (!File.Exists("input.txt")) if (dir.Exists("AdventOfCode")) PrintError01(); else dir.SetCurrentDirectory("../");

// [ITA] salva in un array le righe di testo presenti nel file trovato al percorso attuale
// [ENG] save in an array the text lines present in the file found at the current path
string[] lines = File.ReadAllLines(dir.GetCurrentDirectory() + "\\input.txt");






// [ITA] scorri ogni riga del file di input
// [ENG] scroll every line of the input file
foreach (string line in lines)
{
    
}


Console.WriteLine("\n\nPress any key to exit.");
Console.ReadKey();