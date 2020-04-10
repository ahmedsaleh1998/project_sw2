

namespace library_management.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Admin
    {
        [Required(ErrorMessage = "*Required")]
        [EmailAddress]
        [RegularExpression(".{10,50}")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Required")]
        [DataType(DataType.Password)]
        [RegularExpression(".{6,20}")]
        public string Password { get; set; }
    }
}
