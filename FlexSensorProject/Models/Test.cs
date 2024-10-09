using System.ComponentModel.DataAnnotations;

namespace FlexSensorProject.Models
{
    public class Test
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public double Maximum { get; set; }

        [Required]
        public double Minimum { get; set; }

        [Required]
        public double Average { get; set; }

        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }   
    }
}
