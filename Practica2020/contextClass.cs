using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2020
{
    public partial class MagazineSetEntities
    {
        private static MagazineSetEntities _context;

        public static MagazineSetEntities GetContext()
        {
            if (_context == null)
            {
                _context = new MagazineSetEntities();
            }
            return _context;
        }
    }
}
