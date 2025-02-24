using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ToolManager
{
    public class XmlFileRead
    {
        public static string LanguageRead(string id, string isoname, string LngFile)
        {
            string TextReaded = "";
            XmlDocument XmlEscBoard = new XmlDocument();

            if (File.Exists(LngFile) == true)
                XmlEscBoard.Load(LngFile);
            else
                return "LanguageFileError";

            for (Int16 Lang = 0; Lang < XmlEscBoard.ChildNodes[1].ChildNodes.Count; Lang++)
            {
                if (XmlEscBoard.ChildNodes[1].ChildNodes[Lang].Attributes["ISOName"].Value.ToUpper() == isoname.ToUpper())
                {
                    //                                           tpaLanguages  /language   /   message

                    for (Int16 Msg = 0; Msg < XmlEscBoard.ChildNodes[1].ChildNodes[Lang].ChildNodes.Count; Msg++)
                    {
                        if (XmlEscBoard.ChildNodes[1].ChildNodes[Lang].ChildNodes[Msg].Attributes["MsgID"].Value == id)
                        {
                            TextReaded = XmlEscBoard.ChildNodes[1].ChildNodes[Lang].ChildNodes[Msg].InnerText;
                        }

                    }
                }
            }
            return TextReaded;
        }
    }
}
