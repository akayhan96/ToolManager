using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolManager.Business;

namespace ToolManager
{
    public class Globals
    {
        public static ImageList TreeViewImages = new ImageList();

        public static BusinessManager serviceManager; 

        public static string XmlToolTree = @"C:\Albatros\system\Tecno\ToolTree.xml";
        public static string XmlToolTecno = @"C:\Albatros\system\Tecno\ToolTecno.xml";
        public static string XmlToolData = @"C:\Albatros\system\Tecno\ToolData.xml";
        public static string XmlOutfData = @"C:\Albatros\System\Tecno\OutfData.xml";
        public static string XmlTecData = @"C:\Albatros\system\Tecno\TecData.xml";
        public static string XmlBushCfg = @"C:\Albatros\system\Tecno\BushCfg.xml";

        public static string XmlngEscBoard = @"C:\Albatros\system\Esc\LngFiles\EscBoard.xmlng";
        public static string XmlngToolTecno = @"C:\Albatros\system\Tecno\ToolTecno.xmlng";
        public static string XmlngTecnoManager = @"C:\Albatros\Lng\TecnoManager.xmlng";
        public static string XmlngToolManager = @"C:\Albatros\system\Esc\LngFiles\ToolManager.xmlng";

        public static string CurLang = "TRK";
        public static string SelectWorkValue = "";

        // Writable Entities ID's
        public const int EntityToolTree  = 1;
        public const int EntityDbTools   = 2;
        public const int EntityDbOutfits = 3;
        public const int EntityTecData   = 4;
    }
}
