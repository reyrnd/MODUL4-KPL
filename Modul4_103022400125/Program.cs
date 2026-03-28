public class KodePaket
{
    public (string[] namaPaket, string[] kodePaket) getKodePaket()
    {
        string[] namaPaket = { "Basic", "Standard", "Premium", "Unlimited", "Gaming", "Streaming", "Family", "Business", "Student", "Traveler" };

        string[] kodePaket = { "P201", "P202", "P203", "P204", "P205", "P206", "P207", "P208", "P209", "P210" };

        return (namaPaket, kodePaket);
    }
}

public class Program
{
    public static void Main()
    {
        KodePaket kodes = new KodePaket();
        var (namaPaket, kodePaket) = kodes.getKodePaket();
        Console.WriteLine("Daftar nama paket dan kode paket");

        for (int i = 0; i < namaPaket.Length; i++)
        {
            Console.WriteLine("Kelurahan " + namaPaket[i] + " : " + kodePaket[i]);
        }


    }
}