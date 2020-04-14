namespace library_management.Model
{
    using lib_manage_project;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.Books = new HashSet<Book>();
        }
    
        public int Client_Id { get; set; }
        [Display (Name ="Client UserName")]
        [Required(ErrorMessage = "*Required")]
        [RegularExpression(".{1,50}")]
        
        public string Client_Name { get; set; }

        [Required(ErrorMessage = "*Required")]
        [RegularExpression(".{6,20}")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*Required")]
        [RegularExpression(".{8,50}")]
        [Phone]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "*Required")]
        [RegularExpression(".{10,50}")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Required")]
        [RegularExpression("[0-9]{14}")]
        [Display(Name = "National ID")]
        public string National_Id { get; set; }

        [Required(ErrorMessage = "*Required")]
        [NotInFuture]
        public System.DateTime DateOfBirth { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Books { get; set; }
    }
}
