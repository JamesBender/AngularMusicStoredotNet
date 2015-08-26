using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AngularMusicStore.Api.Models;
using AngularMusicStore.Api.Models.ViewModels;
using AngularMusicStore.Core.Exceptions;

namespace AngularMusicStore.Api.Controllers
{
    [EnableCors("*", "*", "*")]        
    public class ArtistController : ApiController
    {
        private readonly IArtistModel _artistModel;
        
        public ArtistController(IArtistModel artistModel)
        {
            _artistModel = artistModel;
        }

        [EnableCors("*", "*", "*")]
        public IEnumerable<Artist> GetArtists()
        {            
            return _artistModel.GetArtists();
        }

        [ResponseType(typeof(Artist))]
        public HttpResponseMessage GetById(string id)
        {
            Guid retrievalId;
            if (!Guid.TryParse(id, out retrievalId))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var artist = _artistModel.GetById(Guid.Parse(id));
            if (artist == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        public class ArtistResponse
        {
            public Guid Id { get; set; }
        }
        public HttpResponseMessage PostArtist(Artist artist)
        {
            var artistId = _artistModel.Save(artist);
            var resp = new ArtistResponse {Id = artistId};
            return Request.CreateResponse(HttpStatusCode.Created, resp);
        }

        public HttpResponseMessage PutArtist(string id, Artist artist)
        {
            Guid putId;
            if (!Guid.TryParse(id, out putId))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var returnStatus = Guid.Empty == artist.Id ? HttpStatusCode.Created : HttpStatusCode.OK;
            artist.Id = putId;
            
            _artistModel.Save(artist);

            return Request.CreateResponse(returnStatus);
        }

        public HttpResponseMessage Delete(string id)
        {
            Guid artistId;

            if (!Guid.TryParse(id, out artistId))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                _artistModel.Delete(artistId);
            }
            catch (DataNotFoundException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public IEnumerable<Artist> GetArtists(string name)
        {
            return _artistModel.GetByPartialName(name);
        }
    }
}
