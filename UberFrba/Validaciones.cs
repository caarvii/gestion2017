using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UberFrba
{
    public static class Validaciones
    {
        public static void allowNumericOnly(this Form aForm, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        public static void allowAlphaOnly(this Form aForm, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        public static void allowAlphaOnlyYEspacio(this Form aForm, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }

        public static void allowAlphanumericOnly(this Form aForm, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        public static void allowAlphanumericYEspacio(this Form aForm, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == ' ');
        }

        public static void allowMaxLenght(this Form aForm,TextBox txt, int tamMax, KeyPressEventArgs e)
        {
            if (txt.Text.Length == tamMax)
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }











    }
}
