using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FieldValidatorAPI
{
    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
    public delegate bool DateValidDel(string fieldVal, out DateTime validDate);
    public delegate bool PatternValidDel(string fieldVal, string pattern);
    public delegate bool CompareFieldValidDel(string fieldval, string fieldCompareVal);
    public class CoomonFieldValidatorFunctions
    {
        private static RequiredValidDel requiredValidDel = null;
        private static StringLengthValidDel stringLengthValidDel = null;
        private static DateValidDel dateValidDel = null;
        private static PatternValidDel patternValidDel = null;
        private static CompareFieldValidDel compareFieldValidDel = null;

        public static RequiredValidDel RequiredFieldValidDel
        {
            get
            {
                if (requiredValidDel == null)
                    requiredValidDel = new RequiredValidDel(RequiredFieldValid);

                return requiredValidDel;
            }
        }

        public static StringLengthValidDel StringFieldLengthValidDel
        {
            get
            {
                if (stringLengthValidDel == null)
                    stringLengthValidDel = new StringLengthValidDel(StringFieldLengthValid);

                return stringLengthValidDel;
            }
        }
        public static DateValidDel DateFieldValidDel
        {
            get
            {
                if (dateValidDel == null)
                    dateValidDel = new DateValidDel(DateFieldValid);

                return dateValidDel;
            }
        }
        public static PatternValidDel PatternFieldValidDel
        {
            get
            {
                if (patternValidDel == null)
                    patternValidDel = new PatternValidDel(PatterValid);

                return patternValidDel;
            }
        }
        public static CompareFieldValidDel CompareFieldValidDel
        {
            get
            {
                if (compareFieldValidDel == null)
                    compareFieldValidDel = new CompareFieldValidDel(CompareValid);

                return compareFieldValidDel;
            }
        }
        private static bool RequiredFieldValid(string fieldVal)
        {
            if (string.IsNullOrEmpty(fieldVal))
                return true;

            return false;
        }

        private static bool StringFieldLengthValid(string fieldVal, int min, int max)
        {
            if (fieldVal.Length >= max && fieldVal.Length <= min)
                return true;

            return false;
        }

        private static bool DateFieldValid(string fieldVal, out DateTime validDate)
        {
            if (DateTime.TryParse(fieldVal, out validDate))
                return true;

            return false;
        }

        private static bool PatterValid(string fieldVal, string pattern)
        {
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(fieldVal))
                return true;

            return false;
        }

        private static bool CompareValid(string fieldVal, string fieldValCompare)
        {
            if (fieldVal.Equals(fieldValCompare))
                return true;

            return false;
        }
    }

}
