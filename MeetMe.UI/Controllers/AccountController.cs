using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using MeetMe.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MeetMe.UI.Controllers;

public class AccountController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;


    public AccountController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult Login()
    {
        return View(new UserLoginModel());
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginModel model)
    {
        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5261/api/Auth/login", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtTokenResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (tokenModel != null)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claimsIdentiy = new ClaimsIdentity(token.Claims, JwtBearerDefaults.AuthenticationScheme);
                    var authProps = new AuthenticationProperties()
                    {
                        ExpiresUtc = tokenModel.ExpireDate,
                        IsPersistent = true
                    };
                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentiy),authProps);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı !");
            }
        }

        return View(model);
    }
}