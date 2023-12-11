using DakaDiningBackend.Shared.Models;

namespace DakaDiningBackend.Shared.Mappers;

public class MealPlanMapper
{
    public static string MapToString(MealPlan plan)
    {
        switch (plan)
        {
            case MealPlan.BasicFourteen:
                return "BasicFourteen";
            case MealPlan.PremiumNineteen:
                return "PremiumNineteen";
            case MealPlan.VIPTwoHundred:
                return "VIPTwoHundred";
            default:
                throw new Exception("Could not map MealPlan to a string");
        }
    }

    public static MealPlan MapFromString(string plan)
    {
        switch (plan.ToLower())
        {
            case "basicfourteen":
                return MealPlan.BasicFourteen;
            case "premiumnineteen":
                return MealPlan.PremiumNineteen;
            case "viptwohundred":
                return MealPlan.VIPTwoHundred;
            default:
                throw new Exception("Could not map string to a valid MealPlan value");
        }
    }
}
