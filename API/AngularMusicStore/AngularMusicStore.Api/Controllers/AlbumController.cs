﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AngularMusicStore.Api.Models;
using AngularMusicStore.Api.Models.ViewModels;
using AngularMusicStore.Core.Exceptions;

namespace AngularMusicStore.Api.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AlbumController : ApiController
    {
        private readonly IAlbumModel _albumModel;

        public AlbumController(IAlbumModel albumModel)
        {
            _albumModel = albumModel;
        }

        public HttpResponseMessage GetAlbum(string id)
        {
            Guid retrievalId;
            if (!Guid.TryParse(id, out retrievalId))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var album = _albumModel.GetAlbum(Guid.Parse(id));
            return album == null
                ? Request.CreateResponse(HttpStatusCode.NotFound)
                : Request.CreateResponse(HttpStatusCode.OK, album);
        }

        public HttpResponseMessage GetAlbums(string albumName)
        {
            var album = _albumModel.GetByPartialName(albumName);
            return Request.CreateResponse(HttpStatusCode.OK, album);
        }

        public HttpResponseMessage GetAlbums()
        {
            var listOfAlbums = _albumModel.GetAlbums();
            return Request.CreateResponse(HttpStatusCode.OK, listOfAlbums);
        }

        public HttpResponseMessage PostAlbum(Album album)
        {
            var artistId = _albumModel.Save(album.Parent.Id, album);
            return Request.CreateResponse(HttpStatusCode.Created, artistId);
        }

        public HttpResponseMessage DeleteAlbum(string id)
        {
            Guid albumId;

            if (!Guid.TryParse(id, out albumId))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                _albumModel.Delete(albumId);
            }
            catch (DataNotFoundException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }        
    }
}
