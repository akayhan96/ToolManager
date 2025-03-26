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
        public double CorrectorX { get; set; }

        [XmlElement(ElementName = "CorrectorY")]
        public double CorrectorY { get; set; }

        [XmlElement(ElementName = "CorrectorZ")]
        public double CorrectorZ { get; set; }

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
        [XmlAttribute("Machine")]
        public int Machine { get; set; }

        [XmlElement(ElementName = "HeadOffset")]
        public List<HeadOffset> HeadOffset { get; set; }

        [XmlElement(ElementName = "WorkingFeed")]
        public WorkingFeed WorkingFeed { get; set; }

        [XmlElement(ElementName = "AirCoordinates")]
        public AirCoordinates AirCoordinates { get; set; }
    }

    public class WorkingFeed
    {
        [XmlElement("Routers_MaxInterpolationFeed")]
        public float Routers_MaxInterpolationFeed { get; set; }

        [XmlElement("Blade_MaxInterpolationFeed")]
        public float Blade_MaxInterpolationFeed { get; set; }

        [XmlElement("InSpeed_LateralHoles")]
        public float InSpeed_LateralHoles { get; set; }

        [XmlElement("InSpeed_VerticalHoles")]
        public float InSpeed_VerticalHoles { get; set; }

        [XmlElement("InSpeed_Routers")]
        public float InSpeed_Routers { get; set; }

        [XmlElement("InSpeed_Blades")]
        public float InSpeed_Blades { get; set; }

        [XmlElement("InSpeed_Inserters")]
        public float InSpeed_Inserters { get; set; }

        [XmlElement("InSpeed_Probe")]
        public float InSpeed_Probe { get; set; }

        [XmlElement("InsertedFilletFeed")]
        public float InsertedFilletFeed { get; set; }

        [XmlElement("SlowingPercentage_OnEntry")]
        public float SlowingPercentage_OnEntry { get; set; }

        [XmlElement("SlowingPercentage_OnExit")]
        public float SlowingPercentage_OnExit { get; set; }

        [XmlElement("MaxRPM_Router")]
        public float MaxRPM_Router { get; set; }

        [XmlElement("MaxRPM_Blade")]
        public float MaxRPM_Blade { get; set; }

        [XmlElement("MaxRPM_Spindle")]
        public float MaxRPM_Spindle { get; set; }
    }

    public class AirCoordinates
    {
        [XmlElement("Routers_Clearance")]
        public float Routers_Clearance { get; set; }

        [XmlElement("Blades_Clearance")]
        public float Blades_Clearance { get; set; }

        [XmlElement("HorizontalDrills_Clearance")]
        public float HorizontalDrills_Clearance { get; set; }

        [XmlElement("LateralDrills_Clearance")]
        public float LateralDrills_Clearance { get; set; }

        [XmlElement("VerticalDrills_Clearance")]
        public float VerticalDrills_Clearance { get; set; }

        [XmlElement("InserterTools_Clearance")]
        public float InserterTools_Clearance { get; set; }

        [XmlElement("MaxStops_Height")]
        public float MaxStops_Height { get; set; }

        [XmlElement("MaxVices_Height")]
        public float MaxVices_Height { get; set; }

        [XmlElement("MaxPiece_Height")]
        public float MaxPiece_Height { get; set; }

        [XmlElement("FreeBackSpace")]
        public float FreeBackSpace { get; set; }

        [XmlElement("FreeFrontSpace")]
        public float FreeFrontSpace { get; set; }

        [XmlElement("FreeSpaceUnderPod")]
        public float FreeSpaceUnderPod { get; set; }

        [XmlElement("MaxYPosition")]
        public float MaxYPosition { get; set; }

        [XmlElement("MinZPosition")]
        public float MinZPosition { get; set; }

        [XmlElement("MinXLeftPosition")]
        public float MinXLeftPosition { get; set; }

        [XmlElement("MinZLeftPosition")]
        public float MinZLeftPosition { get; set; }
    }

    [XmlRoot(ElementName = "LineParameters")]
    public class LineParameters
    {

        [XmlElement(ElementName = "MachineParameters")]
        public List<MachineParameters> MachineParameters { get; set; }
    }

    [XmlRoot(ElementName = "TechnologicalParameters")]
    public class TecData
    {
        [XmlElement("GeneralParameters")]
        public GeneralParameters GeneralParameters { get; set; }

        [XmlElement(ElementName = "Correctors")]
        public Correctors Correctors { get; set; }

        [XmlElement(ElementName = "LineParameters")]
        public LineParameters LineParameters { get; set; }

    }

    public class GeneralParameters
    {
        [XmlElement("ToolChanger")]
        public List<ToolChanger> ToolChangers { get; set; }
    }
    public class ToolChanger
    {
        [XmlAttribute("Index")]
        public int Index { get; set; }

        [XmlElement("Type")]
        public int Type { get; set; }

        [XmlElement("NumberOfBushes")]
        public int NumberOfBushes { get; set; }

        [XmlElement("FulcrumX")]
        public float FulcrumX { get; set; }

        [XmlElement("FulcrumY")]
        public float FulcrumY { get; set; }

        [XmlElement("DeltaX")]
        public float DeltaX { get; set; }

        [XmlElement("DeltaY")]
        public float DeltaY { get; set; }

        [XmlElement("IntegralWithHeadInX")]
        public bool IntegralWithHeadInX { get; set; }

        [XmlElement("IntegralWithHeadInY")]
        public bool IntegralWithHeadInY { get; set; }

        [XmlElement("X_PickUp_Coordinate")]
        public float XPickUpCoordinate { get; set; }

        [XmlElement("Y_PickUp_Coordinate")]
        public float YPickUpCoordinate { get; set; }

        [XmlElement("Z_PickUp_Coordinate")]
        public float ZPickUpCoordinate { get; set; }

        [XmlElement("ToolLoading_WaitingTime")]
        public int ToolLoadingWaitingTime { get; set; }

        [XmlElement("ToolUnloading_WaitingTime")]
        public int ToolUnloadingWaitingTime { get; set; }

        [XmlElement("ToolChange_InMaskedTime")]
        public bool ToolChangeInMaskedTime { get; set; }
    }



}
