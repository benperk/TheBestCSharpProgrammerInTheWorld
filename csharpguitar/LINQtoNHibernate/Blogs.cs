using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHPosts
{
    public class Blogs
    {

        public Blogs() { }

        #region Properties

        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Subtitle { get; set; }
        public virtual bool AllowsComments { get; set; }
        public virtual DateTime? CreatedAt { get; set; }

        #endregion

    }
}