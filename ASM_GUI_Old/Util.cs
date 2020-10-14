using ASM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASM_GUI_Old
{
    public static class Util
    {
        /// <summary>
        /// Converts Data type ints into different base
        /// </summary>
        /// <param name="value">The value to be converted</param>
        /// <param name="baseInt">The base the value should be converted to as an int.</param>
        /// <returns>A string of the converted value</returns>
        public static string ConvertDataToSelectedBase(int? value, int baseInt)
        {
            if (value == null)
                return null;
            if (baseInt == 16)
                return new Hex(value.Value).ToString();
            return Convert.ToString(value.Value, baseInt);
        }

        /// <summary>
        /// Converts Data type ints into different base
        /// </summary>
        /// <param name="value">The value to be converted</param>
        /// <param name="baseInt">The base the value should be converted to as an int.</param>
        /// <returns>A string of the converted value</returns>
        public static string ConvertInstructionToSelectedBase(Hex value, int baseInt)
        {
            if (value == null)
                return null;
            if (baseInt == 16)
                return new Hex(value).ToString();
            if (baseInt == 2)
                return Convert.ToString(value, baseInt).PadLeft(15,'0');
            return Convert.ToString(value, baseInt);
        }

    }
}
