using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace FlexSensorProject.Models
{
    public class Patient
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Patient Name")]
        public string PatientName { get; set; }

        [Required]
        [DisplayName("Patient Old")]
        public int PatientOld {  get; set; }

        [Required]
        [DisplayName("Patient Hight CM")]
        public int Hight { get; set; }

        [Required]
        [DisplayName("Patient Weight KG")]
        public double Weight { get; set; }

        public ICollection<Test> Tests { get; set; }

    }
}
