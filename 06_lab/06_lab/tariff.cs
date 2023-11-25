public enum CallType
{
    Mobile,
    City
}

public class CallSettings
{
    public double CityCallRate { get; set; }
    public double MobileCallRate { get; set; }
   
}

public class DiscountSettings
{
    public double DiscountRateBefore { get; set; }
    public double DiscountRateAfter { get; set; }

    public int FreeMinutesEveryNthCityCall { get; set; }
    public int DiscountAfterMinutes { get; set; }
    public double DiscountRateAfterFreeCityCall { get; set; }
}

public class TariffPlan
{
    public string Name { get; set; }
    public CallSettings CallSettings { get; set; }
    public DiscountSettings DiscountSettings { get; set; }

    public TariffPlan(string name, CallSettings callSettings, DiscountSettings discountSettings)
    {
        Name = name;
        CallSettings = callSettings;
        DiscountSettings = discountSettings;
    }
}

public class Customer
{
    private string name;
    private double balance;
    private TariffPlan currentTariff;

    public Customer(string name, double initialBalance, TariffPlan initialTariff)
    {
        this.name = name;
        this.balance = initialBalance;
        this.currentTariff = initialTariff;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Balance
    {
        get { return balance; }
    }

    public void RecordPayment(double amount)
    {
        balance += amount;
    }

    public void RecordCall(CallType callType, int minutes)
    {
        double callCost = CalculateCallCost(callType, minutes);
        balance -= callCost;
    }

    private double CalculateCallCost(CallType callType, int minutes)
    {
        double callCost = 0;

        switch (callType)
        {
            case CallType.City:
                callCost = CalculateCityCallCost(minutes);
                break;
            case CallType.Mobile:
                callCost = CalculateMobileCallCost(minutes);
                break;
        }

        return callCost;
    }

    private double CalculateCityCallCost(int minutes)
    {
        int freeMinutes = 0;

        if (minutes > 0 && currentTariff.DiscountSettings.FreeMinutesEveryNthCityCall > 0)
        {
            freeMinutes = minutes / currentTariff.DiscountSettings.FreeMinutesEveryNthCityCall;
        }

        int billableMinutes = minutes - freeMinutes;

        double discountRate = 1.0;

        if (minutes > currentTariff.DiscountSettings.FreeMinutesEveryNthCityCall) {
            discountRate = currentTariff.DiscountSettings.DiscountRateAfterFreeCityCall;
        };

        return billableMinutes * currentTariff.CallSettings.CityCallRate * discountRate;
    }

    private double CalculateMobileCallCost(int minutes)
    {
        double discountRate = 1.0;

        if (currentTariff.DiscountSettings.DiscountAfterMinutes > 0)
        {
            discountRate = (minutes <= currentTariff.DiscountSettings.DiscountAfterMinutes)
                ? currentTariff.DiscountSettings.DiscountRateBefore
                : currentTariff.DiscountSettings.DiscountRateAfter;
            
        }

        return minutes * currentTariff.CallSettings.MobileCallRate * discountRate;

    }

    public void ChangeTariffPlan(TariffPlan newTariff)
    {
        currentTariff = newTariff;
    }
}

class Program
{
    static void Main(string[] args)
    {

        CallSettings baseCallSettings = new CallSettings { CityCallRate = 5.0, MobileCallRate = 1.0};

        TariffPlan tariff1 = new TariffPlan(
            "Поминутный",
            baseCallSettings,
            new DiscountSettings {
                FreeMinutesEveryNthCityCall = 0,
                DiscountRateBefore = 1.0,
                DiscountRateAfter = 1.0,
                DiscountAfterMinutes = 0,
                DiscountRateAfterFreeCityCall = 1.0
            }
        );

        TariffPlan tariff2 = new TariffPlan(
            "После10МинутВ2РазаДешевле",
            baseCallSettings,
            new DiscountSettings {
                FreeMinutesEveryNthCityCall = 10,
                DiscountRateBefore = 1.0,
                DiscountRateAfter = 0.5,
                DiscountAfterMinutes = 0,
                DiscountRateAfterFreeCityCall = 1.0
            }
        );

        TariffPlan tariff3 = new TariffPlan(
            "ПлатиМеньшеДо5Минут",
            baseCallSettings,
            new DiscountSettings {
                FreeMinutesEveryNthCityCall = 0,
                DiscountRateBefore = 0.5,
                DiscountRateAfter = 2.0,
                DiscountAfterMinutes = 5,
                DiscountRateAfterFreeCityCall = 0.5
            }
        );

        Customer customer = new Customer("Иван Иванов", 100.0, tariff3);

        customer.RecordCall(CallType.City, 15);
        customer.RecordCall(CallType.Mobile, 7);

        Console.WriteLine($"Customer {customer.Name}, Balance: {customer.Balance}");
    }
}
