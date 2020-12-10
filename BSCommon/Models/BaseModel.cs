using BSCommon.Constant;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSCommon.Models
{
    public class BaseModel
    {
        /// <summary>
        /// Status
        /// </summary>
        [NotMapped]
        public ModifyMode Status { get; set; }

        public T Clone<T>() where T : BaseModel
        {
            T clone = default;

            if (typeof(T) == this.GetType())
            {
                clone = (T)this.MemberwiseClone();
            }

            return clone;
        }
    }
}
