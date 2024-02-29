using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAudioRecord.DataBaseFolder
{
    public class LDM
    {
        [Key]
        public int Id { get; set; }

        public int PatientMedicalCardCode { get; set; }
        public virtual Patient? Patient { get; set; }


        public string TypeLDM { get; set; }
        public string PatientSaid { get; set; }
        public string Diagnoz { get; set; }
        public string TextRecommendation { get; set; }
    }
}
