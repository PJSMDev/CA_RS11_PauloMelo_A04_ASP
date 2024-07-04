using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E02_EF6_Editora.Class
{

    internal class Livro
    {

        #region Properties

        // Scalar Properties
        public int LivroId { get; set; }     // PK
        public int EditoraId { get; set; }     // FK
        public int TipoId { get; set; }         // FK

        [Required]
        [Column(TypeName = "nvarchar")]  // não precisa de estar porque por default string é sempre nvarchar.
        [StringLength(13, ErrorMessage = "Limite de 13 caracteres.")]
        public string ISBN { get; set; }

        //[StringLength(50, ErrorMessage = "Limite de 50 caracteres.")]
        //public string Tipo { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(100, ErrorMessage = "Limite de 100 caracteres.")]
        public string Título { get; set; }


        // Navigation Properties
        public virtual Editora Editora { get; set; }
        public virtual Tipo Tipo { get; set; }


        #endregion
    }
}
