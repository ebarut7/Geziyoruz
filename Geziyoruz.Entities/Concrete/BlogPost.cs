﻿

using Geziyoruz.Entities.Abstract;

namespace Geziyoruz.Entities.Concrete
{
    public class BlogPost : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Paragraph { get; set; }
        public Picture Picture { get; set; }
    }
}
