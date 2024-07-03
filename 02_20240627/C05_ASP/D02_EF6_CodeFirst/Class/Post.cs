using System;
using System.Collections.Generic;
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
        public string Title { get; set; }
        public string Content { get; set; }

        // Navigation Properties -> ligam as tabelas
        // 1 post pertence a 1 blog (1 - 1)
        public virtual Blog Blog { get; set; }

        #endregion
    }
}
