using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Station_Security_Simulation
{
    
    public partial class Form1 : Form
    {
        bool isDropdown1Open = false;
        bool isDropdown2Open = false;

        bool generateRandomNumber = false;

        int currentNumberToConvert;

        RandomNumberGen randomNumberGen = new RandomNumberGen();
        NumberConverter numberConverter = new NumberConverter();


        public Form1()
        {
            InitializeComponent();
            textBox1.BackColor = Color.FromArgb(58, 22, 112);
            textBox1.MaxLength = 999999999;
            numberConverter.convertFrom = ConvertFrom.binary;
            numberConverter.convertTo = ConvertTo.binary;
        }

        #region Dropdown 1
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if the dropdown menu is open
            if (isDropdown1Open)
            {
                panel1.Height -= 7;

                if (panel1.Height <= 0)
                {
                    timer1.Stop();
                    panel1.Height = 0;
                    isDropdown1Open = false;
                }
            }
            //otherwise
            else
            {
                //increase the pannel2 height by 10px per tick
                panel1.Height += 7;

                //if pannel2 height is equal to 130px
                if (panel1.Height >= 150)
                {
                    timer1.Stop();
                    timer1.Interval = 20;
                    isDropdown1Open = true;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Space_Station_Security_Simulation.Properties.Resources.Binary4;
            numberConverter.convertFrom = ConvertFrom.binary;
            Debug.Print("Converting From:" + numberConverter.convertFrom);
            timer1.Start();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Space_Station_Security_Simulation.Properties.Resources.Hex2;
            numberConverter.convertFrom = ConvertFrom.hex;
            timer1.Start();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Space_Station_Security_Simulation.Properties.Resources.Decimal3;
            numberConverter.convertFrom = ConvertFrom.deci;
            timer1.Start();
        }

        #endregion

        #region Dropdown 2
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //if the dropdown menu is open
            if (isDropdown2Open)
            {
                panel3.Height -= 7;

                if (panel3.Height <= 0)
                {
                    timer2.Stop();
                    panel3.Height = 0;
                    isDropdown2Open = false;
                }
            }
            //otherwise
            else
            {
                //increase the pannel2 height by 10px per tick
                panel3.Height += 7;

                //if pannel2 height is equal to 130px
                if (panel3.Height >= 150)
                {
                    timer2.Stop();
                    timer2.Interval = 20;
                    isDropdown2Open = true;
                }
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pictureBox7.Image = Space_Station_Security_Simulation.Properties.Resources.Binary4;
            numberConverter.convertTo = ConvertTo.binary;
            Debug.Print("Converting to: " + numberConverter.convertTo);
            timer2.Start();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox7.Image = Space_Station_Security_Simulation.Properties.Resources.Hex2;
            numberConverter.convertTo = ConvertTo.hex;
            Debug.Print("Converting to: " + numberConverter.convertTo);
            timer2.Start();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox7.Image = Space_Station_Security_Simulation.Properties.Resources.Decimal3;
            numberConverter.convertTo = ConvertTo.deci;
            Debug.Print("Converting to: " + numberConverter.convertTo);
            timer2.Start();
        }
        #endregion

        #region Generating a Random Number
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            generateRandomNumber = !generateRandomNumber;

            if(generateRandomNumber)
            {
                //generate a random number of the type to convert from

                //generate the random number
                int randomNumber = randomNumberGen.GenerateNumber();
                currentNumberToConvert = randomNumber;

                //display random number in text box, if we are converting from
                if(numberConverter.convertFrom == ConvertFrom.binary)
                {
                    //create and populate the binary number, held in this string list
                    List<string> binaryNumber = numberConverter.ConvertDecimalToBinary(randomNumber);
                    string binaryNum = "";

                    for(int i = 0; i < binaryNumber.Count; i++)
                    {
                        if(i == 0)
                        {
                            binaryNum = binaryNumber[i];
                        }
                        else
                        {
                            binaryNum = binaryNum + binaryNumber[i];
                        }
                    }

                    Console.WriteLine(binaryNum);
                    textBox1.Text = binaryNum;
                }

               
            }
            else
            {
                //remove the random number from the text box
                textBox1.Text = "";
            }
        }
        #endregion
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            

            

        }
        #region Swap Button Attributes
        private void pictureBox14_MouseHover(object sender, EventArgs e)
        {
            //sets the background image to the highlight image I created, gets the image from the resource folder
            pictureBox14.BackgroundImage = Space_Station_Security_Simulation.Properties.Resources.ButtonHighlight;
        }

        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            //sets the background image to null (no image)
            pictureBox14.BackgroundImage = null;
        }
        #endregion

        #region dialpad 1
        /// <summary>
        /// This method sets the background image on the number 1 on the dial pad when it is hovered over.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox26_MouseHover(object sender, EventArgs e)
        {
            //sets the background image to the highlight image I created, gets the image from the resource folder
            pictureBox26.BackgroundImage = Space_Station_Security_Simulation.Properties.Resources.ButtonHighlight;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox26_MouseLeave(object sender, EventArgs e)
        {
            //sets the background image to null (no image)
            pictureBox26.BackgroundImage = null;
        }
        #endregion

        #region dialpad 2
        /// <summary>
        /// This method sets the background image on the number 2 on the dial pad when it is hovered over.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox25_MouseHover(object sender, EventArgs e)
        {
            //sets the background image to the highlight image I created, gets the image from the resource folder
            pictureBox25.BackgroundImage = Space_Station_Security_Simulation.Properties.Resources.ButtonHighlight;
        }
        /// <summary>
        /// This method sets the background image on the number 2 on the dial pad back to having no background image when the mouse leaves
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox25_MouseLeave(object sender, EventArgs e)
        {
            //sets the background image to null (no image)
            pictureBox25.BackgroundImage = null;
        }
        #endregion

        #region dialpad 3
        /// <summary>
        /// This method sets the background image on the number 3 on the dial pad when it is hovered over.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox24_MouseHover(object sender, EventArgs e)
        {
            //sets the background image to the highlight image I created, gets the image from the resource folder
            pictureBox24.BackgroundImage = Space_Station_Security_Simulation.Properties.Resources.ButtonHighlight;
        }

        /// <summary>
        /// This method removes the background image on the number 3 on the dial pad when the mouse leaves.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox24_MouseLeave(object sender, EventArgs e)
        {
            //sets the background image to null (no image)
            pictureBox24.BackgroundImage = null;
        }

        #endregion

        #region dialpad 4
        private void pictureBox23_MouseHover(object sender, EventArgs e)
        {
            pictureBox23.BackgroundImage = Space_Station_Security_Simulation.Properties.Resources.ButtonHighlight;
        }

        private void pictureBox23_MouseLeave(object sender, EventArgs e)
        {
            //sets the background image to null (no image)
            pictureBox23.BackgroundImage = null;
        }

        #endregion

        #region dialpad 5
        private void pictureBox22_MouseHover(object sender, EventArgs e)
        {
            pictureBox22.BackgroundImage = Space_Station_Security_Simulation.Properties.Resources.ButtonHighlight;
        }

        private void pictureBox22_MouseLeave(object sender, EventArgs e)
        {
            //sets the background image to null (no image)
            pictureBox22.BackgroundImage = null;
        }
        #endregion

        #region dialpad 6
        private void pictureBox21_MouseHover(object sender, EventArgs e)
        {
            pictureBox21.BackgroundImage = Space_Station_Security_Simulation.Properties.Resources.ButtonHighlight;
        }

        private void pictureBox21_MouseLeave(object sender, EventArgs e)
        {
            //sets the background image to null (no image)
            pictureBox21.BackgroundImage = null;
        }
        #endregion

        #region dialpad 7
        private void pictureBox20_MouseHover(object sender, EventArgs e)
        {
            pictureBox20.BackgroundImage = Space_Station_Security_Simulation.Properties.Resources.ButtonHighlight;
        }

        private void pictureBox20_MouseLeave(object sender, EventArgs e)
        {
            //sets the background image to null (no image)
            pictureBox20.BackgroundImage = null;
        }
        #endregion

        #region dialpad 8
        private void pictureBox19_MouseHover(object sender, EventArgs e)
        {
            pictureBox19.BackgroundImage = Space_Station_Security_Simulation.Properties.Resources.ButtonHighlight;
        }

        private void pictureBox19_MouseLeave(object sender, EventArgs e)
        {
            //sets the background image to null (no image)
            pictureBox19.BackgroundImage = null;
        }
        #endregion

        #region dialpad 9
        private void pictureBox18_MouseHover(object sender, EventArgs e)
        {
            pictureBox18.BackgroundImage = Space_Station_Security_Simulation.Properties.Resources.ButtonHighlight;
        }

        private void pictureBox18_MouseLeave(object sender, EventArgs e)
        {
            //sets the background image to null (no image)
            pictureBox18.BackgroundImage = null;
        }
        #endregion

        #region decimal point
        private void pictureBox17_MouseHover(object sender, EventArgs e)
        {
            pictureBox17.BackgroundImage = Space_Station_Security_Simulation.Properties.Resources.ButtonHighlight;
        }

        private void pictureBox17_MouseLeave(object sender, EventArgs e)
        {
            //sets the background image to null (no image)
            pictureBox17.BackgroundImage = null;
        }
        #endregion

        #region dialpad 0
        private void pictureBox16_MouseHover(object sender, EventArgs e)
        {
            pictureBox16.BackgroundImage = Space_Station_Security_Simulation.Properties.Resources.ButtonHighlight;
        }

        private void pictureBox16_MouseLeave(object sender, EventArgs e)
        {
            //sets the background image to null (no image)
            pictureBox16.BackgroundImage = null;
        }
        #endregion

        #region clear
        private void pictureBox15_MouseHover(object sender, EventArgs e)
        {
            //setting the background image to the button highlight background from the resource folder
            pictureBox15.BackgroundImage = Space_Station_Security_Simulation.Properties.Resources.ButtonHighlight;

            //setting the image to the white c image from the resource folder
            pictureBox15.Image = Space_Station_Security_Simulation.Properties.Resources.Clear_Button;
        }

        private void pictureBox15_MouseLeave(object sender, EventArgs e)
        {
            //sets the background image to null (no image)
            pictureBox15.BackgroundImage = null;

            //setting the c image back to the purple c when the picture is no longer being hovered over with the mouse
            pictureBox15.Image = Space_Station_Security_Simulation.Properties.Resources.C_Button;
        }
        #endregion


        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Convert From: " + numberConverter.convertFrom);

            if(numberConverter.convertFrom == ConvertFrom.binary)
            {

                if(numberConverter.convertTo != ConvertTo.binary)
                {
                    //convert the number in the textbox 1
                    int convertedNumber = numberConverter.ConvertFromBinary(textBox1.Text);

                    //display the converted number
                    label1.Text = convertedNumber.ToString();
                }
            }
        }
    }
}
//arrow swap by Muneer A.Safiah from the Noun Project