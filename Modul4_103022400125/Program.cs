public class KodePaket
{
    public enum NamaPaket { Basic, Standard, Premium, Unlimited, Gaming, Streaming, Family, Business, Student, Traveler };
    public static string getKodePaket(NamaPaket paket)
    {
        string[] kodePaket = { "P201", "P202", "P203", "P204", "P205", "P206", "P207", "P208", "P209", "P210" };

        return kodePaket[(int)paket];
    }
}
//public class KodePaket
//{
//    public (string[] namaPaket, string[] kodePaket) getKodePaket()
//    {
//        string[] namaPaket = { "Basic", "Standard", "Premium", "Unlimited", "Gaming", "Streaming", "Family", "Business", "Student", "Traveler" };

//        string[] kodePaket = { "P201", "P202", "P203", "P204", "P205", "P206", "P207", "P208", "P209", "P210" };

//        return (namaPaket, kodePaket);
//    }
//}


public class MesinKopi
{
    public enum MesinKopiState { OFF, STANDBY, BREWING, MAINTENANCE };
    public enum Trigger { POWER_ON, POWER_OFF, START_BREW, FINISH_BREW, START_MAINTENANCE, FINISH_MAINTENANCE }

    public MesinKopiState currentState = MesinKopiState.OFF;

    public void TriggerEvent(Trigger trigger)
    {
        switch (currentState)
        {
            case MesinKopiState.OFF:
                if (trigger == Trigger.POWER_ON)
                {
                    currentState = MesinKopiState.STANDBY;
                    Console.WriteLine("Mesin Off berubah menjadi Standby.");
                } else
                {
                    Console.WriteLine("Perubahan state tidak valid.");
                }
                break;
            case MesinKopiState.STANDBY:
                if (trigger == Trigger.POWER_OFF)
                {
                    currentState = MesinKopiState.OFF;
                    Console.WriteLine("Mesin Standby berubah menjadi Off.");
                }
                else if (trigger == Trigger.START_BREW)
                {
                    currentState = MesinKopiState.BREWING;
                    Console.WriteLine("Mesin Standby berubah menjadi Brewing.");
                }
                else if (trigger == Trigger.START_MAINTENANCE)
                {
                    currentState = MesinKopiState.MAINTENANCE;
                    Console.WriteLine("Mesin Standby berubah menjadi Maintenance.");
                } else
                {
                    Console.WriteLine("Perubahan state tidak valid.");
                }
                break;
            case MesinKopiState.BREWING:
                if (trigger == Trigger.FINISH_BREW)
                {
                    currentState = MesinKopiState.STANDBY;
                    Console.WriteLine("Mesin Brewing berubah menjadi Standby.");
                } else
                {
                    Console.WriteLine("Perubahan state tidak valid.");
                }
                break;
            case MesinKopiState.MAINTENANCE:
                if (trigger == Trigger.FINISH_MAINTENANCE)
                {
                        currentState = MesinKopiState.STANDBY;
                        Console.WriteLine("Mesin Maintenance berubah menjadi Standby.");
                }
                else
                {
                    Console.WriteLine("Perubahan state tidak valid.");
                }
                break;
        }
    }



}

public class Program
{
    public static void Main()
    {
        KodePaket kodes = new KodePaket();
        
        Console.WriteLine("Daftar nama paket dan kode paket");
        foreach (KodePaket.NamaPaket p in Enum.GetValues(typeof(KodePaket.NamaPaket)))
        {
            Console.WriteLine("Nama Paket: " + p + " - Kode Paket: " + KodePaket.getKodePaket(p));
        }

        Console.WriteLine("\nSimulasi Mesin Kopi:");
        MesinKopi mesin = new MesinKopi();
        mesin.TriggerEvent(MesinKopi.Trigger.POWER_ON);
        mesin.TriggerEvent(MesinKopi.Trigger.START_BREW);
        mesin.TriggerEvent(MesinKopi.Trigger.FINISH_BREW);
        mesin.TriggerEvent(MesinKopi.Trigger.START_MAINTENANCE);
        mesin.TriggerEvent(MesinKopi.Trigger.FINISH_MAINTENANCE);
        mesin.TriggerEvent(MesinKopi.Trigger.POWER_OFF);
        mesin.TriggerEvent(MesinKopi.Trigger.START_BREW);
    }
}