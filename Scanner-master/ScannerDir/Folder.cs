using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerDir
{
    class Folder
    {
        //Fields
        private string parent;
        private string absolutePath;
        private PropertiesDir contain;
        private int level;

        //Constructor
        public Folder(string parent, string absolutePath, int level, PropertiesDir contain)
        {
            this.parent = parent;
            this.absolutePath = absolutePath;
            this.level = level;
            this.contain = contain;
        }

        //Functions
        public string getParent()
        {
            return parent;
        }

        public string getAbsolutePath()
        {
            return absolutePath;
        }

        public int getLevel()
        {
            return level;
        }

        public PropertiesDir getProp()
        {
            return contain;
        }
    }
}
