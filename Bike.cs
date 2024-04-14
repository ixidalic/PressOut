using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_test
{
    class Bike
    {
        private int _bikeLabel;
        private string _make;
        private string _type;
        private string _model;
        private int _year;
        private string _wheelSize;
        private string _frameType;
        private int _securityCode;
        private int _inStock;

        public int BikeLabel
        {
            get
            {
                return _bikeLabel;
            }

            set
            {
                _bikeLabel = value;
            }
        }
        public string Make
        {
            get
            {
                return _make;
            }

            set
            {
                _make = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public string Model
        {
            get
            {
                return _model;
            }

            set
            {
                _model = value;
            }
        }

        public int Year
        {
            get
            {
                return _year;
            }

            set
            {
                _year = value;
            }
        }

        public string WheelSize
        {
            get
            {
                return _wheelSize;
            }

            set
            {
                _wheelSize = value;
            }
        }

        public string FrameType
        {
            get
            {
                return _frameType;
            }

            set
            {
                _frameType = value;
            }
        }

        public int SecurityCode
        {
            get
            {
                return _securityCode;
            }

            set
            {
                _securityCode = value;
            }
        }
        public int InStock
        {
            get
            {
                return _inStock;
            }

            set
            {
                _inStock = value;
            }

        }

        public Bike() { }

        public Bike(int bikeLabel, string make, string type, string model, int year, string wheelSize, string frameType, int securityCode, int inStock)
        {
            BikeLabel = bikeLabel;
            Make = make;
            Type = type;
            Model = model;
            Year = year;
            WheelSize = wheelSize;
            FrameType = frameType;
            SecurityCode = securityCode;
            InStock = inStock;

        }
    }
}