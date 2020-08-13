using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Safeon.Systems.Core.Swagger.Filters
{
    public class HideInDocsFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            //var controllers = context.ApiDescriptionsGroups.Items
            //    .SelectMany(i => i.Items)
            //    .Where(x => x.ControllerAttributes()
            //        .Any(c => c.GetType() == typeof(HideInDocsAttribute)));

            //foreach (var controller in controllers)
            //{
            //    var key = $"/{controller.RelativePath}";
            //    if (swaggerDoc.Paths.ContainsKey(key))
            //    {
            //        swaggerDoc.Paths.Remove(key);
            //    }
            //}
        }
    }
}