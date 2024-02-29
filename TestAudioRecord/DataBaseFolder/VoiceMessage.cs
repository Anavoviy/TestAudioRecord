using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAudioRecord.DataBaseFolder
{
    public class VoiceMessage
    {
        [Key]
        public int Id { get; set; }



        public byte[] Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}
