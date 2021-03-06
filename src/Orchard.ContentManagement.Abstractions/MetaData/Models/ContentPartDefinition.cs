﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Orchard.ContentManagement.Metadata.Models
{
    public class ContentPartDefinition : ContentDefinition
    {
        public ContentPartDefinition(string name, IEnumerable<ContentPartFieldDefinition> fields, JObject settings)
        {
            Name = name;
            Fields = fields.ToList();
            Settings = settings;

            foreach(var field in Fields)
            {
                field.PartDefinition = this;
            }
        }

        public ContentPartDefinition(string name)
        {
            Name = name;
            Fields = Enumerable.Empty<ContentPartFieldDefinition>();
            Settings = new JObject();
        }

        public IEnumerable<ContentPartFieldDefinition> Fields { get; private set; }
    }
}