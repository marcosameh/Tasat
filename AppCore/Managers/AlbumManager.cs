using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace AppCore.Managers
{
    public class AlbumManager
    {
        private readonly AppCoreContext _context;
        private readonly int _languageId;

        public AlbumManager(AppCoreContext context, int languageId)
        {
            _context = context;
            _languageId = languageId;
        }

        public IQueryable<Album> GetAlbums()
        {
            return (IQueryable<Album>)_context.Albums.Where(x => x.Active.HasValue).Include(u => u.AlbumLocalizeds
                                     .Where(u => u.LanguageId == _languageId)).AsSingleQuery().OrderBy(x => x.DisplayOrder)
                                    .ForEachAsync(p => p.Localize(_languageId));
        }

        public IQueryable<AlbumPhoto> GetPhotos()
        {
            return _context.AlbumPhotos.OrderBy(x => x.DisplayOrder);
        }


    }
}