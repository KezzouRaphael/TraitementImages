using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TraitementImages
{
    public partial class Vision : Form
    {
        #region Variables
        public static float _Zoom = 1;
        bool ImageCharge = false;
        bool ImageChargeDest = false;
        bool Premierpoint = false;
        bool ROI = false;
        bool Pal = false;
        Point Point1 = new Point();
        Point Point2 = new Point();
        Color CouleurBase = new Color();
        Color CouleurArrive = new Color();
        List<double> pente;
        #endregion
        public float Zoom
        {
            get { return _Zoom; }
            set { _Zoom = value; }
        }
        public Vision()
        {
            InitializeComponent();

        }

        private void ImgSrc_Click(object sender, EventArgs e)
        {
            #region CHARGER UNE IMAGE
            if (ImageCharge == false)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ImageCharge = true;
                    Image image = Image.FromFile(dialog.FileName);
                    ImgSrc.Image = image;
                    Bitmap ImgBitmap = new Bitmap(ImgSrc.Image);
                    long[] Tab = new long[256];
                    Tab = GetHistogram(ImgBitmap);
                    CalculHisto(Tab, "NDG", Histogramchart);
                    /*
                    Bitmap Test = new Bitmap(ImgSrc.Image);
                    int i = 0;
                    for(i= 0;i<256;i++)
                    Console.WriteLine("i :"+i+" NB : " +GetHistogram(Test)[i]+"\n");
                    */
                }
                #region GUICOULEURVALUE
                if (ImageCharge == true)
                {
                    LongueurnumericUpDown.Value = ImgSrc.Image.Width;
                    LargeurnumericUpDown.Value = ImgSrc.Image.Height;
                }
                ROIcheckBox.BackColor = Color.Green;
                Palette.BackColor = Color.Green;
                BoutonChangerImage.BackColor = Color.Green;
                buttonNegatif.BackColor = Color.Green;
                ZoomUpbutton.BackColor = Color.Green;
                ZoomDownbutton.BackColor = Color.Green;
                SeuillageSimplebutton.BackColor = Color.Green;
                MultiSeuillagebutton.BackColor = Color.Green;
                buttonSaveImage.BackColor = Color.Green;
                #endregion
            }
            #endregion
            #region ROI
            if (ROI == true)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                Palette.BackColor = Color.Red;
                if (Premierpoint == false)
                {
                    Point1 = me.Location;
                    Premierpoint = true;
                }
                else
                {
                    Point2 = me.Location;
                    Premierpoint = false;
                    ROI = false;
                }
                Console.WriteLine("Point1 = " + Point1 + "\nPoint2 = " + Point2);
                if (ROI == false)
                {
                    int Xmin = 0, Xmax = 0, Ymin = 0, Ymax = 0;
                    if (Point1.X >= Point2.X)
                    {
                        Xmax = Point1.X;
                        Xmin = Point2.X;
                    }
                    if (Point2.X >= Point1.X)
                    {
                        Xmax = Point2.X;
                        Xmin = Point1.X;
                    }
                    if (Point1.Y >= Point2.Y)
                    {
                        Ymax = Point1.Y;
                        Ymin = Point2.Y;
                    }
                    if (Point2.Y >= Point1.Y)
                    {
                        Ymax = Point2.Y;
                        Ymin = Point1.Y;
                    }
                    Console.WriteLine("Xmax = " + Xmax + "\nXmin = " + Xmin + "\nYmax = " + Ymax + "\nYmin = " + Ymin);
                    int i, j;
                    Bitmap Tab = new Bitmap(ImgSrc.Image.Width, ImgSrc.Image.Height);
                    ImgSrc.DrawToBitmap(Tab, ImgSrc.ClientRectangle);
                    for (i = 0; i < ImgSrc.Image.Width; i++)
                    {
                        for (j = 0; j < ImgSrc.Image.Height; j++)
                        {
                            if (i < Xmin || i > Xmax || j < Ymin || j > Ymax)
                            {
                                Tab.SetPixel(i, j, Color.White);
                            }
                        }
                    }
                    ImgDest.Image = (Image)Tab;
                    ImageChargeDest = true;
                    #region GUICOULEUR
                    ROIcheckBox.BackColor = Color.Green;
                    Palette.BackColor = Color.Green;
                    buttonNegatif.BackColor = Color.Green;
                    RetourImage.BackColor = Color.Green;
                    BoutonChangerImage.BackColor = Color.Green;
                    ZoomUpbutton.BackColor = Color.Green;
                    ZoomDownbutton.BackColor = Color.Green;
                    #endregion
                }
            }
            #endregion
            #region Palette
            if (Pal == true)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                Bitmap source = (Bitmap)ImgSrc.Image;
                CouleurBase = source.GetPixel(me.X, me.Y);
                Console.WriteLine("Base" + CouleurBase + "\nArrive" + CouleurArrive);

                ImgDest.Image = (Image)ImgSrc.Image.Clone();
                Bitmap bmp = (Bitmap)ImgDest.Image;
                Graphics g = ImgDest.CreateGraphics();

                if (ImgDest.Image.RawFormat.Guid != ImageFormat.Bmp.Guid)
                {
                    g = Graphics.FromImage(bmp);
                }
                // Set the image attribute's color mappings
                ColorMap[] colorMap = new ColorMap[1];
                colorMap[0] = new ColorMap();
                colorMap[0].OldColor = CouleurBase;
                colorMap[0].NewColor = CouleurArrive;
                ImageAttributes attr = new ImageAttributes();
                attr.SetRemapTable(colorMap);
                // Draw using the color map
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                g.DrawImage(bmp, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, attr);
                ImageChargeDest = true;
                #region GUICOULEUR
                ZoomUpbutton.BackColor = Color.Green;
                ZoomDownbutton.BackColor = Color.Green;
                ROIcheckBox.BackColor = Color.Green;
                buttonNegatif.BackColor = Color.Green;
                this.Palette.BackColor = Color.Green;
                RetourImage.BackColor = Color.Green;
                #endregion
                Pal = false;
            }
            #endregion
        }

        private void RetourImage_Click(object sender, EventArgs e)
        {
            if (ImageChargeDest == true && RetourImage.BackColor == Color.Green)
            {
                ImgSrc.Image = (Image)ImgDest.Image.Clone();
                LongueurnumericUpDown.Value = ImgSrc.Image.Width;
                LargeurnumericUpDown.Value = ImgSrc.Image.Height;
                Bitmap ImgBitmap = new Bitmap(ImgSrc.Image);
                long []Tab = new long[256];
                Tab = GetHistogram(ImgBitmap);
                CalculHisto(Tab, "NDG", Histogramchart);
                RetourImage.BackColor = Color.Red;
                Zoom = 1;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ROI = true;
            ROIcheckBox.BackColor = Color.Red;
            Palette.BackColor = Color.Red;
            buttonNegatif.BackColor = Color.Green;
        }

        private void Palette_Click(object sender, EventArgs e)
        {
            if (ImageCharge == true && Palette.BackColor == Color.Green)
            {
                this.Palette.BackColor = Color.Red;
                ROIcheckBox.BackColor = Color.Red;
                buttonNegatif.BackColor = Color.Green;
                Pal = true;
                FenetrePalette Palette = new FenetrePalette();
                Palette.ShowDialog(this);
                CouleurArrive = Palette.Arrive;
            }

        }

        private void buttonNegatif_Click(object sender, EventArgs e)
        {
            Bitmap Image = new Bitmap(ImgSrc.Image);
            int i, j;
            ImgDest.Image = (Image)ImgSrc.Image.Clone();
            Bitmap ImageDst = new Bitmap(ImgDest.Image);
            Color Negatif;
            for (i = 0; i < Image.Width; i++)
            {
                for (j = 0; j < Image.Height; j++)
                {
                    Negatif = Color.FromArgb(255 - Image.GetPixel(i, j).R, 255 - Image.GetPixel(i, j).R, 255 - Image.GetPixel(i, j).R);
                    ImageDst.SetPixel(i, j, Negatif);
                }
            }
            ImgDest.Image = ImageDst;
            ImageChargeDest = true;
            RetourImage.BackColor = Color.Green;
            buttonNegatif.BackColor = Color.Green;
        }
        private void BoutonChangerImage_Click(object sender, EventArgs e)
        {
            if (BoutonChangerImage.BackColor == Color.Green)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ImageCharge = true;
                    Image image = Image.FromFile(dialog.FileName);
                    ImgSrc.Image = image;
                    Bitmap ImgBitmap = new Bitmap(ImgSrc.Image);
                    long[] Tab = new long[256];
                    Tab = GetHistogram(ImgBitmap);
                    CalculHisto(Tab, "NDG", Histogramchart);
                }
                #region GUICOULEURVALUE
                Zoom = 1;
                if (ImageCharge == true)
                {
                    LongueurnumericUpDown.Value = ImgSrc.Image.Width;
                    LargeurnumericUpDown.Value = ImgSrc.Image.Height;
                }

                ZoomUpbutton.BackColor = Color.Green;
                ZoomDownbutton.BackColor = Color.Green;
                ROIcheckBox.BackColor = Color.Green;
                buttonNegatif.BackColor = Color.Green; ;
                Palette.BackColor = Color.Green;
                BoutonChangerImage.BackColor = Color.Green;
                ImgDest.Image = null;
                ImageChargeDest = false;
                RetourImage.BackColor = Color.Red;
                #endregion
            }
        }

        private void LongueurnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (ChangerTaillebutton.BackColor == Color.Red)
                ChangerTaillebutton.BackColor = Color.Green;
        }

        private void LargeurnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (ChangerTaillebutton.BackColor == Color.Red)
                ChangerTaillebutton.BackColor = Color.Green;
        }

        private void ChangerTaillebutton_Click(object sender, EventArgs e)
        {
            if (ChangerTaillebutton.BackColor == Color.Green)
            {
                if (ImageChargeDest == false)
                {
                    ImgDest.Image = (Image)ImgSrc.Image.Clone();
                    ImageChargeDest = true;
                }
                int destWidth = (int)LongueurnumericUpDown.Value;
                int destHeight = (int)LargeurnumericUpDown.Value;
                Bitmap BmpDst = new Bitmap(destWidth, destHeight);
                Bitmap Modele = new Bitmap(ImgSrc.Image);
                int i, j;
                for (i = 0; i < destWidth; i++)
                {
                    for (j = 0; j < destHeight; j++)
                    {
                        if (i >= ImgSrc.Image.Width || j >= ImgSrc.Image.Height)
                            BmpDst.SetPixel(i, j, Color.White);
                        else
                            BmpDst.SetPixel(i, j, Modele.GetPixel(i, j));
                    }
                }
                ImgDest.Image = (Image)BmpDst;
                LongueurnumericUpDown.Value = ImgSrc.Image.Width;
                LargeurnumericUpDown.Value = ImgSrc.Image.Height;
                ChangerTaillebutton.BackColor = Color.Red;
                ZoomUpbutton.BackColor = Color.Green;
                buttonNegatif.BackColor = Color.Green;
                ZoomDownbutton.BackColor = Color.Green;
                ROIcheckBox.BackColor = Color.Green;
                Palette.BackColor = Color.Green;
                RetourImage.BackColor = Color.Green;
                Zoom = 1;
            }
        }

        private void ZoomUpbutton_Click(object sender, EventArgs e)
        {
            if (Zoom < 128)
            {
                Zoom = Zoom * 2;
            }
            float W2 = ImgSrc.Image.Width * Zoom;
            float H2 = ImgSrc.Image.Height * Zoom;
            if (W2 > 10000 || H2 > 10000)
            {
                W2 = W2 / 2;
                H2 = H2 / 2;
                Zoom = Zoom / 2;
            }
            Bitmap ImgZoom = new Bitmap((int)W2, (int)H2);

            using (Graphics g = Graphics.FromImage(ImgZoom))
            {
                g.InterpolationMode = InterpolationMode.Bilinear;

                g.DrawImage(ImgSrc.Image, new Rectangle(Point.Empty, ImgZoom.Size));
            }
            ImgDest.Image = ImgZoom;
            ImageChargeDest = true;
            RetourImage.BackColor = Color.Green;
        }
        private void ZoomDownbutton_Click(object sender, EventArgs e)
        {
            if (Zoom > 0.0078125)
            {
                Zoom = Zoom / 2;
            }
            float x = ImgSrc.Image.Width * Zoom;
            float y = ImgSrc.Image.Height * Zoom;
            if(x < 1 || y < 1)
            {
                x = 1;
                y = 1;
            }
            Bitmap ImgZoom = new Bitmap((int)x, (int)y);

            using (Graphics g = Graphics.FromImage(ImgZoom))
            {
                g.InterpolationMode = InterpolationMode.Bilinear;

                g.DrawImage(ImgSrc.Image, new Rectangle(Point.Empty, ImgZoom.Size));
            }
            ImgDest.Image = ImgZoom;
            ImageChargeDest = true;
            RetourImage.BackColor = Color.Green;
        }
        #region SEUILLAGE + EGALISATION HISTO
        private void SeuillageSimplebutton_Click(object sender, EventArgs e)
        {
            Bitmap Seuillage = new Bitmap(ImgSrc.Image);
            Color Noir = Color.FromArgb(0, 0, 0);
            Color Blanc = Color.FromArgb(255, 255, 255);
            int i, j;
            int ValeurSeuil = (int)SeuillagenumericUpDown.Value;
            for (i = 0; i < Seuillage.Width; i++)
            {
                for (j = 0; j < Seuillage.Height; j++)
                {
                    if (Seuillage.GetPixel(i, j).R <= ValeurSeuil)
                    {
                        Seuillage.SetPixel(i, j, Noir);
                    }
                    else
                    {
                        Seuillage.SetPixel(i, j, Blanc);
                    }
                }
            }
            ImgDest.Image = (Image)Seuillage;
            ImageChargeDest = true;
            SeuillageSimplebutton.BackColor = Color.Green;
            RetourImage.BackColor = Color.Green;
        }
        private void CalculHistov2(float[] Tab, String name, Chart Histogram)
        {
            if (ImageCharge)
            {
                int i;
                List<float> ListeX = new List<float>();
                List<float> ListeY = new List<float>();
                ListeY.Clear();
                ListeX.Clear();
                for (i = 0; i < 256; i++)
                {
                    ListeY.Insert(i, Tab[i]);
                    ListeX.Insert(i, i);
                }
                Histogram.Series[name].Points.DataBindXY(ListeX, ListeY);
                Histogram.Series[name].Color = Color.Blue;
            }
        }
        private void CalculHisto(long[]Tab, String name, Chart Histogram)
        {
            if (ImageCharge)
            {
                int i;
                List<long> ListeX = new List<long>();
                List<long> ListeY = new List<long>();
                ListeY.Clear();
                ListeX.Clear();
                for (i = 0; i < 256; i++)
                {
                    ListeY.Insert(i, Tab[i]);
                    ListeX.Insert(i, i);
                }
                Histogram.Series[name].Points.DataBindXY(ListeX, ListeY);
                Histogram.Series[name].Color = Color.Blue;
            }
        }
        private long[] GetHistogram(Bitmap picture)
        {
            long[] monHistogram = new long[256];

            for (int i = 0; i < picture.Width; i++)
                for (int j = 0; j < picture.Height; j++)
                {
                    Color c = picture.GetPixel(i, j);

                    long Temp = 0;
                    Temp += c.R;
                    Temp += c.G;
                    Temp += c.B;

                    Temp = (int)Temp / 3;
                    monHistogram[Temp]++;
                }

            return monHistogram;
        }
        private long[] CumuleHistogram(Bitmap Picture)
        {
            long[] Histo = new long[256];
            int i;
            long histoCumul=0;
            Histo = GetHistogram(Picture);
            for (i = 0; i < 256;i++)
            {
                histoCumul = histoCumul + Histo[i]; // calcul du cumul
                Histo[i] = histoCumul; // modif valeur histo avec valeur cumulée 
                //Histo[i] = 100*Histo[i] / (Picture.Width * Picture.Height); POURCENTAGE
            }
            return Histo;
        }
        private void EgaliserHisto(Bitmap Image)
        {
            long[] Histo = new long[256];
            long nbpixel;
            Histo = CumuleHistogram(Image);
            nbpixel = (Image.Height * Image.Width);
            float[] hist = new float[256];
            int i, j;
            hist[0] = Histo[0] * Histo.Length / nbpixel;

            for (i = 1; i < hist.Length; i++)
            {
                hist[i] = (int)((float)(255.0 / nbpixel) * Histo[i]);
            }
            CalculHistov2(hist, "NDG", Histogramchart);
            for(i =0;i<Image.Width;i++)
            {
                for(j=0;j<Image.Height;j++)
                {
                    Image.SetPixel(i, j, Color.FromArgb((int)hist[Image.GetPixel(i, j).R], (int)hist[Image.GetPixel(i, j).G], (int)(int)hist[Image.GetPixel(i, j).B]));   
                }
            }
            ImageChargeDest = true;
            ImgDest.Image = Image;
            RetourImage.BackColor = Color.Green;
        }
        private void CumulHistobutton_Click(object sender, EventArgs e)
        {
            if(ImageCharge)
            {
                long[] Histo = new long[256];
                Bitmap Image = new Bitmap(ImgSrc.Image);
                Histo = CumuleHistogram(Image);
                Histogramchart.Titles.Clear();
                Histogramchart.Titles.Add("Histogramme Cumulé");
                CalculHisto(Histo, "NDG", Histogramchart);
            }
        }

        private void HistoEgalisebutton_Click(object sender, EventArgs e)
        {
            if(ImageCharge)
            {
                Bitmap Image = new Bitmap(ImgSrc.Image);
                EgaliserHisto(Image);
                Histogramchart.Titles.Clear();
                Histogramchart.Titles.Add("Histogramme Egalisé");
            }
        }

        private void MultiSeuillagebutton_Click(object sender, EventArgs e)
        {
            if(ImageCharge)
            {
                Bitmap Image = new Bitmap(ImgSrc.Image);
                int min=0, max=0, avg;
                int valmin, valmax;
                int i, j;
                long[] Histogramme = new long[256];
                Histogramme = CumuleHistogram(Image);
                valmin = (int)Histogramme[0];
                min = 0;
                valmax = (int)Histogramme[255];
                max = 255;
                avg = valmax + valmin / 2;
                valmin = 10;
                for(i=0;i<Histogramme.Length;i++)
                {
                    if(Histogramme[i]< valmin && Histogramme[i]>0)
                    {
                        min = i;
                        valmin = (int)Histogramme[i];
                    }
                }
                avg = (max + min) / 2;
                Color PlusFonce = Color.FromArgb(0, 0, 0);
                Color PlusClair = Color.FromArgb(255, 255, 255);
                Color Grisclair = Color.FromArgb(128, 128, 128);
                Color Grisfonce = Color.FromArgb(50, 50, 50);
                int ValeurSeuil = (int)SeuillagenumericUpDown.Value;
                bool done = false;
                for (i = 0; i < Image.Width; i++)
                {
                    for (j = 0; j < Image.Height; j++)
                    {
                        done = false;
                        if (Image.GetPixel(i, j).R < avg -ValeurSeuil && done != true)
                        {
                            Image.SetPixel(i, j, PlusFonce);
                            done = true;
                        }
                        if(Image.GetPixel(i, j).R > avg + ValeurSeuil && done != true)
                        {
                            Image.SetPixel(i, j, PlusClair);
                            done = true;
                        }
                        if (Image.GetPixel(i, j).R < avg  && done != true)
                        {
                            Image.SetPixel(i, j, Grisfonce);
                            done = true;
                        }
                        if (Image.GetPixel(i, j).R > avg && done != true)
                        {
                            Image.SetPixel(i, j, Grisclair);
                            done = true;
                        }

                    }
                }
                ImgDest.Image = Image;
                ImageChargeDest = true;
                RetourImage.BackColor = Color.Green;
            }
        }
        #endregion
        #region FILTRES
        private void médianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ImageCharge == true)
            {
                Bitmap Image = new Bitmap(ImgSrc.Image);
                int[] Entourage = new int[9];
                ImgDest.Image = (Image)ImgSrc.Image.Clone();
                Bitmap ImageDst = new Bitmap(ImgDest.Image);
                int i, j;
                for(i = 1 ; i < Image.Width - 1 ; i++)
                {
                    for(j = 1 ; j < Image.Height - 1 ; j++)
                    {
                        Entourage = Transformation(Image, i, j);
                        List<int> EntourageList = new List<int>(Entourage);
                        EntourageList.Sort();
                        Color NewColor = Color.FromArgb(EntourageList[4], EntourageList[4], EntourageList[4]);
                        ImageDst.SetPixel(i, j, NewColor);
                    }
                }
                #region ROGNERLESBORSDEL'IMAGE
                for (i = 0, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = Image.Width - 1, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = 0, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                for (i = Image.Height - 1, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                #endregion
                ImgDest.Image = ImageDst;
                ImageChargeDest = true;
                RetourImage.BackColor = Color.Green;
            }
        }
        
        private void moyenneurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ImageCharge == true)
            {
                Bitmap Image = new Bitmap(ImgSrc.Image);
                int[] Entourage = new int[9];
                ImgDest.Image = (Image)ImgSrc.Image.Clone();
                Bitmap ImageDst = new Bitmap(ImgDest.Image);
                int i, j,k;
                for (i = 1; i < Image.Width - 1; i++)
                {
                    for (j = 1; j < Image.Height - 1; j++)
                    {
                        Entourage = Transformation(Image, i, j);
                        List<int> EntourageList = new List<int>(Entourage);
                        for(k = 1; k<EntourageList.Count;k++)
                        {
                            EntourageList[0] += EntourageList[k];
                        }
                        EntourageList[0] = EntourageList[0] / EntourageList.Count;
                        Color NewColor = Color.FromArgb(EntourageList[0], EntourageList[0], EntourageList[0]);
                        ImageDst.SetPixel(i, j, NewColor);
                    }
                }
                #region ROGNERLESBORSDEL'IMAGE
                for (i = 0, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = Image.Width - 1, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = 0, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                for (i = Image.Height - 1, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                #endregion
                ImgDest.Image = ImageDst;
                ImageChargeDest = true;
                RetourImage.BackColor = Color.Green;
            }
        }

        private void gaussienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageCharge == true)
            {
                Bitmap Image = new Bitmap(ImgSrc.Image);
                ImgDest.Image = (Image)ImgSrc.Image.Clone();
                Bitmap ImageDst = new Bitmap(ImgDest.Image);
                int[] Entourage = new int[25];
                double[] KernelGauss = new double[25];
                double niveaugris = 0;
                int i, j,k ;
                KernelGauss = CreateKernel((double)numericUpDownDeviation.Value);
                KernelGauss = NormalizateKernel(KernelGauss);
                for (i = 2; i < Image.Width - 2; i++)
                {
                    for (j = 2; j < Image.Height - 2; j++)
                    {
                        Entourage = Transformation5x5(Image, i, j);
                        for(k = 0;k < 25; k++)
                        {
                            niveaugris += (Entourage[k] * KernelGauss[k]);
                        }
                        Color Couleur = Color.FromArgb((int)niveaugris,(int)niveaugris,(int)niveaugris);
                        ImageDst.SetPixel(i, j, Couleur);
                        niveaugris = 0;
                    }
                }
                #region ROGNERLESBORSDEL'IMAGE
                for (i = 0, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = 1, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = Image.Width - 2, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = Image.Width - 1, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = 0, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                for (i = 1, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                for (i = Image.Height - 2, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                for (i = Image.Height - 1, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                #endregion
                ImgDest.Image = ImageDst;
                ImageChargeDest = true;
                RetourImage.BackColor = Color.Green;
            }
        }
        #region FONCTIONS
        private int[] Transformation(Bitmap Imager,int x, int y)
                {
                    int[] Tab3x3 = new int[9];
                    Tab3x3[0] = Imager.GetPixel(x - 1, y - 1).R;
                    Tab3x3[1] = Imager.GetPixel(x, y - 1).R;
                    Tab3x3[2] = Imager.GetPixel(x + 1, y - 1).R;
                    Tab3x3[3] = Imager.GetPixel(x - 1, y ).R;
                    Tab3x3[4] = Imager.GetPixel(x, y).R;
                    Tab3x3[5] = Imager.GetPixel(x + 1, y ).R;
                    Tab3x3[6] = Imager.GetPixel(x - 1, y + 1).R;
                    Tab3x3[7] = Imager.GetPixel(x , y + 1).R;
                    Tab3x3[8] = Imager.GetPixel(x + 1, y + 1).R;
                    return Tab3x3;
                }

        private int[] Transformation5x5(Bitmap Image, int x, int y)
        {
            int[] Tab5x5 = new int[25];
            Tab5x5[0] = Image.GetPixel(x - 2, y - 2).R;
            Tab5x5[1] = Image.GetPixel(x - 1, y - 2).R;
            Tab5x5[2] = Image.GetPixel(x, y - 2).R;
            Tab5x5[3] = Image.GetPixel(x + 1, y - 2).R;
            Tab5x5[4] = Image.GetPixel(x + 2, y - 2).R;
            Tab5x5[5] = Image.GetPixel(x - 2, y - 1).R;
            Tab5x5[6] = Image.GetPixel(x - 1, y - 1).R;
            Tab5x5[7] = Image.GetPixel(x, y - 1).R;
            Tab5x5[8] = Image.GetPixel(x + 1, y - 1).R;
            Tab5x5[9] = Image.GetPixel(x + 2, y - 1).R;
            Tab5x5[10] = Image.GetPixel(x - 2, y).R;
            Tab5x5[11] = Image.GetPixel(x - 1, y).R;
            Tab5x5[12] = Image.GetPixel(x, y).R;
            Tab5x5[13] = Image.GetPixel(x + 1, y).R;
            Tab5x5[14] = Image.GetPixel(x + 2, y).R;
            Tab5x5[15] = Image.GetPixel(x - 2, y + 1).R;
            Tab5x5[16] = Image.GetPixel(x - 1, y + 1).R;
            Tab5x5[17] = Image.GetPixel(x, y + 1).R;
            Tab5x5[18] = Image.GetPixel(x + 1, y + 1).R;
            Tab5x5[19] = Image.GetPixel(x + 2, y + 1).R;
            Tab5x5[20] = Image.GetPixel(x - 2, y + 2).R;
            Tab5x5[21] = Image.GetPixel(x - 1, y + 2).R;
            Tab5x5[22] = Image.GetPixel(x, y + 2).R;
            Tab5x5[23] = Image.GetPixel(x + 1, y + 2).R;
            Tab5x5[24] = Image.GetPixel(x + 2, y + 2).R;
            return Tab5x5;
        }

        private double[] NormalizateKernel(double[] kernelGauss)
        {
            double somme=0;
            for(int i = 0; i < 25 ; i++)
            {
                somme += kernelGauss[i];
            }
            if(somme !=0)
            {
                for (int i = 0; i < 25; i++)
                {
                    kernelGauss[i] = kernelGauss[i]/somme;
                }
            }
            return kernelGauss;
        }

        private double[] CreateKernel(double deviation)
        {
            double[] Kernel = new double[25];
            Kernel[0]  = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((-2) * (-2))+ ((-2) * (-2)) / (2 * deviation * deviation));
            Kernel[1]  = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((-1) * (-1)) + ((-2) * (-2)) / (2 * deviation * deviation));
            Kernel[2]  = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((0) * (0)) + ((-2) * (-2)) / (2 * deviation * deviation));
            Kernel[3]  = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((1) * (1)) + ((-2) * (-2)) / (2 * deviation * deviation));
            Kernel[4]  = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((2) * (2)) + ((-2) * (-2)) / (2 * deviation * deviation));
            Kernel[5]  = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((-2) * (-2)) + ((-1) * (-1)) / (2 * deviation * deviation));
            Kernel[6]  = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((-1) * (-1)) + ((-1) * (-1)) / (2 * deviation * deviation));
            Kernel[7]  = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((0) * (0)) + ((-1) * (-1)) / (2 * deviation * deviation));
            Kernel[8]  = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((1) * (1)) + ((-1) * (-1)) / (2 * deviation * deviation));
            Kernel[9]  = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((2) * (2)) + ((-1) * (-1)) / (2 * deviation * deviation));
            Kernel[10] = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((-2) * (-2)) + ((0) * (0)) / (2 * deviation * deviation));
            Kernel[11] = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((-1) * (-1)) + ((0) * (0)) / (2 * deviation * deviation));
            Kernel[12] = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((0) * (0)) + ((0) * (0)) / (2 * deviation * deviation));
            Kernel[13] = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((1) * (1)) + ((0) * (0)) / (2 * deviation * deviation));
            Kernel[14] = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((2) * (2)) + ((0) * (0)) / (2 * deviation * deviation));
            Kernel[15] = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((-2) * (-2)) + ((1) * (1)) / (2 * deviation * deviation));
            Kernel[16] = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((-1) * (-1)) + ((1) * (1)) / (2 * deviation * deviation));
            Kernel[17] = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((0) * (0)) + ((1) * (1)) / (2 * deviation * deviation));
            Kernel[18] = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((1) * (1)) + ((1) * (1)) / (2 * deviation * deviation));
            Kernel[19] = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((2) * (2)) + ((1) * (1)) / (2 * deviation * deviation));
            Kernel[20] = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((-2) * (-2)) + ((2) * (2)) / (2 * deviation * deviation));
            Kernel[21] = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((-1) * (-1)) + ((2) * (2)) / (2 * deviation * deviation));
            Kernel[22] = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((0) * (0)) + ((2) * (2)) / (2 * deviation * deviation));
            Kernel[23] = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((1) * (1)) + ((2) * (2)) / (2 * deviation * deviation));
            Kernel[24] = 1.0 / (2.0 * Math.PI * (deviation * deviation)) * Math.Exp(-((2) * (2)) + ((2) * (2)) / (2 * deviation * deviation));
            return Kernel;
        }
        #endregion
        private void laplacienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageCharge == true)
            {
                Bitmap Image = new Bitmap(ImgSrc.Image);
                int[] Entourage = new int[9];
                int[] Laplacien = new int[9];
                Laplacien[0] = -1; Laplacien[1] = -1; Laplacien[2] = -1;
                Laplacien[3] = -1; Laplacien[4] =  8;  Laplacien[5] = -1;
                Laplacien[6] = -1; Laplacien[7] = -1; Laplacien[8] = -1;
                ImgDest.Image = (Image)ImgSrc.Image.Clone();
                int niveaugris = 0;
                Bitmap ImageDst = new Bitmap(ImgDest.Image);
                int i, j, k;
                for (i = 1; i < Image.Width - 1; i++)
                {
                    for (j = 1; j < Image.Height - 1; j++)
                    {
                        Entourage = Transformation(Image, i, j);
                        for (k = 0; k < 9; k++)
                        {
                            niveaugris += (Entourage[k] * Laplacien[k]);
                        }
                        if (niveaugris < 0)
                            niveaugris = 0;
                        if (niveaugris > 255)
                            niveaugris = 255;
                        Color Couleur = Color.FromArgb(niveaugris,niveaugris,niveaugris);
                        ImageDst.SetPixel(i, j, Couleur);
                        niveaugris = 0;
                    }
                }
                #region ROGNERLESBORSDEL'IMAGE
                for (i = 0, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = Image.Width - 1, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = 0, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                for (i = Image.Height - 1, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                #endregion
                ImgDest.Image = ImageDst;
                ImageChargeDest = true;
                RetourImage.BackColor = Color.Green;
            }
        }

        private void kirshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageCharge == true)
            {
                Bitmap Image = new Bitmap(ImgSrc.Image);
                int[] Entourage = new int[9];
                int[] KirschV= new int[9];
                int[] KirschH = new int[9];
                double[] TabPente = new double[ImgSrc.Image.Height * ImgSrc.Image.Width];
                KirschV[0] = -3;KirschV[1] = -3;KirschV[2] =  5;KirschV[3] = -3;KirschV[4] = 0;KirschV[5] =  5;KirschV[6] = -3;KirschV[7] = -3;KirschV[8] = 5;
                KirschH[0] = -3;KirschH[1] = -3;KirschH[2] = -3;KirschH[3] = -3;KirschH[4] = 0;KirschH[5] = -3;KirschH[6] =  5;KirschH[7] =  5;KirschH[8] = 5;
                ImgDest.Image = (Image)ImgSrc.Image.Clone();
                int niveaugris = 0,niveaugris2 = 0;
                Bitmap ImageDst = new Bitmap(ImgDest.Image);
                int i, j, k;
                for (i = 1; i < Image.Width - 1; i++)
                {
                    for (j = 1; j < Image.Height - 1; j++)
                    {
                        Entourage = Transformation(Image, i, j);
                        for (k = 0; k < 9; k++)
                        {
                            niveaugris += (Entourage[k] * KirschH[k]);
                            niveaugris2 += (Entourage[k] * KirschV[k]);
                        }
                        TabPente[(i * j) + j] = (int)(Math.Atan2(niveaugris2, niveaugris) * (180 / Math.PI));
                        if (niveaugris < 0)
                            niveaugris = 0;
                        if (niveaugris > 255)
                            niveaugris = 255;
                        if (niveaugris2 < 0)
                            niveaugris2 = 0;
                        if (niveaugris2 > 255)
                            niveaugris2 = 255;
                        niveaugris += niveaugris2;
                        if (niveaugris < 0)
                            niveaugris = 0;
                        if (niveaugris > 255)
                            niveaugris = 255;
                        Color Couleur = Color.FromArgb(niveaugris, niveaugris, niveaugris);
                        ImageDst.SetPixel(i, j, Couleur);
                        niveaugris = 0;
                        niveaugris2 = 0;
                    }
                }
                #region ROGNERLESBORSDEL'IMAGE
                for (i = 0, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = Image.Width - 1, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = 0, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                for (i = Image.Height - 1, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                #endregion
                pente = new List<double>(TabPente);
                ImgDest.Image = ImageDst;
                ImageChargeDest = true;
                RetourImage.BackColor = Color.Green;
            }
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageCharge == true)
            {
                Bitmap Image = new Bitmap(ImgSrc.Image);
                int[] Entourage = new int[9];
                int[] SobelV = new int[9];
                int[] SobelH = new int[9];
                double[] TabPente = new double[ImgSrc.Image.Height * ImgSrc.Image.Width];
                SobelV[0] = -1; SobelV[1] = 0; SobelV[2] = 1;
                SobelV[3] = -2; SobelV[4] = 0; SobelV[5] = 2;
                SobelV[6] = -1; SobelV[7] = 0; SobelV[8] = 1;

                SobelH[0] = -1; SobelH[1] = -2; SobelH[2] = -1;
                SobelH[3] =  0; SobelH[4] =  0; SobelH[5] =  0;
                SobelH[6] =  1; SobelH[7] =  2; SobelH[8] =  1;
                ImgDest.Image = (Image)ImgSrc.Image.Clone();
                int niveaugris = 0, niveaugris2 = 0;
                Bitmap ImageDst = new Bitmap(ImgDest.Image);
                int i, j, k;
                for (i = 1; i < Image.Width - 1; i++)
                {
                    for (j = 1; j < Image.Height - 1; j++)
                    {
                        Entourage = Transformation(Image, i, j);
                        for (k = 0; k < 9; k++)
                        {
                            niveaugris += (Entourage[k] * SobelH[k]);
                            niveaugris2 += (Entourage[k] * SobelV[k]);
                        }
                        TabPente[(i * j) + j] = (int)(Math.Atan2(niveaugris2, niveaugris) * (180 / Math.PI));
                        if (niveaugris < 0)
                            niveaugris = 0;
                        if (niveaugris > 255)
                            niveaugris = 255;
                        if (niveaugris2 < 0)
                            niveaugris2 = 0;
                        if (niveaugris2 > 255)
                            niveaugris2 = 255;
                        niveaugris = (int)Math.Sqrt((niveaugris*niveaugris)+(niveaugris2*niveaugris2));
                        if (niveaugris < 0)
                            niveaugris = 0;
                        if (niveaugris > 255)
                            niveaugris = 255;
                        Color Couleur = Color.FromArgb(niveaugris, niveaugris, niveaugris);
                        ImageDst.SetPixel(i, j, Couleur);
                        niveaugris = 0;
                        niveaugris2 = 0;
                    }
                }
                #region ROGNERLESBORSDEL'IMAGE
                for (i = 0, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = Image.Width - 1, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = 0, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                for (i = Image.Height - 1, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                #endregion
                pente = new List<double>(TabPente);
                ImgDest.Image = ImageDst;
                ImageChargeDest = true;
                RetourImage.BackColor = Color.Green;
            }
        }

        private void prewittToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageCharge == true)
            {
                Bitmap Image = new Bitmap(ImgSrc.Image);
                int[] Entourage = new int[9];
                int[] PrewittV = new int[9];
                int[] PrewittH = new int[9];
                double[] TabPente = new double[ImgSrc.Image.Height * ImgSrc.Image.Width];
                PrewittV[0] = -1; PrewittV[1] = -1; PrewittV[2] = -1;
                PrewittV[3] = 0; PrewittV[4] = 0; PrewittV[5] = 0;
                PrewittV[6] = 1; PrewittV[7] = 1; PrewittV[8] = 1;

                PrewittH[0] = -1; PrewittH[1] = 0; PrewittH[2] = 1;
                PrewittH[3] = -1; PrewittH[4] = 0; PrewittH[5] = 1;
                PrewittH[6] = -1; PrewittH[7] = 0; PrewittH[8] = 1;
                ImgDest.Image = (Image)ImgSrc.Image.Clone();
                int niveaugris = 0, niveaugris2 = 0;
                Bitmap ImageDst = new Bitmap(ImgDest.Image);
                int i, j, k;
                for (i = 1; i < Image.Width - 1; i++)
                {
                    for (j = 1; j < Image.Height - 1; j++)
                    {
                        Entourage = Transformation(Image, i, j);
                        for (k = 0; k < 9; k++)
                        {
                            niveaugris += (Entourage[k] * PrewittH[k]);
                            niveaugris2 += (Entourage[k] * PrewittV[k]);
                        }
                        TabPente[(i * j) + j] = (int)(Math.Atan2(niveaugris2, niveaugris) * (180 / Math.PI));
                        if (niveaugris < 0)
                            niveaugris = 0;
                        if (niveaugris > 255)
                            niveaugris = 255;
                        if (niveaugris2 < 0)
                            niveaugris2 = 0;
                        if (niveaugris2 > 255)
                            niveaugris2 = 255;
                        niveaugris = (int)Math.Sqrt((niveaugris * niveaugris) + (niveaugris2 * niveaugris2));
                        if (niveaugris < 0)
                            niveaugris = 0;
                        if (niveaugris > 255)
                            niveaugris = 255;
                        Color Couleur = Color.FromArgb(niveaugris, niveaugris, niveaugris);
                        ImageDst.SetPixel(i, j, Couleur);
                        niveaugris = 0;
                        niveaugris2 = 0;
                    }
                }
                #region ROGNERLESBORSDEL'IMAGE
                for (i = 0, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = Image.Width - 1, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = 0, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                for (i = Image.Height - 1, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                #endregion
                pente = new List<double>(TabPente);
                ImgDest.Image = ImageDst;
                ImageChargeDest = true;
                RetourImage.BackColor = Color.Green;
            }
        }

        private void robertsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageCharge == true)
            {
                Bitmap Image = new Bitmap(ImgSrc.Image);
                int[] Entourage = new int[9];
                int[] RobertsV = new int[9];
                int[] RobertsH = new int[9];
                double[] TabPente = new double[ImgSrc.Image.Height * ImgSrc.Image.Width];
                RobertsV[0] = 0; RobertsV[1] = 0; RobertsV[2] = 0; RobertsV[3] = 0; RobertsV[4] = 0; RobertsV[5] = 1; RobertsV[6] = 0; RobertsV[7] = -1; RobertsV[8] = 0;
                RobertsH[0] = 0; RobertsH[1] = 0; RobertsH[2] = 0; RobertsH[3] = 0; RobertsH[4] = -1; RobertsH[5] = 0; RobertsH[6] = 0; RobertsH[7] = 0; RobertsH[8] = 1;
                ImgDest.Image = (Image)ImgSrc.Image.Clone();
                int niveaugris = 0, niveaugris2 = 0;
                Bitmap ImageDst = new Bitmap(ImgDest.Image);
                int i, j, k;
                for (i = 1; i < Image.Width - 1; i++)
                {
                    for (j = 1; j < Image.Height - 1; j++)
                    {
                        Entourage = Transformation(Image, i, j);
                        for (k = 0; k < 9; k++)
                        {
                            niveaugris += (Entourage[k] * RobertsH[k]);
                            niveaugris2 += (Entourage[k] * RobertsV[k]);
                        }
                        TabPente[(i * j) + j] = (int)(Math.Atan2(niveaugris2, niveaugris) * (180 / Math.PI));
                        if (niveaugris < 0)
                            niveaugris = 0;
                        if (niveaugris > 255)
                            niveaugris = 255;
                        if (niveaugris2 < 0)
                            niveaugris2 = 0;
                        if (niveaugris2 > 255)
                            niveaugris2 = 255;
                        niveaugris += niveaugris2;
                        if (niveaugris < 0)
                            niveaugris = 0;
                        if (niveaugris > 255)
                            niveaugris = 255;
                        Color Couleur = Color.FromArgb(niveaugris, niveaugris, niveaugris);
                        ImageDst.SetPixel(i, j, Couleur);
                        niveaugris = 0;
                        niveaugris2 = 0;
                    }
                }
                #region ROGNERLESBORSDEL'IMAGE
                for (i = 0, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = Image.Width - 1, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = 0, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                for (i = Image.Height - 1, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                #endregion
                pente = new List<double>(TabPente);
                ImgDest.Image = ImageDst;
                ImageChargeDest = true;
                RetourImage.BackColor = Color.Green;
            }
        }
        #endregion
        #region MORPHOLOGIE
        private void érosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageCharge == true)
            {
                Bitmap Image = new Bitmap(ImgSrc.Image);
                ImgDest.Image = (Image)ImgSrc.Image.Clone();
                Bitmap ImageDst = new Bitmap(ImgDest.Image);
                int min = 255;
                int[] Entourage = new int[9];
                int[] KernelErosion = new int[9];
                int niveaugris = 0;
                int i, j, k;
                KernelErosion[0] = 0; KernelErosion[1] = 1; KernelErosion[2] = 0;
                KernelErosion[3] = 1; KernelErosion[4] = 1; KernelErosion[5] = 1;
                KernelErosion[6] = 0; KernelErosion[7] = 1; KernelErosion[8] = 0;
                for (i = 1; i < Image.Width - 1; i++)
                {
                    for (j = 1; j < Image.Height - 1; j++)
                    {
                        Entourage = Transformation(Image, i, j);
                        for (k = 0; k < 9; k++)
                        {
                            niveaugris = (Image.GetPixel(i, j).R - (KernelErosion[k] * Entourage[k]));
                            if (min > niveaugris)
                            {
                                min = niveaugris;   
                            }
                        }
                        min += Entourage[4];
                        if (min < 0)
                            min = 0;
                        Color Couleur = Color.FromArgb((int)min, (int)min, (int)min);
                        min = 255;
                        ImageDst.SetPixel(i, j, Couleur);
                    }
                }
                #region ROGNERLESBORSDEL'IMAGE
                for (i = 0, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = Image.Width - 1, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = 0, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                for (i = Image.Height - 1, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                #endregion
                ImgDest.Image = ImageDst;
                ImageChargeDest = true;
                RetourImage.BackColor = Color.Green;
            }
        }
        

        private void dilatationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageCharge == true)
            {
                Bitmap Image = new Bitmap(ImgSrc.Image);
                ImgDest.Image = (Image)ImgSrc.Image.Clone();
                Bitmap ImageDst = new Bitmap(ImgDest.Image);
                int max = 0;
                int[] Entourage = new int[9];
                int[] KernelDilatation = new int[9];
                int niveaugris = 0;
                int i, j, k;
                KernelDilatation[0] = 0; KernelDilatation[1] = 1; KernelDilatation[2] = 0;
                KernelDilatation[3] = 1; KernelDilatation[4] = 1; KernelDilatation[5] = 1;
                KernelDilatation[6] = 0; KernelDilatation[7] = 1; KernelDilatation[8] = 0;
                for (i = 1; i < Image.Width - 1; i++)
                {
                    for (j = 1; j < Image.Height - 1; j++)
                    {
                        Entourage = Transformation(Image, i, j);
                        for (k = 0; k < 9; k++)
                        {
                            niveaugris = (-Image.GetPixel(i, j).R + (KernelDilatation[k] * Entourage[k]));
                            if (max < niveaugris)
                            {
                                max = niveaugris;
                            }
                        }
                        max += Entourage[4];
                        if (max > 255)
                            max = 255;
                        Color Couleur = Color.FromArgb((int)max, (int)max, (int)max);
                        max = 0;
                        ImageDst.SetPixel(i, j, Couleur);
                    }
                }
                #region ROGNERLESBORSDEL'IMAGE
                for (i = 0, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = Image.Width - 1, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = 0, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                for (i = Image.Height - 1, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                #endregion
                ImgDest.Image = ImageDst;
                ImageChargeDest = true;
                RetourImage.BackColor = Color.Green;
            }
        }

        private void ouvertureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageCharge == true)
            {
                Bitmap Image = new Bitmap(ImgSrc.Image);
                ImgDest.Image = (Image)ImgSrc.Image.Clone();
                Bitmap ImageDst = new Bitmap(ImgDest.Image);
                int min = 255, max = 0;
                int[] Entourage = new int[9];
                int[] KernelOuverture = new int[9];
                int niveaugris = 0;
                int i, j, k;
                KernelOuverture[0] = 0; KernelOuverture[1] = 1; KernelOuverture[2] = 0;
                KernelOuverture[3] = 1; KernelOuverture[4] = 1; KernelOuverture[5] = 1;
                KernelOuverture[6] = 0; KernelOuverture[7] = 1; KernelOuverture[8] = 0;

                for (i = 1; i < Image.Width - 1; i++)
                {
                    for (j = 1; j < Image.Height - 1; j++)
                    {
                        Entourage = Transformation(Image, i, j);
                        for (k = 0; k < 9; k++)
                        {
                            niveaugris = (Image.GetPixel(i, j).R - (KernelOuverture[k] * Entourage[k]));
                            if (min > niveaugris)
                            {
                                min = niveaugris;
                            }
                        }
                        min += Entourage[4];
                        if (min < 0)
                            min = 0;
                        Color Couleur = Color.FromArgb((int)min, (int)min, (int)min);
                        min = 255;
                        ImageDst.SetPixel(i, j, Couleur);
                    }
                }
                Bitmap Copie = ImageDst;
                for (i = 1; i < Image.Width - 1; i++)
                {
                    for (j = 1; j < Image.Height - 1; j++)
                    {
                        Entourage = Transformation(Image, i, j);
                        for (k = 0; k < 9; k++)
                        {
                            niveaugris = ( -Copie.GetPixel(i, j).R + (KernelOuverture[k] * Entourage[k]) );
                            if (max < niveaugris)
                            {
                                max = niveaugris;
                            }
                        }
                        max += Entourage[4];
                        if (max > 255)
                            max = 255;
                        Color Couleur = Color.FromArgb((int)max, (int)max, (int)max);
                        max = 0;
                        ImageDst.SetPixel(i, j, Couleur);
                    }
                }
                #region ROGNERLESBORSDEL'IMAGE
                for (i = 0, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = Image.Width - 1, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = 0, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                for (i = Image.Height - 1, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                #endregion
                ImgDest.Image = ImageDst;
                ImageChargeDest = true;
                RetourImage.BackColor = Color.Green;
            }
        }

        private void fermetureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageCharge == true)
            {
                Bitmap Image = new Bitmap(ImgSrc.Image);
                ImgDest.Image = (Image)ImgSrc.Image.Clone();
                Bitmap ImageDst = new Bitmap(ImgDest.Image);
                int min = 255, max = 0;
                int[] Entourage = new int[9];
                int[] KernelFermeture = new int[9];
                int niveaugris = 0;
                int i, j, k;
                KernelFermeture[0] = 0; KernelFermeture[1] = 1; KernelFermeture[2] = 0;
                KernelFermeture[3] = 1; KernelFermeture[4] = 1; KernelFermeture[5] = 1;
                KernelFermeture[6] = 0; KernelFermeture[7] = 1; KernelFermeture[8] = 0;
                for (i = 1; i < Image.Width - 1; i++)
                {
                    for (j = 1; j < Image.Height - 1; j++)
                    {
                        Entourage = Transformation(Image, i, j);
                        for (k = 0; k < 9; k++)
                        {
                            niveaugris = (-Image.GetPixel(i, j).R + (KernelFermeture[k] * Entourage[k]));
                            if (max < niveaugris)
                            {
                                max = niveaugris;
                            }
                        }
                        max += Entourage[4];
                        if (max > 255)
                            max = 255;
                        Color Couleur = Color.FromArgb((int)max, (int)max, (int)max);
                        max = 0;
                        ImageDst.SetPixel(i, j, Couleur);
                    }
                }
                Bitmap Copie = ImageDst;
                for (i = 1; i < Image.Width - 1; i++)
                {
                    for (j = 1; j < Image.Height - 1; j++)
                    {
                        Entourage = Transformation(Copie, i, j);
                        for (k = 0; k < 9; k++)
                        {
                            niveaugris = (Copie.GetPixel(i, j).R - (KernelFermeture[k] * Entourage[k]));
                            if (min > niveaugris)
                            {
                                min = niveaugris;
                            }
                        }
                        min += Entourage[4];
                        if (min < 0)
                            min = 0;
                        Color Couleur = Color.FromArgb((int)min, (int)min, (int)min);
                        min = 255;
                        ImageDst.SetPixel(i, j, Couleur);
                    }
                }
                #region ROGNERLESBORSDEL'IMAGE
                for (i = 0, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = Image.Width - 1, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = 0, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                for (i = Image.Height - 1, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                #endregion
                ImgDest.Image = ImageDst;
                ImageChargeDest = true;
                RetourImage.BackColor = Color.Green;
            }
        }
        #endregion
        #region OPTION
        private void detectionDesBordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageCharge == true)
            {
                Bitmap Image = new Bitmap(ImgSrc.Image);
                int[] Entourage = new int[9];
                int[] MatriceConvolution = new int[9];
                int[] MatriceConvolution2 = new int[9];
                double[] TabPente = new double[ImgSrc.Image.Height * ImgSrc.Image.Width];
                MatriceConvolution[0] = -1; MatriceConvolution[1] = 0; MatriceConvolution[2] = 1;
                MatriceConvolution[3] = -1; MatriceConvolution[4] = 0; MatriceConvolution[5] = 1;
                MatriceConvolution[6] = -1; MatriceConvolution[7] = 0; MatriceConvolution[8] = 1;

                MatriceConvolution2[0] = -1; MatriceConvolution2[1] = -1; MatriceConvolution2[2] = -1;
                MatriceConvolution2[3] = 0; MatriceConvolution2[4] = 0; MatriceConvolution2[5] = 0;
                MatriceConvolution2[6] = 1; MatriceConvolution2[7] = 1; MatriceConvolution2[8] = 1;
                ImgDest.Image = (Image)ImgSrc.Image.Clone();
                int niveaugris = 0, niveaugris2 = 0;
                Bitmap ImageDst = new Bitmap(ImgDest.Image);
                int i, j, k;
                for (i = 1; i < Image.Width - 1; i++)
                {
                    for (j = 1; j < Image.Height - 1; j++)
                    {
                        Entourage = Transformation(Image, i, j);
                        for (k = 0; k < 9; k++)
                        {
                            niveaugris += (Entourage[k]/3 * MatriceConvolution[k]);
                            niveaugris2 += (Entourage[k]/3 * MatriceConvolution2[k]);
                        }
                        TabPente[(i * j) + j] = (Math.Atan2(niveaugris2, niveaugris) * (180 / Math.PI));
                        if (niveaugris < 0)
                            niveaugris = 0;
                        if (niveaugris > 255)
                            niveaugris = 255;
                        if (niveaugris2 < 0)
                            niveaugris2 = 0;
                        if (niveaugris2 > 255)
                            niveaugris2 = 255;
                        niveaugris = (int)Math.Sqrt((niveaugris * niveaugris) + (niveaugris2 * niveaugris2)); //NORME DU GRADIENT
                        if (niveaugris < 0)
                            niveaugris = 0;
                        if (niveaugris > 255)
                            niveaugris = 255;
                        Color Couleur = Color.FromArgb(niveaugris, niveaugris, niveaugris);
                        ImageDst.SetPixel(i, j, Couleur);
                        niveaugris = 0;
                        niveaugris2 = 0;
                    }
                }
                #region ROGNERLESBORSDEL'IMAGE
                for (i = 0, j = 0;j < Image.Height ;j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = Image.Width - 1, j = 0; j < Image.Height; j++)
                {
                    ImageDst.SetPixel(i, j, Color.Black);
                }
                for (i = 0, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                for (i = Image.Height-1, j = 0; j < Image.Width; j++)
                {
                    ImageDst.SetPixel(j, i, Color.Black);
                }
                #endregion
                pente = new List<double>(TabPente);
                ImgDest.Image = ImageDst;
                ImageChargeDest = true;
                RetourImage.BackColor = Color.Green;
            }
        }

        private void seuillageParHystéresisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ImageCharge == true)
            {
                Bitmap Image = new Bitmap(ImgSrc.Image);
                int[] TabImage = new int[Image.Height * Image.Width];
                List<int> Intensite = new List<int>(TabImage);
                int[] Entourage = new int[9];
                int i, j,k,somme = 0,moyenne,variance,ecart;
                int Hs, Ls;
                ImgDest.Image = (Image)ImgSrc.Image.Clone();
                int niveaugris = 0;
                Color Blanc = Color.FromArgb(255, 255, 255);
                Color Noir = Color.FromArgb(0, 0, 0);
                Bitmap ImageDst = new Bitmap(ImgDest.Image);
                bool ok = false;
                #region CalculMoyenneVarianceEcartPourDeterminerValeursSeuill
                for (i = 0; i < Image.Width; i++)
                {
                    for (j = 0; j < Image.Height; j++)
                    {
                        Intensite[(i * j) + j] = Image.GetPixel(i, j).R;
                        somme += Intensite[(i * j) + j];
                    }
                }
                moyenne = (somme/Intensite.Count());
                somme = 0;
                foreach(int ndg in Intensite)
                {
                    somme += (ndg - moyenne) * (ndg - moyenne);
                }
                variance = (somme / Intensite.Count());
                ecart = (int)Math.Sqrt(variance);
                Hs = moyenne + ecart;
                Ls = moyenne - ecart;
                if (Hs > 255)
                    Hs = 255;
                if (Ls < 0)
                    Ls = 0;
                #endregion
                for (i = 1; i < Image.Width - 1; i++)
                {
                    for (j = 1; j < Image.Height - 1; j++)
                    {
                        niveaugris = Image.GetPixel(i, j).R;
                        if(niveaugris >= Hs)
                        {
                            ImageDst.SetPixel(i, j,Blanc);
                            ok = true;
                        }
                        if(niveaugris <= Ls)
                        {
                            ImageDst.SetPixel(i, j, Noir);
                            ok = true;
                        }
                        if(ok == false)
                        {
                            Entourage = Transformation(Image, i, j);
                            for(k=0; k<9 && ok == false; k++)
                            {
                                if(Entourage[k] >= Hs)
                                {
                                    ImageDst.SetPixel(i, j, Blanc);
                                    ok = true;
                                }
                            }
                            if(ok == false)
                            {
                                ImageDst.SetPixel(i, j, Noir);
                            }
                        
                        }
                        ok = false;
                    }
                }
                ImgDest.Image = ImageDst;
                ImageChargeDest = true;
                RetourImage.BackColor = Color.Green;
            }
           
        }
        

        private void affinageDesContoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImageCharge == true)
            {
                Bitmap Image = new Bitmap(ImgSrc.Image);
                int[] Entourage = new int[9];
                ImgDest.Image = (Image)ImgSrc.Image.Clone();
                Color Noir = Color.FromArgb(0, 0, 0);
                Bitmap ImageDst = new Bitmap(ImgDest.Image);
                int i, j;
                for (i = 1; i < Image.Width -1; i++)
                {
                    for (j = 1; j < Image.Height -1; j++)
                    {
                        if (pente[(i* j)+j] > -22.5 && pente[(i * j) + j] <=22.5)//Est
                        {
                            ImageDst.SetPixel(i+1, j, Noir);
                        }
                        if (pente[(i * j) + j] > 22.5 && pente[(i * j) + j] <= 67.5)//NE
                        {
                            ImageDst.SetPixel(i + 1, j - 1, Noir);
                        }
                        if(pente[(i * j) + j] > 67.5 && pente[(i * j) + j] <= 112.5)//Nord
                        {
                            ImageDst.SetPixel(i, j - 1, Noir);
                        }
                        if(pente[(i * j) + j] > 112.5 && pente[(i * j) + j] <= 157.5)//NO
                        {
                            ImageDst.SetPixel(i - 1, j - 1, Noir);
                        }
                        if(pente[(i * j) + j] > 157.5 || pente[(i * j) + j] <= -157.5)//Ouest
                        {
                            ImageDst.SetPixel(i - 1, j, Noir);
                        }
                        if(pente[(i * j) + j] > -157.5 && pente[(i * j) + j] <= -112.5)//SO
                        {
                            ImageDst.SetPixel(i - 1, j + 1, Noir);
                        }
                        if(pente[(i * j) + j] > -112.5 && pente[(i * j) + j] <= -67.5)//Sud
                        {
                            ImageDst.SetPixel(i, j + 1, Noir);
                        }
                        if(pente[(i * j) + j] > -67.5 && pente[(i * j) + j] <= -22.5)//SE
                        {
                            ImageDst.SetPixel(i + 1, j + 1, Noir);
                        }
                    }
                }
                ImgDest.Image = ImageDst;
                ImageChargeDest = true;
                RetourImage.BackColor = Color.Green;
            }
        }
        
        private void chainageDesContoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ImgSrc.Image.Save(dialog.FileName);
            }
            buttonSaveImage.BackColor = Color.Green;
        }
    }

}
