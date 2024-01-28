using Bogus;
using DakaDiningBackend.Entities;
using DakaDiningBackend.Shared.Models;

namespace DakaDiningBackend.Test.Data;

public class DbSeeder
{
    public static ICollection<UserEntity> Users = new List<UserEntity>();
    private readonly DakaContext _context;
    private readonly Faker f;


    public DbSeeder(DakaContext context)
    {
        _context = context;
        f = new Faker();
    }

    public void Seed()
    {
        var users = GenerateUsers(10);

        GenerateOffersForUsers(users);

        _context.SaveChanges();
    }

    private List<UserEntity> GenerateUsers(int numUsers)
    {
        var users = new List<UserEntity>();

        foreach (var i in Enumerable.Range(0, numUsers))
        {
            var user = new UserEntity()
            {
                UserId = f.Random.Uuid().ToString(),
                Email = f.Internet.Email(),
                Password = f.Internet.Password(),
                Plan = f.Random.ArrayElement(new[] { "Basic", "VIP" }),
                Role = f.PickRandom<AccountRole>().ToString(),
                FirstName = f.Name.FirstName(),
                LastName = f.Name.LastName(),
                MealSwipes = f.Random.Number(20),
                MealsOffered = f.Random.Number(10),
            };

            users.Add(user);
            DbSeeder.Users.Add(user);
            _context.Users.Add(user);
        }

        return users;
    }

    private void GenerateOffersForUsers(ICollection<UserEntity> users)
    {
        foreach (UserEntity user in users)
        {
            GenerateOffersForUser(user, f.Random.Number(5), f.PickRandom<UserEntity>(users).UserId);
        }
    }

    private void GenerateOffersForUser(UserEntity user, int numOffers, string? purchasedBy)
    {
        foreach (var i in Enumerable.Range(0, numOffers))
        {
            var offer = new OfferEntity()
            {
                Id = f.Random.Uuid().ToString(),
                OfferedById = user.UserId,
                OfferedBy = user,
                Price = (float)f.Finance.Amount(),
                Purchased = false,
                StartTime = f.Date.Soon(refDate: new DateTime(2023, 1, 1)).ToUniversalTime(),
                EndTime = f.Date.Future(refDate: new DateTime(2023, 1, 1)).ToUniversalTime(),
                OfferedAt = f.Date.Past(refDate: new DateTime(2023, 1, 1)).ToUniversalTime(),
            };

            _context.Offers.Add(offer);
        }
    }
}
