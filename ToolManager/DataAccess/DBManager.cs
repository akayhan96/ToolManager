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
        private DBOutfits outfitData;
        private TecData tecData;
        private BushCfg bushCfg;

        private List<ToolChanger> BackupToolChangers;

        public DBManager()
        {
            toolTree = XmlSerialization.Deserialize<ToolTree>(Globals.XmlToolTree);
            toolTecno = XmlSerialization.Deserialize<ToolTecno>(Globals.XmlToolTecno);
            toolData = XmlSerialization.Deserialize<DBTools>(Globals.XmlToolData);
            outfitData = XmlSerialization.Deserialize<DBOutfits>(Globals.XmlOutfData);
            tecData = XmlSerialization.Deserialize<TecData>(Globals.XmlTecData);
            bushCfg = XmlSerialization.Deserialize<BushCfg>(Globals.XmlBushCfg);
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

        public FieldDef GetTecnoField(string field)
        {
            return toolTecno.ToolDef.FieldDefs.FirstOrDefault(fd => fd.Field == field);
        }

        public int GetToolTecnoFieldValue(string field, string subName)
        {
            var fieldDef = GetTecnoField(field);

            return fieldDef.SubFields.FirstOrDefault(s => s.Name == subName)?.Value ?? -1;
        }

        public List<SubField> GetFieldDefs(string field)
        {
            var fieldDef = toolTecno.ToolDef.FieldDefs.FirstOrDefault(fd => fd.Field == field);

            return fieldDef.SubFields;
        }

        public List<ToolData> GetTools(Expression<Func<ToolData, bool>> filter)
        {
            return toolData.ToolDataList.AsQueryable().Where(filter).ToList();
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

        public ToolData CopyTool(ToolData tool)
        {
            ToolData copiedTool = new ToolData
            {
                ToolFields = tool.ToolFields.Select(tf => new ToolField
                {
                    Name = tf.Name,
                    Type = tf.Type,
                    Value = tf.Value
                }).ToList()
            };

            return copiedTool;
        }

        public List<Field> GetToolFields()
        {
            return toolTecno.ToolDef.Tool.Fields;
        }

        public List<ToolName> GetOutfData(int index)
        {
            return outfitData.Outfits.FirstOrDefault(o => o.Index == index).ToolNames;
        }

        public List<Spindle> GetCorrectors(int group = 1)
        {
            var corrector = tecData.Correctors.Corrector.FirstOrDefault(c => c.Group == group);
            return corrector.Spindles;
        }

        public void AddFeed(ToolName feed)
        {
            GetOutfData(0).Add(feed);
        }
        public void RemoveFeed(ToolName feed)
        {
            GetOutfData(0).Remove(feed);
        }

        public ToolChanger GetChanger(int index)
        {
            ToolChanger changer = tecData.GeneralParameters.ToolChangers.Where(tc => tc.Index == index).FirstOrDefault();
            if(changer == null)
            {
                changer = new ToolChanger()
                {
                    Type = 0,
                    NumberOfBushes = 0,
                    FulcrumX = 0,
                    FulcrumY = 0,
                    DeltaX = 0,
                    DeltaY = 0,
                    IntegralWithHeadInX = false,
                    IntegralWithHeadInY = false,
                    XPickUpCoordinate = 0,
                    YPickUpCoordinate = 0,
                    ZPickUpCoordinate = 0,
                    ToolLoadingWaitingTime = 0,
                    ToolUnloadingWaitingTime = 0,
                    ToolChangeInMaskedTime = false
                };
            }

            return changer;
        }

        private void BackupChangers()
        {
            BackupToolChangers = tecData.GeneralParameters.ToolChangers;
        }

        public void RestoreChangers()
        {
            tecData.GeneralParameters.ToolChangers = BackupToolChangers;
        }

        public void AddChanger(ToolChanger toolChanger)
        {
            tecData.GeneralParameters.ToolChangers.Add(toolChanger);
        }

        public AirCoordinates GetAirCoordinate(int machine)
        {
            var machineParameters = tecData.LineParameters.MachineParameters.FirstOrDefault(m => m.Machine == machine);

            return machineParameters.AirCoordinates;
        }

        public WorkingFeed GetWorkingFeed(int machine)
        {
            var machineParameters = tecData.LineParameters.MachineParameters.FirstOrDefault(m => m.Machine == machine);

            return machineParameters.WorkingFeed;
        }

        public MachineFields GetMacField(int machine, int index)
        {
            var macParams = tecData.LineParameters.MachineParameters.FirstOrDefault(m => m.Machine == machine);
            var macField = macParams.MachineFields.FirstOrDefault(f => f.Index == index);

            return macField;
        }

        public HeadOffset GetHeadOffsets(int machine, int group)
        {
            var machineParameters = tecData.LineParameters.MachineParameters.FirstOrDefault(m => m.Machine == machine);

            return machineParameters.HeadOffset.FirstOrDefault(h => h.Group == group);
        }

        public List<Aggregate> GetAggregates(int group)
        {
            var correctors = tecData.Correctors.Corrector.FirstOrDefault(c => c.Group == group);

            return correctors.Aggregates;
        }

        public List<SubElemSideType> GetSideTypes()
        {
            return bushCfg.SideTypes;
        }
        public List<ElemStart> GetWorkTypes()
        {
            return bushCfg.ToolTypes;
        }


        public void SaveToolTree()
        {
            XmlSerialization.Serialize<ToolTree>(toolTree,Globals.XmlToolTree);
        }

        public void SaveDbTools()
        {
            XmlSerialization.Serialize<DBTools>(toolData,Globals.XmlToolData);
        }

        public void SaveDbOutfit()
        {
            XmlSerialization.Serialize<DBOutfits>(outfitData,Globals.XmlOutfData);
        }

        public void SaveTecData()
        {
            XmlSerialization.Serialize<TecData>(tecData,Globals.XmlTecData);
        }
    }
}
