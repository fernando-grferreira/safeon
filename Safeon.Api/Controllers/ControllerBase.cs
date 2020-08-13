using Microsoft.AspNetCore.Mvc;
using Safeon.Systems.Core.Enums;
using System.Net;

namespace Safeon.Api.Controllers
{
    public class ControllerBase : Controller
    {
        /// <summary>
        /// Token de acesso enviado no Header da requisição.
        /// </summary>
        protected string ApplicationId
        {
            get
            {
                if (Request.Headers.ContainsKey(HttpRequestHeader.Authorization.ToString()))
                    return Request.Headers[HttpRequestHeader.Authorization.ToString()].ToString();

                return null;
            }
        }

        /// <summary>
        /// Identificador da cultura desejada para a resposta de requisição da API.
        /// </summary>
        protected string AcceptLanguage
        {
            get
            {
                if (Request.Headers.ContainsKey(HttpRequestHeader.AcceptLanguage.ToString()))
                    return Request.Headers[HttpRequestHeader.AcceptLanguage.ToString()].ToString();

                return "pt-BR";
            }
        }

        /// <summary>
        /// DeviceToken para envio de push enviado no Header da requisição.
        /// </summary>
        protected string DeviceToken
        {
            get
            {
                if (Request.Headers.ContainsKey("DeviceToken"))
                    return Request.Headers["DeviceToken"].ToString();

                return null;
            }
        }

        protected string Authorization
        {
            get
            {
                if (Request.Headers.ContainsKey("Authorization"))
                    return Request.Headers["Authorization"].ToString();

                return null;
            }
        }

        /// <summary>
        /// Tipo de OS do celular enviado no Header da requisição.
        /// </summary>
        protected ESmartphoneOS OSSmartphone
        {
            get
            {
                if (Request.Headers.ContainsKey("OSSmartphone"))
                {
                    var osString = Request.Headers["OSSmartphone"].ToString();

                    if (osString.ToUpper() == ESmartphoneOS.IOS.ToString())
                        return ESmartphoneOS.IOS;
                    if (osString.ToUpper() == ESmartphoneOS.ANDROID.ToString())
                        return ESmartphoneOS.ANDROID;
                }

                return ESmartphoneOS.UNDEFINED;
            }
        }
    }
}
