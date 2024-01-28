using Bogus;
using DakaDiningBackend.MealOffers.Contracts.Requests;
using DakaDiningBackend.MealOffers.Endpoints;
using DakaDiningBackend.Shared.Models;
using FastEndpoints.Security;
using DakaDiningBackend.Entities;
using DakaDiningBackend.Test.Data;
using YamlDotNet.Core.Tokens;
using System.Net.Http.Json;

namespace DakaDiningBackend.Test.MealOffers;

public class MealOffersIntegrationTests : IClassFixture<ApiWebFactory>
{
    private readonly ApiWebFactory _factory;
    private readonly HttpClient _client;

    private readonly Faker<CreateOfferRequest> _createOfferGenerator = new Faker<CreateOfferRequest>()
        .RuleFor(o => o.Price, f => (float)f.Finance.Amount())
        .RuleFor(o => o.Meals, f => f.Random.Number(1, 2));

    public MealOffersIntegrationTests(ApiWebFactory factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task Test_ShouldCreateOfferGivenValidRequestBody()
    {
        // Arrange
        // Generate a realistic looking user request with `Bogus`
        var offerRequest = _createOfferGenerator.Generate();

        _client.DefaultRequestHeaders.Authorization = new("Bearer", CreateFakeJwtToken());

        // Act
        // Executing a `POST` call to the `CreateUserEndpoint`, note that we use the extension method `POSTAsync` for this.
        // `POSTAsync` comes from FastEndpoints and allows to easily call the endpoint by targeting the `Endpoint` class
        // in one of the generic parameters. It also returns the `HttpResponseMessage`
        // and the actual JSON return type `CreateUserResponse`
        var response = await _client
            .POSTAsync<CreateOfferEndpoint, CreateOfferRequest>(offerRequest);

        var content = await response.Content.ReadAsStringAsync();

        // Assert
        response.Should().NotBeNull();
        response!.StatusCode.Should().Be(HttpStatusCode.Created);
        content.Should().BeNullOrEmpty();
    }

    [Fact]
    public async Task Test_ShouldReturn404GivenInvalidRequestBody()
    {
        var offerRequest = _createOfferGenerator.Generate();
        offerRequest.Meals = -1;

        _client.DefaultRequestHeaders.Authorization = new("Bearer", CreateFakeJwtToken());

        var response = await _client.POSTAsync<CreateOfferEndpoint, CreateOfferRequest>(offerRequest);

        response.Should().NotBeNull();
        response!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Test_ShouldReturn401GivenNoAuthToken()
    {
        var offerRequest = _createOfferGenerator.Generate();

        var response = await _client.POSTAsync<CreateOfferEndpoint, CreateOfferRequest>(offerRequest);

        response.Should().NotBeNull();
        response!.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Test_ShouldReturn403GivenBadAuthToken()
    {
        var offerRequest = _createOfferGenerator.Generate();

        string token = JWTBearer.CreateToken(
                    signingKey: "THIS_IS_A_SECRET",
                    expireAt: DateTime.UtcNow.AddDays(1),
                    privileges: u =>
                    {
                        u.Permissions.AddRange(new[] { "OfferSwipes", "RequestSwipes", "FillRequests", "PurchaseOffers" });
                        u.Claims.Add(new("Email", new Faker().Internet.Email()));
                        u["UserId"] = new Faker().PickRandom<UserEntity>(DbSeeder.Users).UserId;
                    }
                );

        _client.DefaultRequestHeaders.Authorization = new("Bearer", token);

        var response = await _client.POSTAsync<CreateOfferEndpoint, CreateOfferRequest>(offerRequest);

        response.Should().NotBeNull();
        response!.StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }

    private string CreateFakeJwtToken()
    {
        return JWTBearer.CreateToken(
                    signingKey: "THIS_IS_A_SECRET",
                    expireAt: DateTime.UtcNow.AddDays(1),
                    privileges: u =>
                    {
                        u.Roles.Add(AccountRole.Basic.ToString());
                        u.Permissions.AddRange(new[] { "OfferSwipes", "RequestSwipes", "FillRequests", "PurchaseOffers" });
                        u.Claims.Add(new("Email", new Faker().Internet.Email()));
                        u["UserId"] = new Faker().PickRandom<UserEntity>(DbSeeder.Users).UserId;
                    }
                );
    }
}
