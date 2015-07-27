using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubGorizont.org.Controllers
{
    public class MyBaseController : Controller
    {
        //
        // GET: /MyBase/

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string lang = null;
            HttpCookie langCookies = Request.Cookies["culture"];

            if(langCookies!=null)
            {
                lang = langCookies.Value;
            }
            else
            {
                var UserLanguage = Request.UserLanguages;
                var UserLang = UserLanguage != null ? UserLanguage[0] : null;
                if ( UserLang!="")
                {
                    lang = UserLang;
                }
                else
                {
                    lang = SiteLanguages.GetDefaultLanguage();
                }
            }
            
            new SiteLanguages().SetLanguage(lang);

            return base.BeginExecuteCore(callback, state);
        }

    }
}
