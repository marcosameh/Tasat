using AppCore.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AppCore.Contracts
{
    public abstract class LocalizedEntity<T> : ILocalizedEntity
    {
        protected LocalizedEntity()
        {
            DefaultLanguageId = 2057; //en-GB
        }

        [NotMapped]
        public int DefaultLanguageId { get; set; }

        public abstract void Localize(int languageId);
        public abstract void Map(T localizedEntity);

        public T GetLocalizedEntity(Dictionary<int, T> localizedEntities, int languageId)
        {
            if (localizedEntities != null && localizedEntities.Keys.Count > 0)
            {
                T localizedEntity = localizedEntities.Keys.Contains(languageId)
                    ? localizedEntities[languageId]
                    : localizedEntities[DefaultLanguageId];

                Map(localizedEntity);

                return localizedEntity;
            }
            else
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
        }
    }
}