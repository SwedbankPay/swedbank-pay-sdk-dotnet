using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;

using Sample.AspNetCore.Models.ViewModels;

using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest.RemoveToken;

namespace Sample.AspNetCore.Controllers;

public class TokensController : Controller
{
    private readonly ISwedbankPayClient _swedbankPayClient;
    private readonly ILogger<TokensController> _logger;

    public TokensController(ISwedbankPayClient swedbankPayClient,
        ILogger<TokensController> logger)
    {
        _swedbankPayClient = swedbankPayClient;
        _logger = logger;
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
            var tokenResponse = await _swedbankPayClient.PaymentOrders.GetOwnedTokens("AB1234");
            viewModel.Id = tokenResponse?.Id;
            viewModel.PayerReference = tokenResponse?.PayerReference;
            viewModel.Tokens = tokenResponse?.Tokens;
            viewModel.OperationList = tokenResponse?.Operations;
        }
        catch (Exception)
        {
            _logger.LogError("No existing tokens for user");
        }

        return viewModel;
    }
}