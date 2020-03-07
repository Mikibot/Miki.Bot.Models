namespace Miki.Bot.Models.Exceptions
{
    using System;
    using System.Reflection;
    using Miki.Bot.Models.Attributes;
    using Miki.Localization.Exceptions;
    using Miki.Localization.Models;

    public class ArgumentMissingException : LocalizedException
    {
        private readonly string argumentName;

        /// <inheritdoc />
        public override IResource LocaleResource
            => new LanguageResource("errors_missing_argument", argumentName);

        public ArgumentMissingException(string argumentName)
        {
            this.argumentName = argumentName;
        }

        public ArgumentMissingException(Type argumentType)
        {
            var attr = argumentType.GetCustomAttribute<VerbAttribute>();
            argumentName = attr != null ? attr.Value
                : GetVerbFromBaseType(argumentType);
        }

        private static string GetVerbFromBaseType(Type t)
        {
            if(t.IsAssignableFrom(typeof(string)))
            {
                return "verb_word";
            }

            if(t.IsAssignableFrom(typeof(int))
               || t.IsAssignableFrom(typeof(uint))
               || t.IsAssignableFrom(typeof(long))
               || t.IsAssignableFrom(typeof(ulong))
               || t.IsAssignableFrom(typeof(short))
               || t.IsAssignableFrom(typeof(ushort))
               || t.IsAssignableFrom(typeof(float))
               || t.IsAssignableFrom(typeof(double))
               || t.IsAssignableFrom(typeof(decimal)))
            {
                return "verb_number";
            }

            if(t.IsAssignableFrom(typeof(bool)))
            {
                return "verb_switch";
            }

            return "verb_object";
        }
    }
}