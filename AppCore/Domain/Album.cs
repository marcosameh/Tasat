using AppCore.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace AppCore.Models
{
    public partial class Album : LocalizedEntity<AlbumLocalized>
    {
        [NotMapped]
        public string newName { get; set; }

        [NotMapped]
        public string Description { get; set; }


        public override void Localize(int languageId)
        {
            var dictionary = AlbumLocalizeds.ToDictionary(x => x.LanguageId);
           GetLocalizedEntity(dictionary, languageId);
        }

        public override void Map(AlbumLocalized localizedEntity)
        {
            newName = localizedEntity.Name;
            Description = localizedEntity.Description;
        }
    }
}
