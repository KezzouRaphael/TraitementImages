namespace TraitementImages
{
    partial class Vision
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vision));
            this.ImgDest = new System.Windows.Forms.PictureBox();
            this.ImgSrc = new System.Windows.Forms.PictureBox();
            this.RetourImage = new System.Windows.Forms.Button();
            this.Palette = new System.Windows.Forms.Button();
            this.ROIcheckBox = new System.Windows.Forms.CheckBox();
            this.BoutonChangerImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LongueurnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.labelTaille = new System.Windows.Forms.Label();
            this.LargeurnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.labelLargeur = new System.Windows.Forms.Label();
            this.labelLongueur = new System.Windows.Forms.Label();
            this.ChangerTaillebutton = new System.Windows.Forms.Button();
            this.ZoomUpbutton = new System.Windows.Forms.Button();
            this.ZoomDownbutton = new System.Windows.Forms.Button();
            this.SeuillageSimplelabel = new System.Windows.Forms.Label();
            this.SeuillagenumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SeuillageSimplebutton = new System.Windows.Forms.Button();
            this.Histogramchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CumulHistobutton = new System.Windows.Forms.Button();
            this.HistoEgalisebutton = new System.Windows.Forms.Button();
            this.MultiSeuillagebutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.filtresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.médianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moyenneurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laplacienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kirshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prewittToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.robertsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.morphologieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.érosionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilatationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvertureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermetureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chainageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectionDesBordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seuillageParHystéresisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affinageDesContoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chainageDesContoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numericUpDownDeviation = new System.Windows.Forms.NumericUpDown();
            this.labelGauss = new System.Windows.Forms.Label();
            this.buttonNegatif = new System.Windows.Forms.Button();
            this.buttonSaveImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImgDest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgSrc)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LongueurnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LargeurnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeuillagenumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Histogramchart)).BeginInit();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeviation)).BeginInit();
            this.SuspendLayout();
            // 
            // ImgDest
            // 
            this.ImgDest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImgDest.Location = new System.Drawing.Point(3, 12);
            this.ImgDest.Name = "ImgDest";
            this.ImgDest.Size = new System.Drawing.Size(451, 436);
            this.ImgDest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ImgDest.TabIndex = 0;
            this.ImgDest.TabStop = false;
            // 
            // ImgSrc
            // 
            this.ImgSrc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImgSrc.Location = new System.Drawing.Point(0, 12);
            this.ImgSrc.Name = "ImgSrc";
            this.ImgSrc.Size = new System.Drawing.Size(451, 436);
            this.ImgSrc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ImgSrc.TabIndex = 1;
            this.ImgSrc.TabStop = false;
            this.ImgSrc.Click += new System.EventHandler(this.ImgSrc_Click);
            // 
            // RetourImage
            // 
            this.RetourImage.BackColor = System.Drawing.Color.Red;
            this.RetourImage.Location = new System.Drawing.Point(469, 444);
            this.RetourImage.Name = "RetourImage";
            this.RetourImage.Size = new System.Drawing.Size(222, 48);
            this.RetourImage.TabIndex = 3;
            this.RetourImage.Text = "<============";
            this.RetourImage.UseVisualStyleBackColor = false;
            this.RetourImage.Click += new System.EventHandler(this.RetourImage_Click);
            // 
            // Palette
            // 
            this.Palette.BackColor = System.Drawing.Color.Red;
            this.Palette.Location = new System.Drawing.Point(469, 303);
            this.Palette.Name = "Palette";
            this.Palette.Size = new System.Drawing.Size(222, 48);
            this.Palette.TabIndex = 5;
            this.Palette.Text = "Palette";
            this.Palette.UseVisualStyleBackColor = false;
            this.Palette.Click += new System.EventHandler(this.Palette_Click);
            // 
            // ROIcheckBox
            // 
            this.ROIcheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.ROIcheckBox.BackColor = System.Drawing.Color.Red;
            this.ROIcheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ROIcheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ROIcheckBox.Location = new System.Drawing.Point(469, 185);
            this.ROIcheckBox.Name = "ROIcheckBox";
            this.ROIcheckBox.Size = new System.Drawing.Size(222, 48);
            this.ROIcheckBox.TabIndex = 6;
            this.ROIcheckBox.Text = "R.O.I";
            this.ROIcheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ROIcheckBox.UseVisualStyleBackColor = false;
            this.ROIcheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // BoutonChangerImage
            // 
            this.BoutonChangerImage.BackColor = System.Drawing.Color.Red;
            this.BoutonChangerImage.Location = new System.Drawing.Point(12, 548);
            this.BoutonChangerImage.Name = "BoutonChangerImage";
            this.BoutonChangerImage.Size = new System.Drawing.Size(451, 23);
            this.BoutonChangerImage.TabIndex = 7;
            this.BoutonChangerImage.Text = "CHANGER D\'IMAGE DE DÉPART";
            this.BoutonChangerImage.UseVisualStyleBackColor = false;
            this.BoutonChangerImage.Click += new System.EventHandler(this.BoutonChangerImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 51);
            this.label1.TabIndex = 8;
            this.label1.Text = "IMAGE DE DÉPART";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(713, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(397, 51);
            this.label2.TabIndex = 9;
            this.label2.Text = "IMAGE RÉSULTAT";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.ImgSrc);
            this.panel1.Location = new System.Drawing.Point(12, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 459);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.ImgDest);
            this.panel2.Location = new System.Drawing.Point(700, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(455, 459);
            this.panel2.TabIndex = 11;
            // 
            // LongueurnumericUpDown
            // 
            this.LongueurnumericUpDown.Location = new System.Drawing.Point(123, 644);
            this.LongueurnumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.LongueurnumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LongueurnumericUpDown.Name = "LongueurnumericUpDown";
            this.LongueurnumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.LongueurnumericUpDown.TabIndex = 12;
            this.LongueurnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LongueurnumericUpDown.ValueChanged += new System.EventHandler(this.LongueurnumericUpDown_ValueChanged);
            // 
            // labelTaille
            // 
            this.labelTaille.AutoSize = true;
            this.labelTaille.Location = new System.Drawing.Point(12, 621);
            this.labelTaille.Name = "labelTaille";
            this.labelTaille.Size = new System.Drawing.Size(88, 13);
            this.labelTaille.TabIndex = 13;
            this.labelTaille.Text = "Taille de l\'image :";
            // 
            // LargeurnumericUpDown
            // 
            this.LargeurnumericUpDown.Location = new System.Drawing.Point(123, 689);
            this.LargeurnumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.LargeurnumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LargeurnumericUpDown.Name = "LargeurnumericUpDown";
            this.LargeurnumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.LargeurnumericUpDown.TabIndex = 14;
            this.LargeurnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LargeurnumericUpDown.ValueChanged += new System.EventHandler(this.LargeurnumericUpDown_ValueChanged);
            // 
            // labelLargeur
            // 
            this.labelLargeur.AutoSize = true;
            this.labelLargeur.Location = new System.Drawing.Point(12, 691);
            this.labelLargeur.Name = "labelLargeur";
            this.labelLargeur.Size = new System.Drawing.Size(49, 13);
            this.labelLargeur.TabIndex = 15;
            this.labelLargeur.Text = "Largeur :";
            // 
            // labelLongueur
            // 
            this.labelLongueur.AutoSize = true;
            this.labelLongueur.Location = new System.Drawing.Point(12, 646);
            this.labelLongueur.Name = "labelLongueur";
            this.labelLongueur.Size = new System.Drawing.Size(58, 13);
            this.labelLongueur.TabIndex = 16;
            this.labelLongueur.Text = "Longueur :";
            // 
            // ChangerTaillebutton
            // 
            this.ChangerTaillebutton.BackColor = System.Drawing.Color.Red;
            this.ChangerTaillebutton.Location = new System.Drawing.Point(269, 644);
            this.ChangerTaillebutton.Name = "ChangerTaillebutton";
            this.ChangerTaillebutton.Size = new System.Drawing.Size(80, 64);
            this.ChangerTaillebutton.TabIndex = 17;
            this.ChangerTaillebutton.Text = "Changer taille";
            this.ChangerTaillebutton.UseVisualStyleBackColor = false;
            this.ChangerTaillebutton.Click += new System.EventHandler(this.ChangerTaillebutton_Click);
            // 
            // ZoomUpbutton
            // 
            this.ZoomUpbutton.BackColor = System.Drawing.Color.Red;
            this.ZoomUpbutton.Location = new System.Drawing.Point(469, 95);
            this.ZoomUpbutton.Name = "ZoomUpbutton";
            this.ZoomUpbutton.Size = new System.Drawing.Size(17, 23);
            this.ZoomUpbutton.TabIndex = 18;
            this.ZoomUpbutton.Text = "+";
            this.ZoomUpbutton.UseVisualStyleBackColor = false;
            this.ZoomUpbutton.Click += new System.EventHandler(this.ZoomUpbutton_Click);
            // 
            // ZoomDownbutton
            // 
            this.ZoomDownbutton.BackColor = System.Drawing.Color.Red;
            this.ZoomDownbutton.Location = new System.Drawing.Point(469, 124);
            this.ZoomDownbutton.Name = "ZoomDownbutton";
            this.ZoomDownbutton.Size = new System.Drawing.Size(17, 23);
            this.ZoomDownbutton.TabIndex = 19;
            this.ZoomDownbutton.Text = "-";
            this.ZoomDownbutton.UseVisualStyleBackColor = false;
            this.ZoomDownbutton.Click += new System.EventHandler(this.ZoomDownbutton_Click);
            // 
            // SeuillageSimplelabel
            // 
            this.SeuillageSimplelabel.AutoSize = true;
            this.SeuillageSimplelabel.Location = new System.Drawing.Point(719, 584);
            this.SeuillageSimplelabel.Name = "SeuillageSimplelabel";
            this.SeuillageSimplelabel.Size = new System.Drawing.Size(162, 13);
            this.SeuillageSimplelabel.TabIndex = 20;
            this.SeuillageSimplelabel.Text = "Valeur de Seuillage Simple         :";
            // 
            // SeuillagenumericUpDown
            // 
            this.SeuillagenumericUpDown.Location = new System.Drawing.Point(898, 584);
            this.SeuillagenumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.SeuillagenumericUpDown.Name = "SeuillagenumericUpDown";
            this.SeuillagenumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.SeuillagenumericUpDown.TabIndex = 21;
            // 
            // SeuillageSimplebutton
            // 
            this.SeuillageSimplebutton.BackColor = System.Drawing.Color.Red;
            this.SeuillageSimplebutton.Location = new System.Drawing.Point(469, 385);
            this.SeuillageSimplebutton.Name = "SeuillageSimplebutton";
            this.SeuillageSimplebutton.Size = new System.Drawing.Size(222, 23);
            this.SeuillageSimplebutton.TabIndex = 22;
            this.SeuillageSimplebutton.Text = "Seuillage Simple";
            this.SeuillageSimplebutton.UseVisualStyleBackColor = false;
            this.SeuillageSimplebutton.Click += new System.EventHandler(this.SeuillageSimplebutton_Click);
            // 
            // Histogramchart
            // 
            chartArea1.Name = "ChartArea1";
            this.Histogramchart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Histogramchart.Legends.Add(legend1);
            this.Histogramchart.Location = new System.Drawing.Point(722, 621);
            this.Histogramchart.Name = "Histogramchart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "NDG";
            this.Histogramchart.Series.Add(series1);
            this.Histogramchart.Size = new System.Drawing.Size(275, 249);
            this.Histogramchart.TabIndex = 23;
            this.Histogramchart.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Histogramme";
            this.Histogramchart.Titles.Add(title1);
            // 
            // CumulHistobutton
            // 
            this.CumulHistobutton.Location = new System.Drawing.Point(1003, 621);
            this.CumulHistobutton.Name = "CumulHistobutton";
            this.CumulHistobutton.Size = new System.Drawing.Size(80, 41);
            this.CumulHistobutton.TabIndex = 24;
            this.CumulHistobutton.Text = "Histogramme Cumulé";
            this.CumulHistobutton.UseVisualStyleBackColor = true;
            this.CumulHistobutton.Click += new System.EventHandler(this.CumulHistobutton_Click);
            // 
            // HistoEgalisebutton
            // 
            this.HistoEgalisebutton.Location = new System.Drawing.Point(1003, 682);
            this.HistoEgalisebutton.Name = "HistoEgalisebutton";
            this.HistoEgalisebutton.Size = new System.Drawing.Size(80, 41);
            this.HistoEgalisebutton.TabIndex = 25;
            this.HistoEgalisebutton.Text = "Histogramme Egalisé";
            this.HistoEgalisebutton.UseVisualStyleBackColor = true;
            this.HistoEgalisebutton.Click += new System.EventHandler(this.HistoEgalisebutton_Click);
            // 
            // MultiSeuillagebutton
            // 
            this.MultiSeuillagebutton.BackColor = System.Drawing.Color.Red;
            this.MultiSeuillagebutton.Location = new System.Drawing.Point(472, 414);
            this.MultiSeuillagebutton.Name = "MultiSeuillagebutton";
            this.MultiSeuillagebutton.Size = new System.Drawing.Size(222, 23);
            this.MultiSeuillagebutton.TabIndex = 26;
            this.MultiSeuillagebutton.Text = "Seuillage Multiple";
            this.MultiSeuillagebutton.UseVisualStyleBackColor = false;
            this.MultiSeuillagebutton.Click += new System.EventHandler(this.MultiSeuillagebutton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(718, 597);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Valeur d\'approximationMoyenne :";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1290, 24);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filtresToolStripMenuItem,
            this.morphologieToolStripMenuItem,
            this.chainageToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1290, 24);
            this.menuStrip2.TabIndex = 29;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // filtresToolStripMenuItem
            // 
            this.filtresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.médianToolStripMenuItem,
            this.moyenneurToolStripMenuItem,
            this.gaussienToolStripMenuItem,
            this.laplacienToolStripMenuItem,
            this.kirshToolStripMenuItem,
            this.sobelToolStripMenuItem,
            this.prewittToolStripMenuItem,
            this.robertsToolStripMenuItem});
            this.filtresToolStripMenuItem.Name = "filtresToolStripMenuItem";
            this.filtresToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.filtresToolStripMenuItem.Text = "Filtres";
            // 
            // médianToolStripMenuItem
            // 
            this.médianToolStripMenuItem.Name = "médianToolStripMenuItem";
            this.médianToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.médianToolStripMenuItem.Text = "Médian";
            this.médianToolStripMenuItem.Click += new System.EventHandler(this.médianToolStripMenuItem_Click);
            // 
            // moyenneurToolStripMenuItem
            // 
            this.moyenneurToolStripMenuItem.Name = "moyenneurToolStripMenuItem";
            this.moyenneurToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.moyenneurToolStripMenuItem.Text = "Moyenneur";
            this.moyenneurToolStripMenuItem.Click += new System.EventHandler(this.moyenneurToolStripMenuItem_Click);
            // 
            // gaussienToolStripMenuItem
            // 
            this.gaussienToolStripMenuItem.Name = "gaussienToolStripMenuItem";
            this.gaussienToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gaussienToolStripMenuItem.Text = "Gaussien";
            this.gaussienToolStripMenuItem.Click += new System.EventHandler(this.gaussienToolStripMenuItem_Click);
            // 
            // laplacienToolStripMenuItem
            // 
            this.laplacienToolStripMenuItem.Name = "laplacienToolStripMenuItem";
            this.laplacienToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.laplacienToolStripMenuItem.Text = "Laplacien";
            this.laplacienToolStripMenuItem.Click += new System.EventHandler(this.laplacienToolStripMenuItem_Click);
            // 
            // kirshToolStripMenuItem
            // 
            this.kirshToolStripMenuItem.Name = "kirshToolStripMenuItem";
            this.kirshToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kirshToolStripMenuItem.Text = "Kirsh";
            this.kirshToolStripMenuItem.Click += new System.EventHandler(this.kirshToolStripMenuItem_Click);
            // 
            // sobelToolStripMenuItem
            // 
            this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            this.sobelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sobelToolStripMenuItem.Text = "Sobel";
            this.sobelToolStripMenuItem.Click += new System.EventHandler(this.sobelToolStripMenuItem_Click);
            // 
            // prewittToolStripMenuItem
            // 
            this.prewittToolStripMenuItem.Name = "prewittToolStripMenuItem";
            this.prewittToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.prewittToolStripMenuItem.Text = "Prewitt";
            this.prewittToolStripMenuItem.Click += new System.EventHandler(this.prewittToolStripMenuItem_Click);
            // 
            // robertsToolStripMenuItem
            // 
            this.robertsToolStripMenuItem.Name = "robertsToolStripMenuItem";
            this.robertsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.robertsToolStripMenuItem.Text = "Roberts";
            this.robertsToolStripMenuItem.Click += new System.EventHandler(this.robertsToolStripMenuItem_Click);
            // 
            // morphologieToolStripMenuItem
            // 
            this.morphologieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.érosionToolStripMenuItem,
            this.dilatationToolStripMenuItem,
            this.ouvertureToolStripMenuItem,
            this.fermetureToolStripMenuItem});
            this.morphologieToolStripMenuItem.Name = "morphologieToolStripMenuItem";
            this.morphologieToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.morphologieToolStripMenuItem.Text = "Morphologie";
            // 
            // érosionToolStripMenuItem
            // 
            this.érosionToolStripMenuItem.Name = "érosionToolStripMenuItem";
            this.érosionToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.érosionToolStripMenuItem.Text = "Érosion";
            this.érosionToolStripMenuItem.Click += new System.EventHandler(this.érosionToolStripMenuItem_Click);
            // 
            // dilatationToolStripMenuItem
            // 
            this.dilatationToolStripMenuItem.Name = "dilatationToolStripMenuItem";
            this.dilatationToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.dilatationToolStripMenuItem.Text = "Dilatation";
            this.dilatationToolStripMenuItem.Click += new System.EventHandler(this.dilatationToolStripMenuItem_Click);
            // 
            // ouvertureToolStripMenuItem
            // 
            this.ouvertureToolStripMenuItem.Name = "ouvertureToolStripMenuItem";
            this.ouvertureToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.ouvertureToolStripMenuItem.Text = "Ouverture";
            this.ouvertureToolStripMenuItem.Click += new System.EventHandler(this.ouvertureToolStripMenuItem_Click);
            // 
            // fermetureToolStripMenuItem
            // 
            this.fermetureToolStripMenuItem.Name = "fermetureToolStripMenuItem";
            this.fermetureToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.fermetureToolStripMenuItem.Text = "Fermeture";
            this.fermetureToolStripMenuItem.Click += new System.EventHandler(this.fermetureToolStripMenuItem_Click);
            // 
            // chainageToolStripMenuItem
            // 
            this.chainageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detectionDesBordsToolStripMenuItem,
            this.seuillageParHystéresisToolStripMenuItem,
            this.affinageDesContoursToolStripMenuItem,
            this.chainageDesContoursToolStripMenuItem});
            this.chainageToolStripMenuItem.Name = "chainageToolStripMenuItem";
            this.chainageToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.chainageToolStripMenuItem.Text = "Chainage";
            // 
            // detectionDesBordsToolStripMenuItem
            // 
            this.detectionDesBordsToolStripMenuItem.Name = "detectionDesBordsToolStripMenuItem";
            this.detectionDesBordsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.detectionDesBordsToolStripMenuItem.Text = "Detection des bords";
            this.detectionDesBordsToolStripMenuItem.Click += new System.EventHandler(this.detectionDesBordsToolStripMenuItem_Click);
            // 
            // seuillageParHystéresisToolStripMenuItem
            // 
            this.seuillageParHystéresisToolStripMenuItem.Name = "seuillageParHystéresisToolStripMenuItem";
            this.seuillageParHystéresisToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.seuillageParHystéresisToolStripMenuItem.Text = "Seuillage par Hystéresis";
            this.seuillageParHystéresisToolStripMenuItem.Click += new System.EventHandler(this.seuillageParHystéresisToolStripMenuItem_Click);
            // 
            // affinageDesContoursToolStripMenuItem
            // 
            this.affinageDesContoursToolStripMenuItem.Name = "affinageDesContoursToolStripMenuItem";
            this.affinageDesContoursToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.affinageDesContoursToolStripMenuItem.Text = "Affinage des Contours";
            this.affinageDesContoursToolStripMenuItem.Click += new System.EventHandler(this.affinageDesContoursToolStripMenuItem_Click);
            // 
            // chainageDesContoursToolStripMenuItem
            // 
            this.chainageDesContoursToolStripMenuItem.Name = "chainageDesContoursToolStripMenuItem";
            this.chainageDesContoursToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.chainageDesContoursToolStripMenuItem.Text = "Chainage des contours";
            this.chainageDesContoursToolStripMenuItem.Click += new System.EventHandler(this.chainageDesContoursToolStripMenuItem_Click);
            // 
            // numericUpDownDeviation
            // 
            this.numericUpDownDeviation.DecimalPlaces = 3;
            this.numericUpDownDeviation.Location = new System.Drawing.Point(898, 551);
            this.numericUpDownDeviation.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownDeviation.Name = "numericUpDownDeviation";
            this.numericUpDownDeviation.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownDeviation.TabIndex = 30;
            this.numericUpDownDeviation.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelGauss
            // 
            this.labelGauss.AutoSize = true;
            this.labelGauss.Location = new System.Drawing.Point(718, 553);
            this.labelGauss.Name = "labelGauss";
            this.labelGauss.Size = new System.Drawing.Size(151, 13);
            this.labelGauss.TabIndex = 31;
            this.labelGauss.Text = "Déviation gaussienne (sigma) :";
            // 
            // buttonNegatif
            // 
            this.buttonNegatif.BackColor = System.Drawing.Color.Red;
            this.buttonNegatif.Location = new System.Drawing.Point(469, 239);
            this.buttonNegatif.Name = "buttonNegatif";
            this.buttonNegatif.Size = new System.Drawing.Size(222, 48);
            this.buttonNegatif.TabIndex = 32;
            this.buttonNegatif.Text = "Negatif";
            this.buttonNegatif.UseVisualStyleBackColor = false;
            this.buttonNegatif.Click += new System.EventHandler(this.buttonNegatif_Click);
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.BackColor = System.Drawing.Color.Red;
            this.buttonSaveImage.Location = new System.Drawing.Point(12, 577);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(451, 23);
            this.buttonSaveImage.TabIndex = 33;
            this.buttonSaveImage.Text = "SAUVEGARDER L\'IMAGE";
            this.buttonSaveImage.UseVisualStyleBackColor = false;
            this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
            // 
            // Vision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 865);
            this.Controls.Add(this.buttonSaveImage);
            this.Controls.Add(this.buttonNegatif);
            this.Controls.Add(this.labelGauss);
            this.Controls.Add(this.numericUpDownDeviation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MultiSeuillagebutton);
            this.Controls.Add(this.HistoEgalisebutton);
            this.Controls.Add(this.CumulHistobutton);
            this.Controls.Add(this.Histogramchart);
            this.Controls.Add(this.SeuillageSimplebutton);
            this.Controls.Add(this.SeuillagenumericUpDown);
            this.Controls.Add(this.SeuillageSimplelabel);
            this.Controls.Add(this.ZoomDownbutton);
            this.Controls.Add(this.ZoomUpbutton);
            this.Controls.Add(this.ChangerTaillebutton);
            this.Controls.Add(this.labelLongueur);
            this.Controls.Add(this.labelLargeur);
            this.Controls.Add(this.LargeurnumericUpDown);
            this.Controls.Add(this.labelTaille);
            this.Controls.Add(this.LongueurnumericUpDown);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BoutonChangerImage);
            this.Controls.Add(this.ROIcheckBox);
            this.Controls.Add(this.Palette);
            this.Controls.Add(this.RetourImage);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Vision";
            this.Text = "Traitement d\'Images";
            ((System.ComponentModel.ISupportInitialize)(this.ImgDest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgSrc)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LongueurnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LargeurnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeuillagenumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Histogramchart)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeviation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImgDest;
        private System.Windows.Forms.PictureBox ImgSrc;
        private System.Windows.Forms.Button RetourImage;
        private System.Windows.Forms.Button Palette;
        private System.Windows.Forms.CheckBox ROIcheckBox;
        private System.Windows.Forms.Button BoutonChangerImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown LongueurnumericUpDown;
        private System.Windows.Forms.Label labelTaille;
        private System.Windows.Forms.NumericUpDown LargeurnumericUpDown;
        private System.Windows.Forms.Label labelLargeur;
        private System.Windows.Forms.Label labelLongueur;
        private System.Windows.Forms.Button ChangerTaillebutton;
        private System.Windows.Forms.Button ZoomUpbutton;
        private System.Windows.Forms.Button ZoomDownbutton;
        private System.Windows.Forms.Label SeuillageSimplelabel;
        private System.Windows.Forms.NumericUpDown SeuillagenumericUpDown;
        private System.Windows.Forms.Button SeuillageSimplebutton;
        private System.Windows.Forms.DataVisualization.Charting.Chart Histogramchart;
        private System.Windows.Forms.Button CumulHistobutton;
        private System.Windows.Forms.Button HistoEgalisebutton;
        private System.Windows.Forms.Button MultiSeuillagebutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem filtresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem médianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moyenneurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laplacienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kirshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prewittToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem robertsToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numericUpDownDeviation;
        private System.Windows.Forms.Label labelGauss;
        private System.Windows.Forms.ToolStripMenuItem morphologieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem érosionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilatationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ouvertureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fermetureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chainageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectionDesBordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seuillageParHystéresisToolStripMenuItem;
        private System.Windows.Forms.Button buttonNegatif;
        private System.Windows.Forms.ToolStripMenuItem affinageDesContoursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chainageDesContoursToolStripMenuItem;
        private System.Windows.Forms.Button buttonSaveImage;
    }
}

