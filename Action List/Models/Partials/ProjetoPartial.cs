using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Action_List.Models
{

    [MetadataType(typeof(ProjetoPartial))]
    public partial class Projeto
    {
         
    }

    public class ProjetoPartial
    {
        [Key]
        [ScaffoldColumn(false)]
        [Index(IsUnique = true)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Código")]
        [Index(IsUnique = true)]
        [StringLength(20, MinimumLength = 1)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Selecione um Responsável.")]
        [Display(Name = "Responsável")]
        public int Responsavel { get; set; }

    }
}