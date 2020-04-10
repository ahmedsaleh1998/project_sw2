using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lib_manage_project
{
    public class NotInFuture : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime?)
            {
                var v = value as DateTime?;
                if (v.Value < DateTime.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}