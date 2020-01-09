using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class PhotosAndComments
    {
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public Photographs Photo { get; set; } = new Photographs();
    }
}
