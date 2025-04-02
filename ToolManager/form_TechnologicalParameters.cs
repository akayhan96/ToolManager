using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolManager.Entity;

namespace ToolManager
{
    public partial class form_TechnologicalParameters : Form
    {
        #region Variables
        bool changedSystemParameters = false;
        bool isLoadSystemParameters = false;
        int lastTCId;

        bool isLoadGeneralParameters = false;
        bool isLoadHeadOffset = false;


        List<int> changeCorrectorIndexes = new List<int>();
        List<int> changeAggregateIndexes = new List<int>();
        List<int> changeToolChangeIndexes = new List<int>();

        ToolChanger toolChanger;
        #endregion
        #region Forms
        public form_TechnologicalParameters()
        {
            InitializeComponent();
        }

        private void form_TechnologicalParameters_Load(object sender, EventArgs e)
        {
            tcTecnoParams.Appearance = tcCorrectors.Appearance = tcGeneralParams.Appearance = TabAppearance.FlatButtons;
            tcTecnoParams.ItemSize = tcCorrectors.ItemSize = tcGeneralParams.ItemSize = new Size(0, 1);
            tcTecnoParams.SizeMode = tcCorrectors.SizeMode = tcGeneralParams.SizeMode = TabSizeMode.Fixed;

            FillText_SystemParameters();
            FillText_GeneralParameters();
            FillText_Correctors();

            LoadSystemParameters();
            LoadGeneralParamValues();
            LoadCorrectorValues();

            dgvCorrector.CellEndEdit += dgvCorrector_CellEndEdit;
            dgvAggregates.CellEndEdit += dgvAggregate_CellEndEdit;
        }


        private void pbExit_Click(object sender, EventArgs e)
        {
            // Değiştirilmiş bir veri var ise
            if (pbSave.Enabled == true)
            {
                string question = Globals.serviceManager.ReadMessage("3999", Globals.XmlngTecnoManager);
                var result = MessageBox.Show(question, "ToolManager", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel)
                {
                    return;
                }

                if (result == DialogResult.No)
                {
                    Globals.serviceManager.ReloadChangers();
                    this.Close();
                }

                if (result == DialogResult.Yes)
                {
                    bool allChanged = SaveChanges();
                    if(allChanged)
                    {
                        Globals.serviceManager.WriteXml(Globals.EntityTecData);
                        this.Close();
                    }
                }
            }
            else
            {
                this.Close();
            }

        }

