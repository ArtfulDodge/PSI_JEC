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
            double respitoryRate = 0;
            double bloodPressure = 0;
            double temperature = 0;
            double pulse = 0;
            double pH = 0;
            double BUN = 0;
            double sodium = 0;
            double glucose = 0;
            double hematocrit = 0;
            double oxygenPressure = 0;

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
                respitoryRate = Double.Parse(txtRespRate.Text);
            } catch (Exception except)
            {
                MessageBox.Show("Please enter a valid respitory rate.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            if (respitoryRate >= 30)
            {
                PSI += 20;
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
                }
            } else if (rdoFahrenheit.IsChecked == true)
            {
                if (temperature < 95 || temperature > 103.8)
                {
                    PSI += 15;
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
                }
            } else if (rdoBUNmmol.IsChecked == true)
            {
                if (BUN >= 11)
                {
                    PSI += 20;
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
                }
            } else if (rdoGlucoseMmol.IsChecked == true)
            {
                if (glucose >= 14)
                {
                    PSI += 10;
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
                }
            } else if (rdoOxygenKPa.IsChecked == true)
            {
                if (oxygenPressure < 8)
                {
                    PSI += 10;
                }
            }

            if (rdoFemale.IsChecked == true)
            {
                PSI -= 10;
            } else if (rdoMale.IsChecked == false)
            {
                MessageBox.Show("Please select a sex.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            if (chkNursingHome.IsChecked == true)
            {
                PSI += 10;
            }

            if (chkCancer.IsChecked == true)
            {
                PSI += 30;
            }

            if (chkLiverDisease.IsChecked == true)
            {
                PSI += 20;
            }

            if (chkHeartFailure.IsChecked == true)
            {
                PSI += 10;
            }

            if (chkCerebrovascularDisease.IsChecked == true)
            {
                PSI += 10;
            }

            if (chkRenalDisease.IsChecked == true)
            {
                PSI += 10;
            }

            if (chkMentalStatus.IsChecked == true)
            {
                PSI += 20;
            }

            if (chkPleuralEffusion.IsChecked == true)
            {
                PSI += 10;
            }

            String riskClass;
            String admissionStatus = "Outpatient Care";

            if (PSI <= 0)
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
        }
    }
}
