Dictionary<char, int> prios = new Dictionary<char, int>();

//Seed Prio map.
int counter = 1;
for (char c = 'a'; c <= 'z'; c++) {
    prios[c] = counter++;
}
for (char c = 'A'; c <= 'Z'; c++) {
    prios[c] = counter++;
}

string path = Directory.GetCurrentDirectory() + "/input.txt";
var lines = File.ReadLines(path);

int sum = 0;
foreach (var line in lines) {
    var first = line.Substring(0, line.Length / 2);
    var second = line.Substring(line.Length / 2, line.Length / 2);
    if (first.Length != second.Length) throw new Exception("Failed Equality sanity check");
    foreach (var c in first.ToCharArray()) {
        try {
            var match = second.ToCharArray().First(sc => sc.Equals(c));
            sum += prios[match];
            break;
        }
        catch (Exception e) {
            // ignored
        }
    }
}

Console.WriteLine(sum);

int secondCounter = 0;
int secondSum = 0;
string[] groups = new string[3];
foreach (var line in lines) {
    groups[secondCounter%3] = line;
    secondCounter++;
    if (secondCounter % 3 == 0 && secondCounter > 2) {
        char c = FindCommon(groups);
        secondSum += prios[c];
    }
}

Console.WriteLine(secondSum);

char FindCommon(string[] strings) {
    foreach (char first_c in strings[0].ToCharArray()) {
        foreach (char second_c in strings[1].ToCharArray()) {
            foreach (char third_c in strings[2].ToCharArray()) {
                if (first_c == second_c && second_c == third_c) return first_c;
            }
        }
    }
    return '/';
}