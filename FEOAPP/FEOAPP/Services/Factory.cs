using System;
using System.Collections;

namespace FEOAPP.Services
{
    public class Factory<T>
    {
        private static Hashtable hashTableHandlers;
        private static object lockControl = new object();

        public static T GetInstance()
        {
            lock (lockControl)
            {

                if (hashTableHandlers == null)
                    hashTableHandlers = new Hashtable();

                T retorno = (T)hashTableHandlers[typeof(T)];

                if (retorno == null)
                {
                    Type t1 = typeof(T);

                    retorno = (T) Activator.CreateInstance(t1);

                    hashTableHandlers.Add(t1, retorno);
                }

                return retorno;

            }
        }

    }
}