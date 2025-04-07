using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ToolManager.Entity
{
    [XmlRoot(ElementName = "TechnologicalParameters")]
    public class TecData
    {
        [XmlAttribute(AttributeName = "version")]
        public double Version { get; set; }

        [XmlElement("GeneralParameters")]
        public GeneralParameters GeneralParameters { get; set; }

        [XmlElement(ElementName = "Correctors")]
        public Correctors Correctors { get; set; }

        [XmlElement(ElementName = "LineParameters")]
        public LineParameters LineParameters { get; set; }
    }
    //-------------------/GeneralParameters--------------------------------
    public class GeneralParameters
    {
        [XmlElement("VersionInfo")]
        public VersionInfo VersionInfo { get; set; }

        [XmlElement("ToolChanger")]
        public List<ToolChanger> ToolChangers { get; set; }
    }

    public class VersionInfo
    {
        [XmlElement("Software_Version")]
        public string Software_Version { get; set; }

        [XmlElement("Software_Data")]
        public string Software_Data { get; set; }

        [XmlElement("Firmware_Version")]
        public string Firmware_Version { get; set; }

        [XmlElement("Firmware_Data")]
        public string Firmware_Data { get; set; }
    }

    public class ToolChanger
    {
        [XmlAttribute(AttributeName = "Index")]
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
        public int IntegralWithHeadInX { get; set; }

        [XmlElement("IntegralWithHeadInY")]
        public int IntegralWithHeadInY { get; set; }

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
        public int ToolChangeInMaskedTime { get; set; }
    }
    //-------------------GeneralParameters/--------------------------------

    //-------------------/Correctors---------------------------------------
    [XmlRoot(ElementName = "Correctors")]
    public class Correctors
    {
        [XmlElement(ElementName = "Corrector")]
        public List<Corrector> Corrector { get; set; }
    }

    [XmlRoot(ElementName = "Corrector")]
    public class Corrector
    {

        [XmlElement(ElementName = "Spindle")]
        public List<Spindle> Spindles { get; set; }

        [XmlElement(ElementName = "Aggregate")]
        public List<Aggregate> Aggregates { get; set; }

        [XmlAttribute(AttributeName = "Group")]
        public int Group { get; set; }
    }

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
        public double DepthLimit { get; set; }

        [XmlElement(ElementName = "MaximumDiameterAllowed")]
        public int MaximumDiameterAllowed { get; set; }

        [XmlElement(ElementName = "MaximumLengthAllowed")]
        public int MaximumLengthAllowed { get; set; }

        [XmlElement(ElementName = "DistanceNextPosition")]
        public double DistanceNextPosition { get; set; }

        [XmlElement(ElementName = "CorsaPneumaticaBoccola")]
        public int CorsaPneumaticaBoccola { get; set; }

        [XmlElement(ElementName = "DirezionePneumatica")]
        public int DirezionePneumatica { get; set; }

        [XmlElement(ElementName = "ToolWear")]
        public double ToolWear { get; set; }

        [XmlElement(ElementName = "ToolWear2")]
        public double ToolWear2 { get; set; }

        [XmlElement(ElementName = "CustParam1")]
        public double CustParam1 { get; set; }

        [XmlElement(ElementName = "CustParam2")]
        public double CustParam2 { get; set; }

        [XmlElement(ElementName = "CustParam3")]
        public double CustParam3 { get; set; }

        [XmlElement(ElementName = "CustParam4")]
        public double CustParam4 { get; set; }

        [XmlElement(ElementName = "CustParam5")]
        public double CustParam5 { get; set; }

        [XmlElement(ElementName = "CustParam6")]
        public double CustParam6 { get; set; }

        [XmlElement(ElementName = "CustParam7")]
        public double CustParam7 { get; set; }

        [XmlElement(ElementName = "CustParam8")]
        public double CustParam8 { get; set; }

        [XmlElement(ElementName = "CustParam9")]
        public double CustParam9 { get; set; }

        [XmlElement(ElementName = "CustParam10")]
        public double CustParam10 { get; set; }

        [XmlAttribute(AttributeName = "Index")]
        public int Index { get; set; }
    }

    [XmlRoot(ElementName = "Aggregate")]
    public class Aggregate
    {

        [XmlElement(ElementName = "CorrectorX")]
        public double CorrectorX { get; set; }

        [XmlElement(ElementName = "CorrectorY")]
        public double CorrectorY { get; set; }

        [XmlElement(ElementName = "CorrectorZ")]
        public double CorrectorZ { get; set; }

        [XmlElement(ElementName = "OffsetC")]
        public double OffsetC { get; set; }

        [XmlElement(ElementName = "OffsetB")]
        public double OffsetB { get; set; }

        [XmlElement(ElementName = "SideMask")]
        public int SideMask { get; set; }

        [XmlElement(ElementName = "CRotationInfo")]
        public int CRotationInfo { get; set; }

        [XmlElement(ElementName = "MaxRPM")]
        public int MaxRPM { get; set; }

        [XmlElement(ElementName = "DirezionePneumatica")]
        public int DirezionePneumatica { get; set; }

        [XmlElement(ElementName = "Piston1")]
        public double Piston1 { get; set; }

        [XmlElement(ElementName = "Piston2")]
        public double Piston2 { get; set; }

        [XmlElement(ElementName = "Piston3")]
        public double Piston3 { get; set; }

        [XmlElement(ElementName = "SpindleType")]
        public int SpindleType { get; set; }

        [XmlElement(ElementName = "Offset1")]
        public double Offset1 { get; set; }

        [XmlElement(ElementName = "Offset2")]
        public double Offset2 { get; set; }

        [XmlElement(ElementName = "Offset3")]
        public double Offset3 { get; set; }

        [XmlElement(ElementName = "Offset4")]
        public double Offset4 { get; set; }

        [XmlElement(ElementName = "Offset5")]
        public double Offset5 { get; set; }

        [XmlElement(ElementName = "CustParam1")]
        public double CustParam1 { get; set; }

        [XmlElement(ElementName = "CustParam2")]
        public double CustParam2 { get; set; }

        [XmlElement(ElementName = "CustParam3")]
        public double CustParam3 { get; set; }

        [XmlElement(ElementName = "CustParam4")]
        public double CustParam4 { get; set; }

        [XmlElement(ElementName = "CustParam5")]
        public double CustParam5 { get; set; }

        [XmlElement(ElementName = "CustParam6")]
        public double CustParam6 { get; set; }

        [XmlElement(ElementName = "CustParam7")]
        public double CustParam7 { get; set; }

        [XmlElement(ElementName = "CustParam8")]
        public double CustParam8 { get; set; }

        [XmlElement(ElementName = "CustParam9")]
        public double CustParam9 { get; set; }

        [XmlElement(ElementName = "CustParam10")]
        public double CustParam10 { get; set; }

        [XmlAttribute(AttributeName = "Index")]
        public int Index { get; set; }

    }

    //-------------------Correctors/---------------------------------------

    //-------------------/LineParameters-----------------------------------
    [XmlRoot(ElementName = "LineParameters")]
    public class LineParameters
    {
        [XmlElement(ElementName = "MachineParameters")]
        public List<MachineParameters> MachineParameters { get; set; }
    }

    [XmlRoot(ElementName = "MachineParameters")]
    public class MachineParameters
    {
        [XmlAttribute("Machine")]
        public int Machine { get; set; }

        [XmlElement(ElementName = "WorkingFeed")]
        public WorkingFeed WorkingFeed { get; set; }

        [XmlElement(ElementName = "AirCoordinates")]
        public AirCoordinates AirCoordinates { get; set; }

        [XmlElement(ElementName = "GrippersData")]
        public GrippersData GrippersData { get; set; }
        [XmlElement(ElementName = "GeneralData")]
        public GeneralData GeneralData { get; set; }

        [XmlElement(ElementName = "MachineFields")]
        public List<MachineFields> MachineFields { get; set; }

        [XmlElement(ElementName = "HeadOffset")]
        public List<HeadOffset> HeadOffset { get; set; }
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

    public class GrippersData
    {
        [XmlElement("XDimension")]
        public float XDimension { get; set; }

        [XmlElement("YDimension")]
        public float YDimension { get; set; }

        [XmlElement("ZDimension")]
        public float ZDimension { get; set; }

        [XmlElement("ZDimensionUnderPiece")]
        public float ZDimensionUnderPiece { get; set; }

        [XmlElement("BackClampEnabled")]
        public bool BackClampEnabled { get; set; }

        [XmlElement("MinimumDistance")]
        public float MinimumDistance { get; set; }

        [XmlElement("ClampOnPiecePercentage")]
        public float ClampOnPiecePercentage { get; set; }

        [XmlElement("XPositionWindow")]
        public float XPositionWindow { get; set; }

        [XmlElement("WindowWidth")]
        public float WindowWidth { get; set; }

        [XmlElement("WindowHeight")]
        public float WindowHeight { get; set; }

        [XmlElement("XCorFrontClamp")]
        public float XCorFrontClamp { get; set; }

        [XmlElement("XCorBackClamp")]
        public float XCorBackClamp { get; set; }

        [XmlElement("XParkFrontClamp")]
        public float XParkFrontClamp { get; set; }

        [XmlElement("XParkBackClamp")]
        public float XParkBackClamp { get; set; }

        [XmlElement("OpenClampTime")]
        public float OpenClampTime { get; set; }

        [XmlElement("CloseClampTime")]
        public float CloseClampTime { get; set; }

        [XmlElement("PressersDowmTime")]
        public float PressersDowmTime { get; set; }

        [XmlElement("PressersUpTime")]
        public float PressersUpTime { get; set; }

        [XmlElement("PusherXStartCorrector")]
        public float PusherXStartCorrector { get; set; }

        [XmlElement("PusherXEndCorrector")]
        public float PusherXEndCorrector { get; set; }

        [XmlElement("MinLengthPieceTwoGrippers")]
        public float MinLengthPieceTwoGrippers { get; set; }
    }

    public class GeneralData { }

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
    }

    [XmlRoot(ElementName = "Field")]
    public class MachineField
    {

        [XmlElement(ElementName = "OffsetX")]
        public double OffsetX { get; set; }

        [XmlElement(ElementName = "OffsetY")]
        public double OffsetY { get; set; }

        [XmlElement(ElementName = "FieldKind")]
        public int FieldKind { get; set; }

        [XmlAttribute(AttributeName = "FieldName")]
        public string FieldName { get; set; }
    }

    [XmlRoot(ElementName = "HeadOffset")]
    public class HeadOffset
    {

        [XmlElement(ElementName = "OffsetX_Head")]
        public double OffsetXHead { get; set; }

        [XmlElement(ElementName = "OffsetY_Head")]
        public double OffsetYHead { get; set; }

        [XmlElement(ElementName = "OffsetZ_Head")]
        public double OffsetZHead { get; set; }

        [XmlElement(ElementName = "LimitMin_Y2")]
        public double LimitMinY2 { get; set; }

        [XmlElement(ElementName = "LimitMax_Y2")]
        public double LimitMaxY2 { get; set; }

        [XmlElement(ElementName = "MinimumHead_Height")]
        public double MinimumHeadHeight { get; set; }

        [XmlElement(ElementName = "MinimumDrillHead_Height")]
        public double MinimumDrillHeadHeight { get; set; }

        [XmlElement(ElementName = "RangeTools")]
        public object RangeTools { get; set; }

        [XmlAttribute(AttributeName = "Group")]
        public int Group { get; set; }
    }

    //-------------------LineParameters/-----------------------------------
}
