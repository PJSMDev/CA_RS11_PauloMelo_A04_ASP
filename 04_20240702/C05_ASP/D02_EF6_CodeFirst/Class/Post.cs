using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D02_EF6_CodeFirst.Class
{

    internal class Post
    {

        #region Properties

        // Scalar Properties
        public int PostID { get; set; } // PK     
        public int BlogID { get; set; } // FK

        [Required]
        //[Column(TypeName = "nvarchar(100)")]
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string Title { get; set; }

        //[Column(TypeName = "nvarchar(200)")]
        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        public string Content { get; set; }

        // Navigation Properties -> ligam as tabelas
        // 1 post pertence a 1 blog (1 - 1)
        public virtual Blog Blog { get; set; }

        #endregion
    }
}
