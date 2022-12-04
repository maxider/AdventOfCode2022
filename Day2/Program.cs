string path = Directory.GetCurrentDirectory() + "/input.txt";
var lines = File.ReadLines(path);
int total = 0;
foreach (string s in lines) {
    total += Solve(s.First(), s.Last());
}
Console.WriteLine($"First: {total}");

total = 0;
foreach (string s in lines) {
    total += Solve(s.First(), SolveB(s.First(), s.Last()));
}
Console.WriteLine($"Second: {total}");


char SolveB(char other, char self) {
    switch (self) {
        case 'X':
            switch (other) {
                case 'A':
                    return 'Z';
                case 'B':
                    return 'X';
                case 'C':
                    return 'Y';
            }
            break;
        case 'Y':
            switch (other) {
                case 'A':
                    return 'X';
                case 'B':
                    return 'Y';
                case 'C':
                    return 'Z';
            }
            break;
        case 'Z':
            switch (other) {
                case 'A':
                    return 'Y';
                case 'B':
                    return 'Z';
                case 'C':
                    return 'X';
            }
            break;
    }
    return 'K';
}

int Solve(char other, char self) {
    switch (self) {
        case 'X':
            switch (other) {
                case 'A':
                    return 1 + 3;
                case 'B':
                    return 1 + 0;
                case 'C':
                    return 1 + 6;
            }
            break;
        case 'Y':
            switch (other) {
                case 'A':
                    return 2 + 6;
                case 'B':
                    return 2 + 3;
                case 'C':
                    return 2 + 0;
            }
            break;
        case 'Z':
            switch (other) {
                case 'A':
                    return 3 + 0;
                case 'B':
                    return 3 + 6;
                case 'C':
                    return 3 + 3;
            }
            break;
    }
    return 0;
}