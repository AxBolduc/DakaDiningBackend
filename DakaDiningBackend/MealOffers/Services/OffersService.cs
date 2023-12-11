using DakaDiningBackend.Entities;
using DakaDiningBackend.MealOffers.Exceptions;

namespace DakaDiningBackend.MealOffers.Services;

public class OffersService : IOffersService
{
    private readonly DakaContext _context;
    private readonly ILogger _logger;

    public OffersService(DakaContext context, ILogger<OffersService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public ICollection<OfferEntity> GetAvailableOffers()
    {
        return _context.Offers.Where(o => !o.Purchased).ToList();
    }

    public void CreateOffer(OfferEntity offerEntity)
    {
        _context.Offers.Add(offerEntity);
        _context.SaveChanges();
    }

    public bool DeleteOffer(string offerId)
    {
        var existingOffer = _context.Offers.SingleOrDefault(o => o.Id == offerId);

        if (existingOffer == null) return false;

        _context.Offers.Remove(existingOffer);
        _context.SaveChanges();
        return true;
    }

    public OfferEntity? GetOfferById(string offerId)
    {
        return _context.Offers.SingleOrDefault(o => o.Id == offerId);
    }

    /// <summary>
    /// Gets an offer and marks it as purchased by the given purchaser id
    /// </summary>
    /// <param name="offerId">OfferId of the purchased Offer</param>
    /// <param name="userId">UsedId of the purchasing user</param>
    /// <returns>The updated (purchased) OfferEntity </returns>
    /// <exception cref="OfferNotFoundException">When an offer with the given OfferId does not exist</exception>
    /// <exception cref="OfferAlreadyPurchasedException">When the offer with the given OfferId has already been purchased</exception>
    public OfferEntity PurchaseOfferById(string offerId, string userId)
    {
        var existingOffer = _context.Offers.Single(o => o.Id == offerId);

        if (existingOffer == null)
        {
            var errMsg = $"An offer with ID: {offerId} does not exist";
            _logger.LogError(errMsg);
            throw new OfferNotFoundException(errMsg);
        }

        // Check if offer is already purchased
        if (existingOffer.Purchased)
        {
            var errMsg = $"The offer with ID: {offerId} has already been purchased";
            _logger.LogError(errMsg);
            throw new OfferAlreadyPurchasedException(errMsg);
        }

        existingOffer.Purchased = true;
        existingOffer.PurchasedById = userId;
        existingOffer.PurchasedAt = DateTime.Now;

        _context.Offers.Update(existingOffer);
        _context.SaveChanges();
        return existingOffer;
    }
}
