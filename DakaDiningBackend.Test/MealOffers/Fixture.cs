using DakaDiningBackend.MealOffers.Services;
using DakaDiningBackend.Test.MealOffers.Mocks;
using Microsoft.Extensions.DependencyInjection;

namespace DakaDiningBackend.Test.MealOffers;

public class Fixture : TestFixture<Program>
{
    public Fixture(IMessageSink s) : base(s) { }

    protected override async Task SetupAsync()
    {
        await base.SetupAsync();
    }

    protected override async Task TearDownAsync()
    {
        await base.TearDownAsync();
    }

    protected override void ConfigureServices(IServiceCollection s)
    {
        s.AddScoped<IOffersService, MockOffersService>();
    }
}
