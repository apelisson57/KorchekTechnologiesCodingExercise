using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace KorchekTechnologiesCodingExercise.Model
{
    public class XMLObjectModel {}

    public class XMLObject : INotifyPropertyChanged
    {

        // member variables
        private string name_;
        private DateTime dob_;
        private int numberOfWidgets_;

        // accessors
        public string Name
        {
            get { return name_; }

            set
            {
                if (name_ != value)
                {
                    name_ = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public DateTime DOB
        {
            get { return dob_; }

            set
            {
                if (dob_ != value)
                {
                    dob_ = value;
                    RaisePropertyChanged("DOB");
                    
                }
            }
        }

        public int NumberOfWidgets
        {
            get { return numberOfWidgets_; }

            set
            {
                if (numberOfWidgets_ != value)
                {
                    numberOfWidgets_ = value;
                    RaisePropertyChanged("NumberOfWidgets");

                }
            }
        }

        // constructors
        public XMLObject()
        {
            name_ = "";
            dob_ = new DateTime();
            numberOfWidgets_ = 0;
        }

        public XMLObject(string name, DateTime dob, int numberOfWidgets)
        {
            name_ = name;
            dob_ = dob;
            numberOfWidgets_ = numberOfWidgets;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }


    }
}
