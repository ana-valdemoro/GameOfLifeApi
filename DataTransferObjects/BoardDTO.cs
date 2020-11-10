using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLifeApi2.DataTransferObjects
{
    public class BoardDTO{
        public List<CellDTO> Table { set; get; }
    }
}
