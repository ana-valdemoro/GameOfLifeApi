using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLifeApi2.DataTransferObjects
{
    public class BoardDTO{
        [Required]
        public List<CellDTO> Table { set; get; }
    }
}
