namespace Miki.Bot.Models.Exceptions
{
    using System.Linq;
    using System.Reflection;
    using Miki.Bot.Models.Attributes;
    using Miki.Localization.Exceptions;
    using Miki.Localization;

    /// <summary>
    /// Localized exception for if an entity is null. Requires that the type has a
    /// <see cref="EntityAttribute"/> attached to the type.
    /// </summary>
    public class EntityNullException<T> : LocalizedException
        where T : class
    {
        /// <inheritdoc />
        public override IResource LocaleResource
            => new LanguageResource("error_entity_null", GetEntityResource());

        private LanguageResource GetEntityResource()
        {
            var entityAttribute = typeof(T).GetCustomAttributes<EntityAttribute>(false)
                .FirstOrDefault();
            if(entityAttribute == null)
            {
                return new LanguageResource("entity_generic");
            }

            return new LanguageResource(entityAttribute.Value);
        }
    }
}
