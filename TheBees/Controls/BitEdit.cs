using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TheBees.General;

namespace TheBees
{
    public enum BitEditChange
    {
        Private,
        Input,
        ValueSet
    }

    public enum BitEditMode
    {
        Ranged,
        ByValues
    }

    public partial class BitEdit : TextBox, ICustomObservable<NotifyObserver, NotifyParams>
    {
        //private int _vaildSizeInBits;
        //private int _maxLength;
        //private const uint _maxBitSize = sizeof(uint)*8;
        //private const uint _bitFrame = 0xFFFFFFFF;

        private uint value = 0;
        private uint maxValue = 0;
        private uint minValue = 0;

        private uint[] validValues;
        private int valueIndex = 0;

        public BitEditChange ChangeType = BitEditChange.Private;

        public Action<uint> SetValue;
        private Action ValidateText;

        private Action increase;
        private Action decrease;

        public event NotifyObserver ValueChangedEvent = null;
        
        
        public BitEdit()
        {
            InitializeComponent();

            SetMode(BitEditMode.Ranged);

        }

        public void SetMode(BitEditMode newMode, uint[] newValues = null)
        {
            if (newMode == BitEditMode.Ranged)
            {
                SetValue = SetValueModeRanged;
                increase = () => { SetValue(value+1); };
                decrease = () => { SetValue(value-1); };
                ValidateText = ValidateModeRanged;
            }

            else if (newMode == BitEditMode.ByValues)
            {
                if (newValues == null || newValues.Length == 0)
                    throw new Exception("Indexes cannot be null and cannot have a count of 0");

                validValues = newValues;
                Array.Sort(validValues);
                valueIndex = 0;

                SetValue = SetValueModeValues;
                increase = () => { if (valueIndex + 1 < validValues.Length) { valueIndex++; SetValue(validValues[valueIndex]); } };
                decrease = () => { if (valueIndex > 0) { valueIndex--; SetValue(validValues[valueIndex]); } };
                ValidateText = ValidateModeValues;
            }
        }

        

        //private void SetMaxLength()
        //{
        //    _maxLength = (_vaildSizeInBits / 4) + (_vaildSizeInBits % 4 > 0 ? 1 : 0);
        //    int testvar;
        //    testvar = _vaildSizeInBits % 4;
        //    testvar = 0;
        //}

        //private void SetMaxValue()
        //{
        //    int shiftAmt = (int)_maxBitSize - _vaildSizeInBits;
        //    maxValue = (_bitFrame << (shiftAmt)) >> shiftAmt;
        //}

        private void Validate()
        {
            this.Text = this.Text.Trim().ToUpper();

            // make sure it's not empty
            if (this.Text.Length == 0)
            {
                ValidateText();
            }            
        }

        private void ValidateModeRanged()
        {
            this.Text = minValue.ToString();
        }

        private void ValidateModeValues()
        {
            this.Text = validValues[0].ToString();
        }
        
        
        private void SetValueModeRanged(uint newValue)
        {
            this.value = newValue;

            if (value > maxValue)
            {
                this.Text = maxValue.ToString("X");
                value = maxValue;
            }
            else if (value < minValue)
            {
                this.Text = minValue.ToString("X");
                value = minValue;
            }
            else
            {
                this.Text = value.ToString("X");
            }
        }

        private void SetValueModeValues(uint newValue)
        {
            if(validValues.Length == 1)
            {
                value = validValues[0];
                this.Text = value.ToString("X");
                valueIndex = 0;
                return;
            }

            for (int i = 0; i < validValues.Length - 1; i++)
            {
                uint lower = validValues[i];
                uint upper = validValues[i+1];

                if (newValue >= lower && newValue <= upper)
                {
                    if (newValue - lower < upper - newValue)
                    {
                        newValue = lower;
                        valueIndex = i;
                    }
                    else if (newValue - lower > upper - newValue)
                    {
                        newValue = upper;
                        valueIndex = i + 1;
                    }
                    else
                    {
                        newValue = lower;
                        valueIndex = i;
                    }

                    value = newValue;
                    this.Text = value.ToString("X");

                    return;
                }
            }

            newValue = validValues[0];
            valueIndex = 0;
        }


        private void UpdateTextChanged()
        {
            if (this.Text.Length > 0)
            {
                uint tempVal = Convert.ToUInt32(this.Text.Trim(), 16);
                SetValue(tempVal);
            }
        }


        private bool IsHexDigit(char c)
        {
            return (c >= 'a' && c <= 'f') ||
                    (c >= 'A' && c <= 'F') ||
                    (c >= '0' && c <= '9');
        }
        
        ////////////////////////////////////////
        // observer events
        ////////////////////////////////////////
        public void AddObserver(NotifyObserver o)
        {
            ValueChangedEvent += o;
        }

        public void RemoveObserver(NotifyObserver o)
        {
            ValueChangedEvent -= o;
        }

        public void Notify(NotifyParams p)
        {
            if (ValueChangedEvent != null)
                ValueChangedEvent(p);
        }


        ////////////////////////////////////////
        // control events
        ////////////////////////////////////////

        private void BitEdit_TextChanged(object sender, EventArgs e)
        {
            if (ChangeType == BitEditChange.Input)
            {
                UpdateTextChanged();
                Notify(new NotifyParams((int)value));
            }
        }

        void BitEdit_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Validate();
            
            if (e.Delta > 0)
            {
                Increase();
            }
            else
            {
                Decrease();
            }
            //this.OnTextChanged(EventArgs.Empty);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !IsHexDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                ChangeType = BitEditChange.Input;
            }

        }

        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
            Validate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }


        ////////////////////////////////////////
        // properties
        ////////////////////////////////////////

        public void Increase()
        {
            uint oldValue = value;
            increase();

            if (value != oldValue)
            {
                ChangeType = BitEditChange.Input;
                OnTextChanged(EventArgs.Empty);
            }
        }

        public void Decrease()
        {
            uint oldValue = value;
            decrease();

            if (value != oldValue)
            {
                ChangeType = BitEditChange.Input;
                OnTextChanged(EventArgs.Empty);
            }
        }

        public uint MinValue
        {
            set
            {
                ChangeType = BitEditChange.ValueSet;
                minValue = value;
                if (this.value < minValue)
                {
                    Value = value;
                }
            }
            get
            {
                return minValue;
            }
        }
        public uint MaxValue { 
            set
            {
                ChangeType = BitEditChange.ValueSet;
                maxValue = value;
                if (this.value > maxValue)
                {
                    Value = value;
                }
            }
            get { return maxValue; }
        }

        public uint Value
        {
            set
            {
                ChangeType = BitEditChange.ValueSet;
                SetValue(value);
            }

            get
            {
                return value;
            }
        }


    }
}
