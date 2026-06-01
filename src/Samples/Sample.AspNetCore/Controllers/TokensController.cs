using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Sample.AspNetCore.Models;
using Sample.AspNetCore.Models.ViewModels;

using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest.RemoveToken;

namespace Sample.AspNetCore.Controllers;

public class TokensController : Controller
{
    private readonly ISwedbankPayClientFactory _swedbankPayClientFactory;
    private readonly ILogger<TokensController> _logger;
    private readonly Cart _cart;
    private readonly PayerReference _payerReference;
    private readonly Merchant _merchantService;

    public TokensController(ISwedbankPayClientFactory swedbankPayClientFactory,
        ILogger<TokensController> logger,
        Cart cart,
        PayerReference payerReference,
        Merchant merchantService)
    {
        _swedbankPayClientFactory = swedbankPayClientFactory;
        _logger = logger;
        _cart = cart;
        _payerReference = payerReference;
        _merchantService = merchantService;
    }


    public async Task<IActionResult> Index()
    {
        var viewModel = await GetViewModel();

        return View("Index", viewModel);
    }

    public async Task<IActionResult> RemoveAll()
    {
        var viewModel = await GetViewModel();

        if (viewModel.OperationList?.DeleteAllTokens != null)
        {
            var resp = await viewModel.OperationList?.DeleteAllTokens(
                new RemoveTokenRequest(TokenState.Deleted, "Deleted"))!;

            TempData["ResponseMessage"] = $"DELETED: {JsonSerializer.Serialize(resp)}";
        }

        return View("Index", viewModel);
    }

    public async Task<IActionResult> DeleteToken(string tokenId)
    {
        var viewModel = await GetViewModel();

        var token = viewModel.Tokens.FirstOrDefault(x => x.Token == tokenId);
        if (token?.Operations?.DeleteTokens != null)
        {
            var resp = await token.Operations?.DeleteTokens(
                new RemoveTokenRequest(TokenState.Deleted, "Deleted"))!;

            TempData["ResponseMessage"] = $"DELETED: {JsonSerializer.Serialize(resp)}";
        }
        
        return View("Index", viewModel);
    }

    public async Task<IActionResult> DeleteRecurringToken(string tokenId)
    {
        var viewModel = await GetViewModel();

        var token = viewModel.Tokens.FirstOrDefault(x => x.Token == tokenId);
        if (token?.Operations?.DeleteRecurringTokens != null)
        {
            var resp = await token.Operations?.DeleteRecurringTokens(
                new RemoveTokenRequest(TokenState.Deleted, "Deleted"))!;

            TempData["ResponseMessage"] = $"DELETED: {JsonSerializer.Serialize(resp)}";
        }

        return View("Index", viewModel);
    }

    public async Task<IActionResult> DeleteUnscheduledToken(string tokenId)
    {
        var viewModel = await GetViewModel();

        var token = viewModel.Tokens.FirstOrDefault(x => x.Token == tokenId);
        if (token?.Operations?.DeleteUnscheduledTokens != null)
        {
            var resp = await token.Operations?.DeleteUnscheduledTokens(
                new RemoveTokenRequest(TokenState.Deleted, "Deleted"))!;

            TempData["ResponseMessage"] = $"DELETED: {JsonSerializer.Serialize(resp)}";
        }

        return View("Index", viewModel);
    }
    
    private async Task<TokenViewModel> GetViewModel()
    {
        var viewModel = new TokenViewModel();

        try
        {
            var swedbankPayClient = _swedbankPayClientFactory.CreateClient(_merchantService.Token);
            var tokenResponse = await swedbankPayClient.PaymentOrders.GetOwnedTokens(_payerReference.Id);
            viewModel.Id = tokenResponse?.Id;
            viewModel.PayerReference = tokenResponse?.PayerReference;
            if (tokenResponse?.Tokens != null)
            {
                viewModel.Tokens = tokenResponse.Tokens;
            }
            if (tokenResponse?.Operations != null)
            {
                viewModel.OperationList = tokenResponse.Operations;
            }
            viewModel.Cart = _cart;
        }
        catch (Exception ex)
        {
            // GetOwnedTokens throws when the payer owns no tokens yet (e.g. the token from a
            // just-completed payment has not propagated). Log the real exception so CI can tell
            // a benign "no tokens" 404 apart from auth/timeout failures instead of masking it.
            _logger.LogError(ex, "Could not fetch tokens for payer {PayerReference}", _payerReference.Id);
        }

        return viewModel;
    }
}