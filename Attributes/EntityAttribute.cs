namespace Miki.Bot.Models.Attributes
{
    using System;

    /// <summary>
    /// Creates a localizable entity with a resource name of "entity_{Value}".
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class EntityAttribute : Attribute
    {
        public string Value { get; set; }

        public EntityAttribute(string verb)
        {
            Value = verb;
        }
    }
}