namespace CA240523
{
    internal class Kategoria
    {
        public string Nev { get; set; }
        public int Tulelok { get; set; }
        public int Eltuntek { get; set; }
        public int Utasok => Tulelok + Eltuntek;

        public override string ToString()
        {
            return 
                $"kategória neve: {Nev}\n" +
                $"túlélők száma:  {Tulelok} fő\n" +
                $"eltűntek száma: {Eltuntek} fő";
        }

        public Kategoria(string sor)
        {
            string[] v = sor.Split(';');

            Nev = v[0];
            Tulelok = int.Parse(v[1]);
            Eltuntek = int.Parse(v[2]);
        }
    }
}
