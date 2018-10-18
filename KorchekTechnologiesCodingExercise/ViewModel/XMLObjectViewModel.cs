using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KorchekTechnologiesCodingExercise.Model;
using Microsoft.Win32;

namespace KorchekTechnologiesCodingExercise.ViewModel
{
    class XMLObjectViewModel : ViewModelBase
    {

        // member varialbles
        private XMLObject selectedObject_;
        public XMLObject SelectedObject
        {
            get { return selectedObject_;  }
            set { selectedObject_ = value;  }
        }
        private ObservableCollection<XMLObject> objects_;
        public ObservableCollection<XMLObject> Objects
        {
            get { return objects_;  }
            set {
                objects_ = value;
                RaisePropertyChanged(() => Objects);
            }
        }

        private string filePath_;
        public string FilePath
        {
            get { return filePath_; }
            set { filePath_ = value; }
        }
        private string fileName_;
        public string FileName
        {
            get { return fileName_; }
            set { fileName_ = value; }
        }

        private XDocument xDoc_;
        public XDocument XDoc
        {
            get { return xDoc_;  }
            set { xDoc_ = value;  }
        }

        // this is needed to set visibility of error messages
        public Visibility AddErrorVisibility { get; set; }
        public Visibility EditErrorVisibility { get; set; }
        

        // accessors & modifiers for use with add/edit forms
        private string addName_;
        public string AddName
        {
            get { return addName_; }
            set
            {
                addName_ = value;
                RaisePropertyChanged(() => AddName);
            }
        }

        private string addDOB_;
        public string AddDOB
        {
            get { return addDOB_; }
            set
            {
                addDOB_ = value;
                RaisePropertyChanged(() => AddDOB);
            }
        }

        private string addNumberOfWidgets_;
        public string AddNumberOfWidgets
        {
            get { return addNumberOfWidgets_; }
            set
            {
                addNumberOfWidgets_ = value;
                RaisePropertyChanged(() => AddNumberOfWidgets);
            }
        }

        // commands
        private RelayCommand loadCommand_;
        public RelayCommand LoadCommand
        {
            get { return loadCommand_; }
            set { loadCommand_ = value; }
        }

        private RelayCommand saveCommand_;
        public RelayCommand SaveCommand
        {
            get { return saveCommand_; }
            set { saveCommand_ = value; }
        }

        private RelayCommand addCommand_;
        public RelayCommand AddCommand
        {
            get { return addCommand_; }
            set { addCommand_ = value; }
        }

        // constructor
        public XMLObjectViewModel()
        {

            // commands
            loadCommand_ = new RelayCommand(LoadXMLFromFile);
            saveCommand_ = new RelayCommand(SaveXML);
            addCommand_ = new RelayCommand(AddElement);

            
        }

        // load
        private void LoadXMLFromFile()
        {

            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == true)
            {
                FilePath = ofd.FileName;
                FileName = ofd.SafeFileName;
                XDoc = XDocument.Load(FilePath);
                Stream fs = ofd.OpenFile();
                ReadXML(fs);
            }
        }

        // read xml
        private void ReadXML(Stream fs)
        {
            ObservableCollection<XMLObject> objects = new ObservableCollection<XMLObject>();
            XmlReader xreader = XmlReader.Create(fs);
            

            while (xreader.Read())
            {
                if (xreader.IsStartElement() && xreader.Name.Equals("ExampleObject"))
                {
                    string objName = xreader.GetAttribute("Name");
                    DateTime objDOB = DateTime.Parse(xreader.GetAttribute("DOB"));
                    int objNumberOfWidgets = System.Convert.ToInt32(xreader.GetAttribute("NumberOfWidgets"));

                    objects.Add(new XMLObject(objName, objDOB, objNumberOfWidgets));
                }
            }

            Objects = objects;
           
        }

        // save xml
        private void SaveXML()
        { 

            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<XMLObject>));
            using (StreamWriter wr = new StreamWriter(FilePath))
            {
                xs.Serialize(wr, Objects);
            }
        }

        private void AddElement()
        {
           if (string.IsNullOrEmpty(AddName) || string.IsNullOrEmpty(AddDOB) || string.IsNullOrEmpty(AddNumberOfWidgets))
            {
                AddErrorVisibility = Visibility.Visible;
            }
           else
            {
                AddErrorVisibility = Visibility.Hidden;

                string newName = AddName;
                DateTime newDOB = DateTime.Parse(AddDOB);
                int newNumberOfWidgets = Convert.ToInt32(AddNumberOfWidgets);

                XMLObject newObject = new XMLObject(newName, newDOB, newNumberOfWidgets);
                objects_.Add(newObject);
            }
        }

       
    }
}
