using FieldValidatorAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DelegateBasedApp.FieldValidators
{
    public class UserRegistrationValidator : IFieldValidator
    {
        const int FirstNameMaxLength = 100;
        const int FirstNameMinLength = 2;
        const int LastNameMinLength = 2;
        const int LastNameMaxLength = 100;

        delegate bool EmailExistsDel(string emailAdress);

        FieldValidatorDel _fieldValidatorDel = null;

        RequiredValidDel _requiredValidDel = null;
        StringLengthValidDel _stringLengthValidDel = null;
        DateValidDel _dateValidDel = null;
        PatternBasedDel _patternBasedDel = null;
        CompareFieldsValidDel _compareFieldValidDel = null;

        EmailExistsDel _emailExistsDel = null;

        string[] _fieldArray = null;

        public string[] FieldArray
        {
            get
            {
                if (_fieldArray == null)
                    _fieldArray = new string[Enum.GetValues(typeof(UserRegistrationField)).Length];

                return _fieldArray;
            }
        }

        public FieldValidatorDel ValidatorDel => _fieldValidatorDel;

        public void InitializeValidatorDelegates()
        {
            _fieldValidatorDel = new FieldValidatorDel(ValidateField);

            _requiredValidDel = CommonFieldValidationFunctions.RequiredFieldValidDel;
            _stringLengthValidDel = CommonFieldValidationFunctions.StringLengthFieldValidDel;
            _dateValidDel = CommonFieldValidationFunctions.DateValidFieldDel;
            _patternBasedDel = CommonFieldValidationFunctions.PatternBasedFieldDel;
            _compareFieldValidDel = CommonFieldValidationFunctions.CompareFieldsValidFieldDel;
        }

        private bool ValidateField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMssg)
        {
            fieldInvalidMssg = "";

            UserRegistrationField userRegistrationField = (UserRegistrationField)fieldIndex;

            switch (userRegistrationField)
            {
                //28 min
            }

            return fieldInvalidMssg == "";
        }
    }
}
