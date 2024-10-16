using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Clear();
        Console.WriteLine("ConsoleDatenAuswertung");
        Console.WriteLine();
        // Double Array mit nMax Elementen anlegen
        int nMax = 20;
        double[] data = new double[nMax];
        // Array mit Testdaten initialisieren
        ArrayInitialisieren(data);
        // Array auf Konsole ausgeben
        ArrayAusgeben(Console.Out, data);
        // Daten auswerten und Ergebnis in Instanz von Typ Statistik speichern
        Statistik stat = StatistikBerechnen(data);
        // Auswertung auf die Konsole ausgeben
        StatistikAusgeben(Console.Out, stat);
        Value[] data1 = ValueArrGen();
        

        stat = StatistikBerechnen(data1);
        for (int i = 0; i < data1.Length; i++) { Console.Write(data1[i]+""); }
        StatistikAusgeben(Console.Out, stat);
        Console.ReadLine();

    }
    private static Statistik StatistikBerechnen(double[] data)
    {
        Statistik s = new Statistik();
        double max = data[0];
        double min = data[0];
        double summe = 0;

        for (int i = 1; i < data.Length; i++)
        {
            if (data[i] > max)
            {
                max = data[i];
            }
            if (data[i] < min)
            {
                min = data[i];
            }
            summe += data[i];
        }

        s.Maximun = max;
        s.Minimun = min;
        s.Mittelwert = summe/data.Length;
        s.Anzahl=data.Length;
        return s;
    }
    private static Statistik StatistikBerechnen(Value[] data)
    {
        Statistik s =new Statistik();
        double max = data[0].Wert;
        double min = data[0].Wert;
        double summe = data[0].Wert;

        for (int i = 1; i < data.Length; i++)
        {
            if (data[i].Wert > max)
            {
                max = data[i].Wert;
            }
            if (data[i].Wert < min)
            {
                min = data[i].Wert;
            }
            summe += data[i].Wert;
        }
        double MW= summe / data.Length;
        s.Maximun = max;
        s.Minimun = min;
        s.Mittelwert = MW;
        s.Anzahl = data.Length;
        return s;

    }
    private static  Value []  ValueArrGen()
    {   Random rnd = new Random();
        Value [] v = new Value[rnd.Next(1,11)];
        Value v1= new Value();
        for(int i = 0;i< v.Length; i++)
        {
            try {
                v[i] = new Value(i, rnd.Next(1,100));
            }
            catch (Exception ex) { }
        }
        return v;
    } 
    private static void ArrayInitialisieren(double[] data, int randomInit = 123)
    {
        Random r = new Random(randomInit);
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = Math.Round(r.Next(0, 1000) / 10.0, 1);
        }
    }
    
    private static void StatistikAusgeben(TextWriter writer, Statistik stat)
    {
        writer.WriteLine(stat);
    }
    private static void ArrayAusgeben(TextWriter writer, double[] data)
    {
        StringBuilder sb = new StringBuilder();
        foreach (double d in data)
        {
            sb.Append(d);
            sb.Append(' ');
        }
        writer.WriteLine(sb.ToString());
    }
    class Statistik{
   public DateTime Date { get; set; }
        public int Anzahl { get; set; }
        public double Maximun {  get; set; }
        public double Minimun { get; set; }
        public double Mittelwert { get; set; }
        public Statistik() { }
        public Statistik(int anzahl, double maximum, double mittelwert) {
            Anzahl = anzahl;
            Maximun=maximum;
            Minimun=mittelwert;
            Mittelwert=mittelwert;
        }
        public override string ToString() {
            return $"Anzahl= {Anzahl}\n" +
                   $"Maximum= {Maximun.ToString("F2")}\n" +
                   $"Minimum= {Minimun.ToString("F2")}\n" +
                   $"Mittelwert= {Mittelwert.ToString("F2")}\n" +
                   $"";
        }
       
    }
    class Value {
    public int SensorId {  get; set; }
        public double Wert {  get; set; }
        public DateTime Timestamp { get; set; }

        public Value() { }
        public Value(int sensorId, double wert)
        {
            SensorId = sensorId;
            Wert = wert;
            Timestamp = DateTime.Now;
        }
        public override string ToString() {
            return "Seonsor Id= "+SensorId+ " "+ "Wert= "+Wert+" " +  "Time Stamp= "+Timestamp+ "\n";
                   
        }
    }
}