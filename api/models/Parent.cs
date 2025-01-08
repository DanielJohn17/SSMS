using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.models
{
    public class Parent : IdentityUser
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public List<ParentAnnouncement> ParentAnnouncements { get; set; } = new List<ParentAnnouncement>();
    }
}