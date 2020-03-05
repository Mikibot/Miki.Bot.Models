namespace Miki.Bot.Models.Attributes
{
    using System;

    /// <summary>
    /// Creates a localizable entity with a resource name of "verb_{Value}".
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class VerbAttribute : Attribute
    {
        public string Value { get; set; }

        public VerbAttribute(string verb)
        {
            Value = verb;
        }
    }
}
