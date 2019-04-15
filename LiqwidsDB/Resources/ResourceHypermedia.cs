using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WIM.Resources;
using WIM.Hypermedia;

namespace LiqwidsDB.Resources
{
    public partial class Citation : IHypermedia {[NotMapped] public List<Link> Links { get; set; } }
}
