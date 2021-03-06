﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Domain
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    [Table("UserProfile")]
    public class UserProfile
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public ICollection<Link> Links { get; set; }
    }
}
