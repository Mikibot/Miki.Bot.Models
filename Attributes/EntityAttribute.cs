﻿using System;

namespace Miki.Bot.Models.Attributes
{
    /// <summary>
    /// Creates a localizable entity with a resource name of "entity_{Value}".
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class EntityAttribute : Attribute
    {
        private readonly string innerValue;

        public string Value => $"entity_{innerValue}";

        public EntityAttribute(string noun)
        {
            innerValue = noun;
        }
    }
}