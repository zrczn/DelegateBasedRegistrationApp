using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateBasedApp.FieldValidators
{
    public delegate bool FieldValidatorDel(int fieldIndex, string fieldValue,
                                          string[] fieldArr, out string fieldInvalidMsg);

    public interface IFieldValidator
    {
        void InitializeValidatorDelegates();
        string[] FieldArray { get; }
        FieldValidatorDel ValidatorDel { get; }
    }
}
