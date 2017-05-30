using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayerISMS
{
  public class Department
    {
      public int Id { get; set; }
      public string Name { get; set; }
    }

  public class DocTemplate
  {
      public string DocumentName { get; set; }
      public string DocumentUrl { get; set; }
      public int DeptId { get; set; }
  }
}
