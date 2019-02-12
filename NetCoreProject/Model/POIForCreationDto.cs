using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreProject.Model
{
    public class POIForCreationDto
    {
        [Required]
        public string Name { get; set; }


        [MaxLength(200)]
        public string Description { get; set; } 
    }
}
