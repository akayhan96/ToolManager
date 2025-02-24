using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolManager.DataAccess;
using ToolManager.Entity;

namespace ToolManager.Business
{
    public class BusinessManager
    {
        private DBManager dbManager;
        public BusinessManager()
        {
            this.dbManager = new DBManager();
        }

        //----  ToolTree ------
        public List<Node> GetToolTree()
        {
            return dbManager.GetToolTree();
        }

        public List<Node> GetToolTreeWorkNodes(string treeName)
        {
            return dbManager.GetToolTree(n => n.Name == treeName);
        }
        
        //-------------------------

        // ----- ToolTecno ------------
        public string GetFieldText(string field, string subField)
        {
            string msgName = dbManager.GetToolTecnoMsgName(field, subField);
            int msgId = dbManager.GetToolTecnoMsgId(msgName);

            return ReadMessage(msgId.ToString(), Globals.XmlngToolTecno);
        }

        public string GetFieldText(string msgName)
        {
            int msgId = dbManager.GetToolTecnoMsgId(msgName);

            return ReadMessage(msgId.ToString(), Globals.XmlngToolTecno);
        }

        public string GetFieldValue(string field, string subName)
        {
            return dbManager.GetToolTecnoFieldValue(field, subName).ToString();
        }

        public ToolViewItem GetToolViews(string[] nodeValues)
        {
            string work = nodeValues[0];
            string side = nodeValues[1];
            string subWork = nodeValues[2];

            return dbManager.GetViews(work, side, subWork);
        }
        
        public List<Field> GetToolTypes()
        {
            return dbManager.GetToolFields();
        }
        // ---------------------------

        // ----- ToolData --------------
        public List<ToolData> GetTools(string workName, string sideName, string subWorkName)
        {
            int workValue = dbManager.GetToolTecnoFieldValue("codWork", workName);
            int sideValue = dbManager.GetToolTecnoFieldValue("codSide", sideName);
            int subWorkValue = dbManager.GetToolTecnoFieldValue("codSubWork", subWorkName);

            return dbManager.GetTools(workValue, sideValue, subWorkValue);
        }

        public ToolData GetTool(string[] nodeValues)
        {
            string workName = nodeValues[0];
            string sideName = nodeValues[1];
            string subWorkName = nodeValues[2];
            string toolName = nodeValues[3];

            int workValue = dbManager.GetToolTecnoFieldValue("codWork", workName);
            int sideValue = dbManager.GetToolTecnoFieldValue("codSide", sideName);
            int subWorkValue = dbManager.GetToolTecnoFieldValue("codSubWork", subWorkName);

            return dbManager.GetTools(workValue, sideValue, subWorkValue).Where(t =>t.ToolFields.Any(n=> n.Value == toolName)).FirstOrDefault();
        }

        public string GetToolValue(ToolData toolData, string fieldName)
        {
            fieldName = fieldName.Replace("[0]", "");
            var tField = toolData.ToolFields.Where(v => v.Name == fieldName).FirstOrDefault();
            string tValue = tField == null ? "0" : tField.Type.Contains("[]") ? tField.Value.Split(';')[0] : tField.Value;

            return tValue;
        }

        public void SetToolValue(ToolData toolData, string fieldName,string value)
        {
            fieldName = fieldName.Replace("[0]", "");
            var tField = toolData.ToolFields.Where(v => v.Name == fieldName).FirstOrDefault();
            if(tField.Type.Contains("[]"))
            {
                value = value + ";0;0;0;0;0;0";
            }

            tField.Value = value;
        }

        public string GetToolName(ToolData toolData)
        {
            return toolData.ToolFields.Where(f => f.Name == "description").FirstOrDefault().Value;
        }
        
        public void AddToolOnList(ToolData toolData)
        {
            dbManager.AddTool(toolData);
        }
        public void RemoveToolOnList(string tag)
        {
            var tool = GetTool(tag.Split('|'));

            dbManager.RemoveTool(tool);
        }
        // -----------------------------

        // ----- General ---------------
        public string ReadMessage(string msgNo, string langFile)
        {
            return XmlFileRead.LanguageRead(msgNo, Globals.CurLang, langFile);
        }
        // -----------------------------

    }
}
