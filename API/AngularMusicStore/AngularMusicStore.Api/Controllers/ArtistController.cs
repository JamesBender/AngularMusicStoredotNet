using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AngularMusicStore.Api.Models;
using AngularMusicStore.Api.Models.ViewModels;

namespace AngularMusicStore.Api.Controllers
{
    public class ArtistController : ApiController
    {
        private readonly IArtistModel _artistModel;

        public ArtistController(IArtistModel artistModel)
        {
            _artistModel = artistModel;
        }

        public IEnumerable<Artist> GetArtists()
        {
            return _artistModel.GetArtists();
        }

        [ResponseType(typeof(Artist))]
        public HttpResponseMessage GetById( string artistId)
        {
            Guid retrievalId;
            if (!Guid.TryParse(artistId, out retrievalId))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var artist = _artistModel.GetById(Guid.Parse(artistId));
            return artist == null
                ? Request.CreateResponse(HttpStatusCode.NotFound)
                : Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        public Guid PostArtist(Artist artist)
        {
            return _artistModel.Save(artist);
        }

        public HttpResponseMessage PutArtist(Artist artist)
        {
            var returnStatus = HttpStatusCode.OK;

            if (artist.Id == Guid.Empty)
            {
                returnStatus = HttpStatusCode.Created;
            }

            _artistModel.Save(artist);
            
            return Request.CreateResponse(returnStatus);
        }

        public HttpResponseMessage Delete(Artist artist)
        {
            if (_artistModel.GetById(artist.Id) == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            _artistModel.Delete(artist);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
