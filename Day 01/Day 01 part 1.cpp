// Day 01.cpp

#include <iostream>
#include <fstream>
#include <stdio.h>
#include <sstream>

using namespace std;


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
        int i_reverse = str.length() - 1;
        string str = text[i];

        
        for (int i_ordered = 0; i_ordered < str.length(); i_ordered++)
        {
            // exit the internal loop
            if (firstDigit >= 0 && lastDigit >= 0) break;

            // if first digit is not found yet and  current char is a digit store it in firstDigit
            if (firstDigit < 0 && isdigit(str[i_ordered])) firstDigit = str[i_ordered] - '0';

            // if last digit is not found yet...
            if (lastDigit < 0) {

                // if the current char is a digit convert the char to int and store it in lastDigit
                if (isdigit(str[i_reverse])) lastDigit = str[i_reverse] - '0';

                // decrement i_reverse to check the prev char
                else i_reverse -= 1;
	    }
	}

        // combine the two digits into a single int
        sums[i] = (firstDigit * 10) + lastDigit;
        // print the sum and the string
        cout << sums[i] << "  <  " << str << endl;
        // add the sum to the final sum
        finalSum += sums[i];
    }
    
    cout << endl << "Total sum: " << finalSum << endl << endl;
    system("pause");
    return 0;
}
