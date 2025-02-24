using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToolManager.Entity;

namespace ToolManager.DataAccess
{
    public class DBManager
    {
        private ToolTree toolTree;
        private ToolTecno toolTecno;
        private DBTools toolData;

        public DBManager()
        {
            toolTree = XmlSerialization.Deserialize<ToolTree>(Globals.XmlToolTree);
            toolTecno = XmlSerialization.Deserialize<ToolTecno>(Globals.XmlToolTecno);
            toolData = XmlSerialization.Deserialize<DBTools>(Globals.XmlToolData);
        }

        public List<Node> GetToolTree(Expression<Func<Node, bool>> filter = null)
        {
            List<Node> resultNodes;
            if (filter == null)
            {
                resultNodes = toolTree.Nodes;
            }
            else
            {
                var sideNodes = toolTree.Nodes.AsQueryable().FirstOrDefault(work => work.Value == Globals.SelectWorkValue);
                resultNodes = sideNodes.SubNodes.AsQueryable().Where(filter).ToList();
            }
            return resultNodes;
        }

        public int GetToolTecnoMsgId(string msgName)
        {
            return toolTecno.MsgDef.Messages.FirstOrDefault(m => m.Name == msgName)?.Id ?? -1;
        }

        public string GetToolTecnoMsgName(string field, string subName)
        {
            var fieldDef = toolTecno.ToolDef.FieldDefs.FirstOrDefault(fd => fd.Field == field);

            return fieldDef.SubFields.FirstOrDefault(s => s.Name == subName)?.MessageId ?? "-1";
        }

        public int GetToolTecnoFieldValue(string field, string subName)
        {
            var fieldDef = toolTecno.ToolDef.FieldDefs.FirstOrDefault(fd => fd.Field == field);

            return fieldDef.SubFields.FirstOrDefault(s => s.Name == subName)?.Value ?? -1;
        }

        public List<ToolData> GetTools(int workValue, int sideValue, int subWorkValue)
        {
            return toolData.ToolDataList
                            .Where(tData =>
                                tData.ToolFields.Any(f => f.Name == "codWork" && f.Value == workValue.ToString()) &&
                                tData.ToolFields.Any(f => f.Name == "codSide" && f.Value == sideValue.ToString()) &&
                                tData.ToolFields.Any(f => f.Name == "codSubWork" && f.Value == subWorkValue.ToString()))
                            .ToList(); ;
        }

        public ToolViewItem GetViews(string work, string side, string subWork)
        {
            return toolTecno.ToolView.Tools
                            .Where(tView => 
                                        tView.CodWork == work && 
                                        tView.CodSide == side && 
                                        tView.CodSubWork == subWork)
                            .FirstOrDefault(); 

        }

        public void AddTool(ToolData tool)
        {
            toolData.ToolDataList.Add(tool);
        }

        public void RemoveTool(ToolData tool)
        {
            toolData.ToolDataList.Remove(tool);
        }

        public List<Field> GetToolFields()
        {
            return toolTecno.ToolDef.Tool.Fields;
        }
    }
}
