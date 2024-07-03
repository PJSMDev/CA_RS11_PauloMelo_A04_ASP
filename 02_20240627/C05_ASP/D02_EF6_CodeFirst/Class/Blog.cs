using System.Collections.Generic;

namespace D02_EF6_CodeFirst.Class
{

    internal class Blog
    {

        #region Properties

        // Scalar Properties
        public int BlogID { get; set; }
        public string Name { get; set; }

        // Navigation Properties -> ligam as tabelas
        // 1 blog tem uma coleção de posts (1 -> n)
        public virtual ICollection<Post> Post {  get; set; } 

        #endregion
    }
}
