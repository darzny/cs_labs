public enum TariffPlan
{
    Standard,
    After10MinutesHalfPrice,
    PayLessFor5Minutes
}

public enum CallType
{
    City,
    Mobile
}

public interface ITariffPlan
{
    decimal CalculateCost(int minutes);
}

public static class CallRates
{
    public const decimal CityCallRate = 5;
    public const decimal MobileCallRate = 1;
}

public class StandardBilling : ITariffPlan
{
    private CallType callType;

    public StandardBilling(CallType callType)
    {
        this.callType = callType;
    }

    public decimal CalculateCost(int minutes)
    {
        decimal costPerMinute = (callType == CallType.City) ? CallRates.CityCallRate : CallRates.MobileCallRate;
        return minutes * costPerMinute;
    }
}

public class After10MinutesHalfPriceBilling : ITariffPlan
{
    private CallType callType;

    public After10MinutesHalfPriceBilling(CallType callType)
    {
        this.callType = callType;
    }

    public decimal CalculateCost(int minutes)
    {
        // Тут должен быть сложный расчет, но мне лень
        decimal costPerMinute = (callType == CallType.City) ? CallRates.CityCallRate : CallRates.MobileCallRate;
        return minutes * costPerMinute;
    }
}

public class PayLessFor5MinutesBilling : ITariffPlan
{
    private CallType callType;

    public PayLessFor5MinutesBilling(CallType callType)
    {
        this.callType = callType;
    }

    public decimal CalculateCost(int minutes)
    {
        // Тут должен быть сложный расчет, но мне лень
        decimal costPerMinute = (callType == CallType.City) ? CallRates.CityCallRate : CallRates.MobileCallRate;
        return minutes * costPerMinute;
    }
}

public class Customer
{
    public string name { get; set; }
    public decimal balance { get; private set; }

    private ITariffPlan tariffPlan;

    public Customer(ITariffPlan tariffPlan)
    {
        this.tariffPlan = tariffPlan ?? throw new ArgumentNullException("tariffPlan");
    }

    public void RecordPayment(decimal amount)
    {
        balance += amount;
    }

    public void RecordCall(int minutes)
    {
        decimal cost = tariffPlan.CalculateCost(minutes);
        balance -= cost;
    }

    public void ChangeTariffPlan(ITariffPlan newTariff)
    {
        this.tariffPlan = newTariff;
    }
}
