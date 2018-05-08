using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;

namespace Action_List.Models
{
    [MetadataType(typeof(UsuarioPartial))]
    public partial class Usuario
    {



    }


    public class UsuarioPartial
    {

        [Key]
        [Index(IsUnique = true)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(11,MinimumLength = 11, ErrorMessage = "Formato inválido! [dd123451234]")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Formato inválido!")]
        public string Telefone { get; set; }

    }
}