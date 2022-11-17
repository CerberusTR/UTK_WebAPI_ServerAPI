using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UTK_WebAPI_ServerAPI_UI.Models;
using WepAPI_DB;

namespace UTK_WebAPI_ServerAPI_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinsiyetController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<EnumItem>> GetEnumList()
        {
            List<EnumItem> list = new List<EnumItem>();
            string[] cinsiyet = Enum.GetNames<Cinsiyet>();

            Cinsiyet[] değerler = Enum.GetValues<Cinsiyet>();
            for (int i = 0; i < cinsiyet.Length; i++)
            {
                list.Add(new EnumItem()
                {
                    Name = cinsiyet[i],
                    Value = (int)değerler[i]

                });
            }
            return list;


        }
    }
}
