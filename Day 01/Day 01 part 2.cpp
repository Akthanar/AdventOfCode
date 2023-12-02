// Day 01.cpp

#include <iostream>
#include <fstream>
#include <stdio.h>
#include <sstream>

using namespace std;


// array of 10 strings with the numbers from 0 to 9 in letters
string numbers[10] = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };



int main()
{
    const int amountOfLines = 1000;

    cout << "Advent of Code 2023 - Day 01\n\n";
    cout << "Paste here the " << amountOfLines << " lines of calibrations values: \n\n";

    string* text = new string[amountOfLines];

    // copy and paste the full text here
    for (int i = 0; i < amountOfLines; i++) getline(cin, text[i]);
    cout << endl << endl;

    // create an array of ints to store the sums
    int* sums = new int[amountOfLines];
    // initialize the final sum
    int finalSum = 0;

    // loop through the lines
    for (int i = 0; i < amountOfLines; i++)
    {
        int firstDigit = -1, lastDigit = -1;
        string str = text[i];

        // #####################
        // # FIND FIRST NUMBER #
        // #####################

        // loop through the string in order
        for (int i_ordered = 0; i_ordered < str.length(); i_ordered++) {

            // if first digit is found exit the loop
            if (firstDigit >= 0) break;

            // if the current char is a digit convert to int and store it
            if (isdigit(str[i_ordered])) firstDigit = str[i_ordered] - '0';
            
            // loop through the array of number names
            else for (int j = 0; j < 10; j++) {

		// store name to compare
                string number_name = numbers[j];

                // if the current number name is longer than the remaining string skip it
                if (number_name.length() > str.length() - i_ordered) continue;

                // if first char of the number name is different from the current char skip it
                if (str[i_ordered] != number_name[0]) continue;

                // if substring of the number name is different from the current substring skip it
                if (str.compare(i_ordered, number_name.length(), number_name) != 0) continue;
                
                // store founded digit
                firstDigit = j;
                break;
            }
        }

        // ####################
        // # FIND LAST NUMBER #
        // ####################
        
        // loop through the string in reverse order
        for (int i_reverse = (int)str.length(); i_reverse > 0; i_reverse--) {

            // if last digit is found exit the loop
            if (lastDigit >= 0) break;

            // if the current char is a digit convert to int and store it
            if (isdigit(str[i_reverse - 1])) lastDigit = str[i_reverse -1] - '0';
            
            // loop through the array of number names
            else for (int j = 0; j < 10; j++)
            {
                string number_name = numbers[j];

                // if the current number name is longer than the remaining string skip it
                if (number_name.length() > i_reverse) continue;

                // find the start index of the substring to compare
                int start_index = i_reverse - number_name.length();

                // if first char of the number name is different from the current char skip it
                if (str[start_index] != number_name[0]) continue;

                // extract the substring to compare
                string str_to_compare = str.substr(start_index, number_name.length());
                
                // if substring of the number name is different from the current substring skip it
                if (str_to_compare.compare(number_name) != 0) continue;

                // save founded digit
                lastDigit = j;
                break;
            }
	}

        // combine the two digits into a single int
        sums[i] = (firstDigit * 10) + lastDigit;
        // print the sum and the string
        cout << sums[i] << "  <  " << str << endl << endl;
        // add the sum to the final sum
        finalSum += sums[i];
    }
    
    cout << endl << "Total sum: " << finalSum << endl << endl;
    system("pause");
    return 0;
}
