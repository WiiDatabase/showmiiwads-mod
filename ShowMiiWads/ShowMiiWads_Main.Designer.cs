/* This file is part of ShowMiiWads
 * Copyright (C) 2009 Leathl
 * 
 * ShowMiiWads is free software: you can redistribute it and/or
 * modify it under the terms of the GNU General Public License as published
 * by the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ShowMiiWads is distributed in the hope that it will be
 * useful, but WITHOUT ANY WARRANTY; without even the implied warranty
 * of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

namespace ShowMiiWads
{
    partial class ShowMiiWads_Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lvWads = new System.Windows.Forms.ListView();
            this.lvName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvBlocks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvFilesize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvIOS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvRegion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmWads = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmCut = new System.Windows.Forms.ToolStripMenuItem();
            this.cmPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.cmRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmChangeTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.cmChangeID = new System.Windows.Forms.ToolStripMenuItem();
            this.cmChangeIosSlot = new System.Windows.Forms.ToolStripMenuItem();
            this.cmChangeTitleVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.cmChangeRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.cmRegionFree = new System.Windows.Forms.ToolStripMenuItem();
            this.cmPal = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNtscU = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNtscJ = new System.Windows.Forms.ToolStripMenuItem();
            this.cmInsertDol = new System.Windows.Forms.ToolStripMenuItem();
            this.cmExtract = new System.Windows.Forms.ToolStripMenuItem();
            this.cmToFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmToNand = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.cmExtractVcPics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.cmPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.cmRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cmRemoveFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmRemoveAllFolders = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.cmRefreshFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMru = new System.Windows.Forms.ToolStripMenuItem();
            this.mruSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCut = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRename = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnChangeTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChangeID = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChangeIosSlot = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChangeTitleVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsChangeRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRegionFree = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPal = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNtscU = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNtscJ = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInsertDol = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExtract = new System.Windows.Forms.ToolStripMenuItem();
            this.btnToFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.btnToNand = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNandPath = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWiiGamePath = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveFolders = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowPath = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAutoResize = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateBackups = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddSub = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowSplash = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPortableMode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGerman = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFrench = new System.Windows.Forms.ToolStripMenuItem();
            this.btnItalian = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSpanish = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNorwegian = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPortuguese = new System.Windows.Forms.ToolStripMenuItem();
            this.btnJapanese = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChinese = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFromFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTools = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPackWad = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUnpackU8 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPackU8 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPackU8WithoutHeader = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPackU8WithIMD5 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPackU8WithIMET = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConvertFromTpl = new System.Windows.Forms.ToolStripMenuItem();
            this.tsConvertToTpl = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAsRGBA8 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAsRGB565 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAsRGB5A3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLz77Compress = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLz77Decompress = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExtractBootmiiDump = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateNANDFromScratch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsView = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowMiiWads = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowMiiNand = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowMiiWiiGames = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdateCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDisclaimer = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.lbFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbFileCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lbFolders = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbFolderCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbQueue = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbQueueCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbQueueInstall = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbQueueDiscard = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvNand = new System.Windows.Forms.ListView();
            this.lvNandName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvNandID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvNandBlocks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvNandSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvNandIOS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvNandRegion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvNandContent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvNandPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvNandType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvNandVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvNandTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmNand = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmInstall = new System.Windows.Forms.ToolStripMenuItem();
            this.cmInstallWad = new System.Windows.Forms.ToolStripMenuItem();
            this.cmInstallFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsNandSaveData = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNandBackupSave = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNandRestoreSave = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNandBackupSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNandRestoreSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.cmNandPackWad = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNandPatchReturnTo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNandDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.cmNandPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.lvQueue = new System.Windows.Forms.ListBox();
            this.lvWiiGames = new System.Windows.Forms.ListView();
            this.lvwgId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwgTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwgCustomTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwgIOSrequired = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwgRegion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwgSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwgType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwgPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmWads.SuspendLayout();
            this.msMain.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.cmNand.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvWads
            // 
            this.lvWads.AllowDrop = true;
            this.lvWads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvName,
            this.lvID,
            this.lvBlocks,
            this.lvFilesize,
            this.lvIOS,
            this.lvRegion,
            this.lvData,
            this.lvPath,
            this.lvType,
            this.lvVersion,
            this.lvTitle});
            this.lvWads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWads.FullRowSelect = true;
            this.lvWads.Location = new System.Drawing.Point(0, 24);
            this.lvWads.Name = "lvWads";
            this.lvWads.Size = new System.Drawing.Size(922, 345);
            this.lvWads.TabIndex = 1;
            this.lvWads.UseCompatibleStateImageBehavior = false;
            this.lvWads.View = System.Windows.Forms.View.Details;
            this.lvWads.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvWads_ColumnClick);
            this.lvWads.SelectedIndexChanged += new System.EventHandler(this.lvWads_SelectedIndexChanged);
            this.lvWads.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvWads_DragDrop);
            this.lvWads.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvWads_DragEnter);
            this.lvWads.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvWads_MouseClick);
            this.lvWads.Resize += new System.EventHandler(this.lvWads_Resize);
            // 
            // lvName
            // 
            this.lvName.Text = "Filename";
            this.lvName.Width = 145;
            // 
            // lvID
            // 
            this.lvID.DisplayIndex = 3;
            this.lvID.Text = "Title ID";
            this.lvID.Width = 56;
            // 
            // lvBlocks
            // 
            this.lvBlocks.DisplayIndex = 5;
            this.lvBlocks.Tag = "";
            this.lvBlocks.Text = "Blocks";
            // 
            // lvFilesize
            // 
            this.lvFilesize.DisplayIndex = 6;
            this.lvFilesize.Text = "Filesize";
            this.lvFilesize.Width = 82;
            // 
            // lvIOS
            // 
            this.lvIOS.DisplayIndex = 7;
            this.lvIOS.Text = "IOS Flag";
            this.lvIOS.Width = 53;
            // 
            // lvRegion
            // 
            this.lvRegion.DisplayIndex = 8;
            this.lvRegion.Text = "Region Flag";
            this.lvRegion.Width = 70;
            // 
            // lvData
            // 
            this.lvData.DisplayIndex = 9;
            this.lvData.Tag = "Numeric";
            this.lvData.Text = "Content";
            this.lvData.Width = 49;
            // 
            // lvPath
            // 
            this.lvPath.DisplayIndex = 10;
            this.lvPath.Text = "Path";
            this.lvPath.Width = 122;
            // 
            // lvType
            // 
            this.lvType.DisplayIndex = 1;
            this.lvType.Text = "Type";
            this.lvType.Width = 78;
            // 
            // lvVersion
            // 
            this.lvVersion.DisplayIndex = 4;
            this.lvVersion.Tag = "Numeric";
            this.lvVersion.Text = "Version";
            this.lvVersion.Width = 47;
            // 
            // lvTitle
            // 
            this.lvTitle.DisplayIndex = 2;
            this.lvTitle.Text = "Channel Title";
            this.lvTitle.Width = 148;
            // 
            // cmWads
            // 
            this.cmWads.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmCopy,
            this.cmCut,
            this.cmPaste,
            this.cmRename,
            this.cmDelete,
            this.toolStripSeparator3,
            this.cmChangeTitle,
            this.cmChangeID,
            this.cmChangeIosSlot,
            this.cmChangeTitleVersion,
            this.cmChangeRegion,
            this.cmInsertDol,
            this.cmExtract,
            this.toolStripSeparator11,
            this.cmPreview,
            this.cmRestore,
            this.toolStripSeparator6,
            this.cmRemoveFolder,
            this.cmRemoveAllFolders,
            this.toolStripSeparator16,
            this.cmRefreshFolder});
            this.cmWads.Name = "cmWads";
            this.cmWads.Size = new System.Drawing.Size(189, 402);
            this.cmWads.Opening += new System.ComponentModel.CancelEventHandler(this.cmWads_Opening);
            // 
            // cmCopy
            // 
            this.cmCopy.Name = "cmCopy";
            this.cmCopy.Size = new System.Drawing.Size(188, 22);
            this.cmCopy.Text = "Copy";
            this.cmCopy.Click += new System.EventHandler(this.cmCopy_Click);
            // 
            // cmCut
            // 
            this.cmCut.Name = "cmCut";
            this.cmCut.Size = new System.Drawing.Size(188, 22);
            this.cmCut.Text = "Cut";
            this.cmCut.Click += new System.EventHandler(this.cmCut_Click);
            // 
            // cmPaste
            // 
            this.cmPaste.Name = "cmPaste";
            this.cmPaste.Size = new System.Drawing.Size(188, 22);
            this.cmPaste.Text = "Paste";
            this.cmPaste.Click += new System.EventHandler(this.cmPaste_Click);
            // 
            // cmRename
            // 
            this.cmRename.Name = "cmRename";
            this.cmRename.Size = new System.Drawing.Size(188, 22);
            this.cmRename.Text = "Rename";
            this.cmRename.Click += new System.EventHandler(this.cmRename_Click);
            // 
            // cmDelete
            // 
            this.cmDelete.Name = "cmDelete";
            this.cmDelete.Size = new System.Drawing.Size(188, 22);
            this.cmDelete.Text = "Delete";
            this.cmDelete.Click += new System.EventHandler(this.cmDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(185, 6);
            // 
            // cmChangeTitle
            // 
            this.cmChangeTitle.Enabled = false;
            this.cmChangeTitle.Name = "cmChangeTitle";
            this.cmChangeTitle.Size = new System.Drawing.Size(188, 22);
            this.cmChangeTitle.Text = "Change Channel Title";
            this.cmChangeTitle.Click += new System.EventHandler(this.cmChannelName_Click);
            // 
            // cmChangeID
            // 
            this.cmChangeID.Enabled = false;
            this.cmChangeID.Name = "cmChangeID";
            this.cmChangeID.Size = new System.Drawing.Size(188, 22);
            this.cmChangeID.Text = "Change Title ID";
            this.cmChangeID.Click += new System.EventHandler(this.cmChangeID_Click);
            // 
            // cmChangeIosSlot
            // 
            this.cmChangeIosSlot.Enabled = false;
            this.cmChangeIosSlot.Name = "cmChangeIosSlot";
            this.cmChangeIosSlot.Size = new System.Drawing.Size(188, 22);
            this.cmChangeIosSlot.Text = "Change IOS Slot";
            this.cmChangeIosSlot.Click += new System.EventHandler(this.cmChangeIosSlot_Click);
            // 
            // cmChangeTitleVersion
            // 
            this.cmChangeTitleVersion.Enabled = false;
            this.cmChangeTitleVersion.Name = "cmChangeTitleVersion";
            this.cmChangeTitleVersion.Size = new System.Drawing.Size(188, 22);
            this.cmChangeTitleVersion.Text = "Change Title Version";
            this.cmChangeTitleVersion.Click += new System.EventHandler(this.cmChangeTitleVersion_Click);
            // 
            // cmChangeRegion
            // 
            this.cmChangeRegion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmRegionFree,
            this.cmPal,
            this.cmNtscU,
            this.cmNtscJ});
            this.cmChangeRegion.Enabled = false;
            this.cmChangeRegion.Name = "cmChangeRegion";
            this.cmChangeRegion.Size = new System.Drawing.Size(188, 22);
            this.cmChangeRegion.Text = "Change Region Flag";
            // 
            // cmRegionFree
            // 
            this.cmRegionFree.Name = "cmRegionFree";
            this.cmRegionFree.Size = new System.Drawing.Size(136, 22);
            this.cmRegionFree.Text = "Region Free";
            this.cmRegionFree.Click += new System.EventHandler(this.cmRegionFree_Click);
            // 
            // cmPal
            // 
            this.cmPal.Name = "cmPal";
            this.cmPal.Size = new System.Drawing.Size(136, 22);
            this.cmPal.Text = "PAL";
            this.cmPal.Click += new System.EventHandler(this.cmPal_Click);
            // 
            // cmNtscU
            // 
            this.cmNtscU.Name = "cmNtscU";
            this.cmNtscU.Size = new System.Drawing.Size(136, 22);
            this.cmNtscU.Text = "NTSC-U";
            this.cmNtscU.Click += new System.EventHandler(this.cmNtscU_Click);
            // 
            // cmNtscJ
            // 
            this.cmNtscJ.Name = "cmNtscJ";
            this.cmNtscJ.Size = new System.Drawing.Size(136, 22);
            this.cmNtscJ.Text = "NTSC-J";
            this.cmNtscJ.Click += new System.EventHandler(this.cmNtscJ_Click);
            // 
            // cmInsertDol
            // 
            this.cmInsertDol.Enabled = false;
            this.cmInsertDol.Name = "cmInsertDol";
            this.cmInsertDol.Size = new System.Drawing.Size(188, 22);
            this.cmInsertDol.Text = "Insert Dol";
            this.cmInsertDol.Click += new System.EventHandler(this.cmInsertDol_Click);
            // 
            // cmExtract
            // 
            this.cmExtract.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmToFolder,
            this.cmToNand,
            this.toolStripSeparator8,
            this.cmExtractVcPics});
            this.cmExtract.Enabled = false;
            this.cmExtract.Name = "cmExtract";
            this.cmExtract.Size = new System.Drawing.Size(188, 22);
            this.cmExtract.Text = "Extract";
            // 
            // cmToFolder
            // 
            this.cmToFolder.Name = "cmToFolder";
            this.cmToFolder.Size = new System.Drawing.Size(125, 22);
            this.cmToFolder.Text = "To Folder";
            this.cmToFolder.Click += new System.EventHandler(this.cmToFolder_Click);
            // 
            // cmToNand
            // 
            this.cmToNand.Name = "cmToNand";
            this.cmToNand.Size = new System.Drawing.Size(125, 22);
            this.cmToNand.Text = "To NAND";
            this.cmToNand.Click += new System.EventHandler(this.cmToNAND_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(122, 6);
            // 
            // cmExtractVcPics
            // 
            this.cmExtractVcPics.Name = "cmExtractVcPics";
            this.cmExtractVcPics.Size = new System.Drawing.Size(125, 22);
            this.cmExtractVcPics.Text = "VC Pics";
            this.cmExtractVcPics.Click += new System.EventHandler(this.cmExtractVcPics_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(185, 6);
            // 
            // cmPreview
            // 
            this.cmPreview.Name = "cmPreview";
            this.cmPreview.Size = new System.Drawing.Size(188, 22);
            this.cmPreview.Text = "Preview";
            this.cmPreview.Click += new System.EventHandler(this.cmPreview_Click);
            // 
            // cmRestore
            // 
            this.cmRestore.Name = "cmRestore";
            this.cmRestore.Size = new System.Drawing.Size(188, 22);
            this.cmRestore.Text = "Restore Backup";
            this.cmRestore.Click += new System.EventHandler(this.cmRestore_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(185, 6);
            // 
            // cmRemoveFolder
            // 
            this.cmRemoveFolder.Name = "cmRemoveFolder";
            this.cmRemoveFolder.Size = new System.Drawing.Size(188, 22);
            this.cmRemoveFolder.Text = "Remove This Folder";
            this.cmRemoveFolder.Click += new System.EventHandler(this.cmRemoveFolder_Click);
            // 
            // cmRemoveAllFolders
            // 
            this.cmRemoveAllFolders.Name = "cmRemoveAllFolders";
            this.cmRemoveAllFolders.Size = new System.Drawing.Size(188, 22);
            this.cmRemoveAllFolders.Text = "Remove All Folders";
            this.cmRemoveAllFolders.Click += new System.EventHandler(this.cmRemoveAllFolders_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(185, 6);
            // 
            // cmRefreshFolder
            // 
            this.cmRefreshFolder.Name = "cmRefreshFolder";
            this.cmRefreshFolder.Size = new System.Drawing.Size(188, 22);
            this.cmRefreshFolder.Text = "Refresh This Folder";
            this.cmRefreshFolder.Click += new System.EventHandler(this.cmRefreshFolder_Click);
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFile,
            this.tsEdit,
            this.tsOptions,
            this.tsTools,
            this.tsView,
            this.tsHelp});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(922, 24);
            this.msMain.TabIndex = 2;
            this.msMain.Text = "menuStrip1";
            this.msMain.MouseEnter += new System.EventHandler(this.msMain_MouseEnter);
            // 
            // tsFile
            // 
            this.tsFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnExport,
            this.btnRefresh,
            this.toolStripSeparator1,
            this.tsMru,
            this.mruSeparator,
            this.btnExit});
            this.tsFile.Name = "tsFile";
            this.tsFile.Size = new System.Drawing.Size(37, 20);
            this.tsFile.Text = "File";
            // 
            // btnOpen
            // 
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.btnOpen.Size = new System.Drawing.Size(182, 22);
            this.btnOpen.Text = "Open Folder";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.btnExport.Size = new System.Drawing.Size(182, 22);
            this.btnExport.Text = "Export to File";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.btnRefresh.Size = new System.Drawing.Size(182, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // tsMru
            // 
            this.tsMru.Name = "tsMru";
            this.tsMru.Size = new System.Drawing.Size(182, 22);
            this.tsMru.Text = "Most Recently Used";
            // 
            // mruSeparator
            // 
            this.mruSeparator.Name = "mruSeparator";
            this.mruSeparator.Size = new System.Drawing.Size(179, 6);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(182, 22);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tsEdit
            // 
            this.tsEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopy,
            this.btnCut,
            this.btnPaste,
            this.btnRename,
            this.btnDelete,
            this.toolStripSeparator2,
            this.btnChangeTitle,
            this.btnChangeID,
            this.btnChangeIosSlot,
            this.btnChangeTitleVersion,
            this.tsChangeRegion,
            this.btnInsertDol,
            this.tsExtract,
            this.toolStripSeparator12,
            this.btnPreview,
            this.btnRestore});
            this.tsEdit.Name = "tsEdit";
            this.tsEdit.Size = new System.Drawing.Size(39, 20);
            this.tsEdit.Text = "Edit";
            this.tsEdit.Click += new System.EventHandler(this.tsEdit_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.btnCopy.Size = new System.Drawing.Size(188, 22);
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.cmCopy_Click);
            // 
            // btnCut
            // 
            this.btnCut.Name = "btnCut";
            this.btnCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.btnCut.Size = new System.Drawing.Size(188, 22);
            this.btnCut.Text = "Cut";
            this.btnCut.Click += new System.EventHandler(this.cmCut_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.btnPaste.Size = new System.Drawing.Size(188, 22);
            this.btnPaste.Text = "Paste";
            this.btnPaste.Click += new System.EventHandler(this.cmPaste_Click);
            // 
            // btnRename
            // 
            this.btnRename.Name = "btnRename";
            this.btnRename.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.btnRename.Size = new System.Drawing.Size(188, 22);
            this.btnRename.Text = "Rename";
            this.btnRename.Click += new System.EventHandler(this.cmRename_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.btnDelete.Size = new System.Drawing.Size(188, 22);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.cmDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(185, 6);
            // 
            // btnChangeTitle
            // 
            this.btnChangeTitle.Enabled = false;
            this.btnChangeTitle.Name = "btnChangeTitle";
            this.btnChangeTitle.Size = new System.Drawing.Size(188, 22);
            this.btnChangeTitle.Text = "Change Channel Title";
            this.btnChangeTitle.Click += new System.EventHandler(this.cmChannelName_Click);
            // 
            // btnChangeID
            // 
            this.btnChangeID.Enabled = false;
            this.btnChangeID.Name = "btnChangeID";
            this.btnChangeID.Size = new System.Drawing.Size(188, 22);
            this.btnChangeID.Text = "Change Title ID";
            this.btnChangeID.Click += new System.EventHandler(this.cmChangeID_Click);
            // 
            // btnChangeIosSlot
            // 
            this.btnChangeIosSlot.Enabled = false;
            this.btnChangeIosSlot.Name = "btnChangeIosSlot";
            this.btnChangeIosSlot.Size = new System.Drawing.Size(188, 22);
            this.btnChangeIosSlot.Text = "Change IOS Slot";
            this.btnChangeIosSlot.Click += new System.EventHandler(this.cmChangeIosSlot_Click);
            // 
            // btnChangeTitleVersion
            // 
            this.btnChangeTitleVersion.Enabled = false;
            this.btnChangeTitleVersion.Name = "btnChangeTitleVersion";
            this.btnChangeTitleVersion.Size = new System.Drawing.Size(188, 22);
            this.btnChangeTitleVersion.Text = "Change Title Version";
            this.btnChangeTitleVersion.Click += new System.EventHandler(this.cmChangeTitleVersion_Click);
            // 
            // tsChangeRegion
            // 
            this.tsChangeRegion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRegionFree,
            this.btnPal,
            this.btnNtscU,
            this.btnNtscJ});
            this.tsChangeRegion.Enabled = false;
            this.tsChangeRegion.Name = "tsChangeRegion";
            this.tsChangeRegion.Size = new System.Drawing.Size(188, 22);
            this.tsChangeRegion.Text = "Change Region Flag";
            // 
            // btnRegionFree
            // 
            this.btnRegionFree.Name = "btnRegionFree";
            this.btnRegionFree.Size = new System.Drawing.Size(136, 22);
            this.btnRegionFree.Text = "Region Free";
            this.btnRegionFree.Click += new System.EventHandler(this.cmRegionFree_Click);
            // 
            // btnPal
            // 
            this.btnPal.Name = "btnPal";
            this.btnPal.Size = new System.Drawing.Size(136, 22);
            this.btnPal.Text = "PAL";
            this.btnPal.Click += new System.EventHandler(this.cmPal_Click);
            // 
            // btnNtscU
            // 
            this.btnNtscU.Name = "btnNtscU";
            this.btnNtscU.Size = new System.Drawing.Size(136, 22);
            this.btnNtscU.Text = "NTSC-U";
            this.btnNtscU.Click += new System.EventHandler(this.cmNtscU_Click);
            // 
            // btnNtscJ
            // 
            this.btnNtscJ.Name = "btnNtscJ";
            this.btnNtscJ.Size = new System.Drawing.Size(136, 22);
            this.btnNtscJ.Text = "NTSC-J";
            this.btnNtscJ.Click += new System.EventHandler(this.cmNtscJ_Click);
            // 
            // btnInsertDol
            // 
            this.btnInsertDol.Enabled = false;
            this.btnInsertDol.Name = "btnInsertDol";
            this.btnInsertDol.Size = new System.Drawing.Size(188, 22);
            this.btnInsertDol.Text = "Insert Dol";
            this.btnInsertDol.Click += new System.EventHandler(this.cmInsertDol_Click);
            // 
            // tsExtract
            // 
            this.tsExtract.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnToFolder,
            this.btnToNand});
            this.tsExtract.Enabled = false;
            this.tsExtract.Name = "tsExtract";
            this.tsExtract.Size = new System.Drawing.Size(188, 22);
            this.tsExtract.Text = "Extract";
            // 
            // btnToFolder
            // 
            this.btnToFolder.Name = "btnToFolder";
            this.btnToFolder.Size = new System.Drawing.Size(125, 22);
            this.btnToFolder.Text = "To Folder";
            this.btnToFolder.Click += new System.EventHandler(this.cmToFolder_Click);
            // 
            // btnToNand
            // 
            this.btnToNand.Name = "btnToNand";
            this.btnToNand.Size = new System.Drawing.Size(125, 22);
            this.btnToNand.Text = "To NAND";
            this.btnToNand.Click += new System.EventHandler(this.cmToNAND_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(185, 6);
            // 
            // btnPreview
            // 
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(188, 22);
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.cmPreview_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(188, 22);
            this.btnRestore.Text = "Restore Backup";
            this.btnRestore.Click += new System.EventHandler(this.cmRestore_Click);
            // 
            // tsOptions
            // 
            this.tsOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNandPath,
            this.btnWiiGamePath,
            this.toolStripSeparator5,
            this.btnSaveFolders,
            this.btnShowPath,
            this.btnAutoResize,
            this.btnCreateBackups,
            this.btnAddSub,
            this.btnShowSplash,
            this.btnPortableMode,
            this.toolStripSeparator4,
            this.tsLanguage});
            this.tsOptions.Name = "tsOptions";
            this.tsOptions.Size = new System.Drawing.Size(61, 20);
            this.tsOptions.Text = "Options";
            // 
            // btnNandPath
            // 
            this.btnNandPath.Name = "btnNandPath";
            this.btnNandPath.Size = new System.Drawing.Size(234, 22);
            this.btnNandPath.Text = "Set NAND Backup Path";
            this.btnNandPath.Click += new System.EventHandler(this.btnNandPath_Click);
            // 
            // btnWiiGamePath
            // 
            this.btnWiiGamePath.Name = "btnWiiGamePath";
            this.btnWiiGamePath.Size = new System.Drawing.Size(234, 22);
            this.btnWiiGamePath.Text = "Set Wii Game Backup Path";
            this.btnWiiGamePath.Click += new System.EventHandler(this.btnWiiGamePath_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(231, 6);
            // 
            // btnSaveFolders
            // 
            this.btnSaveFolders.Checked = true;
            this.btnSaveFolders.CheckOnClick = true;
            this.btnSaveFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnSaveFolders.Name = "btnSaveFolders";
            this.btnSaveFolders.Size = new System.Drawing.Size(234, 22);
            this.btnSaveFolders.Text = "Save Folders";
            this.btnSaveFolders.Click += new System.EventHandler(this.btnSaveFolders_Click);
            // 
            // btnShowPath
            // 
            this.btnShowPath.Checked = true;
            this.btnShowPath.CheckOnClick = true;
            this.btnShowPath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnShowPath.Name = "btnShowPath";
            this.btnShowPath.Size = new System.Drawing.Size(234, 22);
            this.btnShowPath.Text = "Show Path In Groupnames";
            this.btnShowPath.Click += new System.EventHandler(this.btnShowPath_Click);
            // 
            // btnAutoResize
            // 
            this.btnAutoResize.Checked = true;
            this.btnAutoResize.CheckOnClick = true;
            this.btnAutoResize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnAutoResize.Name = "btnAutoResize";
            this.btnAutoResize.Size = new System.Drawing.Size(234, 22);
            this.btnAutoResize.Text = "Resize Columns Automatically";
            this.btnAutoResize.Click += new System.EventHandler(this.btnAutoResize_Click);
            // 
            // btnCreateBackups
            // 
            this.btnCreateBackups.CheckOnClick = true;
            this.btnCreateBackups.Name = "btnCreateBackups";
            this.btnCreateBackups.Size = new System.Drawing.Size(234, 22);
            this.btnCreateBackups.Text = "Create Backups Before Editing";
            this.btnCreateBackups.Click += new System.EventHandler(this.btnCreateBackups_Click);
            // 
            // btnAddSub
            // 
            this.btnAddSub.CheckOnClick = true;
            this.btnAddSub.Name = "btnAddSub";
            this.btnAddSub.Size = new System.Drawing.Size(234, 22);
            this.btnAddSub.Text = "Add Subfolders";
            this.btnAddSub.Click += new System.EventHandler(this.btnAddSub_Click);
            // 
            // btnShowSplash
            // 
            this.btnShowSplash.Checked = true;
            this.btnShowSplash.CheckOnClick = true;
            this.btnShowSplash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnShowSplash.Name = "btnShowSplash";
            this.btnShowSplash.Size = new System.Drawing.Size(234, 22);
            this.btnShowSplash.Text = "Show SplashScreen";
            this.btnShowSplash.Click += new System.EventHandler(this.btnShowSplash_Click);
            // 
            // btnPortableMode
            // 
            this.btnPortableMode.CheckOnClick = true;
            this.btnPortableMode.Name = "btnPortableMode";
            this.btnPortableMode.Size = new System.Drawing.Size(234, 22);
            this.btnPortableMode.Text = "Portable Mode";
            this.btnPortableMode.Click += new System.EventHandler(this.btnPortableMode_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(231, 6);
            // 
            // tsLanguage
            // 
            this.tsLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEnglish,
            this.btnGerman,
            this.btnFrench,
            this.btnItalian,
            this.btnSpanish,
            this.btnNorwegian,
            this.btnPortuguese,
            this.btnJapanese,
            this.btnChinese,
            this.toolStripSeparator7,
            this.btnFromFile});
            this.tsLanguage.Name = "tsLanguage";
            this.tsLanguage.Size = new System.Drawing.Size(234, 22);
            this.tsLanguage.Text = "Language";
            // 
            // btnEnglish
            // 
            this.btnEnglish.Checked = true;
            this.btnEnglish.CheckOnClick = true;
            this.btnEnglish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.Size = new System.Drawing.Size(128, 22);
            this.btnEnglish.Text = "English";
            this.btnEnglish.Click += new System.EventHandler(this.btnEnglish_Click);
            // 
            // btnGerman
            // 
            this.btnGerman.CheckOnClick = true;
            this.btnGerman.Name = "btnGerman";
            this.btnGerman.Size = new System.Drawing.Size(128, 22);
            this.btnGerman.Text = "Deutsch";
            this.btnGerman.Click += new System.EventHandler(this.btnGerman_Click);
            // 
            // btnFrench
            // 
            this.btnFrench.CheckOnClick = true;
            this.btnFrench.Name = "btnFrench";
            this.btnFrench.Size = new System.Drawing.Size(128, 22);
            this.btnFrench.Text = "Français";
            this.btnFrench.Click += new System.EventHandler(this.btnFrench_Click);
            // 
            // btnItalian
            // 
            this.btnItalian.CheckOnClick = true;
            this.btnItalian.Name = "btnItalian";
            this.btnItalian.Size = new System.Drawing.Size(128, 22);
            this.btnItalian.Text = "Italiano";
            this.btnItalian.Click += new System.EventHandler(this.btnItalian_Click);
            // 
            // btnSpanish
            // 
            this.btnSpanish.CheckOnClick = true;
            this.btnSpanish.Name = "btnSpanish";
            this.btnSpanish.Size = new System.Drawing.Size(128, 22);
            this.btnSpanish.Text = "Español";
            this.btnSpanish.Click += new System.EventHandler(this.btnSpanish_Click);
            // 
            // btnNorwegian
            // 
            this.btnNorwegian.CheckOnClick = true;
            this.btnNorwegian.Name = "btnNorwegian";
            this.btnNorwegian.Size = new System.Drawing.Size(128, 22);
            this.btnNorwegian.Text = "Norsk";
            this.btnNorwegian.Click += new System.EventHandler(this.btnNorwegian_Click);
            // 
            // btnPortuguese
            // 
            this.btnPortuguese.CheckOnClick = true;
            this.btnPortuguese.Name = "btnPortuguese";
            this.btnPortuguese.Size = new System.Drawing.Size(128, 22);
            this.btnPortuguese.Text = "Português";
            this.btnPortuguese.Click += new System.EventHandler(this.btnPortuguese_Click);
            // 
            // btnJapanese
            // 
            this.btnJapanese.CheckOnClick = true;
            this.btnJapanese.Name = "btnJapanese";
            this.btnJapanese.Size = new System.Drawing.Size(128, 22);
            this.btnJapanese.Text = "Japanese";
            this.btnJapanese.Click += new System.EventHandler(this.btnJapanese_Click);
            // 
            // btnChinese
            // 
            this.btnChinese.CheckOnClick = true;
            this.btnChinese.Name = "btnChinese";
            this.btnChinese.Size = new System.Drawing.Size(128, 22);
            this.btnChinese.Text = "Chinese";
            this.btnChinese.Click += new System.EventHandler(this.btnChinese_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(125, 6);
            // 
            // btnFromFile
            // 
            this.btnFromFile.CheckOnClick = true;
            this.btnFromFile.Name = "btnFromFile";
            this.btnFromFile.Size = new System.Drawing.Size(128, 22);
            this.btnFromFile.Text = "From File";
            this.btnFromFile.Click += new System.EventHandler(this.btnFromFile_Click);
            // 
            // tsTools
            // 
            this.tsTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPackWad,
            this.btnUnpackU8,
            this.tsPackU8,
            this.btnConvertFromTpl,
            this.tsConvertToTpl,
            this.btnLz77Compress,
            this.btnLz77Decompress,
            this.toolStripSeparator14,
            this.btnExtractBootmiiDump,
            this.btnCreateNANDFromScratch});
            this.tsTools.Name = "tsTools";
            this.tsTools.Size = new System.Drawing.Size(48, 20);
            this.tsTools.Text = "Tools";
            // 
            // btnPackWad
            // 
            this.btnPackWad.Name = "btnPackWad";
            this.btnPackWad.Size = new System.Drawing.Size(218, 22);
            this.btnPackWad.Text = "Pack Wad";
            this.btnPackWad.Click += new System.EventHandler(this.btnPackWad_Click);
            // 
            // btnUnpackU8
            // 
            this.btnUnpackU8.Name = "btnUnpackU8";
            this.btnUnpackU8.Size = new System.Drawing.Size(218, 22);
            this.btnUnpackU8.Text = "Unpack U8 Archive";
            this.btnUnpackU8.Click += new System.EventHandler(this.btnUnpackU8_Click);
            // 
            // tsPackU8
            // 
            this.tsPackU8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPackU8WithoutHeader,
            this.btnPackU8WithIMD5,
            this.btnPackU8WithIMET});
            this.tsPackU8.Name = "tsPackU8";
            this.tsPackU8.Size = new System.Drawing.Size(218, 22);
            this.tsPackU8.Text = "Pack U8 Archive";
            // 
            // btnPackU8WithoutHeader
            // 
            this.btnPackU8WithoutHeader.Name = "btnPackU8WithoutHeader";
            this.btnPackU8WithoutHeader.Size = new System.Drawing.Size(293, 22);
            this.btnPackU8WithoutHeader.Text = "Without Header";
            this.btnPackU8WithoutHeader.Click += new System.EventHandler(this.btnPackU8WithoutHeader_Click);
            // 
            // btnPackU8WithIMD5
            // 
            this.btnPackU8WithIMD5.Name = "btnPackU8WithIMD5";
            this.btnPackU8WithIMD5.Size = new System.Drawing.Size(293, 22);
            this.btnPackU8WithIMD5.Text = "With IMD5 Header (Banner.bin / Icon.bin)";
            this.btnPackU8WithIMD5.Click += new System.EventHandler(this.btnPackU8WithIMD5_Click);
            // 
            // btnPackU8WithIMET
            // 
            this.btnPackU8WithIMET.Name = "btnPackU8WithIMET";
            this.btnPackU8WithIMET.Size = new System.Drawing.Size(293, 22);
            this.btnPackU8WithIMET.Text = "With IMET Header (00000000.app)";
            this.btnPackU8WithIMET.Click += new System.EventHandler(this.btnPackU8WithIMET_Click);
            // 
            // btnConvertFromTpl
            // 
            this.btnConvertFromTpl.Name = "btnConvertFromTpl";
            this.btnConvertFromTpl.Size = new System.Drawing.Size(218, 22);
            this.btnConvertFromTpl.Text = "Convert Tpl To Image";
            this.btnConvertFromTpl.Click += new System.EventHandler(this.btnConvertFromTpl_Click);
            // 
            // tsConvertToTpl
            // 
            this.tsConvertToTpl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAsRGBA8,
            this.btnAsRGB565,
            this.btnAsRGB5A3});
            this.tsConvertToTpl.Name = "tsConvertToTpl";
            this.tsConvertToTpl.Size = new System.Drawing.Size(218, 22);
            this.tsConvertToTpl.Text = "Convert Image To Tpl";
            // 
            // btnAsRGBA8
            // 
            this.btnAsRGBA8.Name = "btnAsRGBA8";
            this.btnAsRGBA8.Size = new System.Drawing.Size(233, 22);
            this.btnAsRGBA8.Text = "As RGBA8 (High Quality)";
            this.btnAsRGBA8.Click += new System.EventHandler(this.btnAsRGBA8_Click);
            // 
            // btnAsRGB565
            // 
            this.btnAsRGB565.Name = "btnAsRGB565";
            this.btnAsRGB565.Size = new System.Drawing.Size(233, 22);
            this.btnAsRGB565.Text = "As RGB565 (Moderate Quality)";
            this.btnAsRGB565.Click += new System.EventHandler(this.btnAsRGB565_Click);
            // 
            // btnAsRGB5A3
            // 
            this.btnAsRGB5A3.Name = "btnAsRGB5A3";
            this.btnAsRGB5A3.Size = new System.Drawing.Size(233, 22);
            this.btnAsRGB5A3.Text = "As RGB5A3 (Low Quality)";
            this.btnAsRGB5A3.Click += new System.EventHandler(this.btnAsRGB5A3_Click);
            // 
            // btnLz77Compress
            // 
            this.btnLz77Compress.Name = "btnLz77Compress";
            this.btnLz77Compress.Size = new System.Drawing.Size(218, 22);
            this.btnLz77Compress.Text = "Lz77 Compress File";
            this.btnLz77Compress.Click += new System.EventHandler(this.btnLz77Compress_Click);
            // 
            // btnLz77Decompress
            // 
            this.btnLz77Decompress.Name = "btnLz77Decompress";
            this.btnLz77Decompress.Size = new System.Drawing.Size(218, 22);
            this.btnLz77Decompress.Text = "Lz77 Decompress File";
            this.btnLz77Decompress.Click += new System.EventHandler(this.btnLz77Decompress_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(215, 6);
            // 
            // btnExtractBootmiiDump
            // 
            this.btnExtractBootmiiDump.Name = "btnExtractBootmiiDump";
            this.btnExtractBootmiiDump.Size = new System.Drawing.Size(218, 22);
            this.btnExtractBootmiiDump.Text = "Extract BootMii Dump";
            this.btnExtractBootmiiDump.Click += new System.EventHandler(this.btnExtractBootmiiDump_Click);
            // 
            // btnCreateNANDFromScratch
            // 
            this.btnCreateNANDFromScratch.Name = "btnCreateNANDFromScratch";
            this.btnCreateNANDFromScratch.Size = new System.Drawing.Size(218, 22);
            this.btnCreateNANDFromScratch.Text = "Create NAND From Scratch";
            this.btnCreateNANDFromScratch.Click += new System.EventHandler(this.btnCreateNANDFromScratch_Click);
            // 
            // tsView
            // 
            this.tsView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowMiiWads,
            this.btnShowMiiNand,
            this.btnShowMiiWiiGames});
            this.tsView.Name = "tsView";
            this.tsView.Size = new System.Drawing.Size(44, 20);
            this.tsView.Text = "View";
            // 
            // btnShowMiiWads
            // 
            this.btnShowMiiWads.Checked = true;
            this.btnShowMiiWads.CheckOnClick = true;
            this.btnShowMiiWads.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnShowMiiWads.Name = "btnShowMiiWads";
            this.btnShowMiiWads.Size = new System.Drawing.Size(173, 22);
            this.btnShowMiiWads.Text = "ShowMiiWads";
            this.btnShowMiiWads.Click += new System.EventHandler(this.btnShowMiiWads_Click);
            // 
            // btnShowMiiNand
            // 
            this.btnShowMiiNand.CheckOnClick = true;
            this.btnShowMiiNand.Name = "btnShowMiiNand";
            this.btnShowMiiNand.Size = new System.Drawing.Size(173, 22);
            this.btnShowMiiNand.Text = "ShowMiiNand";
            this.btnShowMiiNand.Click += new System.EventHandler(this.btnShowMiiNand_Click);
            // 
            // btnShowMiiWiiGames
            // 
            this.btnShowMiiWiiGames.CheckOnClick = true;
            this.btnShowMiiWiiGames.Name = "btnShowMiiWiiGames";
            this.btnShowMiiWiiGames.Size = new System.Drawing.Size(173, 22);
            this.btnShowMiiWiiGames.Text = "ShowMiiWiiGames";
            this.btnShowMiiWiiGames.Click += new System.EventHandler(this.btnShowMiiWiiGames_Click);
            // 
            // tsHelp
            // 
            this.tsHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUpdateCheck,
            this.toolStripSeparator15,
            this.btnDisclaimer,
            this.btnAbout});
            this.tsHelp.Name = "tsHelp";
            this.tsHelp.Size = new System.Drawing.Size(44, 20);
            this.tsHelp.Text = "Help";
            // 
            // btnUpdateCheck
            // 
            this.btnUpdateCheck.Enabled = false;
            this.btnUpdateCheck.Name = "btnUpdateCheck";
            this.btnUpdateCheck.Size = new System.Drawing.Size(168, 22);
            this.btnUpdateCheck.Text = "Check For Update";
            this.btnUpdateCheck.Click += new System.EventHandler(this.btnUpdateCheck_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(165, 6);
            // 
            // btnDisclaimer
            // 
            this.btnDisclaimer.Name = "btnDisclaimer";
            this.btnDisclaimer.Size = new System.Drawing.Size(168, 22);
            this.btnDisclaimer.Text = "Disclaimer";
            this.btnDisclaimer.Click += new System.EventHandler(this.btnDisclaimer_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(168, 22);
            this.btnAbout.Text = "About";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbFiles,
            this.lbFileCount,
            this.pbProgress,
            this.lbFolders,
            this.lbFolderCount,
            this.lbQueue,
            this.lbQueueCount,
            this.lbQueueInstall,
            this.lbQueueDiscard});
            this.ssMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ssMain.Location = new System.Drawing.Point(0, 347);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(922, 22);
            this.ssMain.TabIndex = 3;
            this.ssMain.Text = "statusStrip1";
            // 
            // lbFiles
            // 
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(33, 17);
            this.lbFiles.Text = "Files:";
            // 
            // lbFileCount
            // 
            this.lbFileCount.AutoSize = false;
            this.lbFileCount.Name = "lbFileCount";
            this.lbFileCount.Size = new System.Drawing.Size(35, 17);
            this.lbFileCount.Text = "0";
            this.lbFileCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pbProgress
            // 
            this.pbProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(100, 16);
            this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbProgress.Value = 100;
            // 
            // lbFolders
            // 
            this.lbFolders.Name = "lbFolders";
            this.lbFolders.Size = new System.Drawing.Size(48, 17);
            this.lbFolders.Text = "Folders:";
            // 
            // lbFolderCount
            // 
            this.lbFolderCount.AutoSize = false;
            this.lbFolderCount.Name = "lbFolderCount";
            this.lbFolderCount.Size = new System.Drawing.Size(35, 17);
            this.lbFolderCount.Text = "0";
            this.lbFolderCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbQueue
            // 
            this.lbQueue.Name = "lbQueue";
            this.lbQueue.Size = new System.Drawing.Size(45, 17);
            this.lbQueue.Text = "Queue:";
            this.lbQueue.Visible = false;
            // 
            // lbQueueCount
            // 
            this.lbQueueCount.AutoSize = false;
            this.lbQueueCount.Name = "lbQueueCount";
            this.lbQueueCount.Size = new System.Drawing.Size(35, 17);
            this.lbQueueCount.Text = "0";
            this.lbQueueCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbQueueCount.Visible = false;
            // 
            // lbQueueInstall
            // 
            this.lbQueueInstall.IsLink = true;
            this.lbQueueInstall.Name = "lbQueueInstall";
            this.lbQueueInstall.Size = new System.Drawing.Size(38, 17);
            this.lbQueueInstall.Text = "Install";
            this.lbQueueInstall.Visible = false;
            this.lbQueueInstall.Click += new System.EventHandler(this.lbQueueInstall_Click);
            // 
            // lbQueueDiscard
            // 
            this.lbQueueDiscard.IsLink = true;
            this.lbQueueDiscard.Name = "lbQueueDiscard";
            this.lbQueueDiscard.Size = new System.Drawing.Size(46, 17);
            this.lbQueueDiscard.Text = "Discard";
            this.lbQueueDiscard.Visible = false;
            this.lbQueueDiscard.Click += new System.EventHandler(this.lbQueueDiscard_Click);
            // 
            // lvNand
            // 
            this.lvNand.AllowDrop = true;
            this.lvNand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvNandName,
            this.lvNandID,
            this.lvNandBlocks,
            this.lvNandSize,
            this.lvNandIOS,
            this.lvNandRegion,
            this.lvNandContent,
            this.lvNandPath,
            this.lvNandType,
            this.lvNandVersion,
            this.lvNandTitle});
            this.lvNand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvNand.FullRowSelect = true;
            this.lvNand.Location = new System.Drawing.Point(0, 24);
            this.lvNand.Name = "lvNand";
            this.lvNand.ShowGroups = false;
            this.lvNand.Size = new System.Drawing.Size(922, 323);
            this.lvNand.TabIndex = 4;
            this.lvNand.UseCompatibleStateImageBehavior = false;
            this.lvNand.View = System.Windows.Forms.View.Details;
            this.lvNand.Visible = false;
            this.lvNand.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvNand_ColumnClick);
            this.lvNand.SelectedIndexChanged += new System.EventHandler(this.lvNand_SelectedIndexChanged);
            this.lvNand.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvNand_DragDrop);
            this.lvNand.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvNand_DragEnter);
            this.lvNand.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvNand_MouseClick);
            this.lvNand.Resize += new System.EventHandler(this.lvNand_Resize);
            // 
            // lvNandName
            // 
            this.lvNandName.Text = "Filename";
            this.lvNandName.Width = 145;
            // 
            // lvNandID
            // 
            this.lvNandID.DisplayIndex = 3;
            this.lvNandID.Text = "Title ID";
            this.lvNandID.Width = 56;
            // 
            // lvNandBlocks
            // 
            this.lvNandBlocks.DisplayIndex = 5;
            this.lvNandBlocks.Tag = "Numeric";
            this.lvNandBlocks.Text = "Blocks";
            // 
            // lvNandSize
            // 
            this.lvNandSize.DisplayIndex = 6;
            this.lvNandSize.Text = "Size";
            this.lvNandSize.Width = 82;
            // 
            // lvNandIOS
            // 
            this.lvNandIOS.DisplayIndex = 7;
            this.lvNandIOS.Text = "IOS Flag";
            this.lvNandIOS.Width = 53;
            // 
            // lvNandRegion
            // 
            this.lvNandRegion.DisplayIndex = 8;
            this.lvNandRegion.Text = "Region Flag";
            this.lvNandRegion.Width = 70;
            // 
            // lvNandContent
            // 
            this.lvNandContent.DisplayIndex = 9;
            this.lvNandContent.Tag = "Numeric";
            this.lvNandContent.Text = "Content";
            this.lvNandContent.Width = 49;
            // 
            // lvNandPath
            // 
            this.lvNandPath.DisplayIndex = 10;
            this.lvNandPath.Text = "Path";
            this.lvNandPath.Width = 122;
            // 
            // lvNandType
            // 
            this.lvNandType.DisplayIndex = 1;
            this.lvNandType.Text = "Type";
            this.lvNandType.Width = 78;
            // 
            // lvNandVersion
            // 
            this.lvNandVersion.DisplayIndex = 4;
            this.lvNandVersion.Tag = "Numeric";
            this.lvNandVersion.Text = "Version";
            this.lvNandVersion.Width = 47;
            // 
            // lvNandTitle
            // 
            this.lvNandTitle.DisplayIndex = 2;
            this.lvNandTitle.Text = "Channel Title";
            this.lvNandTitle.Width = 148;
            // 
            // cmNand
            // 
            this.cmNand.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmInstall,
            this.tsNandSaveData,
            this.toolStripSeparator10,
            this.cmNandPackWad,
            this.cmNandPatchReturnTo,
            this.cmNandDelete,
            this.toolStripSeparator13,
            this.cmNandPreview});
            this.cmNand.Name = "cmNand";
            this.cmNand.Size = new System.Drawing.Size(160, 148);
            // 
            // cmInstall
            // 
            this.cmInstall.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmInstallWad,
            this.cmInstallFolder});
            this.cmInstall.Name = "cmInstall";
            this.cmInstall.Size = new System.Drawing.Size(159, 22);
            this.cmInstall.Text = "Install";
            // 
            // cmInstallWad
            // 
            this.cmInstallWad.Name = "cmInstallWad";
            this.cmInstallWad.Size = new System.Drawing.Size(107, 22);
            this.cmInstallWad.Text = "Wad";
            this.cmInstallWad.Click += new System.EventHandler(this.cmInstallWad_Click);
            // 
            // cmInstallFolder
            // 
            this.cmInstallFolder.Name = "cmInstallFolder";
            this.cmInstallFolder.Size = new System.Drawing.Size(107, 22);
            this.cmInstallFolder.Text = "Folder";
            this.cmInstallFolder.Click += new System.EventHandler(this.cmInstallFolder_Click);
            // 
            // tsNandSaveData
            // 
            this.tsNandSaveData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmNandBackupSave,
            this.cmNandRestoreSave,
            this.cmNandBackupSaveAll,
            this.cmNandRestoreSaveAll});
            this.tsNandSaveData.Name = "tsNandSaveData";
            this.tsNandSaveData.Size = new System.Drawing.Size(159, 22);
            this.tsNandSaveData.Text = "Savedata";
            // 
            // cmNandBackupSave
            // 
            this.cmNandBackupSave.Name = "cmNandBackupSave";
            this.cmNandBackupSave.Size = new System.Drawing.Size(130, 22);
            this.cmNandBackupSave.Text = "Backup";
            this.cmNandBackupSave.Click += new System.EventHandler(this.cmNandBackupSave_Click);
            // 
            // cmNandRestoreSave
            // 
            this.cmNandRestoreSave.Name = "cmNandRestoreSave";
            this.cmNandRestoreSave.Size = new System.Drawing.Size(130, 22);
            this.cmNandRestoreSave.Text = "Restore";
            this.cmNandRestoreSave.Click += new System.EventHandler(this.cmNandRestoreSave_Click);
            // 
            // cmNandBackupSaveAll
            // 
            this.cmNandBackupSaveAll.Name = "cmNandBackupSaveAll";
            this.cmNandBackupSaveAll.Size = new System.Drawing.Size(130, 22);
            this.cmNandBackupSaveAll.Text = "Backup All";
            this.cmNandBackupSaveAll.Click += new System.EventHandler(this.cmNandBackupSaveAll_Click);
            // 
            // cmNandRestoreSaveAll
            // 
            this.cmNandRestoreSaveAll.Name = "cmNandRestoreSaveAll";
            this.cmNandRestoreSaveAll.Size = new System.Drawing.Size(130, 22);
            this.cmNandRestoreSaveAll.Text = "Restore All";
            this.cmNandRestoreSaveAll.Click += new System.EventHandler(this.cmNandRestoreSaveAll_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(156, 6);
            // 
            // cmNandPackWad
            // 
            this.cmNandPackWad.Name = "cmNandPackWad";
            this.cmNandPackWad.Size = new System.Drawing.Size(159, 22);
            this.cmNandPackWad.Text = "Pack To Wad";
            this.cmNandPackWad.Click += new System.EventHandler(this.btnPackToWad_Click);
            // 
            // cmNandPatchReturnTo
            // 
            this.cmNandPatchReturnTo.Name = "cmNandPatchReturnTo";
            this.cmNandPatchReturnTo.Size = new System.Drawing.Size(159, 22);
            this.cmNandPatchReturnTo.Text = "Patch Return To";
            this.cmNandPatchReturnTo.Visible = false;
            this.cmNandPatchReturnTo.Click += new System.EventHandler(this.cmNandPatchReturnTo_Click);
            // 
            // cmNandDelete
            // 
            this.cmNandDelete.Name = "cmNandDelete";
            this.cmNandDelete.Size = new System.Drawing.Size(159, 22);
            this.cmNandDelete.Text = "Delete";
            this.cmNandDelete.Click += new System.EventHandler(this.cmDelete_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(156, 6);
            // 
            // cmNandPreview
            // 
            this.cmNandPreview.Name = "cmNandPreview";
            this.cmNandPreview.Size = new System.Drawing.Size(159, 22);
            this.cmNandPreview.Text = "Preview";
            this.cmNandPreview.Click += new System.EventHandler(this.cmPreview_Click);
            // 
            // lvQueue
            // 
            this.lvQueue.FormattingEnabled = true;
            this.lvQueue.Location = new System.Drawing.Point(858, 305);
            this.lvQueue.Name = "lvQueue";
            this.lvQueue.Size = new System.Drawing.Size(44, 30);
            this.lvQueue.TabIndex = 5;
            this.lvQueue.Visible = false;
            // 
            // lvWiiGames
            // 
            this.lvWiiGames.AllowDrop = true;
            this.lvWiiGames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvwgId,
            this.lvwgTitle,
            this.lvwgCustomTitle,
            this.lvwgIOSrequired,
            this.lvwgRegion,
            this.lvwgSize,
            this.lvwgType,
            this.lvwgPath});
            this.lvWiiGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWiiGames.FullRowSelect = true;
            this.lvWiiGames.Location = new System.Drawing.Point(0, 24);
            this.lvWiiGames.Name = "lvWiiGames";
            this.lvWiiGames.Size = new System.Drawing.Size(922, 323);
            this.lvWiiGames.TabIndex = 6;
            this.lvWiiGames.UseCompatibleStateImageBehavior = false;
            this.lvWiiGames.View = System.Windows.Forms.View.Details;
            this.lvWiiGames.Resize += new System.EventHandler(this.lvWiiGames_Resize);
            // 
            // lvwgId
            // 
            this.lvwgId.Text = "ID";
            this.lvwgId.Width = 62;
            // 
            // lvwgTitle
            // 
            this.lvwgTitle.Text = "Title";
            this.lvwgTitle.Width = 187;
            // 
            // lvwgCustomTitle
            // 
            this.lvwgCustomTitle.Text = "Custom Title";
            this.lvwgCustomTitle.Width = 177;
            // 
            // lvwgIOSrequired
            // 
            this.lvwgIOSrequired.Text = "IOS Required";
            this.lvwgIOSrequired.Width = 79;
            // 
            // lvwgRegion
            // 
            this.lvwgRegion.Tag = "Numeric";
            this.lvwgRegion.Text = "Region";
            this.lvwgRegion.Width = 50;
            // 
            // lvwgSize
            // 
            this.lvwgSize.Tag = "";
            this.lvwgSize.Text = "Game Size";
            this.lvwgSize.Width = 73;
            // 
            // lvwgType
            // 
            this.lvwgType.Text = "Type";
            this.lvwgType.Width = 43;
            // 
            // lvwgPath
            // 
            this.lvwgPath.Text = "Game Path";
            this.lvwgPath.Width = 250;
            // 
            // ShowMiiWads_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 369);
            this.Controls.Add(this.lvWiiGames);
            this.Controls.Add(this.lvQueue);
            this.Controls.Add(this.lvNand);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.lvWads);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.MinimumSize = new System.Drawing.Size(930, 396);
            this.Name = "ShowMiiWads_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowMiiWads by Leathl (mod by orwel)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShowMiiWads_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResizeEnd += new System.EventHandler(this.Main_ResizeEnd);
            this.LocationChanged += new System.EventHandler(this.Main_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.cmWads.ResumeLayout(false);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.cmNand.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvWads;
        private System.Windows.Forms.ColumnHeader lvName;
        private System.Windows.Forms.ColumnHeader lvID;
        private System.Windows.Forms.ColumnHeader lvBlocks;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsFile;
        private System.Windows.Forms.ToolStripMenuItem tsHelp;
        private System.Windows.Forms.ToolStripMenuItem btnAbout;
        private System.Windows.Forms.ToolStripMenuItem btnRefresh;
        private System.Windows.Forms.ColumnHeader lvFilesize;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ColumnHeader lvIOS;
        private System.Windows.Forms.ColumnHeader lvRegion;
        private System.Windows.Forms.ColumnHeader lvData;
        private System.Windows.Forms.ColumnHeader lvPath;
        private System.Windows.Forms.ToolStripMenuItem tsOptions;
        private System.Windows.Forms.ToolStripStatusLabel lbFiles;
        private System.Windows.Forms.ToolStripStatusLabel lbFileCount;
        private System.Windows.Forms.ToolStripProgressBar pbProgress;
        private System.Windows.Forms.ToolStripMenuItem tsEdit;
        private System.Windows.Forms.ToolStripMenuItem btnChangeID;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ContextMenuStrip cmWads;
        private System.Windows.Forms.ToolStripMenuItem cmChangeID;
        private System.Windows.Forms.ToolStripMenuItem tsLanguage;
        private System.Windows.Forms.ToolStripMenuItem btnEnglish;
        private System.Windows.Forms.ToolStripMenuItem btnGerman;
        private System.Windows.Forms.ToolStripMenuItem cmRename;
        private System.Windows.Forms.ToolStripMenuItem btnRename;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.ToolStripMenuItem cmDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnAutoResize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem btnOpen;
        private System.Windows.Forms.ToolStripMenuItem cmChangeRegion;
        private System.Windows.Forms.ToolStripMenuItem tsChangeRegion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripStatusLabel lbFolders;
        private System.Windows.Forms.ToolStripStatusLabel lbFolderCount;
        private System.Windows.Forms.ToolStripMenuItem cmRemoveFolder;
        private System.Windows.Forms.ToolStripMenuItem cmRegionFree;
        private System.Windows.Forms.ToolStripMenuItem cmPal;
        private System.Windows.Forms.ToolStripMenuItem cmNtscU;
        private System.Windows.Forms.ToolStripMenuItem cmNtscJ;
        private System.Windows.Forms.ToolStripMenuItem btnRegionFree;
        private System.Windows.Forms.ToolStripMenuItem btnPal;
        private System.Windows.Forms.ToolStripMenuItem btnNtscU;
        private System.Windows.Forms.ToolStripMenuItem btnNtscJ;
        private System.Windows.Forms.ToolStripMenuItem btnDisclaimer;
        private System.Windows.Forms.ToolStripMenuItem btnSaveFolders;
        private System.Windows.Forms.ToolStripMenuItem btnCopy;
        private System.Windows.Forms.ToolStripMenuItem btnCut;
        private System.Windows.Forms.ToolStripMenuItem btnPaste;
        private System.Windows.Forms.ToolStripMenuItem cmCopy;
        private System.Windows.Forms.ToolStripMenuItem cmCut;
        private System.Windows.Forms.ToolStripMenuItem cmPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ColumnHeader lvType;
        private System.Windows.Forms.ColumnHeader lvVersion;
        private System.Windows.Forms.ToolStripMenuItem btnNandPath;
        private System.Windows.Forms.ToolStripMenuItem cmExtract;
        private System.Windows.Forms.ToolStripMenuItem cmToFolder;
        private System.Windows.Forms.ToolStripMenuItem cmToNand;
        private System.Windows.Forms.ToolStripMenuItem tsExtract;
        private System.Windows.Forms.ToolStripMenuItem btnToFolder;
        private System.Windows.Forms.ToolStripMenuItem btnToNand;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem btnFromFile;
        private System.Windows.Forms.ToolStripMenuItem btnShowPath;
        private System.Windows.Forms.ToolStripMenuItem btnExport;
        private System.Windows.Forms.ToolStripMenuItem cmChangeTitle;
        private System.Windows.Forms.ToolStripMenuItem btnChangeTitle;
        private System.Windows.Forms.ToolStripSeparator mruSeparator;
        private System.Windows.Forms.ToolStripMenuItem tsMru;
        private System.Windows.Forms.ColumnHeader lvTitle;
        private System.Windows.Forms.ToolStripMenuItem tsView;
        private System.Windows.Forms.ToolStripMenuItem btnShowMiiWads;
        private System.Windows.Forms.ToolStripMenuItem btnShowMiiNand;
        private System.Windows.Forms.ToolStripMenuItem tsTools;
        private System.Windows.Forms.ToolStripMenuItem btnPackWad;
        private System.Windows.Forms.ListView lvNand;
        private System.Windows.Forms.ColumnHeader lvNandName;
        private System.Windows.Forms.ColumnHeader lvNandID;
        private System.Windows.Forms.ColumnHeader lvNandBlocks;
        private System.Windows.Forms.ColumnHeader lvNandSize;
        private System.Windows.Forms.ColumnHeader lvNandIOS;
        private System.Windows.Forms.ColumnHeader lvNandRegion;
        private System.Windows.Forms.ColumnHeader lvNandContent;
        private System.Windows.Forms.ColumnHeader lvNandPath;
        private System.Windows.Forms.ColumnHeader lvNandType;
        private System.Windows.Forms.ColumnHeader lvNandVersion;
        private System.Windows.Forms.ColumnHeader lvNandTitle;
        private System.Windows.Forms.ContextMenuStrip cmNand;
        private System.Windows.Forms.ToolStripMenuItem cmNandDelete;
        private System.Windows.Forms.ToolStripMenuItem cmInstall;
        private System.Windows.Forms.ToolStripMenuItem cmInstallWad;
        private System.Windows.Forms.ToolStripMenuItem cmInstallFolder;
        private System.Windows.Forms.ToolStripStatusLabel lbQueue;
        private System.Windows.Forms.ToolStripStatusLabel lbQueueCount;
        private System.Windows.Forms.ToolStripStatusLabel lbQueueInstall;
        private System.Windows.Forms.ToolStripStatusLabel lbQueueDiscard;
        private System.Windows.Forms.ListBox lvQueue;
        private System.Windows.Forms.ToolStripMenuItem btnAddSub;
        private System.Windows.Forms.ToolStripMenuItem btnFrench;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem cmNandPackWad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem cmPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem btnPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem cmNandPreview;
        private System.Windows.Forms.ToolStripMenuItem btnUnpackU8;
        private System.Windows.Forms.ToolStripMenuItem btnConvertFromTpl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem btnUpdateCheck;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem btnCreateBackups;
        private System.Windows.Forms.ToolStripMenuItem cmRestore;
        private System.Windows.Forms.ToolStripMenuItem btnRestore;
        private System.Windows.Forms.ToolStripMenuItem btnItalian;
        private System.Windows.Forms.ToolStripMenuItem btnSpanish;
        private System.Windows.Forms.ToolStripMenuItem cmRemoveAllFolders;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem cmRefreshFolder;
        private System.Windows.Forms.ToolStripMenuItem btnShowSplash;
        private System.Windows.Forms.ToolStripMenuItem btnNorwegian;
        private System.Windows.Forms.ToolStripMenuItem tsPackU8;
        private System.Windows.Forms.ToolStripMenuItem tsConvertToTpl;
        private System.Windows.Forms.ToolStripMenuItem btnAsRGBA8;
        private System.Windows.Forms.ToolStripMenuItem btnAsRGB565;
        private System.Windows.Forms.ToolStripMenuItem btnAsRGB5A3;
        private System.Windows.Forms.ToolStripMenuItem btnPackU8WithoutHeader;
        private System.Windows.Forms.ToolStripMenuItem btnPackU8WithIMD5;
        private System.Windows.Forms.ToolStripMenuItem btnPackU8WithIMET;
        private System.Windows.Forms.ToolStripMenuItem btnLz77Compress;
        private System.Windows.Forms.ToolStripMenuItem btnLz77Decompress;
        private System.Windows.Forms.ToolStripMenuItem cmInsertDol;
        private System.Windows.Forms.ToolStripMenuItem btnInsertDol;
        private System.Windows.Forms.ToolStripMenuItem cmChangeIosSlot;
        private System.Windows.Forms.ToolStripMenuItem cmChangeTitleVersion;
        private System.Windows.Forms.ToolStripMenuItem tsNandSaveData;
        private System.Windows.Forms.ToolStripMenuItem cmNandBackupSave;
        private System.Windows.Forms.ToolStripMenuItem cmNandRestoreSave;
        private System.Windows.Forms.ToolStripMenuItem cmNandBackupSaveAll;
        private System.Windows.Forms.ToolStripMenuItem cmNandRestoreSaveAll;
        private System.Windows.Forms.ToolStripMenuItem btnChangeIosSlot;
        private System.Windows.Forms.ToolStripMenuItem btnChangeTitleVersion;
        private System.Windows.Forms.ToolStripMenuItem btnExtractBootmiiDump;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem cmExtractVcPics;
        private System.Windows.Forms.ToolStripMenuItem btnPortuguese;
        private System.Windows.Forms.ToolStripMenuItem btnJapanese;
        private System.Windows.Forms.ToolStripMenuItem btnPortableMode;
        private System.Windows.Forms.ToolStripMenuItem btnChinese;
        private System.Windows.Forms.ToolStripMenuItem cmNandPatchReturnTo;
        private System.Windows.Forms.ToolStripMenuItem btnCreateNANDFromScratch;
        private System.Windows.Forms.ListView lvWiiGames;
        private System.Windows.Forms.ColumnHeader lvwgId;
        private System.Windows.Forms.ColumnHeader lvwgIOSrequired;
        private System.Windows.Forms.ColumnHeader lvwgSize;
        private System.Windows.Forms.ColumnHeader lvwgType;
        private System.Windows.Forms.ColumnHeader lvwgPath;
        private System.Windows.Forms.ColumnHeader lvwgTitle;
        private System.Windows.Forms.ColumnHeader lvwgRegion;
        private System.Windows.Forms.ColumnHeader lvwgCustomTitle;
        private System.Windows.Forms.ToolStripMenuItem btnShowMiiWiiGames;
        private System.Windows.Forms.ToolStripMenuItem btnWiiGamePath;
    }
}

