using System;

namespace Safeon.Systems.Core.Swagger.Attributes
{
    public class AuthorizeHeaderRequired : Attribute
    {
        private bool useApiGateway;

        public bool UseApiGateway
        {
            get
            {
                return useApiGateway;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="useApiGateway">Se true (padrão) vai exigir header "x-api-key"</param>
        public AuthorizeHeaderRequired(bool useApiGateway = true)
        {
            this.useApiGateway = useApiGateway;
        }
    }
}