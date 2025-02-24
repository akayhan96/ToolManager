using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ToolManager.Entity
{
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(TechnologicalParameters));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (TechnologicalParameters)serializer.Deserialize(reader);
    // }

    [XmlRoot(ElementName = "Spindle")]
    public class Spindle
    {

        [XmlElement(ElementName = "CorrectorX")]
        public int CorrectorX { get; set; }

        [XmlElement(ElementName = "CorrectorY")]
        public int CorrectorY { get; set; }

        [XmlElement(ElementName = "CorrectorZ")]
        public int CorrectorZ { get; set; }

        [XmlElement(ElementName = "SideMask")]
        public int SideMask { get; set; }

        [XmlElement(ElementName = "WorkType")]
        public int WorkType { get; set; }

        [XmlElement(ElementName = "ToolChangeNumber")]
        public int ToolChangeNumber { get; set; }

        [XmlElement(ElementName = "ToolChangeBush")]
        public int ToolChangeBush { get; set; }

        [XmlElement(ElementName = "RelativeAggregate")]
        public int RelativeAggregate { get; set; }

        [XmlElement(ElementName = "DepthLimit")]
        public int DepthLimit { get; set; }

        [XmlElement(ElementName = "MaximumDiameterAllowed")]
        public int MaximumDiameterAllowed { get; set; }

        [XmlElement(ElementName = "MaximumLengthAllowed")]
        public int MaximumLengthAllowed { get; set; }

        [XmlElement(ElementName = "DistanceNextPosition")]
        public int DistanceNextPosition { get; set; }

        [XmlElement(ElementName = "CorsaPneumaticaBoccola")]
        public int CorsaPneumaticaBoccola { get; set; }

        [XmlElement(ElementName = "DirezionePneumatica")]
        public int DirezionePneumatica { get; set; }

        [XmlElement(ElementName = "ToolWear")]
        public int ToolWear { get; set; }

        [XmlElement(ElementName = "ToolWear2")]
        public int ToolWear2 { get; set; }

        [XmlElement(ElementName = "CustParam1")]
        public int CustParam1 { get; set; }

        [XmlElement(ElementName = "CustParam2")]
        public int CustParam2 { get; set; }

        [XmlElement(ElementName = "CustParam3")]
        public int CustParam3 { get; set; }

        [XmlElement(ElementName = "CustParam4")]
        public int CustParam4 { get; set; }

        [XmlElement(ElementName = "CustParam5")]
        public int CustParam5 { get; set; }

        [XmlElement(ElementName = "CustParam6")]
        public int CustParam6 { get; set; }

        [XmlElement(ElementName = "CustParam7")]
        public int CustParam7 { get; set; }

        [XmlElement(ElementName = "CustParam8")]
        public int CustParam8 { get; set; }

        [XmlElement(ElementName = "CustParam9")]
        public int CustParam9 { get; set; }

        [XmlElement(ElementName = "CustParam10")]
        public int CustParam10 { get; set; }

        [XmlAttribute(AttributeName = "Index")]
        public int Index { get; set; }

        [XmlText]
        public double Text { get; set; }
    }

    [XmlRoot(ElementName = "Aggregate")]
    public class Aggregate
    {

        [XmlElement(ElementName = "CorrectorX")]
        public int CorrectorX { get; set; }

        [XmlElement(ElementName = "CorrectorY")]
        public int CorrectorY { get; set; }

        [XmlElement(ElementName = "CorrectorZ")]
        public int CorrectorZ { get; set; }

        [XmlElement(ElementName = "OffsetC")]
        public int OffsetC { get; set; }

        [XmlElement(ElementName = "OffsetB")]
        public int OffsetB { get; set; }

        [XmlElement(ElementName = "SideMask")]
        public int SideMask { get; set; }

        [XmlElement(ElementName = "CRotationInfo")]
        public int CRotationInfo { get; set; }

        [XmlElement(ElementName = "MaxRPM")]
        public int MaxRPM { get; set; }

        [XmlElement(ElementName = "DirezionePneumatica")]
        public int DirezionePneumatica { get; set; }

        [XmlElement(ElementName = "Piston1")]
        public int Piston1 { get; set; }

        [XmlElement(ElementName = "Piston2")]
        public int Piston2 { get; set; }

        [XmlElement(ElementName = "Piston3")]
        public int Piston3 { get; set; }

        [XmlElement(ElementName = "SpindleType")]
        public int SpindleType { get; set; }

        [XmlElement(ElementName = "Offset1")]
        public int Offset1 { get; set; }

        [XmlElement(ElementName = "Offset2")]
        public int Offset2 { get; set; }

        [XmlElement(ElementName = "Offset3")]
        public int Offset3 { get; set; }

        [XmlElement(ElementName = "Offset4")]
        public int Offset4 { get; set; }

        [XmlElement(ElementName = "Offset5")]
        public int Offset5 { get; set; }

        [XmlElement(ElementName = "CustParam1")]
        public int CustParam1 { get; set; }

        [XmlElement(ElementName = "CustParam2")]
        public int CustParam2 { get; set; }

        [XmlElement(ElementName = "CustParam3")]
        public int CustParam3 { get; set; }

        [XmlElement(ElementName = "CustParam4")]
        public int CustParam4 { get; set; }

        [XmlElement(ElementName = "CustParam5")]
        public int CustParam5 { get; set; }

        [XmlElement(ElementName = "CustParam6")]
        public int CustParam6 { get; set; }

        [XmlElement(ElementName = "CustParam7")]
        public int CustParam7 { get; set; }

        [XmlElement(ElementName = "CustParam8")]
        public int CustParam8 { get; set; }

        [XmlElement(ElementName = "CustParam9")]
        public int CustParam9 { get; set; }

        [XmlElement(ElementName = "CustParam10")]
        public int CustParam10 { get; set; }

        [XmlAttribute(AttributeName = "Index")]
        public int Index { get; set; }

        [XmlText]
        public double Text { get; set; }
    }

    [XmlRoot(ElementName = "Corrector")]
    public class Corrector
    {

        [XmlElement(ElementName = "Spindle")]
        public List<Spindle> Spindle { get; set; }

        [XmlElement(ElementName = "Aggregate")]
        public Aggregate Aggregate { get; set; }

        [XmlAttribute(AttributeName = "Group")]
        public int Group { get; set; }

        [XmlText]
        public double Text { get; set; }
    }

    [XmlRoot(ElementName = "Correctors")]
    public class Correctors
    {

        [XmlElement(ElementName = "Corrector")]
        public List<Corrector> Corrector { get; set; }
    }

    [XmlRoot(ElementName = "Field")]
    public class MachineField
    {

        [XmlElement(ElementName = "OffsetX")]
        public int OffsetX { get; set; }

        [XmlElement(ElementName = "OffsetY")]
        public int OffsetY { get; set; }

        [XmlElement(ElementName = "FieldKind")]
        public int FieldKind { get; set; }

        [XmlAttribute(AttributeName = "FieldName")]
        public string FieldName { get; set; }

        [XmlText]
        public int Text { get; set; }
    }

    [XmlRoot(ElementName = "MachineFields")]
    public class MachineFields
    {

        [XmlElement(ElementName = "Field")]
        public List<MachineField> Field { get; set; }

        [XmlAttribute(AttributeName = "Index")]
        public int Index { get; set; }

        [XmlAttribute(AttributeName = "PushingReference")]
        public int PushingReference { get; set; }

        [XmlAttribute(AttributeName = "MirrorOnNormalFieldReference")]
        public int MirrorOnNormalFieldReference { get; set; }

        [XmlAttribute(AttributeName = "NormalOnMirrorFieldReference")]
        public int NormalOnMirrorFieldReference { get; set; }

        [XmlText]
        public int Text { get; set; }
    }

    [XmlRoot(ElementName = "HeadOffset")]
    public class HeadOffset
    {

        [XmlElement(ElementName = "OffsetX_Head")]
        public int OffsetXHead { get; set; }

        [XmlElement(ElementName = "OffsetY_Head")]
        public double OffsetYHead { get; set; }

        [XmlElement(ElementName = "OffsetZ_Head")]
        public double OffsetZHead { get; set; }

        [XmlElement(ElementName = "LimitMin_Y2")]
        public int LimitMinY2 { get; set; }

        [XmlElement(ElementName = "LimitMax_Y2")]
        public int LimitMaxY2 { get; set; }

        [XmlElement(ElementName = "MinimumHead_Height")]
        public int MinimumHeadHeight { get; set; }

        [XmlElement(ElementName = "MinimumDrillHead_Height")]
        public int MinimumDrillHeadHeight { get; set; }

        [XmlElement(ElementName = "RangeTools")]
        public object RangeTools { get; set; }

        [XmlAttribute(AttributeName = "Group")]
        public int Group { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "MachineParameters")]
    public class MachineParameters
    {
        [XmlElement(ElementName = "HeadOffset")]
        public List<HeadOffset> HeadOffset { get; set; }
    }

    [XmlRoot(ElementName = "LineParameters")]
    public class LineParameters
    {

        [XmlElement(ElementName = "MachineParameters")]
        public List<MachineParameters> MachineParameters { get; set; }
    }

    [XmlRoot(ElementName = "TechnologicalParameters")]
    public class TechnologicalParameters
    {

        [XmlElement(ElementName = "Correctors")]
        public Correctors Correctors { get; set; }

        [XmlElement(ElementName = "LineParameters")]
        public LineParameters LineParameters { get; set; }

    }


}
