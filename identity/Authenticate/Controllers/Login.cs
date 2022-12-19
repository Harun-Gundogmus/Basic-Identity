using Authenticate.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authenticate.Controllers
{
    public class Login : Controller
    {
        Context c = new Context();


        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> GirisYap(Admin p) //Giriş Yap sayfamın ekrana gelmesinin ardından post işlemini gerçekleştirecek yapı.
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == p.Kullanici && x.Sifre == p.Sifre);//Textbox'ta yazılan bilgileri cookie'yle eşliyorum.
            if(bilgiler != null) //eğer textler boş gelmezse 
            {
                var claims = new List<Claim> //Claim yapımı oluşturuyorum
                {
                    new Claim (ClaimTypes.Name, p.Kullanici)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");//identity tanımlamamı yapıp loginden aldırıyorum.
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);//buradaki principal benim sorgu alanım ve bu alanda ben loginden şeyleri sorguluyorum.
                await HttpContext.SignInAsync(principal);//await kullanıp işlem sıramı düzenledim.
                return RedirectToAction("Index", "Personel");//Eğer pri. gelen veri doğruysa yönlendirme yapsın. 
            }
            return View();
        }





        public IActionResult Index()
        {
            return View();
        }

    }
}
