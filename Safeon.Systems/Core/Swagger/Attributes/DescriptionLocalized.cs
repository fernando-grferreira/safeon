using System;
using System.ComponentModel;

namespace Safeon.Systems.Core.Swagger.Attributes
{
    public class DescriptionLocalized : DescriptionAttribute
    {
        public DescriptionLocalized(Type resourceType, string descriptionResourceName)
            : base(new System.Resources.ResourceManager(resourceType).GetString(descriptionResourceName))
        {
        }

        public DescriptionLocalized(string descriptionName)
            : base(descriptionName)
        {
        }
    }
}