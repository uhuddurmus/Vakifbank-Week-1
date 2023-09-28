using cohorts.patika._1.Attributes;
using cohorts.patika._1.DataAccess.Abstract;
using cohorts.patika._1.Entities;
using cohorts.patika._1.Models;
using Microsoft.AspNetCore.Mvc;

namespace cohorts.patika._1.Controllers
{
    // Bu controller, "/api/Login" yolunu kullanır.
    [Route("api/Login")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        // UserController sınıfının yapıcı metodu.
        // IUserService ve ILogger bağımlılıkları enjekte edilir.
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // HTTP POST isteğine yanıt veren metot.
        [HttpPost]
        public ActionResult<bool> Login([FromBody] LoginRequestModel model)
        {
            // ModelState.IsValid, modelin geçerli (valid) olup olmadığını kontrol eder.
            if (ModelState.IsValid)
            {
                // _userService.Login metodu kullanıcı girişini gerçekleştirir ve sonucu döndürür.
                return Ok(_userService.Login(model)); // Başarılı yanıt (HTTP 200) döner.
            }

            // Eğer model geçerli değilse, BadRequest (HTTP 400) yanıtı döndürülür.
            return BadRequest();
        }
    }
}
