using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BlessingsMod.Custom {

    public static class BlessingUtilities {

        /// <summary>
        /// Returns a List of Types that aren't abstract that extend the class T.
        /// </summary>
        /// <typeparam name="T"> The Class to get the children of. </typeparam>
        public static List<Type> GetAllChildrenOfClass<T>() {
            return Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsSubclassOf(typeof(T)) && !type.IsAbstract).ToList();
        }
    }
}