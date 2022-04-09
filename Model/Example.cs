using System.ComponentModel.DataAnnotations;

namespace SampleWebApi.Model
{
    public class Example
    {
     [Key] 
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
