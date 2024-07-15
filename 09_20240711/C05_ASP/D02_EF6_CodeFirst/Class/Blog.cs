using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D02_EF6_CodeFirst.Class
{

    internal class Blog
    {

        #region Properties

        // Scalar Properties
        public int BlogID { get; set; }

        [Required]
        //[Column(TypeName = "nvarchar(100)")]  // versão 4.7.2
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string Name { get; set; }

        // Navigation Properties -> ligam as tabelas
        // 1 blog tem uma coleção de posts (1 -> n)
        public virtual ICollection<Post> Post {  get; set; } 

        #endregion
    }
}
