using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
       
        #region Constructor
        public BusinessManager()
        {
            this.dbManager = new DBManager();
        }
        #endregion

        #region TOOLTREEE
        public List<Node> GetToolTree()
        {
            return dbManager.GetToolTree();
        }

        public List<Node> GetToolTreeWorkNodes(string treeName)
        {
            return dbManager.GetToolTree(n => n.Name == treeName);
        }
        #endregion

        #region TOOLTECNO
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

        public string GetFieldName(string field, string value)
        {
            var fielDef = dbManager.GetTecnoField(field);
            return fielDef.SubFields.FirstOrDefault(s => s.Value == Convert.ToInt32(value)).Name;
        }

        public string GetFieldSideImage(string value)
        {
            var fielDef = dbManager.GetTecnoField("codSide");
            return fielDef.SubFields.FirstOrDefault(s => s.Value == Convert.ToInt32(value)).ImageName;
        }

        public void GetFieldImages()
        {
            AddImages("codWork");
            AddImages("codSide");
            AddImages("codSubWork");
        }

        private void AddImages(string subName)
        {
            string baseImageFolder = @"C:\Albatros\System\Tecno\Img\UTE\TREE\";
            var subs = dbManager.GetFieldDefs(subName);
            foreach (var sub in subs)
            {
                string imgFile = baseImageFolder + sub.ImageName;
                if (File.Exists(imgFile))
                {
                    Globals.TreeViewImages.Images.Add(sub.Name, Image.FromFile(imgFile));
                }
            }
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
        #endregion

        #region TOOLDATA
        public List<ToolData> GetTools(string workName, string sideName, string subWorkName)
        {
            int workValue = dbManager.GetToolTecnoFieldValue("codWork", workName);
            int sideValue = dbManager.GetToolTecnoFieldValue("codSide", sideName);
            int subWorkValue = dbManager.GetToolTecnoFieldValue("codSubWork", subWorkName);

            return dbManager.GetTools(tData =>
                                        tData.ToolFields.Any(f => f.Name == "codWork" && f.Value == workValue.ToString()) &&
                                        tData.ToolFields.Any(f => f.Name == "codSide" && f.Value == sideValue.ToString()) &&
                                        tData.ToolFields.Any(f => f.Name == "codSubWork" && f.Value == subWorkValue.ToString())
                                      );

            //return dbManager.GetTools(workValue, sideValue, subWorkValue);
        }

        public List<ToolData> GetToolsForFeedTools(int workValue, int sideValue)
        {
            return dbManager.GetTools(tData => tData.ToolFields.Any(f => f.Name == "codWork" && f.Value == workValue.ToString()) &&
                                                    tData.ToolFields.Any(f => f.Name == "codSide" && (Convert.ToInt32(f.Value) & sideValue) != 0));

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

            var toolList = dbManager.GetTools(tData =>
                                        tData.ToolFields.Any(f => f.Name == "codWork" && f.Value == workValue.ToString()) &&
                                        tData.ToolFields.Any(f => f.Name == "codSide" && f.Value == sideValue.ToString()) &&
                                        tData.ToolFields.Any(f => f.Name == "codSubWork" && f.Value == subWorkValue.ToString())
                                      );

            return toolList.Where(t => t.ToolFields.Any(n => n.Value == toolName)).FirstOrDefault();
        }

        public ToolData GetTool(string toolName)
        {
            return dbManager.GetTools(t => t.ToolFields.Any(n => n.Name == "description" && n.Value == toolName)).FirstOrDefault();
        }

        public string GetToolValue(ToolData toolData, string fieldName)
        {
            fieldName = fieldName.Replace("[0]", "");
            var tField = toolData.ToolFields.Where(v => v.Name == fieldName).FirstOrDefault();
            string tValue = tField == null ? "0" : tField.Type.Contains("[]") ? tField.Value.Split(';')[0] : tField.Value;

            return tValue;
        }

        public void SetToolValue(ToolData toolData, string fieldName, string value)
        {
            fieldName = fieldName.Replace("[0]", "");
            var tField = toolData.ToolFields.Where(v => v.Name == fieldName).FirstOrDefault();
            if (tField.Type.Contains("[]"))
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

        public ToolData CopyTool(ToolData toolData)
        {
            var copiedTool = dbManager.CopyTool(toolData);

            // Description alanını güncelle
            var descriptionField = copiedTool.ToolFields.FirstOrDefault(tf => tf.Name == "description");
            string codWorkField = GetToolValue(copiedTool, "codWork");
            string codSideField = GetToolValue(copiedTool, "codSide");
            string codSubWorkField = GetToolValue(copiedTool, "codSubWork");

            if (descriptionField != null)
            {
                string baseDescription = descriptionField.Value.ToString();
                int counter = 1;
                string newDescription = baseDescription + "_" + counter;

                List<ToolData> existingTools = GetTools(codWorkField, codSideField, codSubWorkField);
                while (existingTools.Any(td => td.ToolFields.Any(tf => tf.Name == "description" && tf.Value.ToString() == newDescription)))
                {
                    counter++;
                    newDescription = baseDescription + "_" + counter;
                }

                descriptionField.Value = newDescription;
            }

            AddToolOnList(copiedTool);

            return copiedTool;
        }
        #endregion

        #region OUTFDATA
        public List<ToolName> GetFeeds()
        {
            return dbManager.GetOutfData(0);
        }

        public void AddFeed(string pos, string name)
        {
            dbManager.AddFeed(new ToolName { Group = 1, Position = Convert.ToInt32(pos), Value = name });
        }
        public void RemoveFeed(string pos)
        {
            var removedFeed = GetFeeds().Where(t => t.Position == Convert.ToInt32(pos)).FirstOrDefault();
            dbManager.RemoveFeed(removedFeed);
        }
        public void UpdateFeed(string pos, string name)
        {
            GetFeeds().Where(t => t.Position == Convert.ToInt32(pos)).FirstOrDefault().Value = name;
        }

        public ToolName GetFeed(string pos)
        {
            var feeds = dbManager.GetOutfData(0);
            var tool = feeds.FirstOrDefault(t => t.Position == Convert.ToInt32(pos));
            return tool;
        }

        public bool isPlugTool(string pos, string name)
        {
            var feeds = dbManager.GetOutfData(0);
            var tool = feeds.FirstOrDefault(t => t.Position != Convert.ToInt32(pos) && t.Value == name);
            return tool != null ? true : false;
        }
        #endregion

        #region TECDATA
        public List<Spindle> GetCorrectors()
        {
            return dbManager.GetCorrectors();
        }
        #endregion

        #region General Methods
        public string ReadMessage(string msgNo, string langFile)
        {
            return XmlFileRead.LanguageRead(msgNo, Globals.CurLang, langFile);
        }
        #endregion

    }
}
