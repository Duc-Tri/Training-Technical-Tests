using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using System.Xml.Linq;

namespace WPFAsync
{
    public partial class BackgroundWorkerSample : Window
    {
        const int NUMBER = 200;
        const int DIVIDER = 7;
        BackgroundWorker backgroundWorker = null;

        private readonly Action EmptyDelegate = delegate { };

        public BackgroundWorkerSample()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------

        private void btnDoSynchronousCalculation_Click(object sender, RoutedEventArgs e)
        {
            pbCalculationProgress.Value = 0;
            lbResults.Items.Clear();

            lbResults.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);

            int result = 0;
            for (int i = 0; i < NUMBER; i++)
            {
                if (i % DIVIDER == 0)
                {
                    lbResults.Items.Add(i);
                    result++;
                }
                System.Threading.Thread.Sleep(1);
                pbCalculationProgress.Value = Convert.ToInt32(((double)i / NUMBER) * 100);
            }
            MessageBoxResult(result.ToString());
        }

        //-------------------------------------------------------------------------------------------

        private void btnDoAsynchronousCalculation_Click(object sender, RoutedEventArgs e)
        {
            pbCalculationProgress.Value = 0;
            lbResults.Items.Clear();

            backgroundWorker = new BackgroundWorker();

            backgroundWorker.WorkerSupportsCancellation = true;

            // on ne peut faire rafaichir l'IHM  avec DoWork
            backgroundWorker.DoWork += worker_DoWork;

            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.ProgressChanged += worker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += worker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync(NUMBER);
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int max = (int)e.Argument;
            int result = 0;
            for (int i = 0; i < max; i++)
            {
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                int progressPercentage = Convert.ToInt32(((double)i / max) * 100);
                if (i % DIVIDER == 0)
                {
                    result++;
                    (sender as BackgroundWorker).ReportProgress(progressPercentage, i);
                }
                else
                    (sender as BackgroundWorker).ReportProgress(progressPercentage);
                System.Threading.Thread.Sleep(1);
            }
            e.Result = result;
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbCalculationProgress.Value = e.ProgressPercentage;
            if (e.UserState != null)
                lbResults.Items.Add(e.UserState);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show("BackgroundWorker Cancelled !");

            else
                MessageBoxResult(e.Result.ToString());
        }

        //-------------------------------------------------------------------------------------------

        private void btnCancelBackgroundWorker_Click(object sender, RoutedEventArgs e)
        {
            backgroundWorker.CancelAsync();
        }

        //-------------------------------------------------------------------------------------------

        private void MessageBoxResult(string result)
        {
            MessageBox.Show("Numbers between 0 and " + NUMBER + " divisible by " + DIVIDER + ": " + result);
        }

    }

}