        private bool SaveChanges()
        {
            // System Parameters
            // -> Bir işlem yapmaya gerek yok. Değişiklikler liste üzerinde doğrudan yapıldı.
            // -> Seriliaze işleminde direkt xml' e yazılacak

            // General Parameters
            var airCoordinate = Globals.serviceManager.GetDistanceDimensions(1);
            foreach (var prop in airCoordinate.GetType().GetProperties())
            {
                var textBox = this.Controls.Find("tbx" + prop.Name.Replace("_", ""), true).FirstOrDefault() as TextBox;
                if (textBox != null)
                {
                    try
                    {
                        object convertedValue = Convert.ChangeType(textBox.Text, prop.PropertyType);
                        prop.SetValue(airCoordinate, convertedValue);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {prop.Name} için geçersiz değer! \n{ex.Message}");
                        return false;
                    }
                }
            }


            var workingFeed = Globals.serviceManager.GetWorkFeeds(1);
            foreach (var prop in workingFeed.GetType().GetProperties())
            {
                var textBox = this.Controls.Find("tbx" + prop.Name.Replace("_", ""), true).FirstOrDefault() as TextBox;
                if (textBox != null)
                {
                    try
                    {
                        object convertedValue = Convert.ChangeType(textBox.Text, prop.PropertyType);
                        prop.SetValue(workingFeed, convertedValue);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {prop.Name} için geçersiz değer! \n{ex.Message}");
                        return false;
                    }
                }
            }

            try
            {
                var field1 = Globals.serviceManager.GetMachineFields(1, 1);
                // Hata ayıklama için field name'leri kontrol ederek her işlem için log yazdırma
                void SetOffset(string fieldName, string xText, string yText)
                {
                    var field = field1.Field.FirstOrDefault(f => f.FieldName == fieldName);
                    if (field != null)
                    {
                        try
                        {
                            field.OffsetX = Convert.ToDouble(xText); // xText'i double'a dönüştür
                            field.OffsetY = Convert.ToDouble(yText); // yText'i double'a dönüştür
                        }
                        catch (FormatException)
                        {
                            throw new FormatException($"Veri tipi hatası: FieldName '{fieldName}' için yanlış veri tipi girildi. X: {xText}, Y: {yText}");
                        }
                    }
                    else
                    {
                        throw new Exception($"FieldName '{fieldName}' bulunamadı.");
                    }
                }

                // FieldName'lere göre işlemleri yap
                SetOffset("N", tbxN1X.Text, tbxN1Y.Text);
                SetOffset("T", tbxT1X.Text, tbxT1Y.Text);
                SetOffset("M", tbxM1X.Text, tbxM1Y.Text);
                SetOffset("A", tbxA1X.Text, tbxA1Y.Text);
                SetOffset("N2", tbxN2X.Text, "0"); // Örnek olarak yText için '0' kullanıldı
                SetOffset("T2", tbxT2X.Text, "0");
                SetOffset("A2", tbxA2X.Text, "0");
                SetOffset("M2", tbxR2X.Text, "0");
                field1.PushingReference = rBtnPushReff.Checked;
                field1.MirrorOnNormalFieldReference = cbxMirrorOnNormalFieldReference.Checked;
                field1.NormalOnMirrorFieldReference = cbxNormalOnMirrorFieldReference.Checked;
            }
            catch (FormatException ex)
            {
                // Hata mesajını ve hangi FieldName'de yanlış veri tipi olduğunu logla
                MessageBox.Show($"Hata: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Diğer hataları yakala
                MessageBox.Show($"Beklenmeyen hata: {ex.Message}");
                return false;
            }

            try
            {
                var field2 = Globals.serviceManager.GetMachineFields(1, 2);
                // Hata ayıklama için field name'leri kontrol ederek her işlem için log yazdırma
                void SetOffset(string fieldName, string xText, string yText)
                {
                    var field = field2.Field.FirstOrDefault(f => f.FieldName == fieldName);
                    if (field != null)
                    {
                        try
                        {
                            field.OffsetX = Convert.ToDouble(xText); // xText'i double'a dönüştür
                            field.OffsetY = Convert.ToDouble(yText); // yText'i double'a dönüştür
                        }
                        catch (FormatException)
                        {
                            throw new FormatException($"Veri tipi hatası: FieldName '{fieldName}' için yanlış veri tipi girildi. X: {xText}, Y: {yText}");
                        }
                    }
                    else
                    {
                        throw new Exception($"FieldName '{fieldName}' bulunamadı.");
                    }
                }

                // FieldName'lere göre işlemleri yap
                SetOffset("N", tbxN3X.Text, tbxN3Y.Text);
                SetOffset("T", tbxT3X.Text, tbxT3Y.Text);
                SetOffset("M", tbxM3X.Text, tbxM3Y.Text);
                SetOffset("A", tbxA3X.Text, tbxA3Y.Text);
                SetOffset("N2", tbxN4X.Text, "0"); // Örnek olarak yText için '0' kullanıldı
                SetOffset("T2", tbxT4X.Text, "0");
                SetOffset("A2", tbxA4X.Text, "0");
                SetOffset("M2", tbxR4X.Text, "0");
                field2.PushingReference = rBtnPushReff2.Checked;
                field2.MirrorOnNormalFieldReference = cbxMirrorOnNormalFieldReference2.Checked;
                field2.NormalOnMirrorFieldReference = cbxNormalOnMirrorFieldReference2.Checked;
            }
            catch (FormatException ex)
            {
                // Hata mesajını ve hangi FieldName'de yanlış veri tipi olduğunu logla
                MessageBox.Show($"Hata: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Diğer hataları yakala
                MessageBox.Show($"Beklenmeyen hata: {ex.Message}");
                return false;
            }
      
            // Correctors
            // -> Offset bilgileri(Head Offset) güncelle
            var headOffset = Globals.serviceManager.GetMachineHeadOffsets(1, 1);
            headOffset.OffsetXHead = Convert.ToDouble(tbxHeadX.Text);
            headOffset.OffsetYHead = Convert.ToDouble(tbxHeadY.Text);
            headOffset.OffsetZHead = Convert.ToDouble(tbxHeadZ.Text);
            headOffset.MinimumHeadHeight = Convert.ToDouble(tbxMinHeight.Text);

            // -> Mil Düzelticilerini(Spindle) güncelle
            var spindles = Globals.serviceManager.GetCorrectors();
            bool isAddSpindleList = false; // Spindle nesnesi listeye eklensin mi?
            for (int i = 0; i < changeCorrectorIndexes.Count; i++)
            {
                int index = changeCorrectorIndexes[i];

                var existSpindle = spindles.FirstOrDefault(s => s.Index == index + 1);
                DataGridViewRow row = dgvCorrector.Rows[index];

                if (existSpindle == null)
                {
                    existSpindle = new Spindle();
                    existSpindle.Index = index + 1;

                    isAddSpindleList = true;
                }

                foreach (DataGridViewCell cell in row.Cells)
                {
                    string columnName = dgvCorrector.Columns[cell.ColumnIndex].Name;

                    switch (columnName)
                    {
                        case "cCorrectorX": existSpindle.CorrectorX = (double)cell.Value; break;
                        case "cCorrectorY": existSpindle.CorrectorY = (double)cell.Value; break;
                        case "cCorrectorZ": existSpindle.CorrectorZ = (double)cell.Value; break;
                        case "cSideMask": existSpindle.SideMask = (int)cell.Value; break;
                        case "cWorkType": existSpindle.WorkType = (int)cell.Value; break;
                        case "cTCNumber": existSpindle.ToolChangeNumber = (int)cell.Value; break;
                        case "cTCBush": existSpindle.ToolChangeBush = (int)cell.Value; break;
                        case "cRelativeAggreagate": existSpindle.RelativeAggregate = (int)cell.Value; break;
                        case "cDepthLimit": existSpindle.DepthLimit = (double)cell.Value; break;
                        case "cMaxDiameterAllowed": existSpindle.MaximumDiameterAllowed = (int)cell.Value; break;
                        case "cMaxLengthAllowed": existSpindle.MaximumLengthAllowed = (int)cell.Value; break;
                        case "cDistNextPos": existSpindle.DistanceNextPosition = (double)cell.Value; break;
                        case "cCorsaPneumatic": existSpindle.CorsaPneumaticaBoccola = (int)cell.Value; break;
                        case "cDirPnematic": existSpindle.DirezionePneumatica = (int)cell.Value; break;
                        case "cToolWear": existSpindle.ToolWear = (double)cell.Value; break;
                        case "cToolWear2": existSpindle.ToolWear2 = (double)cell.Value; break;
                        case "cCustParam1": existSpindle.CustParam1 = (double)cell.Value; break;
                        case "cCustParam2": existSpindle.CustParam2 = (double)cell.Value; break;
                        case "cCustParam3": existSpindle.CustParam3 = (double)cell.Value; break;
                        case "cCustParam4": existSpindle.CustParam4 = (double)cell.Value; break;
                        case "cCustParam5": existSpindle.CustParam5 = (double)cell.Value; break;
                        case "cCustParam6": existSpindle.CustParam6 = (double)cell.Value; break;
                        case "cCustParam7": existSpindle.CustParam7 = (double)cell.Value; break;
                        case "cCustParam8": existSpindle.CustParam8 = (double)cell.Value; break;
                        case "cCustParam9": existSpindle.CustParam9 = (double)cell.Value; break;
                        case "cCustParam10": existSpindle.CustParam10 = (double)cell.Value; break;
                        default:
                            break;
                    }
                }

                if(isAddSpindleList)
                {
                    spindles.Add(existSpindle);
                    isAddSpindleList = false;
                }
            }
            spindles.RemoveAll(spindle => spindle.CorrectorX == 0 &&
                              spindle.CorrectorY == 0 &&
                              spindle.CorrectorZ == 0 &&
                              spindle.ToolChangeNumber == 0 &&
                              spindle.RelativeAggregate == 0);

            // -> Aggregate Parametlerini güncelle
            var aggregates = Globals.serviceManager.GetAggregates();
            bool isAddAggregateList = false; // Spindle nesnesi listeye eklensin mi?
            for (int i = 0; i < changeAggregateIndexes.Count; i++)
            {
                int index = changeAggregateIndexes[i];

                var existAggregate = aggregates.FirstOrDefault(s => s.Index == index + 1);
                DataGridViewRow row = dgvAggregates.Rows[index];

                if (existAggregate == null)
                {
                    existAggregate = new Aggregate();
                    existAggregate.Index = index + 1;

                    isAddAggregateList = true;
                }

                foreach (DataGridViewCell cell in row.Cells)
                {
                    string columnName = dgvAggregates.Columns[cell.ColumnIndex].Name;

                    switch (columnName)
                    {
                        case "aCorrectorX": existAggregate.CorrectorX = (double)cell.Value; break;
                        case "aCorrectorY": existAggregate.CorrectorY = (double)cell.Value; break;
                        case "aCorrectorZ": existAggregate.CorrectorZ = (double)cell.Value; break;
                        case "aOffsetC": existAggregate.OffsetC = (double)cell.Value; break;
                        case "aOffsetB": existAggregate.OffsetB = (double)cell.Value; break;
                        case "aSideMask": existAggregate.SideMask = (int)cell.Value; break;
                        case "aCRotationInfo": existAggregate.CRotationInfo = (int)cell.Value; break;
                        case "aMaxRpm": existAggregate.MaxRPM = (int)cell.Value; break;
                        case "aDirPnematic": existAggregate.DirezionePneumatica = (int)cell.Value; break;
                        case "aPiston1": existAggregate.Piston1 = (double)cell.Value; break;
                        case "aPiston2": existAggregate.Piston2 = (double)cell.Value; break;
                        case "aPiston3": existAggregate.Piston3 = (double)cell.Value; break;
                        case "aSpindleType": existAggregate.SpindleType = (int)cell.Value; break;
                        case "aOffset1": existAggregate.Offset1 = (double)cell.Value; break;
                        case "aOffset2": existAggregate.Offset2 = (double)cell.Value; break;
                        case "aOffset3": existAggregate.Offset3 = (double)cell.Value; break;
                        case "aOffset4": existAggregate.Offset4 = (double)cell.Value; break;
                        case "aOffset5": existAggregate.Offset5 = (double)cell.Value; break;
                        case "cCustParam1": existAggregate.CustParam1 = (double)cell.Value; break;
                        case "cCustParam2": existAggregate.CustParam2 = (double)cell.Value; break;
                        case "cCustParam3": existAggregate.CustParam3 = (double)cell.Value; break;
                        case "cCustParam4": existAggregate.CustParam4 = (double)cell.Value; break;
                        case "cCustParam5": existAggregate.CustParam5 = (double)cell.Value; break;
                        case "cCustParam6": existAggregate.CustParam6 = (double)cell.Value; break;
                        case "cCustParam7": existAggregate.CustParam7 = (double)cell.Value; break;
                        case "cCustParam8": existAggregate.CustParam8 = (double)cell.Value; break;
                        case "cCustParam9": existAggregate.CustParam9 = (double)cell.Value; break;
                        case "cCustParam10": existAggregate.CustParam10 = (double)cell.Value; break;
                        default:
                            break;
                    }
                }

                if (isAddAggregateList)
                {
                    aggregates.Add(existAggregate);
                    isAddAggregateList = false;
                }
            }

            aggregates.RemoveAll(aggregate => aggregate.CorrectorX == 0 &&
                                              aggregate.CorrectorY == 0 &&
                                              aggregate.CorrectorZ == 0);

            return true;
        }


        private void pbSave_Click(object sender, EventArgs e)
        {
            bool allChanged = SaveChanges();
            if(allChanged)
            {
                Globals.serviceManager.WriteXml(Globals.EntityTecData);
                pbSave.Enabled = false;
            }
        }
        #endregion

        #region System Parameters
        private void pbSystemParams_Click(object sender, EventArgs e)
        {
            tcTecnoParams.SelectedTab = tpSystemParams;
        }

        private void FillText_SystemParameters()
        {
            lblNumberBush.Text = Globals.serviceManager.ReadMessage("4317", Globals.XmlngTecnoManager);
            lblTCType.Text = Globals.serviceManager.ReadMessage("4318", Globals.XmlngTecnoManager);
            lblFulcrumX.Text = Globals.serviceManager.ReadMessage("4325", Globals.XmlngTecnoManager);
            lblFulcrumY.Text = Globals.serviceManager.ReadMessage("4326", Globals.XmlngTecnoManager);
            lblDeltaX.Text = Globals.serviceManager.ReadMessage("4327", Globals.XmlngTecnoManager);
            lblDeltaY.Text = Globals.serviceManager.ReadMessage("4328", Globals.XmlngTecnoManager);
            chkWithBench.Text = Globals.serviceManager.ReadMessage("4340", Globals.XmlngTecnoManager);
            chkWithX.Text = Globals.serviceManager.ReadMessage("4341", Globals.XmlngTecnoManager);
            chkWithY.Text = Globals.serviceManager.ReadMessage("4342", Globals.XmlngTecnoManager);
            lblPosX.Text = Globals.serviceManager.ReadMessage("4343", Globals.XmlngTecnoManager);
            lblPosY.Text = Globals.serviceManager.ReadMessage("4344", Globals.XmlngTecnoManager);
            lblLoadTime.Text = Globals.serviceManager.ReadMessage("4345", Globals.XmlngTecnoManager);
            lblUnloadTime.Text = Globals.serviceManager.ReadMessage("4346", Globals.XmlngTecnoManager);
            chkTCTime.Text = Globals.serviceManager.ReadMessage("4347", Globals.XmlngTecnoManager);
            lblPosZ.Text = Globals.serviceManager.ReadMessage("4348", Globals.XmlngTecnoManager);
        }

        private void LoadSystemParameters()
        {
            List<string> tcTypes = new List<string>();
            tcTypes.Add(Globals.serviceManager.ReadMessage("4319", Globals.XmlngTecnoManager));
            tcTypes.Add(Globals.serviceManager.ReadMessage("4320", Globals.XmlngTecnoManager));
            tcTypes.Add(Globals.serviceManager.ReadMessage("4321", Globals.XmlngTecnoManager));
            tcTypes.Add(Globals.serviceManager.ReadMessage("4322", Globals.XmlngTecnoManager));
            tcTypes.Add(Globals.serviceManager.ReadMessage("4323", Globals.XmlngTecnoManager));
            cbTCType.DataSource = tcTypes;

            //---------------------------------------------------

            LoadSysParamValues();
        }

        private void LoadSysParamValues()
        {
            isLoadSystemParameters = true;

            toolChanger = Globals.serviceManager.GetToolChanger((int)nudTcId.Value);
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

            lastTCId = (int)nudTcId.Value;
            isLoadSystemParameters = false;
        }
        private void nudTcId_ValueChanged(object sender, EventArgs e)
        {
            if (changedSystemParameters)
            {
                toolChanger.Type = cbTCType.SelectedIndex;
                toolChanger.NumberOfBushes = Convert.ToInt32(tbxNumberBush.Text);
                toolChanger.FulcrumX = Convert.ToSingle(tbxFulcrumX.Text);
                toolChanger.FulcrumY = Convert.ToSingle(tbxFulcrumY.Text);
                toolChanger.DeltaX = Convert.ToSingle(tbxDeltaX.Text);
                toolChanger.DeltaY = Convert.ToSingle(tbxDeltaY.Text);
                toolChanger.XPickUpCoordinate = Convert.ToSingle(tbxPosX.Text);
                toolChanger.YPickUpCoordinate = Convert.ToSingle(tbxPosY.Text);
                toolChanger.ZPickUpCoordinate = Convert.ToSingle(tbxPosZ.Text);
                toolChanger.ToolLoadingWaitingTime = Convert.ToInt32(tbxLoadTime.Text);
                toolChanger.ToolUnloadingWaitingTime = Convert.ToInt32(tbxUnloadTime.Text);
                toolChanger.IntegralWithHeadInX = chkWithX.Checked;
                toolChanger.IntegralWithHeadInY = chkWithY.Checked;
                toolChanger.ToolChangeInMaskedTime = chkTCTime.Checked;

                if (toolChanger.Index == null)
                {
                    toolChanger.Index = lastTCId;
                    Globals.serviceManager.AddToolChanger(toolChanger);
                }

                changedSystemParameters = false;
                pbSave.Enabled = true;
            }

            LoadSysParamValues();
        }

        private void chkWithBench_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWithBench.Checked)
            {
                chkWithX.Checked = false;
                chkWithY.Checked = false;
            }

            if (!isLoadSystemParameters)
            {
                changedSystemParameters = true;
            }

        }

