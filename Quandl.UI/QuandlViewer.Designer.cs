namespace Quandl.UI {
  partial class QuandlViewer {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      this.displayButton = new System.Windows.Forms.Button();
      this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
      this.SuspendLayout();
      // 
      // displayButton
      // 
      this.displayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.displayButton.Location = new System.Drawing.Point(664, 390);
      this.displayButton.Name = "displayButton";
      this.displayButton.Size = new System.Drawing.Size(75, 23);
      this.displayButton.TabIndex = 0;
      this.displayButton.Text = "Display data";
      this.displayButton.UseVisualStyleBackColor = true;
      this.displayButton.Click += new System.EventHandler(this.displayButton_Click);
      // 
      // chart
      // 
      this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      chartArea1.Name = "ChartArea1";
      this.chart.ChartAreas.Add(chartArea1);
      legend1.Name = "Legend1";
      this.chart.Legends.Add(legend1);
      this.chart.Location = new System.Drawing.Point(12, 12);
      this.chart.Name = "chart";
      this.chart.Size = new System.Drawing.Size(727, 372);
      this.chart.TabIndex = 1;
      this.chart.Text = "chart";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(751, 425);
      this.Controls.Add(this.chart);
      this.Controls.Add(this.displayButton);
      this.Name = "Form1";
      this.Text = "Quandl Stock Viewer";
      ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button displayButton;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart;
  }
}

