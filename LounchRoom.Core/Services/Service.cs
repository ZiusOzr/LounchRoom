using System;
using System.Collections.Generic;
using System.Text;

namespace LounchRoom.Core.Services
{
    public class Service<T>
    {
        private static T instence;
        public static void Register(T inst)
        {
            if (instence != null)
                throw new Exception("Такой сервис уже есть");
            else instence = inst;
        }

        public static T GetInstence()
        {
            return instence;
        }
    }
}
