using System;

namespace AngularMusicStore.Core.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string message) : base(message)
        {
            
        }
    }
}