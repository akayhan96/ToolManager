using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolManager
{
    public partial class form_TechnologicalParameters : Form
    {
        #region Forms
        public form_TechnologicalParameters()
        {
            InitializeComponent();
        }

        private void form_TechnologicalParameters_Load(object sender, EventArgs e)
        {
            LoadSystemParameters();
            LoadGeneralParamValues();

            tcTecnoParams.Appearance = tcCorrectors.Appearance = tcGeneralParams.Appearance = TabAppearance.FlatButtons;
            tcTecnoParams.ItemSize = tcCorrectors.ItemSize = tcGeneralParams.ItemSize = new Size(0, 1);
            tcTecnoParams.SizeMode = tcCorrectors.SizeMode = tcGeneralParams.SizeMode = TabSizeMode.Fixed;

            FillText_GeneralParameters();
        }

        private void FillText_GeneralParameters()
        {
            rBtnPushReff.Text = rBtnPushReff2.Text = XmlFileRead.LanguageRead("4544", Globals.CurLang, Globals.XmlngTecnoManager);
            rBtnPullReff.Text = rBtnPullReff2.Text = XmlFileRead.LanguageRead("4545", Globals.CurLang, Globals.XmlngTecnoManager);
            cbxMirrorOnNormalFieldReference.Text = cbxMirrorOnNormalFieldReference2.Text = XmlFileRead.LanguageRead("4546", Globals.CurLang, Globals.XmlngTecnoManager);
            cbxNormalOnMirrorFieldReference.Text = cbxNormalOnMirrorFieldReference2.Text = XmlFileRead.LanguageRead("4547", Globals.CurLang, Globals.XmlngTecnoManager);
            btnWorkField.Text = tpWF1.Text = XmlFileRead.LanguageRead("4548", Globals.CurLang, Globals.XmlngTecnoManager);
            tpWF2.Text = XmlFileRead.LanguageRead("4548", Globals.CurLang, Globals.XmlngTecnoManager) + " 1";

            lblRouterFeed.Text = XmlFileRead.LanguageRead("4700", Globals.CurLang, Globals.XmlngTecnoManager);
            lblBladeFeed.Text = XmlFileRead.LanguageRead("4701", Globals.CurLang, Globals.XmlngTecnoManager);
            lblSpeedLateral.Text = XmlFileRead.LanguageRead("4702", Globals.CurLang, Globals.XmlngTecnoManager);
            lblSpeedVertical.Text = XmlFileRead.LanguageRead("4703", Globals.CurLang, Globals.XmlngTecnoManager);
            lblSpeedRouter.Text = XmlFileRead.LanguageRead("4704", Globals.CurLang, Globals.XmlngTecnoManager);
            lblSpeedBlade.Text = XmlFileRead.LanguageRead("4705", Globals.CurLang, Globals.XmlngTecnoManager);
            lblSpeedInserterTool.Text = XmlFileRead.LanguageRead("4706", Globals.CurLang, Globals.XmlngTecnoManager);
            lblSpeedProbe.Text = XmlFileRead.LanguageRead("4707", Globals.CurLang, Globals.XmlngTecnoManager);
            lblFilletFeed.Text = XmlFileRead.LanguageRead("4708", Globals.CurLang, Globals.XmlngTecnoManager);
            lblSlowEntry.Text = XmlFileRead.LanguageRead("4709", Globals.CurLang, Globals.XmlngTecnoManager);
            lblSlowExit.Text = XmlFileRead.LanguageRead("4710", Globals.CurLang, Globals.XmlngTecnoManager);
            lblMaxRPMRouter.Text = XmlFileRead.LanguageRead("4711", Globals.CurLang, Globals.XmlngTecnoManager);
            lblMaxRPMSpindle.Text = XmlFileRead.LanguageRead("4712", Globals.CurLang, Globals.XmlngTecnoManager);
            lblMaxRPMBlade.Text = XmlFileRead.LanguageRead("4713", Globals.CurLang, Globals.XmlngTecnoManager);
            btnWorkFeed.Text = XmlFileRead.LanguageRead("4714", Globals.CurLang, Globals.XmlngTecnoManager);

            lblRouter.Text = XmlFileRead.LanguageRead("4400", Globals.CurLang, Globals.XmlngTecnoManager);
            lblBlade.Text = XmlFileRead.LanguageRead("4401", Globals.CurLang, Globals.XmlngTecnoManager);
            lblHorDrill.Text = XmlFileRead.LanguageRead("4402", Globals.CurLang, Globals.XmlngTecnoManager);
            lblLateralDrill.Text = XmlFileRead.LanguageRead("4403", Globals.CurLang, Globals.XmlngTecnoManager);
            lblVerDrill.Text = XmlFileRead.LanguageRead("4404", Globals.CurLang, Globals.XmlngTecnoManager);
            lblInserterTool.Text = XmlFileRead.LanguageRead("4405", Globals.CurLang, Globals.XmlngTecnoManager);
            lblMaxStopHeight.Text = XmlFileRead.LanguageRead("4406", Globals.CurLang, Globals.XmlngTecnoManager);
            lblMaxVicesHeight.Text = XmlFileRead.LanguageRead("4407", Globals.CurLang, Globals.XmlngTecnoManager);
            btnDistDim.Text = XmlFileRead.LanguageRead("4410", Globals.CurLang, Globals.XmlngTecnoManager);
            lblMaxPieceHeight.Text = XmlFileRead.LanguageRead("4411", Globals.CurLang, Globals.XmlngTecnoManager);
            lblFreeBackSpace.Text = XmlFileRead.LanguageRead("4412", Globals.CurLang, Globals.XmlngTecnoManager);
            lblFreeFrontSpace.Text = XmlFileRead.LanguageRead("4413", Globals.CurLang, Globals.XmlngTecnoManager);
            lblFreeSpaceUnderPod.Text = XmlFileRead.LanguageRead("4414", Globals.CurLang, Globals.XmlngTecnoManager);
            lblMaxYPos.Text = XmlFileRead.LanguageRead("4415", Globals.CurLang, Globals.XmlngTecnoManager);
            lblMinZPos.Text = XmlFileRead.LanguageRead("4416", Globals.CurLang, Globals.XmlngTecnoManager);
            lblMinXLeftPos.Text = XmlFileRead.LanguageRead("4417", Globals.CurLang, Globals.XmlngTecnoManager);
            lblMinZLeftPos.Text = XmlFileRead.LanguageRead("4418", Globals.CurLang, Globals.XmlngTecnoManager);
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region System Parameters
        private void pbSystemParams_Click(object sender, EventArgs e)
        {
            tcTecnoParams.SelectedTab = tpSystemParams;
        }

        private void LoadSystemParameters()
        {
            List<string> tcTypes = new List<string>();
            tcTypes.Add("Not Present");
            tcTypes.Add("Linear");
            tcTypes.Add("Carousel");
            tcTypes.Add("Chain");
            tcTypes.Add("Multi");
            cbTCType.DataSource = tcTypes;

            //---------------------------------------------------

            LoadSysParamValues();
        }

        private void LoadSysParamValues()
        {
            var toolChanger = Globals.serviceManager.GetToolChanger((int)nudTcId.Value);
            cbTCType.SelectedIndex = toolChanger.Type;
            tbxNumberBush.Text = toolChanger.NumberOfBushes.ToString();
            tbxFulcrumX.Text = toolChanger.FulcrumX.ToString();
            tbxFulcrumY.Text = toolChanger.FulcrumY.ToString();
            tbxDeltaX.Text = toolChanger.DeltaX.ToString();
            tbxDeltaY.Text = toolChanger.DeltaY.ToString();
            tbxPosX.Text = toolChanger.XPickUpCoordinate.ToString();
            tbxPosY.Text = toolChanger.YPickUpCoordinate.ToString();
            tbxPosZ.Text = toolChanger.ZPickUpCoordinate.ToString();
            tbxLoadTime.Text = toolChanger.ToolLoadingWaitingTime.ToString();
            tbxUnloadTime.Text = toolChanger.ToolUnloadingWaitingTime.ToString();

            if (toolChanger.IntegralWithHeadInX == false && toolChanger.IntegralWithHeadInY == false)
            {
                chkWithBench.Checked = true;
            }
            else
            {
                chkWithX.Checked = toolChanger.IntegralWithHeadInX;
                chkWithY.Checked = toolChanger.IntegralWithHeadInY;
            }

            chkTCTime.Checked = toolChanger.ToolChangeInMaskedTime;
        }
        private void nudTcId_ValueChanged(object sender, EventArgs e)
        {
            LoadSysParamValues();
        }

        private void chkWithBench_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWithBench.Checked)
            {
                chkWithX.Checked = false;
                chkWithY.Checked = false;
            }
        }

        private void chkWithX_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWithX.Checked)
            {
                chkWithBench.Checked = false;
            }
        }

        private void chkWithY_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWithY.Checked)
            {
                chkWithBench.Checked = false;
            }
        }

        #endregion

        #region General Parameters
        private void pbGeneralParams_Click(object sender, EventArgs e)
        {
            tcTecnoParams.SelectedTab = tpGeneralParams;
        }
        private void btnDistDim_Click(object sender, EventArgs e)
        {
            tcGeneralParams.SelectedTab = tpDistanceParams;
        }

        private void btnWorkFeed_Click(object sender, EventArgs e)
        {
            tcGeneralParams.SelectedTab = tpWorkParams;
        }

        private void btnWorkField_Click(object sender, EventArgs e)
        {
            tcGeneralParams.SelectedTab = tpWorkFieldParams;
        }

        private void LoadGeneralParamValues()
        {
            var airCoordinate = Globals.serviceManager.GetDistanceDimensions(1);
            tbxRouter.Text = airCoordinate.Routers_Clearance.ToString();
            tbxBlade.Text = airCoordinate.Blades_Clearance.ToString();
            tbxHorDrill.Text = airCoordinate.HorizontalDrills_Clearance.ToString();
            tbxLateralDrill.Text = airCoordinate.LateralDrills_Clearance.ToString();
            tbxVerDrill.Text = airCoordinate.VerticalDrills_Clearance.ToString();
            tbxInserterTool.Text = airCoordinate.InserterTools_Clearance.ToString();
            tbxMaxStopHeight.Text = airCoordinate.MaxStops_Height.ToString();
            tbxMaxVicesHeight.Text = airCoordinate.MaxVices_Height.ToString();
            tbxMaxPieceHeight.Text = airCoordinate.MaxPiece_Height.ToString();
            tbxFreeBackSpace.Text = airCoordinate.FreeBackSpace.ToString();
            tbxFreeFrontSpace.Text = airCoordinate.FreeFrontSpace.ToString();
            tbxFreeSpaceUnderPod.Text = airCoordinate.FreeSpaceUnderPod.ToString();
            tbxMaxYPos.Text = airCoordinate.MaxYPosition.ToString();
            tbxMinZPos.Text = airCoordinate.MinZPosition.ToString();
            tbxMinXLeftPos.Text = airCoordinate.MinXLeftPosition.ToString();
            tbxMinZLeftPos.Text = airCoordinate.MinZLeftPosition.ToString();


            var workingFeed = Globals.serviceManager.GetWorkFeeds(1);
            tbxRouterFeed.Text = workingFeed.Routers_MaxInterpolationFeed.ToString();
            tbxBladeFeed.Text = workingFeed.Blade_MaxInterpolationFeed.ToString();
            tbxSpeedLateral.Text = workingFeed.InSpeed_LateralHoles.ToString();
            tbxSpeedVertical.Text = workingFeed.InSpeed_VerticalHoles.ToString();
            tbxSpeedRouter.Text = workingFeed.InSpeed_Routers.ToString();
            tbxSpeedBlade.Text = workingFeed.InSpeed_Blades.ToString();
            tbxSpeedInserterTool.Text = workingFeed.InSpeed_Inserters.ToString();
            tbxSpeedProbe.Text = workingFeed.InSpeed_Probe.ToString();
            tbxFilletFeed.Text = workingFeed.InsertedFilletFeed.ToString();
            tbxSlowEntry.Text = workingFeed.SlowingPercentage_OnEntry.ToString();
            tbxSlowExit.Text = workingFeed.SlowingPercentage_OnExit.ToString();
            tbxMaxRPMRouter.Text = workingFeed.MaxRPM_Router.ToString();
            tbxMaxRPMBlade.Text = workingFeed.MaxRPM_Blade.ToString();
            tbxMaxRPMSpindle.Text = workingFeed.MaxRPM_Spindle.ToString();
        }

        #endregion

        #region Correctors
        private void pbCorrectors_Click(object sender, EventArgs e)
        {
            tcTecnoParams.SelectedTab = tpCorrectors;
        }
        private void btnOffets_Click(object sender, EventArgs e)
        {
            tcCorrectors.SelectedTab = tpHeadOffsets;
        }

        private void btnCorrectors_Click(object sender, EventArgs e)
        {
            tcCorrectors.SelectedTab = tpCorrector;
        }

        private void btnAggregate_Click(object sender, EventArgs e)
        {
            tcCorrectors.SelectedTab = tpAggregate;
        }

        #endregion


    }
}
