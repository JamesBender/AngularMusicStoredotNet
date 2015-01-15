using System;
using System.Collections.Generic;
using System.Linq;
using AngularMusicStore.Core.Entities;
using AngularMusicStore.Core.Persistence;
using Moq;
using NHibernate;
using NUnit.Framework;

namespace AngularMusicStore.UnitTests.Core
{
    [TestFixture]
    public class RepositoryTests
    {
        private ISessionFactory _sessionFactory;
        private Mock<ISession> _session;
        private ISession _sessionMockedObject;
        private Repository _repository;

        [SetUp]
        public void SetupTests()
        {
            var sessionFactoryMock = new Mock<ISessionFactory>();
            _sessionFactory = sessionFactoryMock.Object;
            _session = new Mock<ISession>();
            _sessionMockedObject = _session.Object;
            sessionFactoryMock.Setup(x => x.OpenSession()).Returns(_sessionMockedObject);
            _repository = new Repository(_sessionFactory);
        }

        [Test]
        public void ShouldBeAbleToGetAListOfAllEntities()
        {
            var listOfUsers = new List<Artist> { new Artist(), new Artist(), new Artist() };
            var expectedNumberOfEntities = listOfUsers.Count();
            var criteraQueryMock = new Mock<ICriteria>();

            criteraQueryMock.Setup(x => x.List<Artist>()).Returns(listOfUsers);
            _session.Setup(x => x.CreateCriteria<Artist>()).Returns(criteraQueryMock.Object);

            var result = _repository.GetAll<Artist>();

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNumberOfEntities, result.Count());
        }

        [Test]
        public void ShouldBeAbleToSaveAnEntityToTheDatastore()
        {
            var artist = new Artist();
            var artistId = Guid.NewGuid();

            _session.Setup(x => x.Save(artist)).Returns(artistId);

            var result = _repository.Save(artist);

            Assert.IsNotNull(result);
            Assert.AreEqual(artistId, result);
            _session.Verify(x => x.Save(artist), Times.Once());
            _session.Verify(x => x.Flush(), Times.Once());
            _session.Verify(x => x.Evict(artist), Times.Once);
        }

        [Test]
        public void ShouldBeAbleToRetriveAnEntityById()
        {
            var artistId = Guid.NewGuid();
            var expectedArtist = new Artist { Id = artistId };

            _session.Setup(x => x.Get<Artist>(artistId)).Returns(expectedArtist);

            var result = _repository.GetById<Artist>(artistId);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedArtist, result);
        }

        [Test]
        public void ShouldBeAbleToDeleteAnEntity()
        {
            var artist = new Artist();

            _repository.Delete(artist);

            _session.Verify(x => x.Delete(artist), Times.Once);
            _session.Verify(x => x.Flush(), Times.Once);
            _session.Verify(x => x.Evict(artist), Times.Once);
        }

        [Test]
        public void ShouldBeAbleToUpdateAnExisitngEntity()
        {
            var artistId = Guid.NewGuid();
            var artist = new Artist {Id = artistId};

            var result = _repository.Save(artist);

            Assert.IsNotNull(result);
            Assert.AreEqual(artistId, result);
            _session.Verify(x => x.Merge(artist), Times.Once);
            _session.Verify(x => x.Flush(), Times.Once);
            _session.Verify(x => x.Evict(artist));
        }
    }
}