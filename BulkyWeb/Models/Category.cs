using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key] // it is a data annotation which says Id is a primary key
        public int Id { get; set; }
        [Required] // it is a data annotation which says the columns name, displayouder should not be null
        [MaxLength(30)] // server side validation
        [DisplayName("Category Name")] // By this u can create client side validation and you can display what name u want


        
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order Must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
