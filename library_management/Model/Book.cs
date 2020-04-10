
namespace library_management.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.Clients = new HashSet<Client>();
        }
    
        public int Book_Id { get; set; }
        public string Title { get; set; }
        public string Descripion { get; set; }
        public System.DateTime DataOfPublish { get; set; }
        public int Author_Id { get; set; }
        public int Category_Id { get; set; }
        public string Image { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client> Clients { get; set; }
    }
}
