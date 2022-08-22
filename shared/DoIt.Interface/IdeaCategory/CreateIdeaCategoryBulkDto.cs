using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoIt.Interface.IdeaCategory
{
    public class CreateCategoryBulkDto
    {
        public IEnumerable<CreateCategoryDto> Categories { get; set; }
    }
}
