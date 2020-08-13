using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;

namespace Safeon.Api.Filters
{
    public class ApplyCustomSchemaFilters : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
        }

        public void Apply(Schema schema, SchemaFilterContext context)
        {
            var excludeList = new List<string>();
            foreach (var prop in excludeList)
            {
                if (schema.Properties.ContainsKey(prop))
                    schema.Properties.Remove(prop);
            }
        }
    }
}