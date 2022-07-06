using System;
using System.ComponentModel.DataAnnotations;

namespace CManagerData.Entities
{
    public class Logo: BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string FileType { get; set; }
        [MaxLength]
        public byte[] DataFiles { get; set; }
    }
}

