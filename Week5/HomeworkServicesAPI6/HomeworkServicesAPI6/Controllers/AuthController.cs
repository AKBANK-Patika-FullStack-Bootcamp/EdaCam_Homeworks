using DAL.Models;
using Microsoft.AspNetCore.Mvc;


namespace HomeworkServicesAPI6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static Login login = new Login();
        private readonly IConfiguration _configuration;
        DBOperations dBOperation = new DBOperations();
        AuthorityOperations authorityOperations = new AuthorityOperations(); 

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Parametre olarak verilen user bilgileri ile siteme kayıt yapılır.
        /// </summary>
        /// <param name="_user"></param>
        /// <returns>Kayıt işleminin başarı durumunu döner</returns>
        [HttpPost("create")]
        public bool LoginCreate(APIAuthority _user)
        {
            _user.Password= authorityOperations.MD5Hashing(_user.Password); //Girilen parola bilgisi hashlenir.
            dBOperation.CreateLogin(_user);
            return true;
        }

        /// <summary>
        /// Header'dan parametre olarak verilen user bilgileri ile siteme giriş yapılır.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Giriş işleminin başarı durumunu döner</returns>
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromHeader] LoginDto request)
        {
            APIAuthority tokenUser=new APIAuthority();//Bir APIAuthority nesnesi oluşturularak,nesneye girilen bilgiler ile Username ve Password bilgileri verilir.
            tokenUser.Username=request.Username;
            tokenUser.Password= authorityOperations.MD5Hashing(request.Password);

            APIAuthority result=dBOperation.GetLogin(tokenUser);//Oluşturulan nesne ile veritabanında username,password eşleşmesi kontrol edilir.

            if(result != null)
            {
                return Ok(authorityOperations.CreateToken(login,_configuration));
            }
            else
            {
                return Unauthorized("Kullanıcı bulunamadı veya parola hatalı.");
            }
        }
    }
}
