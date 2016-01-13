namespace Dapper.FastCrud.DtoRepository.Converters
{
    using System;
    using System.Collections.Generic;

    public class GenericTypeObjectMap
    {
        private readonly Dictionary<Type, Func<object>> _typeObjFuncMap = new Dictionary<Type, Func<object>>();
        private readonly Dictionary<Type, object> _typeObjMap = new Dictionary<Type, object>();

        /// <summary>
        /// Sets an object.
        /// </summary>
        public void Set<T>(T obj)
        {            
            this.Set(obj, typeof(T));
        }

        /// <summary>
        /// Sets an object getter.
        /// </summary>
        public void Set<T>(Func<T> objFct)
        {
            Requires.NotNull(objFct, nameof(objFct));

            this.Set(()=>objFct(), typeof(T));
        }

        /// <summary>
        /// Sets an untyped object using an optional known type.
        /// </summary>
        public void Set(object obj, Type objType)
        {
            if (objType == null)
            {
                objType = obj.GetType();
            }

            _typeObjMap[objType] = obj;
            _typeObjFuncMap.Remove(objType);
        }

        /// <summary>
        /// Gets an untyped object, using the given type.
        /// </summary>
        public T Get<T>()
        {
            return (T)this.Get(typeof(T));
        }

        /// <summary>
        /// Gets an untyped object, using the given type.
        /// </summary>
        public object Get(Type objType)
        {
            object obj = null;
            if (!_typeObjMap.TryGetValue(objType, out obj))
            {
                Func<object> objFct;
                if (_typeObjFuncMap.TryGetValue(objType, out objFct))
                {
                    obj = objFct();
                }
            }

            return obj;
        }

        /// <summary>
        /// Sets an untyped object using a known type.
        /// </summary>
        protected internal void Set(Func<object> objFct, Type objType)
        {
            Requires.NotNull(objFct, nameof(objFct));
            Requires.NotNull(objType, nameof(objType));

            _typeObjFuncMap[objType] = objFct;
            _typeObjMap.Remove(objType);
        }


    }
}
