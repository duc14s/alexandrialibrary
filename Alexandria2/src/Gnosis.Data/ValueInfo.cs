﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Gnosis.Data
{
    public class ValueInfo
    {
        public ValueInfo(EntityInfo parent, PropertyInfo property, Type valueType)
        {
            this.parent = parent;
            this.property = property;
            this.type = valueType;
            this.name = string.Format("{0}_{1}", parent.Name, property.Name);

            MapTypes(valueType);
        }

        private readonly EntityInfo parent;
        private readonly Type type;
        private readonly PropertyInfo property;
        private readonly string name;
        private readonly List<ElementInfo> elements = new List<ElementInfo>();

        private void MapTypes(Type type)
        {
            foreach (var interfaceType in type.GetInterfaces())
            {
                MapProperties(interfaceType);
            }

            MapProperties(type);
        }

        private void MapProperties(Type type)
        {
            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var ignore = false;
                foreach (var attribute in property.GetCustomAttributes(true))
                {
                    if (attribute is PersistenceIgnoreAttribute)
                    {
                        ignore = true;
                        break;
                    }
                }

                if (!ignore)
                {
                    if (property.PropertyType.IsPrimitive || property.PropertyType.IsSimpleType() || property.PropertyType.IsChildType())
                    {
                        elements.Add(new ElementInfo(property));
                    }
                }
            }
        }

        public EntityInfo Parent
        {
            get { return parent; }
        }

        public Type Type
        {
            get { return type; }
        }

        public string Name
        {
            get { return name; }
        }

        public ElementInfo Identifer
        {
            get { return elements.Where(x => x.Name == "Id").FirstOrDefault(); }
        }

        public ElementInfo ParentIdentifier
        {
            get { return elements.Where(x => x.Name == "Parent").FirstOrDefault(); }
        }

        public ElementInfo Sequence
        {
            get { return elements.Where(x => x.Name == "Sequence").FirstOrDefault(); }
        }

        public IEnumerable<ElementInfo> Elements
        {
            get { return elements; }
        }
    }
}
