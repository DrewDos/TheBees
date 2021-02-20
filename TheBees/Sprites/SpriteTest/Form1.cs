using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpriteTest.Graphics;

namespace SpriteTest
{
    public partial class Form1 : Form
    {
        private const int maxSpriteW = Sprite.MaxSpriteW;
        private const int maxSpriteH = Sprite.MaxSpriteH;

        //Color [] pallet;
        Bitmap b;
        Sprite mainSprite;
        
        List<Sprite> spriteList;


        public Form1()
        {
            InitializeComponent();

            InitObjects();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void InitObjects()
        {

            b = new Bitmap(maxSpriteW, maxSpriteH);

            //pallet = Pallet.FromFile("c:\\sourcepallet");
            //spriteSet = SpriteHandler.FromRom("C:\\20d", "C:\\50", pallet, b); 
            //spriteSet = SpriteHandler.GetLargeSprite("C:\\20d", "C:\\50", pallet, b);

            SpriteHandler.LoadRomData();

            mainSprite = SpriteHandler.GetLargeSprite(0x0c);
            spriteList = SpriteHandler.GetLargeFromRange(1, 0x0E);
            //mainSprite = SpriteHandler.GetNormalSprite(0xd8D0);
            //multiSprite = SpriteHandler.GetSpritesFromIndexes(new int[] { 0xE180 });
            trackBarH.Minimum = 0;
            trackBarH.Maximum = mainSprite.GetPalCount();

            if(trackBarH.Maximum >= 0)
                trackBarH.Value = 0;

            labelSprIndex.Text = string.Format("Pallet Index: {0}", trackBarH.Value.ToString("X8"));
            /*
            trackBarSprIndex.Minimum = 0;
            trackBarSprIndex.Maximum = 512;
            trackBarSprIndex.Value = 16;
            */
            //SetLblText();

            trackBarW.Minimum = 1;
            trackBarW.Maximum = spriteList.Count - 1;
            trackBarW.Value = 1;

            spriteList[0].DrawSprite(b, 250, 250);

           // SpriteHandler.DrawMultipleSprites(b, multiSprite, 350, 350);
            spritePanel.SetBitmap(b);
            spritePanel.SetImageSize(maxSpriteW, maxSpriteH);
            spritePanel.Draw();
            //spritePanel.SetBitmap(spriteSet[0].AsBitmap);
     
        }

        private void trackBarH_Scroll(object sender, EventArgs e)
        {
            //OnTrackBarScroll();
            mainSprite.SetPalletOffset(trackBarH.Value);
            mainSprite.DrawSprite(b, 350, 350);
            spritePanel.Draw();

            labelSprIndex.Text = string.Format("Pallet Index: {0}", trackBarH.Value.ToString("X8"));

        }

        private void trackBarW_Scroll(object sender, EventArgs e)
        {
            //OnTrackBarScroll();
            
            spriteList[trackBarW.Value-1].DrawSprite(b, 250, 250);
            spritePanel.Draw();
        }

        private void OnTrackBarScroll()
        {
            SetLblText();

            // set the control to the current bitmap
            //spritePanel.SetBitmap(sp.GetBitmap(pallet));      
        }

        private void SetLblText()
        {
            labelW.Text = String.Format("Width: {0}", trackBarW.Value);
            labelH.Text = String.Format("Height: {0}", trackBarH.Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBarSprIndex_Scroll(object sender, EventArgs e)
        {
            

            //Sprite sprite = spriteSet[trackBarSprIndex.Value];

            //spritePanel.SetBitmap(b);
            //sprite.DrawSprite(b, maxSpriteW, maxSpriteH);
             
            //spritePanel.SetBitmap(spriteSet[0].GetSingleTile(trackBarSprIndex.Value));

            //((LargeSprite)(mainSprite)).SetWidthInTiles(trackBarSprIndex.Value);
            //spritePanel.Invalidate();
        }

        private void labelSprIndex_Click(object sender, EventArgs e)
        {

        }
    }
}
