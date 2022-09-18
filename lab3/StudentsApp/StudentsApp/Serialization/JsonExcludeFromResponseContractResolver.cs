using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsApp.Serialization
{
    public class JsonExcludeFromResponseContractResolver : DefaultContractResolver
    {
        private readonly List<string> _excludedPropNames;

        public JsonExcludeFromResponseContractResolver(List<string> excludedPropNames) => _excludedPropNames = excludedPropNames;

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var includedPropList = type.GetProperties()
                .Select(x => x.Name)
                .Where(x => !_excludedPropNames.Contains(x))
                .ToList();

            var properties = base.CreateProperties(type, memberSerialization)
                .Where(x => includedPropList.Contains(x.PropertyName))
                .ToList();

            return properties;
        }
    }
}