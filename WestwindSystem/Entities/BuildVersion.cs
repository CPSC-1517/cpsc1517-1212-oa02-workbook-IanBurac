﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // for Key
using System.ComponentModel.DataAnnotations.Schema; // for Table
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestwindSystem.Entities
{
    [Table("BuildVersion")]
    public class BuildVersion
    {
        [Key]
        public int Id { get; set; }
        public  int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
