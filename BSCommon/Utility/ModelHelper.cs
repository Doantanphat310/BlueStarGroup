using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Utility
{
    public static class ModelHelper
    {
        public static TTarget CopyToNew<TSource, TTarget>(TSource copyFrom)
           where TTarget : new()
        {
            if (copyFrom == null)
            {
                return new TTarget();
            }

            var sourceProps = copyFrom.GetType().GetProperties().Where(o => o.CanRead).ToList();
            Dictionary<string, object> dict = new Dictionary<string, object>();
            TTarget copyTo = new TTarget();
            var destProps = copyTo.GetType().GetProperties().Where(o => o.CanWrite).ToList();

            foreach (var sourceProp in sourceProps)
            {
                dict.Add(sourceProp.Name, sourceProp.GetValue(copyFrom, null));
            }

            foreach (var prop in destProps)
            {
                if (dict.ContainsKey(prop.Name))
                {
                    prop.SetValue(copyTo, dict[prop.Name]);
                }
            }

            return copyTo;
        }

        public static TTarget CopyTo<TSource, TTarget>(TSource copyFrom, TTarget copyTo)
           where TTarget : new()
        {
            var sourceProps = copyFrom.GetType().GetProperties().Where(o => o.CanRead).ToList();
            var destProps = copyTo.GetType().GetProperties().Where(o => o.CanWrite).ToList();
            Dictionary<string, object> dict = new Dictionary<string, object>();

            if (copyFrom == null)
            {
                return copyTo;
            }

            foreach (var sourceProp in sourceProps)
            {
                dict.Add(sourceProp.Name, sourceProp.GetValue(copyFrom, null));
            }

            foreach (var prop in destProps)
            {
                if (dict.ContainsKey(prop.Name))
                {
                    prop.SetValue(copyTo, dict[prop.Name]);
                }
            }

            return copyTo;
        }
    }
}
