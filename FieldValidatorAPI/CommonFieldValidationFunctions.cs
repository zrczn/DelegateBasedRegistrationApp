using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FieldValidatorAPI
{
    public delegate bool RequiredValidDel(string fieldVal); //Check id field null
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max); //check for field min max lenght
    public delegate bool DateValidDel(string fieldVal, out DateTime validDateTime); //check for valid date
    public delegate bool PatternBasedDel(string fieldVal, string pattern); //check against regex pattern
    public delegate bool CompareFieldsValidDel(string fieldVal, string compareToField); //field comparer

    public class CommonFieldValidationFunctions
    {
        private static RequiredValidDel _requiredValidDel = null;
        private static StringLengthValidDel _stringLengthValidDel = null;
        private static DateValidDel _dateValidDel = null;
        private static PatternBasedDel _patternBasedDel = null;
        private static CompareFieldsValidDel _compareFieldsValidDel = null;

        public static RequiredValidDel RequiredFieldValidDel
        {
            get
            {
                if (_requiredValidDel == null)
                    _requiredValidDel = new RequiredValidDel(RequiredFieldValid);

                return _requiredValidDel;
            }
        }

        public static StringLengthValidDel StringLengthFieldValidDel
        {
            get
            {
                if (_stringLengthValidDel == null)
                    _stringLengthValidDel = new StringLengthValidDel(StringLengthValid);

                return _stringLengthValidDel;
            }
        }

        public static DateValidDel DateValidFieldDel
        {
            get
            {
                if (_dateValidDel == null)
                    _dateValidDel = new DateValidDel(DateFieldValid);

                return _dateValidDel;
            }
        }

        public static PatternBasedDel PatternBasedFieldDel
        {
            get
            {
                if (_patternBasedDel == null)
                    _patternBasedDel = new PatternBasedDel(FieldPatternValid);

                return _patternBasedDel;
            }
        }

        public static CompareFieldsValidDel CompareFieldsValidFieldDel
        {
            get
            {
                if (_compareFieldsValidDel == null)
                    _compareFieldsValidDel = new CompareFieldsValidDel(FieldComparisonValid);

                return _compareFieldsValidDel;
            }
        }


        //method implementations

        private static bool RequiredFieldValid(string fieldVal)
        {
            if (string.IsNullOrEmpty(fieldVal))
                return false;

            return true;
        }

        private static bool StringLengthValid(string fieldVal, int min, int max)
        {
            if (fieldVal.Length >= min && fieldVal.Length <= max)
                return true;

            return false;
        }

        private static bool DateFieldValid(string datetime, out DateTime validDateTime)
        {
            if (DateTime.TryParse(datetime, out validDateTime))
                return true;

            return false;
        }

        private static bool FieldPatternValid(string fieldVal, string regexString)
        {
            Regex rgx = new Regex(regexString);

            if (rgx.IsMatch(fieldVal))
                return true;

            return false;
        }

        private static bool FieldComparisonValid(string f1, string f2)
        {
            if (f1.Equals(f2))
                return true;

            return false;
        }

    }

}
