using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHPosts
{
    public class Posts
    {

        public Posts() { }

        #region Properties

        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime? PostedAt { get; set; }
        public virtual int BlogId { get; set; }
        public virtual int UserId { get; set; }

        #endregion

    }
}