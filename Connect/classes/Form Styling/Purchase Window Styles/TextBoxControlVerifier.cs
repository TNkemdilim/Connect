﻿using Accessibility;
using Connect.Properties;
using Microsoft.VisualBasic.PowerPacks;
using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Connect.classes.Form_Styling.Purchase_Window_Styles
{
    internal class TextBoxControlVerifier
    {
        public readonly TextBox _txtBox;
        private RectangleShape _rectangleShape;
        private readonly PictureBox _iconPictureBox;
        private readonly NumberStyles _style1;
        private readonly CustomNumberStyles _style2;

        public enum CustomNumberStyles
        {
            NotMoreThan31Days,
            YearLimit,
            MonthLimit,
            None
        }

        public TextBoxControlVerifier(TextBox textBox, RectangleShape rectangleShape,
            PictureBox iconPictureBox, NumberStyles style = NumberStyles.Any)
        {
            _txtBox = textBox;
            _rectangleShape = rectangleShape;
            _iconPictureBox = iconPictureBox;
            _style1 = style;
        }

        public TextBoxControlVerifier(TextBox textBox, RectangleShape rectangleShape,
            PictureBox iconPictureBox, CustomNumberStyles style)
        {
            _txtBox = textBox;
            _rectangleShape = rectangleShape;
            _iconPictureBox = iconPictureBox;
            _style2 = style;
            _style1 = NumberStyles.Any;
        }

        public TextBoxControlVerifier()
        {
        }

        public virtual bool VerifyInput()
        {
            var success = 0;
            if (_txtBox.Text != string.Empty)
            {
                if (_style1 != NumberStyles.Any)
                {
                    int.TryParse(_txtBox.Text, _style1, new NumberFormatInfo(), out success);
                }
                else if (_style2.Equals(CustomNumberStyles.NotMoreThan31Days)
                    && Regex.Match(_txtBox.Text, "[0-9]", RegexOptions.IgnoreCase).Success)
                {
                    success = (Convert.ToInt32(_txtBox.Text) <= 31) && (Convert.ToInt32(_txtBox.Text) >= 1) ? 1 : 0;
                }
                else if (_style2.Equals(CustomNumberStyles.MonthLimit)
                && Regex.Match(_txtBox.Text, "[0-9]", RegexOptions.IgnoreCase).Success)
                {
                    success = (Convert.ToInt32(_txtBox.Text) <= 12) && (Convert.ToInt32(_txtBox.Text) >= 1) ? 1 : 0;
                }
                else if (_style2.Equals(CustomNumberStyles.YearLimit)
                && Regex.Match(_txtBox.Text, "[0-9]", RegexOptions.IgnoreCase).Success)
                {
                    success = (Convert.ToInt32(_txtBox.Text) <= 3000) && (Convert.ToInt32(_txtBox.Text) >= DateTime.Now.Year) ? 1 : 0;
                }
                else if (_style1 != NumberStyles.Any)
                {
                    //is not a number required field e.g name on card
                    success = 1;
                }
                else
                {
                    success = 0;
                }

                if (success.Equals(0))
                {
                    if (_iconPictureBox != null)
                    {
                        //not a valid integer input in number required field
                        _iconPictureBox.Image = Resources.Delete_16px;
                        _iconPictureBox.Visible = true;
                    }
                }
                else
                {
                    if (_iconPictureBox != null)
                    {
                        _iconPictureBox.Image = Resources.Checkmark_16px;
                        _iconPictureBox.Visible = true;
                    }
                }
            }
            else
            {
                if (_iconPictureBox != null)
                {
                    _iconPictureBox.Image = Resources.Delete_16px;
                    _iconPictureBox.Visible = true;
                }
            }

            if (success > 0) return true;
            else return false;
        }
    }
}