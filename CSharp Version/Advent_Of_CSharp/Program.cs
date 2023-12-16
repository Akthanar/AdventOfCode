using static EasyCode.Output;
using static EasyCode.Input;

using dir = System.IO.Directory;
using System.Data;



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



const bool EXECUTE_FIRST_PART = true;
int sum = 0;



// [ITA] scorri ogni riga del file di input
// [ENG] scroll every line of the input file

foreach (string line in lines) Part_01(line);

Console.WriteLine($"Part 01: {sum}");

sum = 0;

foreach (string line in lines) Part_02(line);

Console.WriteLine($"Part 02: {sum}");
Console.ReadKey();






void Part_01(string line)
{
    // [ITA] trova il primo numero scorrendo la stringa da sinistra a destra,
    // [ITA] convertilo in decina e sommalo al totale
    // [ENG] find the first number scrolling the string from left to right,
    // [ENG] convert it in tens and add it to the total
    for (int i = 0; i < line.Length; i++) if (char.IsNumber(line[i]))
        { sum += int.Parse(line[i].ToString()) * 10; break; }

    // [ITA] trova il secondo numero scorrendo al contrario e aggiungilo al totale
    // [ENG] find the second number scrolling in reverse order and add it to the total
    for (int i = line.Length - 1; i >= 0; i--) if (char.IsNumber(line[i]))
        { sum += int.Parse(line[i].ToString()); break; }
}



void Part_02(string line)
{
    // array of 10 strings with the numbers from 0 to 9 in letters
    string[] numbers = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];


    int first_num = -1;
    int last_num = -1;



    // [ITA] trova il primo numero scorrendo la stringa da sinistra a destra,
    // [ITA] convertilo in decina e sommalo al totale
    // [ENG] find the first number scrolling the string from left to right,
    // [ENG] convert it in tens and add it to the total



    #region FIND_FIRST_NUMBER

    // [ITA] scorri la stringa da sinistra a destra
    // [ENG] loop the string from left to right
    for (int i_ordered = 0; i_ordered < line.Length; i_ordered++)
    {
        // [ITA] se il primo numero è stato trovato esci dal loop
        // [ENG] if first digit is found exit the loop
        if (first_num >= 0) break;

        // [ITA] se il carattere corrente è un numero convertilo in int e salvalo
        // [ENG] if the current char is a digit convert to int and store it
        if (char.IsNumber(line[i_ordered])) first_num = line[i_ordered] - '0';

        // [ITA] scorri l'array dei nomi dei numeri
        // [ENG] loop through the array of number names
        else for (int j = 0; j < 10; j++)
            {
                string number_name = numbers[j];

                // [ITA] se il nome del numero corrente è più lungo della stringa rimanente saltalo
                // [ENG] if the current number name is longer than the remaining string skip it
                if (number_name.Length > line.Length - i_ordered) continue;

                // [ITA] se il primo carattere del nome del numero è diverso dal carattere corrente saltalo
                // [ENG] if first char of the number name is different from the current char skip it
                if (line[i_ordered] != number_name[0]) continue;

                // [ITA] se la sottostringa del nome del numero è diversa dalla sottostringa corrente saltala
                // [ENG] if substring of the number name is different from the current substring skip it
                if (line.Substring(i_ordered, number_name.Length).CompareTo(number_name) != 0) continue;

                // [ITA] salva il numero trovato
                // [ENG] save founded digit
                first_num = j;
                break;
            }
    }
    #endregion


    #region FIND_LAST_NUMBER

    for (int i = 0; i < line.Length; i++)
    {
        if (char.IsNumber(line[i]))
        {
            sum += int.Parse(line[i].ToString()) * 10;
            break;
        }
        else
        {
            last_num = -1;
            
            // [ITA] scorri la stringa al contrario
            // [ENG] loop the string in reverse order
            for (int i_reverse = line.Length; i_reverse > 0; i_reverse--)
            {
                // [ITA] se l'ultimo numero è stato trovato esci dal loop
                // [ENG] if last digit is found exit the loop
                if (last_num >= 0) break;

                // [ITA] se il carattere corrente è un numero convertilo in int e salvalo
                // [ENG] if the current char is a digit convert to int and store it
                if (char.IsNumber(line[i_reverse - 1])) last_num = line[i_reverse - 1] - '0';

                // [ITA] scorri l'array dei nomi dei numeri
                // [ENG] loop through the array of number names
                else for (int j = 0; j < 10; j++)
                    {
                        string number_name = numbers[j];

                        // [ITA] se il nome del numero corrente è più lungo della stringa rimanente saltalo
                        // [ENG] if the current number name is longer than the remaining string skip it
                        if (number_name.Length > i_reverse) continue;

                        // [ITA] trova l'indice di partenza della sottostringa da confrontare
                        // [ENG] find the start index of the substring to compare
                        int start_index = i_reverse - number_name.Length;

                        // [ITA] se il primo carattere del nome del numero è diverso dal carattere corrente saltalo
                        // [ENG] if first char of the number name is different from the current char skip it
                        if (line[start_index] != number_name[0]) continue;

                        // [ITA] estrai la sottostringa da confrontare
                        // [ENG] extract the substring to compare
                        string str_to_compare = line.Substring(start_index, number_name.Length);

                        // [ITA] se la sottostringa del nome del numero è diversa dalla sottostringa corrente saltala
                        // [ENG] if substring of the number name is different from the current substring skip it
                        if (str_to_compare.CompareTo(number_name) != 0) continue;

                        // [ITA] salva il numero trovato
                        // [ENG] save founded digit
                        last_num = j;
                        break;
                    }
            }
        }
    }
    #endregion

    sum += (first_num * 10) + last_num;
}


static int ConvertWordToNumber (string word)
{
    Dictionary<string, int> wordToNumberMap = new() {
        {"zero", 0}, {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4},
        {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}
    };


    if (wordToNumberMap.TryGetValue(word.ToLower(), out int result)) return result;

    // Handle the case where the input word is not a valid number in words.
    else throw new ArgumentException("Invalid number in words.");
}