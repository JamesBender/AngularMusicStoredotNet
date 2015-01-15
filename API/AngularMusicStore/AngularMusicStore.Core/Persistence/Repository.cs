using System;
using System.Collections.Generic;
using AngularMusicStore.Core.Entities;
using NHibernate;

namespace AngularMusicStore.Core.Persistence
{
    public interface IRepository
    {
        IEnumerable<T> GetAll<T>() where T : BaseEntity;
        Guid Save<T>(T entity) where T: BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
        T GetById<T>(Guid entityId) where T : BaseEntity;
    }

    public class Repository : IRepository
    {
        private readonly ISessionFactory _sessionFactory;

        public Repository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public IEnumerable<T> GetAll<T>() where T : BaseEntity
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session.CreateCriteria<T>().List<T>();
            }
        }

        public Guid Save<T>(T entity) where T : BaseEntity
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return entity.Id == Guid.Empty ? SaveEntity(entity, session) : UpdateEntity(entity, session);
            }
        }

        private static Guid UpdateEntity<T>(T entity, ISession session) where T : BaseEntity
        {
            session.Merge(entity);
            session.Flush();
            session.Evict(entity);
            return entity.Id;
        }

        private static Guid SaveEntity<T>(T entity, ISession session) where T : BaseEntity
        {
            var id = (Guid)session.Save(entity);
            session.Flush();
            session.Evict(entity);
            return id;
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            using (var session = _sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
                session.Evict(entity);
            }
        }

        public T GetById<T>(Guid entityId) where T : BaseEntity
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session.Get<T>(entityId);
            }
        }
    }
}