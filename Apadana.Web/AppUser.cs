using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Apadana.Web
{
    public class AppUser : IdentityUser
    {
        //[Required]
        //[Index(IsUnique = true)]
        //public override string PhoneNumber
        //{
        //    get
        //    {
        //        return base.PhoneNumber;
        //    }

        //    set
        //    {
        //        base.PhoneNumber = value;
        //    }
        //}
        ////no need for custom user information currently
    }
}