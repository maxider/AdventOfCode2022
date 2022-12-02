var curDir = Directory.GetCurrentDirectory();
var path = $"{curDir}/input.txt";

var read = File.ReadLines(path);

List<Elf> elfs = new List<Elf>();

ElfBuilder builder = new ElfBuilder(elfs);

foreach (var s in read) {
    if (s.Equals(""))
        builder.Build();
    else
        builder.Add(s);
}


var max = elfs.MaxBy(e => e.Total);
elfs.Sort(new ElfComparator());
var range = elfs.GetRange(0, 3);
Console.WriteLine(max.Total);
Console.WriteLine("3 biggest");
Console.WriteLine(range.Sum(e => e.Total));

public class ElfBuilder {
    private List<string> bar = new List<string>();

    private readonly List<Elf> foo;

    public ElfBuilder(List<Elf> elfs) {
        foo = elfs;
    }

    public void Add(string cal) => bar.Add(cal);

    public void Build() {
        foo.Add(new Elf(bar));
        bar.Clear();
    }
}


public struct Elf {
    private readonly List<int> cal;

    public int Total => cal.Sum();

    public Elf(IEnumerable<string> values) {
        cal = values.Select(s => int.Parse(s)).ToList();
    }
}

public class ElfComparator : IComparer<Elf> {
    public int Compare(Elf x, Elf y) {
        return y.Total - x.Total;
    }
}