namespace TVS1TO10ConveretrMinHistoricalData
{
    partial class TVS1TO10ConveretrMinHistoricalData
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.servicetimer = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.servicetimer)).BeginInit();
            // 
            // servicetimer
            // 
            this.servicetimer.AutoReset = false;
            this.servicetimer.Enabled = true;
            this.servicetimer.Elapsed += new System.Timers.ElapsedEventHandler(this.servicetimer_Elapsed);
            // 
            // TVS1TO10ConveretrMinHistoricalData
            // 
            this.ServiceName = "Service1";
            ((System.ComponentModel.ISupportInitialize)(this.servicetimer)).EndInit();

        }

        #endregion

        private System.Timers.Timer servicetimer;
    }
}
