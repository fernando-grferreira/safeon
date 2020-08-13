using Swashbuckle.AspNetCore.Swagger;
using System;

namespace Safeon.Systems.Core.Swagger.Attributes
{
    /// <summary>
    /// NonBodyParameter customizado.
    /// Pode ser usado para solicitar headers customizados, por exemplo: exigir que uma informação específica seja enviada nos headers de cada requisição.
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class NonBodyParameterAttribute : Attribute
    {
        private readonly NonBodyParameter _parameter;

        public NonBodyParameter Parameter
        {
            get
            {
                return _parameter;
            }
        }

        /// <summary>
        /// Cria um NonBodyParameter customizado
        /// </summary>
        /// <param name="name">Nome do parameter, ex: x-api-key</param>
        /// <param name="description">Descrição do parameter ex: API Gateway access token</param>
        /// <param name="required">Se true o parâmetro é obrigatório</param>
        /// <param name="parameterType">Local do parametro, ex: header</param>
        /// <param name="dataType">Tipo de dados do parâmetro</param>
        public NonBodyParameterAttribute(string name, string description, bool required, string parameterType= "header", string dataType="string")
        {
            _parameter = new NonBodyParameter {
                Name = name,
                Description = description,
                Required = required,
                In = parameterType,
                Type = dataType
            };
            
        }

        /// <summary>
        /// Cria um NonBodyParameter customizado
        /// </summary>
        /// <param name="resourceType">Tipo de recurso de idioma</param>
        /// <param name="nameResourceName">Identificador do recurso de idioma para o name do parameter.</param>
        /// <param name="descriptionResourceName">Identificador do recurso de idioma para o description do parameter.</param>
        /// <param name="required">Se true o parâmetro é obrigatório</param>
        /// <param name="parameterType">Local do parametro, ex: header</param>
        /// <param name="dataType">Tipo de dados do parâmetro</param>
        public NonBodyParameterAttribute(Type resourceType,string nameResourceName, string descriptionResourceName, bool required, string parameterType = "header", string dataType = "string")
            : this(
                  new System.Resources.ResourceManager(resourceType).GetString(nameResourceName), 
                  new System.Resources.ResourceManager(resourceType).GetString(descriptionResourceName), 
                  required, parameterType, dataType)
        {
        }
    }
}