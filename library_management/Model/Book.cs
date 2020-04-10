
namespace library_management.Model
{
    using lib_manage_project;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.Clients = new HashSet<Client>();
        }
    
        public int Book_Id { get; set; }


        [Required(ErrorMessage = "*Required")]
        [RegularExpression(".{10,50}")]
        public string Title { get; set; }

        [Required(ErrorMessage = "*Required")]
        [RegularExpression(".{10,1000}")]
        public string Descripion { get; set; }

        [Required(ErrorMessage = "*Required")]
        [DataType(DataType.Date)]
        [NotInFuture]
        public System.DateTime DataOfPublish { get; set; }
        public int Author_Id { get; set; }
        public int Category_Id { get; set; }

        [Required(ErrorMessage = "*Required")]
        [RegularExpression(".{4,100}")]
        public string Image { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client> Clients { get; set; }
    }
}
