using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAudioRecord.DataBaseFolder
{
    public class Patient
    {
        [Key]
        public int MedicalCardCode { get; set; }

        [MaxLength(150)]
        public string FirstName { get; set; }
        [MaxLength(150)]
        public string LastName { get; set; }
        [MaxLength(150)]
        public string Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        [Column(TypeName ="char(4)")]
        public string PassportSeria { get; set; }
        [Column(TypeName = "char(6)")]
        public string PassportNumber { get; set; }
        public string? Diagnoz { get; set; }
    }
}