        private void chkWithX_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWithX.Checked)
            {
                chkWithBench.Checked = false;
            }

            if (!isLoadSystemParameters)
            {
                changedSystemParameters = true;
            }
        }

        private void chkWithY_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWithY.Checked)
            {
                chkWithBench.Checked = false;
            }

            if (!isLoadSystemParameters)
            {
                changedSystemParameters = true;
            }
        }

        private void SystemParametersTextbox_TextChanged(object sender, EventArgs e)
        {
            if (isLoadSystemParameters) return;

            changedSystemParameters = true;
        }

        private void cbTCType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoadSystemParameters) return;

            changedSystemParameters = true;
        }

        private void chkTCTime_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoadSystemParameters)
            {
                changedSystemParameters = true;
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

        private void LoadGeneralParamValues()
        {
            isLoadGeneralParameters = true;

            var airCoordinate = Globals.serviceManager.GetDistanceDimensions(1);
            tbxRouters_Clearance.Text = airCoordinate.Routers_Clearance.ToString();
            tbxBlades_Clearance.Text = airCoordinate.Blades_Clearance.ToString();
            tbxHorizontalDrills_Clearance.Text = airCoordinate.HorizontalDrills_Clearance.ToString();
            tbxLateralDrills_Clearance.Text = airCoordinate.LateralDrills_Clearance.ToString();
            tbxVerticalDrills_Clearance.Text = airCoordinate.VerticalDrills_Clearance.ToString();
            tbxInserterTools_Clearance.Text = airCoordinate.InserterTools_Clearance.ToString();
            tbxMaxStops_Height.Text = airCoordinate.MaxStops_Height.ToString();
            tbxMaxVices_Height.Text = airCoordinate.MaxVices_Height.ToString();
            tbxMaxPiece_Height.Text = airCoordinate.MaxPiece_Height.ToString();
            tbxFreeBackSpace.Text = airCoordinate.FreeBackSpace.ToString();
            tbxFreeFrontSpace.Text = airCoordinate.FreeFrontSpace.ToString();
            tbxFreeSpaceUnderPod.Text = airCoordinate.FreeSpaceUnderPod.ToString();
            tbxMaxYPosition.Text = airCoordinate.MaxYPosition.ToString();
            tbxMinZPosition.Text = airCoordinate.MinZPosition.ToString();
            tbxMinXLeftPosition.Text = airCoordinate.MinXLeftPosition.ToString();
            tbxMinZLeftPosition.Text = airCoordinate.MinZLeftPosition.ToString();


            var workingFeed = Globals.serviceManager.GetWorkFeeds(1);
            tbxRouters_MaxInterpolationFeed.Text = workingFeed.Routers_MaxInterpolationFeed.ToString();
            tbxBlade_MaxInterpolationFeed.Text = workingFeed.Blade_MaxInterpolationFeed.ToString();
            tbxInSpeed_LateralHoles.Text = workingFeed.InSpeed_LateralHoles.ToString();
            tbxInSpeed_VerticalHoles.Text = workingFeed.InSpeed_VerticalHoles.ToString();
            tbxInSpeed_Routers.Text = workingFeed.InSpeed_Routers.ToString();
            tbxInSpeed_Blades.Text = workingFeed.InSpeed_Blades.ToString();
            tbxInSpeed_Inserters.Text = workingFeed.InSpeed_Inserters.ToString();
            tbxInSpeed_Probe.Text = workingFeed.InSpeed_Probe.ToString();
            tbxInsertedFilletFeed.Text = workingFeed.InsertedFilletFeed.ToString();
            tbxSlowingPercentage_OnEntry.Text = workingFeed.SlowingPercentage_OnEntry.ToString();
            tbxSlowingPercentage_OnExit.Text = workingFeed.SlowingPercentage_OnExit.ToString();
            tbxMaxRPM_Router.Text = workingFeed.MaxRPM_Router.ToString();
            tbxMaxRPM_Blade.Text = workingFeed.MaxRPM_Blade.ToString();
            tbxMaxRPM_Spindle.Text = workingFeed.MaxRPM_Spindle.ToString();

            var field1 = Globals.serviceManager.GetMachineFields(1, 1);
            tbxN1X.Text = field1.Field.Where(f => f.FieldName == "N").FirstOrDefault().OffsetX.ToString();
            tbxN1Y.Text = field1.Field.Where(f => f.FieldName == "N").FirstOrDefault().OffsetY.ToString();
            tbxT1X.Text = field1.Field.Where(f => f.FieldName == "T").FirstOrDefault().OffsetX.ToString();
            tbxT1Y.Text = field1.Field.Where(f => f.FieldName == "T").FirstOrDefault().OffsetY.ToString();
            tbxM1X.Text = field1.Field.Where(f => f.FieldName == "M").FirstOrDefault().OffsetX.ToString();
            tbxM1Y.Text = field1.Field.Where(f => f.FieldName == "M").FirstOrDefault().OffsetY.ToString();
            tbxA1X.Text = field1.Field.Where(f => f.FieldName == "A").FirstOrDefault().OffsetX.ToString();
            tbxA1Y.Text = field1.Field.Where(f => f.FieldName == "A").FirstOrDefault().OffsetY.ToString();
            tbxN2X.Text = field1.Field.Where(f => f.FieldName == "N2").FirstOrDefault().OffsetX.ToString();
            tbxT2X.Text = field1.Field.Where(f => f.FieldName == "T2").FirstOrDefault().OffsetX.ToString();
            tbxA2X.Text = field1.Field.Where(f => f.FieldName == "A2").FirstOrDefault().OffsetX.ToString();
            tbxR2X.Text = field1.Field.Where(f => f.FieldName == "M2").FirstOrDefault().OffsetX.ToString();
            rBtnPushReff.Checked = field1.PushingReference;
            rBtnPullReff.Checked = !rBtnPushReff.Checked;
            cbxMirrorOnNormalFieldReference.Checked = field1.MirrorOnNormalFieldReference;
            cbxNormalOnMirrorFieldReference.Checked = field1.NormalOnMirrorFieldReference;

            var field2 = Globals.serviceManager.GetMachineFields(1, 2);
            tbxN3X.Text = field2.Field.Where(f => f.FieldName == "N").FirstOrDefault().OffsetX.ToString();
            tbxN3Y.Text = field2.Field.Where(f => f.FieldName == "N").FirstOrDefault().OffsetY.ToString();
            tbxT3X.Text = field2.Field.Where(f => f.FieldName == "T").FirstOrDefault().OffsetX.ToString();
            tbxT3Y.Text = field2.Field.Where(f => f.FieldName == "T").FirstOrDefault().OffsetY.ToString();
            tbxM3X.Text = field2.Field.Where(f => f.FieldName == "M").FirstOrDefault().OffsetX.ToString();
            tbxM3Y.Text = field2.Field.Where(f => f.FieldName == "M").FirstOrDefault().OffsetY.ToString();
            tbxA3X.Text = field2.Field.Where(f => f.FieldName == "A").FirstOrDefault().OffsetX.ToString();
            tbxA3Y.Text = field2.Field.Where(f => f.FieldName == "A").FirstOrDefault().OffsetY.ToString();
            tbxN4X.Text = field2.Field.Where(f => f.FieldName == "N2").FirstOrDefault().OffsetX.ToString();
            tbxT4X.Text = field2.Field.Where(f => f.FieldName == "T2").FirstOrDefault().OffsetX.ToString();
            tbxA4X.Text = field2.Field.Where(f => f.FieldName == "A2").FirstOrDefault().OffsetX.ToString();
            tbxR4X.Text = field2.Field.Where(f => f.FieldName == "M2").FirstOrDefault().OffsetX.ToString();
            rBtnPushReff2.Checked = field2.PushingReference;
            rBtnPullReff2.Checked = !rBtnPushReff2.Checked;
            cbxMirrorOnNormalFieldReference2.Checked = field2.MirrorOnNormalFieldReference;
            cbxNormalOnMirrorFieldReference2.Checked = field2.NormalOnMirrorFieldReference;

            isLoadGeneralParameters = false;
        }

        private void GeneralParametersTextbox_TextChanged(object sender, EventArgs e)
        {
            if( !isLoadGeneralParameters )
            {
                pbSave.Enabled = true;
            }
        }

        private void GeneralParametersRadioButton_Checked(object sender, EventArgs e)
        {
            if (!isLoadGeneralParameters)
            {
                pbSave.Enabled = true;
            }
        }

        private void GeneralParametersCheckbox_Checked(object sender, EventArgs e)
        {
            if (!isLoadGeneralParameters)
            {
                pbSave.Enabled = true;
            }
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

        private void FillText_Correctors()
        {
            btnOffets.Text = XmlFileRead.LanguageRead("4552", Globals.CurLang, Globals.XmlngTecnoManager);
            btnCorrectors.Text = XmlFileRead.LanguageRead("4550", Globals.CurLang, Globals.XmlngTecnoManager);
            btnAggregate.Text = XmlFileRead.LanguageRead("4215", Globals.CurLang, Globals.XmlngTecnoManager);

            // Tab Head Offset
            lblHeadX.Text = XmlFileRead.LanguageRead("4560", Globals.CurLang, Globals.XmlngTecnoManager);
            lblHeadY.Text = XmlFileRead.LanguageRead("4561", Globals.CurLang, Globals.XmlngTecnoManager);
            lblHeadZ.Text = XmlFileRead.LanguageRead("4562", Globals.CurLang, Globals.XmlngTecnoManager);
            lblMinHeight.Text = XmlFileRead.LanguageRead("4564", Globals.CurLang, Globals.XmlngTecnoManager);

            //dgvCorrrectors Headers
            dgvCorrector.Columns[1].HeaderText = XmlFileRead.LanguageRead("4600", Globals.CurLang, Globals.XmlngTecnoManager);     //X
            dgvCorrector.Columns[2].HeaderText = XmlFileRead.LanguageRead("4601", Globals.CurLang, Globals.XmlngTecnoManager);     //Y
            dgvCorrector.Columns[3].HeaderText = XmlFileRead.LanguageRead("4602", Globals.CurLang, Globals.XmlngTecnoManager);     //Z
            dgvCorrector.Columns[4].HeaderText = XmlFileRead.LanguageRead("4603", Globals.CurLang, Globals.XmlngTecnoManager);     //Görüntü
            dgvCorrector.Columns[5].HeaderText = XmlFileRead.LanguageRead("4604", Globals.CurLang, Globals.XmlngTecnoManager);     //İşlem Türü
            dgvCorrector.Columns[6].HeaderText = XmlFileRead.LanguageRead("4753", Globals.CurLang, Globals.XmlngTecnoManager);     // N.Ch Tool
            dgvCorrector.Columns[7].HeaderText = XmlFileRead.LanguageRead("4750", Globals.CurLang, Globals.XmlngTecnoManager);     // Takım yeri no
            dgvCorrector.Columns[8].HeaderText = XmlFileRead.LanguageRead("4751", Globals.CurLang, Globals.XmlngTecnoManager);     // Aggreate No
            dgvCorrector.Columns[9].HeaderText = XmlFileRead.LanguageRead("4766", Globals.CurLang, Globals.XmlngTecnoManager);     // En Büyük Kalınlık
            dgvCorrector.Columns[10].HeaderText = XmlFileRead.LanguageRead("4612", Globals.CurLang, Globals.XmlngTecnoManager);    // Max Çap izin verilir
            dgvCorrector.Columns[11].HeaderText = XmlFileRead.LanguageRead("4613", Globals.CurLang, Globals.XmlngTecnoManager);    // Max İzin verilen uzunluk
            dgvCorrector.Columns[12].HeaderText = XmlFileRead.LanguageRead("4614", Globals.CurLang, Globals.XmlngTecnoManager);    // Bir sonraki pozisyona uzaklık
            dgvCorrector.Columns[13].HeaderText = XmlFileRead.LanguageRead("4615", Globals.CurLang, Globals.XmlngTecnoManager);    // Önseçelim darbe
            dgvCorrector.Columns[14].HeaderText = XmlFileRead.LanguageRead("4616", Globals.CurLang, Globals.XmlngTecnoManager);    // Preselectin Dire
            dgvCorrector.Columns[15].HeaderText = XmlFileRead.LanguageRead("4617", Globals.CurLang, Globals.XmlngTecnoManager);    // usura utansile
            dgvCorrector.Columns[16].HeaderText = XmlFileRead.LanguageRead("4617", Globals.CurLang, Globals.XmlngTecnoManager) + "2"; // usura utansile 2
            dgvCorrector.Columns[17].HeaderText = XmlFileRead.LanguageRead("4618", Globals.CurLang, Globals.XmlngTecnoManager);    // Ayna Takım

            //dgvAggregate Headers
            dgvAggregates.Columns[1].HeaderText = XmlFileRead.LanguageRead("4600", Globals.CurLang, Globals.XmlngTecnoManager);     //X
            dgvAggregates.Columns[2].HeaderText = XmlFileRead.LanguageRead("4601", Globals.CurLang, Globals.XmlngTecnoManager);     //Y
            dgvAggregates.Columns[3].HeaderText = XmlFileRead.LanguageRead("4602", Globals.CurLang, Globals.XmlngTecnoManager);     //Z
            dgvAggregates.Columns[4].HeaderText = XmlFileRead.LanguageRead("4754", Globals.CurLang, Globals.XmlngTecnoManager);     //Offset C
            dgvAggregates.Columns[5].HeaderText = XmlFileRead.LanguageRead("4755", Globals.CurLang, Globals.XmlngTecnoManager);     //Offset B
            dgvAggregates.Columns[6].HeaderText = XmlFileRead.LanguageRead("4603", Globals.CurLang, Globals.XmlngTecnoManager);     //Görüntü
            dgvAggregates.Columns[7].HeaderText = XmlFileRead.LanguageRead("4752", Globals.CurLang, Globals.XmlngTecnoManager);     //C Bilgileri
            dgvAggregates.Columns[8].HeaderText = XmlFileRead.LanguageRead("4759", Globals.CurLang, Globals.XmlngTecnoManager);     //Maks d/da
            dgvAggregates.Columns[9].HeaderText = XmlFileRead.LanguageRead("4616", Globals.CurLang, Globals.XmlngTecnoManager);     //Preselection dir
            dgvAggregates.Columns[10].HeaderText = XmlFileRead.LanguageRead("4756", Globals.CurLang, Globals.XmlngTecnoManager);     //Silindir
            dgvAggregates.Columns[11].HeaderText = XmlFileRead.LanguageRead("4757", Globals.CurLang, Globals.XmlngTecnoManager);     //Silindir2
            dgvAggregates.Columns[12].HeaderText = XmlFileRead.LanguageRead("4758", Globals.CurLang, Globals.XmlngTecnoManager);     //Silindir3
            dgvAggregates.Columns[13].HeaderText = XmlFileRead.LanguageRead("4760", Globals.CurLang, Globals.XmlngTecnoManager);     //Elektro mil tipi
            dgvAggregates.Columns[14].HeaderText = XmlFileRead.LanguageRead("4761", Globals.CurLang, Globals.XmlngTecnoManager);     //Offset1
            dgvAggregates.Columns[15].HeaderText = XmlFileRead.LanguageRead("4762", Globals.CurLang, Globals.XmlngTecnoManager);     //Offset2
            dgvAggregates.Columns[16].HeaderText = XmlFileRead.LanguageRead("4763", Globals.CurLang, Globals.XmlngTecnoManager);     //Offset3
            dgvAggregates.Columns[17].HeaderText = XmlFileRead.LanguageRead("4764", Globals.CurLang, Globals.XmlngTecnoManager);     //Offset4
            dgvAggregates.Columns[18].HeaderText = XmlFileRead.LanguageRead("4765", Globals.CurLang, Globals.XmlngTecnoManager);     //Offset5
        }

        private void LoadCorrectorValues()
        {

            isLoadHeadOffset = true;
            // Head Offsets
            var headOffsets = Globals.serviceManager.GetMachineHeadOffsets(1, 1);
            tbxHeadX.Text = headOffsets.OffsetXHead.ToString();
            tbxHeadY.Text = headOffsets.OffsetYHead.ToString();
            tbxHeadZ.Text = headOffsets.OffsetZHead.ToString();
            tbxMinHeight.Text = headOffsets.MinimumHeadHeight.ToString();
            isLoadHeadOffset = false;

            #region Face Datas
            // Face combobox datas
            var sideTypes = Globals.serviceManager.GetSideItems();
            (dgvCorrector.Columns["cSideMask"] as DataGridViewComboBoxColumn).DataSource = sideTypes;
            (dgvCorrector.Columns["cSideMask"] as DataGridViewComboBoxColumn).DisplayMember = "Name";
            (dgvCorrector.Columns["cSideMask"] as DataGridViewComboBoxColumn).ValueMember = "Value";

            (dgvAggregates.Columns["aSideMask"] as DataGridViewComboBoxColumn).DataSource = sideTypes;
            (dgvAggregates.Columns["aSideMask"] as DataGridViewComboBoxColumn).DisplayMember = "Name";
            (dgvAggregates.Columns["aSideMask"] as DataGridViewComboBoxColumn).ValueMember = "Value";
            #endregion

            #region WorkType Combobox Datas
            // Work combobox Datas (Punta,fresa,saw,...)
            var workTypes = Globals.serviceManager.GetWorkItems();
            var workTypeList = new List<KeyValuePair<int, string>>();

            // KeyValuePair oluşturma işlemi
            for (int i = 0; i < workTypes.Count; i++)
            {
                workTypeList.Add(new KeyValuePair<int, string>(i, workTypes[i].Text));
            }
            // Şimdi workTypeList'i DataGridView'deki ComboBox'a atıyoruz
            (dgvCorrector.Columns["cWorkType"] as DataGridViewComboBoxColumn).DataSource = workTypeList;
            (dgvCorrector.Columns["cWorkType"] as DataGridViewComboBoxColumn).DisplayMember = "Value";
            (dgvCorrector.Columns["cWorkType"] as DataGridViewComboBoxColumn).ValueMember = "Key";
            #endregion

            #region DirezionePneumatica combobox datas
            string[] dirList = new string[] { "Z-", "Z+", "X-", "X+", "Y-", "Y+" };
            var dirTypeList = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < dirList.Length; i++)
            {
                dirTypeList.Add(new KeyValuePair<int, string>(i, dirList[i]));
            }
            (dgvCorrector.Columns["cDirPnematic"] as DataGridViewComboBoxColumn).DataSource = dirTypeList;
            (dgvCorrector.Columns["cDirPnematic"] as DataGridViewComboBoxColumn).DisplayMember = "Value";
            (dgvCorrector.Columns["cDirPnematic"] as DataGridViewComboBoxColumn).ValueMember = "Key";

            (dgvAggregates.Columns["aDirPnematic"] as DataGridViewComboBoxColumn).DataSource = dirTypeList;
            (dgvAggregates.Columns["aDirPnematic"] as DataGridViewComboBoxColumn).DisplayMember = "Value";
            (dgvAggregates.Columns["aDirPnematic"] as DataGridViewComboBoxColumn).ValueMember = "Key";
            #endregion

            #region CRotationInfo Combobox Datas
            string[] infosC = new string[]
            {
                Globals.serviceManager.ReadMessage("4770",Globals.XmlngTecnoManager),
                Globals.serviceManager.ReadMessage("4771",Globals.XmlngTecnoManager),
                Globals.serviceManager.ReadMessage("4772",Globals.XmlngTecnoManager),
                Globals.serviceManager.ReadMessage("4773",Globals.XmlngTecnoManager)
            };
            var infosCList = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < infosC.Length; i++)
            {
                infosCList.Add(new KeyValuePair<int, string>(i, infosC[i]));
            }
            (dgvAggregates.Columns["aCRotationInfo"] as DataGridViewComboBoxColumn).DataSource = infosCList;
            (dgvAggregates.Columns["aCRotationInfo"] as DataGridViewComboBoxColumn).DisplayMember = "Value";
            (dgvAggregates.Columns["aCRotationInfo"] as DataGridViewComboBoxColumn).ValueMember = "Key";
            #endregion

            #region SpindleType Combobox Datas
            string[] spindleTypes = new string[]
            {
                Globals.serviceManager.ReadMessage("4780",Globals.XmlngTecnoManager),
                Globals.serviceManager.ReadMessage("4781",Globals.XmlngTecnoManager),
                Globals.serviceManager.ReadMessage("4782",Globals.XmlngTecnoManager),
                Globals.serviceManager.ReadMessage("4783",Globals.XmlngTecnoManager),
                Globals.serviceManager.ReadMessage("4784",Globals.XmlngTecnoManager),
                Globals.serviceManager.ReadMessage("4785",Globals.XmlngTecnoManager)
            };
            var spindleTypeList = new List<KeyValuePair<int, string>>();
            for (int i = 0; i < spindleTypes.Length; i++)
            {
                spindleTypeList.Add(new KeyValuePair<int, string>(i, spindleTypes[i]));
            }
            (dgvAggregates.Columns["aSpindleType"] as DataGridViewComboBoxColumn).DataSource = spindleTypeList;
            (dgvAggregates.Columns["aSpindleType"] as DataGridViewComboBoxColumn).DisplayMember = "Value";
            (dgvAggregates.Columns["aSpindleType"] as DataGridViewComboBoxColumn).ValueMember = "Key";
            #endregion

            // Corrector Values
            var spindles = Globals.serviceManager.GetCorrectors();
            dgvCorrector.RowCount = 500;
            foreach (DataGridViewRow row in dgvCorrector.Rows)
            {
                var existSpindle = spindles.FirstOrDefault(s => s.Index == row.Index + 1);
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string columnName = dgvCorrector.Columns[cell.ColumnIndex].Name;
                    if (cell.ColumnIndex == 0)
                    {
                        cell.Value = (row.Index + 1).ToString();
                    }
                    else
                    {
                        if (existSpindle == null)
                        {
                            cell.Value = 0;
                        }
                        else
                        {
                            switch (columnName)
                            {
                                case "cCorrectorX": cell.Value = existSpindle.CorrectorX.ToString(); break;
                                case "cCorrectorY": cell.Value = existSpindle.CorrectorY.ToString(); break;
                                case "cCorrectorZ": cell.Value = existSpindle.CorrectorZ.ToString(); break;
                                case "cSideMask": cell.Value = existSpindle.SideMask; break;
                                case "cWorkType": cell.Value = existSpindle.WorkType; break;
                                case "cTCNumber": cell.Value = existSpindle.ToolChangeNumber.ToString(); break;
                                case "cTCBush": cell.Value = existSpindle.ToolChangeBush.ToString(); break;
                                case "cRelativeAggreagate": cell.Value = existSpindle.RelativeAggregate.ToString(); break;
                                case "cDepthLimit": cell.Value = existSpindle.DepthLimit.ToString(); break;
                                case "cMaxDiameterAllowed": cell.Value = existSpindle.MaximumDiameterAllowed.ToString(); break;
                                case "cMaxLengthAllowed": cell.Value = existSpindle.MaximumLengthAllowed.ToString(); break;
                                case "cDistNextPos": cell.Value = existSpindle.DistanceNextPosition.ToString(); break;
                                case "cCorsaPneumatic": cell.Value = existSpindle.CorsaPneumaticaBoccola.ToString(); break;
                                case "cDirPnematic": cell.Value = existSpindle.DirezionePneumatica; break;
                                case "cToolWear": cell.Value = existSpindle.ToolWear.ToString(); break;
                                case "cToolWear2": cell.Value = existSpindle.ToolWear2.ToString(); break;
                                case "cCustParam1": cell.Value = existSpindle.CustParam1.ToString(); break;
                                case "cCustParam2": cell.Value = existSpindle.CustParam2.ToString(); break;
                                case "cCustParam3": cell.Value = existSpindle.CustParam3.ToString(); break;
                                case "cCustParam4": cell.Value = existSpindle.CustParam4.ToString(); break;
                                case "cCustParam5": cell.Value = existSpindle.CustParam5.ToString(); break;
                                case "cCustParam6": cell.Value = existSpindle.CustParam6.ToString(); break;
                                case "cCustParam7": cell.Value = existSpindle.CustParam7.ToString(); break;
                                case "cCustParam8": cell.Value = existSpindle.CustParam8.ToString(); break;
                                case "cCustParam9": cell.Value = existSpindle.CustParam9.ToString(); break;
                                case "cCustParam10": cell.Value = existSpindle.CustParam10.ToString(); break;
                                default: cell.Value = 0; break;  // Tanımlanmamış sütunlar için varsayılan değer
                            }
                        }
                    }
                }
            }

            var aggregates = Globals.serviceManager.GetAggregates();
            dgvAggregates.RowCount = 10;
            foreach (DataGridViewRow row in dgvAggregates.Rows)
            {
                var existAggregate = aggregates.FirstOrDefault(s => s.Index == row.Index + 1);
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string columnName = dgvAggregates.Columns[cell.ColumnIndex].Name;
                    if (cell.ColumnIndex == 0)
                    {
                        cell.Value = (row.Index + 1).ToString();
                    }
                    else
                    {
                        if (existAggregate == null)
                        {
                            cell.Value = 0;
                        }
                        else
                        {
                            switch (columnName)
                            {
                                case "aCorrectorX": cell.Value = existAggregate.CorrectorX.ToString(); break;
                                case "aCorrectorY": cell.Value = existAggregate.CorrectorY.ToString(); break;
                                case "aCorrectorZ": cell.Value = existAggregate.CorrectorZ.ToString(); break;
                                case "aOffsetC": cell.Value = existAggregate.OffsetC.ToString(); break;
                                case "aOffsetB": cell.Value = existAggregate.OffsetB.ToString(); break;
                                case "aSideMask": cell.Value = existAggregate.SideMask; break;
                                case "aCRotationInfo": cell.Value = existAggregate.CRotationInfo; break;
                                case "aMaxRpm": cell.Value = existAggregate.MaxRPM.ToString(); break;
                                case "aDirPnematic": cell.Value = existAggregate.DirezionePneumatica; break;
                                case "aPiston1": cell.Value = existAggregate.Piston1.ToString(); break;
                                case "aPiston2": cell.Value = existAggregate.Piston2.ToString(); break;
                                case "aPiston3": cell.Value = existAggregate.Piston3.ToString(); break;
                                case "aSpindleType": cell.Value = existAggregate.SpindleType; break;
                                case "aOffset1": cell.Value = existAggregate.Offset1.ToString(); break;
                                case "aOffset2": cell.Value = existAggregate.Offset2.ToString(); break;
                                case "aOffset3": cell.Value = existAggregate.Offset3.ToString(); break;
                                case "aOffset4": cell.Value = existAggregate.Offset4.ToString(); break;
                                case "aOffset5": cell.Value = existAggregate.Offset5.ToString(); break;
                                case "cCustParam1": cell.Value = existAggregate.CustParam1.ToString(); break;
                                case "cCustParam2": cell.Value = existAggregate.CustParam2.ToString(); break;
                                case "cCustParam3": cell.Value = existAggregate.CustParam3.ToString(); break;
                                case "cCustParam4": cell.Value = existAggregate.CustParam4.ToString(); break;
                                case "cCustParam5": cell.Value = existAggregate.CustParam5.ToString(); break;
                                case "cCustParam6": cell.Value = existAggregate.CustParam6.ToString(); break;
                                case "cCustParam7": cell.Value = existAggregate.CustParam7.ToString(); break;
                                case "cCustParam8": cell.Value = existAggregate.CustParam8.ToString(); break;
                                case "cCustParam9": cell.Value = existAggregate.CustParam9.ToString(); break;
                                case "cCustParam10": cell.Value = existAggregate.CustParam10.ToString(); break;
                                default: cell.Value = 0; break;  // Tanımlanmamış sütunlar için varsayılan değer
                            }
                        }
                    }
                }
            }


        }
        private void dgvCorrector_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!changeCorrectorIndexes.Contains(e.RowIndex))
            {
                changeCorrectorIndexes.Add(e.RowIndex);
            }

            pbSave.Enabled = true;
        }
        private void dgvAggregate_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!changeAggregateIndexes.Contains(e.RowIndex))
            {
                changeAggregateIndexes.Add(e.RowIndex);
            }
            pbSave.Enabled = true;
        }
        private void HeadOffsetTextbox_TextChanged(object sender, EventArgs e)
        {
            if(!isLoadHeadOffset)
            {
                pbSave.Enabled = true;
            }
        }
        #endregion


    }
}
