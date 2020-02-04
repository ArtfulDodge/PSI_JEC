using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace PP2_JEC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int PSI = 0;
            int age = 0;
            bool allPointsFromAge = true;
            String sex;
            int nursingHome = 0;
            int cancer = 0;
            int liverDisease = 0;
            int heartFailure = 0;
            int cerebrovascularDisease = 0;
            int renalDisease = 0;
            int alteredMentalStatus = 0;
            int pleuralEffusion = 0;
            double respiratoryRate = 0;
            double bloodPressure = 0;
            double temperature = 0;
            bool celsius = true;
            double pulse = 0;
            double pH = 0;
            double BUN = 0;
            bool BUNmgdl = true;
            double sodium = 0;
            double glucose = 0;
            bool glucosemgdl = true;
            double hematocrit = 0;
            double oxygenPressure = 0;
            bool oxygenmmhg = true;

            try
            {
                age = Int32.Parse(txtAge.Text);
            } catch (Exception except)
            {
                MessageBox.Show("Please enter a valid age.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            PSI += age;

            try
            {
                respiratoryRate = Double.Parse(txtRespRate.Text);
            } catch (Exception except)
            {
                MessageBox.Show("Please enter a valid respiratory rate.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            if (respiratoryRate >= 30)
            {
                PSI += 20;
                if (allPointsFromAge)
                {
                    allPointsFromAge = false;
                }
            }

            try
            {
                bloodPressure = Double.Parse(txtBloodPressure.Text);
            } catch (Exception except)
            {
                MessageBox.Show("Please enter a valid systolic blood pressure.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            if (bloodPressure < 90)
            {
                PSI += 20;
                if (allPointsFromAge)
                {
                    allPointsFromAge = false;
                }
            }

            try
            {
                temperature = Double.Parse(txtTemperature.Text);
            }
            catch (Exception except)
            {
                MessageBox.Show("Please enter a valid temperature.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            if (rdoCelsius.IsChecked == true)
            {
                if (temperature < 35 || temperature > 39.9)
                {
                    PSI += 15;
                    if (allPointsFromAge)
                    {
                        allPointsFromAge = false;
                    }
                }
            } else if (rdoFahrenheit.IsChecked == true)
            {
                celsius = false;
                if (temperature < 95 || temperature > 103.8)
                {
                    PSI += 15;
                    if (allPointsFromAge)
                    {
                        allPointsFromAge = false;
                    }
                }
            }

            try
            {
                pulse = Double.Parse(txtPulse.Text);
            }
            catch (Exception except)
            {
                MessageBox.Show("Please enter a valid pulse.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            if (pulse >= 125)
            {
                PSI += 10;
                if (allPointsFromAge)
                {
                    allPointsFromAge = false;
                }
            }

            try
            {
                pH = Double.Parse(txtPH.Text);
            }
            catch (Exception except)
            {
                MessageBox.Show("Please enter a valid pH value.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            if (pH < 7.35)
            {
                PSI += 30;
                if (allPointsFromAge)
                {
                    allPointsFromAge = false;
                }
            }

            try
            {
                BUN = Double.Parse(txtBUN.Text);
            }
            catch (Exception except)
            {
                MessageBox.Show("Please enter a valid BUN.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            if (rdoBUNmg.IsChecked == true)
            {
                if (BUN >= 30)
                {
                    PSI += 20;
                    if (allPointsFromAge)
                    {
                        allPointsFromAge = false;
                    }
                }
            } else if (rdoBUNmmol.IsChecked == true)
            {
                BUNmgdl = false;
                if (BUN >= 11)
                {
                    PSI += 20;
                    if (allPointsFromAge)
                    {
                        allPointsFromAge = false;
                    }
                }
            }

            try
            {
                sodium = Double.Parse(txtSodium.Text);
            }
            catch (Exception except)
            {
                MessageBox.Show("Please enter a valid sodium value.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            if (sodium < 130)
            {
                PSI += 20;
                if (allPointsFromAge)
                {
                    allPointsFromAge = false;
                }
            }

            try
            {
                glucose = Double.Parse(txtGlucose.Text);
            }
            catch (Exception except)
            {
                MessageBox.Show("Please enter a valid glucose value.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            if (rdoGlucoseMg.IsChecked == true)
            {
                if (glucose >= 250)
                {
                    PSI += 10;
                    if (allPointsFromAge)
                    {
                        allPointsFromAge = false;
                    }
                }
            } else if (rdoGlucoseMmol.IsChecked == true)
            {
                glucosemgdl = false;
                if (glucose >= 14)
                {
                    PSI += 10;
                    if (allPointsFromAge)
                    {
                        allPointsFromAge = false;
                    }
                }
            }

            try
            {
                hematocrit = Double.Parse(txtHematocrit.Text);
            }
            catch (Exception except)
            {
                MessageBox.Show("Please enter a valid hematocrit percentage.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            if (hematocrit < 30)
            {
                PSI += 10;
                if (allPointsFromAge)
                {
                    allPointsFromAge = false;
                }
            }

            try
            {
                oxygenPressure = Double.Parse(txtOxygenPressure.Text);
            }
            catch (Exception except)
            {
                MessageBox.Show("Please enter a valid partial oxygen pressure.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            if (rdoOxygenMmHg.IsChecked == true)
            {
                if (oxygenPressure < 60)
                {
                    PSI += 10;
                    if (allPointsFromAge)
                    {
                        allPointsFromAge = false;
                    }
                }
            } else if (rdoOxygenKPa.IsChecked == true)
            {
                oxygenmmhg = false;
                if (oxygenPressure < 8)
                {
                    PSI += 10;
                    if (allPointsFromAge)
                    {
                        allPointsFromAge = false;
                    }
                }
            }

            if (rdoFemale.IsChecked == true)
            {
                PSI -= 10;
                sex = "F";
            } else if (rdoMale.IsChecked == true)
            {
                sex = "M";
            } else
            {
                MessageBox.Show("Please select a sex.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            if (chkNursingHome.IsChecked == true)
            {
                PSI += 10;
                nursingHome = 1;
                if (allPointsFromAge)
                {
                    allPointsFromAge = false;
                }
            }

            if (chkCancer.IsChecked == true)
            {
                PSI += 30;
                cancer = 1;
                if (allPointsFromAge)
                {
                    allPointsFromAge = false;
                }
            }

            if (chkLiverDisease.IsChecked == true)
            {
                PSI += 20;
                liverDisease = 1;
                if (allPointsFromAge)
                {
                    allPointsFromAge = false;
                }
            }

            if (chkHeartFailure.IsChecked == true)
            {
                PSI += 10;
                heartFailure = 1;
                if (allPointsFromAge)
                {
                    allPointsFromAge = false;
                }
            }

            if (chkCerebrovascularDisease.IsChecked == true)
            {
                PSI += 10;
                cerebrovascularDisease = 1;
                if (allPointsFromAge)
                {
                    allPointsFromAge = false;
                }
            }

            if (chkRenalDisease.IsChecked == true)
            {
                PSI += 10;
                renalDisease = 1;
                if (allPointsFromAge)
                {
                    allPointsFromAge = false;
                }
            }

            if (chkMentalStatus.IsChecked == true)
            {
                PSI += 20;
                alteredMentalStatus = 1;
                if (allPointsFromAge)
                {
                    allPointsFromAge = false;
                }
            }

            if (chkPleuralEffusion.IsChecked == true)
            {
                PSI += 10;
                pleuralEffusion = 1;
                if (allPointsFromAge)
                {
                    allPointsFromAge = false;
                }
            }

            String riskClass;
            String admissionStatus = "Outpatient Care";

            if (PSI <= 0 || allPointsFromAge)
            {
                riskClass = "I";
            } else if (PSI <= 70)
            {
                riskClass = "II";
            } else if (PSI <= 90)
            {
                riskClass = "III";
                admissionStatus = "Outpatient or Observation Admission";
            } else if (PSI <= 130)
            {
                riskClass = "IV";
                admissionStatus = "Inpatient Admission";
            } else
            {
                riskClass = "V";
                admissionStatus = "Inpatient Admission (check for sepsis)";
            }

            String result = "Risk Class: " + riskClass + "\nRecommended Admission Status: " + admissionStatus;
            MessageBox.Show(result, "Result", MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.OK);

            String fileName = "data.csv";
            int id = 1;
            bool firstLine = true;

            if (File.Exists(fileName))
            {
                try 
                {
                    String lastLine = File.ReadLines(fileName).Last();
                    id = Int32.Parse(lastLine.Substring(0, lastLine.IndexOf(","))) + 1;
                    firstLine = false;
                } catch (Exception except)
                {
                    firstLine = true;
                }
                
            }

            if (!celsius)
                temperature = ToCelsius(temperature);

            if (!BUNmgdl)
                BUN = BUNToMgdl(BUN);

            if (!glucosemgdl)
                glucose = GlucoseToMgdl(glucose);

            if (!oxygenmmhg)
                oxygenPressure = ToMmHg(oxygenPressure);

            StreamWriter sw = new StreamWriter(fileName, true);
            if (!firstLine)
                sw.WriteLine();
            sw.Write(id.ToString() + ", " + age.ToString() + ", " + sex + ", " + nursingHome.ToString() + ", " + cancer.ToString() + ", " + liverDisease.ToString() + ", " + heartFailure.ToString() + ", " + cerebrovascularDisease.ToString() + ", " + 
                renalDisease.ToString() + ", " + alteredMentalStatus.ToString() + ", " + respiratoryRate.ToString() + ", " + bloodPressure.ToString() + ", " + temperature.ToString() + ", " + pulse.ToString() + ", " + pH.ToString() + ", " + 
                BUN.ToString() + ", " + sodium.ToString() + ", " + glucose.ToString() + ", " + hematocrit.ToString() + ", " + oxygenPressure.ToString() + ", " + pleuralEffusion.ToString());
            sw.Close();
        }

        private double ToCelsius(double temp)
        {
            return (temp - 32.0) * (5.0 / 9.0);
        }

        private double BUNToMgdl(double input)
        {
            return input * 2.80112;
        }

        private double GlucoseToMgdl(double input)
        {
            return input * 18.018018;
        }

        private double ToMmHg(double input)
        {
            return input * 7.50061683;
        }
    }
}