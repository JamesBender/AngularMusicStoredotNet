using System;
using System.Collections.Generic;
using AngularMusicStore.Core.Entities;
using NHibernate;

namespace AngularMusicStore.Core.Persistence
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> All { get; }
        Guid Save(T entity);
        void Delete(T entity);
        T GetById(Guid entityId);
    }

    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ISessionFactory _sessionFactory;

        public Repository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public IEnumerable<T> All 
        {
            get
            {
                using (var session = _sessionFactory.OpenSession())
                {
                    return session.CreateCriteria<Artist>().List<T>();
                }
            } 
        }

        public Guid Save(T entity)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return entity.Id == Guid.Empty ? SaveEntity(entity, session) : UpdateEntity(entity, session);
            }
        }

        private static Guid UpdateEntity(T entity, ISession session)
        {
            session.Merge(entity);
            session.Flush();
            session.Evict(entity);
            return entity.Id;
        }

        private static Guid SaveEntity(T entity, ISession session)
        {
            var id = (Guid) session.Save(entity);
            session.Flush();
            session.Evict(entity);
            return id;
        }

        public void Delete(T entity)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
                session.Evict(entity);
            }
        }

        public T GetById(Guid entityId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session.Get<T>(entityId);
            }
        }
    }
}